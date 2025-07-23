using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADNF_casestudy
{
    public partial class Modify_Products : Form
    {
        public Modify_Products()
        {
            InitializeComponent();
            fill_cbox();
            display();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");
        public static bool Validations(String str)
        {
            //Only alphabets are allowed here
            bool output = true;
            String regex1 = "[^a-zA-Z ]+";

            Regex rgex1 = new Regex(regex1);

            if (str == null)
            {
                output = false;
                return output;
            }
            MatchCollection matchedAuthors1 = rgex1.Matches(str);

            if (matchedAuthors1.Count != 0)
            {
                output = false;
                return output;
            }
            else
            {
                return output;
            }
        }
        void fill_cbox()
        {
            String q = "select unit from Units";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                comboBox1.Items.Add(sdr[0].ToString());
                comboBox2.Items.Add(sdr[0].ToString());

            }
            con.Close();
        }

        public void display()
        {
            String q = "select * from Product_name";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void insert_btn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && comboBox1.Text != "")
            {
                if (Validations(textBox1.Text))
                {
                    String q = "insert into Product_name values(@product,@unit)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@product", textBox1.Text);
                    cmd.Parameters.AddWithValue("@unit", comboBox1.SelectedItem);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data inserted");
                    textBox1.Clear();
                    comboBox1.ResetText();
                    display();
                }
                else
                {
                    MessageBox.Show("Enter Product name properly");
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter all product details");
            }
            
            
        }
        int i;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            

            String q1 = "select * from Product_name where id = '"+i+"'";
            SqlDataAdapter sda1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            sda1 .Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                textBox2.Text = dr1["Product_name"].ToString();
                comboBox2.SelectedItem = dr1["Unit"].ToString();
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && comboBox2.Text != "")
            {    
                if (Validations(textBox2.Text))
                {
                    String q = "update Product_name set Product_name = @product,Unit = @unit where id = '" + i + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@product", textBox2.Text);
                    cmd.Parameters.AddWithValue("@unit", comboBox2.SelectedItem);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data updated");
                    textBox2.Clear();
                    comboBox2.ResetText();
                    display();
                }
                else
                {
                    MessageBox.Show("Enter Product name properly");
                    textBox2.Clear();
                }
            }
                else
                {
                    MessageBox.Show("Enter all product details");
                }
}
    }
}
