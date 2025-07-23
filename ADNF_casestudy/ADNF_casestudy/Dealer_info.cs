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
    public partial class Dealer_info : Form
    {
        public Dealer_info()
        {
            InitializeComponent();
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

        public static bool Validations2(String str)
        {
            //Only numbers are allowed here
            bool output = true;

            String regex2 = "[^0-9]+";

            Regex rgex2 = new Regex(regex2);
            if (str == null)
            {
                output = false;
                return output;
            }

            MatchCollection matchedAuthors2 = rgex2.Matches(str);

            if (matchedAuthors2.Count != 0)
            {
                output = false;
                return output;
            }
            else
            {
                return output;
            }
        }
        private void insert_btn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (Validations(textBox1.Text) && Validations2(textBox3.Text) && Validations(textBox5.Text))
                {
                    String q = "insert into Dealer_info values(@dn,@dc,@contact,@address,@city)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@dn", textBox1.Text);
                    cmd.Parameters.AddWithValue("@dc", textBox2.Text);
                    cmd.Parameters.AddWithValue("@contact", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@city", textBox5.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data inserted");
                    display();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else
                {
                    MessageBox.Show("Enter dealer details properly");
                    textBox1.Clear();
                    textBox3.Clear();
                    textBox5.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter all the dealer details");
            }
            
            
        }

        public void display()
        {
            String q = "select * from Dealer_info";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void delete_btn_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String q = "delete from Dealer_info where Id = " + id + "";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            display();
        }

        private void update_sel_btn_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            panel2.Visible = true;

            String q = "select * from Dealer_info where id=" + id + "";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox6.Text = dr["Dealer_name"].ToString();
                textBox7.Text = dr["Dealer_company_name"].ToString();
                textBox8.Text = dr["Contact"].ToString();
                textBox9.Text = dr["Address"].ToString();
                textBox10.Text = dr["City"].ToString();
            }
    }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {
                 
                if (Validations(textBox6.Text) && Validations2(textBox8.Text) && Validations(textBox10.Text))
                {
                    String q = "update dealer_info set Dealer_name=@dn,Dealer_company_name=@dc,Contact=@contact,Address=@address,City=@city where id=" + id + "";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@dn", textBox6.Text);
                    cmd.Parameters.AddWithValue("@dc", textBox7.Text);
                    cmd.Parameters.AddWithValue("@contact", textBox8.Text);
                    cmd.Parameters.AddWithValue("@address", textBox9.Text);
                    cmd.Parameters.AddWithValue("@city", textBox10.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Dealer details updated");
                    display();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                }
                else
                {
                    MessageBox.Show("Enter dealer details properly");
                    
                }
            }
            else
            {
                MessageBox.Show("Enter all the dealer details");
            } 
        }
    }
}
