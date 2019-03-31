using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace MissionPlanner.SprayPlanner
{
    public class GridPlugin : MissionPlanner.Plugin.Plugin
    {
        public static MissionPlanner.Plugin.PluginHost Host2;
        public static Utilities.PointLatLngAlt continue_point;
        public static float continue_wp;
        public static bool bWaitforSprayer;

        ToolStripMenuItem but;
        ToolStripMenuItem but1;
        MissionPlanner.Controls.MyDataGridView commands;
        public static String pervious_mode;

        private GMapOverlay mapOverlayFP;
        private GMapOverlay mapOverlayFD;

        public double pump_servo, pump_pwm, spinner_servo, spinner_pwm,angle;
        public int tank_low;
        public int spray_delay;

        public override string Name
        {
            get { return "SprayPlanner"; }
        }

        public override string Version
        {
            get { return "0.2"; }
        }

        public override string Author
        {
            get { return "Schaffer Andras"; }
        }

        public override bool Init()
        {
            loopratehz = 0.5f;
            pervious_mode = "none";
            return true;
        }

        public override bool Loaded()
        {
            Host2 = Host;

            but = new ToolStripMenuItem("SprayPlanner");
            but.Click += but_Click;

            bool hit = false;
            ToolStripItemCollection col = Host.FPMenuMap.Items;

            col.Insert(0, but);

            this.mapOverlayFD = new GMapOverlay("return_point");
            this.mapOverlayFP = new GMapOverlay("return_point");

            Host.FDGMapControl.Overlays.Add(this.mapOverlayFD);
            Host.FPGMapControl.Overlays.Add(this.mapOverlayFP);


            if (Host.config.ContainsKey("sprayplan_pump_pwm")) pump_pwm = double.Parse(Host.config["sprayplan_pump_pwm"].ToString());
            if (Host.config.ContainsKey("sprayplan_pump_servo")) pump_servo = double.Parse(Host.config["sprayplan_pump_servo"].ToString());
            if (Host.config.ContainsKey("sprayplan_spinner_pwm")) spinner_pwm = double.Parse(Host.config["sprayplan_spinner_pwm"].ToString());
            if (Host.config.ContainsKey("sprayplan_spinner_servo")) spinner_servo = double.Parse(Host.config["sprayplan_spinner_servo"].ToString());
            if (Host.config.ContainsKey("sprayplan_tank_low")) tank_low = int.Parse(Host.config["sprayplan_tank_low"].ToString());
            if (Host.config.ContainsKey("sprayplan_spray_delay")) spray_delay = int.Parse(Host.config["sprayplan_spray_delay"].ToString());


            return true;
        }


        //This calls in every 0.5 sec
        public override bool Loop()
        {

            if (Host.cs.armed == false)
            {
                bWaitforSprayer = true; 
            }

            //Check ch6 high to disable spraying
            if (Host.cs.ch6in > 1800)
            {
                MainV2.instance.Invoke((Action)
                        delegate
                        {
                            //Send it three times to make is sure
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)pump_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)spinner_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)pump_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)spinner_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)pump_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)spinner_servo, 1000, 0, 0, 0, 0, 0, false);

                        });
            }

            if (Host.cs.armed) 

                if (    (String.Equals(Host.cs.mode, "auto", StringComparison.OrdinalIgnoreCase) && (Host.cs.rxrssi <= tank_low))
                     || (String.Equals(Host.cs.mode, "rtl", StringComparison.OrdinalIgnoreCase) && String.Equals(pervious_mode, "auto", StringComparison.OrdinalIgnoreCase)))
                {


                    if (String.Equals(Host.cs.mode, "auto", StringComparison.OrdinalIgnoreCase))
                    {
                        MainV2.comPort.setMode("brake");
                        MainV2.comPort.setMode("brake");
                        MainV2.comPort.setMode("brake");
                        MainV2.comPort.setMode("brake");
                        MainV2.comPort.setMode("brake");
                    }

                this.mapOverlayFP.Clear();
                    this.mapOverlayFD.Clear();
                    bWaitforSprayer = false;
                    continue_point = Host.cs.Location;
                    continue_point.Alt = Host.cs.alt;       //We need absolute altitude not ASL

                    continue_wp = Host.cs.wpno;
                    this.mapOverlayFD.Markers.Add(new GMarkerGoogle(continue_point, GMarkerGoogleType.blue_pushpin));
                    this.mapOverlayFP.Markers.Add(new GMarkerGoogle(continue_point, GMarkerGoogleType.yellow_pushpin));


                    MainV2.instance.Invoke((Action)
                        delegate
                        {
                            //Send it three times to make is sure

                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)pump_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)spinner_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)pump_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)spinner_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)pump_servo, 1000, 0, 0, 0, 0, 0, false);
                            MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, (float)spinner_servo, 1000, 0, 0, 0, 0, 0, false);



                            commands = Host.MainForm.FlightPlanner.Controls.Find("Commands", true).FirstOrDefault() as MissionPlanner.Controls.MyDataGridView; ;

                        for (int i = 0;i<continue_wp-1;i++)
                            commands.Rows.RemoveAt(0);

                            Host.MainForm.FlightPlanner.writeKML();

                            Host.InsertWP(0, MAVLink.MAV_CMD.DO_SET_SERVO, pump_servo, 1000, 0, 0, 0, 0, 0);
                            Host.InsertWP(1, MAVLink.MAV_CMD.DO_SET_SERVO, spinner_servo, 1000, 0, 0, 0, 0, 0);
                            Host.InsertWP(2, MAVLink.MAV_CMD.WAYPOINT, 1, 0, 0, 0, continue_point.Lng, continue_point.Lat, continue_point.Alt);
                            if (spray_delay > 0)
                            {
                                Host.InsertWP(3, MAVLink.MAV_CMD.CONDITION_DELAY, (double) spray_delay, 0, 0, 0, 0, 0, 0);
                                Host.InsertWP(4, MAVLink.MAV_CMD.DO_SET_SERVO, pump_servo, pump_pwm, 0, 0, 0, 0, 0);
                                Host.InsertWP(5, MAVLink.MAV_CMD.DO_SET_SERVO, spinner_servo, spinner_pwm, 0, 0, 0, 0, 0);
                            } else
                            {
                                Host.InsertWP(3, MAVLink.MAV_CMD.DO_SET_SERVO, pump_servo, pump_pwm, 0, 0, 0, 0, 0);
                                Host.InsertWP(4, MAVLink.MAV_CMD.DO_SET_SERVO, spinner_servo, spinner_pwm, 0, 0, 0, 0, 0);

                            }

                        });
            }




            pervious_mode = Host.cs.mode;

            return true;
        }


            void but_Click(object sender, EventArgs e)
        {
            if (Host.FPDrawnPolygon != null && Host.FPDrawnPolygon.Points.Count > 2)
            {
                using (Form gridui = new GridUI(this))
                {
                    MissionPlanner.Utilities.ThemeManager.ApplyThemeTo(gridui);
                    gridui.ShowDialog();
                }
            }
            else
            {
                CustomMessageBox.Show("Please define a polygon.", "Error");
            }
        }

        public override bool Exit()
        {
            return true;
        }
    }
}
