using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using log4net;
using MissionPlanner.Plugin;
using MissionPlanner.Utilities;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;

namespace MissionPlanner.SprayPlanner
{
    public partial class GridUI : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        const double rad2deg = (180 / Math.PI);
        const double deg2rad = (1.0 / rad2deg);

        GMapOverlay layerpolygons;
        GMapPolygon wppoly;
        private GridPlugin plugin;
        List<PointLatLngAlt> grid;

        public GridUI(GridPlugin plugin)
        {
            this.plugin = plugin;

            InitializeComponent();

            map.MapProvider = plugin.Host.FDMapType;

            layerpolygons = new GMapOverlay( "polygons");
            map.Overlays.Add(layerpolygons);

            CMB_startfrom.DataSource = Enum.GetNames(typeof(Utilities.Grid.StartPosition));
            CMB_startfrom.SelectedIndex = 0;

            // set and angle that is good
            list = new List<PointLatLngAlt>();
            plugin.Host.FPDrawnPolygon.Points.ForEach(x => { list.Add(x); });
            NUM_angle.Value = (decimal)((getAngleOfLongestSide(list) + 360) % 360);

            // Map Events
            map.OnMarkerEnter += new MarkerEnter(map_OnMarkerEnter);
            map.OnMarkerLeave += new MarkerLeave(map_OnMarkerLeave);
            map.MouseUp += new MouseEventHandler(map_MouseUp);
            map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map_MouseDown);
            map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_MouseMove);
        }

        void loadsettings()
        {
            if (plugin.Host.config.ContainsKey("sprayplan_alt"))
            {
                
                loadsetting("sprayplan_alt", NUM_altitude);
                loadsetting("sprayplan_dist", NUM_Distance);
                loadsetting("sprayplan_pump_pwm", NUM_PumpPWM);
                loadsetting("sprayplan_pump_servo", NUM_Pump_servo);
                loadsetting("sprayplan_spinner_pwm", NUM_SpinnerPWM);
                loadsetting("sprayplan_spinner_servo", NUM_Spinner_servo);
                loadsetting("sprayplan_tank_low", NUM_tank_low);
                loadsetting("sprayplan_spray_delay", NUM_spray_delay);



            }
            else
            {
                plugin.Host.config["sprayplan_pump_pwm"] = "1800";
                plugin.Host.config["sprayplan_pump_servo"] = "9";
                plugin.Host.config["sprayplan_spinner_pwm"] = "1700";
                plugin.Host.config["sprayplan_spinner_servo"] = "10";
                plugin.Host.config["sprayplan_tank_low"] = "35";
            }


        }

        void loadsetting(string key, Control item)
        {
            if (plugin.Host.config.ContainsKey(key))
            {
                if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = decimal.Parse(plugin.Host.config[key].ToString());
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Text = plugin.Host.config[key].ToString();
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)item).Checked = bool.Parse(plugin.Host.config[key].ToString());
                }
                else if (item is RadioButton)
                {
                    ((RadioButton)item).Checked = bool.Parse(plugin.Host.config[key].ToString());
                }
            }
        }

        void savesettings()
        {
            plugin.Host.config["sprayplan_alt"] = NUM_altitude.Value.ToString();
            plugin.Host.config["sprayplan_angle"] = NUM_angle.Value.ToString();
            plugin.Host.config["sprayplan_dist"] = NUM_Distance.Value.ToString();
            plugin.Host.config["sprayplan_pump_pwm"] = NUM_PumpPWM.Value.ToString();
            plugin.Host.config["sprayplan_pump_servo"] = NUM_Pump_servo.Value.ToString();
            plugin.Host.config["sprayplan_spinner_pwm"] = NUM_SpinnerPWM.Value.ToString();
            plugin.Host.config["sprayplan_spinner_servo"] = NUM_Spinner_servo.Value.ToString();
            plugin.Host.config["sprayplan_tank_low"] = NUM_tank_low.Value.ToString();
            plugin.Host.config["sprayplan_spray_delay"] = NUM_spray_delay.Value.ToString();




        }

        List<PointLatLngAlt> list = new List<PointLatLngAlt>();
        internal PointLatLng MouseDownStart = new PointLatLng();
        internal PointLatLng MouseDownEnd;
        internal PointLatLngAlt CurrentGMapMarkerStartPos;
        PointLatLng currentMousePosition;
        GMapMarker marker;
        GMapMarker CurrentGMapMarker = null;
        int CurrentGMapMarkerIndex = 0;
        bool isMouseDown = false;
        bool isMouseDraging = false;
        static public Object thisLock = new Object();

        public PluginHost Host2 { get; private set; }

        private void map_OnMarkerLeave(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarker)
                {
                    // when you click the context menu this triggers and causes problems
                    CurrentGMapMarker = null;
                }

            }
        }

        private void map_OnMarkerEnter(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarker)
                {
                    CurrentGMapMarker = item as GMapMarker;
                    CurrentGMapMarkerStartPos = CurrentGMapMarker.Position;
                }
            }
        }

        private void map_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDownEnd = map.FromLocalToLatLng(e.X, e.Y);

            // Console.WriteLine("MainMap MU");

            if (e.Button == MouseButtons.Right) // ignore right clicks
            {
                return;
            }

            if (isMouseDown) // mouse down on some other object and dragged to here.
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = false;
                }
                if (!isMouseDraging)
                {
                    if (CurrentGMapMarker != null)
                    {
                        // Redraw polygon
                        //AddDrawPolygon();
                    }
                }
            }
            isMouseDraging = false;
            CurrentGMapMarker = null;
            CurrentGMapMarkerIndex = 0;
            CurrentGMapMarkerStartPos = null;
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownStart = map.FromLocalToLatLng(e.X, e.Y);

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Alt)
            {
                isMouseDown = true;
                isMouseDraging = false;

                if (CurrentGMapMarkerStartPos != null)
                    CurrentGMapMarkerIndex = list.FindIndex(c => c.ToString() == CurrentGMapMarkerStartPos.ToString());
            }
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = map.FromLocalToLatLng(e.X, e.Y);
            currentMousePosition = point;

            if (MouseDownStart == point)
                return;

            if (!isMouseDown)
            {
                // update mouse pos display
                //SetMouseDisplay(point.Lat, point.Lng, 0);
            }

            //draging
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                isMouseDraging = true;

                if (CurrentGMapMarker != null)
                {
                    if (CurrentGMapMarkerIndex == -1)
                    {
                        isMouseDraging = false;
                        return;
                    }

                    PointLatLng pnew = map.FromLocalToLatLng(e.X, e.Y);

                    CurrentGMapMarker.Position = pnew;

                    list[CurrentGMapMarkerIndex] = new PointLatLngAlt(pnew);
                    domainUpDown1_ValueChanged(sender, e);
                }
                else // left click pan
                {
                    double latdif = MouseDownStart.Lat - point.Lat;
                    double lngdif = MouseDownStart.Lng - point.Lng;

                    try
                    {
                        lock (thisLock)
                        {
                            map.Position = new PointLatLng(map.Position.Lat + latdif, map.Position.Lng + lngdif);
                        }
                    }
                    catch { }
                }
            }
        }

        void AddDrawPolygon()
        {
            List<PointLatLng> list2 = new List<PointLatLng>();

            list.ForEach(x => { list2.Add(x); });

            var poly = new GMapPolygon(list2, "poly");
            poly.Stroke = new Pen(Color.Red, 2);
            poly.Fill = Brushes.Transparent;

            layerpolygons.Polygons.Add(poly);

            foreach (var item in list)
            {
                layerpolygons.Markers.Add(new GMarkerGoogle(item, GMarkerGoogleType.red));
            }
        }

        double getAngleOfLongestSide(List<PointLatLngAlt> list)
        {
            double angle = 0;
            double maxdist = 0;
            PointLatLngAlt last = list[list.Count - 1];
            foreach (var item in list)
            {
                 if (item.GetDistance(last) > maxdist) 
                 {
                     angle = item.GetBearing(last);
                     maxdist = item.GetDistance(last);
                 }
                 last = item;
            }

            return (angle + 360) % 360;
        }

        private void domainUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Host2 = plugin.Host;

            grid = Utilities.Grid.CreateGrid(list, (double) NUM_altitude.Value, (double) NUM_Distance.Value,
                (double) 5000, (double) NUM_angle.Value, (double) 0,
                (double) 0,
                (Utilities.Grid.StartPosition) Enum.Parse(typeof(Utilities.Grid.StartPosition), CMB_startfrom.Text),
                false, 0, 0, plugin.Host.cs.HomeLocation);

            List<PointLatLng> list2 = new List<PointLatLng>();

            grid.ForEach(x => { list2.Add(x); });

            map.HoldInvalidation = true;

            layerpolygons.Polygons.Clear();
            layerpolygons.Markers.Clear();


            if (chk_boundary.Checked)
                AddDrawPolygon();

            if (grid.Count == 0)
            {
                map.ZoomAndCenterMarkers("polygons");
                return;
            }

            int strips = 0;
            int a = 1;
            PointLatLngAlt prevpoint = grid[0];
            foreach (var item in grid)
            {
                if (item.Tag == "M")
                {
                    if (CHK_internals.Checked)
                    {
                        layerpolygons.Markers.Add(new GMarkerGoogle(item, GMarkerGoogleType.yellow_pushpin) { ToolTipText = a.ToString(), ToolTipMode = MarkerTooltipMode.OnMouseOver });
                        a++;
                    }
                }
                else
                {
                    if (item.Tag == "S" || item.Tag == "E")
                    {
                        strips++;
                        if (chk_markers.Checked)
                            layerpolygons.Markers.Add(new GMarkerGoogle(item, GMarkerGoogleType.green)
                            {
                                ToolTipText = a.ToString(),
                                ToolTipMode = MarkerTooltipMode.OnMouseOver
                            });

                        a++;
                    }
                }
                prevpoint = item;
            }

            // add wp polygon
            wppoly = new GMapPolygon(list2, "Grid");
            wppoly.Stroke.Color = Color.Yellow;
            wppoly.Fill = Brushes.Transparent;
            wppoly.Stroke.Width = 4;
            if (chk_grid.Checked)
                layerpolygons.Polygons.Add(wppoly);

            Console.WriteLine("Poly Dist " + wppoly.Distance);

            lbl_area.Text = calcpolygonarea(plugin.Host.FPDrawnPolygon.Points).ToString("#") + " m^2 / " + (calcpolygonarea(plugin.Host.FPDrawnPolygon.Points)/10000).ToString("0.###") + " ha";

            lbl_distance.Text = wppoly.Distance.ToString("0.##") + " km";
            lbl_grid_points.Text = grid.Count.ToString("#");


            lbl_strips.Text = ((int)(strips / 2)).ToString();
            lbl_distbetweenlines.Text = NUM_Distance.Value.ToString("0.##") + " m";

                map.HoldInvalidation = false;

            map.ZoomAndCenterMarkers("polygons");

        }

        double calcpolygonarea(List<PointLatLng> polygon)
        {
            // should be a closed polygon
            // coords are in lat long
            // need utm to calc area

            if (polygon.Count == 0)
            {
                CustomMessageBox.Show("Please define a polygon!");
                return 0;
            }

            // close the polygon
            if (polygon[0] != polygon[polygon.Count - 1])
                polygon.Add(polygon[0]); // make a full loop

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();

            IGeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;

            int utmzone = (int)((polygon[0].Lng - -186.0) / 6.0);

            IProjectedCoordinateSystem utm = ProjectedCoordinateSystem.WGS84_UTM(utmzone, polygon[0].Lat < 0 ? false : true);

            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, utm);

            double prod1 = 0;
            double prod2 = 0;

            for (int a = 0; a < (polygon.Count - 1); a++)
            {
                double[] pll1 = { polygon[a].Lng, polygon[a].Lat };
                double[] pll2 = { polygon[a + 1].Lng, polygon[a + 1].Lat };

                double[] p1 = trans.MathTransform.Transform(pll1);
                double[] p2 = trans.MathTransform.Transform(pll2);

                prod1 += p1[0] * p2[1];
                prod2 += p1[1] * p2[0];
            }

            double answer = (prod1 - prod2) / 2;

            if (polygon[0] == polygon[polygon.Count - 1])
                polygon.RemoveAt(polygon.Count - 1); // unmake a full loop

            return Math.Abs( answer);
        }

        private void BUT_Accept_Click(object sender, EventArgs e)
        {
            bool row_end_indicator = false;

            plugin.spray_delay = (int)NUM_spray_delay.Value;

            if (grid!=null)
            {
                if ((plugin.spray_delay > 0) && (grid.Count > 350)) {
                    CustomMessageBox.Show("Grid is too big for one mission, decrease area", "Error");
                    return;
                }
                if ((plugin.spray_delay == 0) && (grid.Count > 460))
                {
                    CustomMessageBox.Show("Grid is too big for one mission, decrease area", "Error");
                    return;
                }
            }




            if (grid != null && grid.Count > 0)
            {
                MainV2.instance.FlightPlanner.quickadd = true;

                PointLatLngAlt lastpnt = PointLatLngAlt.Zero;

                //Add start commands
                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Pump_servo.Value, 1000, 0, 0, 0, 0, 0);     //Filler for empty spaces
                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Spinner_servo.Value, 1000, 0, 0, 0, 0, 0);     //Filler for empty spaces
                //plugin.Host.AddWPtoList(MAVLink.MAV_CMD.CONDITION_YAW, (double)NUM_angle.Value, 0, 0, 0, 0, 0, 0);     //Filler for empty spaces


                grid.ForEach(plla =>
                {
                    if (plla.Tag != "M")
                    {
                        if (!(plla.Lat == lastpnt.Lat && plla.Lng == lastpnt.Lng && plla.Alt == lastpnt.Alt))
                        {
                            plugin.Host.AddWPtoList(MAVLink.MAV_CMD.WAYPOINT, 1, 0, 0, 0, plla.Lng, plla.Lat, plla.Alt);        // Go to the next waypoint, add 1 sec wait for 
                            if (!row_end_indicator)
                            {
                                if (plugin.spray_delay > 0) plugin.Host.AddWPtoList(MAVLink.MAV_CMD.CONDITION_DELAY, (double)NUM_spray_delay.Value, 0, 0, 0, 0, 0, 0);
                                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Pump_servo.Value, (double)NUM_PumpPWM.Value, 0, 0, 0, 0, 0);                     // Start spraying
                                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Spinner_servo.Value, (double)NUM_SpinnerPWM.Value, 0, 0, 0, 0, 0);                     // Start spraying
                            }
                            else
                            {
                                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Pump_servo.Value, 1000, 0, 0, 0, 0, 0);                     // Stop spraying
                                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Spinner_servo.Value, 1000, 0, 0, 0, 0, 0);                     // Stop spraying

                            }
                            row_end_indicator = !row_end_indicator;
                        }

                        lastpnt = plla;
                    }

                });
                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Pump_servo.Value, 1000, 0, 0, 0, 0, 0);     //Stop spraying
                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.DO_SET_SERVO, (double)NUM_Spinner_servo.Value, 1000, 0, 0, 0, 0, 0);    //Stop Spinners as well
                plugin.Host.AddWPtoList(MAVLink.MAV_CMD.RETURN_TO_LAUNCH, 0, 0, 0, 0, 0, 0, 0);              //Let's go home

                MainV2.instance.FlightPlanner.quickadd = false;

                MainV2.instance.FlightPlanner.writeKML();

                //Save servo and pump parameters for using in plugin
                plugin.pump_servo = (double)NUM_Pump_servo.Value;
                plugin.pump_pwm = (double)NUM_PumpPWM.Value;
                plugin.spinner_servo = (double)NUM_Spinner_servo.Value;
                plugin.spinner_pwm = (double)NUM_SpinnerPWM.Value;
                plugin.angle = (double)NUM_angle.Value;
                plugin.tank_low = (int)NUM_tank_low.Value;
                plugin.spray_delay = (int)NUM_spray_delay.Value;

                savesettings();

                this.Close();
            }
            else
            {
                CustomMessageBox.Show("Bad Grid", "Error");
            }
        }

        private void GridUI_Resize(object sender, EventArgs e)
        {
            map.ZoomAndCenterMarkers("polygons");
        }

        private void GridUI_Load(object sender, EventArgs e)
        {
            loadsettings();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

