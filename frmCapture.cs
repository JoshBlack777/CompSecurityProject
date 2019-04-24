using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;

namespace MyPacketCapture
{
    public partial class frmCapture : Form
    {
        CaptureDeviceList devices; //list of devices for this computer
        public static ICaptureDevice device; //the device we will be using
        public static string stringPackets = ""; // the data that is captured
        static int numPackets = 0;
        frmSend fSend; //This will be our send form
        frmData fData; // new data form
        static int totalIP;
        static int totalTCP;
        static int totalARP;
        static int totalUDP;

        public frmCapture()
        {
            InitializeComponent();

            //Get the list of devices
            devices = CaptureDeviceList.Instance;

            //Make sure there is at least one device
            if(devices.Count < 1)
            {
                MessageBox.Show("No Capture Devices Found!");
                Application.Exit();
            }

            //Add devices to combobox
            foreach(ICaptureDevice dev in devices)
            {
                cmbDevices.Items.Add(dev.Description);
            }

            //Get the 2nd device and display In combo box
            device = devices[1];
            cmbDevices.Text = device.Description;

            //register handler function to the packet arrival event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

        }

        private static void device_OnPacketArrival(object sender,CaptureEventArgs packet)
        {
            //Increment the number of packets captured
            numPackets++;

            //Put the packet number in the capture window
            stringPackets += "Packet Number: " + Convert.ToString(numPackets);
            stringPackets += Environment.NewLine;

            //array to store our data
            byte[] data = packet.Packet.Data;

            //keep track of the number of bytes displayed per line
            int byteCounter = 0;

            stringPackets += "Destination MAC Address: ";

            //Parsing the packets
            foreach (byte b in data)
            {
                //Add the byte to our string (in hexadecimal)
                if(byteCounter<=13) stringPackets += b.ToString("X2") + " ";
                byteCounter++;

                switch(byteCounter)
                {
                    case 6: stringPackets += Environment.NewLine;
                        stringPackets += "Source MAC Address: ";
                        break;
                    case 12: stringPackets += Environment.NewLine;
                        stringPackets += "EtherType: ";
                        break;
                    case 14: if(data[12] == 8)
                        {
                            if (data[13] == 0)
                            {
                                stringPackets += "(IP)";
                                totalIP++;
                            }
                            if (data[13] == 6)
                            {
                                stringPackets += "(ARP)";
                                totalARP++;
                            }
                        }
                        break;
                }
            }

            stringPackets += Environment.NewLine + Environment.NewLine;
            byteCounter = 0;
            stringPackets += "Raw Data" + Environment.NewLine;

            //Process each byte in our captured packet
            foreach (byte b in data)
            {
                //Add the byte to our string (in hexadecimal)
                stringPackets += b.ToString("X2") + " ";
                byteCounter++;

                if (byteCounter == 16)
                {
                    byteCounter = 0;
                    stringPackets += Environment.NewLine;
                }
            }
            stringPackets += Environment.NewLine;
            stringPackets += Environment.NewLine;

        }

        private void txtCapturedData_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStartStop.Text == "Start")
                {
                    device.StartCapture();
                    timer1.Enabled = true;
                    btnStartStop.Text = "Stop";
                }
                else
                {
                    device.StopCapture();
                    timer1.Enabled = false;
                    btnStartStop.Text = "Start";
                }
            }
            catch(Exception exp)
            {

            }
        }

        //dump the packet data from stringPackets to the text box
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCapturedData.AppendText(stringPackets);
            stringPackets = "";
            txtNumPackets.Text = Convert.ToString(numPackets);
            //txtNumPackets.Text = numPackets + "";
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = devices[cmbDevices.SelectedIndex];
            cmbDevices.Text = device.Description;

            //register handler function to the packet arrival event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save the Captured Packets";
            saveFileDialog1.ShowDialog();

            //Check to see if a filename was given
            if(saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtCapturedData.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog1.Title = "Open the Captured Packets";
            openFileDialog1.ShowDialog();

            //Check to see if a filename was given
            if (openFileDialog1.FileName != "")
            {
                txtCapturedData.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void txtNumPackets_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmSend.instantiations == 0)
            {
                fSend = new frmSend(); //Creates a new frmSend
                fSend.Show();
            }
           
        }

        private void packetAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmData.instantiations == 0)
            {
                fData = new frmData(); //new frmData
                fData.Show();
            }
        }

        private void chartNumPackets_Click(object sender, EventArgs e)
        {
            
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            this.chartNumPackets.Series["Number of Packets"].Points.AddXY("IP", totalIP);
            this.chartNumPackets.Series["Number of Packets"].Points.AddXY("ARP", totalARP);
            this.chartNumPackets.Series["Number of Packets"].Points.AddXY("TCP", totalTCP);
            this.chartNumPackets.Series["Number of Packets"].Points.AddXY("UDP", totalUDP);
        }
    }
}
