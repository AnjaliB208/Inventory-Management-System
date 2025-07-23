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
    public partial class Order_detail_report : Form
    {
        public Order_detail_report()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");

        private void view_all_btn_Click(object sender, EventArgs e)
        {

            decimal i = 0;
            String q = "select * from Order_Item oi left join Order_user ou on oi.Order_id = ou.Id";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            String q1 = "select Total from Order_Item oi left join Order_user ou on oi.Order_id = ou.Id";
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
            if (comboBox1.Text != "")
            {
                decimal i = 0;
                String q = "select * from Order_Item i left join Order_user u on i.Order_id = u.Id where u.Bill_type = '" + (comboBox1.SelectedItem).ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                String q1 = "select Total from Order_Item oi left join Order_user ou on oi.Order_id = ou.Id";
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
            else
            {
                MessageBox.Show("Select Bill type");
            }
        }
    }
}
