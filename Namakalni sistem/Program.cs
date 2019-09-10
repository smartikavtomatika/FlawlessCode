using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;


namespace Namakalni_sistem
{
    static class Program
    {
     
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1());
            
                       
            //Console.ReadLine();
        }
        
    
    }
    

    public class variables
    {
        public static string IP = "192.168.1.99";
        //public static int PORT = 8888;

        public static string DO_H_zelenica = "01";
        public static string DO_M_zelenica = "01";

        //Interval kapljično
        public static string kapljicno_OD_H = "01";
        public static string kapljicno_OD_M = "01";
        public static string kapljicno_DO_H = "01";
        public static string kapljicno_DO_M = "01";

        //Interval avtomatika
        public static string OD_H_avtomatika = "01";
        public static string OD_M_avtomatika = "01";



        //Interval vrt
        public static string vrt_OD_H = "01";
        public static string vrt_OD_M = "01";
        public static string vrt_DO_H = "01";
        public static string vrt_DO_M = "01";

        //Interval 1 zelenica
        public static string P_OD_H = "01";
        public static string P_OD_M = "01";
        public static string P_DO_H = "01";
        public static string P_DO_M = "01";

        //Interval 2 zelenica
        public static string D_OD_H = "01";
        public static string D_OD_M = "01";
        public static string D_DO_H = "01";
        public static string D_DO_M = "01";

        //Interval 3 zelenica
        public static string T_OD_H = "01";
        public static string T_OD_M = "01";
        public static string T_DO_H = "01";
        public static string T_DO_M = "01";

        //TEST

        //Interval 4 zelenica
        public static string S_OD_H = "01";
        public static string S_OD_M = "01";
        public static string S_DO_H = "01";
        public static string S_DO_M = "01";

        //Intervali ventilov
        public static string ventil1_interval1 = "01";
        public static string ventil2_interval1 = "01";
        public static string ventil3_interval1 = "01";
        public static string ventil4_interval1 = "01";
        public static string ventil5_interval1 = "01";
        public static string ventil6_interval1 = "01";
        public static string ventil7_interval1 = "01";
        public static string ventil8_interval1 = "01";
        public static string ventil9_interval1 = "01";

        public static string ventil1_interval2 = "01";
        public static string ventil2_interval2 = "01";
        public static string ventil3_interval2 = "01";
        public static string ventil4_interval2 = "01";
        public static string ventil5_interval2 = "01";
        public static string ventil6_interval2 = "01";
        public static string ventil7_interval2 = "01";
        public static string ventil8_interval2 = "01";
        public static string ventil9_interval2 = "01";

        public static string ventil1_interval3 = "01";
        public static string ventil2_interval3 = "01";
        public static string ventil3_interval3 = "01";
        public static string ventil4_interval3 = "01";
        public static string ventil5_interval3 = "01";
        public static string ventil6_interval3 = "01";
        public static string ventil7_interval3 = "01";
        public static string ventil8_interval3 = "01";
        public static string ventil9_interval3 = "01";

        public static string ventil1_interval4 = "01";
        public static string ventil2_interval4 = "01";
        public static string ventil3_interval4 = "01";
        public static string ventil4_interval4 = "01";
        public static string ventil5_interval4 = "01";
        public static string ventil6_interval4 = "01";
        public static string ventil7_interval4 = "01";
        public static string ventil8_interval4 = "01";
        public static string ventil9_interval4 = "01";

        public static string ventil1_interval_procenti = "00";
        public static string ventil2_interval_procenti = "00";
        public static string ventil3_interval_procenti = "00";
        public static string ventil4_interval_procenti = "00";
        public static string ventil5_interval_procenti = "00";
        public static string ventil6_interval_procenti = "00";
        public static string ventil7_interval_procenti = "00";
        public static string ventil8_interval_procenti = "00";
        public static string ventil9_interval_procenti = "00";


        public static string chosendate_zelenica = "";
        public static string chosendate_zelenica2="";
        public static string chosendate_zelenica3="";
        public static string chosendate_zelenica4 = "";
        public static string chosendate_zelenica5 = "";
        public static string chosendate_zelenica6 = "";
        public static string chosendate_zelenica7 = "";

        public static int repeat_one_time = 0;

        public static string cas_sistema_ura = "Ni podatka";
        public static string cas_sistema_datum = "Ni podatka";
        

        public static string pc_tima_and_date1 = System.DateTime.Now.ToString("dd.MM.yyyy");
        public static string pc_tima_and_date = System.DateTime.Now.ToString("HH:mm:ss");

        public static int epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

        public static bool controller_connected = false;

        public static bool UDP_WUP = false;
        public static bool startup_firspage = true;
        public static bool form1shown;

        public static bool status_avtomatika;
        public static bool status_manual;
        public static bool status_stop;


        //Izračun skupnega namakanja v določenem intervalu - za izračun intervalov ventilov
        public static int interval1_sum_hours;
        public static int interval2_sum_hours;
        public static int interval3_sum_hours;
        public static int interval4_sum_hours;

        public static int interval1_sum_minutes;
        public static int interval2_sum_minutes;
        public static int interval3_sum_minutes;
        public static int interval4_sum_minutes;

        /*public static double consumption_V1 = 43.2;
        public static double consumption_V2 = 32.4;
        public static double consumption_V3 = 43.2;
        public static double consumption_V4 = 21.6;
        public static double consumption_V5 = 46.2;
        public static double consumption_V6 = 43.2;
        public static double consumption_V7 = 31.6;
        public static double consumption_V8 = 0;
        public static double consumption_V9 = 0;*/

        public static double consumption_sum = 0;

        public static bool ure_shranjene = false;
        public static bool samodejno_shrenjevanje_novih_intervalov = false;

        public static string januar = "Namakanje ni priporočljivo!";
        public static string februar = "Namakanje ni priporočljivo!";
        public static string marec = "00:31";
        public static string april = "00:50";
        public static string maj = "01:12";
        public static string junij = "01:18";
        public static string julij = "01:24";
        public static string avgust = "01:11";
        public static string september = "00:43";
        public static string oktober = "00:24";
        public static string november = "Namakanje ni priporočljivo!";
        public static string december = "Namakanje ni priporočljivo!";

        public static bool udpfree = true;
        public static bool udpfree12014 = true;
        public static bool udpfree11002 = true;

        public static int btn_delay_ms = 1;

        public static bool pon_zelenica;
        public static bool tor_zelenica;
        public static bool sre_zelenica;
        public static bool cet_zelenica;
        public static bool pet_zelenica;
        public static bool sob_zelenica;
        public static bool ned_zelenica;

        public static bool int1_zel;
        public static bool int2_zel;
        public static bool int3_zel;
        public static bool int4_zel;

        public static bool pon_vrt;
        public static bool tor_vrt;
        public static bool sre_vrt;
        public static bool cet_vrt;
        public static bool pet_vrt;
        public static bool sob_vrt;
        public static bool ned_vrt;

        public static bool pon_kapljicno;
        public static bool tor_kapljicno;
        public static bool sre_kapljicno;
        public static bool cet_kapljicno;
        public static bool pet_kapljicno;
        public static bool sob_kapljicno;
        public static bool ned_kapljicno;

        

    }

    
}
