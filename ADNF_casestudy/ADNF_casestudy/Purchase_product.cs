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
    public partial class Purchase_product : Form
    {
        public Purchase_product()
        {
            InitializeComponent();
            fill_cb1();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");
        public void fill_cb1()
        {
            String q1 = "select Product_name from Product_name";
            String q2 = "select Dealer_name from Dealer_info";
            SqlCommand cmd1 = new SqlCommand(q1, con);
            SqlCommand cmd2 = new SqlCommand(q2, con);
            con.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            
            while (sdr1.Read())
            {
                comboBox1.Items.Add(sdr1[0].ToString());
            }

            con.Close();
            
            con.Open();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
           
            while (sdr2.Read())
            {
                comboBox2.Items.Add(sdr2[0].ToString());
            }

            con.Close();
        }
        private void pur_item_btn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if(Validations2(textBox1.Text) && Validations2(textBox2.Text) && Validations2(textBox3.Text) && Validations2(textBox4.Text))
                {
                    int i = 0;
                    decimal qty = Convert.ToDecimal(textBox1.Text);
                    String q = "select Product_qty from stock where Product_name=@pn";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@pn", comboBox1.SelectedItem);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        i++;
                        qty = Convert.ToDecimal((sdr[0]));
                    }
                    con.Close();

                    if (i == 0)
                    {
                        String q1 = "insert into Purchase_master values(@pro_n,@pro_q,@pro_u,@pro_p,@pro_t,@pur_d,@pur_p,@pur_t,@exp_d,@profit)";
                        SqlCommand cmd1 = new SqlCommand(q1, con);
                        cmd1.Parameters.AddWithValue("@pro_n", comboBox1.SelectedItem);
                        cmd1.Parameters.AddWithValue("@pro_q", textBox1.Text);
                        cmd1.Parameters.AddWithValue("@pro_u", label10.Text);
                        cmd1.Parameters.AddWithValue("@pro_p", textBox2.Text);
                        cmd1.Parameters.AddWithValue("@pro_t", textBox3.Text);
                        cmd1.Parameters.AddWithValue("@pur_d", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                        cmd1.Parameters.AddWithValue("@pur_p", comboBox2.SelectedItem);
                        cmd1.Parameters.AddWithValue("@pur_t", comboBox3.SelectedItem);
                        cmd1.Parameters.AddWithValue("@exp_d", dateTimePicker2.Value.ToString("dd-MM-yyyy"));
                        cmd1.Parameters.AddWithValue("@profit", textBox4.Text);

                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        String q2 = "insert into Stock values(@pro_n,@pro_q,@pro_u)";
                        SqlCommand cmd2 = new SqlCommand(q2, con);
                        cmd2.Parameters.AddWithValue("@pro_n", comboBox1.SelectedItem);
                        cmd2.Parameters.AddWithValue("@pro_q", textBox1.Text);
                        cmd2.Parameters.AddWithValue("@pro_u", label10.Text);

                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data inserted");
                    }
                    else
                    {
                        String q3 = "insert into Purchase_master values(@pro_n,@pro_q,@pro_u,@pro_p,@pro_t,@pur_d,@pur_p,@pur_t,@exp_d,@profit)";
                        SqlCommand cmd3 = new SqlCommand(q3, con);
                        cmd3.Parameters.AddWithValue("@pro_n", comboBox1.SelectedItem);
                        cmd3.Parameters.AddWithValue("@pro_q", textBox1.Text);
                        cmd3.Parameters.AddWithValue("@pro_u", label10.Text);
                        cmd3.Parameters.AddWithValue("@pro_p", textBox2.Text);
                        cmd3.Parameters.AddWithValue("@pro_t", textBox3.Text);
                        cmd3.Parameters.AddWithValue("@pur_d", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                        cmd3.Parameters.AddWithValue("@pur_p", comboBox2.SelectedItem);
                        cmd3.Parameters.AddWithValue("@pur_t", comboBox3.SelectedItem);
                        cmd3.Parameters.AddWithValue("@exp_d", dateTimePicker2.Value.ToString("dd-MM-yyyy"));
                        cmd3.Parameters.AddWithValue("@profit", textBox4.Text);

                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();

                        String q4 = "update Stock set Product_qty=" + (qty + Convert.ToDecimal(textBox1.Text)) + " where Product_name=@pro_n";
                        SqlCommand cmd4 = new SqlCommand(q4, con);
                        cmd4.Parameters.AddWithValue("@pro_n", comboBox1.SelectedItem);
                        cmd4.Parameters.AddWithValue("@pro_q", textBox1.Text);

                        con.Open();
                        cmd4.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data inserted");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        comboBox1.ResetText();
                        comboBox2.ResetText();
                        comboBox3.ResetText();
                        dateTimePicker1.ResetText();
                        dateTimePicker2.ResetText();
                    }
                }
                else
                {
                    MessageBox.Show("Enter proper data ");
                }
            }              
            else
            {
                MessageBox.Show("Enter all data ");
            }
            
        }


        public static bool Validations2(String str)
        {
            //Only numbers are allowed here
            bool output = true;

            String regex2 = "[^0-9.]+";

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String q = "select Unit from Product_name where Product_name=@p_name";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@p_name", comboBox1.SelectedItem);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                label10.Text = (sdr[0]).ToString();
            }
            con.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Validations2(textBox1.Text) && Validations2(textBox2.Text))
            {

                textBox3.Text = (Convert.ToDecimal(textBox1.Text) * Convert.ToDecimal(textBox2.Text)).ToString();

            }
            else
            {
                MessageBox.Show("Enter Product details properly");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

}
}