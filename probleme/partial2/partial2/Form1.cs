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

namespace partial2
{
    public partial class Form1 : Form
    {
        private SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=Problema2;Integrated Security=True;TrustServerCertificate=true;");
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
                    this.da1.SelectCommand = new SqlCommand("SELECT * FROM Artisti", conn);
                    this.da1.Fill(ds, "Artisti");
                    this.dataGridView1.DataSource = ds.Tables["Artisti"];
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
                    if (this.ds.Tables.Contains("Melodii"))
                        this.ds.Tables["Melodii"].Clear();
                    this.da2.SelectCommand = new SqlCommand("SELECT * FROM Melodii where cod_artist=@id", conn);
                    this.da2.SelectCommand.Parameters.AddWithValue("@id", id);
                    this.da2.Fill(ds, "Melodii");
                    this.dataGridView2.DataSource = ds.Tables["Melodii"];
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
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_artist"].Value);
                fill2(id); 
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView2.SelectedRows[0];
                    textBox1.Text = row.Cells["titlu"].Value.ToString();
                    textBox2.Text = row.Cells["an_lansare"].Value.ToString();
                    textBox3.Text = row.Cells["durata"].Value.ToString();
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
                    int codArtist = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_artist"].Value);
                    fill2(codArtist);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la schimbarea selecției: " + ex.Message);
                }
            }
        }

        private void add1()
        {
            if(dataGridView2.SelectedRows.Count > 0)
                {
                try
                {
                    int artist = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_artist"].Value);
                    string titlu = textBox1.Text.Trim();
                    string an = textBox2.Text.Trim();
                    string durata = textBox3.Text.Trim();

                    if (string.IsNullOrWhiteSpace(titlu) || string.IsNullOrWhiteSpace(an) || string.IsNullOrWhiteSpace(durata))
                    {
                        MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                        return;
                    }
                    int anInt;
                    if (!int.TryParse(an, out anInt) || anInt <= 0 || anInt > DateTime.Now.Year)
                    {
                        MessageBox.Show("Anul trebuie să fie real și să nu depășească anul curent.");
                        return;
                    }

                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        this.da2.InsertCommand = new SqlCommand("insert into Melodii(titlu,an_lansare,durata,cod_artist) values (@n,@d,@p,@c)", conn);
                        this.da2.InsertCommand.Parameters.AddWithValue("@n", titlu);
                        this.da2.InsertCommand.Parameters.AddWithValue("@d", int.Parse(an));
                        this.da2.InsertCommand.Parameters.AddWithValue("@p", TimeSpan.Parse(durata));
                        this.da2.InsertCommand.Parameters.AddWithValue("@c", artist);
                        this.da2.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Inregistrarea a fost adaugata cu succes!");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la adaugarea înregistrării: " + ex.Message);
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
                try
                {
                    int codMelodie = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_melodie"].Value);
                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("DELETE FROM Melodii WHERE cod_melodie=@cod", conn);
                        cmd.Parameters.AddWithValue("@cod", codMelodie);
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
                try
                {
                    int codMelodie = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_melodie"].Value);
                    SqlCommand cmd;
                    string titlu = textBox1.Text.Trim();
                    string an = textBox2.Text.Trim();
                    string durata = textBox3.Text.Trim();

                    if (string.IsNullOrWhiteSpace(titlu) || string.IsNullOrWhiteSpace(an) || string.IsNullOrWhiteSpace(durata))
                    {
                        MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                        return;
                    }
                    int anInt;
                    if (!int.TryParse(an, out anInt) || anInt <= 0 || anInt > DateTime.Now.Year)
                    {
                        MessageBox.Show("Anul trebuie să fie real și să nu depășească anul curent.");
                        return;
                    }

                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Melodii SET titlu = @titlu, an_lansare = @an, durata = @durata WHERE cod_melodie = @cod";
                        cmd = new SqlCommand(updateQuery, conn);

                        cmd.Parameters.AddWithValue("@titlu", titlu);
                        cmd.Parameters.AddWithValue("@an", int.Parse(an));
                        cmd.Parameters.AddWithValue("@durata", TimeSpan.Parse(durata)); // Asigurați-vă că durata este introdusă într-un format corect hh:mm:ss
                        cmd.Parameters.AddWithValue("@cod", codMelodie);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Inregistrarea a fost actualizată cu succes.");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la actualizarea înregistrării: " + ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Selectați o inregistrare pentru a o actualiza.");
            }
            this.refresh();
        }
        private void add_Click(object sender, EventArgs e)
        {
            this.add1();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            this.delete1();
        }

        private void update_Click(object sender, EventArgs e)
        {
            this.update1();
        }
    }       
}
