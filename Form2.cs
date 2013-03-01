using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        string grevenue, gtime, gharvest_final, gbinding_capacity_final, gflow_rate_capture_final, ginter_binding_capacity_final, gint_flow_rate_final, gpolishing_binding_capacity_final, gpol_flow_rate_final, gharvest_volume_final, gproduct_final, gbatches_per_year;
        public Form2(double revenue, double time, double harvest_final, double binding_capacity_final, double flow_rate_capture_final, double inter_binding_capacity_final,double int_flow_rate_final, double polishing_binding_capacity_final, double pol_flow_rate_final, double harvest_volume_final, double product_final, double batches_per_year)
        {
            InitializeComponent();
            grevenue = revenue.ToString();
            gtime = time.ToString();
            gharvest_final = harvest_final.ToString();
            gbinding_capacity_final = binding_capacity_final.ToString();
            gflow_rate_capture_final = flow_rate_capture_final.ToString();
            ginter_binding_capacity_final = inter_binding_capacity_final.ToString();
            gint_flow_rate_final = int_flow_rate_final.ToString();
            gpolishing_binding_capacity_final = polishing_binding_capacity_final.ToString();
            gpol_flow_rate_final = pol_flow_rate_final.ToString();
            gharvest_volume_final = harvest_volume_final.ToString();
            gproduct_final = product_final.ToString();
            gbatches_per_year = batches_per_year.ToString();
      
           }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                textBox1.Text = gharvest_final;
                textBox11.Text = gbinding_capacity_final;
                textBox12.Text = ginter_binding_capacity_final;
                textBox2.Text = gpolishing_binding_capacity_final;
                textBox3.Text = gflow_rate_capture_final;
                textBox4.Text = gint_flow_rate_final;
                textBox5.Text = gpol_flow_rate_final;
                textBox6.Text = gharvest_volume_final;
                textBox7.Text = gtime;
                textBox8.Text = gbatches_per_year;
                textBox9.Text = gproduct_final;
                textBox10.Text = grevenue;
                /*textBox13.Text = gres_time_cap_lb;
                textBox14.Text = gres_time_cap_ub;
                textBox15.Text = gres_time_int_lb;
                textBox16.Text = gres_time_int_ub;
                textBox17.Text = gres_time_pol_lb; 
                textBox18.Text = gres_time_pol_ub;*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
