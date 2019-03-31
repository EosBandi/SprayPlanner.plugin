namespace MissionPlanner.SprayPlanner
{
    partial class GridUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridUI));
            this.map = new MissionPlanner.Controls.myGMAP();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbl_distbetweenlines = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbl_strips = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lbl_distance = new System.Windows.Forms.Label();
            this.lbl_area = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabSimple = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.NUM_spray_delay = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.NUM_tank_low = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.NUM_Spinner_servo = new System.Windows.Forms.NumericUpDown();
            this.NUM_Pump_servo = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NUM_SpinnerPWM = new System.Windows.Forms.NumericUpDown();
            this.NUM_PumpPWM = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NUM_angle = new System.Windows.Forms.NumericUpDown();
            this.NUM_altitude = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.BUT_Accept = new MissionPlanner.Controls.MyButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CMB_startfrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NUM_Distance = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CHK_internals = new System.Windows.Forms.CheckBox();
            this.chk_grid = new System.Windows.Forms.CheckBox();
            this.chk_markers = new System.Windows.Forms.CheckBox();
            this.chk_boundary = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lbl_grid_points = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.tabSimple.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_spray_delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_tank_low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Spinner_servo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Pump_servo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_SpinnerPWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_PumpPWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_altitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Distance)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            resources.ApplyResources(this.map, "map");
            this.map.EmptyTileColor = System.Drawing.Color.Gray;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.HoldInvalidation = false;
            this.map.LevelsKeepInMemmory = 5;
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 19;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Zoom = 3D;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_grid_points);
            this.groupBox5.Controls.Add(this.lbl_distbetweenlines);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.lbl_strips);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.lbl_distance);
            this.groupBox5.Controls.Add(this.lbl_area);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // lbl_distbetweenlines
            // 
            resources.ApplyResources(this.lbl_distbetweenlines, "lbl_distbetweenlines");
            this.lbl_distbetweenlines.Name = "lbl_distbetweenlines";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // lbl_strips
            // 
            resources.ApplyResources(this.lbl_strips, "lbl_strips");
            this.lbl_strips.Name = "lbl_strips";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // lbl_distance
            // 
            resources.ApplyResources(this.lbl_distance, "lbl_distance");
            this.lbl_distance.Name = "lbl_distance";
            // 
            // lbl_area
            // 
            resources.ApplyResources(this.lbl_area, "lbl_area");
            this.lbl_area.Name = "lbl_area";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // tabSimple
            // 
            this.tabSimple.Controls.Add(this.groupBox6);
            this.tabSimple.Controls.Add(this.groupBox4);
            resources.ApplyResources(this.tabSimple, "tabSimple");
            this.tabSimple.Name = "tabSimple";
            this.tabSimple.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.NUM_spray_delay);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.NUM_tank_low);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.NUM_Spinner_servo);
            this.groupBox6.Controls.Add(this.NUM_Pump_servo);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.NUM_SpinnerPWM);
            this.groupBox6.Controls.Add(this.NUM_PumpPWM);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.NUM_angle);
            this.groupBox6.Controls.Add(this.NUM_altitude);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.BUT_Accept);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.CMB_startfrom);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.NUM_Distance);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // NUM_spray_delay
            // 
            resources.ApplyResources(this.NUM_spray_delay, "NUM_spray_delay");
            this.NUM_spray_delay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUM_spray_delay.Name = "NUM_spray_delay";
            this.NUM_spray_delay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // NUM_tank_low
            // 
            resources.ApplyResources(this.NUM_tank_low, "NUM_tank_low");
            this.NUM_tank_low.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NUM_tank_low.Name = "NUM_tank_low";
            this.NUM_tank_low.Value = new decimal(new int[] {
            28,
            0,
            0,
            0});
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // NUM_Spinner_servo
            // 
            resources.ApplyResources(this.NUM_Spinner_servo, "NUM_Spinner_servo");
            this.NUM_Spinner_servo.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.NUM_Spinner_servo.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NUM_Spinner_servo.Name = "NUM_Spinner_servo";
            this.NUM_Spinner_servo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // NUM_Pump_servo
            // 
            resources.ApplyResources(this.NUM_Pump_servo, "NUM_Pump_servo");
            this.NUM_Pump_servo.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.NUM_Pump_servo.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NUM_Pump_servo.Name = "NUM_Pump_servo";
            this.NUM_Pump_servo.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // NUM_SpinnerPWM
            // 
            resources.ApplyResources(this.NUM_SpinnerPWM, "NUM_SpinnerPWM");
            this.NUM_SpinnerPWM.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.NUM_SpinnerPWM.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUM_SpinnerPWM.Name = "NUM_SpinnerPWM";
            this.NUM_SpinnerPWM.Value = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            // 
            // NUM_PumpPWM
            // 
            resources.ApplyResources(this.NUM_PumpPWM, "NUM_PumpPWM");
            this.NUM_PumpPWM.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.NUM_PumpPWM.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUM_PumpPWM.Name = "NUM_PumpPWM";
            this.NUM_PumpPWM.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // NUM_angle
            // 
            resources.ApplyResources(this.NUM_angle, "NUM_angle");
            this.NUM_angle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NUM_angle.Name = "NUM_angle";
            this.NUM_angle.ValueChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // NUM_altitude
            // 
            this.NUM_altitude.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.NUM_altitude, "NUM_altitude");
            this.NUM_altitude.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUM_altitude.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUM_altitude.Name = "NUM_altitude";
            this.NUM_altitude.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUM_altitude.ValueChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // BUT_Accept
            // 
            resources.ApplyResources(this.BUT_Accept, "BUT_Accept");
            this.BUT_Accept.Name = "BUT_Accept";
            this.BUT_Accept.UseVisualStyleBackColor = true;
            this.BUT_Accept.Click += new System.EventHandler(this.BUT_Accept_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CMB_startfrom
            // 
            this.CMB_startfrom.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_startfrom, "CMB_startfrom");
            this.CMB_startfrom.Name = "CMB_startfrom";
            this.CMB_startfrom.SelectedIndexChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // NUM_Distance
            // 
            resources.ApplyResources(this.NUM_Distance, "NUM_Distance");
            this.NUM_Distance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUM_Distance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUM_Distance.Name = "NUM_Distance";
            this.NUM_Distance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUM_Distance.ValueChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CHK_internals);
            this.groupBox4.Controls.Add(this.chk_grid);
            this.groupBox4.Controls.Add(this.chk_markers);
            this.groupBox4.Controls.Add(this.chk_boundary);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // CHK_internals
            // 
            resources.ApplyResources(this.CHK_internals, "CHK_internals");
            this.CHK_internals.Checked = true;
            this.CHK_internals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_internals.Name = "CHK_internals";
            this.CHK_internals.UseVisualStyleBackColor = true;
            this.CHK_internals.CheckedChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // chk_grid
            // 
            resources.ApplyResources(this.chk_grid, "chk_grid");
            this.chk_grid.Checked = true;
            this.chk_grid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_grid.Name = "chk_grid";
            this.chk_grid.UseVisualStyleBackColor = true;
            this.chk_grid.CheckedChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // chk_markers
            // 
            resources.ApplyResources(this.chk_markers, "chk_markers");
            this.chk_markers.Checked = true;
            this.chk_markers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_markers.Name = "chk_markers";
            this.chk_markers.UseVisualStyleBackColor = true;
            this.chk_markers.CheckedChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // chk_boundary
            // 
            resources.ApplyResources(this.chk_boundary, "chk_boundary");
            this.chk_boundary.Checked = true;
            this.chk_boundary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_boundary.Name = "chk_boundary";
            this.chk_boundary.UseVisualStyleBackColor = true;
            this.chk_boundary.CheckedChanged += new System.EventHandler(this.domainUpDown1_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSimple);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // lbl_grid_points
            // 
            resources.ApplyResources(this.lbl_grid_points, "lbl_grid_points");
            this.lbl_grid_points.Name = "lbl_grid_points";
            // 
            // GridUI
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.map);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Name = "GridUI";
            this.Load += new System.EventHandler(this.GridUI_Load);
            this.Resize += new System.EventHandler(this.GridUI_Resize);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabSimple.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_spray_delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_tank_low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Spinner_servo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Pump_servo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_SpinnerPWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_PumpPWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_altitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Distance)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.myGMAP map;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbl_distance;
        private System.Windows.Forms.Label lbl_area;
        private System.Windows.Forms.Label lbl_distbetweenlines;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbl_strips;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabPage tabSimple;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUM_angle;
        private System.Windows.Forms.NumericUpDown NUM_altitude;
        private System.Windows.Forms.Label label6;
        private Controls.MyButton BUT_Accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMB_startfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUM_Distance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chk_grid;
        private System.Windows.Forms.CheckBox chk_markers;
        private System.Windows.Forms.CheckBox chk_boundary;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox CHK_internals;
        private System.Windows.Forms.NumericUpDown NUM_SpinnerPWM;
        private System.Windows.Forms.NumericUpDown NUM_PumpPWM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUM_Spinner_servo;
        private System.Windows.Forms.NumericUpDown NUM_Pump_servo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NUM_tank_low;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NUM_spray_delay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_grid_points;
    }
}