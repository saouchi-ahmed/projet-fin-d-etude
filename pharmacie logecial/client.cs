using System;
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
    public partial class client : Form
    {
        public client(int y)
        {
            InitializeComponent();
            panel(1);
            lang(y);

        }
        private void lang(int l)
        {
            if (l==1)
            {
                a7.Text="                      تسجيل عميل جديد";
                a1.Text="رقم تعريف الزبون  ";
                a2.Text="اللقب";
                a3.Text="       الاسم ";
                a4.Text="   عنوان";
                a5.Text="                رقم الهاتف";
                a6.Text="                      رقم وصفة الطبية";
                button5.Text="تسجيل";
                button1.Text="حذف";
                m1.Text="                                  معلومات الطبيب";
                m2.Text="              صاحب الوصفة الطبية";
                m3.Text="رقم تعريف الطبيب     ";
                m4.Text="اللقب";
                m5.Text="       الاسم";
                m6.Text="              عنوان الطبيب";
                m7.Text="               رقم الهاتف";
                m8.Text="تخصص الطبيب";
            


            }

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");
        int v;
        private void button5_Click(object sender, EventArgs e)
        {if (v==1)
            {
                if (pnc.Text == "" || idc.Text == ""||nc.Text == "" || ac.Text == ""||nmc.Text == "" || oc.Text == "")
                    MessageBox.Show("Complitez les informations Svp ");
                else
                {
                    try
                    {
                        Con.Open();

                        DateTime a = DateTime.Now;
                        string Req = " insert into client values('" +idc.Text+ "','" +nc.Text+ "','" +a+ "','" +pnc.Text+ "','" +nmc.Text+ "','" +oc.Text+ "','" +ac.Text+ "') ";
                        SqlCommand cmd = new SqlCommand(Req, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" les informations ajoute avec succes.");
                        Con.Close();
                        v=1;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Con.Close();

                    }
                }
           
            }
        else
            { MessageBox.Show("Vous devez vérifier si le médecin est un faux ou non"); }
            pnc.Text="";
            idc.Text="";
            nc.Text="";
            oc.Text="";
            nmc.Text="";
            ac.Text="";
            pm.Text="";
            idm.Text="";
            nm.Text="";
            spm.Text="";
            nmm.Text="";
            am.Text="";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ( idc.Text == "")
                MessageBox.Show("entre le id du client  Svp ");
            else
            {
                try
                {
                    Con.Open();


                    string Req = " delete from client where id = "+idc.Text+"  ";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" le client supprime  avec succes");

                    Con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                }
                pnc.Text="";
                idc.Text="";
                nc.Text="";
                oc.Text="";
                nmc.Text="";
                ac.Text="";

            }
        }

        private void panel(int l)
        {
            if (l==1)
            {
                m6.Visible=false;
                m7.Visible=false;
                m8.Visible=false;
                am.Visible=false;
                spm.Visible=false;
                nmm.Visible=false;
                pm.Text="";
                idm.Text="";
                nm.Text="";
                spm.Text="";
                nmm.Text="";
                am.Text="";
                panel1.BackColor=Color.WhiteSmoke;
                button2.BackColor=Color.MediumTurquoise; 

            }
            else if (l==2)
            {
                m6.Visible=true;
                m7.Visible=true;
                m8.Visible=true;
                am.Visible=true;
                spm.Visible=true;
                nmm.Visible=true;
                panel1.BackColor=Color.MediumTurquoise;
            
             


            }
            else if (l==3)

            {
                /*
                m3.Visible=false;
                m4.Visible=false;
                m8.Visible=false;
                am.Visible=false;
                spm.Visible=false;
                nmm.Visible=false;*/
                panel1.BackColor=Color.OrangeRed;
                button2.BackColor=Color.OrangeRed;



            }
         }
        private void client_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void pm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void nm_TextChanged(object sender, EventArgs e)
        {

        }
        string nom, prenom, nom1, prenom1;

        private void label13_Click_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m1_Click(object sender, EventArgs e)
        {

        }

        int id,id1,b=0,a=0;
        public void verifies()
        {
            try
            {      a=1;
                Con.Open();
                string req = " select  * from medcin where id= '"+idm.Text+"'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;


                dr = cm.ExecuteReader();

                if (idm.Text == "" || nm.Text == ""|| pm.Text == "")

                {
                    MessageBox.Show("entre les information du medcin slvp");
                    a=0;
                    b=1;
                    Con.Close();
                }

                else if (dr.Read() == false)
                {
                    panel(3);
                    MessageBox.Show(" Ce médecin n'est pas enregistré dans le centre de données");


                    b=1;
                    Con.Close();
                }
                else
                {
                    id=   dr.GetInt32(0);
                    nom=   dr.GetString(1);
                    prenom=  dr.GetString(2);
                    id1=    Convert.ToInt32( idm.Text);
                    nom1=  nm.Text;
                    prenom1=  pm.Text;
                   
                    if (nom!=nom1&& prenom!=prenom1 && id!=id1&& b==0)
                    {
                        panel(3);
                        MessageBox.Show(" Ce médecin n'est pas enregistré dans le centre de données");

                    }
                    else if ( id==id1)
                    {
                        b=0;
                        nom="null";
                        nom1="nul";
                        prenom="null";
                        prenom1="nul";

                        idm.Text=Convert.ToString(   id);
                        nm.Text=dr.GetString(1);
                        pm.Text=dr.GetString(2);
                        int nummm;
                        nummm=dr.GetInt32(3);
                        nmm.Text=Convert.ToString(nummm);
                        am.Text=dr.GetString(4);
                        spm.Text=dr.GetString(5);
                        panel(2);
                        id=0;
                        id1=1;
                        v=1;


                    }
                    

                }



                dr.Close();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();

            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (a==1)
            {
                a=0;
                panel(1);
            }
            else
            verifies();
        }
    }
}
