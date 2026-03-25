using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbLibrary;

namespace USBNC
{
    public partial class Form_SampleCom : Form
    {
        byte[] readbuff = new byte[65];
        byte[] writebuff = new byte[65];

        // Ve hinh tron cho LED
        private void MakeCircle(Panel p)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, p.Width, p.Height);
            p.Region = new Region(path);
        }

        // Bat LED
        void Led0On()
        {
            panel_LED0.BackColor = Color.Red;
        }

        void Led1On()
        {
            panel_LED1.BackColor = Color.Red;
        }

        // Tat LED
        void Led0Off()
        {
            panel_LED0.BackColor = Color.Gray;
        }

        void Led1Off()
        {
            panel_LED1.BackColor = Color.Gray;
        }

        public Form_SampleCom()
        {
            InitializeComponent();
            MakeCircle(panel_LED0);
            MakeCircle(panel_LED1);
        }
        private void Form_SampleCom_Load(object sender, EventArgs e)
        {
            this.usbHidPort.VendorId = 0x04D8;
            this.usbHidPort.ProductId = 0x0001;
            this.usbHidPort.CheckDevicePresent();

            if (this.usbHidPort.SpecifiedDevice != null)
            {
                this.usbHidPort.SpecifiedDevice.SendData(writebuff);
            }
            textBox_VID.Text = usbHidPort.VendorId.ToString("x4");
            textBox_PID.Text = usbHidPort.ProductId.ToString("x4");
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exit the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void usbHidPort_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            toolStripStatusLabel_InforDevice.Text = "Device Dectected";
            textBox_Status.Text = "Connected";
            textBox_Status.BackColor = Color.Lime;
            textBox_SW1.Text = "0";
        }

        private void usbHidPort_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHidPort_OnSpecifiedDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                toolStripStatusLabel_InforDevice.Text = "Device Disconnected";
                textBox_Status.Text = "Disconnected!";
                textBox_Status.BackColor = Color.Red;
            }

        }
        

        private void usbHidPort_OnDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHidPort_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                toolStripStatusLabel_InforDevice.Text = "USB Removed";
            }

        }

        private void usbHidPort_OnDeviceArrived(object sender, EventArgs e)
        {
            toolStripStatusLabel_InforDevice.Text = "USB Connected";
        }

        private void usbHidPort_OnDataSend(object sender, EventArgs e)
        {
            toolStripStatusLabel_InforDevice.Text = "Data sent";
        }

        private void usbHidPort_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new DataRecievedEventHandler(usbHidPort_OnDataRecieved), new object[] { sender, args });
                }
                catch
                { }
            }
            else
            {
                readbuff = args.data;
                toolStripStatusLabel_InforDevice.Text = "New Received Data";
                textBox_SW1.Text = readbuff[1].ToString();
                if (readbuff[9] == 'O')
                {
                    Led0On();
                }
                else if (readbuff[9] == 'F')
                {
                    Led0Off();
                }
                else if (readbuff[9] == 'o')
                {
                    Led1On();
                }
                else if (readbuff[9] == 'f')
                {
                    Led1Off();
                }
            }

        }
        private void button_ON_Click(object sender, EventArgs e)
        {
            writebuff[1] = 1;
            if (this.usbHidPort.SpecifiedDevice != null)

                this.usbHidPort.SpecifiedDevice.SendData(writebuff);
            else
            {
                MessageBox.Show("Device not found. Please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button_OFF_Click(object sender, EventArgs e)
        {
            writebuff[1] = 0;
            if (this.usbHidPort.SpecifiedDevice != null)
                this.usbHidPort.SpecifiedDevice.SendData(writebuff);
            else
            {
                MessageBox.Show("Device not found. Please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usbHidPort.RegisterHandle(Handle);
        }
        protected override void WndProc(ref Message m)
        {
            usbHidPort.ParseMessages(ref m);
            base.WndProc(ref m);
        }

        private void ovalShape_LED2_Click(object sender, EventArgs e)
        {

        }

        private void button_ON2_Click(object sender, EventArgs e)
        {
            writebuff[1] = 2;
            if (this.usbHidPort.SpecifiedDevice != null)

                this.usbHidPort.SpecifiedDevice.SendData(writebuff);
            else
            {
                MessageBox.Show("Device not found. Please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_OFF2_Click(object sender, EventArgs e)
        {
            writebuff[1] = 3;
            if (this.usbHidPort.SpecifiedDevice != null)
                this.usbHidPort.SpecifiedDevice.SendData(writebuff);
            else
            {
                MessageBox.Show("Device not found. Please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripStatusLabel_InforDevice_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip_InforDevice_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox_SW2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
