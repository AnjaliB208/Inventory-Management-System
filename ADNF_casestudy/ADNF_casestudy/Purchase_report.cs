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
    public partial class Purchase_report : Form
    {
        public Purchase_report()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");

        private void view_all_btn_Click(object sender, EventArgs e)
        {

            decimal i = 0;
            String q = "select * from Purchase_master";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            String q1 = "select Product_total from Purchase_master";
            SqlCommand cmd = new SqlCommand(q1, con);
            
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                i = i + Convert.ToDecimal(sdr[0]);
            }
            con.Close();
            label3.Text = i.ToString();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string start_date, end_date;

            start_date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            end_date = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            decimal i = 0;
            String q = "select * from Purchase_master where Purchase_date>='"+start_date+"' AND Purchase_date<='"+end_date+"'";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            String q1 = "select Product_total from Purchase_master where Purchase_date>='"+start_date +"' AND Purchase_date<='"+end_date+"'";
            SqlCommand cmd = new SqlCommand(q1, con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                i = i + Convert.ToDecimal(sdr[0]);
            }
            con.Close();
            label3.Text = i.ToString();
        } 
    }
}
