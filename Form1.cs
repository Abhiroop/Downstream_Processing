using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String x, y, z, w, a, b, c, d, k, f, g, h;
            
            double linear_velocity_cap, linear_velocity_int, linear_velocity_pol;
            double p1,p2,p3,p4,p5;
            double time_centrifugation;
            double pc1, rbc2, rbc4, rbc5, frc, ifrc, pfrc,sy1,sy2,sy3,sy4,sy5,lc2,la2,r2,lv2,ncyc2,ncyc2peryear;
            double time_equilibration_4_cv,time_loading,time_washing,time_elution_3_cv;
            double time_regen_2_cv,timepercycle,time_capture;
            double load_ppn, run_time,pc3,pv3,r4;
            double la4, lc4, lv4, ncyc4, ncyc4peryear, time_elution_10_cv, timepercycle_inter,time_inter,vol,pc4;
            double r5,lc5,la5,lv5,load_per_cycle,ncyc5,ncyc5peryear, load_volume,timepercycle_pol,time_pol;
            double time_temp, batches_per_year_temp, product_temp, revenue_temp,saleprice;
            double revenue,time,harvest_final,binding_capacity_final,flow_rate_capture_final,inter_binding_capacity_final,int_flow_rate_final,polishing_binding_capacity_final,pol_flow_rate_final,harvest_volume_final,product_final,batches_per_year;
            revenue = 0;
            time=0;
            harvest_final=0;
            binding_capacity_final=0;
            flow_rate_capture_final=0;
            inter_binding_capacity_final=0;
            int_flow_rate_final=0;
            polishing_binding_capacity_final=0;
            pol_flow_rate_final=0;
            harvest_volume_final=0;
            product_final=0;
            batches_per_year = 0;
            r2 = 0;
            r4 = 0;
            r5 = 0;
            sy2 = 0;
            sy4 = 0;
            sy5 = 0;
            saleprice =100;
            
            double h1 = double.Parse(textBox31.Text);    ///harvest volume
            double pc1ub = double.Parse(textBox1.Text);
            double pc1lb = double.Parse(textBox5.Text);
            double pc1inc = double.Parse(textBox9.Text);
            double rbc2ub = double.Parse(textBox2.Text);
            double rbc2lb = double.Parse(textBox6.Text);
            double rbc2inc = double.Parse(textBox10.Text);
            double rbc4ub = double.Parse(textBox3.Text);
            double rbc4lb = double.Parse(textBox7.Text);
            double rbc4inc = double.Parse(textBox11.Text);
            double rbc5ub = double.Parse(textBox4.Text);
            double rbc5lb = double.Parse(textBox8.Text);
            double rbc5inc = double.Parse(textBox12.Text);
            double frcub = double.Parse(textBox13.Text);
            double frclb = double.Parse(textBox14.Text);
            double frcinc = double.Parse(textBox15.Text);
            double ifrcub = double.Parse(textBox16.Text);
            double ifrclb = double.Parse(textBox17.Text);
            double ifrcinc = double.Parse(textBox18.Text);
            double pfrcub = double.Parse(textBox19.Text);
            double pfrclb = double.Parse(textBox20.Text);
            double pfrcinc = double.Parse(textBox21.Text);
            double no_of_cycles_capture_upper = double.Parse(textBox22.Text);
            double no_of_cycles_capture_lower = double.Parse(textBox23.Text);
            double no_of_cycles_int_upper = double.Parse(textBox24.Text);
            double no_of_cycles_int_lower = double.Parse(textBox25.Text);
            double no_of_cycles_pol_upper = double.Parse(textBox26.Text);
            double no_of_cycles_pol_lower = double.Parse(textBox27.Text);

            double t1 = 24 * (double.Parse(textBox32.Text));                ///harvest time
            for (pc1 = pc1lb; pc1 <= pc1ub; pc1 += pc1inc)
            {

                p1 = h1 * pc1;

                ///Step Process 1 : Centrifugation
                
                
                sy1 = 0.95;
                p2 = sy1 * p1 ;
                time_centrifugation = 2;


                ///Step Process 2 : Capture
                
                
                if (h1 <= 4)
                {
                    r2 = 0.02;
                }
                if (h1 > 4 && h1 <= 10)
                {
                    r2 = 0.375;
                }
                if (h1 > 10 && h1 <= 100)
                {
                    r2 = 0.5;
                }
                lc2 = p2 / h1;
                for (rbc2 = rbc2lb; rbc2 <= rbc2ub; rbc2 += rbc2inc)
                {
                    la2 = r2 * rbc2;
                    lv2 = la2 / lc2;
                    ncyc2 = p2 / la2;
                    ncyc2peryear = (ncyc2 * 365) / (t1 / 24);
                    for (frc = frclb; frc <= frcub; frc += frcinc)
                    {
                        
                        linear_velocity_cap = frc * 1000/(3.1*0.8*0.8);
                        time_equilibration_4_cv = 4 * r2 / frc;
                        time_loading = lv2 / frc;
                        time_washing = 4 * r2 / frc;
                        time_elution_3_cv  = 3 * r2 / frc;
                        time_regen_2_cv = 2 * r2 / frc;
                        timepercycle = time_equilibration_4_cv + time_loading + time_washing + time_elution_3_cv + time_regen_2_cv;
                        time_capture = timepercycle * ncyc2;
                        sy2 = calc_percent_yield(rbc2,linear_velocity_cap,1);
                        p2 = p2 * sy2;


                        ///Step Process 3 : Filtration
                        
                        sy3 = 0.95;
                        p3 = sy3 * p2;
                        load_ppn = 1;
                        run_time = 3;
                        pc3 = 4;
                        pv3 = p3 / pc3;


                        ///Step Process 4 : Intermediate
                        

                        if (h1 <= 4)
                        {
                            r4 = 0.02;
                        }
                        if (h1 > 4 && h1 <= 10)
                        {
                            r4 = 0.375;
                        }
                        if (h1 > 10 && h1 <= 100)
                        {
                            r4 = 0.5;
                        }
                        for (rbc4 = rbc4lb; rbc4 <= rbc4ub; rbc4 += rbc4inc)
                        {
                            la4 = r4 * rbc4;
                            lc4 = pc3;
                            lv4 = la4 / lc4;
                            ncyc4 = p3 / la4;
                            ncyc4peryear = (ncyc4 * 365) / (t1 / 24);
                            for (ifrc = ifrclb; ifrc <= ifrcub; ifrc += ifrcinc)
                            {
                                linear_velocity_int = ifrc  * 1000/(3.1*0.8*0.8);
                                time_equilibration_4_cv = 4 * r4 / ifrc;
                                time_loading = lv4 / ifrc;
                                time_washing = 4 * r4 / ifrc;
                                time_elution_10_cv = 10 * r4 / ifrc;
                                time_regen_2_cv = 2 * r4 / ifrc;
                                timepercycle_inter = time_equilibration_4_cv + time_loading + time_washing + time_elution_10_cv + time_regen_2_cv;
                                time_inter = timepercycle_inter * ncyc4;
                                sy4 = calc_percent_yield(rbc4,linear_velocity_int,2);
                                p4 = sy4 * p3;
                                vol = 0.6;    ///0.6 can be changed
                                pc4 = p4 / vol;


                                ///Step Process 5 : Polishing

                                for (rbc5 = rbc5lb; rbc5 <= rbc5ub; rbc5 += rbc5inc)
                                {
                                    if (h1 <= 4)
                                    {
                                        r5 = 0.02;
                                    }
                                    if (h1 > 4 && h1 <= 10)
                                    {
                                        r5 = 0.375;
                                    }
                                    if (h1 > 10 && h1 <= 100)
                                    {
                                        r5 = 0.5;
                                    }
                                    lc5 = pc4;
                                    lv5 = vol;
                                    la5 = lc5 * lv5;
                                    load_per_cycle = r5 * rbc5;
                                    ncyc5 = la5 / load_per_cycle;
                                    load_volume = load_per_cycle / lc5;
                                    ncyc5peryear = (ncyc5 * 365) / (t1 / 24);
                                    for (pfrc = pfrclb; pfrc <= pfrcub; pfrc += pfrcinc)
                                    {
                                        linear_velocity_pol=pfrc * 1000/(3.1*0.8*0.8);
                                        time_equilibration_4_cv = 4 * r5 / pfrc;
                                        time_loading = load_volume / pfrc;
                                        time_washing = 4 * r5 / pfrc;
                                        time_elution_10_cv = 10 * r5 / pfrc;
                                        time_regen_2_cv = 2 * r5 / pfrc;
                                        timepercycle_pol = time_equilibration_4_cv + time_loading + time_washing + time_elution_10_cv + time_regen_2_cv;
                                        time_pol = timepercycle_pol * ncyc5;
                                        sy5 = calc_percent_yield(rbc5,linear_velocity_pol,3);
                                        p5 = sy5 * p4;


                                        ///Final Calculations

                                        time_temp = time_pol + time_capture + time_inter + t1 + run_time + time_centrifugation;
                                        batches_per_year_temp = 365 * 24 / time_temp;
                                        product_temp = p5;
                                        revenue_temp = product_temp * batches_per_year_temp * saleprice; ///Sale Price taken as 100$
                                        if ((ncyc2peryear >= no_of_cycles_capture_lower) && (ncyc2peryear <= no_of_cycles_capture_upper))
                                        {
                                            if ((ncyc4peryear >= no_of_cycles_int_lower) && (ncyc4peryear <= no_of_cycles_int_upper))
                                            {
                                                if ((ncyc5peryear >= no_of_cycles_pol_lower) && (ncyc5peryear <= no_of_cycles_pol_upper))
                                                {
                                                    if (revenue_temp >= revenue)
                                                    {
                                                        time = time_temp;
                                                        revenue = revenue_temp;
                                                        harvest_final = pc1;
                                                        binding_capacity_final = rbc2;
                                                        flow_rate_capture_final = frc;
                                                        inter_binding_capacity_final = rbc4;
                                                        int_flow_rate_final = ifrc;
                                                        polishing_binding_capacity_final = rbc5;
                                                        pol_flow_rate_final = pfrc;
                                                        harvest_volume_final = h1;
                                                        product_final = product_temp;
                                                        batches_per_year = batches_per_year_temp;

                                                        
                                                        ///Residence Time Calculation
                                                        
                                                        ///Capture
                                                        /*if (linear_velocity_cap >= 90 && linear_velocity_cap <= 100)
                                                        {
                                                            res_time_cap_lb = 50;
                                                            res_time_cap_ub = 60;
                                                        }
                                                        if (linear_velocity_cap >= 80 && linear_velocity_cap < 90)
                                                        {
                                                            res_time_cap_lb = 60;
                                                            res_time_cap_ub = 70;
                                                        }
                                                        if (linear_velocity_cap >= 70 && linear_velocity_cap < 80)
                                                        {
                                                            res_time_cap_lb = 70;
                                                            res_time_cap_ub = 80;
                                                        }
                                                        if (linear_velocity_cap >= 60 && linear_velocity_cap < 70)
                                                        {
                                                            res_time_cap_lb = 80;
                                                            res_time_cap_ub = 90;
                                                        }
                                                        if (linear_velocity_cap >= 50 && linear_velocity_cap <= 60)
                                                        {
                                                            res_time_cap_lb = 90;
                                                            res_time_cap_ub = 100;
                                                        }
                                                        if (linear_velocity_cap >= 40 && linear_velocity_cap <= 50)
                                                        {
                                                            res_time_cap_lb = 100;
                                                            res_time_cap_ub = 110;
                                                        }
 
                                                        ///Intermediate
                                                        if (linear_velocity_int >= 70 && linear_velocity_int < 80)
                                                        {
                                                            res_time_int_lb = 20;
                                                            res_time_int_ub = 22;
                                                        } 
                                                        if (linear_velocity_int >= 60 && linear_velocity_int < 70)
                                                        {
                                                            res_time_int_lb = 22;
                                                            res_time_int_ub = 25;
                                                        }
                                                        if (linear_velocity_int >= 50 && linear_velocity_int <= 60)
                                                        {
                                                            res_time_int_lb = 25;
                                                            res_time_int_ub = 27;
                                                        } 
                                                        if (linear_velocity_int >= 40 && linear_velocity_int <= 50)
                                                        {
                                                            res_time_int_lb = 28;
                                                            res_time_int_ub = 30;
                                                        }

                                                        ///Polishing
                                                        if (linear_velocity_pol >= 70 && linear_velocity_pol <= 80)
                                                        {
                                                            res_time_pol_lb = 5;
                                                            res_time_pol_ub = 7;
                                                        }
                                                        if (linear_velocity_pol >= 60 && linear_velocity_pol <= 70)
                                                        {
                                                            res_time_pol_lb = 7;
                                                            res_time_pol_ub = 9;
                                                        }
                                                        if (linear_velocity_pol >= 50 && linear_velocity_pol <= 60)
                                                        {
                                                            res_time_pol_lb = 9;
                                                            res_time_pol_ub = 10;
                                                        }
                                                        if (linear_velocity_pol >= 40 && linear_velocity_pol <= 50)
                                                        {
                                                            res_time_pol_lb = 10;
                                                            res_time_pol_ub = 11;
                                                        } */


                                                        ///CAPTURING ITERATIONS

                                                        x = harvest_final.ToString();
                                                        y = binding_capacity_final.ToString();
                                                        z = inter_binding_capacity_final.ToString();
                                                        w = polishing_binding_capacity_final.ToString();
                                                        a = flow_rate_capture_final.ToString();
                                                        b = int_flow_rate_final.ToString();
                                                        c = pol_flow_rate_final.ToString();
                                                        d = harvest_volume_final.ToString();
                                                        k = time.ToString();
                                                        f = batches_per_year.ToString();
                                                        g = product_final.ToString();
                                                        h = revenue.ToString();
                                                        
                                                        ///initialize connection
                                                       /* MySqlConnection connection;
                                                        string server;
                                                        string database;
                                                        string uid;
                                                        string password;

                                                        ///connecting
                                                        server = "localhost";
                                                        database = "downstream";
                                                        uid = "root";
                                                        password = "password";
                                                        string connectionString;
                                                        connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                                                        connection = new MySqlConnection(connectionString);
                                                        connection.Open();


                                                        string query = "INSERT INTO dsp (harvest,cap_binding_capacity,int_binding_capacity,pol_binding_capacity,cap_flow_rate,int_flow_rate,pol_flow_rate,harvest_volume,min_harvest_time,batches_per_year,products_per_batch,revenue) VALUES(@harvest,@cap_binding_capacity,@int_binding_capacity,@pol_binding_capacity,@cap_flow_rate,@int_flow_rate,@pol_flow_rate,@harvest_volume,@min_harvest_time,@batches_per_year,@products_per_batch,@revenue)";

                                                        MySqlCommand cmd = new MySqlCommand(query, connection);
                                                        cmd.Parameters.Add("@harvest", MySqlDbType.VarChar).Value = x ;
                                                        cmd.Parameters.Add("@cap_binding_capacity", MySqlDbType.VarChar).Value = y ;
                                                        cmd.Parameters.Add("@int_binding_capacity", MySqlDbType.VarChar).Value = z ;
                                                        cmd.Parameters.Add("@pol_binding_capacity", MySqlDbType.VarChar).Value = w ;
                                                        cmd.Parameters.Add("@cap_flow_rate", MySqlDbType.VarChar).Value = a ;
                                                        cmd.Parameters.Add("@int_flow_rate", MySqlDbType.VarChar).Value = b ;
                                                        cmd.Parameters.Add("@pol_flow_rate", MySqlDbType.VarChar).Value = c ;
                                                        cmd.Parameters.Add("@harvest_volume", MySqlDbType.VarChar).Value = d ;
                                                        cmd.Parameters.Add("@min_harvest_time", MySqlDbType.VarChar).Value = k ;
                                                        cmd.Parameters.Add("@batches_per_year", MySqlDbType.VarChar).Value = f ;
                                                        cmd.Parameters.Add("@products_per_batch", MySqlDbType.VarChar).Value = g ;
                                                        cmd.Parameters.Add("@revenue", MySqlDbType.VarChar).Value = h ;
                                                        cmd.ExecuteNonQuery();*/


                                                    }
                                                }
                                            }
                                        }
                                    }                     

                                }                                
                        
                            }

                        }                      
                        

                    }

                }           
                              
             }
            Form2 e1 = new Form2(revenue,time, harvest_final, binding_capacity_final, flow_rate_capture_final, inter_binding_capacity_final, int_flow_rate_final, polishing_binding_capacity_final, pol_flow_rate_final, harvest_volume_final, product_final, batches_per_year);
            e1.Show();
        }
        public double calc_percent_yield(double binding_capacity,double linear_velocity,int number)
        {

                double ft10;
                if (number == 1)
                {
                    ft10 = double.Parse(textBox28.Text);
                    if (linear_velocity >= 90 && linear_velocity <= 100)
                        return 0.95;
                    else if ((binding_capacity <= (0.8 * ft10) + 3) || (linear_velocity > 80 && linear_velocity <= 90))
                        return 0.9;
                    else if ((binding_capacity >= (ft10 * 0.85) - 3 && binding_capacity <= (0.85 * ft10) + 3) || (linear_velocity > 70 && linear_velocity <= 80))
                        return 0.85;
                    else if (binding_capacity >= (ft10 * 0.9) - 3 && binding_capacity <= (0.9 * ft10) + 3)
                        return 0.8;
                    else if (binding_capacity > ft10 * 0.9)
                        return 0.8;
                    else return 0;
                }
                if (number == 2)
                {
                    ft10 = double.Parse(textBox29.Text);
                    if (binding_capacity <= (0.8 * ft10) + 3)
                        return 0.8;
                    else if (binding_capacity >= (ft10 * 0.85) - 3 && binding_capacity <= (0.85 * ft10) + 3)
                        return 0.75;
                    else if (binding_capacity >= (ft10 * 0.9) - 3 && binding_capacity <= (0.9 * ft10) + 3)
                        return 0.7;
                    else if (binding_capacity > ft10 * 0.9)
                        return 0.7;
                    else return 0;
                }
                if (number == 3)
                {
                    ft10 = double.Parse(textBox30.Text);
                    if (linear_velocity > 70 && linear_velocity <= 80)
                        return 0.85;
                    else if ((binding_capacity < (0.8 * ft10) + 0.4) || (linear_velocity > 60 && linear_velocity <= 70))
                        return 0.80;
                    else if (binding_capacity >= (ft10 * 0.85) - 0.4 && binding_capacity < (0.85 * ft10) + 0.4 || (linear_velocity > 50 && linear_velocity <= 60))
                        return 0.75;
                    else if (binding_capacity >= (ft10 * 0.9) - 0.4 && binding_capacity < (0.9 * ft10) + 0.4)
                        return 0.70;
                    else if (binding_capacity > ft10 * 0.9)
                        return 0.7;
                    else return 0;
                }
                else return 0;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
