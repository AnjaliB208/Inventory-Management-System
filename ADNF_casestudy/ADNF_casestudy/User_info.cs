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
    public partial class User_info : Form
    {
        public User_info()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");

        private void User_info_Load(object sender, EventArgs e)
        {
            String q1 = "select Firstname,Lastname,Email from User_Detail";
            
            SqlCommand cmd1 = new SqlCommand(q1, con);
            
            con.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            
            while (sdr1.Read())
            {
                label4.Text = sdr1[0].ToString();
                label5.Text = sdr1[1].ToString();
                label6.Text = sdr1[2].ToString();
            }
           
            con.Close();
        }
    }
}
