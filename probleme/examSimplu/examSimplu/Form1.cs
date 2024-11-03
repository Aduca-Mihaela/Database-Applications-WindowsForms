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

namespace examSimplu
{
    public partial class Form1 : Form
    {
        private SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=S1;Integrated Security=True;TrustServerCertificate=true;");
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
            try
            {
                fill1();
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.SelectionChanged += new EventHandler(dataGridView2_SelectionChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
            }
        }

        private void fill1()
        {
            try
            {
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    this.da1.SelectCommand = new SqlCommand("SELECT * FROM TipuriArticole", conn);
                    this.da1.Fill(ds, "TipuriArticole");
                    this.dataGridView1.DataSource = ds.Tables["TipuriArticole"];
                }
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
            }
        }

        private void fill2(int id)
        {
            try
            {
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    if (this.ds.Tables.Contains("Articole"))
                        this.ds.Tables["Articole"].Clear();
                    this.da2.SelectCommand = new SqlCommand("SELECT * FROM Articole where Tid=@id", conn);
                    this.da2.SelectCommand.Parameters.AddWithValue("@id", id);
                    this.da2.Fill(ds, "Articole");
                    this.dataGridView2.DataSource = ds.Tables["Articole"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
            }
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Tid"].Value);
                    fill2(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la schimbarea selecției: " + ex.Message);
                }

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView2.SelectedRows[0];
                    textBox1.Text = row.Cells["Titlu"].Value.ToString();
                    textBox2.Text = row.Cells["NrAutori"].Value.ToString();
                    textBox3.Text = row.Cells["NrPagini"].Value.ToString();
                    textBox4.Text = row.Cells["AnPublicare"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la schimbarea selecției: " + ex.Message);
                }
            }
        }

        private void refresh()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int tid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Tid"].Value);
                    fill2(tid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la reîmprospătarea datelor: " + ex.Message);
                }
            }
        }

        private void add1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    int t = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Tid"].Value);
                    string titlu = this.textBox1.Text;
                    int nrautori = int.Parse(textBox2.Text);
                    int nrpagini = int.Parse(textBox3.Text);
                    int an = int.Parse(textBox4.Text);



                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        this.da2.InsertCommand = new SqlCommand("insert into Articole(Titlu,NrAutori,NrPagini,AnPublicare,Tid) values (@n,@d,@p,@a,@c)", conn);
                        this.da2.InsertCommand.Parameters.AddWithValue("@n", titlu);
                        this.da2.InsertCommand.Parameters.AddWithValue("@d", nrautori);
                        this.da2.InsertCommand.Parameters.AddWithValue("@p", nrpagini);
                        this.da2.InsertCommand.Parameters.AddWithValue("@a", an);
                        this.da2.InsertCommand.Parameters.AddWithValue("@c", t);
                        this.da2.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Inregistrarea a fost adaugata cu succes!");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la adăugarea înregistrării: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectați o inregistrare din tabela părinte pentru a putea adăuga în tabela fiu.");
            }
            this.refresh();

        }

        private void delete1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    int aid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Aid"].Value);
                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("DELETE FROM Articole WHERE Aid=@cod", conn);
                        cmd.Parameters.AddWithValue("@cod", aid);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Inregistrarea a fost stearsa cu succes!");
                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la stergerea înregistrării: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Selectați o inregistrare pentru a o șterge.");
            }
            this.refresh();
        }


        private void update1()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int aid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Aid"].Value);
                SqlCommand cmd;
                string titlu = textBox1.Text.Trim();
                string nrautori = textBox2.Text.Trim();
                string nrpagini = textBox3.Text.Trim();
                string an = textBox4.Text.Trim();


                if (string.IsNullOrWhiteSpace(titlu) || string.IsNullOrWhiteSpace(nrautori) || string.IsNullOrWhiteSpace(nrpagini) || string.IsNullOrWhiteSpace(an))
                {
                    MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                    return;
                }
                

                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Articole SET Titlu = @titlu, NrAutori = @nrautori, NrPagini = @nrpagini, AnPublicare = @an WHERE Aid = @cod";
                    cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@titlu", titlu);
                    cmd.Parameters.AddWithValue("@nrautori", int.Parse(nrautori));
                    cmd.Parameters.AddWithValue("@nrpagini", int.Parse(nrpagini));
                    cmd.Parameters.AddWithValue("@an", int.Parse(an));// Asigurați-vă că durata este introdusă într-un format corect hh:mm:ss
                    cmd.Parameters.AddWithValue("@cod", aid);

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
