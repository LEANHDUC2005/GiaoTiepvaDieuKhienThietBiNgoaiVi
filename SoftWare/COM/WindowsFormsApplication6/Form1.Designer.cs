namespace WindowsFormsApplication6
{
    partial class Form_SampleCOM
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
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.label_NameLab = new System.Windows.Forms.Label();
            this.label_NameDesigned = new System.Windows.Forms.Label();
            this.groupBox_COMSetup = new System.Windows.Forms.GroupBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.button_DisConnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.label_BaudRate = new System.Windows.Forms.Label();
            this.label_COMPort = new System.Windows.Forms.Label();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_COMPort = new System.Windows.Forms.ComboBox();
            this.groupBox_PC2bit = new System.Windows.Forms.GroupBox();
            this.button_OFF1 = new System.Windows.Forms.Button();
            this.button_ON1 = new System.Windows.Forms.Button();
            this.label_LEDOnOff1 = new System.Windows.Forms.Label();
            this.panel_LED1 = new System.Windows.Forms.Panel();
            this.panel_LED0 = new System.Windows.Forms.Panel();
            this.label_LEDOnOff0 = new System.Windows.Forms.Label();
            this.button_OFF0 = new System.Windows.Forms.Button();
            this.button_ON0 = new System.Windows.Forms.Button();
            this.groupBox_Kit1PC = new System.Windows.Forms.GroupBox();
            this.label_Counter = new System.Windows.Forms.Label();
            this.textBox_SW = new System.Windows.Forms.TextBox();
            this.groupBox_DataSendReceive = new System.Windows.Forms.GroupBox();
            this.checkBox_DataSend = new System.Windows.Forms.CheckBox();
            this.label_DataSend = new System.Windows.Forms.Label();
            this.label_Receive = new System.Windows.Forms.Label();
            this.textBox_DataReceive = new System.Windows.Forms.TextBox();
            this.textBox_DataSend = new System.Windows.Forms.TextBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_DataSend = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.Serial_Port = new System.IO.Ports.SerialPort(this.components);
            this.groupBox_COMSetup.SuspendLayout();
            this.groupBox_PC2bit.SuspendLayout();
            this.groupBox_Kit1PC.SuspendLayout();
            this.groupBox_DataSendReceive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_NameLab
            // 
            this.label_NameLab.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.label_NameLab.AutoSize = true;
            this.label_NameLab.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label_NameLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NameLab.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_NameLab.Location = new System.Drawing.Point(220, 9);
            this.label_NameLab.Name = "label_NameLab";
            this.label_NameLab.Size = new System.Drawing.Size(238, 16);
            this.label_NameLab.TabIndex = 0;
            this.label_NameLab.Text = "RS232 (COM) Communication Lab";
            this.label_NameLab.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_NameDesigned
            // 
            this.label_NameDesigned.AutoSize = true;
            this.label_NameDesigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NameDesigned.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_NameDesigned.Location = new System.Drawing.Point(473, 9);
            this.label_NameDesigned.Name = "label_NameDesigned";
            this.label_NameDesigned.Size = new System.Drawing.Size(151, 16);
            this.label_NameDesigned.TabIndex = 1;
            this.label_NameDesigned.Text = "Design by LeAnhDuc";
            this.label_NameDesigned.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox_COMSetup
            // 
            this.groupBox_COMSetup.Controls.Add(this.textBox_Status);
            this.groupBox_COMSetup.Controls.Add(this.button_DisConnect);
            this.groupBox_COMSetup.Controls.Add(this.button_Connect);
            this.groupBox_COMSetup.Controls.Add(this.label_BaudRate);
            this.groupBox_COMSetup.Controls.Add(this.label_COMPort);
            this.groupBox_COMSetup.Controls.Add(this.comboBox_BaudRate);
            this.groupBox_COMSetup.Controls.Add(this.comboBox_COMPort);
            this.groupBox_COMSetup.Location = new System.Drawing.Point(12, 26);
            this.groupBox_COMSetup.Name = "groupBox_COMSetup";
            this.groupBox_COMSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_COMSetup.Size = new System.Drawing.Size(200, 223);
            this.groupBox_COMSetup.TabIndex = 2;
            this.groupBox_COMSetup.TabStop = false;
            this.groupBox_COMSetup.Text = "Communication Setup";
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(52, 97);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(100, 20);
            this.textBox_Status.TabIndex = 6;
            this.textBox_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Status.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_DisConnect
            // 
            this.button_DisConnect.Location = new System.Drawing.Point(119, 123);
            this.button_DisConnect.Name = "button_DisConnect";
            this.button_DisConnect.Size = new System.Drawing.Size(75, 23);
            this.button_DisConnect.TabIndex = 5;
            this.button_DisConnect.Text = "Disconnect";
            this.button_DisConnect.UseVisualStyleBackColor = true;
            this.button_DisConnect.Click += new System.EventHandler(this.button_DisConnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(17, 123);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // label_BaudRate
            // 
            this.label_BaudRate.AutoSize = true;
            this.label_BaudRate.Location = new System.Drawing.Point(14, 49);
            this.label_BaudRate.Name = "label_BaudRate";
            this.label_BaudRate.Size = new System.Drawing.Size(58, 13);
            this.label_BaudRate.TabIndex = 3;
            this.label_BaudRate.Text = "Baud Rate";
            // 
            // label_COMPort
            // 
            this.label_COMPort.AutoSize = true;
            this.label_COMPort.Location = new System.Drawing.Point(14, 22);
            this.label_COMPort.Name = "label_COMPort";
            this.label_COMPort.Size = new System.Drawing.Size(53, 13);
            this.label_COMPort.TabIndex = 2;
            this.label_COMPort.Text = "COM Port";
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(73, 46);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBox_BaudRate.TabIndex = 1;
            this.comboBox_BaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBox_BaudRate_SelectedIndexChanged_1);
            // 
            // comboBox_COMPort
            // 
            this.comboBox_COMPort.AllowDrop = true;
            this.comboBox_COMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_COMPort.FormattingEnabled = true;
            this.comboBox_COMPort.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.comboBox_COMPort.Location = new System.Drawing.Point(73, 19);
            this.comboBox_COMPort.Name = "comboBox_COMPort";
            this.comboBox_COMPort.Size = new System.Drawing.Size(121, 21);
            this.comboBox_COMPort.TabIndex = 0;
            this.comboBox_COMPort.SelectedIndexChanged += new System.EventHandler(this.comboBox_COMPort_SelectedIndexChanged);
            // 
            // groupBox_PC2bit
            // 
            this.groupBox_PC2bit.BackColor = System.Drawing.Color.White;
            this.groupBox_PC2bit.Controls.Add(this.button_OFF1);
            this.groupBox_PC2bit.Controls.Add(this.button_ON1);
            this.groupBox_PC2bit.Controls.Add(this.label_LEDOnOff1);
            this.groupBox_PC2bit.Controls.Add(this.panel_LED1);
            this.groupBox_PC2bit.Controls.Add(this.panel_LED0);
            this.groupBox_PC2bit.Controls.Add(this.label_LEDOnOff0);
            this.groupBox_PC2bit.Controls.Add(this.button_OFF0);
            this.groupBox_PC2bit.Controls.Add(this.button_ON0);
            this.groupBox_PC2bit.Location = new System.Drawing.Point(223, 134);
            this.groupBox_PC2bit.Name = "groupBox_PC2bit";
            this.groupBox_PC2bit.Size = new System.Drawing.Size(313, 115);
            this.groupBox_PC2bit.TabIndex = 3;
            this.groupBox_PC2bit.TabStop = false;
            this.groupBox_PC2bit.Text = "LED Control";
            this.groupBox_PC2bit.Enter += new System.EventHandler(this.groupBox_PC2bit_Enter);
            // 
            // button_OFF1
            // 
            this.button_OFF1.Location = new System.Drawing.Point(232, 48);
            this.button_OFF1.Name = "button_OFF1";
            this.button_OFF1.Size = new System.Drawing.Size(75, 23);
            this.button_OFF1.TabIndex = 8;
            this.button_OFF1.Text = "OFF";
            this.button_OFF1.UseVisualStyleBackColor = true;
            this.button_OFF1.Click += new System.EventHandler(this.button_OFF1_Click);
            // 
            // button_ON1
            // 
            this.button_ON1.Location = new System.Drawing.Point(232, 19);
            this.button_ON1.Name = "button_ON1";
            this.button_ON1.Size = new System.Drawing.Size(75, 23);
            this.button_ON1.TabIndex = 7;
            this.button_ON1.Text = "ON";
            this.button_ON1.UseVisualStyleBackColor = true;
            this.button_ON1.Click += new System.EventHandler(this.button_ON1_Click);
            // 
            // label_LEDOnOff1
            // 
            this.label_LEDOnOff1.AutoSize = true;
            this.label_LEDOnOff1.Location = new System.Drawing.Point(169, 29);
            this.label_LEDOnOff1.Name = "label_LEDOnOff1";
            this.label_LEDOnOff1.Size = new System.Drawing.Size(34, 13);
            this.label_LEDOnOff1.TabIndex = 6;
            this.label_LEDOnOff1.Text = "LED1";
            this.label_LEDOnOff1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel_LED1
            // 
            this.panel_LED1.BackColor = System.Drawing.Color.Gray;
            this.panel_LED1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_LED1.Location = new System.Drawing.Point(172, 48);
            this.panel_LED1.Name = "panel_LED1";
            this.panel_LED1.Size = new System.Drawing.Size(50, 50);
            this.panel_LED1.TabIndex = 5;
            this.panel_LED1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_LED1_Paint);
            // 
            // panel_LED0
            // 
            this.panel_LED0.BackColor = System.Drawing.Color.Gray;
            this.panel_LED0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_LED0.Location = new System.Drawing.Point(13, 48);
            this.panel_LED0.Name = "panel_LED0";
            this.panel_LED0.Size = new System.Drawing.Size(50, 50);
            this.panel_LED0.TabIndex = 4;
            this.panel_LED0.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_LED0_Paint);
            // 
            // label_LEDOnOff0
            // 
            this.label_LEDOnOff0.AutoSize = true;
            this.label_LEDOnOff0.Location = new System.Drawing.Point(10, 29);
            this.label_LEDOnOff0.Name = "label_LEDOnOff0";
            this.label_LEDOnOff0.Size = new System.Drawing.Size(34, 13);
            this.label_LEDOnOff0.TabIndex = 3;
            this.label_LEDOnOff0.Text = "LED0";
            this.label_LEDOnOff0.Click += new System.EventHandler(this.label8_Click);
            // 
            // button_OFF0
            // 
            this.button_OFF0.Location = new System.Drawing.Point(80, 48);
            this.button_OFF0.Name = "button_OFF0";
            this.button_OFF0.Size = new System.Drawing.Size(75, 23);
            this.button_OFF0.TabIndex = 1;
            this.button_OFF0.Text = "OFF";
            this.button_OFF0.UseVisualStyleBackColor = true;
            this.button_OFF0.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_ON0
            // 
            this.button_ON0.Location = new System.Drawing.Point(80, 19);
            this.button_ON0.Name = "button_ON0";
            this.button_ON0.Size = new System.Drawing.Size(75, 23);
            this.button_ON0.TabIndex = 0;
            this.button_ON0.Text = "ON";
            this.button_ON0.UseVisualStyleBackColor = true;
            this.button_ON0.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_Kit1PC
            // 
            this.groupBox_Kit1PC.Controls.Add(this.label_Counter);
            this.groupBox_Kit1PC.Controls.Add(this.textBox_SW);
            this.groupBox_Kit1PC.Location = new System.Drawing.Point(218, 28);
            this.groupBox_Kit1PC.Name = "groupBox_Kit1PC";
            this.groupBox_Kit1PC.Size = new System.Drawing.Size(200, 100);
            this.groupBox_Kit1PC.TabIndex = 4;
            this.groupBox_Kit1PC.TabStop = false;
            this.groupBox_Kit1PC.Text = "Switch Status";
            this.groupBox_Kit1PC.Enter += new System.EventHandler(this.groupBox_Kit1PC_Enter);
            // 
            // label_Counter
            // 
            this.label_Counter.AutoSize = true;
            this.label_Counter.Location = new System.Drawing.Point(6, 23);
            this.label_Counter.Name = "label_Counter";
            this.label_Counter.Size = new System.Drawing.Size(71, 13);
            this.label_Counter.TabIndex = 1;
            this.label_Counter.Text = "Counter (SW)";
            // 
            // textBox_SW
            // 
            this.textBox_SW.Location = new System.Drawing.Point(83, 20);
            this.textBox_SW.Name = "textBox_SW";
            this.textBox_SW.ReadOnly = true;
            this.textBox_SW.Size = new System.Drawing.Size(100, 20);
            this.textBox_SW.TabIndex = 0;
            this.textBox_SW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SW.TextChanged += new System.EventHandler(this.textBox_SW_TextChanged);
            // 
            // groupBox_DataSendReceive
            // 
            this.groupBox_DataSendReceive.Controls.Add(this.checkBox_DataSend);
            this.groupBox_DataSendReceive.Controls.Add(this.label_DataSend);
            this.groupBox_DataSendReceive.Controls.Add(this.label_Receive);
            this.groupBox_DataSendReceive.Controls.Add(this.textBox_DataReceive);
            this.groupBox_DataSendReceive.Controls.Add(this.textBox_DataSend);
            this.groupBox_DataSendReceive.Location = new System.Drawing.Point(424, 28);
            this.groupBox_DataSendReceive.Name = "groupBox_DataSendReceive";
            this.groupBox_DataSendReceive.Size = new System.Drawing.Size(200, 100);
            this.groupBox_DataSendReceive.TabIndex = 5;
            this.groupBox_DataSendReceive.TabStop = false;
            this.groupBox_DataSendReceive.Text = "Data Send/Receive";
            this.groupBox_DataSendReceive.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // checkBox_DataSend
            // 
            this.checkBox_DataSend.AutoSize = true;
            this.checkBox_DataSend.Location = new System.Drawing.Point(72, 24);
            this.checkBox_DataSend.Name = "checkBox_DataSend";
            this.checkBox_DataSend.Size = new System.Drawing.Size(15, 14);
            this.checkBox_DataSend.TabIndex = 4;
            this.checkBox_DataSend.UseVisualStyleBackColor = true;
            this.checkBox_DataSend.CheckedChanged += new System.EventHandler(this.checkBox_DataSend_CheckedChanged_1);
            // 
            // label_DataSend
            // 
            this.label_DataSend.AutoSize = true;
            this.label_DataSend.Location = new System.Drawing.Point(16, 27);
            this.label_DataSend.Name = "label_DataSend";
            this.label_DataSend.Size = new System.Drawing.Size(32, 13);
            this.label_DataSend.TabIndex = 2;
            this.label_DataSend.Text = "Send";
            this.label_DataSend.Click += new System.EventHandler(this.label_DataSend_Click);
            // 
            // label_Receive
            // 
            this.label_Receive.AutoSize = true;
            this.label_Receive.Location = new System.Drawing.Point(16, 50);
            this.label_Receive.Name = "label_Receive";
            this.label_Receive.Size = new System.Drawing.Size(47, 13);
            this.label_Receive.TabIndex = 3;
            this.label_Receive.Text = "Receive";
            this.label_Receive.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox_DataReceive
            // 
            this.textBox_DataReceive.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.textBox_DataReceive.Location = new System.Drawing.Point(93, 47);
            this.textBox_DataReceive.Name = "textBox_DataReceive";
            this.textBox_DataReceive.ReadOnly = true;
            this.textBox_DataReceive.Size = new System.Drawing.Size(100, 20);
            this.textBox_DataReceive.TabIndex = 1;
            this.textBox_DataReceive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DataReceive.TextChanged += new System.EventHandler(this.textBox_DataReceive_TextChanged);
            // 
            // textBox_DataSend
            // 
            this.textBox_DataSend.Location = new System.Drawing.Point(93, 20);
            this.textBox_DataSend.Name = "textBox_DataSend";
            this.textBox_DataSend.ReadOnly = true;
            this.textBox_DataSend.Size = new System.Drawing.Size(100, 20);
            this.textBox_DataSend.TabIndex = 0;
            this.textBox_DataSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DataSend.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(541, 134);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 6;
            this.button_Exit.Text = "Exit Program";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_DataSend
            // 
            this.button_DataSend.Location = new System.Drawing.Point(542, 158);
            this.button_DataSend.Name = "button_DataSend";
            this.button_DataSend.Size = new System.Drawing.Size(75, 23);
            this.button_DataSend.TabIndex = 7;
            this.button_DataSend.Text = "Send";
            this.button_DataSend.UseVisualStyleBackColor = true;
            this.button_DataSend.Click += new System.EventHandler(this.button_DataSend_Click_1);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            this.eventLog1.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLog1_EntryWritten);
            // 
            // Serial_Port
            // 
            this.Serial_Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_Port_DataReceived_1);
            // 
            // Form_SampleCOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 261);
            this.Controls.Add(this.button_DataSend);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox_Kit1PC);
            this.Controls.Add(this.groupBox_DataSendReceive);
            this.Controls.Add(this.groupBox_PC2bit);
            this.Controls.Add(this.groupBox_COMSetup);
            this.Controls.Add(this.label_NameDesigned);
            this.Controls.Add(this.label_NameLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_SampleCOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample Interface - RS232 Communication Lab";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_COMSetup.ResumeLayout(false);
            this.groupBox_COMSetup.PerformLayout();
            this.groupBox_PC2bit.ResumeLayout(false);
            this.groupBox_PC2bit.PerformLayout();
            this.groupBox_Kit1PC.ResumeLayout(false);
            this.groupBox_Kit1PC.PerformLayout();
            this.groupBox_DataSendReceive.ResumeLayout(false);
            this.groupBox_DataSendReceive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label_NameLab;
        private System.Windows.Forms.Label label_NameDesigned;
        private System.Windows.Forms.GroupBox groupBox_COMSetup;
        private System.Windows.Forms.GroupBox groupBox_PC2bit;
        private System.Windows.Forms.GroupBox groupBox_Kit1PC;
        private System.Windows.Forms.GroupBox groupBox_DataSendReceive;
        private System.Windows.Forms.Button button_DisConnect;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Label label_BaudRate;
        private System.Windows.Forms.Label label_COMPort;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_COMPort;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Button button_OFF0;
        private System.Windows.Forms.Button button_ON0;
        private System.Windows.Forms.Label label_Counter;
        private System.Windows.Forms.TextBox textBox_SW;
        private System.Windows.Forms.Label label_DataSend;
        private System.Windows.Forms.Label label_Receive;
        private System.Windows.Forms.TextBox textBox_DataReceive;
        private System.Windows.Forms.TextBox textBox_DataSend;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_DataSend;
        private System.Windows.Forms.Label label_LEDOnOff0;
        private System.Windows.Forms.CheckBox checkBox_DataSend;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Panel panel_LED0;
        private System.IO.Ports.SerialPort Serial_Port;
        private System.Windows.Forms.Button button_OFF1;
        private System.Windows.Forms.Button button_ON1;
        private System.Windows.Forms.Label label_LEDOnOff1;
        private System.Windows.Forms.Panel panel_LED1;
    }
}

