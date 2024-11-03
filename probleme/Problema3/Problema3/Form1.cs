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

namespace Problema3
{
    public partial class Form1 : Form
    {
        private SqlConnection cs = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=Problema3;Integrated Security=True;TrustServerCertificate=true;");
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
                    this.da1.SelectCommand = new SqlCommand("SELECT * FROM Producatori", conn);
                    this.da1.Fill(ds, "Producatori");
                    this.dataGridView1.DataSource = ds.Tables["Producatori"];
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
                    if (this.ds.Tables.Contains("Biscuiti"))
                        this.ds.Tables["Biscuiti"].Clear();
                    this.da2.SelectCommand = new SqlCommand("SELECT * FROM Biscuiti where cod_p=@id", conn);
                    this.da2.SelectCommand.Parameters.AddWithValue("@id", id);
                    this.da2.Fill(ds, "Biscuiti");
                    this.dataGridView2.DataSource = ds.Tables["Biscuiti"];
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
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_p"].Value);
                    fill2(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la schimbarea selectiei: " + ex.Message);
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
                    textBox1.Text = row.Cells["nume_b"].Value.ToString();
                    textBox2.Text = row.Cells["nr_calorii"].Value.ToString();
                    textBox3.Text = row.Cells["pret"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la schimbarea selectiei: " + ex.Message);
                }
            }
        }


        private void refresh()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int codP = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cod_p"].Value);
                    fill2(codP);
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
                    int producator = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_p"].Value);
                    string nume_b = this.textBox1.Text.Trim();
                    string nr_calorii = this.textBox2.Text.Trim();
                    string pret = this.textBox3.Text.Trim();
                    if (string.IsNullOrWhiteSpace(nume_b) || string.IsNullOrWhiteSpace(nr_calorii) || string.IsNullOrWhiteSpace(pret))
                    {
                        MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                        return;
                    }
                    int nr_calorii_int;
                    if (!int.TryParse(nr_calorii, out nr_calorii_int) || nr_calorii_int <= 0)
                    {
                        MessageBox.Show("Numărul de calorii trebuie să fie un număr pozitiv.");
                        return;
                    }
                    int pretInt;
                    if (!int.TryParse(pret, out pretInt) || pretInt <= 0)
                    {
                        MessageBox.Show("Pretul trebuie să fie un număr pozitiv.");
                        return;
                    }
                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                        this.da2.InsertCommand = new SqlCommand("insert into Biscuiti(nume_b,nr_calorii,pret,cod_p) values (@n,@d,@p,@c)", conn);
                        this.da2.InsertCommand.Parameters.AddWithValue("@n", nume_b);
                        this.da2.InsertCommand.Parameters.AddWithValue("@d", int.Parse(nr_calorii));
                        this.da2.InsertCommand.Parameters.AddWithValue("@p", int.Parse(pret));
                        this.da2.InsertCommand.Parameters.AddWithValue("@c", producator);
                        this.da2.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Inregistrarea a fost adaugata cu succes!");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la salvarea inregistrarii: " + ex.Message);
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
                int codB = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_b"].Value);
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM Biscuiti WHERE cod_b=@cod", conn);
                    cmd.Parameters.AddWithValue("@cod", codB);
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
                int codB = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["cod_b"].Value);
                SqlCommand cmd;
                string nume = textBox1.Text.Trim();
                string nr_calorii = textBox2.Text.Trim();
                string pret = textBox3.Text.Trim();

                if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(nr_calorii) || string.IsNullOrWhiteSpace(pret))
                {
                    MessageBox.Show("Completați toate câmpurile pentru a actualiza inregistrarea.");
                    return;
                }
                int nr_calorii_int;
                if (!int.TryParse(nr_calorii, out nr_calorii_int) || nr_calorii_int <= 0)
                {
                    MessageBox.Show("Numărul de calorii trebuie să fie un număr pozitiv.");
                    return;
                }
                int pretInt;
                if (!int.TryParse(pret, out pretInt) || pretInt <= 0)
                {
                    MessageBox.Show("Pretul trebuie să fie un număr pozitiv.");
                    return;
                }
                using (var conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Biscuiti SET nume_b = @nume, nr_calorii = @nr_calorii, pret = @pret WHERE cod_b = @cod";
                    cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@nr_calorii", int.Parse(nr_calorii));
                    cmd.Parameters.AddWithValue("@pret", int.Parse(pret)); // Asigurați-vă că durata este introdusă într-un format corect hh:mm:ss
                    cmd.Parameters.AddWithValue("@cod", codB);

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
