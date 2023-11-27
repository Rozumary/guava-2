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

namespace Job_Board_System
{
    public partial class Form1 : Form
    {
        public bool userIsTyping = false;
        public Form1()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=AccessDB;Integrated Security=True");
                {
                    con.Open();

                    string query = "SELECT * FROM Users WHERE Username=@Username AND Password=@Password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            textBox1.Text = "";
                            textBox2.Text = "";

                            if (dt.Rows.Count > 0)
                            {
                                this.Hide();
                                Form2 f2 = new Form2();
                                f2.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password", "Error");

                                textBox2.Clear();
                                textBox2.Focus();

                                textBox2.PasswordChar = '\0';
                                textBox2.Text = "";
                                textBox2.PasswordChar = '*';
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
            finally
            {
                userIsTyping = false;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
