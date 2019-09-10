using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Namakalni_sistem
{
    public partial class Veje_sett : Form
    {
        public static bool startup = true;

        public Veje_sett()
        {

            variables.form1shown = false;
            InitializeComponent();

            if (variables.ure_shranjene==false)
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
                variables.ure_shranjene = true;
            }
            Check_ventil1_procente();
            Check_ventil2_procente();
            Check_ventil3_procente();
            Check_ventil4_procente();
            Check_ventil5_procente();
            Check_ventil6_procente();
            Check_ventil7_procente();

            calculate_interval1_duration();
            calculate_interval2_duration();
            calculate_interval3_duration();
            calculate_interval4_duration();
                       
            
            Sum_interval1_time_FUNC();
            Sum_interval2_time_FUNC();
            Sum_interval3_time_FUNC();
            Sum_interval4_time_FUNC();

            refresh_intervals_to_slider_and_textBox();
            
            /*Ventil1_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil2_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil3_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil4_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil5_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil6_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil7_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            */
            comboBox1.Text = "100";
            Ventil1_slider.Maximum = 100;
            Ventil2_slider.Maximum = 100;
            Ventil3_slider.Maximum = 100;
            Ventil4_slider.Maximum = 100;
            Ventil5_slider.Maximum = 100;
            //Ventil6_slider.Maximum = 100;
            //Ventil7_slider.Maximum = 100;
            
           /*
                variables.ventil1_interval1 = interval1_v1_sum.Text;
                variables.ventil2_interval1 = interval1_v2_sum.Text;
                variables.ventil3_interval1 = interval1_v3_sum.Text;
                variables.ventil4_interval1 = interval1_v4_sum.Text;
                variables.ventil5_interval1 = interval1_v5_sum.Text;
                variables.ventil6_interval1 = interval1_v6_sum.Text;
                variables.ventil7_interval1 = interval1_v7_sum.Text;

                variables.ventil1_interval2 = interval2_v1_sum.Text;
                variables.ventil2_interval2 = interval2_v2_sum.Text;
                variables.ventil3_interval2 = interval2_v3_sum.Text;
                variables.ventil4_interval2 = interval2_v4_sum.Text;
                variables.ventil5_interval2 = interval2_v5_sum.Text;
                variables.ventil6_interval2 = interval2_v6_sum.Text;
                variables.ventil7_interval2 = interval2_v7_sum.Text;

                variables.ventil1_interval3 = interval3_v1_sum.Text;
                variables.ventil2_interval3 = interval3_v2_sum.Text;
                variables.ventil3_interval3 = interval3_v3_sum.Text;
                variables.ventil4_interval3 = interval3_v4_sum.Text;
                variables.ventil5_interval3 = interval3_v5_sum.Text;
                variables.ventil6_interval3 = interval3_v6_sum.Text;
                variables.ventil7_interval3 = interval3_v7_sum.Text;

                variables.ventil1_interval4 = interval4_v1_sum.Text;
                variables.ventil2_interval4 = interval4_v2_sum.Text;
                variables.ventil3_interval4 = interval4_v3_sum.Text;
                variables.ventil4_interval4 = interval4_v4_sum.Text;
                variables.ventil5_interval4 = interval4_v5_sum.Text;
                variables.ventil6_interval4 = interval4_v6_sum.Text;
                variables.ventil7_interval4 = interval4_v7_sum.Text;*/
                //Pošlji kontrolerju intervale ventilov

            int a = 1;
            while ((ventil1_slider_label.Text == "00") && a <= 3)
            {
                
                Check_ventil1_procente();
                
                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                a = a + 1;
                if (a >= 8)
                {
                    //MessageBox.Show("Delež 1. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }
            int b = 1;
            while ((ventil2_slider_label.Text == "00") && b <= 3)
            {

                Check_ventil2_procente();

                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                b = b + 1;
                if (b >= 8)
                {
                    //MessageBox.Show("Delež 2. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }
            int c = 1;
            while ((ventil3_slider_label.Text == "00") && c <= 3)
            {

                Check_ventil3_procente();

                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                c = c + 1;
                if (c >= 8)
                {
                    //MessageBox.Show("Delež 3. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }
            int d = 1;
            while ((ventil4_slider_label.Text == "00") && d <= 3)
            {

                Check_ventil4_procente();

                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                d = d + 1;
                if (d >= 8)
                {
                    //MessageBox.Show("Delež 4. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }
            int e = 1;
            while ((ventil5_slider_label.Text == "00") && e <= 3)
            {

                Check_ventil5_procente();

                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                e = e + 1;
                if (e >= 8)
                {
                    //MessageBox.Show("Delež 5. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }
            /*int f = 1;
            while ((ventil6_slider_label.Text == "00") && f <= 3)
            {

                Check_ventil6_procente();

                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                f = f + 1;
                if (f >= 8)
                {
                    //MessageBox.Show("Delež 6. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }
            int g = 1;
            while ((ventil7_slider_label.Text == "00") && g <= 3)
            {

                Check_ventil7_procente();

                calculate_interval1_duration();
                calculate_interval2_duration();
                calculate_interval3_duration();
                calculate_interval4_duration();


                Sum_interval1_time_FUNC();
                Sum_interval2_time_FUNC();
                Sum_interval3_time_FUNC();
                Sum_interval4_time_FUNC();

                refresh_intervals_to_slider_and_textBox();
                g = g + 1;
                if (g >= 8)
                {
                    //MessageBox.Show("Delež 7. veje je 0 ali povezava z kontrolerjem ni vzpostavljena!");
                    break;
                }
            }*/
            



            if (variables.samodejno_shrenjevanje_novih_intervalov)
            {
                Send_ventil1_interval1();
                Send_ventil2_interval1();
                Send_ventil3_interval1();
                Send_ventil4_interval1();
                Send_ventil5_interval1();
                Send_ventil6_interval1();
                Send_ventil7_interval1();


                Send_ventil1_interval2();
                Send_ventil2_interval2();
                Send_ventil3_interval2();
                Send_ventil4_interval2();
                Send_ventil5_interval2();
                Send_ventil6_interval2();
                Send_ventil7_interval2();

                Send_ventil1_interval3();
                Send_ventil2_interval3();
                Send_ventil3_interval3();
                Send_ventil4_interval3();
                Send_ventil5_interval3();
                Send_ventil6_interval3();
                Send_ventil7_interval3();

                Send_ventil1_interval4();
                Send_ventil2_interval4();
                Send_ventil3_interval4();
                Send_ventil4_interval4();
                Send_ventil5_interval4();
                Send_ventil6_interval4();
                Send_ventil7_interval4();

                variables.samodejno_shrenjevanje_novih_intervalov = false;
            }
            Cursor.Current = Cursors.Default;
            startup = false;
        }

        public bool calculated1 = false;
        public bool calculated2 = false;
        public bool calculated3 = false;
        public bool calculated4 = false;

        private void začetnaStranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void iPKontrolerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            config fconfig = new config();
            fconfig.ShowDialog();
            this.Hide();
            //this.Close();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) <= 99)
            {
                MessageBox.Show("Skupna vrednost intervalov je manjša od 100%");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                variables.ventil1_interval1 = interval1_v1_sum.Text;
                variables.ventil2_interval1 = interval1_v2_sum.Text;
                variables.ventil3_interval1 = interval1_v3_sum.Text;
                variables.ventil4_interval1 = interval1_v4_sum.Text;
                variables.ventil5_interval1 = interval1_v5_sum.Text;
                //variables.ventil6_interval1 = interval1_v6_sum.Text;
                //variables.ventil7_interval1 = interval1_v7_sum.Text;

                variables.ventil1_interval2 = interval2_v1_sum.Text;
                variables.ventil2_interval2 = interval2_v2_sum.Text;
                variables.ventil3_interval2 = interval2_v3_sum.Text;
                variables.ventil4_interval2 = interval2_v4_sum.Text;
                variables.ventil5_interval2 = interval2_v5_sum.Text;
                //variables.ventil6_interval2 = interval2_v6_sum.Text;
                //variables.ventil7_interval2 = interval2_v7_sum.Text;

                variables.ventil1_interval3 = interval3_v1_sum.Text;
                variables.ventil2_interval3 = interval3_v2_sum.Text;
                variables.ventil3_interval3 = interval3_v3_sum.Text;
                variables.ventil4_interval3 = interval3_v4_sum.Text;
                variables.ventil5_interval3 = interval3_v5_sum.Text;
                //variables.ventil6_interval3 = interval3_v6_sum.Text;
                //variables.ventil7_interval3 = interval3_v7_sum.Text;

                variables.ventil1_interval4 = interval4_v1_sum.Text;
                variables.ventil2_interval4 = interval4_v2_sum.Text;
                variables.ventil3_interval4 = interval4_v3_sum.Text;
                variables.ventil4_interval4 = interval4_v4_sum.Text;
                variables.ventil5_interval4 = interval4_v5_sum.Text;
                //variables.ventil6_interval4 = interval4_v6_sum.Text;
                //variables.ventil7_interval4 = interval4_v7_sum.Text;
                //Pošlji kontrolerju intervale ventilov

                Send_ventil1_interval1();
                Send_ventil2_interval1();
                Send_ventil3_interval1();
                Send_ventil4_interval1();
                Send_ventil5_interval1();
                //Send_ventil6_interval1();
                //Send_ventil7_interval1();


                Send_ventil1_interval2();
                Send_ventil2_interval2();
                Send_ventil3_interval2();
                Send_ventil4_interval2();
                Send_ventil5_interval2();
                //Send_ventil6_interval2();
                //Send_ventil7_interval2();

                Send_ventil1_interval3();
                Send_ventil2_interval3();
                Send_ventil3_interval3();
                Send_ventil4_interval3();
                Send_ventil5_interval3();
                //Send_ventil6_interval3();
                //Send_ventil7_interval3();

                Send_ventil1_interval4();
                Send_ventil2_interval4();
                Send_ventil3_interval4();
                Send_ventil4_interval4();
                Send_ventil5_interval4();
                //Send_ventil6_interval4();
                //Send_ventil7_interval4();

                send_ventil1_interval_procenti();
                send_ventil2_interval_procenti();
                send_ventil3_interval_procenti();
                send_ventil4_interval_procenti();
                send_ventil5_interval_procenti();
                //send_ventil6_interval_procenti();
                //send_ventil7_interval_procenti();
                send_check_signal();
               
                Form1 home = new Form1(); // Instantiate a Form3 object.
                home.Show(); // Show Form3 and
                this.Hide();
                //MessageBox.Show("Poslano");
                //MessageBox.Show("Nastavitve so shranjene");
                
            }
        }
            




        

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            Check_ventil1_procente();
            Check_ventil2_procente();
            Check_ventil3_procente();
            Check_ventil4_procente();
            Check_ventil5_procente();
            //Check_ventil6_procente();
            //Check_ventil7_procente();

            calculate_interval1_duration();
            calculate_interval2_duration();
            calculate_interval3_duration();
            calculate_interval4_duration();

            Sum_interval1_time_FUNC();
            Sum_interval2_time_FUNC();
            Sum_interval3_time_FUNC();
            Sum_interval4_time_FUNC();


            Ventil1_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil2_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil3_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil4_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            Ventil5_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            //Ventil6_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            //Ventil7_slider.Maximum = Convert.ToInt32(comboBox1.Text);

            refresh_intervals_to_slider_and_textBox();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Osveženo");
        }

        public void UDPListener()
        {


            bool done = false;
            variables.udpfree11002 = false;


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
                    else if (received_data.Contains("<ZE_T10>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //MessageBox.Show(tokens[1]);
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
                    //interval1 sprinklerja 1
                    else if (received_data.Contains("<INTV1ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil1_interval1 = tokens[1];


                    }

                        //interval1 sprinklerja 2
                    else if (received_data.Contains("<INTV2ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil2_interval1 = tokens[1];


                    }
                    //interval sprinklerja 3
                    else if (received_data.Contains("<INTV3ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil3_interval1 = tokens[1];


                    }

                        //interval sprinklerja 4
                    else if (received_data.Contains("<INTV4ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil4_interval1 = tokens[1];


                    }

                    //interval sprinklerja 5
                    else if (received_data.Contains("<INTV5ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil5_interval1 = tokens[1];


                    }

                    //interval sprinklerja 6
                    else if (received_data.Contains("<INTV6ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil6_interval1 = tokens[1];


                    }

                    //interval sprinklerja 7
                    else if (received_data.Contains("<INTV7ch1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil7_interval1 = tokens[1];


                    }


                    //interval1 sprinklerja 1
                    else if (received_data.Contains("<INTV1ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil1_interval2 = tokens[1];


                    }

                        //interval1 sprinklerja 2
                    else if (received_data.Contains("<INTV2ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil2_interval2 = tokens[1];


                    }
                    //interval sprinklerja 3
                    else if (received_data.Contains("<INTV3ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil3_interval2 = tokens[1];


                    }

                        //interval sprinklerja 4
                    else if (received_data.Contains("<INTV4ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil4_interval2 = tokens[1];


                    }

                    //interval sprinklerja 5
                    else if (received_data.Contains("<INTV5ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil5_interval2 = tokens[1];


                    }

                    //interval sprinklerja 6
                    else if (received_data.Contains("<INTV6ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil6_interval2 = tokens[1];


                    }

                    //interval sprinklerja 7
                    else if (received_data.Contains("<INTV7ch2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil7_interval2 = tokens[1];


                    }

                        //interval1 sprinklerja 1
                    else if (received_data.Contains("<INTV1ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil1_interval3 = tokens[1];


                    }

                        //interval1 sprinklerja 2
                    else if (received_data.Contains("<INTV2ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil2_interval3 = tokens[1];


                    }
                    //interval sprinklerja 3
                    else if (received_data.Contains("<INTV3ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil3_interval3 = tokens[1];


                    }

                        //interval sprinklerja 4
                    else if (received_data.Contains("<INTV4ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil4_interval3 = tokens[1];


                    }

                    //interval sprinklerja 5
                    else if (received_data.Contains("<INTV5ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil5_interval3 = tokens[1];


                    }

                    //interval sprinklerja 6
                    else if (received_data.Contains("<INTV6ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil6_interval3 = tokens[1];


                    }

                    //interval sprinklerja 7
                    else if (received_data.Contains("<INTV7ch3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil7_interval3 = tokens[1];


                    }

                             //interval1 sprinklerja 1
                    else if (received_data.Contains("<INTV1ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil1_interval4 = tokens[1];


                    }

                        //interval1 sprinklerja 2
                    else if (received_data.Contains("<INTV2ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil2_interval4 = tokens[1];


                    }
                    //interval sprinklerja 3
                    else if (received_data.Contains("<INTV3ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil3_interval4 = tokens[1];


                    }

                        //interval sprinklerja 4
                    else if (received_data.Contains("<INTV4ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil4_interval4 = tokens[1];


                    }

                    //interval sprinklerja 5
                    else if (received_data.Contains("<INTV5ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil5_interval4 = tokens[1];


                    }

                    //interval sprinklerja 6
                    else if (received_data.Contains("<INTV6ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil6_interval4 = tokens[1];


                    }

                    //interval sprinklerja 7
                    else if (received_data.Contains("<INTV7ch4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil7_interval4 = tokens[1];


                    }

                    //Kontroler pošilja procente intervalov
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V1pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil1_interval_procenti = tokens[1];

                    }
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V2pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil2_interval_procenti = tokens[1];

                    }
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V3pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil3_interval_procenti = tokens[1];

                    }
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V4pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil4_interval_procenti = tokens[1];

                    }
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V5pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil5_interval_procenti = tokens[1];

                    }
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V6pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil6_interval_procenti = tokens[1];

                    }
                    //interval sprinklerja 1
                    else if (received_data.Contains("<V7pr>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);

                        variables.ventil7_interval_procenti = tokens[1];

                    }


                    else if (received_data.Contains("OK") == true)
                    {
                        //MessageBox.Show("Nastavitve so shranjene");
                    }

                    else
                    {
                        MessageBox.Show(received_data);
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
                variables.udpfree11002 = false;
            }
        }
        
        private void Ventil1_slider_Scroll(object sender, EventArgs e)
        {
            if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
            {
                Ventil1_slider.Value = 100 - (Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
            }
            //string label = ToString(Ventil1_slider.Value);
            ventil1_slider_label.Text = Convert.ToString(Ventil1_slider.Value);
            variables.ventil1_interval_procenti = Convert.ToString(Ventil1_slider.Value);
            calculate_interval1_duration();
            
            calculate_interval2_duration();
            
            calculate_interval3_duration();
            
            calculate_interval4_duration();

            SUM_slider_label.Text =Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);

           
        }
        private void Ventil2_slider_Scroll(object sender, EventArgs e)
        {
            if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
            {
                Ventil2_slider.Value = 100 - (Ventil1_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
            }
            

            ventil2_slider_label.Text = Convert.ToString(Ventil2_slider.Value);
            variables.ventil2_interval_procenti = Convert.ToString(Ventil2_slider.Value);
            
            calculate_interval1_duration();
            
            calculate_interval2_duration();
            
            calculate_interval3_duration();
            
            calculate_interval4_duration();
            SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
        }
        private void Ventil3_slider_Scroll(object sender, EventArgs e)
        {
            if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
            {
                Ventil3_slider.Value = 100 - (Ventil2_slider.Value + Ventil1_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
            }
            ventil3_slider_label.Text = Convert.ToString(Ventil3_slider.Value);
            variables.ventil3_interval_procenti = Convert.ToString(Ventil3_slider.Value);
            calculated1 = false;
            calculate_interval1_duration();
            calculated2 = false;
            calculate_interval2_duration();
            calculated3 = false;
            calculate_interval3_duration();
            calculated4 = false;
            calculate_interval4_duration();
            SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
        }
        private void Ventil4_slider_Scroll(object sender, EventArgs e)
        {
            if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
            {
                Ventil4_slider.Value = 100 - (Ventil2_slider.Value + Ventil3_slider.Value + Ventil1_slider.Value + Ventil5_slider.Value);
            }
            ventil4_slider_label.Text = Convert.ToString(Ventil4_slider.Value);
            variables.ventil4_interval_procenti = Convert.ToString(Ventil4_slider.Value);
            calculated1 = false;
            calculate_interval1_duration();
            calculated2 = false;
            calculate_interval2_duration();
            calculated3 = false;
            calculate_interval3_duration();
            calculated4 = false;
            calculate_interval4_duration();
            SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
        }
        private void Ventil5_slider_Scroll(object sender, EventArgs e)
        {
            if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
            {
                Ventil5_slider.Value = 100 - (Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil1_slider.Value);
            }
            ventil5_slider_label.Text = Convert.ToString(Ventil5_slider.Value);
            variables.ventil5_interval_procenti = Convert.ToString(Ventil5_slider.Value);
            calculated1 = false;
            calculate_interval1_duration();
            calculated2 = false;
            calculate_interval2_duration();
            calculated3 = false;
            calculate_interval3_duration();
            calculated4 = false;
            calculate_interval4_duration();
            SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
        }
        /*
         private void Ventil6_slider_Scroll(object sender, EventArgs e)
         {
             if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
             {
                 Ventil6_slider.Value = 100 - (Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value + Ventil1_slider.Value + Ventil7_slider.Value);
             }
             ventil6_slider_label.Text = Convert.ToString(Ventil6_slider.Value);
             variables.ventil6_interval_procenti = Convert.ToString(Ventil6_slider.Value);
             calculated1 = false;
             calculate_interval1_duration();
             calculated2 = false;
             calculate_interval2_duration();
             calculated3 = false;
             calculate_interval3_duration();
             calculated4 = false;
             calculate_interval4_duration();
             SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
         }
         private void Ventil7_slider_Scroll(object sender, EventArgs e)
         {
             if ((Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value) >= 101)
             {
                 Ventil7_slider.Value = 100 - (Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value + Ventil6_slider.Value + Ventil1_slider.Value);
             }
             ventil7_slider_label.Text = Convert.ToString(Ventil7_slider.Value);
             variables.ventil7_interval_procenti = Convert.ToString(Ventil7_slider.Value);
             calculated1 = false;
             calculate_interval1_duration();
             calculated2 = false;
             calculate_interval2_duration();
             calculated3 = false;
             calculate_interval3_duration();
             calculated4 = false;
             calculate_interval4_duration();
             SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
         }
       
         */

        //Pošlji kontrolerju nastavljene vrednosti za vsak interval - iz sliderjev
        private void Send_ventil1_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V1>" + variables.ventil1_interval1);

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
        private void Send_ventil2_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V2>" + variables.ventil2_interval1);

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
        private void Send_ventil3_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V3>" + variables.ventil3_interval1);

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
        private void Send_ventil4_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V4>" + variables.ventil4_interval1);

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
        private void Send_ventil5_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V5>" + variables.ventil5_interval1);

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
        private void Send_ventil6_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V6>" + variables.ventil6_interval1);

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
        private void Send_ventil7_interval1()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT1V7>" + variables.ventil7_interval1);

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


        private void Send_ventil1_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V1>" + variables.ventil1_interval2);

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
        private void Send_ventil2_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V2>" + variables.ventil2_interval2);

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
        private void Send_ventil3_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V3>" + variables.ventil3_interval2);

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
        private void Send_ventil4_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V4>" + variables.ventil4_interval2);

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
        private void Send_ventil5_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V5>" + variables.ventil5_interval2);

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
        private void Send_ventil6_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V6>" + variables.ventil6_interval2);

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
        private void Send_ventil7_interval2()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT2V7>" + variables.ventil7_interval2);

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

        private void Send_ventil1_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V1>" + variables.ventil1_interval3);

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
        private void Send_ventil2_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V2>" + variables.ventil2_interval3);

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
        private void Send_ventil3_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V3>" + variables.ventil3_interval3);

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
        private void Send_ventil4_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V4>" + variables.ventil4_interval3);

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
        private void Send_ventil5_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V5>" + variables.ventil5_interval3);

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
        private void Send_ventil6_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V6>" + variables.ventil6_interval3);

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
        private void Send_ventil7_interval3()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT3V7>" + variables.ventil7_interval3);

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

        private void Send_ventil1_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V1>" + variables.ventil1_interval4);

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
        private void Send_ventil2_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V2>" + variables.ventil2_interval4);

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
        private void Send_ventil3_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V3>" + variables.ventil3_interval4);

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
        private void Send_ventil4_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V4>" + variables.ventil4_interval4);

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
        private void Send_ventil5_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V5>" + variables.ventil5_interval4);

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
        private void Send_ventil6_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V6>" + variables.ventil6_interval4);

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
        private void Send_ventil7_interval4()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INT4V7>" + variables.ventil7_interval4);

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

        //Preveri nastavljene intervale ventilov iz kontrolerja

        private void Check_ventil1_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV1ch1>");

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
        private void Check_ventil2_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV2ch1>");

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
        private void Check_ventil3_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV3ch1>");

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
        private void Check_ventil4_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV4ch1>");

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
        private void Check_ventil5_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV5ch1>");

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
        private void Check_ventil6_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV6ch1>");

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
        private void Check_ventil7_interval1()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV7ch1>");

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
      

        private void Check_ventil1_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV1ch2>");

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
        private void Check_ventil2_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV2ch2>");

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
        private void Check_ventil3_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV3ch2>");

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
        private void Check_ventil4_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV4ch2>");

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
        private void Check_ventil5_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV5ch2>");

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
        private void Check_ventil6_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV6ch2>");

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
        private void Check_ventil7_interval2()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV7ch2>");

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

        private void Check_ventil1_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV1ch3>");

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
        private void Check_ventil2_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV2ch3>");

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
        private void Check_ventil3_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV3ch3>");

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
        private void Check_ventil4_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV4ch3>");

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
        private void Check_ventil5_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV5ch3>");

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
        private void Check_ventil6_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV6ch3>");

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
        private void Check_ventil7_interval3()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV7ch3>");

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

        private void Check_ventil1_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV1ch4>");

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
        private void Check_ventil2_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV2ch4>");

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
        private void Check_ventil3_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV3ch4>");

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
        private void Check_ventil4_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV4ch4>");

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
        private void Check_ventil5_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV5ch4>");

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
        private void Check_ventil6_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV6ch4>");

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
        private void Check_ventil7_interval4()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTV7ch4>");

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

        
        public void Sum_interval1_time_FUNC()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval1_time.Text = Convert.ToString(duration);
        }
        public void Sum_interval2_time_FUNC()
        {
            string startTime = variables.D_OD_H + ": " + variables.D_OD_M;
            string endTime = variables.D_DO_H + ": " + variables.D_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval2_time.Text = Convert.ToString(duration);
        }
        public void Sum_interval3_time_FUNC()
        {
            string startTime = variables.T_OD_H + ": " + variables.T_OD_M;
            string endTime = variables.T_DO_H + ": " + variables.T_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval3_time.Text = Convert.ToString(duration);
        }
        public void Sum_interval4_time_FUNC()
        {
            string startTime = variables.S_OD_H + ": " + variables.S_OD_M;
            string endTime = variables.S_DO_H + ": " + variables.S_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval4_time.Text = Convert.ToString(duration);
        }

        

        private void refresh_intervals_to_slider_and_textBox()
        {
            
            ventil1_slider_label.Text = variables.ventil1_interval_procenti;
            ventil2_slider_label.Text = variables.ventil2_interval_procenti;
            ventil3_slider_label.Text = variables.ventil3_interval_procenti;
            ventil4_slider_label.Text = variables.ventil4_interval_procenti;
            ventil5_slider_label.Text = variables.ventil5_interval_procenti;
            //ventil6_slider_label.Text = variables.ventil6_interval_procenti;
            //ventil7_slider_label.Text = variables.ventil7_interval_procenti;

            Ventil1_slider.Value = Convert.ToInt16(variables.ventil1_interval_procenti);
            Ventil2_slider.Value = Convert.ToInt16(variables.ventil2_interval_procenti);
            Ventil3_slider.Value = Convert.ToInt16(variables.ventil3_interval_procenti);
            Ventil4_slider.Value = Convert.ToInt16(variables.ventil4_interval_procenti);
            Ventil5_slider.Value = Convert.ToInt16(variables.ventil5_interval_procenti);
            //Ventil6_slider.Value = Convert.ToInt16(variables.ventil6_interval_procenti);
            //Ventil7_slider.Value = Convert.ToInt16(variables.ventil7_interval_procenti);

            SUM_slider_label.Text = Convert.ToString(Ventil1_slider.Value + Ventil2_slider.Value + Ventil3_slider.Value + Ventil4_slider.Value + Ventil5_slider.Value);
           
        }

        public void calculate_interval1_duration()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);

            int calculated1 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil1_interval_procenti));
            int calculated2 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil2_interval_procenti));
            int calculated3 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil3_interval_procenti));
            int calculated4 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil4_interval_procenti));
            int calculated5 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil5_interval_procenti));
            int calculated6 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil6_interval_procenti));
            int calculated7 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil7_interval_procenti));
            

             
            interval1_v1_sum.Text = Convert.ToString(calculated1);
            interval1_v2_sum.Text = Convert.ToString(calculated2);
            interval1_v3_sum.Text = Convert.ToString(calculated3);
            interval1_v4_sum.Text = Convert.ToString(calculated4);
            interval1_v5_sum.Text = Convert.ToString(calculated5);
            //interval1_v6_sum.Text = Convert.ToString(calculated6);
            //interval1_v7_sum.Text = Convert.ToString(calculated7);

            variables.ventil1_interval1 = Convert.ToString(calculated1);
            variables.ventil2_interval1 = Convert.ToString(calculated2);
            variables.ventil3_interval1 = Convert.ToString(calculated3);
            variables.ventil4_interval1 = Convert.ToString(calculated4);
            variables.ventil5_interval1 = Convert.ToString(calculated5);
            variables.ventil6_interval1 = Convert.ToString(calculated6);
            variables.ventil7_interval1 = Convert.ToString(calculated7);
            

        }
        public void calculate_interval2_duration()
        {
            string startTime = variables.D_OD_H + ": " + variables.D_OD_M;
            string endTime = variables.D_DO_H + ": " + variables.D_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);

            int calculated1 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil1_interval_procenti));
            int calculated2 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil2_interval_procenti));
            int calculated3 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil3_interval_procenti));
            int calculated4 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil4_interval_procenti));
            int calculated5 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil5_interval_procenti));
            int calculated6 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil6_interval_procenti));
            int calculated7 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil7_interval_procenti));



            interval2_v1_sum.Text = Convert.ToString(calculated1);
            interval2_v2_sum.Text = Convert.ToString(calculated2);
            interval2_v3_sum.Text = Convert.ToString(calculated3);
            interval2_v4_sum.Text = Convert.ToString(calculated4);
            interval2_v5_sum.Text = Convert.ToString(calculated5);
            //interval2_v6_sum.Text = Convert.ToString(calculated6);
            //interval2_v7_sum.Text = Convert.ToString(calculated7);

            variables.ventil1_interval2 = Convert.ToString(calculated1);
            variables.ventil2_interval2 = Convert.ToString(calculated2);
            variables.ventil3_interval2 = Convert.ToString(calculated3);
            variables.ventil4_interval2 = Convert.ToString(calculated4);
            variables.ventil5_interval2 = Convert.ToString(calculated5);
            variables.ventil6_interval2 = Convert.ToString(calculated6);
            variables.ventil7_interval2 = Convert.ToString(calculated7);
        }
        public void calculate_interval3_duration()
        {
            string startTime = variables.T_OD_H + ": " + variables.T_OD_M;
            string endTime = variables.T_DO_H + ": " + variables.T_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);

            int calculated1 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil1_interval_procenti));
            int calculated2 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil2_interval_procenti));
            int calculated3 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil3_interval_procenti));
            int calculated4 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil4_interval_procenti));
            int calculated5 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil5_interval_procenti));
            int calculated6 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil6_interval_procenti));
            int calculated7 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil7_interval_procenti));



            interval3_v1_sum.Text = Convert.ToString(calculated1);
            interval3_v2_sum.Text = Convert.ToString(calculated2);
            interval3_v3_sum.Text = Convert.ToString(calculated3);
            interval3_v4_sum.Text = Convert.ToString(calculated4);
            interval3_v5_sum.Text = Convert.ToString(calculated5);
            //interval3_v6_sum.Text = Convert.ToString(calculated6);
            //interval3_v7_sum.Text = Convert.ToString(calculated7);

            variables.ventil1_interval3 = Convert.ToString(calculated1);
            variables.ventil2_interval3 = Convert.ToString(calculated2);
            variables.ventil3_interval3 = Convert.ToString(calculated3);
            variables.ventil4_interval3 = Convert.ToString(calculated4);
            variables.ventil5_interval3 = Convert.ToString(calculated5);
            variables.ventil6_interval3 = Convert.ToString(calculated6);
            variables.ventil7_interval3 = Convert.ToString(calculated7);
        }
        public void calculate_interval4_duration()
        {
            string startTime = variables.S_OD_H + ": " + variables.S_OD_M;
            string endTime = variables.S_DO_H + ": " + variables.S_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);

            int calculated1 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil1_interval_procenti));
            int calculated2 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil2_interval_procenti));
            int calculated3 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil3_interval_procenti));
            int calculated4 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil4_interval_procenti));
            int calculated5 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil5_interval_procenti));
            int calculated6 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil6_interval_procenti));
            int calculated7 = Convert.ToInt32((totalMinutes / 100) * Convert.ToDouble(variables.ventil7_interval_procenti));



            interval4_v1_sum.Text = Convert.ToString(calculated1);
            interval4_v2_sum.Text = Convert.ToString(calculated2);
            interval4_v3_sum.Text = Convert.ToString(calculated3);
            interval4_v4_sum.Text = Convert.ToString(calculated4);
            interval4_v5_sum.Text = Convert.ToString(calculated5);
            //interval4_v6_sum.Text = Convert.ToString(calculated6);
            //interval4_v7_sum.Text = Convert.ToString(calculated7);

            variables.ventil1_interval4 = Convert.ToString(calculated1);
            variables.ventil2_interval4 = Convert.ToString(calculated2);
            variables.ventil3_interval4 = Convert.ToString(calculated3);
            variables.ventil4_interval4 = Convert.ToString(calculated4);
            variables.ventil5_interval4 = Convert.ToString(calculated5);
            variables.ventil6_interval4 = Convert.ToString(calculated6);
            variables.ventil7_interval4 = Convert.ToString(calculated7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veja1_photo home = new Veja1_photo();
            home.Show();
            //this.Hide();
        }

        public void calculate_ventil1_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100-(((totalMinutes - Convert.ToDouble(variables.ventil1_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil1_interval_procenti = Convert.ToString(per);
            
            

        }
        public void calculate_ventil2_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100 - (((totalMinutes - Convert.ToDouble(variables.ventil2_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil2_interval_procenti = Convert.ToString(per);

            

        }
        public void calculate_ventil3_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100 - (((totalMinutes - Convert.ToDouble(variables.ventil3_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil3_interval_procenti = Convert.ToString(per);

            

        }
        public void calculate_ventil4_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100 - (((totalMinutes - Convert.ToDouble(variables.ventil4_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil4_interval_procenti = Convert.ToString(per);

            

        }
        public void calculate_ventil5_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100 - (((totalMinutes - Convert.ToDouble(variables.ventil5_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil5_interval_procenti = Convert.ToString(per);

            

        }
        public void calculate_ventil6_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100 - (((totalMinutes - Convert.ToDouble(variables.ventil6_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil6_interval_procenti = Convert.ToString(per);

            

        }
        public void calculate_ventil7_procente()
        {
            string startTime = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime = variables.P_DO_H + ": " + variables.P_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            double totalMinutes = (duration.TotalMinutes);


            double percentage = 100 - (((totalMinutes - Convert.ToDouble(variables.ventil7_interval1)) / totalMinutes) * 100);
            int per = Convert.ToInt16(percentage);
            variables.ventil7_interval_procenti = Convert.ToString(per);

            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Ventil1_slider.Maximum = Convert.ToInt32(comboBox1.Text);
                Ventil2_slider.Maximum = Convert.ToInt32(comboBox1.Text);
                Ventil3_slider.Maximum = Convert.ToInt32(comboBox1.Text);
                Ventil4_slider.Maximum = Convert.ToInt32(comboBox1.Text);
                Ventil5_slider.Maximum = Convert.ToInt32(comboBox1.Text);
                //Ventil6_slider.Maximum = Convert.ToInt32(comboBox1.Text);
                //Ventil7_slider.Maximum = Convert.ToInt32(comboBox1.Text);
            }
            
           
            
        }

        public void Check_ventil1_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V1%ch>");

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
        public void Check_ventil2_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V2%ch>");

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
        public void Check_ventil3_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V3%ch>");

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
        public void Check_ventil4_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V4%ch>");

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
        public void Check_ventil5_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V5%ch>");

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
        public void Check_ventil6_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V6%ch>");

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
        public void Check_ventil7_procente()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V7%ch>");

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

        //Pošlji intervale ventilov v %
        public void send_ventil1_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V1%>" + variables.ventil1_interval_procenti);

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
        public void send_ventil2_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V2%>" + variables.ventil2_interval_procenti);

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
        public void send_ventil3_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V3%>" + variables.ventil3_interval_procenti);

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
        public void send_ventil4_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V4%>" + variables.ventil4_interval_procenti);

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
        public void send_ventil5_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V5%>" + variables.ventil5_interval_procenti);

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
        public void send_ventil6_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V6%>" + variables.ventil6_interval_procenti);

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
        public void send_ventil7_interval_procenti()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V7%>" + variables.ventil7_interval_procenti);

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

        private void intervaliVentilovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sett_zelenica home = new sett_zelenica(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void živaMejaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sett_kapljicno home = new sett_kapljicno(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
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

        private void button8_Click(object sender, EventArgs e)
        {
            variables.ventil1_interval_procenti = Convert.ToString(6);
            variables.ventil2_interval_procenti = Convert.ToString(20);
            variables.ventil3_interval_procenti = Convert.ToString(30);
            variables.ventil4_interval_procenti = Convert.ToString(30);
            variables.ventil5_interval_procenti = Convert.ToString(14);
            //variables.ventil6_interval_procenti = Convert.ToString(12);
            //variables.ventil7_interval_procenti = Convert.ToString(5);

            
            calculate_interval1_duration();
            calculate_interval2_duration();
            calculate_interval3_duration();
            calculate_interval4_duration();

            Sum_interval1_time_FUNC();
            Sum_interval2_time_FUNC();
            Sum_interval3_time_FUNC();
            Sum_interval4_time_FUNC();

            refresh_intervals_to_slider_and_textBox();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Veja2_photo home = new Veja2_photo();
            home.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Veja3_photo home = new Veja3_photo();
            home.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Veja4_photo home = new Veja4_photo();
            home.Show();
            //this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Veja5_photo home = new Veja5_photo();
            home.Show();
            //this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Veja6_photo home = new Veja6_photo();
            home.Show();
            //this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Veja7_photo home = new Veja7_photo();
            home.Show();
            //this.Hide();
        }

        private void iZHODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Veje_sett_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        

    }
}
