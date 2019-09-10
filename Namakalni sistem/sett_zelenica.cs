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
    public partial class sett_zelenica : Form
    {
        bool startup = true;

        public sett_zelenica()
        {

            variables.form1shown = false;
            //MessageBox.Show("Komuniciram z kontrolerjem");
            InitializeComponent();
            //posodobi čase iz kontrolerja, če še niso

            if (variables.ure_shranjene == false)
            {
                ////DO SEM
                zel_int1_odH_check();
                zel_int1_odM_check();
                zel_int1_doH_check();
                zel_int1_doM_check();
                zel_int2_odH_check();
                zel_int2_odM_check();
                zel_int2_doH_check();
                zel_int2_doM_check();
                zel_int3_odH_check();
                zel_int3_odM_check();
                zel_int3_doH_check();
                zel_int3_doM_check();
                zel_int4_odH_check();
                zel_int4_odM_check();
                zel_int4_doH_check();
                zel_int4_doM_check();

                zel_pon_check();
                zel_tor_check();
                zel_sre_check();
                zel_cet_check();
                zel_pet_check();
                zel_sob_check();
                zel_ned_check();
                zel_int1_check();
                zel_int2_check();
                zel_int3_check();
                zel_int4_check();

                excludet_date_1_check();
                excludet_date_2_check();
                excludet_date_3_check();
                excludet_date_4_check();
                excludet_date_5_check();
                excludet_date_6_check();
                excludet_date_7_check();

                variables.ure_shranjene = true;
            }
            

            

            //Interval 1 zelenica
            string P_OD_H = variables.P_OD_H;
            string P_OD_M = variables.P_OD_M;
            string P_DO_H = variables.P_DO_H;
            string P_DO_M = variables.P_DO_M;


            //Interval 2 zelenica
            string D_OD_H = variables.D_OD_H;
            string D_OD_M = variables.D_OD_M;
            string D_DO_H = variables.D_DO_H;
            string D_DO_M = variables.D_DO_M;

            //Interval 3 zelenica
            string T_OD_H = variables.T_OD_H;
            string T_OD_M = variables.T_OD_M;
            string T_DO_H = variables.T_DO_H;
            string T_DO_M = variables.T_DO_M;

            //Interval 4 zelenica
            string S_OD_H = variables.S_OD_H;
            string S_OD_M = variables.S_OD_M;
            string S_DO_H = variables.S_DO_H;
            string S_DO_M = variables.S_DO_M;

            comboBox1_OD_H.Text = P_OD_H;
            comboBox1_OD_M.Text = P_OD_M;
            comboBox1_DO_H.Text = P_DO_H;
            comboBox1_DO_M.Text = P_DO_M;

            comboBox2_OD_H.Text = D_OD_H;
            comboBox2_OD_M.Text = D_OD_M;
            comboBox2_DO_H.Text = D_DO_H;
            comboBox2_DO_M.Text = D_DO_M;

            comboBox3_OD_H.Text = T_OD_H;
            comboBox3_OD_M.Text = T_OD_M;
            comboBox3_DO_H.Text = T_DO_H;
            comboBox3_DO_M.Text = T_DO_M;

            comboBox4_OD_H.Text = S_OD_H;
            comboBox4_OD_M.Text = S_OD_M;
            comboBox4_DO_H.Text = S_DO_H;
            comboBox4_DO_M.Text = S_DO_M;

            Sum_interval1_time_FUNC();
            Sum_interval2_time_FUNC();
            Sum_interval3_time_FUNC();
            Sum_interval4_time_FUNC();

            

            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;

            if (variables.pon_zelenica) { checkBox_PON_Z.Checked = true; }
            else { checkBox_PON_Z.Checked = false; }
            if (variables.tor_zelenica) { checkBox_TOR_Z.Checked = true; }
            else { checkBox_TOR_Z.Checked = false; }
            if (variables.sre_zelenica) { checkBox_SRE_Z.Checked = true; }
            else { checkBox_SRE_Z.Checked = false; }
            if (variables.cet_zelenica) { checkBox_CET_Z.Checked = true; }
            else { checkBox_CET_Z.Checked = false; }
            if (variables.pet_zelenica) { checkBox_PET_Z.Checked = true; }
            else { checkBox_PET_Z.Checked = false; }
            if (variables.sob_zelenica) { checkBox_SOB_Z.Checked = true; }
            else { checkBox_SOB_Z.Checked = false; }
            if (variables.ned_zelenica) { checkBox_NED_Z.Checked = true; }
            else { checkBox_NED_Z.Checked = false; }

            if (variables.int1_zel) { checkBox_interval1_z.Checked = true; }
            else { checkBox_interval1_z.Checked = false; }
            if (variables.int2_zel) { checkBox_interval2_z.Checked = true; }
            else { checkBox_interval2_z.Checked = false; }
            if (variables.int3_zel) { checkBox_interval3_z.Checked = true; }
            else { checkBox_interval3_z.Checked = false; }
            if (variables.int4_zel) { checkBox_interval4_z.Checked = true; }
            else { checkBox_interval4_z.Checked = false; }

            startup = false;

            priporocljiv_interval_calc();
            Cursor.Current = Cursors.Default;

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
                Cursor.Current = Cursors.WaitCursor;
                disableButtons();
                TimeSpan start1 = new TimeSpan(Convert.ToInt16(comboBox1_OD_H.Text), Convert.ToInt16(comboBox1_OD_M.Text), 0);
                TimeSpan end1 = new TimeSpan(Convert.ToInt16(comboBox1_DO_H.Text), Convert.ToInt16(comboBox1_DO_M.Text), 0); //12 o'clock
                TimeSpan start2 = new TimeSpan(Convert.ToInt16(comboBox2_OD_H.Text), Convert.ToInt16(comboBox2_OD_M.Text), 0);
                TimeSpan end2 = new TimeSpan(Convert.ToInt16(comboBox2_DO_H.Text), Convert.ToInt16(comboBox2_DO_M.Text), 0);
                TimeSpan start3 = new TimeSpan(Convert.ToInt16(comboBox3_OD_H.Text), Convert.ToInt16(comboBox3_OD_M.Text), 0);
                TimeSpan end3 = new TimeSpan(Convert.ToInt16(comboBox3_DO_H.Text), Convert.ToInt16(comboBox3_DO_M.Text), 0);
                TimeSpan start4 = new TimeSpan(Convert.ToInt16(comboBox4_OD_H.Text), Convert.ToInt16(comboBox4_OD_M.Text), 0);
                TimeSpan end4 = new TimeSpan(Convert.ToInt16(comboBox4_DO_H.Text), Convert.ToInt16(comboBox4_DO_M.Text), 0);
                if ((start2 >= start1) && (start2 <= end1))
                {
                    MessageBox.Show("Začetek 2. intervala je znotraj 1. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start2 >= start3) && (start2 <= end3))
                {
                    MessageBox.Show("Začetek 2. intervala je znotraj 3. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start2 >= start4) && (start2 <= end4))
                {
                    MessageBox.Show("Začetek 2. intervala je znotraj 4. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                
                else if((start1 >= start2) && (start1 <= end2))
                {
                    MessageBox.Show("Začetek 1. intervala je znotraj 2. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start1 >= start3) && (start1 <= end3))
                {
                    MessageBox.Show("Začetek 1. intervala je znotraj 3. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start1 >= start4) && (start1 <= end4))
                {
                    MessageBox.Show("Začetek 1. intervala je znotraj 4. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start3 >= start1) && (start3 <= end1))
                {
                    MessageBox.Show("Začetek 3. intervala je znotraj 1. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start3 >= start2) && (start3 <= end2))
                {
                    MessageBox.Show("Začetek 3. intervala je znotraj 2. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start3 >= start4) && (start3 <= end4))
                {
                    MessageBox.Show("Začetek 3. intervala je znotraj 4. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start4 >= start1) && (start4 <= end1))
                {
                    MessageBox.Show("Začetek 4. intervala je znotraj 1. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if((start4 >= start2) && (start4 <= end2))
                {
                    MessageBox.Show("Začetek 4. intervala je znotraj 2. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if ((start4 >= start3) && (start4 <= end3))
                {
                    MessageBox.Show("Začetek 4. intervala je znotraj 3. intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if (start1 >= end1)
                {
                    MessageBox.Show("Konec 1. intervala je manjši ali enak začetku tega intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if (start2 >= end2)
                {
                    MessageBox.Show("Konec 1. intervala je manjši ali enak začetku tega intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if (start3 >= end3)
                {
                    MessageBox.Show("Konec 1. intervala je manjši ali enak začetku tega intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else if (start4 >= end4)
                {
                    MessageBox.Show("Konec 1. intervala je manjši ali enak začetku tega intervala!");
                    Application.DoEvents();
                    enableButtons();
                }
                else
                {
                    variables.samodejno_shrenjevanje_novih_intervalov = true;

                    variables.P_OD_H = comboBox1_OD_H.Text;
                    variables.P_OD_M = comboBox1_OD_M.Text;
                    variables.P_DO_H = comboBox1_DO_H.Text;
                    variables.P_DO_M = comboBox1_DO_M.Text;

                    variables.D_OD_H = comboBox2_OD_H.Text;
                    variables.D_OD_M = comboBox2_OD_M.Text;
                    variables.D_DO_H = comboBox2_DO_H.Text;
                    variables.D_DO_M = comboBox2_DO_M.Text;

                    variables.T_OD_H = comboBox3_OD_H.Text;
                    variables.T_OD_M = comboBox3_OD_M.Text;
                    variables.T_DO_H = comboBox3_DO_H.Text;
                    variables.T_DO_M = comboBox3_DO_M.Text;

                    variables.S_OD_H = comboBox4_OD_H.Text;
                    variables.S_OD_M = comboBox4_OD_M.Text;
                    variables.S_DO_H = comboBox4_DO_H.Text;
                    variables.S_DO_M = comboBox4_DO_M.Text;

                    if (checkBox_PON_Z.Checked == true) { variables.pon_zelenica = true; } else { variables.pon_zelenica = false; }
                    if (checkBox_TOR_Z.Checked == true) { variables.tor_zelenica = true; } else { variables.tor_zelenica = false; }
                    if (checkBox_SRE_Z.Checked == true) { variables.sre_zelenica = true; } else { variables.sre_zelenica = false; }
                    if (checkBox_CET_Z.Checked == true) { variables.cet_zelenica = true; } else { variables.cet_zelenica = false; }
                    if (checkBox_PET_Z.Checked == true) { variables.pet_zelenica = true; } else { variables.pet_zelenica = false; }
                    if (checkBox_SOB_Z.Checked == true) { variables.sob_zelenica = true; } else { variables.sob_zelenica = false; }
                    if (checkBox_NED_Z.Checked == true) { variables.ned_zelenica = true; } else { variables.ned_zelenica = false; }

                    if (checkBox_interval1_z.Checked == true) { variables.int1_zel = true; } else { variables.int1_zel = false; }
                    if (checkBox_interval2_z.Checked == true) { variables.int2_zel = true; } else { variables.int2_zel = false; }
                    if (checkBox_interval3_z.Checked == true) { variables.int3_zel = true; } else { variables.int3_zel = false; }
                    if (checkBox_interval4_z.Checked == true) { variables.int4_zel = true; } else { variables.int4_zel = false; }


                    send_int1_odH();
                    send_check_signal();
                    send_int1_odM();
                    send_check_signal();
                    send_int1_doH();
                    send_check_signal();
                    send_int1_doM();
                    send_check_signal();
                    //send_check_signal();
                    send_int2_odH();
                    send_check_signal();
                    send_int2_odM();
                    send_check_signal();
                    send_int2_doH();
                    send_check_signal();
                    send_int2_doM();
                    send_check_signal();
                    //send_check_signal();
                    send_int3_odH();
                    send_check_signal();
                    send_int3_odM();
                    send_check_signal();
                    send_int3_doH();
                    send_check_signal();
                    send_int3_doM();
                    send_check_signal();
                    //send_check_signal();
                    send_int4_odH();
                    send_check_signal();
                    send_int4_odM();
                    send_check_signal();
                    send_int4_doH();
                    send_check_signal();
                    send_int4_doM();
                    send_check_signal();
                    //send_check_signal();
                    send_PON_BOX();
                    send_check_signal();
                    send_TOR_BOX();
                    send_check_signal();
                    send_SRE_BOX();
                    send_check_signal();
                    send_CET_BOX();
                    send_check_signal();
                    send_PET_BOX();
                    send_check_signal();
                    send_SOB_BOX();
                    send_check_signal();
                    send_NED_BOX();
                    //send_check_signal();

                    send_check_signal();
                    send_INT1_BOX();
                    send_check_signal();
                    send_INT2_BOX();
                    send_check_signal();
                    send_INT3_BOX();
                    send_check_signal();
                    send_check_signal();
                    send_INT4_BOX();
                    //send_check_signal();
                    
                    send_IZ_ZEL_1_BOX();
                    send_check_signal();
                    send_IZ_ZEL_2_BOX();
                    send_check_signal();
                    send_IZ_ZEL_3_BOX();
                    send_check_signal();
                    send_IZ_ZEL_4_BOX();
                    //send_check_signal();
                    send_IZ_ZEL_5_BOX();
                    send_check_signal();
                    send_IZ_ZEL_6_BOX();
                    send_check_signal();
                    send_IZ_ZEL_7_BOX();
                    send_check_signal();
                    //MessageBox.Show("Poslano");
                    Application.DoEvents();
                    enableButtons();
                    Veje_sett home = new Veje_sett(); // Instantiate a Form3 object.
                    home.Show(); // Show Form3 and
                    
                    this.Hide();
                }
                
        }


        //Preverjanje časov shranjenih na kontrolerju
        private void zel_int1_odH_check()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T1>");

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
        private void zel_int1_odM_check()
        {
            //MessageBox.Show("zel_int1_odM_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T2>");

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
        private void zel_int1_doH_check()
        {
            // MessageBox.Show("zel_int1_doH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T3>");

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
        private void zel_int1_doM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T4>");

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
        private void zel_int2_odH_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T5>");

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
        private void zel_int2_odM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T6>");

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
        private void zel_int2_doH_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T7>");

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
        private void zel_int2_doM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T8>");

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
        private void zel_int3_odH_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T9>");

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
        private void zel_int3_odM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T10>");

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
        private void zel_int3_doH_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T11>");

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
        private void zel_int3_doM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T12>");

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
        private void zel_int4_odH_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T13>");

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
        private void zel_int4_odM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T14>");

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
        private void zel_int4_doH_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T15>");

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
        private void zel_int4_doM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<ZE_T16>");

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

        //Preveri izbrane dni namakanja iz kontrolerja
        private void zel_pon_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<PON_ch>");

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
        private void zel_tor_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TOR_ch>");

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
        private void zel_sre_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SRE_ch>");

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
        private void zel_cet_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<CET_ch>");

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
        private void zel_pet_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<PET_ch>");

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
        private void zel_sob_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SOB_ch>");

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
        private void zel_ned_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NED_ch>");

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

        //Preveri izbrane intervale namakanja iz kontrolerja
        private void zel_int1_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IN1Z_ch>");

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
        private void zel_int2_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IN2Z_ch>");

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
        private void zel_int3_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IN3Z_ch>");

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
        private void zel_int4_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<IN4Z_ch>");

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


        //Pošiljanje novih časov na kontroler
        private void send_int1_odH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_1>" + variables.P_OD_H);

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
        private void send_int1_odM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_2>" + variables.P_OD_M);

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
        private void send_int1_doH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_3>" + variables.P_DO_H);

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
        private void send_int1_doM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_4>" + variables.P_DO_M);

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
        private void send_int2_odH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_5>" + variables.D_OD_H);

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
        private void send_int2_odM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_6>" + variables.D_OD_M);

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
        private void send_int2_doH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_7>" + variables.D_DO_H);

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
        private void send_int2_doM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_8>" + variables.D_DO_M);

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
        private void send_int3_odH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_9>" + variables.T_OD_H);

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
        private void send_int3_odM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_10>" + variables.T_OD_M);

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
        private void send_int3_doH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_11>" + variables.T_DO_H);

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
        private void send_int3_doM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_12>" + variables.T_DO_M);

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
        private void send_int4_odH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_13>" + variables.S_OD_H);

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
        private void send_int4_odM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_14>" + variables.S_OD_M);

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
        private void send_int4_doH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_15>" + variables.S_DO_H);

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
        private void send_int4_doM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NT_16>" + variables.S_DO_M);

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

        //pošiljanje dni namakanja
        private void send_PON_BOX()
        {
            string SendData;
            if (checkBox_PON_Z.Checked == true)
            {
                SendData = "<PON>ON";
                variables.pon_zelenica = true;
            }
            else
            {
                SendData = "<PON>OFF";
                variables.pon_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_TOR_BOX()
        {
            string SendData;
            if (checkBox_TOR_Z.Checked == true)
            {
                SendData = "<TOR>ON";
                variables.tor_zelenica = true;
            }
            else
            {
                SendData = "<TOR>OFF";
                variables.tor_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_SRE_BOX()
        {
            string SendData;
            if (checkBox_SRE_Z.Checked == true)
            {
                SendData = "<SRE>ON";
                variables.sre_zelenica = true;
            }
            else
            {
                SendData = "<SRE>OFF";
                variables.sre_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_CET_BOX()
        {
            string SendData;
            if (checkBox_CET_Z.Checked == true)
            {
                SendData = "<CET>ON";
                variables.cet_zelenica = true;
            }
            else
            {
                SendData = "<CET>OFF";
                variables.cet_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_PET_BOX()
        {
            string SendData;
            if (checkBox_PET_Z.Checked == true)
            {
                SendData = "<PET>ON";
                variables.pet_zelenica = true;
            }
            else
            {
                SendData = "<PET>OFF";
                variables.pet_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_SOB_BOX()
        {
            string SendData;
            if (checkBox_SOB_Z.Checked == true)
            {
                SendData = "<SOB>ON";
                variables.sob_zelenica = true;
            }
            else
            {
                SendData = "<SOB>OFF";
                variables.sob_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_NED_BOX()
        {
            string SendData;
            if (checkBox_NED_Z.Checked == true)
            {
                SendData = "<NED>ON";
                variables.ned_zelenica = true;
            }
            else
            {
                SendData = "<NED>OFF";
                variables.ned_zelenica = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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

        //pošiljanje intervalov
        private void send_INT1_BOX()
        {
            string SendData;
            if (checkBox_interval1_z.Checked == true)
            {
                SendData = "<INT1_Z>ON";
                variables.int1_zel = true;
            }
            else
            {
                SendData = "<INT1_Z>OFF";
                variables.int1_zel = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_INT2_BOX()
        {
            string SendData;
            if (checkBox_interval2_z.Checked == true)
            {
                SendData = "<INT2_Z>ON";
                variables.int2_zel = true;
            }
            else
            {
                SendData = "<INT2_Z>OFF";
                variables.int2_zel = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_INT3_BOX()
        {
            string SendData;
            if (checkBox_interval3_z.Checked == true)
            {
                SendData = "<INT3_Z>ON";
                variables.int3_zel = true;
            }
            else
            {
                SendData = "<INT3_Z>OFF";
                variables.int2_zel = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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
        private void send_INT4_BOX()
        {
            string SendData;
            if (checkBox_interval4_z.Checked == true)
            {
                SendData = "<INT4_Z>ON";
                variables.int4_zel = true;
            }
            else
            {
                SendData = "<INT4_Z>OFF";
                variables.int4_zel = false;
            }
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes(SendData);
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


        public void UDPListener()
        {


            bool done = false;



            UdpClient listener = new UdpClient(11002);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11002);
            string received_data;
            byte[] receive_byte_array;
            listener.Client.ReceiveTimeout = 15000; //block waiting for connections
            if (listener.Client.Connected == false)
            {
                if (variables.repeat_one_time == 0)
                {
                    //Izključeno zaradi priklopa direkt na pc
                    //MessageBox.Show("Kontroler ni povezan!");
                    variables.repeat_one_time = 1;
                }
            }



            try
            {
                while (!done)
                {
                    //MessageBox.Show("Waiting for broadcast");
                    receive_byte_array = listener.Receive(ref groupEP);
                    //MessageBox.Show("Received a broadcast from {0}", groupEP.ToString() );
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

                    variables.repeat_one_time = 0;
                    //MessageBox.Show(received_data);
                    //1 interval od H
                    if (received_data.Contains("<ZE_T1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.P_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.P_OD_H = (tokens[1]);

                        }

                    }
                    //interval 1 od m
                    else if (received_data.Contains("<ZE_T2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.P_OD_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.P_OD_M = (tokens[1]);

                        }

                    }

                    //interval 1 do h
                    else if (received_data.Contains("ZE_T3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.P_DO_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.P_DO_H = (tokens[1]);

                        }

                    }
                    //interval 1 od m
                    else if (received_data.Contains("ZE_T4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.P_DO_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.P_DO_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T5>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.D_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.D_OD_H = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T6>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.D_OD_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.D_OD_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T7>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.D_DO_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.D_DO_H = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T8>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.D_DO_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.D_DO_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T9>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.T_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.T_OD_H = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T10") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.T_OD_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.T_OD_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T11") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.T_DO_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.T_DO_H = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T12") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.T_DO_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.T_DO_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T13") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.S_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.S_OD_H = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T14") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.S_OD_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.S_OD_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T15") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.S_DO_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.S_DO_H = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("ZE_T16") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.S_DO_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.S_DO_M = (tokens[1]);

                        }


                    }
                    else if (received_data.Contains("<PON>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_PON_Z.Checked = true; variables.pon_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_PON_Z.Checked = false; variables.pon_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<TOR>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_TOR_Z.Checked = true; variables.tor_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_TOR_Z.Checked = false; variables.tor_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SRE>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_SRE_Z.Checked = true; variables.sre_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_SRE_Z.Checked = false; variables.sre_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    
                    else if (received_data.Contains("<CET>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_CET_Z.Checked = true; variables.cet_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_CET_Z.Checked = false; variables.cet_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<PET>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_PET_Z.Checked = true; variables.pet_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_PET_Z.Checked = false; variables.pet_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SOB>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_SOB_Z.Checked = true; variables.sob_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_SOB_Z.Checked = false; variables.sob_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<NED>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_NED_Z.Checked = true; variables.ned_zelenica = true; }
                        else if (tokens[1] == "OFF") { checkBox_NED_Z.Checked = false; variables.ned_zelenica = false; }


                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN1Z>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_interval1_z.Checked = true; variables.int1_zel = true; }
                        else if (tokens[1] == "OFF") { checkBox_interval1_z.Checked = false; variables.int1_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN2Z>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_interval2_z.Checked = true; variables.int2_zel = true; }
                        else if (tokens[1] == "OFF") { checkBox_interval2_z.Checked = false; variables.int2_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN3Z>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_interval3_z.Checked = true; variables.int3_zel = true; }
                        else if (tokens[1] == "OFF") { checkBox_interval3_z.Checked = false; variables.int3_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN4Z>") == true)
                    {
                        string myString = received_data;
                        //MessageBox.Show(received_data);
                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_interval4_z.Checked = true; variables.int4_zel = true; }
                        else if (tokens[1] == "OFF") { checkBox_interval4_z.Checked = false; variables.int4_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("ZE_T5>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.D_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.D_OD_H = (tokens[1]);

                        }


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


                    else if (received_data.Contains("OK") == true)
                    {
                        //MessageBox.Show("Nastavitve so shranjene");
                    }

                    else if (received_data.Contains("FAIL") == true)
                    {
                        MessageBox.Show("Napaka v komunikaciji");
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

        private void iPKontrolerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            config fconfig = new config();
            fconfig.ShowDialog();
            //this.Close();
        }

        private void btn_preberi_zel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            disableButtons();
            zel_int1_odH_check();
            zel_int1_odM_check();
            zel_int1_doH_check();
            zel_int1_doM_check();
            zel_int2_odH_check();
            zel_int2_odM_check();
            zel_int2_doH_check();
            zel_int2_doM_check();
            zel_int3_odH_check();
            zel_int3_odM_check();
            zel_int3_doH_check();
            zel_int3_doM_check();
            zel_int4_odH_check();
            zel_int4_odM_check();
            zel_int4_doH_check();
            zel_int4_doM_check();
            zel_pon_check();
            zel_tor_check();
            zel_sre_check();
            zel_cet_check();
            zel_pet_check();
            zel_sob_check();
            zel_ned_check();
            zel_int1_check();
            zel_int2_check();
            zel_int3_check();
            zel_int4_check();
            excludet_date_1_check();
            excludet_date_2_check();
            excludet_date_3_check();
            excludet_date_4_check();
            excludet_date_5_check();
            excludet_date_6_check();
            excludet_date_7_check();

            

            //Interval 1 zelenica
            string P_OD_H = variables.P_OD_H;
            string P_OD_M = variables.P_OD_M;
            string P_DO_H = variables.P_DO_H;
            string P_DO_M = variables.P_DO_M;


            //Interval 2 zelenica
            string D_OD_H = variables.D_OD_H;
            string D_OD_M = variables.D_OD_M;
            string D_DO_H = variables.D_DO_H;
            string D_DO_M = variables.D_DO_M;

            //Interval 3 zelenica
            string T_OD_H = variables.T_OD_H;
            string T_OD_M = variables.T_OD_M;
            string T_DO_H = variables.T_DO_H;
            string T_DO_M = variables.T_DO_M;

            //Interval 4 zelenica
            string S_OD_H = variables.S_OD_H;
            string S_OD_M = variables.S_OD_M;
            string S_DO_H = variables.S_DO_H;
            string S_DO_M = variables.S_DO_M;


            comboBox1_OD_H.Text = P_OD_H;
            comboBox1_OD_M.Text = P_OD_M;
            comboBox1_DO_H.Text = P_DO_H;
            comboBox1_DO_M.Text = P_DO_M;

            comboBox2_OD_H.Text = D_OD_H;
            comboBox2_OD_M.Text = D_OD_M;
            comboBox2_DO_H.Text = D_DO_H;
            comboBox2_DO_M.Text = D_DO_M;

            comboBox3_OD_H.Text = T_OD_H;
            comboBox3_OD_M.Text = T_OD_M;
            comboBox3_DO_H.Text = T_DO_H;
            comboBox3_DO_M.Text = T_DO_M;

            comboBox4_OD_H.Text = S_OD_H;
            comboBox4_OD_M.Text = S_OD_M;
            comboBox4_DO_H.Text = S_DO_H;
            comboBox4_DO_M.Text = S_DO_M;

            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;
            Application.DoEvents();
            enableButtons();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Osveženo");
        }

        private void upravljalnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
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

        private void save_date_btn_Click(object sender, EventArgs e)
        {
            
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

        }

        private void remove_date_btn_Click(object sender, EventArgs e)
        {
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
        }

        private void intervaliVentilovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veje_sett home = new Veje_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veje_sett home = new Veje_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        public void Sum_interval1_time_FUNC()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            //string formattedTimespan = duration.ToString("hh\\:mm");

            Sum_interval1_time.Text = Convert.ToString(duration.ToString("hh\\:mm"));
        }
        public void Sum_interval2_time_FUNC()
        {
            string startTime = variables.D_OD_H + ": " + variables.D_OD_M;
            string endTime = variables.D_DO_H + ": " + variables.D_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval2_time.Text = Convert.ToString(duration.ToString("hh\\:mm"));
        }
        public void Sum_interval3_time_FUNC()
        {
            string startTime = variables.T_OD_H + ": " + variables.T_OD_M;
            string endTime = variables.T_DO_H + ": " + variables.T_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval3_time.Text = Convert.ToString(duration.ToString("hh\\:mm"));
        }
        public void Sum_interval4_time_FUNC()
        {
            string startTime = variables.S_OD_H + ": " + variables.S_OD_M;
            string endTime = variables.S_DO_H + ": " + variables.S_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval4_time.Text = Convert.ToString(duration.ToString("hh\\:mm"));
        }

        public void Sum1_interval1_time_FUNC()
        {
            string startTime = comboBox1_OD_H.Text + ": " + comboBox1_OD_M.Text;
            string endTime = comboBox1_DO_H.Text + ": " + comboBox1_DO_M.Text;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval1_time.Text = Convert.ToString(duration);
        }
        public void Sum1_interval2_time_FUNC()
        {
            string startTime = comboBox2_OD_H.Text + ": " + comboBox2_OD_M.Text;
            string endTime = comboBox2_DO_H.Text + ": " + comboBox2_DO_M.Text;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval2_time.Text = Convert.ToString(duration);
        }
        public void Sum1_interval3_time_FUNC()
        {
            string startTime = comboBox3_OD_H.Text + ": " + comboBox3_OD_M.Text;
            string endTime = comboBox3_DO_H.Text + ": " + comboBox3_DO_M.Text;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval3_time.Text = Convert.ToString(duration);
        }
        public void Sum1_interval4_time_FUNC()
        {
            string startTime = comboBox4_OD_H.Text + ": " + comboBox4_OD_M.Text;
            string endTime = comboBox4_DO_H.Text + ": " + comboBox4_DO_M.Text;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval4_time.Text = Convert.ToString(duration);
        }


        private void comboBox1_OD_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox1_OD_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox1_DO_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox1_DO_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox2_OD_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox2_OD_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox2_DO_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox2_DO_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox3_OD_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox3_OD_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox3_DO_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox3_DO_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox4_OD_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox4_OD_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox4_DO_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }
        }

        private void comboBox4_DO_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum1_interval1_time_FUNC();
                Sum1_interval2_time_FUNC();
                Sum1_interval3_time_FUNC();
                Sum1_interval4_time_FUNC();
            }

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

        private void živaMejaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sett_kapljicno home = new sett_kapljicno(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void vrtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sett_vrt home = new sett_vrt(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void zAPRIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            priporocljiv_interval_calc();
        }

        public void priporocljiv_interval_calc()
        {
            string sMonth = DateTime.Now.ToString("MM");
            //MessageBox.Show(sMonth);
            switch (Convert.ToInt16(sMonth))
            {
                case 1:
                    pripor_cas_lbl.Text = variables.januar;
                    break;
                case 2:
                    pripor_cas_lbl.Text = variables.februar;
                    break;
                case 3:
                    pripor_cas_lbl.Text = variables.marec;
                    break;
                case 4:
                    pripor_cas_lbl.Text = variables.april;
                    break;
                case 5:
                    pripor_cas_lbl.Text = variables.maj;
                    break;
                case 6:
                    pripor_cas_lbl.Text = variables.junij;
                    break;
                case 7:
                    pripor_cas_lbl.Text = variables.julij;
                    break;
                case 8:
                    pripor_cas_lbl.Text = variables.avgust;
                    break;
                case 9:
                    pripor_cas_lbl.Text = variables.september;
                    break;
                case 10:
                    pripor_cas_lbl.Text = variables.oktober;
                    break;
                case 11:
                    pripor_cas_lbl.Text = variables.november;
                    break;
                case 12:
                    pripor_cas_lbl.Text = variables.december;
                    break;

            }

        }

        private void sett_zelenica_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        public void disableButtons()
        {

            this.save_btn.Enabled = false;
            this.btn_preberi_zel.Enabled = false;
            this.button1.Enabled = false;
            this.save_date_btn.Enabled = false;
            this.remove_date_btn.Enabled = false;

            //this.spremeni_btn.Enabled = false;
            this.button1.Enabled = false;
            this.iPKontrolerjaToolStripMenuItem.Enabled = false;
            //this.živaMejaToolStripMenuItem.Enabled = false;
            //this.vrtToolStripMenuItem.Enabled = false;
           


        }

        public void enableButtons()
        {
            this.save_btn.Enabled = true;
            this.btn_preberi_zel.Enabled = true;
            this.button1.Enabled = true;
            this.save_date_btn.Enabled = true;
            this.remove_date_btn.Enabled = true;
            
            //this.spremeni_btn.Enabled = true;
            this.button1.Enabled = true;
            this.iPKontrolerjaToolStripMenuItem.Enabled = true;
            //this.živaMejaToolStripMenuItem.Enabled = true;
            //this.vrtToolStripMenuItem.Enabled = true;
            
        }
    }
}    

