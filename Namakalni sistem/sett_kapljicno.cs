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
    public partial class sett_kapljicno : Form
    {
        bool startup = true;
        public sett_kapljicno()
        {
            
            variables.form1shown = false;
            InitializeComponent();

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


            string kapljicno_OD_H = variables.kapljicno_OD_H;
            string kapljicno_OD_M = variables.kapljicno_OD_M;
            string kapljicno_DO_H = variables.kapljicno_DO_H;
            string kapljicno_DO_M = variables.kapljicno_DO_M;

            comboBox1_OD_H.Text = kapljicno_OD_H;
            comboBox1_OD_M.Text = kapljicno_OD_M;
            comboBox1_DO_H.Text = kapljicno_DO_H;
            comboBox1_DO_M.Text = kapljicno_DO_M;

            Sum_interval1_time_FUNC();

            excludet_date_1_check();
            excludet_date_2_check();
            excludet_date_3_check();
            excludet_date_4_check();
            excludet_date_5_check();
            excludet_date_6_check();
            excludet_date_7_check();

            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;

            startup = false;
            Cursor.Current = Cursors.Default;
        }

        private void btn_preberi_zel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            
            excludet_date_1_check();
            excludet_date_2_check();
            excludet_date_3_check();
            excludet_date_4_check();
            excludet_date_5_check();
            excludet_date_6_check();
            excludet_date_7_check();



            //Interval
            string P_OD_H = variables.kapljicno_OD_H;
            string P_OD_M = variables.kapljicno_OD_M;
            string P_DO_H = variables.kapljicno_DO_H;
            string P_DO_M = variables.kapljicno_DO_M;
            
           
            comboBox1_OD_H.Text = P_OD_H;
            comboBox1_OD_M.Text = P_OD_M;
            comboBox1_DO_H.Text = P_DO_H;
            comboBox1_DO_M.Text = P_DO_M;

            

            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;
            Cursor.Current = Cursors.Default;
            //MessageBox.Show("Osveženo");
        }
       
        private void save_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            variables.kapljicno_OD_H = comboBox1_OD_H.Text;
            variables.kapljicno_OD_M = comboBox1_OD_M.Text;
            variables.kapljicno_DO_H = comboBox1_DO_H.Text;
            variables.kapljicno_DO_M = comboBox1_DO_M.Text;

            
            
            /*
            string startTime1 = variables.P_OD_H + ": " + variables.P_OD_M;
            string endTime1 = variables.P_DO_H + ": " + variables.P_DO_M;
            string startTime2 = variables.D_OD_H + ": " + variables.D_OD_M;
            string endTime2 = variables.D_DO_H + ": " + variables.D_DO_M;
            string startTime3 = variables.T_OD_H + ": " + variables.T_OD_M;
            string endTime3 = variables.T_DO_H + ": " + variables.T_DO_M;
            string startTime4 = variables.S_OD_H + ": " + variables.S_OD_M;
            string endTime4 = variables.S_DO_H + ": " + variables.S_DO_M;

            //TimeSpan duration1 = DateTime.Parse(endTime4).Subtract(DateTime.Parse(startTime1));
            TimeSpan duration2 = DateTime.Parse(endTime1).Subtract(DateTime.Parse(startTime2));
            TimeSpan duration3 = DateTime.Parse(endTime2).Subtract(DateTime.Parse(startTime3));
            TimeSpan duration4 = DateTime.Parse(endTime3).Subtract(DateTime.Parse(startTime4));

            //double minutes1 = duration1.TotalMinutes;
            double minutes2 = duration2.TotalMinutes;
            double minutes3 = duration3.TotalMinutes;
            double minutes4 = duration4.TotalMinutes;


            if (duration2.TotalMinutes >= 0)
            {

                MessageBox.Show("Začetek 2. intervala je znotraj 1. intervala!");
            }
            

            if ((duration2.TotalMinutes < 0) && (duration3.TotalMinutes < 0) && (duration4.TotalMinutes < 0))
            {
                */
                send_kapljicno_odH();
                send_kapljicno_odM();
                send_kapljicno_doH();
                send_kapljicno_doM();

                send_PON_BOX();
                send_TOR_BOX();
                send_SRE_BOX();
                send_CET_BOX();
                send_PET_BOX();
                send_SOB_BOX();
                send_NED_BOX();
                
                send_IZ_ZEL_1_BOX();
                send_IZ_ZEL_2_BOX();
                send_IZ_ZEL_3_BOX();
                send_IZ_ZEL_4_BOX();
                send_IZ_ZEL_5_BOX();
                send_IZ_ZEL_6_BOX();
                send_IZ_ZEL_7_BOX();
                kapljicno_pon_check();
                kapljicno_tor_check();
                kapljicno_sre_check();
                kapljicno_cet_check();
                kapljicno_pet_check();
                kapljicno_sob_check();
                kapljicno_ned_check();
                send_check_signal();
                Form1 home = new Form1(); // Instantiate a Form3 object.
                home.Show(); // Show Form3 and
                this.Hide();
                Cursor.Current = Cursors.Default;
                //MessageBox.Show("Poslano");
           // }
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

        private void save_date_btn_Click_1(object sender, EventArgs e)
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

        private void remove_date_btn_Click_1(object sender, EventArgs e)
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

        //Preverjanje časov shranjenih na kontrolerju
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

        //Pošiljanje novih časov na kontroler
        private void send_kapljicno_odH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NTK_1>" + variables.kapljicno_OD_H);

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
        private void send_kapljicno_odM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NTK_2>" + variables.kapljicno_OD_M);

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
        private void send_kapljicno_doH()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NTK_3>" + variables.kapljicno_DO_H);

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
        private void send_kapljicno_doM()
        {


            byte[] packetData5 = System.Text.ASCIIEncoding.ASCII.GetBytes("<NTK_4>" + variables.kapljicno_DO_M);

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
                SendData = "<PONK>ON";
                variables.pon_kapljicno = true;
            }
            else
            {
                SendData = "<PONK>OFF";
                variables.pon_kapljicno = false;
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
                SendData = "<TORK>ON";
                variables.tor_kapljicno = true;
            }
            else
            {
                SendData = "<TORK>OFF";
                variables.tor_kapljicno = false;
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
                SendData = "<SREK>ON";
                variables.sre_kapljicno = true;
            }
            else
            {
                SendData = "<SREK>OFF";
                variables.sre_kapljicno = false;
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
                SendData = "<CETK>ON";
                variables.cet_kapljicno = true;
            }
            else
            {
                SendData = "<CETK>OFF";
                variables.cet_kapljicno = false;
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
                SendData = "<PETK>ON";
                variables.pet_kapljicno = true;
            }
            else
            {
                SendData = "<PETK>OFF";
                variables.pet_kapljicno = false;
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
                SendData = "<SOBK>ON";
                variables.sob_kapljicno = true;
            }
            else
            {
                SendData = "<SOBK>OFF";
                variables.sob_kapljicno = false;
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
                SendData = "<NEDK>ON";
                variables.ned_kapljicno = true;
            }
            else
            {
                SendData = "<NEDK>OFF";
                variables.ned_kapljicno = false;
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

        public void Sum_interval1_time_FUNC()
        {
            variables.kapljicno_OD_H = comboBox1_OD_H.Text;
            variables.kapljicno_OD_M = comboBox1_OD_M.Text;
            variables.kapljicno_DO_H = comboBox1_DO_H.Text;
            variables.kapljicno_DO_M = comboBox1_DO_M.Text;

            string startTime = variables.kapljicno_OD_H + ": " + variables.kapljicno_OD_M;
            string endTime = variables.kapljicno_DO_H + ": " + variables.kapljicno_DO_M;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            Sum_interval1_time.Text = Convert.ToString(duration);
        }

        public void UDPListener()
        {
            variables.udpfree = false;

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

                        if (tokens[1] == "ON") { checkBox_PON_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_PON_Z.Checked = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<TORK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_TOR_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_TOR_Z.Checked = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SREK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_SRE_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_SRE_Z.Checked = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    
                    else if (received_data.Contains("<CETK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_CET_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_CET_Z.Checked = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<PETK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_PET_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_PET_Z.Checked = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<SOBK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_SOB_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_SOB_Z.Checked = false; }

                        //Console.WriteLine(tokens[1]);

                    }
                    else if (received_data.Contains("<NEDK>") == true)
                    {
                        string myString = received_data;

                        string[] tokens = myString.Split('>');

                        if (tokens[1] == "ON") { checkBox_NED_Z.Checked = true; }
                        else if (tokens[1] == "OFF") { checkBox_NED_Z.Checked = false; }


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

                    else
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
                variables.udpfree = true;
            }
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

        private void upravljalnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void intervaliVentilovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veje_sett home = new Veje_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void časovnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sett_zelenica home = new sett_zelenica(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void btn_preberi_zel_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            
            excludet_date_1_check();
            excludet_date_2_check();
            excludet_date_3_check();
            excludet_date_4_check();
            excludet_date_5_check();
            excludet_date_6_check();
            excludet_date_7_check();



            //Interval 1 zelenica
            string P_OD_H = variables.kapljicno_OD_H;
            string P_OD_M = variables.kapljicno_OD_M;
            string P_DO_H = variables.kapljicno_DO_H;
            string P_DO_M = variables.kapljicno_DO_M;



            comboBox1_OD_H.Text = P_OD_H;
            comboBox1_OD_M.Text = P_OD_M;
            comboBox1_DO_H.Text = P_DO_H;
            comboBox1_DO_M.Text = P_DO_M;


            izkljuceni_datumi_zelen_1.Text = variables.chosendate_zelenica;
            izkljuceni_datumi_zelen_2.Text = variables.chosendate_zelenica2;
            izkljuceni_datumi_zelen_3.Text = variables.chosendate_zelenica3;
            izkljuceni_datumi_zelen_4.Text = variables.chosendate_zelenica4;
            izkljuceni_datumi_zelen_5.Text = variables.chosendate_zelenica5;
            izkljuceni_datumi_zelen_6.Text = variables.chosendate_zelenica6;
            izkljuceni_datumi_zelen_7.Text = variables.chosendate_zelenica7;
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Osveženo");
        }

        private void comboBox1_OD_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum_interval1_time_FUNC();
                
            }
        }

        private void comboBox1_OD_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum_interval1_time_FUNC();

            }
        }

        private void comboBox1_DO_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum_interval1_time_FUNC();

            }
        }

        private void comboBox1_DO_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                Sum_interval1_time_FUNC();

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void iPKontrolerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            config fconfig = new config();
            fconfig.ShowDialog();

            //this.Close();
            
        }

        private void iZHODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void živaMejaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            sett_vrt fconfig = new sett_vrt();
            fconfig.ShowDialog();
        }

        private void domovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        private void avtomatikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avtomatika_sett home = new avtomatika_sett(); // Instantiate a Form3 object.
            home.Show(); // Show Form3 and
            this.Hide();
        }

        
    }
}
