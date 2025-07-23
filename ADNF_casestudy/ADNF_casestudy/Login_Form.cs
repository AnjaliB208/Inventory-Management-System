using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADNF_casestudy
{
    public partial class Login_Form : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");
        public Login_Form()
        {

            InitializeComponent();
            details_fetch();
            textBox1.Text = null;
            textBox2.Text = null;
        }

        void details_fetch()
        {
            String q = "select Username,Password from User_detail";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                name = sdr[0].ToString();
                pw = sdr[1].ToString();
            }
            con.Close();
        }
        String name,pw;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                if (textBox1.Text != name && textBox2.Text != pw)
                {
                    MessageBox.Show("Username and Password Invalid");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else if (textBox1.Text!=name)
                {
                    MessageBox.Show("Username Invalid");
                    textBox1.Clear();
                }
                else if(textBox2.Text != pw)
                {
                    MessageBox.Show("Password Invalid");
                    textBox2.Clear();
                }
                else
                {
                    this.Hide();
                    Home h = new Home();
                    h.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter credentials");
            }
        }
    }
}
