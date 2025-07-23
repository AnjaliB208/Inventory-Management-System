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
    public partial class Unit : Form
    {
        public Unit()
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

        private void add_unit_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Validations(textBox1.Text))
                {
                    int count = 0;
                    String q1 = "select * from Units where unit = '" + textBox1.Text + "'";
                    SqlDataAdapter sda1 = new SqlDataAdapter(q1, con);
                    DataTable ds1 = new DataTable();
                    sda1.Fill(ds1);
                    count = Convert.ToInt32(ds1.Rows.Count.ToString());

                    if (count == 0)
                    {
                        String q = "insert into Units values(@unit)";
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@unit", textBox1.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data inserted");
                        display();
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("The unit already exists in database");
                        textBox1.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Enter a proper unit");
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter unit");
            }
            
        }

        public void display()
        {
            String q = "select * from Units";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void del_unit_btn_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String q = "delete from Units where Id = '"+id+"'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data deleted");
            display();
            textBox1.Clear();
        }

    }
}
