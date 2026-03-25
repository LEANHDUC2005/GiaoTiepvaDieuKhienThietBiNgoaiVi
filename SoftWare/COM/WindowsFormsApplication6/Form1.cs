// Copy vao Form.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;

namespace WindowsFormsApplication6
{
    public partial class Form_SampleCOM : Form
    {
        string ReceiveData = String.Empty;   // Bien chua chuoi nhan ve ( Receive )
        string TransmitData = String.Empty;  // Bien chua chuoi gui di ( Transmit )

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

        // Khoi dong chuong trinh
        public Form_SampleCOM()
        {
            InitializeComponent();
            // Tao LED
            MakeCircle(panel_LED0);
            MakeCircle(panel_LED1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cau hinh cong COM mac dinh
            // COM Port: ???, Baud Rate: 9600 / Data: 8/ Parity: 0/ Stop: 1
            Serial_Port.PortName = "COM1";
            Serial_Port.BaudRate = 9600;
            Serial_Port.DataBits = 8;
            Serial_Port.Parity = Parity.None;
            Serial_Port.StopBits = StopBits.One;
            // Doc thong tin cac cong COM co trong PC.
            string[] ports = SerialPort.GetPortNames();
            // Them ten cua tat ca cac cong vao muc COM Port.
            foreach (string port in ports)
            {
                comboBox_COMPort.Items.Add(port);
            }

            // Kiem tra ten COM mac dinh co hop le
            try
            {
                if (!Serial_Port.IsOpen)
                {
                    Serial_Port.Open();
                }
                MessageBox.Show("Welcome User, Click OK to comfirm", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Serial_Port.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        // Chuong trinh con gui du lieu
        public void Send_Data(string Send_Text)
        {
            Serial_Port.Write(Send_Text);
            textBox_DataSend.Text = Send_Text.ToString();
        }

        // Xu ly khi dong giao dien
        public void Form_SampleCOM_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Serial_Port.IsOpen)
                Serial_Port.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox_COMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serial_Port.Close();                            // Dong cong COM da chon truoc do
            textBox_Status.BackColor = Color.Red;           // Hieu chinh mau va thong tin
            textBox_Status.Text = "Disconnected!";
            Serial_Port.PortName = comboBox_COMPort.Text;   // Lay so cong COM da chon
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    TransmitData = "@le_on&";
                    Send_Data(TransmitData);
                }
                else
                {
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is disconnected. Please reconnect to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The control appear error. Action can not be completed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    TransmitData = "@le_of&";
                    Send_Data(TransmitData);
                }
                else
                {
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is disconnected. Please reconnect to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The control appears error. Please reconnect to use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox_DataReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_DataSend_Click(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            // Kiem tra da chon cong COM
            if (comboBox_COMPort.Text == "")
                MessageBox.Show("Select COM Port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (comboBox_BaudRate.Text == "")
                MessageBox.Show("Select BaudRate for COM Port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                // Xu ly mo cong COM da chon
                try
                {
                    if (Serial_Port.IsOpen) // Truong hop da ket noi
                    {
                        MessageBox.Show("COM Port is connected and ready for use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else                    // Truong hop chua ket noi
                    {
                        Serial_Port.Open();
                        MessageBox.Show(comboBox_COMPort.Text + " is connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Status.BackColor = Color.Lime;    // Hieu chinh mau va thong tin
                        textBox_Status.Text = "Connecting...";

                        comboBox_COMPort.Enabled = false;
                        comboBox_BaudRate.Enabled = false;

                        ReceiveData = String.Empty;
                        TransmitData = String.Empty;
                    }
                }
                catch (Exception)           // Xu ly xuat hien loi khong thay thiet bi
                {
                    textBox_Status.BackColor = Color.Red;    // Hieu chinh mau va thong tin
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox_Kit1PC_Enter(object sender, EventArgs e)
        {

        }

        // Xu ly khi nhan nut Disconnect
        private void button_DisConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    Serial_Port.Close();
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox_COMPort.Enabled = true;
                    comboBox_BaudRate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("COM Port have been disconnected. Please reconnect to use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Disconnection appears error. Unable to disconnect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xu ly khi nhan nut Exit
        private void button_Exit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exit the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                if (Serial_Port.IsOpen)
                {
                    Serial_Port.Close();
                }
                this.Close();
            }
        }

        private void groupBox_COMSetup_Enter(object sender, EventArgs e)
        {

        }

        private void button_DataSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    TransmitData = textBox_DataSend.Text;
                    Send_Data(TransmitData);

                }
                else
                {
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is disconnected. Please reconnect to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The control appear error. Action can not be completed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_DataSend_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DataSend.Checked == true)
            {
                button_DataSend.Enabled = true;
                textBox_DataSend.ReadOnly = false;
            }
            else
            {
                button_DataSend.Enabled = false;
                textBox_DataSend.ReadOnly = true;
            }
        }

        private void comboBox_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serial_Port.Close();                                           // Dong cong COM da chon truoc do
            textBox_Status.BackColor = Color.Red;                          // Hieu chinh mau va thong tin
            textBox_Status.Text = "Disconnected!";
            Serial_Port.BaudRate = Convert.ToInt32(comboBox_BaudRate.Text);// Lay toc do baud da chon
        }

        private void button_DataSend_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    TransmitData = textBox_DataSend.Text.ToString();
                    Send_Data(TransmitData);
                }
                else
                {
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is not connected. Please reconnect to use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The control appers error. Action can not be completed.");
            }
        }

        private void checkBox_DataSend_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox_DataSend.Checked == true)
            {
                button_DataSend.Enabled = true;    // Cho phep nhap chuoi du lieu vao o Send
                textBox_DataSend.ReadOnly = false;
            }
            else
            {
                button_DataSend.Enabled = false;
                textBox_DataSend.ReadOnly = true;
            }
        }

        private void comboBox_BaudRate_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Serial_Port.Close();
            textBox_Status.BackColor = Color.Red;
            textBox_Status.Text = "Disconnected!";
            Serial_Port.BaudRate = Convert.ToInt32(comboBox_BaudRate.Text);
        }

        private void Serial_Port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;     // Bo kiem tra xung dot
            // Nhan du lieu co nhan dang dang ky tu bat dau @ va ky tu ket thuc & cua chuoi du lieu (@...&)
            ReceiveData = Serial_Port.ReadTo("&");
            textBox_DataReceive.Text = ReceiveData.ToString() + "&";
            if (ReceiveData.Substring(0, 1) == "@") // Kiem tra dung dinh dang chuoi du lieu
            {
                if (ReceiveData.Substring(1, 1) == "S")// Kiem tra du lieu nhan nut
                {
                    textBox_SW.Text = ReceiveData.Substring(2); // Tach lay phan du lieu so lan nhan SW
                    ReceiveData = String.Empty;                 // Xoa bien luu chuoi du lieu nhan
                }
                else if (ReceiveData.Substring(1, 1) == "L") // Kiem tra du lieu phan hoi trang thai LED
                {
                    if (ReceiveData.Substring(2) == "le_on") // Dieu chinh mau doi tuong theo du lieu LED sang
                    {
                       Led0On();
                    }
                    else if (ReceiveData.Substring(2) == "le_of")
                    {
                       Led0Off();
                    }
                    else if(ReceiveData.Substring(2) == "le+_on")
                    {
                        Led1On();
                    }
                    else if(ReceiveData.Substring(2) == "le+_of")
                    {
                        Led1Off();
                    }
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel_LED0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_ON1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    TransmitData = "@le+_on&";
                    Send_Data(TransmitData);
                }
                else
                {
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is disconnected. Please reconnect to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The control appear error. Action can not be completed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_OFF1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Port.IsOpen)
                {
                    TransmitData = "@le+_of&";
                    Send_Data(TransmitData);
                }
                else
                {
                    textBox_Status.BackColor = Color.Red;
                    textBox_Status.Text = "Disconnected!";
                    MessageBox.Show("COM Port is disconnected. Please reconnect to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The control appears error. Please reconnect to use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox_PC2bit_Enter(object sender, EventArgs e)
        {

        }

        private void textBox_SW_TextChanged(object sender, EventArgs e)
        {

        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void panel_LED1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
