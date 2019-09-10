using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace Namakalni_sistem
{
    public partial class config : Form
    {
        
        
        public config()
        {
            variables.form1shown = false;
            InitializeComponent();
            string IP = variables.IP;
            ip_Label.Text = IP;
            get_system_date();
            get_system_time();
            ip_textBox.Text = ip_Label.Text;
            Cursor.Current = Cursors.Default;
            
            
            
        }

        public void UDPListener()
        {


            bool done = false;
            


            UdpClient listener = new UdpClient(11002);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11002);
            string received_data;
            byte[] receive_byte_array;

            listener.Client.ReceiveTimeout = 300; //block waiting for connections

            try
            {
                while (!done)
                {
                    //MessageBox.Show("Waiting for broadcast");
                    button3.BackColor = Color.IndianRed;  
                    receive_byte_array = listener.Receive(ref groupEP);
                    //MessageBox.Show("Received a broadcast from {0}", groupEP.ToString() );
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

                    //MessageBox.Show(received_data);
                    if (received_data.Contains("<OK>") == true)
                    {
                        button3.BackColor = Color.LightGreen;
                        
                    }

                    
                    else if (received_data.Contains("<SYS_TM>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        //MessageBox.Show(myString);
                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        variables.cas_sistema_ura = (tokens[1]);
                        pc_time_label.Text = variables.cas_sistema_ura;

                    }
                    else if (received_data.Contains("<DT>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        //MessageBox.Show(myString);
                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        variables.cas_sistema_datum = (tokens[1]);
                        pc_date_label.Text = variables.cas_sistema_datum;

                    }

                    
                    break;
                    //("data follows \n{0}\n\n", received_data);
                }
               
                    

            }





            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //MessageBox.Show(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }


        public void get_system_time()
        {
            //MessageBox.Show("System time check CONFIG");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_TM>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            UDPListener();
            //
        }

        public void get_system_date()
        {
            //MessageBox.Show("System time check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_DT>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            UDPListener();
            //
        }
        

        public void button1_Click(object sender, EventArgs e)
        {
            variables.IP = ip_textBox.Text;


            //int PORT = int.Parse(port_textBox.Text);

            string IP = variables.IP;
            ip_Label.Text = IP;

        }

        private void začetnaStranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
           
        }

        
        /*private void button2_Click(object sender, EventArgs e)
        {
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TEST>");

            if (ip_textBox.Text == "")
            {
                MessageBox.Show("Vnesi IP!");
            }
            else
            {
                //Port in ip za pošiljanje UDP paketa
                string IP = ip_textBox.Text;
                //int const listenPort = (Convert.ToInt32(variables.PORT));
                int port = 8888;

                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                //
            }
        }*/

        private void zelenicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void posodobi_time_btn_Click(object sender, EventArgs e)
        {
            
            int epoch_int = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            epoch_int = epoch_int + 7200; //LJUBLJANA offset
            
            string epoch_string = epoch_int.ToString(); //shranjen epoch trenutni čas računalnika
            
            
            byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes("<ST>" + epoch_string);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
            
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData, ep);

            //poslušanje

            UDPListener();
            get_system_time();
            get_system_date();
            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pc_time_label.Text = variables.cas_sistema_ura;
            pc_date_label.Text = variables.cas_sistema_datum;
        }

        private void časovnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sett_zelenica home = new sett_zelenica(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void živaMejaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sett_kapljicno home = new sett_kapljicno(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void vrtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sett_vrt home = new sett_vrt(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void intervaliVentilovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veje_sett home = new Veje_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TEST>");

            if (ip_textBox.Text == "")
            {
                MessageBox.Show("Vnesi IP!");
            }
            else
            {
                //Port in ip za pošiljanje UDP paketa
                string IP = ip_textBox.Text;
                //int const listenPort = (Convert.ToInt32(variables.PORT));
                int port = 8888;

                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                //
            }
        }

        private void dOMOVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            //this.Hide();

            this.Close();
        }

        

        

        

        


                
    }
}
