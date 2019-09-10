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
using System.Threading;

namespace Namakalni_sistem
{
    public partial class avtomatika_sett : Form
    {
        public avtomatika_sett()
        {
            InitializeComponent();
            label4.Text = Convert.ToString(variables.OD_H_avtomatika) + ":" + Convert.ToString(variables.OD_M_avtomatika);
            od_H_avtomatika_box.Text = Convert.ToString(variables.OD_H_avtomatika);
            od_M_avtomatika_box.Text = Convert.ToString(variables.OD_M_avtomatika);

            if (variables.ure_shranjene == false)
            {
                excludet_date_1_check();
                excludet_date_2_check();
                excludet_date_3_check();
                excludet_date_4_check();
                excludet_date_5_check();
                excludet_date_6_check();
                excludet_date_7_check();
            }
            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;
        }

        private void spremeni_btn_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            variables.OD_H_avtomatika = od_H_avtomatika_box.Text;
            //MessageBox.Show("2");
            variables.OD_M_avtomatika = od_M_avtomatika_box.Text;
            //MessageBox.Show("3");
            label4.Text = variables.OD_H_avtomatika + ":" + variables.OD_M_avtomatika;
            //MessageBox.Show("AS");
            send_odH();
            send_odM();




            //MessageBox.Show("Shranjeno");
            //SendTest();
            odH_check();
            odM_check();

            

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void send_odH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<odH_a>" + variables.OD_H_avtomatika);
            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener();
        }
        private void send_odM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<odM_a>" + variables.OD_M_avtomatika);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);



        }

        private void odH_check()
        {
            //MessageBox.Show("zel_int1_odM_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<odH_aCH>");

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
        private void odM_check()
        {
            // MessageBox.Show("zel_int1_doH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<odM_aCH>");

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

        public void disableButtons()
        {


            this.save_btn.Enabled = false;
            this.btn_preberi_zel.Enabled = false;
            this.save_date_btn.Enabled = false;
            this.remove_date_btn.Enabled = false;
            this.button1.Enabled = false;

            
        }

        public void enableButtons()
        {


            this.save_btn.Enabled = true;
            this.btn_preberi_zel.Enabled = true;
            this.save_date_btn.Enabled = true;
            this.remove_date_btn.Enabled = true;
            this.button1.Enabled = true;
            
        }

        public void UDPListener()
        {

            variables.udpfree = false;
            bool done = false;



            UdpClient listener1 = new UdpClient(11002);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11002);
            string received_data;
            byte[] receive_byte_array;
            listener1.Client.ReceiveTimeout = 500; //block waiting for connections
            if (listener1.Client.Connected == false)
            {
                if (variables.repeat_one_time == 0)
                {
                    //Izključeno zaradi priklopa direkt na pc
                    //MessageBox.Show("Kontroler ni povezan!");
                    variables.repeat_one_time = 1;
                    variables.controller_connected = false;
                }
            }

            try
            {
                while (!done)
                {
                    //MessageBox.Show("Waiting for broadcast");
                    receive_byte_array = listener1.Receive(ref groupEP);
                    //MessageBox.Show("Received a broadcast from {0}", groupEP.ToString() );
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    variables.repeat_one_time = 0;
                    //MessageBox.Show(received_data);

                    if (received_data.Contains("<odH_>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.OD_H_avtomatika = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.OD_H_avtomatika = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("<odM_>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.OD_M_avtomatika = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.OD_M_avtomatika = (tokens[1]);

                        }
                        label4.Text = Convert.ToString(variables.OD_H_avtomatika) + ":" + Convert.ToString(variables.OD_M_avtomatika);
                        od_H_avtomatika_box.Text = Convert.ToString(variables.OD_H_avtomatika);
                        od_M_avtomatika_box.Text = Convert.ToString(variables.OD_M_avtomatika);
                    }

                    else if (received_data.Contains("<1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica = tokens[1];
                    }
                    else if (received_data.Contains("<2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica2 = tokens[1];
                    }
                    else if (received_data.Contains("<3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica3 = tokens[1];
                    }
                    else if (received_data.Contains("<4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica4 = tokens[1];
                    }
                    else if (received_data.Contains("<5>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica5 = tokens[1];
                    }
                    else if (received_data.Contains("<6>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica6 = tokens[1];
                    }
                    else if (received_data.Contains("<7>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');
                        variables.chosendate_zelenica7 = tokens[1];
                    }
                    
                    else if (received_data.Contains("<OK>") == true)
                    {

                        //odH_check();
                        //odM_check();
                        //MessageBox.Show("Shranjeno!");
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

                listener1.Close();
                variables.udpfree = true;
            }
        }

        private void avtomatika_sett_Load(object sender, EventArgs e)
        {

        }

        private void zAPRIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void domovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void iPKontrolerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            config fconfig = new config();
            fconfig.ShowDialog();

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

        private void časovnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sett_zelenica home = new sett_zelenica(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void intervaliVentilovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veje_sett home = new Veje_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void save_date_btn_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            if (variables.chosendate_zelenica == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (variables.chosendate_zelenica2 == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (variables.chosendate_zelenica3 == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (variables.chosendate_zelenica4 == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (variables.chosendate_zelenica5 == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (variables.chosendate_zelenica6 == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (variables.chosendate_zelenica7 == dateTimePicker1.Text)
            {
                MessageBox.Show("Ta datum je že vnešen!");
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica))
            {
                variables.chosendate_zelenica = dateTimePicker1.Text;
                //send_IZ_ZEL_1_BOX();
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica2))
            {
                variables.chosendate_zelenica2 = dateTimePicker1.Text;
                //send_IZ_ZEL_2_BOX();
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica3))
            {
                variables.chosendate_zelenica3 = dateTimePicker1.Text;
                //send_IZ_ZEL_3_BOX();
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica4))
            {
                variables.chosendate_zelenica4 = dateTimePicker1.Text;
                //send_IZ_ZEL_4_BOX();
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica5))
            {
                variables.chosendate_zelenica5 = dateTimePicker1.Text;
                //send_IZ_ZEL_5_BOX();
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica6))
            {
                variables.chosendate_zelenica6 = dateTimePicker1.Text;
                // send_IZ_ZEL_6_BOX();
            }
            else if (string.IsNullOrEmpty(variables.chosendate_zelenica7))
            {
                variables.chosendate_zelenica7 = dateTimePicker1.Text;
                //send_IZ_ZEL_7_BOX();
            }


            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;

            
            Cursor.Current = Cursors.WaitCursor;
            variables.OD_H_avtomatika = od_H_avtomatika_box.Text;
            //MessageBox.Show("2");
            variables.OD_M_avtomatika = od_M_avtomatika_box.Text;
            //MessageBox.Show("3");
            label4.Text = variables.OD_H_avtomatika + ":" + variables.OD_M_avtomatika;
            //MessageBox.Show("AS");
            send_odH();
            send_odM();




            //MessageBox.Show("Shranjeno");
            //SendTest();
            odH_check();
            odM_check();

            send_IZ_ZEL_1_BOX();
            send_IZ_ZEL_2_BOX();
            send_IZ_ZEL_3_BOX();
            send_IZ_ZEL_4_BOX();
            send_IZ_ZEL_5_BOX();
            send_IZ_ZEL_6_BOX();
            send_IZ_ZEL_7_BOX();
            send_check_signal();

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void remove_date_btn_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            if (variables.chosendate_zelenica == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica = variables.chosendate_zelenica2;
                variables.chosendate_zelenica2 = variables.chosendate_zelenica3;
                variables.chosendate_zelenica3 = variables.chosendate_zelenica4;
                variables.chosendate_zelenica4 = variables.chosendate_zelenica5;
                variables.chosendate_zelenica5 = variables.chosendate_zelenica6;
                variables.chosendate_zelenica6 = variables.chosendate_zelenica7;
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();

            }
            else if (variables.chosendate_zelenica2 == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica2 = variables.chosendate_zelenica3;
                variables.chosendate_zelenica3 = variables.chosendate_zelenica4;
                variables.chosendate_zelenica4 = variables.chosendate_zelenica5;
                variables.chosendate_zelenica5 = variables.chosendate_zelenica6;
                variables.chosendate_zelenica6 = variables.chosendate_zelenica7;
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
            }
            else if (variables.chosendate_zelenica3 == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica3 = variables.chosendate_zelenica4;
                variables.chosendate_zelenica4 = variables.chosendate_zelenica5;
                variables.chosendate_zelenica5 = variables.chosendate_zelenica6;
                variables.chosendate_zelenica6 = variables.chosendate_zelenica7;
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
            }
            else if (variables.chosendate_zelenica4 == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica4 = variables.chosendate_zelenica5;
                variables.chosendate_zelenica5 = variables.chosendate_zelenica6;
                variables.chosendate_zelenica6 = variables.chosendate_zelenica7;
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
            }
            else if (variables.chosendate_zelenica5 == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica5 = variables.chosendate_zelenica6;
                variables.chosendate_zelenica6 = variables.chosendate_zelenica7;
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
            }
            else if (variables.chosendate_zelenica6 == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica6 = variables.chosendate_zelenica7;
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
            }
            else if (variables.chosendate_zelenica7 == dateTimePicker1.Text)
            {
                variables.chosendate_zelenica7 = "";
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
            }
            else
            {
                MessageBox.Show("Ta datum ni vnešen!");
            }



            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;
            send_check_signal();

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            variables.OD_H_avtomatika = od_H_avtomatika_box.Text;
            //MessageBox.Show("2");
            variables.OD_M_avtomatika = od_M_avtomatika_box.Text;
            //MessageBox.Show("3");
            label4.Text = variables.OD_H_avtomatika + ":" + variables.OD_M_avtomatika;
            //MessageBox.Show("AS");
            send_odH();
            send_odM();




            //MessageBox.Show("Shranjeno");
            //SendTest();
            odH_check();
            odM_check();



            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void send_IZ_ZEL_1_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z1>" + variables.chosendate_zelenica);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }
        private void send_IZ_ZEL_2_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z2>" + variables.chosendate_zelenica2);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }
        private void send_IZ_ZEL_3_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z3>" + variables.chosendate_zelenica3);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }
        private void send_IZ_ZEL_4_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z4>" + variables.chosendate_zelenica4);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }
        private void send_IZ_ZEL_5_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z5>" + variables.chosendate_zelenica5);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }
        private void send_IZ_ZEL_6_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z6>" + variables.chosendate_zelenica6);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }
        private void send_IZ_ZEL_7_BOX()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z7>" + variables.chosendate_zelenica7);

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            //UDPListener2();
        }

        public void excludet_date_1_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z1_CH>");

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
        public void excludet_date_2_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z2_CH>");

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
        public void excludet_date_3_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z3_CH>");

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
        public void excludet_date_4_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z4_CH>");

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
        public void excludet_date_5_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z5_CH>");

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
        public void excludet_date_6_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z6_CH>");

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
        public void excludet_date_7_check()
        {
            //MessageBox.Show("System date check");
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IZ_Z7_CH>");

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

        public void send_check_signal()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TEST>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

            //poslušanje

            UDPListener();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            variables.OD_H_avtomatika = od_H_avtomatika_box.Text;
            //MessageBox.Show("2");
            variables.OD_M_avtomatika = od_M_avtomatika_box.Text;
            //MessageBox.Show("3");
            label4.Text = variables.OD_H_avtomatika + ":" + variables.OD_M_avtomatika;
            //MessageBox.Show("AS");
            send_odH();
            send_odM();




            //MessageBox.Show("Shranjeno");
            //SendTest();
            odH_check();
            odM_check();



            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }
    }
}
