using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace experiment
{
    public partial class Form1 : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=sgbdlb1;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sgbdlb1DataSet3.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter2.Fill(this.sgbdlb1DataSet3.Product);
            // TODO: This line of code loads data into the 'sgbdlb1DataSet1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.sgbdlb1DataSet1.Product);
            // TODO: This line of code loads data into the 'sgbdlb1DataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.sgbdlb1DataSet.Product);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM Product", cs);
            ds.Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                da.InsertCommand = new SqlCommand("INSERT INTO Product (Pid, PName, Quantity, Price,Cid) VALUES(@i, @p, @q, @pr, @c)", cs);
                da.InsertCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = textBox1.Text;
                da.InsertCommand.Parameters.Add("@q", SqlDbType.Int).Value =
               Int32.Parse(textBox2.Text);
                da.InsertCommand.Parameters.Add("@pr", SqlDbType.Int).Value =
               Int32.Parse(textBox3.Text);
                da.InsertCommand.Parameters.Add("@c", SqlDbType.Int).Value =
               Int32.Parse(textBox4.Text);
                cs.Open();
                da.InsertCommand.Parameters.Add("@i", SqlDbType.Int).Value =
               Int32.Parse(textBox5.Text);
                da.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted Succesfull to the Database");
                cs.Close();
                // already inserted - apear in the list
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cs.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
