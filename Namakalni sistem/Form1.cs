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

    public partial class Form1 : Form
    {
        public bool noConnection = false;
        public DateTime nextWatteringTimeZelenica = DateTime.Today;
        public DateTime nextWatteringTimeVrt = DateTime.Today;
        public DateTime nextWatteringTimeKapljicno = DateTime.Today;
        public bool interval1 = true;
        public bool interval2, interval3, interval4;
        public Form1()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            system_status_check();
            automatic_status_check();
            system_time_check();
            system_Date_check();
            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();

            

           
            
            int p = 1;
            int a = 1;
            while ((btn_avtomatika.BackColor.ToString() == "Color [Control]" || btn_stop.BackColor.ToString() == "Color [Control]" || btn_rocno.BackColor.ToString() == "Color [Control]") && a <= 2)
            {
                system_status_check();
                system_time_check();
                system_Date_check();
                system_ventil1_status_check();
                system_ventil2_status_check();
                system_ventil3_status_check();
                system_ventil4_status_check();
                system_ventil5_status_check();
                system_ventil6_status_check();
                system_ventil7_status_check();
                system_ventil8_status_check();
                system_ventil9_status_check();
                a = a + 1;
                if (a >= 2)
                {
                    MessageBox.Show("Povezave s kontrolerjem ni mogoče vzpostaviti!");
                    p = 4;
                    noConnection = true;
                    break;
                }
            }

            if (!noConnection)
            {

                while (label4.Text == "label4" && p <= 3)
                {
                    odH_check();
                    odM_check();

                    if (p >= 2)
                    {
                        p = p + 1;
                        break;
                    }
                }
                //Če ni posodobil statusa ponovno zahtevaj status
                int tm = 1;

                while (tm <= 2 && (btn_avtomatika.BackColor.ToString() == "Color [Control]" || btn_stop.BackColor.ToString() == "Color [Control]" || btn_rocno.BackColor.ToString() == "Color [Control]")) { system_status_check(); tm++; }
                tm = 1;
                while (tm <= 2 && (btn_avtomatika.BackColor.ToString() == "Color [IndianRed]" && btn_stop.BackColor.ToString() == "Color [IndianRed]" && btn_rocno.BackColor.ToString() == "Color [IndianRed]")) { system_status_check(); tm++; }
                tm = 1;
                while (tm <= 2 && V1.BackColor.ToString() == "Color [Control]") { system_ventil1_status_check(); tm++; }
                tm = 1;
                while (tm <= 2 && V2.BackColor.ToString() == "Color [Control]") { system_ventil2_status_check(); tm++; }
                tm = 1;
                while (tm <= 2 && V3.BackColor.ToString() == "Color [Control]") { system_ventil3_status_check(); tm++; }
                tm = 1;
                while (tm <= 2 && V4.BackColor.ToString() == "Color [Control]") { system_ventil4_status_check(); tm++; }
                tm = 1;
                while (tm <= 2 && V5.BackColor.ToString() == "Color [Control]") { system_ventil5_status_check(); tm++; }
                tm = 1;
                
                /*while (tm <= 2 && V8.BackColor.ToString() == "Color [Control]") { system_ventil8_status_check(); tm++; }
                tm = 1*/
                
                variables.form1shown = true;

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

                    vrt_int1_odH_check();
                    vrt_int1_odM_check();
                    vrt_int1_doH_check();
                    vrt_int1_doM_check();

                    vrt_pon_check();
                    vrt_tor_check();
                    vrt_sre_check();
                    vrt_cet_check();
                    vrt_pet_check();
                    vrt_sob_check();
                    vrt_ned_check();

                    odH_check();
                    odM_check();

                    vrt_int1_odH_check();
                    vrt_int1_odM_check();
                    vrt_int1_doH_check();
                    vrt_int1_doM_check();

                    kapljicno_int1_odH_check();
                    kapljicno_int1_odM_check();
                    kapljicno_int1_doH_check();
                    kapljicno_int1_doM_check();

                    kapljicno_pon_check();
                    kapljicno_tor_check();
                    kapljicno_sre_check();
                    kapljicno_cet_check();
                    kapljicno_pet_check();
                    kapljicno_sob_check();
                    kapljicno_ned_check();

                    variables.ure_shranjene = true;
                }


                Thread t1 = new Thread(UDP_WakeupSignalFromATMEL_auto);
                t1.IsBackground = true;
                t1.Start();

            }

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

                vrt_int1_odH_check();
                vrt_int1_odM_check();
                vrt_int1_doH_check();
                vrt_int1_doM_check();

                vrt_pon_check();
                vrt_tor_check();
                vrt_sre_check();
                vrt_cet_check();
                vrt_pet_check();
                vrt_sob_check();
                vrt_ned_check();

                odH_check();
                odM_check();

                vrt_int1_odH_check();
                vrt_int1_odM_check();
                vrt_int1_doH_check();
                vrt_int1_doM_check();

                kapljicno_int1_odH_check();
                kapljicno_int1_odM_check();
                kapljicno_int1_doH_check();
                kapljicno_int1_doM_check();

                kapljicno_pon_check();
                kapljicno_tor_check();
                kapljicno_sre_check();
                kapljicno_cet_check();
                kapljicno_pet_check();
                kapljicno_sob_check();
                kapljicno_ned_check();

                

                variables.ure_shranjene = true;
            }







            /*Thread t2 = new Thread(finishTime_calculation);
            t2.IsBackground = true;
            t2.Start();*/
            finishTime_calculation();
            calculate_start_time_vrt();
            calculate_start_time_kapljicno();
            calculate_start_time();
            Cursor.Current = Cursors.Default;
        }





        public void UDP_WakeupSignalFromATMEL_auto()
        {


            while (true)
            {
                if (variables.form1shown == true && variables.udpfree12014 == true)
                {
                    variables.udpfree12014 = false;
                    //MessageBox.Show("not");
                    bool done = false;

                    //UdpClient listener_auto = new UdpClient(12014);

                    UdpClient listener_auto = new UdpClient(12014);
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 12014);
                    string received_data;
                    byte[] receive_byte_array;
                    listener_auto.Client.ReceiveTimeout = 1000; //block waiting for connections
                    /*if (listener_auto.Client.Connected == false)
                    {
                        if (variables.repeat_one_time == 0)
                        {
                            //Izključeno zaradi priklopa direkt na pc
                            //MessageBox.Show("Kontroler ni povezan!");
                            variables.repeat_one_time = 1;
                            variables.controller_connected = false;
                        }
                    }*/




                    try
                    {
                        while (!done)
                        {
                            //MessageBox.Show("Waiting for broadcast");
                            receive_byte_array = listener_auto.Receive(ref groupEP);
                            //MessageBox.Show("Received a broadcast from {0}", groupEP.ToString() );
                            received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                            variables.repeat_one_time = 0;
                            //MessageBox.Show(received_data);

                            if (variables.form1shown == true)
                            {
                                if (received_data.Contains("<A_ST1>") == true)
                                {

                                    btn_avtomatika.BackColor = Color.LightGreen;
                                    btn_rocno.BackColor = Color.IndianRed;
                                    btn_stop.BackColor = Color.IndianRed;
                                    //MessageBox.Show("PREJET AUTO");
                                    /*system_ventil1_status_check();
                                    system_ventil2_status_check();
                                    system_ventil3_status_check();
                                    system_ventil4_status_check();
                                    system_ventil5_status_check();
                                    system_ventil6_status_check();
                                    system_ventil7_status_check();
                                    system_ventil8_status_check();
                                    system_ventil9_status_check();*/



                                }
                                else if (received_data.Contains("<START>") == true)
                                {
                                    system_status_check();
                                    system_Date_check();
                                    system_time_check();
                                    MessageBox.Show("Povezava z kontrolerjem je vzpostavljena!");
                                    system_ventil1_status_check();
                                    system_ventil2_status_check();
                                    system_ventil3_status_check();
                                    system_ventil4_status_check();
                                    system_ventil5_status_check();
                                    system_ventil6_status_check();
                                    system_ventil7_status_check();
                                    system_ventil8_status_check();
                                    system_ventil9_status_check();
                                }

                                else if (received_data.Contains("<M_ST1>") == true)
                                {
                                    btn_avtomatika.BackColor = Color.IndianRed;
                                    btn_rocno.BackColor = Color.LightGreen;
                                    btn_stop.BackColor = Color.IndianRed;
                                    //MessageBox.Show("PREJET MANUAL");
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                   
                                    //V8.BackColor = Color.IndianRed;
                                    
                                }
                                else if (received_data.Contains("<S_ST1>") == true)
                                {
                                    btn_avtomatika.BackColor = Color.IndianRed;
                                    btn_rocno.BackColor = Color.IndianRed;
                                    btn_stop.BackColor = Color.LightGreen;
                                    //MessageBox.Show("PREJET STOP");
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                    
                                    //V8.BackColor = Color.IndianRed;
                                   
                                }
                                else if (received_data.Contains("<WUP>") == true)
                                {
                                    system_Date_check();
                                    system_status_check();
                                    system_time_check();
                                    automatic_status_check();

                                    system_ventil1_status_check();
                                    system_ventil2_status_check();
                                    system_ventil3_status_check();
                                    system_ventil4_status_check();
                                    system_ventil5_status_check();
                                    
                                    system_ventil8_status_check();
                                    
                                    //odH_check();
                                    //odM_check();

                                }
                                else if (received_data.Contains("<V1ONA>") == true)
                                {
                                    V1.BackColor = Color.LightGreen;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                    
                                }
                                else if (received_data.Contains("<V2ONA>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.LightGreen;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                    
                                }
                                else if (received_data.Contains("<V3ONA>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.LightGreen;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                    
                                }
                                else if (received_data.Contains("<V4ONA>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.LightGreen;
                                    V5.BackColor = Color.IndianRed;
                                   
                                }
                                else if (received_data.Contains("<V5ONA>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.LightGreen;
                                    
                                }
                                else if (received_data.Contains("<V6ONA>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                   
                                }
                                else if (received_data.Contains("<V7ONA>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                    V2.BackColor = Color.IndianRed;
                                    V3.BackColor = Color.IndianRed;
                                    V4.BackColor = Color.IndianRed;
                                    V5.BackColor = Color.IndianRed;
                                   
                                }



                                else if (received_data.Contains("<V1ON>") == true)
                                {
                                    V1.BackColor = Color.LightGreen;
                                }
                                else if (received_data.Contains("<V1OFF>") == true)
                                {
                                    V1.BackColor = Color.IndianRed;
                                }
                                else if (received_data.Contains("<V2ON>") == true)
                                {
                                    V2.BackColor = Color.LightGreen;
                                }
                                else if (received_data.Contains("<V2OFF>") == true)
                                {
                                    V2.BackColor = Color.IndianRed;
                                }
                                else if (received_data.Contains("<V3ON>") == true)
                                {
                                    V3.BackColor = Color.LightGreen;
                                }
                                else if (received_data.Contains("<V3OFF>") == true)
                                {
                                    V3.BackColor = Color.IndianRed;
                                }
                                else if (received_data.Contains("<V4ON>") == true)
                                {
                                    V4.BackColor = Color.LightGreen;
                                }
                                else if (received_data.Contains("<V4OFF>") == true)
                                {
                                    V4.BackColor = Color.IndianRed;
                                }
                                else if (received_data.Contains("<V5ON>") == true)
                                {
                                    V5.BackColor = Color.LightGreen;
                                }
                                else if (received_data.Contains("<V5OFF>") == true)
                                {
                                    V5.BackColor = Color.IndianRed;
                                }
                               
                                else if (received_data.Contains("<V8ON>") == true)
                                {
                                    //V8.BackColor = Color.LightGreen;
                                }
                                else if (received_data.Contains("<V8OFF>") == true)
                                {
                                    //V8.BackColor = Color.IndianRed;
                                }
                                
                                else if (received_data.Contains("<FAIL>") == true)
                                {
                                    btn_avtomatika.BackColor = Color.IndianRed;
                                    btn_rocno.BackColor = Color.IndianRed;
                                    btn_stop.BackColor = Color.IndianRed;
                                    MessageBox.Show("Komunikacija OK. Napaka pri pošiljanju ukaza!");

                                }
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
                        variables.udpfree12014 = true;
                        listener_auto.Close();
                    }

                }
                else { break; }

            }

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
                        //MessageBox.Show(myString);
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
                        //MessageBox.Show(myString);
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

                    }

                    else if (received_data.Contains("<A_ST1>") == true)
                    {

                        btn_avtomatika.BackColor = Color.LightGreen;
                        btn_rocno.BackColor = Color.IndianRed;
                        btn_stop.BackColor = Color.IndianRed;
                        break;

                    }
                    else if (received_data.Contains("<M_ST1>") == true)
                    {
                        btn_avtomatika.BackColor = Color.IndianRed;
                        btn_rocno.BackColor = Color.LightGreen;
                        btn_stop.BackColor = Color.IndianRed;
                        break;
                    }
                    else if (received_data.Contains("<S_ST1>") == true)
                    {
                        btn_avtomatika.BackColor = Color.IndianRed;
                        btn_rocno.BackColor = Color.IndianRed;
                        btn_stop.BackColor = Color.LightGreen;
                        break;
                    }
                    if (received_data.Contains("<VARC1>") == true)
                    {

                        btn_varcno.BackColor = Color.Aqua;
                        btn_optimalno.BackColor = Color.Empty;
                        btn_intenzivno.BackColor = Color.Empty;
                        btn_osebno.BackColor = Color.Empty;
                        break;

                    }
                    if (received_data.Contains("<OPTI1>") == true)
                    {

                        btn_varcno.BackColor = Color.Empty;
                        btn_optimalno.BackColor = Color.Aqua;
                        btn_intenzivno.BackColor = Color.Empty;
                        btn_osebno.BackColor = Color.Empty;
                        break;

                    }

                    if (received_data.Contains("<INTEN1>") == true)
                    {

                        btn_varcno.BackColor = Color.Empty;
                        btn_optimalno.BackColor = Color.Empty;
                        btn_intenzivno.BackColor = Color.Aqua;
                        btn_osebno.BackColor = Color.Empty;
                        break;

                    }
                    if (received_data.Contains("<OSEB1>") == true)
                    {

                        btn_varcno.BackColor = Color.Empty;
                        btn_optimalno.BackColor = Color.Empty;
                        btn_intenzivno.BackColor = Color.Empty;
                        btn_osebno.BackColor = Color.Aqua;
                        break;

                    }


                    else if (received_data.Contains("<FAIL>") == true)
                    {
                        btn_avtomatika.BackColor = Color.IndianRed;
                        btn_rocno.BackColor = Color.IndianRed;
                        btn_stop.BackColor = Color.IndianRed;
                        MessageBox.Show("Komunikacija OK. Napaka pri pošiljanju ukaza!");
                        break;
                    }
                    else if (received_data.Contains("<V1ON>") == true)
                    {
                        V1.BackColor = Color.LightGreen;
                        break;
                    }
                    else if (received_data.Contains("<V1OFF>") == true)
                    {
                        V1.BackColor = Color.IndianRed;
                        break;
                    }
                    else if (received_data.Contains("<V2ON>") == true)
                    {
                        V2.BackColor = Color.LightGreen;
                        break;
                    }
                    else if (received_data.Contains("<V2OFF>") == true)
                    {
                        V2.BackColor = Color.IndianRed;
                        break;
                    }
                    else if (received_data.Contains("<V3ON>") == true)
                    {
                        V3.BackColor = Color.LightGreen;
                        break;
                    }
                    else if (received_data.Contains("<V3OFF>") == true)
                    {
                        V3.BackColor = Color.IndianRed;
                        break;
                    }
                    else if (received_data.Contains("<V4ON>") == true)
                    {
                        V4.BackColor = Color.LightGreen;
                        break;
                    }
                    else if (received_data.Contains("<V4OFF>") == true)
                    {
                        V4.BackColor = Color.IndianRed;
                        break;
                    }
                    else if (received_data.Contains("<V5ON>") == true)
                    {
                        V5.BackColor = Color.LightGreen;
                        break;
                    }
                    else if (received_data.Contains("<V5OFF>") == true)
                    {
                        V5.BackColor = Color.IndianRed;
                        break;
                    }
                    
                    else if (received_data.Contains("<V8ON>") == true)
                    {
                        //V8.BackColor = Color.LightGreen;
                        break;
                    }
                    else if (received_data.Contains("<V8OFF>") == true)
                    {
                       // V8.BackColor = Color.IndianRed;
                        break;
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
                        cas_sistema_label.Text = variables.cas_sistema_ura;
                        break;

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
                        datum_sistema_label.Text = variables.cas_sistema_datum;
                        break;

                    }
                    else if (received_data.Contains("<OK>") == true)
                    {

                        //odH_check();
                        //odM_check();
                        //MessageBox.Show("Shranjeno!");

                       // status_led.BackColor = Color.LightGreen;
                    }
                    else if (received_data.Contains("<SETtoM>") == true)
                    {
                        //MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!");
                    }
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

                        if (tokens[1] == "ON") { variables.pon_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.pon_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<TOR>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.tor_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.tor_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SRE>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.sre_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.sre_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }

                    else if (received_data.Contains("<CET>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.cet_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.cet_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<PET>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.pet_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.pet_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SOB>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.sob_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.sob_zelenica = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<NED>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.ned_zelenica = true; }
                        else if (tokens[1] == "OFF") { variables.ned_zelenica = false; }


                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN1Z>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.int1_zel = true; }
                        else if (tokens[1] == "OFF") { variables.int1_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN2Z>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.int2_zel = true; }
                        else if (tokens[1] == "OFF") { variables.int2_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN3Z>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.int3_zel = true; }
                        else if (tokens[1] == "OFF") { variables.int3_zel = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<IN4Z>") == true)
                    {
                        string myString = received_data;
                        //MessageBox.Show(received_data);
                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.int4_zel = true; }
                        else if (tokens[1] == "OFF") { variables.int4_zel = false; }

                        //Console.WriteLine(tokens[1]);

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
                        //MessageBox.Show(myString);

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
                    if (received_data.Contains("<VRT_T1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.vrt_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.vrt_OD_H = (tokens[1]);

                        }

                    }
                    //interval 1 od m
                    else if (received_data.Contains("<VRT_T2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.vrt_OD_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.vrt_OD_M = (tokens[1]);

                        }

                    }

                    //interval 1 do h
                    else if (received_data.Contains("VRT_T3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.vrt_DO_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.vrt_DO_H = (tokens[1]);

                        }

                    }
                    //interval 1 od m
                    else if (received_data.Contains("VRT_T4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.vrt_DO_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.vrt_DO_M = (tokens[1]);

                        }


                    }

                    else if (received_data.Contains("<PONV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.pon_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.pon_vrt = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<TORV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.tor_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.tor_vrt = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SREV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.sre_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.sre_vrt = false; }

                        //Console.WriteLine(tokens[1]);

                    }

                    else if (received_data.Contains("<CETV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.cet_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.cet_vrt = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<PETV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.pet_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.pet_vrt = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SOBV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.sob_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.sob_vrt = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<NEDV>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.ned_vrt = true; }
                        else if (tokens[1] == "OFF") { variables.ned_vrt = false; }


                        //Console.WriteLine(tokens[1]);

                    }

                    if (received_data.Contains("<KAP_T1>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.kapljicno_OD_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.kapljicno_OD_H = (tokens[1]);

                        }

                    }
                    //interval 1 od m
                    else if (received_data.Contains("<KAP_T2>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.kapljicno_OD_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.kapljicno_OD_M = (tokens[1]);

                        }

                    }

                    //interval 1 do h
                    else if (received_data.Contains("KAP_T3>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.kapljicno_DO_H = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.kapljicno_DO_H = (tokens[1]);

                        }

                    }
                    //interval 1 od m
                    else if (received_data.Contains("KAP_T4>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        //Console.WriteLine(tokens[1]);
                        int transformed;
                        Int32.TryParse(tokens[1], out transformed);
                        if (transformed < 10)
                        {
                            variables.kapljicno_DO_M = ("0" + tokens[1]);
                        }
                        else
                        {
                            variables.kapljicno_DO_M = (tokens[1]);

                        }


                    }

                    else if (received_data.Contains("<PONK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.pon_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.pon_kapljicno = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<TORK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.tor_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.tor_kapljicno = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SREK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.sre_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.sre_kapljicno = false; }

                        //Console.WriteLine(tokens[1]);

                    }

                    else if (received_data.Contains("<CETK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.cet_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.cet_kapljicno = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<PETK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.pet_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.pet_kapljicno = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SOBK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.sob_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.sob_kapljicno = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<NEDK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { variables.ned_kapljicno = true; }
                        else if (tokens[1] == "OFF") { variables.ned_kapljicno = false; }


                        //Console.WriteLine(tokens[1]);

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

        public void Controller_Coneccted_Check()
        {

        }

        private void system_status_check()
        {
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_ST>");

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
        private void automatic_status_check()
        {
            //sys_status_check();
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<AUTOM_ST>");

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

        private void system_ventil1_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V1>");

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
        private void system_ventil2_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V2>");

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
        private void system_ventil3_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V3>");

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
        private void system_ventil4_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V4>");

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
        private void system_ventil5_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V5>");

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
        private void system_ventil6_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V6>");

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
        private void system_ventil7_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V7>");

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
        private void system_ventil8_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V8>");

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
        private void system_ventil9_status_check()
        {
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SYS_V9>");

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

        private void system_time_check()
        {

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
        private void system_Date_check()
        {
            //MessageBox.Show("System date check");
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
        private void btn_avtomatika_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            byte[] packetData1 = System.Text.ASCIIEncoding.ASCII.GetBytes("<A_ST>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData1, ep);




            //poslušanje

            UDPListener();
            //

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            finishTime_calculation();
            calculate_start_time();
            calculate_start_time_vrt();
            calculate_start_time_kapljicno();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();


        }

        private void btn_rocno_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            byte[] packetData2 = System.Text.ASCIIEncoding.ASCII.GetBytes("<M_ST>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData2, ep);

            //poslušanje

            UDPListener();

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            //
            finishTime_calculation();
            calculate_start_time();
            calculate_start_time_vrt();
            calculate_start_time_kapljicno();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            byte[] packetData3 = System.Text.ASCIIEncoding.ASCII.GetBytes("<S_ST>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData3, ep);

            //poslušanje

            UDPListener();

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            finishTime_calculation();
            calculate_start_time();
            calculate_start_time_vrt();
            calculate_start_time_kapljicno();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
            //
        }


        private void iPKontrolerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Hide();
            config fconfig = new config();
            fconfig.ShowDialog();



        }



        private void V1_Click(object sender, EventArgs e)
        {

            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V1>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();



        }

        private void V2_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V2>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V3_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V3>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V4_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V4>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V5_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V5>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V6_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V6>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V7_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V7>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V8_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V8>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void V9_Click(object sender, EventArgs e)
        {
            if (btn_rocno.BackColor.ToString() == "Color [LightGreen]")
            {
                disableButtons();
                Cursor.Current = Cursors.WaitCursor;
                //sys_status_check();
                byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<V9>");

                //Port in ip za pošiljanje UDP paketa
                string IP = variables.IP;
                int port = 8888;


                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.SendTo(packetData5, ep);

                //poslušanje

                UDPListener();
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
                enableButtons();
                //
            }
            else { MessageBox.Show("Preklopi v ročni modus za upravljanje z ventili!"); }
        }

        private void zelenicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //UDP_WakeupSignalFromATMEL();

            //system_status_check();
            /* system_ventil1_status_check();
             system_ventil2_status_check();
             system_ventil3_status_check();
             system_ventil4_status_check();
             system_ventil5_status_check();
             system_ventil6_status_check();
             system_ventil7_status_check();
             system_ventil8_status_check();
             system_ventil9_status_check();   */
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (variables.udpfree)
            {
                system_time_check();
                system_Date_check();
                
            }
            //odH_check();
            //odM_check();
        }

        private void časovnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sett_zelenica home = new sett_zelenica(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void sMARTIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Smartik home = new Smartik(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void intervaliVentilovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Veje_sett home = new Veje_sett();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            vrt_int1_odH_check();
            vrt_int1_odM_check();
            vrt_int1_doH_check();
            vrt_int1_doM_check();

            vrt_pon_check();
            vrt_tor_check();
            vrt_sre_check();
            vrt_cet_check();
            vrt_pet_check();
            vrt_sob_check();
            vrt_ned_check();

            odH_check();
            odM_check();

            vrt_int1_odH_check();
            vrt_int1_odM_check();
            vrt_int1_doH_check();
            vrt_int1_doM_check();

            kapljicno_int1_odH_check();
            kapljicno_int1_odM_check();
            kapljicno_int1_doH_check();
            kapljicno_int1_doM_check();

            kapljicno_pon_check();
            kapljicno_tor_check();
            kapljicno_sre_check();
            kapljicno_cet_check();
            kapljicno_pet_check();
            kapljicno_sob_check();
            kapljicno_ned_check();


            Cursor.Current = Cursors.WaitCursor;
            system_Date_check();
            system_status_check();
            system_time_check();
            automatic_status_check();

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            odH_check();
            odM_check();
            calculate_start_time();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
            //MessageBox.Show("Osveženo");
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

        private void button2_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            byte[] packetData1 = System.Text.ASCIIEncoding.ASCII.GetBytes("<VARC>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData1, ep);




            //poslušanje

            UDPListener();
            //

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            calculate_start_time();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void btn_optimalno_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;

            byte[] packetData1 = System.Text.ASCIIEncoding.ASCII.GetBytes("<OPTI>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData1, ep);




            //poslušanje

            UDPListener();
            //

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            calculate_start_time();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void btn_intenzivno_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;

            byte[] packetData1 = System.Text.ASCIIEncoding.ASCII.GetBytes("<INTEN>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData1, ep);




            //poslušanje

            UDPListener();
            //

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            calculate_start_time();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void btn_osebno_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            byte[] packetData1 = System.Text.ASCIIEncoding.ASCII.GetBytes("<OSEB>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData1, ep);




            //poslušanje

            UDPListener();
            //

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();
            calculate_start_time();
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




        private void SendTest()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TEST>");

            //Port in ip za pošiljanje UDP paketa
            string IP = variables.IP;
            //int const listenPort = (Convert.ToInt32(variables.PORT));
            int port = 8888;

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTo(packetData5, ep);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sett_zelenica home = new sett_zelenica(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void veja1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja1_photo home = new Veja1_photo();
            home.Show();
            //this.Hide();
        }

        private void veja2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja2_photo home = new Veja2_photo();
            home.Show();
            //this.Hide();
        }

        private void veja3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja3_photo home = new Veja3_photo();
            home.Show();
            //this.Hide();
        }

        private void veja4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja4_photo home = new Veja4_photo();
            home.Show();
            //this.Hide();
        }

        private void veja5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja5_photo home = new Veja5_photo();
            home.Show();
            //this.Hide();
        }

        private void veja6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja6_photo home = new Veja6_photo();
            home.Show();
            //this.Hide();
        }

        private void veja78ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veja7_photo home = new Veja7_photo();
            home.Show();
            //this.Hide();
        }

        private void iZHODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            finishTime_calculation();
        }

        public void finishTime_calculation()
        {

            string sMonth = DateTime.Now.ToString("MM");

            string startTime = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
            //string endTime = variables.P_DO_H + ": " + variables.P_DO_M;


            TimeSpan duration3 = DateTime.Parse(variables.marec).Subtract(DateTime.Parse("00:00"));
            double minutes3 = duration3.TotalMinutes;

            TimeSpan duration4 = DateTime.Parse(variables.april).Subtract(DateTime.Parse("00:00"));
            double minutes4 = duration4.TotalMinutes;

            TimeSpan duration5 = DateTime.Parse(variables.maj).Subtract(DateTime.Parse("00:00"));
            double minutes5 = duration5.TotalMinutes;

            TimeSpan duration6 = DateTime.Parse(variables.junij).Subtract(DateTime.Parse("00:00"));
            double minutes6 = duration6.TotalMinutes;

            TimeSpan duration7 = DateTime.Parse(variables.julij).Subtract(DateTime.Parse("00:00"));
            double minutes7 = duration7.TotalMinutes;

            TimeSpan duration8 = DateTime.Parse(variables.avgust).Subtract(DateTime.Parse("00:00"));
            double minutes8 = duration8.TotalMinutes;

            TimeSpan duration9 = DateTime.Parse(variables.september).Subtract(DateTime.Parse("00:00"));
            double minutes9 = duration9.TotalMinutes;

            TimeSpan duration10 = DateTime.Parse(variables.oktober).Subtract(DateTime.Parse("00:00"));
            double minutes10 = duration10.TotalMinutes;




            switch (Convert.ToInt16(sMonth))
            {
                case 1:
                    if ((btn_osebno.BackColor.ToString() == "Color [Control]"))
                    {
                        konecNamakanja_lbl.Text = "Namakanje v tem obdobju deluje samo po osebnih nastavitvah!";
                    }
                    break;
                case 2:
                    if ((btn_osebno.BackColor.ToString() == "Color [Control]"))
                    {
                        konecNamakanja_lbl.Text = "Namakanje v tem obdobju deluje samo po osebnih nastavitvah!";
                    }
                    break;
                case 3:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes3 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);


                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }

                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;

                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }

                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes3 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        ////konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }

                    break;
                case 4:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes4 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes4) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes4 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        ////konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }


                    break;
                case 5:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes5 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes5) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes5 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        ////konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }
                    break;
                case 6:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes6 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes6) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes6 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        //konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }
                    break;
                case 7:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes7 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes7 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        //konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }
                    break;
                case 8:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes8 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes8) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes8 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        //konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }
                    break;
                case 9:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes9 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes9) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes9 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        //konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }
                    break;
                case 10:
                    if (btn_varcno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes10 * 0.7) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;

                    }
                    else if (btn_optimalno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes10) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_intenzivno.BackColor.ToString() == "Color [Aqua]")
                    {
                        string start = variables.OD_H_avtomatika + ": " + variables.OD_M_avtomatika;
                        TimeSpan start1 = DateTime.Parse(start).Subtract(DateTime.Parse("00:00"));
                        double totalMinutes = (start1.TotalMinutes);
                        double h = 0;
                        double min = (minutes10 * 1.3) + totalMinutes;
                        while (min >= 60) { h = h + 1; min = min - 60; }
                        int c = Convert.ToInt16(min);
                        string a = Convert.ToString(h);
                        string b = Convert.ToString(c);

                        if (h <= 9) { a = "0" + a; }
                        if (min <= 9) { b = "0" + c; }
                        variables.DO_H_zelenica = a;
                        variables.DO_M_zelenica = b;
                        //konecNamakanja_lbl.Text = a + ":" + b;
                    }
                    else if (btn_osebno.BackColor.ToString() == "Color [Aqua]")
                    {
                        //konecNamakanja_lbl.Text = "Preveri osebne nastavitve...";
                    }
                    break;
                case 11:
                    if((btn_osebno.BackColor.ToString() == "Color [Control]"))
                    {
                    konecNamakanja_lbl.Text = "Namakanje v tem obdobju deluje samo po osebnih nastavitvah!";
                    }
                    break;
                case 12:
                    if ((btn_osebno.BackColor.ToString() == "Color [Control]"))
                    {
                        konecNamakanja_lbl.Text = "Namakanje v tem obdobju deluje samo po osebnih nastavitvah!";
                    }
                    break;

            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void spremeni_btn_Click(object sender, EventArgs e)
        {
            disableButtons();
            Cursor.Current = Cursors.WaitCursor;
            //variables.OD_H_avtomatika = od_H_avtomatika_box.Text;
            //MessageBox.Show("2");
            //variables.OD_M_avtomatika = od_M_avtomatika_box.Text;
            //MessageBox.Show("3");
            label4.Text = variables.OD_H_avtomatika + ":" + variables.OD_M_avtomatika;
            //MessageBox.Show("AS");
            send_odH();
            send_odM();




            //MessageBox.Show("Shranjeno");
            //SendTest();
            odH_check();
            odM_check();

            system_ventil1_status_check();
            system_ventil2_status_check();
            system_ventil3_status_check();
            system_ventil4_status_check();
            system_ventil5_status_check();
            system_ventil6_status_check();
            system_ventil7_status_check();
            system_ventil8_status_check();
            system_ventil9_status_check();

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            enableButtons();
        }

        private void shrani_btn_zacetek_Click(object sender, EventArgs e)
        {
            //variables.OD_H_avtomatika = od_H_avtomatika_box.Text;
            MessageBox.Show("2");
            //variables.OD_M_avtomatika = od_M_avtomatika_box.Text;
            MessageBox.Show("3");
            label4.Text = variables.OD_H_avtomatika + ":" + variables.OD_M_avtomatika;
            MessageBox.Show("AS");
            send_odH();
            send_odM();




            MessageBox.Show("Shranjeno");
            //SendTest();
            odH_check();
            odM_check();
        }


        public void disableButtons()
        {

            this.btn_avtomatika.Enabled = false;
            this.btn_rocno.Enabled = false;
            this.btn_stop.Enabled = false;
            this.btn_osebno.Enabled = false;
            this.btn_intenzivno.Enabled = false;
            this.btn_optimalno.Enabled = false;
            this.btn_varcno.Enabled = false;
            //this.spremeni_btn.Enabled = false;
            this.linkLabel1.Enabled = false;
            this.V1.Enabled = false;
            this.V2.Enabled = false;
            this.V3.Enabled = false;
            this.V4.Enabled = false;
            this.V5.Enabled = false;
            
            //this.V8.Enabled = false;
            
            //this.spremeni_btn.Enabled = false;
            this.button1.Enabled = false;
            this.iPKontrolerjaToolStripMenuItem.Enabled = false;
           // this.živaMejaToolStripMenuItem.Enabled = false;
            
            this.časovnikToolStripMenuItem.Enabled = false;


        }

        public void enableButtons()
        {

            this.btn_avtomatika.Enabled = true;
            this.btn_rocno.Enabled = true;
            this.btn_stop.Enabled = true;
            this.btn_osebno.Enabled = true;
            this.btn_intenzivno.Enabled = true;
            this.btn_optimalno.Enabled = true;
            this.btn_varcno.Enabled = true;
            //this.spremeni_btn.Enabled = true;
            this.linkLabel1.Enabled = true;
            this.V1.Enabled = true;
            this.V2.Enabled = true;
            this.V3.Enabled = true;
            this.V4.Enabled = true;
            this.V5.Enabled = true;
            
            //this.V8.Enabled = true;
            
            //this.spremeni_btn.Enabled = true;
            this.button1.Enabled = true;
            this.iPKontrolerjaToolStripMenuItem.Enabled = true;
            //this.živaMejaToolStripMenuItem.Enabled = true;
            //this.vrtToolStripMenuItem.Enabled = true;
            this.časovnikToolStripMenuItem.Enabled = true;
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

        private void avtomatikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avtomatika_sett home = new avtomatika_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
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


        //Kalkulacija začetka naslednjega intervala zelenice
        public void calculate_start_time()
        {
            if ((btn_avtomatika.BackColor.ToString() == "Color [LightGreen]"))
            {
                
                DateTime danes = DateTime.Today;
                DateTime izklj1, izklj2, izklj3, izklj4, izklj5, izklj6, izklj7;
                DateTime old = DateTime.Parse("2008-05-01T07:34:42-5:00");


                if (variables.chosendate_zelenica != "") { izklj1 = DateTime.Parse(variables.chosendate_zelenica); }
                else { izklj1 = old; }
                if (variables.chosendate_zelenica2 != "") { izklj2 = DateTime.Parse(variables.chosendate_zelenica2); }
                else { izklj2 = old; }
                if (variables.chosendate_zelenica3 != "") { izklj3 = DateTime.Parse(variables.chosendate_zelenica3); }
                else { izklj3 = old; }
                if (variables.chosendate_zelenica4 != "") { izklj4 = DateTime.Parse(variables.chosendate_zelenica4); }
                else { izklj4 = old; }
                if (variables.chosendate_zelenica5 != "") { izklj5 = DateTime.Parse(variables.chosendate_zelenica5); }
                else { izklj5 = old; }
                if (variables.chosendate_zelenica6 != "") { izklj6 = DateTime.Parse(variables.chosendate_zelenica6); }
                else { izklj6 = old; }
                if (variables.chosendate_zelenica7 != "") { izklj7 = DateTime.Parse(variables.chosendate_zelenica7); }
                else { izklj7 = old; }


                if (izklj1 != old || izklj2 != old || izklj3 != old || izklj4 != old || izklj5 != old || izklj6 != old || izklj7 != old)
                {
                    while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                    {
                        nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);

                    }
                }
                DayOfWeek dan = nextWatteringTimeZelenica.DayOfWeek;
                //MessageBox.Show(Convert.ToString(nextWatteringTimeZelenica.DayOfWeek));
                //Datum namakanja po osebnih nastavitvah
                if ((btn_osebno.BackColor.ToString() == "Color [Aqua]"))
                {
                    //MessageBox.Show("Aqua");

                    if (dan == DayOfWeek.Monday)
                    {
                        if (variables.pon_zelenica==true) { }
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Tuesday)
                    {
                        if (variables.tor_zelenica) {}
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Wednesday)
                    {
                        if (variables.sre_zelenica) { }
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Thursday)
                    {
                        if (variables.cet_zelenica) { }
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Friday)
                    {
                        if (variables.pet_zelenica) { }
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Saturday)
                    {
                        if (variables.sob_zelenica) {  }
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Sunday)
                    {
                        if (variables.ned_zelenica) {  }
                        else
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            dan = nextWatteringTimeZelenica.DayOfWeek;
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                                dan = nextWatteringTimeZelenica.DayOfWeek;
                            }
                        }
                    }

                    //Ura namakanja po osebnih nastavitvah

                        DateTime nextwateringTimeStart = nextWatteringTimeZelenica;
                        DateTime nextwateringTimeStop = nextWatteringTimeZelenica;
                        
                        bool interval1 = variables.int1_zel;
                        bool interval2 = variables.int2_zel;
                        bool interval3 = variables.int3_zel;
                        bool interval4 = variables.int4_zel;
                        
                        bool interval1sorted = variables.int1_zel;
                        bool interval2sorted = variables.int2_zel;
                        bool interval3sorted = variables.int3_zel;
                        bool interval4sorted = variables.int4_zel;

                        DateTime konec1 = nextWatteringTimeZelenica.Date;
                        DateTime konec2 = nextWatteringTimeZelenica.Date;
                        DateTime konec3 = nextWatteringTimeZelenica.Date;
                        DateTime konec4 = nextWatteringTimeZelenica.Date;

                        DateTime konec1sorted = nextWatteringTimeZelenica.Date;
                        DateTime konec2sorted = nextWatteringTimeZelenica.Date;
                        DateTime konec3sorted = nextWatteringTimeZelenica.Date;
                        DateTime konec4sorted = nextWatteringTimeZelenica.Date;

                        DateTime zacetek1 = nextWatteringTimeZelenica.Date;
                        DateTime zacetek2 = nextWatteringTimeZelenica.Date;
                        DateTime zacetek3 = nextWatteringTimeZelenica.Date;
                        DateTime zacetek4 = nextWatteringTimeZelenica.Date;

                        DateTime zacetek1sorted = nextWatteringTimeZelenica.Date;
                        DateTime zacetek2sorted = nextWatteringTimeZelenica.Date;
                        DateTime zacetek3sorted = nextWatteringTimeZelenica.Date;
                        DateTime zacetek4sorted = nextWatteringTimeZelenica.Date;
                        //MessageBox.Show(Convert.ToString(konec));
                        konec1 = konec1.AddHours(Convert.ToDouble(variables.P_DO_H));
                        konec1 = konec1.AddMinutes(Convert.ToDouble(variables.P_DO_M));
                        konec2 = konec2.AddHours(Convert.ToDouble(variables.D_DO_H));
                        konec2 = konec2.AddMinutes(Convert.ToDouble(variables.D_DO_M));
                        konec3 = konec3.AddHours(Convert.ToDouble(variables.T_DO_H));
                        konec3 = konec3.AddMinutes(Convert.ToDouble(variables.T_DO_M));
                        konec4 = konec4.AddHours(Convert.ToDouble(variables.S_DO_H));
                        konec4 = konec4.AddMinutes(Convert.ToDouble(variables.S_DO_M));

                        zacetek1 = zacetek1.AddHours(Convert.ToDouble(variables.P_OD_H));
                        zacetek1 = zacetek1.AddMinutes(Convert.ToDouble(variables.P_OD_M));
                        zacetek2 = zacetek2.AddHours(Convert.ToDouble(variables.D_OD_H));
                        zacetek2 = zacetek2.AddMinutes(Convert.ToDouble(variables.D_OD_M));
                        zacetek3 = zacetek3.AddHours(Convert.ToDouble(variables.T_OD_H));
                        zacetek3 = zacetek3.AddMinutes(Convert.ToDouble(variables.T_OD_M));
                        zacetek4 = zacetek4.AddHours(Convert.ToDouble(variables.S_OD_H));
                        zacetek4 = zacetek4.AddMinutes(Convert.ToDouble(variables.S_OD_M));
                        
                        //Sortiranje časov

                        if (zacetek1 < zacetek2 && zacetek1 < zacetek3 && zacetek1 < zacetek4)
                        {
                            zacetek1sorted = zacetek1;
                            konec1sorted = konec1;
                            interval1sorted = interval1;
                            if (zacetek2 < zacetek3 && zacetek2 < zacetek4)
                            {
                                zacetek2sorted = zacetek2;
                                konec2sorted = konec2;
                                interval2sorted = interval2;
                                if (zacetek3 < zacetek4)
                                {
                                    zacetek3sorted = zacetek3;
                                    konec3sorted = konec3;
                                    interval3sorted = interval3;
                                    zacetek4sorted = zacetek4;
                                    konec4sorted = konec4;
                                    interval4sorted = interval4;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek4;
                                    konec3sorted = konec4;
                                    interval3sorted = interval4;
                                    zacetek4sorted = zacetek3;
                                    konec4sorted = konec3;
                                    interval4sorted = interval3;
                                }

                            }
                            else if (zacetek3 < zacetek2 && zacetek3 < zacetek4)
                            {
                                zacetek2sorted = zacetek3;
                                konec2sorted = konec3;
                                interval2sorted = interval3;
                                if (zacetek2 < zacetek4)
                                {
                                    zacetek3sorted = zacetek2;
                                    konec3sorted = konec2;
                                    interval3sorted = interval2;
                                    zacetek4sorted = zacetek4;
                                    konec4sorted = konec4;
                                    interval4sorted = interval4;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek4;
                                    konec3sorted = konec4;
                                    interval3sorted = interval4;
                                    zacetek4sorted = zacetek2;
                                    konec4sorted = konec2;
                                    interval4sorted = interval2;
                                }

                            }
                            else if (zacetek4 < zacetek2 && zacetek4 < zacetek3)
                            {
                                zacetek2sorted = zacetek4;
                                konec2sorted = konec4;
                                interval2sorted = interval4;
                                if (zacetek2 < zacetek3)
                                {
                                    zacetek3sorted = zacetek2;
                                    konec3sorted = konec2;
                                    interval3sorted = interval2;
                                    zacetek4sorted = zacetek3;
                                    konec4sorted = konec3;
                                    interval4sorted = interval3;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek3;
                                    konec3sorted = konec3;
                                    interval3sorted = interval3;
                                    zacetek4sorted = zacetek2;
                                    konec4sorted = konec2;
                                    interval4sorted = interval2;
                                }
                            }
                        }
                        else if (zacetek2 < zacetek1 && zacetek2 < zacetek3 && zacetek2 < zacetek4)
                        {
                            zacetek1sorted = zacetek2;
                            konec1sorted = konec2;
                            interval1sorted = interval2;
                            if (zacetek1 < zacetek3 && zacetek1 < zacetek4)
                            {
                                zacetek2sorted = zacetek1;
                                konec2sorted = konec1;
                                interval2sorted = interval1;
                                if (zacetek3 < zacetek4)
                                {
                                    zacetek3sorted = zacetek3;
                                    konec3sorted = konec3;
                                    interval3sorted = interval3;
                                    zacetek4sorted = zacetek4;
                                    konec4sorted = konec4;
                                    interval4sorted = interval4;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek4;
                                    konec3sorted = konec4;
                                    interval3sorted = interval4;
                                    zacetek4sorted = zacetek3;
                                    konec4sorted = konec3;
                                    interval4sorted = interval3;
                                }

                            }
                            else if (zacetek3 < zacetek1 && zacetek3 < zacetek4)
                            {
                                zacetek2sorted = zacetek3;
                                konec2sorted = konec3;
                                interval2sorted = interval3;
                                if (zacetek1 < zacetek4)
                                {
                                    zacetek3sorted = zacetek1;
                                    konec3sorted = konec1;
                                    interval3sorted = interval1;
                                    zacetek4sorted = zacetek4;
                                    konec4sorted = konec4;
                                    interval4sorted = interval4;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek4;
                                    konec3sorted = konec4;
                                    interval3sorted = interval4;
                                    zacetek4sorted = zacetek1;
                                    konec4sorted = konec1;
                                    interval4sorted = interval1;
                                }

                            }
                            else if (zacetek4 < zacetek1 && zacetek4 < zacetek3)
                            {
                                zacetek2sorted = zacetek4;
                                konec2sorted = konec4;
                                interval2sorted = interval4;
                                if (zacetek1 < zacetek3)
                                {
                                    zacetek3sorted = zacetek1;
                                    konec3sorted = konec1;
                                    interval3sorted = interval1;
                                    zacetek4sorted = zacetek3;
                                    konec4sorted = konec3;
                                    interval4sorted = interval3;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek3;
                                    konec3sorted = konec3;
                                    interval3sorted = interval3;
                                    zacetek4sorted = zacetek1;
                                    konec4sorted = konec1;
                                    interval4sorted = interval1;
                                }
                            }
                        }
                        else if (zacetek3 < zacetek1 && zacetek3 < zacetek2 && zacetek3 < zacetek4)
                        {
                            zacetek1sorted = zacetek3;
                            konec1sorted = konec3;
                            interval1sorted = interval3;
                            if (zacetek1 < zacetek2 && zacetek1 < zacetek4)
                            {
                                zacetek2sorted = zacetek1;
                                konec2sorted = konec1;
                                interval2sorted = interval1;
                                if (zacetek2 < zacetek4)
                                {
                                    zacetek3sorted = zacetek2;
                                    konec3sorted = konec2;
                                    interval3sorted = interval2;
                                    zacetek4sorted = zacetek4;
                                    konec4sorted = konec4;
                                    interval4sorted = interval4;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek4;
                                    konec3sorted = konec4;
                                    interval3sorted = interval4;
                                    zacetek4sorted = zacetek2;
                                    konec4sorted = konec2;
                                    interval4sorted = interval2;
                                }

                            }
                            else if (zacetek2 < zacetek1 && zacetek2 < zacetek4)
                            {
                                zacetek2sorted = zacetek2;
                                konec2sorted = konec2;
                                interval2sorted = interval2;
                                if (zacetek1 < zacetek4)
                                {
                                    zacetek3sorted = zacetek1;
                                    konec3sorted = konec1;
                                    interval3sorted = interval1;
                                    zacetek4sorted = zacetek4;
                                    konec4sorted = konec4;
                                    interval4sorted = interval4;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek4;
                                    konec3sorted = konec4;
                                    interval3sorted = interval4;
                                    zacetek4sorted = zacetek1;
                                    konec4sorted = konec1;
                                    interval4sorted = interval1;
                                }

                            }
                            else if (zacetek4 < zacetek1 && zacetek4 < zacetek2)
                            {
                                zacetek2sorted = zacetek4;
                                konec2sorted = konec4;
                                interval2sorted = interval4;
                                if (zacetek1 < zacetek2)
                                {
                                    zacetek3sorted = zacetek1;
                                    konec3sorted = konec1;
                                    interval3sorted = interval1;
                                    zacetek4sorted = zacetek2;
                                    konec4sorted = konec2;
                                    interval4sorted = interval2;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek2;
                                    konec3sorted = konec2;
                                    interval3sorted = interval2;
                                    zacetek4sorted = zacetek1;
                                    konec4sorted = konec1;
                                    interval4sorted = interval1;
                                }
                            }
                        }
                        else if (zacetek4 < zacetek1 && zacetek4 < zacetek2 && zacetek4 < zacetek3)
                        {
                            zacetek1sorted = zacetek4;
                            konec1sorted = konec4;
                            interval1sorted = interval4;
                            if (zacetek1 < zacetek2 && zacetek1 < zacetek3)
                            {
                                zacetek2sorted = zacetek1;
                                konec2sorted = konec1;
                                interval2sorted = interval1;
                                if (zacetek2 < zacetek3)
                                {
                                    zacetek3sorted = zacetek2;
                                    konec3sorted = konec2;
                                    interval3sorted = interval2;
                                    zacetek4sorted = zacetek3;
                                    konec4sorted = konec3;
                                    interval4sorted = interval3;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek3;
                                    konec3sorted = konec3;
                                    interval3sorted = interval3;
                                    zacetek4sorted = zacetek2;
                                    konec4sorted = konec2;
                                    interval4sorted = interval2;
                                }

                            }
                            else if (zacetek2 < zacetek1 && zacetek2 < zacetek3)
                            {
                                zacetek2sorted = zacetek2;
                                konec2sorted = konec2;
                                interval2sorted = interval2;
                                if (zacetek1 < zacetek3)
                                {
                                    zacetek3sorted = zacetek1;
                                    konec3sorted = konec1;
                                    interval3sorted = interval1;
                                    zacetek4sorted = zacetek3;
                                    konec4sorted = konec3;
                                    interval4sorted = interval3;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek3;
                                    konec3sorted = konec3;
                                    interval3sorted = interval3;
                                    zacetek4sorted = zacetek1;
                                    konec4sorted = konec1;
                                    interval4sorted = interval1;
                                }

                            }
                            else if (zacetek3 < zacetek1 && zacetek3 < zacetek2)
                            {
                                zacetek2sorted = zacetek3;
                                konec2sorted = konec3;
                                interval2sorted = interval3;
                                if (zacetek1 < zacetek2)
                                {
                                    zacetek3sorted = zacetek1;
                                    konec3sorted = konec1;
                                    interval3sorted = interval1;
                                    zacetek4sorted = zacetek2;
                                    konec4sorted = konec2;
                                    interval4sorted = interval2;

                                }
                                else
                                {
                                    zacetek3sorted = zacetek2;
                                    konec3sorted = konec2;
                                    interval3sorted = interval2;
                                    zacetek4sorted = zacetek1;
                                    konec4sorted = konec1;
                                    interval4sorted = interval1;
                                }
                            }
                        }
                        /*
                        MessageBox.Show(Convert.ToString(zacetek1sorted));
                        MessageBox.Show(Convert.ToString(zacetek2sorted));
                        MessageBox.Show(Convert.ToString(zacetek3sorted));
                        MessageBox.Show(Convert.ToString(zacetek4sorted));
                        */
                        int i = 0;

                        if ((interval4sorted == true) && (konec4sorted > DateTime.Now))
                        {
                            nextwateringTimeStart = zacetek4sorted;
                            nextwateringTimeStop = konec4sorted;
                            label4.Text = nextwateringTimeStart.ToString("HH:mm  dd/MM/yyyy");
                            konecNamakanja_lbl.Text = nextwateringTimeStop.ToString("HH:mm  dd/MM/yyyy");
                            
                        }
                        else if (interval4sorted == true)
                        {
                          
                            nextwateringTimeStart = zacetek4sorted;
                            nextwateringTimeStop = konec4sorted;

                            i = 1;
                        }
                        if ((interval3sorted == true) && (konec3sorted > DateTime.Now))
                        {
                            nextwateringTimeStart = zacetek3sorted;
                            nextwateringTimeStop = konec3sorted;
                            label4.Text = nextwateringTimeStart.ToString("HH:mm  dd/MM/yyyy");
                            konecNamakanja_lbl.Text = nextwateringTimeStop.ToString("HH:mm  dd/MM/yyyy");
                            
                        }
                        else if ((interval3sorted == true) && (interval4sorted == false))
                        {
                            nextwateringTimeStart = zacetek3sorted;
                            nextwateringTimeStop = konec3sorted;
                           
                            i = 1;
                        }
                        if ((interval2sorted == true) && (konec2sorted > DateTime.Now))
                        {
                            nextwateringTimeStart = zacetek2sorted;
                            nextwateringTimeStop = konec2sorted;
                            label4.Text = nextwateringTimeStart.ToString("HH:mm  dd/MM/yyyy");
                            konecNamakanja_lbl.Text = nextwateringTimeStop.ToString("HH:mm  dd/MM/yyyy");
                            
                        }
                        else if ((interval2sorted == true) && (interval3sorted == true) && (interval4sorted == false))
                        {
                            nextwateringTimeStart = zacetek2sorted;
                            nextwateringTimeStop = konec2sorted;
                            
                            i = 1;
                        }
                        if ((interval1sorted == true) && (konec1sorted > DateTime.Now))
                        {
                            nextwateringTimeStart = zacetek1sorted;
                            nextwateringTimeStop = konec1sorted;
                            label4.Text = nextwateringTimeStart.ToString("HH:mm  dd/MM/yyyy");
                            konecNamakanja_lbl.Text = nextwateringTimeStop.ToString("HH:mm  dd/MM/yyyy");
                            
                        }
                        else if ((interval1sorted == true) && (interval2sorted == false) && (interval3sorted == false) && (interval4sorted == false))
                        {
                            nextwateringTimeStart = zacetek1sorted;
                            nextwateringTimeStop = konec1sorted;
                            
                            i = 1;
                        }

    //////////////Če mora prestopiti dan
                        if (i == 1)
                        {
                           
                            nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                            nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                            

                            if (izklj1 != old || izklj2 != old || izklj3 != old || izklj4 != old || izklj5 != old || izklj6 != old || izklj7 != old)
                            {
                                
                                while (nextwateringTimeStart.Date == izklj1.Date || nextwateringTimeStart.Date == izklj2.Date || nextwateringTimeStart.Date == izklj3.Date || nextwateringTimeStart.Date == izklj4.Date || nextwateringTimeStart.Date == izklj5.Date || nextwateringTimeStart.Date == izklj6.Date || nextwateringTimeStart.Date == izklj7.Date)
                                {

                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                }
                            }
                            
                            dan = nextwateringTimeStart.DayOfWeek;
                            
                            if (dan == DayOfWeek.Monday)
                            {
                                if (variables.pon_zelenica) { }
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            }
                            if (dan == DayOfWeek.Tuesday)
                            {
                                if (variables.tor_zelenica) { }
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            } if (dan == DayOfWeek.Wednesday)
                            {
                                
                                if (variables.sre_zelenica) {}
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            } if (dan == DayOfWeek.Thursday)
                            {
                                if (variables.cet_zelenica) { }
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            } if (dan == DayOfWeek.Friday)
                            {
                                if (variables.pet_zelenica) { }
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            } if (dan == DayOfWeek.Saturday)
                            {
                                if (variables.sob_zelenica) { }
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            } if (dan == DayOfWeek.Sunday)
                            {
                                if (variables.ned_zelenica) { }
                                else
                                {
                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                    dan = nextwateringTimeStart.DayOfWeek;
                                    while (nextwateringTimeStart == izklj1 || nextwateringTimeStart == izklj2 || nextwateringTimeStart == izklj3 || nextwateringTimeStart == izklj4 || nextwateringTimeStart == izklj5 || nextwateringTimeStart == izklj6 || nextwateringTimeStart == izklj7)
                                    {
                                        nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                        nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                        dan = nextwateringTimeStart.DayOfWeek;
                                    }
                                }
                            }

                            if (izklj1 != old || izklj2 != old || izklj3 != old || izklj4 != old || izklj5 != old || izklj6 != old || izklj7 != old)
                            {
                                
                                while (nextwateringTimeStart.Date == izklj1.Date || nextwateringTimeStart.Date == izklj2.Date || nextwateringTimeStart.Date == izklj3.Date || nextwateringTimeStart.Date == izklj4.Date || nextwateringTimeStart.Date == izklj5.Date || nextwateringTimeStart.Date == izklj6.Date || nextwateringTimeStart.Date == izklj7.Date)
                                {

                                    nextwateringTimeStart = nextwateringTimeStart.AddDays(1);
                                    nextwateringTimeStop = nextwateringTimeStop.AddDays(1);
                                }
                            }
                            label4.Text = nextwateringTimeStart.ToString("HH:mm  dd/MM/yyyy");
                            konecNamakanja_lbl.Text = nextwateringTimeStop.ToString("HH:mm  dd/MM/yyyy");


                        }

                        /*if (DateTime.Now >= konec1)
                        {

                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                            while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                            {
                                nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);

                            }
                        }*/

                   

                    






                    if (!variables.pon_zelenica && !variables.tor_zelenica && !variables.sre_zelenica && !variables.cet_zelenica && !variables.pet_zelenica && !variables.sob_zelenica && !variables.ned_zelenica)
                    {
                        konecNamakanja_lbl.Text = "Vsi dnevi v tednu so izključeni!";
                    }
                    else if (!variables.int1_zel && !variables.int2_zel && !variables.int3_zel && !variables.int4_zel)
                    {
                        konecNamakanja_lbl.Text = "Izključeni so vsi intervali!";
                    }

                }
                //Ura namakanja po avtomatiki
                else if ((btn_varcno.BackColor.ToString() == "Color [Aqua]") || (btn_optimalno.BackColor.ToString() == "Color [Aqua]") || (btn_intenzivno.BackColor.ToString() == "Color [Aqua]"))
                {

                    DateTime konec = nextWatteringTimeZelenica.Date;
                    //MessageBox.Show(Convert.ToString(konec));
                    konec = konec.AddHours(Convert.ToDouble(variables.DO_H_zelenica));
                    konec = konec.AddMinutes(Convert.ToDouble(variables.DO_M_zelenica));


                    if (DateTime.Now >= konec)
                    {

                        nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);
                        while (nextWatteringTimeZelenica == izklj1 || nextWatteringTimeZelenica == izklj2 || nextWatteringTimeZelenica == izklj3 || nextWatteringTimeZelenica == izklj4 || nextWatteringTimeZelenica == izklj5 || nextWatteringTimeZelenica == izklj6 || nextWatteringTimeZelenica == izklj7)
                        {
                            nextWatteringTimeZelenica = nextWatteringTimeZelenica.AddDays(1);

                        }
                    }
                    DateTime zacetek = nextWatteringTimeZelenica;
                    zacetek = zacetek.AddHours(Convert.ToDouble(variables.OD_H_avtomatika));
                    zacetek = zacetek.AddMinutes(Convert.ToDouble(variables.OD_M_avtomatika));

                    label4.Text = zacetek.ToString("HH:mm  dd/MM/yyyy");

                    finishTime_calculation();
                    konec = nextWatteringTimeZelenica.Date;
                    //MessageBox.Show(Convert.ToString(konec));
                    konec = konec.AddHours(Convert.ToDouble(variables.DO_H_zelenica));
                    konec = konec.AddMinutes(Convert.ToDouble(variables.DO_M_zelenica));
                    konecNamakanja_lbl.Text = konec.ToString("HH:mm  dd/MM/yyyy");


                }


            }
            else
            {
                label4.Text = "Preklopi v avtomatiko!";
                konecNamakanja_lbl.Text = "Preklopi v avtomatiko!";
            }

        }

        public void calculate_start_time_vrt()
        {
            if ((btn_avtomatika.BackColor.ToString() == "Color [LightGreen]"))
            {

                DateTime danes = DateTime.Today;
                DateTime izklj1, izklj2, izklj3, izklj4, izklj5, izklj6, izklj7;
                DateTime old = DateTime.Parse("2008-05-01T07:34:42-5:00");


                if (variables.chosendate_zelenica != "") { izklj1 = DateTime.Parse(variables.chosendate_zelenica); }
                else { izklj1 = old; }
                if (variables.chosendate_zelenica2 != "") { izklj2 = DateTime.Parse(variables.chosendate_zelenica2); }
                else { izklj2 = old; }
                if (variables.chosendate_zelenica3 != "") { izklj3 = DateTime.Parse(variables.chosendate_zelenica3); }
                else { izklj3 = old; }
                if (variables.chosendate_zelenica4 != "") { izklj4 = DateTime.Parse(variables.chosendate_zelenica4); }
                else { izklj4 = old; }
                if (variables.chosendate_zelenica5 != "") { izklj5 = DateTime.Parse(variables.chosendate_zelenica5); }
                else { izklj5 = old; }
                if (variables.chosendate_zelenica6 != "") { izklj6 = DateTime.Parse(variables.chosendate_zelenica6); }
                else { izklj6 = old; }
                if (variables.chosendate_zelenica7 != "") { izklj7 = DateTime.Parse(variables.chosendate_zelenica7); }
                else { izklj7 = old; }


                if (izklj1 != old || izklj2 != old || izklj3 != old || izklj4 != old || izklj5 != old || izklj6 != old || izklj7 != old)
                {
                    while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);

                    }
                }
                DayOfWeek dan = nextWatteringTimeVrt.DayOfWeek;

                if (dan == DayOfWeek.Monday)
                {
                    if (variables.pon_vrt == true) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Tuesday)
                {
                    if (variables.tor_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Wednesday)
                {
                    if (variables.sre_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Thursday)
                {
                    if (variables.cet_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Friday)
                {
                    if (variables.pet_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Saturday)
                {
                    if (variables.sob_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Sunday)
                {
                    if (variables.ned_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }

                if (variables.chosendate_zelenica != "") { izklj1 = DateTime.Parse(variables.chosendate_zelenica); }
                else { izklj1 = old; }
                if (variables.chosendate_zelenica2 != "") { izklj2 = DateTime.Parse(variables.chosendate_zelenica2); }
                else { izklj2 = old; }
                if (variables.chosendate_zelenica3 != "") { izklj3 = DateTime.Parse(variables.chosendate_zelenica3); }
                else { izklj3 = old; }
                if (variables.chosendate_zelenica4 != "") { izklj4 = DateTime.Parse(variables.chosendate_zelenica4); }
                else { izklj4 = old; }
                if (variables.chosendate_zelenica5 != "") { izklj5 = DateTime.Parse(variables.chosendate_zelenica5); }
                else { izklj5 = old; }
                if (variables.chosendate_zelenica6 != "") { izklj6 = DateTime.Parse(variables.chosendate_zelenica6); }
                else { izklj6 = old; }
                if (variables.chosendate_zelenica7 != "") { izklj7 = DateTime.Parse(variables.chosendate_zelenica7); }
                else { izklj7 = old; }

                if (dan == DayOfWeek.Monday)
                {
                    if (variables.pon_vrt == true) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Tuesday)
                {
                    if (variables.tor_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Wednesday)
                {
                    if (variables.sre_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Thursday)
                {
                    if (variables.cet_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Friday)
                {
                    if (variables.pet_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Saturday)
                {
                    if (variables.sob_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Sunday)
                {
                    if (variables.ned_vrt) { }
                    else
                    {
                        nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                        dan = nextWatteringTimeVrt.DayOfWeek;
                        while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                        }
                    }
                }


                DateTime konec_vrt = nextWatteringTimeVrt.Date;
                DateTime zacetek_vrt = nextWatteringTimeVrt.Date;
                //DateTime nextwateringTimeStop = nextWatteringTimeVrt.Date;

                konec_vrt = konec_vrt.AddHours(Convert.ToDouble(variables.vrt_DO_H));
                konec_vrt = konec_vrt.AddMinutes(Convert.ToDouble(variables.vrt_DO_M));

                zacetek_vrt = zacetek_vrt.AddHours(Convert.ToDouble(variables.vrt_OD_H));
                zacetek_vrt = zacetek_vrt.AddMinutes(Convert.ToDouble(variables.vrt_OD_M));

                //MessageBox.Show(Convert.ToString(zacetek_vrt));

                if (konec_vrt > DateTime.Now)
                {
                    //MessageBox.Show("Manjši");
                    konec_vrt = nextWatteringTimeVrt;
                    zacetek_vrt = nextWatteringTimeVrt;

                    konec_vrt = konec_vrt.AddHours(Convert.ToDouble(variables.vrt_DO_H));
                    konec_vrt = konec_vrt.AddMinutes(Convert.ToDouble(variables.vrt_DO_M));

                    zacetek_vrt = zacetek_vrt.AddHours(Convert.ToDouble(variables.vrt_OD_H));
                    zacetek_vrt = zacetek_vrt.AddMinutes(Convert.ToDouble(variables.vrt_OD_M));

                    

                }
                else
                {
                    //MessageBox.Show("Večji");
                    nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                    dan = nextWatteringTimeVrt.DayOfWeek;
                    if (dan == DayOfWeek.Monday)
                    {
                        if (variables.pon_vrt == true) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Tuesday)
                    {
                        if (variables.tor_vrt) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Wednesday)
                    {
                        if (variables.sre_vrt) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Thursday)
                    {
                        if (variables.cet_vrt) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Friday)
                    {
                        if (variables.pet_vrt) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Saturday)
                    {
                        if (variables.sob_vrt) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Sunday)
                    {
                        if (variables.ned_vrt) { }
                        else
                        {
                            nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                            dan = nextWatteringTimeVrt.DayOfWeek;
                            while (nextWatteringTimeVrt == izklj1 || nextWatteringTimeVrt == izklj2 || nextWatteringTimeVrt == izklj3 || nextWatteringTimeVrt == izklj4 || nextWatteringTimeVrt == izklj5 || nextWatteringTimeVrt == izklj6 || nextWatteringTimeVrt == izklj7)
                            {
                                nextWatteringTimeVrt = nextWatteringTimeVrt.AddDays(1);
                                dan = nextWatteringTimeVrt.DayOfWeek;
                            }
                        }
                    }
                    konec_vrt = nextWatteringTimeVrt;
                    zacetek_vrt = nextWatteringTimeVrt;

                    konec_vrt = konec_vrt.AddHours(Convert.ToDouble(variables.vrt_DO_H));
                    konec_vrt = konec_vrt.AddMinutes(Convert.ToDouble(variables.vrt_DO_M));

                    zacetek_vrt = zacetek_vrt.AddHours(Convert.ToDouble(variables.vrt_OD_H));
                    zacetek_vrt = zacetek_vrt.AddMinutes(Convert.ToDouble(variables.vrt_OD_M));

                   

                    
                    
                }
            }
            else
            {

                
            }
            if (!variables.pon_vrt && !variables.tor_vrt && !variables.sre_vrt && !variables.cet_vrt && !variables.pet_vrt && !variables.sob_vrt && !variables.ned_vrt)
            {
                
            }
        }

        public void calculate_start_time_kapljicno()
        {
            if ((btn_avtomatika.BackColor.ToString() == "Color [LightGreen]"))
            {

                DateTime danes = DateTime.Today;
                DateTime izklj1, izklj2, izklj3, izklj4, izklj5, izklj6, izklj7;
                DateTime old = DateTime.Parse("2008-05-01T07:34:42-5:00");


                if (variables.chosendate_zelenica != "") { izklj1 = DateTime.Parse(variables.chosendate_zelenica); }
                else { izklj1 = old; }
                if (variables.chosendate_zelenica2 != "") { izklj2 = DateTime.Parse(variables.chosendate_zelenica2); }
                else { izklj2 = old; }
                if (variables.chosendate_zelenica3 != "") { izklj3 = DateTime.Parse(variables.chosendate_zelenica3); }
                else { izklj3 = old; }
                if (variables.chosendate_zelenica4 != "") { izklj4 = DateTime.Parse(variables.chosendate_zelenica4); }
                else { izklj4 = old; }
                if (variables.chosendate_zelenica5 != "") { izklj5 = DateTime.Parse(variables.chosendate_zelenica5); }
                else { izklj5 = old; }
                if (variables.chosendate_zelenica6 != "") { izklj6 = DateTime.Parse(variables.chosendate_zelenica6); }
                else { izklj6 = old; }
                if (variables.chosendate_zelenica7 != "") { izklj7 = DateTime.Parse(variables.chosendate_zelenica7); }
                else { izklj7 = old; }


                if (izklj1 != old || izklj2 != old || izklj3 != old || izklj4 != old || izklj5 != old || izklj6 != old || izklj7 != old)
                {
                    while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);

                    }
                }
                DayOfWeek dan = nextWatteringTimeKapljicno.DayOfWeek;

                if (dan == DayOfWeek.Monday)
                {
                    if (variables.pon_kapljicno == true) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Tuesday)
                {
                    if (variables.tor_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Wednesday)
                {
                    if (variables.sre_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Thursday)
                {
                    if (variables.cet_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Friday)
                {
                    if (variables.pet_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Saturday)
                {
                    if (variables.sob_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Sunday)
                {
                    if (variables.ned_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }

                if (variables.chosendate_zelenica != "") { izklj1 = DateTime.Parse(variables.chosendate_zelenica); }
                else { izklj1 = old; }
                if (variables.chosendate_zelenica2 != "") { izklj2 = DateTime.Parse(variables.chosendate_zelenica2); }
                else { izklj2 = old; }
                if (variables.chosendate_zelenica3 != "") { izklj3 = DateTime.Parse(variables.chosendate_zelenica3); }
                else { izklj3 = old; }
                if (variables.chosendate_zelenica4 != "") { izklj4 = DateTime.Parse(variables.chosendate_zelenica4); }
                else { izklj4 = old; }
                if (variables.chosendate_zelenica5 != "") { izklj5 = DateTime.Parse(variables.chosendate_zelenica5); }
                else { izklj5 = old; }
                if (variables.chosendate_zelenica6 != "") { izklj6 = DateTime.Parse(variables.chosendate_zelenica6); }
                else { izklj6 = old; }
                if (variables.chosendate_zelenica7 != "") { izklj7 = DateTime.Parse(variables.chosendate_zelenica7); }
                else { izklj7 = old; }

                if (dan == DayOfWeek.Monday)
                {
                    if (variables.pon_kapljicno == true) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Tuesday)
                {
                    if (variables.tor_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Wednesday)
                {
                    if (variables.sre_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Thursday)
                {
                    if (variables.cet_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Friday)
                {
                    if (variables.pet_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Saturday)
                {
                    if (variables.sob_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }
                if (dan == DayOfWeek.Sunday)
                {
                    if (variables.ned_kapljicno) { }
                    else
                    {
                        nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                        dan = nextWatteringTimeKapljicno.DayOfWeek;
                        while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                        }
                    }
                }


                DateTime konec_kapljicno = nextWatteringTimeKapljicno.Date;
                DateTime zacetek_kapljicno = nextWatteringTimeKapljicno.Date;
                //DateTime nextwateringTimeStop = nextWatteringTimeKapljicno.Date;

                konec_kapljicno = konec_kapljicno.AddHours(Convert.ToDouble(variables.kapljicno_DO_H));
                konec_kapljicno = konec_kapljicno.AddMinutes(Convert.ToDouble(variables.kapljicno_DO_M));

                zacetek_kapljicno = zacetek_kapljicno.AddHours(Convert.ToDouble(variables.kapljicno_OD_H));
                zacetek_kapljicno = zacetek_kapljicno.AddMinutes(Convert.ToDouble(variables.kapljicno_OD_M));

                //MessageBox.Show(Convert.ToString(zacetek_kapljicno));

                if (konec_kapljicno > DateTime.Now)
                {
                    //MessageBox.Show("Manjši");
                    konec_kapljicno = nextWatteringTimeKapljicno;
                    zacetek_kapljicno = nextWatteringTimeKapljicno;

                    konec_kapljicno = konec_kapljicno.AddHours(Convert.ToDouble(variables.kapljicno_DO_H));
                    konec_kapljicno = konec_kapljicno.AddMinutes(Convert.ToDouble(variables.kapljicno_DO_M));

                    zacetek_kapljicno = zacetek_kapljicno.AddHours(Convert.ToDouble(variables.kapljicno_OD_H));
                    zacetek_kapljicno = zacetek_kapljicno.AddMinutes(Convert.ToDouble(variables.kapljicno_OD_M));

                    //KAPLJICNOstartWattering.Text = zacetek_kapljicno.ToString("HH:mm  dd/MM/yyyy");
                    //KAPLJICNOstopWattering.Text = konec_kapljicno.ToString("HH:mm  dd/MM/yyyy");

                }
                else
                {
                    //MessageBox.Show("Večji");
                    nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                    dan = nextWatteringTimeKapljicno.DayOfWeek;
                    
                    if (dan == DayOfWeek.Monday)
                    {
                        if (variables.pon_kapljicno == true) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Tuesday)
                    {
                        if (variables.tor_kapljicno) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Wednesday)
                    {
                        if (variables.sre_kapljicno) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Thursday)
                    {
                        if (variables.cet_kapljicno) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Friday)
                    {
                        if (variables.pet_kapljicno) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Saturday)
                    {
                        if (variables.sob_kapljicno) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    if (dan == DayOfWeek.Sunday)
                    {
                        if (variables.ned_kapljicno) { }
                        else
                        {
                            nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                            dan = nextWatteringTimeKapljicno.DayOfWeek;
                            while (nextWatteringTimeKapljicno == izklj1 || nextWatteringTimeKapljicno == izklj2 || nextWatteringTimeKapljicno == izklj3 || nextWatteringTimeKapljicno == izklj4 || nextWatteringTimeKapljicno == izklj5 || nextWatteringTimeKapljicno == izklj6 || nextWatteringTimeKapljicno == izklj7)
                            {
                                nextWatteringTimeKapljicno = nextWatteringTimeKapljicno.AddDays(1);
                                dan = nextWatteringTimeKapljicno.DayOfWeek;
                            }
                        }
                    }
                    konec_kapljicno = nextWatteringTimeKapljicno;
                    zacetek_kapljicno = nextWatteringTimeKapljicno;

                    konec_kapljicno = konec_kapljicno.AddHours(Convert.ToDouble(variables.kapljicno_DO_H));
                    konec_kapljicno = konec_kapljicno.AddMinutes(Convert.ToDouble(variables.kapljicno_DO_M));

                    zacetek_kapljicno = zacetek_kapljicno.AddHours(Convert.ToDouble(variables.kapljicno_OD_H));
                    zacetek_kapljicno = zacetek_kapljicno.AddMinutes(Convert.ToDouble(variables.kapljicno_OD_M));

                    //KAPLJICNOstartWattering.Text = zacetek_kapljicno.ToString("HH:mm  dd/MM/yyyy");
                    //KAPLJICNOstopWattering.Text = konec_kapljicno.ToString("HH:mm  dd/MM/yyyy");
                }
            }
            else
            {

                //KAPLJICNOstartWattering.Text = "Preklopi v avtomatiko!";
                //KAPLJICNOstopWattering.Text = "Preklopi v avtomatiko!";
            }

            if (!variables.pon_kapljicno && !variables.tor_kapljicno && !variables.sre_kapljicno && !variables.cet_kapljicno && !variables.pet_kapljicno && !variables.sob_kapljicno && !variables.ned_kapljicno)
            {

                //KAPLJICNOstartWattering.Text = "Vsi dnevi v tednu so izključeni!";
                //KAPLJICNOstopWattering.Text = "Vsi dnevi v tednu so izključeni!";
            }
        }

        private void vrt_int1_odH_check()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<vrt_T1>");

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
        private void vrt_int1_odM_check()
        {
            //MessageBox.Show("zel_int1_odM_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<vrt_T2>");

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
        private void vrt_int1_doH_check()
        {
            // MessageBox.Show("zel_int1_doH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<vrt_T3>");

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
        private void vrt_int1_doM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<vrt_T4>");

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

        private void vrt_pon_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<PONV_ch>");

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
        private void vrt_tor_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TORV_ch>");

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
        private void vrt_sre_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SREV_ch>");

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
        private void vrt_cet_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<CETV_ch>");

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
        private void vrt_pet_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<PETV_ch>");

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
        private void vrt_sob_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SOBV_ch>");

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
        private void vrt_ned_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NEDV_ch>");

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

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void kapljicno_int1_odH_check()
        {
            //MessageBox.Show("zel_int1_odH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<kap_T1>");

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
        private void kapljicno_int1_odM_check()
        {
            //MessageBox.Show("zel_int1_odM_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<kap_T2>");

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
        private void kapljicno_int1_doH_check()
        {
            // MessageBox.Show("zel_int1_doH_check");
            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<kap_T3>");

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
        private void kapljicno_int1_doM_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<kap_T4>");

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
        private void kapljicno_pon_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<PONK_ch>");

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
        private void kapljicno_tor_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<TORK_ch>");

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
        private void kapljicno_sre_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SREK_ch>");

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
        private void kapljicno_cet_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<CETK_ch>");

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
        private void kapljicno_pet_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<PETK_ch>");

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
        private void kapljicno_sob_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<SOBK_ch>");

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
        private void kapljicno_ned_check()
        {

            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NEDK_ch>");

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
