using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace pharmacie_logecial
{
    public partial class Form3 : Form
    {
        int yy;
        public Form3(int l)
        {
            nb=l;
            InitializeComponent();
            affichepnrml();
            lang(l);
            panel1.Visible=false;
            yy=l;


           



        }
        int jb,valid;
        private void drr()
        {
            try
            {
                Con.Open();
              
                string rqq = " select  j_b from produitdanger where num= '" + cle + "'";
                SqlCommand cmm = new SqlCommand(rqq, Con);
                SqlDataReader drr;
                drr = cmm.ExecuteReader();
                if (drr.Read() == false)
                {

                    MessageBox.Show("svp verifiez le nom de client  ");
                    Con.Close();
                }
                else
                {
                   
                    jb = drr.GetInt32(0);
                    drr.Close();
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
                
            }
        }
        private void date()
        {


            try
            {
                
                Con.Open();
                string rq = " select  date from client where id= '" + id.Text + "'";
                SqlCommand cm = new SqlCommand(rq, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read() == false)
                {

                    MessageBox.Show("svp verifiez le nom de client  ");
                    Con.Close();
                }
                else
                {
                    DateTime Tcl = dr.GetDateTime(0);
                    dr.Close();
                    Con.Close();
                    drr();

                    DateTime now = DateTime.Now;
                    var def = now-Tcl;
                    int jeur = (int)def.TotalDays;
                   
                    if (jb>=jeur)
                    {
                        valid=0;
                        MessageBox.Show("Ce client n'a pas été autorisé à acheter plus de ce médicament");

                    }
                    else
                        valid=1;


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
        private void lang(int l)
        {
            if (l==1)
            {
                label9.Text="        إدارة الصيدلة    ";
                label2.Text="          اسم منتج ";
               label1.Text="  كمية مستهلكة"; 
                button2.Text = "التعديل في مخزن";
                button1.Text = "استهلاك";
                a1.Text="           ادخل معلومات الزبون";
                a3.Text="              اسم الزبون";
                a2.Text="  رقم تعريف الزبون";
                a4.Text="          تسجيل الزبون جديد";
                button3.Text = "تحقق";
              
            }

        }
       private void Alart(String m)
        {
            Form4 r = new Form4(m);
            r.ShowDialog();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");
       
        private void affichepnrml()
        {
          
            Con.Open();
            string req = " select * from TTable ";
            SqlDataAdapter adapter = new SqlDataAdapter(req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var d = new DataSet();
            adapter.Fill(d);
            Na.DataSource = d.Tables[0];
            Con.Close();


        }
        private void affichepdang()
        {

            Con.Open();
            string req = " select * from produitdanger ";
            SqlDataAdapter adapter = new SqlDataAdapter(req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var d = new DataSet();
            adapter.Fill(d);
            Na.DataSource = d.Tables[0];
            Con.Close();


        }
        int cle;
        string m ;
        int b = 0;
        string nomm = "null", nom1 = "nul";

    
        public void verifies()
        {
            try
            {
                Con.Open();
                string req = " select  * from client where id= '"+id.Text+"'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;

               
                dr = cm.ExecuteReader();
             
                if (id.Text == "" || nom.Text == "")

                {
                    MessageBox.Show("entre le nom et id slvp");
                    b=1;
                    Con.Close();
                }

                else if (dr.Read() == false)
                {
                    MessageBox.Show("svp verifiez les informations  ");
                    b=1;
                    Con.Close();
                }
                else
                {
                    nomm=   dr.GetString(1);

                    nom1=  nom.Text;
                    Con.Close();
                    date();

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
        private void panel()
        {
            panel1.Visible=true;
            Quen.Visible=false;
            button1.Visible=false;
            label1.Visible=false;
        }
        private void recherchepdang()
        {

            if (cle == 0)
            {
                Con.Open();
                string req = " select  * from produitdanger where nom= '" + T.Text + "'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (dr.Read() == false)
                {
                     button7.BackColor=Color.Gray;
                    MessageBox.Show("svp verifiez le nom de produit  ");
                    button7.BackColor=Color.WhiteSmoke;

                }
                   


                else
                {
                    cle = dr.GetInt32(0);

                    e = dr.GetInt32(3);
                    button7.BackColor=Color.MediumTurquoise;
                    panel();

                }



                dr.Close();
                Con.Close();
            }
        }
        private void recherchepnrml()
        {

            if (cle == 0)
            {
                Con.Open();
                string req = " select  * from TTable where nom= '" + T.Text + "'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
              
                if (dr.Read() == false)
                {
                    Con.Close();
                    recherchepdang();
                }
                   


                else
                {
                    cle = dr.GetInt32(0);

                    e = dr.GetInt32(3);
                    button7.BackColor=Color.MediumTurquoise;
                }



                dr.Close();
                Con.Close();
            }
        }
        private void Na_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            T.Text = Na.SelectedRows[0].Cells[1].Value.ToString();

            cle = Convert.ToInt32(Na.SelectedRows[0].Cells[0].Value.ToString());

        }
        private void Reinialisation()
        {
            T.Text = "";
            Quen.Text = "";
            e = 0;
            cle = 0;
        }
        int e = 0, q, s;
        private void we()
        {
            if (e == 0)
                e = Convert.ToInt32(Na.SelectedRows[0].Cells[3].Value.ToString());



            q = Convert.ToInt32(Quen.Text);
            s = e - q;
            Quen.Text = s.ToString();
            if (s <= 5)
                if (yy==1)
                {
                    m = "   على وشك النفاذ "+T.Text+"  تنبيه كمية الدواء ";
                }
                else
                    m = "Votre produit "+ T.Text+"a atteint la limite maximale,\n vous devez vérifier la quantité du produit .";
                


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void consomq(int a)
        {

            Con.Open();

            DateTime date = DateTime.Now;
            MessageBox.Show(" ;;"+cle);
         
            string Reqq = " Update Tq set  q='" + q + "' ,date ='" + date + "' ,nom='"+T.Text+"' where idd = '" + cle + "' ";
            SqlCommand cmmd = new SqlCommand(Reqq, Con);
            cmmd.ExecuteNonQuery();
            MessageBox.Show(" produit ajoute avec succes");

            Con.Close();

        }
        private void cass()
        {
            int a = 4;
            Con.Open();
            string rq = " select  * from client where nom= '" + a + "'";
            SqlCommand cm = new SqlCommand(rq, Con);
            SqlDataReader dr;
            dr = cm.ExecuteReader();
           string ab = dr.GetString(1);
            MessageBox.Show(" produit ajoute avec succes"+a);
            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {



         
            if (cle == 0)
                MessageBox.Show(" selectionnez un produit  Svp ");
            else
            {
           
                if (cas==0)
                {
                    try
                    {
                        Con.Open();
                        we();

                        if (s < 0)
                        {
                            MessageBox.Show("svp verifiez la quentite");
                            Con.Close();
                        }
                        else
                        {
                            string Req = " Update TTable set quantité ='" + s + "'  where num ='" + cle + "'  ";
                            SqlCommand cmd = new SqlCommand(Req, Con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(" produit modifiez  avec succes nv Q est :" + s);

                            Con.Close();

                            affichepnrml();

                            if (s <= 5)
                                Alart(m);
                            Reinialisation();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
           else
              {if (valid==1)
                    {
                        try
                        {
                            Con.Open();
                            we();

                            if (s < 0)
                                MessageBox.Show("svp verifiez la quentite");
                            else
                            {
                                string Req = " Update produitdanger set quantité ='" + s + "'  where num ='" + cle + "'  ";
                                SqlCommand cmd = new SqlCommand(Req, Con);
                                cmd.ExecuteNonQuery();
                                DateTime date = DateTime.Now;
                                string Reqq = " Update client set date ='" + date + "'  where num ='" + id.Text + "'  ";
                                SqlCommand cmdd = new SqlCommand(Reqq, Con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show(" produit modifiez  avec succes nv Q est :" + s);

                                Con.Close();
                                id.Text="";
                                nom.Text="";
                                cas=0;

                                affichepdang();

                                if (s <= 5)
                                    Alart(m);
                                Reinialisation();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Ce client n'a pas été autorisé à acheter plus de ce médicament");
                    }


                }

            }

        }
        int nb;

        private void T_TextChanged(object sender, EventArgs e)
        {

        }
        int cas=0;
        private void button3_Click(object sender, EventArgs e)
        {
            verifies();


            if (nomm!=nom1 && b==0)
                MessageBox.Show(" verifies le id   Svp ");
            else if (nomm==nom1)
            {
                b=0;
                nomm="null";
                nom1="nul";
                Quen.Visible=true;
                button1.Visible=true;
                panel1.Visible=false;
                label1.Visible=true;
                cas=1;
                affichepdang();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
            Quen.Visible=true;
            label1.Visible=true;
            button1.Visible=true;
            button7.BackColor=Color.WhiteSmoke;
            T.Text="";
              
            cle=0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            client a = new client(yy);
            a.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cle!=0)
            {
               
                cle=0;
                button7.BackColor=Color.WhiteSmoke;
                T.Text="";
            }
           else
            recherchepnrml();
        }

        private void kll ( int l)
        {
            Close();
            Form5 conn = new Form5(l);
            conn.ShowDialog(); 



        }
       private void button2_Click(object sender, EventArgs e)
        {
            kll(nb);
           
        }
    }


}