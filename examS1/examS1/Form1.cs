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

namespace examS1
{
    public partial class Form1 : Form
    {
        private SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=PracticS4;Integrated Security=True;TrustServerCertificate=true;");
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
                    this.da1.SelectCommand = new SqlCommand("SELECT * FROM Clienti", conn);
                    this.da1.Fill(ds, "Clienti");
                    this.dataGridView1.DataSource = ds.Tables["Clienti"];
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
                    if (this.ds.Tables.Contains("Facturi"))
                    this.ds.Tables["Facturi"].Clear();
                    this.da2.SelectCommand = new SqlCommand("SELECT * FROM Facturi where cod_client=@id", conn);
                    this.da2.SelectCommand.Parameters.AddWithValue("@id", id);
                    this.da2.Fill(ds, "Facturi");
                    this.dataGridView2.DataSource = ds.Tables["Facturi"];
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
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_client"].Value);
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
                    textBox1.Text = row.Cells["data_emitere"].Value.ToString();
                    textBox2.Text = row.Cells["data_scadenta"].Value.ToString();
                    textBox3.Text = row.Cells["total_plata"].Value.ToString();
                    textBox4.Text = row.Cells["adresa_factura"].Value.ToString();
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
                    int cid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_client"].Value);
                    fill2(cid);
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
                    int t = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_client"].Value);
                    string data_emitere = textBox1.Text.Trim();
                    string data_scadenta = textBox2.Text.Trim();
                    string total_plata = textBox3.Text.Trim();
                    string adresa_factura = textBox4.Text.Trim();


                    if (string.IsNullOrWhiteSpace(data_emitere) || string.IsNullOrWhiteSpace(data_scadenta) || string.IsNullOrWhiteSpace(total_plata) || string.IsNullOrWhiteSpace(adresa_factura))
                    {
                        MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                        return;
                    }
                    DateTime data_emitere1;
                    
                    if (!DateTime.TryParse(data_emitere, out data_emitere1) || data_emitere1 > DateTime.Now)
                    {
                        MessageBox.Show("data emitere trebuie să fie reala și să nu depășească anul curent.");
                        return;
                    }

                    DateTime data_scadenta1;

                    if (!DateTime.TryParse(data_scadenta, out data_scadenta1) )
                    {
                        MessageBox.Show("Data scadenta trebuie să fie reala ");
                        return;
                    }

                    float total_plata1;
                    if (!float.TryParse(total_plata, out total_plata1) || total_plata1 <= 0)
                    {
                        MessageBox.Show("total plata trebuie sa fie un nr pozitiv.");
                        return;
                    }

                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        this.da2.InsertCommand = new SqlCommand("insert into Facturi(data_emitere,data_scadenta,total_plata,adresa_factura,cod_client) values (@n,@d,@p,@a,@c)", conn);
                        this.da2.InsertCommand.Parameters.AddWithValue("@n", DateTime.Parse(data_emitere));
                        this.da2.InsertCommand.Parameters.AddWithValue("@d", DateTime.Parse(data_scadenta));
                        this.da2.InsertCommand.Parameters.AddWithValue("@p", float.Parse(total_plata));
                        this.da2.InsertCommand.Parameters.AddWithValue("@a", adresa_factura);
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
                    int aid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_factura"].Value);
                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("DELETE FROM Facturi WHERE cod_factura=@cod", conn);
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
                try
                {
                    int aid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_factura"].Value);
                    SqlCommand cmd;
                    string data_emitere = textBox1.Text.Trim();
                    string data_scadenta = textBox2.Text.Trim();
                    string total_plata = textBox3.Text.Trim();
                    string adresa_factura = textBox4.Text.Trim();


                    if (string.IsNullOrWhiteSpace(data_emitere) || string.IsNullOrWhiteSpace(data_scadenta) || string.IsNullOrWhiteSpace(total_plata) || string.IsNullOrWhiteSpace(adresa_factura))
                    {
                        MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                        return;
                    }
                    DateTime data_emitere1;

                    if (!DateTime.TryParse(data_emitere, out data_emitere1) || data_emitere1 > DateTime.Now)
                    {
                        MessageBox.Show("data emitere trebuie să fie reala și să nu depășească anul curent.");
                        return;
                    }

                    DateTime data_scadenta1;

                    if (!DateTime.TryParse(data_scadenta, out data_scadenta1))
                    {
                        MessageBox.Show("Data scadenta trebuie să fie reala ");
                        return;
                    }

                    float total_plata1;
                    if (!float.TryParse(total_plata, out total_plata1) || total_plata1 <= 0)
                    {
                        MessageBox.Show("total plata trebuie sa fie un nr pozitiv.");
                        return;
                    }

                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Facturi SET data_emitere = @data_emitere, data_scadenta = @data_scadenta, total_plata = @total_plata, adresa_factura = @adresa_factura WHERE cod_factura = @cod";
                        cmd = new SqlCommand(updateQuery, conn);

                        cmd.Parameters.AddWithValue("@data_emitere", DateTime.Parse(data_emitere));
                        cmd.Parameters.AddWithValue("@data_scadenta", DateTime.Parse(data_scadenta));
                        cmd.Parameters.AddWithValue("@total_plata", float.Parse(total_plata));
                        cmd.Parameters.AddWithValue("@adresa_factura", adresa_factura);
                        cmd.Parameters.AddWithValue("@cod", aid);

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
