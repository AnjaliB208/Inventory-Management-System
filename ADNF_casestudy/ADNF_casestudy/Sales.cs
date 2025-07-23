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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Welcome\Documents\Inventory_Database.mdf;Integrated Security=True;Connect Timeout=30");
        DataTable dt = new DataTable();
        decimal tot = 0;
        private void Sales_Load(object sender, EventArgs e)
        {
            dt.Clear();
            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
        }
        
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;

            listBox1.Items.Clear();
            String q = "select Product_name from Stock where Product_name like ('"+ textBox4.Text + "%')";
            SqlCommand cmd = new SqlCommand(q,con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                listBox1.Items.Add(sdr[0].ToString());
            }
            con.Close();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Down)
                {
                    this.listBox1.SelectedItem = this.listBox1.SelectedIndex + 1;
                }
                if(e.KeyCode == Keys.Up)
                {
                    this.listBox1.SelectedItem = this.listBox1.SelectedIndex - 1;
                }
                if(e.KeyCode == Keys.Enter)
                {
                    textBox4.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    textBox3.Focus();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            String q = "select top 1 Product_price from Purchase_master where Product_name=@pn order by Id desc";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@pn", textBox4.Text);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                textBox3.Text= (sdr[0].ToString());
            }
            con.Close();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = (Convert.ToDecimal(textBox3.Text) * Convert.ToDecimal(textBox5.Text)).ToString();
            }
            catch(Exception ex)
            {

            }
        }

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

        private void add_btn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" )
            {
                if(Validations(textBox1.Text) && Validations(textBox2.Text) && Validations(textBox4.Text) && Validations2(textBox3.Text) && Validations2(textBox5.Text) && Validations2(textBox6.Text))
                {
                    decimal stock = 0;
                    String q = "select Product_qty from Stock where Product_name = @pn";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@pn", textBox4.Text);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        stock = Convert.ToDecimal(sdr[0].ToString());
                    }
                    con.Close();

                    if (Convert.ToDecimal(textBox5.Text) > stock)
                    {
                        MessageBox.Show("This much stock is not available");
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr["Product"] = textBox4.Text;
                        dr["Price"] = textBox3.Text;
                        dr["Quantity"] = textBox5.Text;
                        dr["Total"] = textBox6.Text;
                        dt.Rows.Add(dr);
                        dataGridView1.DataSource = dt;

                        tot = tot + Convert.ToDecimal(dr["Total"].ToString());
                        label10.Text = tot.ToString();

                    }
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                }
                else
                {
                    MessageBox.Show("Enter proper data");
                }
            }
            else
            {
                MessageBox.Show("Enter all the data");
            }
            
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                tot = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));
                foreach(DataRow dr1 in dt.Rows)
                {
                    tot = tot + Convert.ToDecimal(dr1["Total"].ToString());
                    label10.Text = tot.ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void sav_print_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                string orderid = "";
                String q = "insert into Order_user values(@fn,@ln,@bt,@pd)";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@fn", textBox1.Text);
                cmd.Parameters.AddWithValue("@ln", textBox2.Text);
                cmd.Parameters.AddWithValue("@bt", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@pd", dateTimePicker1.Value.ToString("dd/MM/yyyy"));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                String q1 = "select top 1 * from Order_user order by Id desc";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                //cmd1.Parameters.AddWithValue("@pn", textBox4.Text);
                con.Open();
                SqlDataReader sdr = cmd1.ExecuteReader();
                while (sdr.Read())
                {
                    orderid = sdr[0].ToString();
                }
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    decimal qty = 0;
                    string pname = "";
                    String q2 = "insert into Order_item values(@oid,@prod,@price,@qty,@tot)";
                    SqlCommand cmd2 = new SqlCommand(q2, con);
                    cmd2.Parameters.AddWithValue("@oid", orderid.ToString());
                    cmd2.Parameters.AddWithValue("@prod", dr["Product"].ToString());
                    cmd2.Parameters.AddWithValue("@price", dr["Price"].ToString());
                    cmd2.Parameters.AddWithValue("@qty", dr["Quantity"].ToString());
                    cmd2.Parameters.AddWithValue("@tot", dr["Total"].ToString());

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    qty = Convert.ToDecimal(dr["Quantity"]);
                    pname = dr["Product"].ToString();

                    String q3 = "update Stock set Product_qty=Product_qty-" + qty + " where Product_name = '" + pname.ToString() + "'";
                    SqlCommand cmd3 = new SqlCommand(q3, con);

                    con.Open();
                    cmd3.ExecuteNonQuery();
                    con.Close();

                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                label10.Text = "";

                dt.Clear();
                dataGridView1.DataSource = dt;

                MessageBox.Show("Data inserted");
            }
            else
            {
                MessageBox.Show("Enter all data properly");
            }
        }
            
    }
}
