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

namespace Problema1
{
    public partial class Form1 : Form
    {
        private SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=Problema1;Integrated Security=True;TrustServerCertificate=true;");
        private SqlDataAdapter da1 = new SqlDataAdapter();
        private SqlDataAdapter da2 = new SqlDataAdapter();
        private DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            dataGridView2.SelectionChanged += new EventHandler(dataGridView2_SelectionChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fill1();

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionChanged += new EventHandler(dataGridView2_SelectionChanged);
        }


        private void fill1()
        {
            using (var conn = new SqlConnection(cs.ConnectionString))
            {
                this.da1.SelectCommand = new SqlCommand("SELECT * FROM Cofetarii", conn);
                this.da1.Fill(ds, "Cofetarii");
                this.dataGridView1.DataSource = ds.Tables["Cofetarii"];
            }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void fill2(int id)
        {
            using (var conn = new SqlConnection(cs.ConnectionString))
            {
                if (this.ds.Tables.Contains("Briose"))
                    this.ds.Tables["Briose"].Clear();
                this.da2.SelectCommand = new SqlCommand("SELECT * FROM Briose where cod_cofetarie=@id", conn);
                this.da2.SelectCommand.Parameters.AddWithValue("@id", id);
                this.da2.Fill(ds, "Briose");
                this.dataGridView2.DataSource = ds.Tables["Briose"];
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_cofetarie"].Value);
                fill2(id);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows[0];
                textBox1.Text = row.Cells["nume_briosa"].Value.ToString();
                textBox2.Text = row.Cells["descriere"].Value.ToString();
                textBox3.Text = row.Cells["pret"].Value.ToString();
            }
        }

        private void refresh()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int codCofetarie = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_cofetarie"].Value);
                fill2(codCofetarie);
            }
        }

        private void add1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int cofetarie = int.Parse(this.dataGridView1.SelectedRows[0].Cells["cod_cofetarie"].Value.ToString());
                string nume = this.textBox1.Text;
                string descriere = this.textBox2.Text;
                int pret = int.Parse(this.textBox3.Text);
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    this.da2.InsertCommand = new SqlCommand("insert into Briose(nume_briosa,descriere,pret,cod_cofetarie) values (@n,@d,@p,@c)", conn);
                    this.da2.InsertCommand.Parameters.AddWithValue("@n", nume);
                    this.da2.InsertCommand.Parameters.AddWithValue("@d", descriere);
                    this.da2.InsertCommand.Parameters.AddWithValue("@p", pret);
                    this.da2.InsertCommand.Parameters.AddWithValue("@c", cofetarie);
                    this.da2.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Inregistrarea a fost adaugata cu succes!");
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Selectați o inregistrare din tabela parinte pentru a putea adauga in tabela fiu.");
            }

            this.refresh();
        }
        
        private void delete1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int codBriosa = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_briosa"].Value);
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM Briose WHERE cod_briosa=@cod", conn);
                    cmd.Parameters.AddWithValue("@cod", codBriosa);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inregistrarea a fost stearsa cu succes!");
                    conn.Close();
                }
                this.refresh();
            }
            else
            {
                MessageBox.Show("Selectați o inregistrare pentru a o șterge.");
            }
        }


        private void update1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int codBriosa = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_briosa"].Value);
                SqlCommand cmd;
                string nume = textBox1.Text.Trim();
                string descriere = textBox2.Text.Trim();
                string pret = textBox3.Text.Trim();

                if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(descriere) || string.IsNullOrWhiteSpace(pret))
                {
                    MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                    return;
                }

                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Briose SET nume_briosa = @nume, descriere = @descriere, pret = @pret WHERE cod_briosa = @cod";
                    cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@descriere", descriere);
                    cmd.Parameters.AddWithValue("@pret", int.Parse(pret)); // Asigurați-vă că durata este introdusă într-un format corect hh:mm:ss
                    cmd.Parameters.AddWithValue("@cod", codBriosa);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inregistrarea a fost actualizată cu succes.");
                    conn.Close();
                }
                this.refresh();
            }
            else
            {
                MessageBox.Show("Selectați o inregistrare pentru a o actualiza.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.add1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.delete1();     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.update1();
        }
    }
}
