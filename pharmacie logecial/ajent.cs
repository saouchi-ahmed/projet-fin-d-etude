﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pharmacie_logecial
{
    public partial class ajent : Form
    {
        public ajent(int l)
        {
            InitializeComponent();
            lang(l);
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");

        private void lang(int l)
        {
            if (l==1)
            {
                a1.Text="                      تسجيل صيدلي جديد";
                a2.Text="         رقم تعريف صيدلي";
               
                a3.Text="       الكلمة سرية ";
                a4.Text="                      تسجيل باءع جديد";
                a5.Text="       رقم تعريف باءع";
                a6.Text="             الاسم باءع";
                button2.Text="تسجيل";
                button4.Text="حذف";
                button5.Text="تسجيل";
                button1.Text="حذف";
          


            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ph1.Text == "" || ph2.Text == "")
                MessageBox.Show("Complitez les informations Svp ");
            else
            {
                try
                {
                    Con.Open();


                    string Req = " insert into responsable values('" +ph1.Text+ "','" +ph2.Text+ "') ";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" les informations ajoute avec succes.");
                    Con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();

                }
            }
            ph1.Text="";
            ph2.Text="";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        string R = "e";

      
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();


                string Req = " delete from responsable where id = "+ph1.Text+"  ";
                SqlCommand cmd = new SqlCommand(Req, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" la pharmacien supprime  avec succes");

                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            ph1.Text="";
            ph2.Text="";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (v1.Text == "" || v2.Text == "")
                MessageBox.Show("Complitez les informations Svp ");
            else
            {
                try
                {
                    Con.Open();


                    string Req = " insert into lesemployes values('" +v2.Text+ "','" +v1.Text+ "') ";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" les informations ajoute avec succes.");
                    Con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();

                }
            }
            v1.Text="";
            v2.Text="";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();


                string Req = " delete from lesemployes where id = "+v2.Text+"  ";
                SqlCommand cmd = new SqlCommand(Req, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" le vendeur supprime  avec succes");

                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            v1.Text="";
            v2.Text="";
        }

        private void l6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void v2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ajent_Load(object sender, EventArgs e)
        {

        }
    }
}