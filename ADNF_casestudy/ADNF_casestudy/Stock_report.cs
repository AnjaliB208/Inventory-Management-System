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
    public partial class Stock_report : Form
    {
        public Stock_report()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");

        private void Stock_report_Load(object sender, EventArgs e)
        {
            String q = "select * from Stock";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
