namespace USBNC
{
    partial class Form_SampleCom
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_PN = new System.Windows.Forms.TextBox();
            this.textBox_VN = new System.Windows.Forms.TextBox();
            this.textBox_PID = new System.Windows.Forms.TextBox();
            this.textBox_VID = new System.Windows.Forms.TextBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_SW1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_OFF = new System.Windows.Forms.Button();
            this.button_ON = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.statusStrip_InforDevice = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_InforDevice = new System.Windows.Forms.ToolStripStatusLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.usbHidPort = new UsbLibrary.UsbHidPort(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_OFF2 = new System.Windows.Forms.Button();
            this.button_ON2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.panel_LED0 = new System.Windows.Forms.Panel();
            this.panel_LED1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip_InforDevice.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(194, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "USB (HID) Comunication Lab";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_PN);
            this.groupBox1.Controls.Add(this.textBox_VN);
            this.groupBox1.Controls.Add(this.textBox_PID);
            this.groupBox1.Controls.Add(this.textBox_VID);
            this.groupBox1.Controls.Add(this.textBox_Status);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(256, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Information";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "for PIC18F4550";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "for Microchip";
            // 
            // textBox_PN
            // 
            this.textBox_PN.BackColor = System.Drawing.Color.White;
            this.textBox_PN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PN.Location = new System.Drawing.Point(101, 113);
            this.textBox_PN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_PN.Name = "textBox_PN";
            this.textBox_PN.ReadOnly = true;
            this.textBox_PN.Size = new System.Drawing.Size(152, 19);
            this.textBox_PN.TabIndex = 6;
            this.textBox_PN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_VN
            // 
            this.textBox_VN.BackColor = System.Drawing.Color.White;
            this.textBox_VN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_VN.Location = new System.Drawing.Point(101, 91);
            this.textBox_VN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_VN.Name = "textBox_VN";
            this.textBox_VN.ReadOnly = true;
            this.textBox_VN.Size = new System.Drawing.Size(152, 19);
            this.textBox_VN.TabIndex = 5;
            this.textBox_VN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PID
            // 
            this.textBox_PID.BackColor = System.Drawing.Color.White;
            this.textBox_PID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PID.Location = new System.Drawing.Point(101, 68);
            this.textBox_PID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_PID.Name = "textBox_PID";
            this.textBox_PID.ReadOnly = true;
            this.textBox_PID.Size = new System.Drawing.Size(53, 19);
            this.textBox_PID.TabIndex = 4;
            this.textBox_PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_VID
            // 
            this.textBox_VID.BackColor = System.Drawing.Color.White;
            this.textBox_VID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_VID.Location = new System.Drawing.Point(101, 45);
            this.textBox_VID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_VID.Name = "textBox_VID";
            this.textBox_VID.ReadOnly = true;
            this.textBox_VID.Size = new System.Drawing.Size(53, 19);
            this.textBox_VID.TabIndex = 4;
            this.textBox_VID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Status
            // 
            this.textBox_Status.BackColor = System.Drawing.Color.Red;
            this.textBox_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Status.Location = new System.Drawing.Point(101, 23);
            this.textBox_Status.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(96, 19);
            this.textBox_Status.TabIndex = 3;
            this.textBox_Status.Text = "Disconnected!";
            this.textBox_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Vendor Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Product ID (HEX)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vendor ID (HEX)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Device Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_SW1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(351, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(150, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Switch1 Status";
            // 
            // textBox_SW1
            // 
            this.textBox_SW1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox_SW1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SW1.Location = new System.Drawing.Point(85, 21);
            this.textBox_SW1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_SW1.Name = "textBox_SW1";
            this.textBox_SW1.ReadOnly = true;
            this.textBox_SW1.Size = new System.Drawing.Size(57, 19);
            this.textBox_SW1.TabIndex = 1;
            this.textBox_SW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Counter (SW1)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel_LED0);
            this.groupBox3.Controls.Add(this.button_OFF);
            this.groupBox3.Controls.Add(this.button_ON);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(269, 70);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(150, 93);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LED1 Control";
            // 
            // button_OFF
            // 
            this.button_OFF.Location = new System.Drawing.Point(89, 49);
            this.button_OFF.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_OFF.Name = "button_OFF";
            this.button_OFF.Size = new System.Drawing.Size(56, 25);
            this.button_OFF.TabIndex = 2;
            this.button_OFF.Text = "OFF";
            this.button_OFF.UseVisualStyleBackColor = true;
            this.button_OFF.Click += new System.EventHandler(this.button_OFF_Click);
            // 
            // button_ON
            // 
            this.button_ON.Location = new System.Drawing.Point(89, 17);
            this.button_ON.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_ON.Name = "button_ON";
            this.button_ON.Size = new System.Drawing.Size(56, 25);
            this.button_ON.TabIndex = 1;
            this.button_ON.Text = "ON";
            this.button_ON.UseVisualStyleBackColor = true;
            this.button_ON.Click += new System.EventHandler(this.button_ON_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "LED1 On/Off";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(249, 169);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(79, 25);
            this.button_Exit.TabIndex = 4;
            this.button_Exit.Text = "Exit Program";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // statusStrip_InforDevice
            // 
            this.statusStrip_InforDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_InforDevice});
            this.statusStrip_InforDevice.Location = new System.Drawing.Point(0, 205);
            this.statusStrip_InforDevice.Name = "statusStrip_InforDevice";
            this.statusStrip_InforDevice.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip_InforDevice.Size = new System.Drawing.Size(581, 22);
            this.statusStrip_InforDevice.TabIndex = 5;
            this.statusStrip_InforDevice.Text = "statusStrip1";
            this.statusStrip_InforDevice.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_InforDevice_ItemClicked);
            // 
            // toolStripStatusLabel_InforDevice
            // 
            this.toolStripStatusLabel_InforDevice.Name = "toolStripStatusLabel_InforDevice";
            this.toolStripStatusLabel_InforDevice.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel_InforDevice.Text = "USB Disconnected";
            this.toolStripStatusLabel_InforDevice.Click += new System.EventHandler(this.toolStripStatusLabel_InforDevice_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(433, 209);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Designed by LEANHDUC";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // usbHidPort
            // 
            this.usbHidPort.ProductId = 0;
            this.usbHidPort.VendorId = 0;
            this.usbHidPort.OnSpecifiedDeviceArrived += new System.EventHandler(this.usbHidPort_OnSpecifiedDeviceArrived);
            this.usbHidPort.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usbHidPort_OnSpecifiedDeviceRemoved);
            this.usbHidPort.OnDeviceArrived += new System.EventHandler(this.usbHidPort_OnDeviceArrived);
            this.usbHidPort.OnDeviceRemoved += new System.EventHandler(this.usbHidPort_OnDeviceRemoved);
            this.usbHidPort.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usbHidPort_OnDataRecieved);
            this.usbHidPort.OnDataSend += new System.EventHandler(this.usbHidPort_OnDataSend);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel_LED1);
            this.groupBox5.Controls.Add(this.button_OFF2);
            this.groupBox5.Controls.Add(this.button_ON2);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(424, 70);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Size = new System.Drawing.Size(150, 93);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "LED2 Control";
            // 
            // button_OFF2
            // 
            this.button_OFF2.Location = new System.Drawing.Point(89, 49);
            this.button_OFF2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_OFF2.Name = "button_OFF2";
            this.button_OFF2.Size = new System.Drawing.Size(56, 25);
            this.button_OFF2.TabIndex = 2;
            this.button_OFF2.Text = "OFF";
            this.button_OFF2.UseVisualStyleBackColor = true;
            this.button_OFF2.Click += new System.EventHandler(this.button_OFF2_Click);
            // 
            // button_ON2
            // 
            this.button_ON2.Location = new System.Drawing.Point(89, 17);
            this.button_ON2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_ON2.Name = "button_ON2";
            this.button_ON2.Size = new System.Drawing.Size(56, 25);
            this.button_ON2.TabIndex = 1;
            this.button_ON2.Text = "ON";
            this.button_ON2.UseVisualStyleBackColor = true;
            this.button_ON2.Click += new System.EventHandler(this.button_ON2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "LED2 On/Off";
            // 
            // panel_LED0
            // 
            this.panel_LED0.BackColor = System.Drawing.Color.Gray;
            this.panel_LED0.Location = new System.Drawing.Point(8, 39);
            this.panel_LED0.Name = "panel_LED0";
            this.panel_LED0.Size = new System.Drawing.Size(61, 50);
            this.panel_LED0.TabIndex = 3;
            this.panel_LED0.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel_LED1
            // 
            this.panel_LED1.BackColor = System.Drawing.Color.Gray;
            this.panel_LED1.Location = new System.Drawing.Point(10, 39);
            this.panel_LED1.Name = "panel_LED1";
            this.panel_LED1.Size = new System.Drawing.Size(61, 50);
            this.panel_LED1.TabIndex = 4;
            // 
            // Form_SampleCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 227);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.statusStrip_InforDevice);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form_SampleCom";
            this.Text = "Sample Interface-HID-USB Communication";
            this.Load += new System.EventHandler(this.Form_SampleCom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip_InforDevice.ResumeLayout(false);
            this.statusStrip_InforDevice.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_PN;
        private System.Windows.Forms.TextBox textBox_VN;
        private System.Windows.Forms.TextBox textBox_PID;
        private System.Windows.Forms.TextBox textBox_VID;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_SW1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_OFF;
        private System.Windows.Forms.Button button_ON;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.StatusStrip statusStrip_InforDevice;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_InforDevice;
        private System.Windows.Forms.Label label11;
        private UsbLibrary.UsbHidPort usbHidPort;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_OFF2;
        private System.Windows.Forms.Button button_ON2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel_LED0;
        private System.Windows.Forms.Panel panel_LED1;
    }
}

