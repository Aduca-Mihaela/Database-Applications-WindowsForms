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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestFarmacie
{
    public partial class Form1 : Form
    {
        private SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=SCOALASGBD;Integrated Security=True;TrustServerCertificate=true;");
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
                this.da1.SelectCommand = new SqlCommand("SELECT * FROM Profesori", conn);
                this.da1.Fill(ds, "Profesori");
                this.dataGridView1.DataSource = ds.Tables["Profesori"];
            }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void fill2(int id)
        {
            using (var conn = new SqlConnection(cs.ConnectionString))
            {
                if (this.ds.Tables.Contains("Cursuri"))
                    this.ds.Tables["Cursuri"].Clear();
                this.da2.SelectCommand = new SqlCommand("SELECT * FROM Cursuri where profesorID=@id", conn);
                this.da2.SelectCommand.Parameters.AddWithValue("@id", id);
                this.da2.Fill(ds, "Cursuri");
                this.dataGridView2.DataSource = ds.Tables["Cursuri"];
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["profesorID"].Value);
                fill2(id);
            }
        }



        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows[0];
                textBox1.Text = row.Cells["nume_curs"].Value.ToString();
                textBox2.Text = row.Cells["descriere"].Value.ToString();
                
            }
        }
        private void add1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int profesor = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["profesorID"].Value);
                string nume_curs = this.textBox1.Text;
                string descriere = this.textBox2.Text;
                
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    this.da2.InsertCommand = new SqlCommand("insert into Cursuri(nume_curs,descriere, profesorID) values (@n,@c,@p)", conn);
                    this.da2.InsertCommand.Parameters.AddWithValue("@n", nume_curs);
                    this.da2.InsertCommand.Parameters.AddWithValue("@c", descriere);
                    this.da2.InsertCommand.Parameters.AddWithValue("@p", profesor);
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

        private void refresh()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int codF = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["profesorID"].Value);
                fill2(codF);
            }
        }


        private void delete1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int codM = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cursID"].Value);
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM Cursuri WHERE cursID=@cod", conn);
                    cmd.Parameters.AddWithValue("@cod", codM);
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
                int codM = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cursID"].Value);
                SqlCommand cmd;
                string nume = textBox1.Text.Trim();
                string descriere = textBox2.Text.Trim();
                

                if (string.IsNullOrWhiteSpace(nume) ||  string.IsNullOrWhiteSpace(descriere))
                {
                    MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                    return;
                }

                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Cursuri SET nume_curs = @nume, descriere = @descriere WHERE cursID = @cod";
                    cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@nume", nume);
                    
                    cmd.Parameters.AddWithValue("@descriere", descriere); // Asigurați-vă că durata este introdusă într-un format corect hh:mm:ss
                    cmd.Parameters.AddWithValue("@cod", codM);

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
