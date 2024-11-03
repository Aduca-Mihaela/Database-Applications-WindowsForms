using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Linq.Expressions;
using System;

namespace lab1sgbd
{
    public partial class Form1 : Form
    {
        // Declarații pentru variabilele statice pentru a accesa valorile din fișierul de configurare
        public static string selectParentQuery = ConfigurationManager.AppSettings.Get("selectParent");
        public static string selectChildQuery = ConfigurationManager.AppSettings.Get("selectChild");
        public static string parentTableName = ConfigurationManager.AppSettings.Get("ParentTableName");
        public static string childTableName = ConfigurationManager.AppSettings.Get("ChildTableName");
        public static string childColumnsNames = ConfigurationManager.AppSettings.Get("ChildColumnsNames");
        public static string insertQuery = ConfigurationManager.AppSettings.Get("InsertQuery");
        public static string updateQuery = ConfigurationManager.AppSettings.Get("UpdateQuery");
        public static string deleteQuery = ConfigurationManager.AppSettings.Get("DeleteQuery");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        int pFKid;
        int id;

        public Form1()
        {
            InitializeComponent();
        }



        private void generatetextbox_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ColumnNames = new List<string>(ConfigurationManager.AppSettings["ChildColumnsNames"].Split(','));
                int pointX = 30;
                int pointY = 40;
                int numberOfColumns = Convert.ToInt32(ConfigurationManager.AppSettings["ChildNumberOfColumns"]);
                panel1.Controls.Clear();
                foreach (string column in ColumnNames)
                {
                    TextBox a = new TextBox();
                    a.Text = column;
                    a.Name = column;
                    a.Location = new Point(pointX, pointY);
                    a.Visible = true;
                    a.Parent = panel1;
                    panel1.Show();
                    pointY += 30;

                }

            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewFiu.SelectionChanged += dataGridViewFiu_SelectionChanged;
            dataGridViewParinte.CellContentClick += dataGridViewParinte_CellContentClick;
            dataGridViewParinte.CellClick += dataGridViewParinte_CellClick;
            string connectionString = ConfigurationManager.ConnectionStrings["lab2"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectParentQuery, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridViewParinte.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Verifică dacă a fost selectat un rând în DataGridView-ul fiu
            if (dataGridViewFiu.SelectedRows.Count > 0)
            {
                // Obține conexiunea din configurație
                string con = ConfigurationManager.ConnectionStrings["lab2"].ConnectionString;
                SqlConnection cs = new SqlConnection(con);

                try
                {
                    // Obține interogarea de ștergere din configurație
                    string DeleteQuery = ConfigurationManager.AppSettings["DeleteQuery"];
                    SqlCommand cmd = new SqlCommand(DeleteQuery, cs);

                    // Obține ID-ul înregistrării selectate din DataGridView
                    int id = int.Parse(dataGridViewFiu.SelectedRows[0].Cells[0].Value.ToString());

                    // Setează parametrul ID în comanda SQL
                    cmd.Parameters.AddWithValue("@id", id);

                    cs.Open();
                    cmd.ExecuteNonQuery();
                    List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnsNames"].Split(','));
                    foreach (string column in ColumnNamesList)
                    {
                        TextBox textBox = (TextBox)panel1.Controls[column];
                        
                        textBox.Text = column;
                    }

                    // Reîncarcă datele în DataSet și actualizează DataGridView-ul fiu
                    ds1.Clear();
                    da.Fill(ds1);
                    dataGridViewFiu.DataSource = ds1.Tables[0];

                    MessageBox.Show("Deleted succesfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A apărut o eroare în timpul ștergerii cursului: " + ex.Message);
                }
                finally
                {
                    cs.Close();
                }
            }
            else
            {
                // Afișează un mesaj către utilizator dacă nu este selectat niciun curs pentru ștergere
                MessageBox.Show("Vă rugăm să selectați un curs pentru a-l șterge.");
            }
        }


        private void Update_Click(object sender, EventArgs e)
        {
            // Verifică dacă a fost selectat un rând în DataGridView-ul fiu
            if (dataGridViewFiu.SelectedRows.Count > 0)
            {
                // Obține conexiunea din configurație
                string con = ConfigurationManager.ConnectionStrings["lab2"].ConnectionString;
                SqlConnection cs = new SqlConnection(con);

                try
                {
                    // Obține interogarea de actualizare din configurație
                    string UpdateQuery = ConfigurationManager.AppSettings["UpdateQuery"];
                    SqlCommand cmd = new SqlCommand(UpdateQuery, cs);

                    // Obține ID-ul înregistrării selectate din DataGridView
                    int id = int.Parse(dataGridViewFiu.SelectedRows[0].Cells[0].Value.ToString());

                    // Setează parametrul ID în comanda SQL
                    cmd.Parameters.AddWithValue("@id", id);

                    // Obține coloanele și valorile corespunzătoare din controalele TextBox
                    List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnsNames"].Split(','));
                    foreach (string column in ColumnNamesList)
                    {
                        TextBox textBox = (TextBox)panel1.Controls[column];
                        cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                        textBox.Text = column;
                    }

                    cs.Open();
                    cmd.ExecuteNonQuery();

                    // Reîncarcă datele în DataSet și actualizează DataGridView-ul fiu
                    ds1.Clear();
                    da.Fill(ds1);
                    dataGridViewFiu.DataSource = ds1.Tables[0];

                    MessageBox.Show("Updated succesfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A apărut o eroare în timpul actualizării : " + ex.Message);
                }
                finally
                {
                    cs.Close();
                }
            }
            else
            {
                // Afișează un mesaj către utilizator dacă nu este selectat niciun curs pentru actualizare
                MessageBox.Show("Vă rugăm să selectați un  copil pentru a-l actualiza.");
            }
        }







        private void Insert_Click(object sender, EventArgs e)
        {
            // Verificăm dacă un părinte este selectat în DataGridView-ul părinte
            if (dataGridViewParinte.SelectedRows.Count > 0)
            {
                // Obținem ID-ul părintelui selectat
                pFKid = int.Parse(dataGridViewParinte.SelectedRows[0].Cells[0].Value.ToString());

                string con = ConfigurationManager.ConnectionStrings["lab2"].ConnectionString;
                SqlConnection cs = new SqlConnection(con);

                try
                {
                    string ChildTableName = ConfigurationManager.AppSettings["ChildTableName"];
                    string ChildColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];
                    List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnsNames"].Split(','));
                    string InsertQuery = ConfigurationManager.AppSettings["InsertQuery"];
                    SqlCommand cmd = new SqlCommand(InsertQuery, cs);

                    // Setăm parametrul pentru ID-ul părintelui
                    cmd.Parameters.AddWithValue("@pFKid", pFKid);

                    // Setăm valorile pentru celelalte coloane din tabela "Cursuri"
                    foreach (string column in ColumnNamesList)
                    {
                        TextBox textBox = (TextBox)panel1.Controls[column];
                        cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                        textBox.Text = column;
                    }

                    cs.Open();
                    cmd.ExecuteNonQuery();
                    ds1.Clear();
                    da.Fill(ds1);
                    dataGridViewFiu.DataSource = ds1.Tables[0];
                    MessageBox.Show("Inserted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the course: " + ex.Message);
                }
                finally
                {
                    cs.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a parent before adding a course.");
            }
        }


        private void dataGridViewFiu_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFiu.SelectedRows.Count > 0)
            {
                List<string> ColumnNames = new List<string>(ConfigurationManager.AppSettings["ChildColumnsNames"].Split(','));
                // Obține ID-ul copilului selectat
                id = int.Parse(dataGridViewFiu.CurrentRow.Cells[0].Value.ToString());
                int i = 1;
                foreach (string column in ColumnNames)
                {
                    // Verifică dacă există un control TextBox pentru fiecare coloană
                    if (panel1.Controls.ContainsKey(column))
                    {
                        TextBox textBox = (TextBox)panel1.Controls[column];
                        // Verifică dacă celula este validă și are o valoare
                        if (dataGridViewFiu.CurrentCell != null && dataGridViewFiu.CurrentCell.Value != null)
                        {
                            // Populează TextBox-urile cu valorile celulelor din rândul selectat
                            textBox.Text = dataGridViewFiu.CurrentRow.Cells[i].Value.ToString();
                        }
                        else
                        {
                            // Golește TextBox-urile dacă nu este selectat niciun copil
                            textBox.Text = string.Empty;
                        }
                        i++;
                    }
                }
            }
            else
            {
                // Golește TextBox-urile dacă nu este selectat niciun copil
                foreach (Control control in panel1.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        textBox.Text = string.Empty;
                    }
                }
            }
        }


        private void LoadChildData(int pFKid)
        {
            string con = ConfigurationManager.ConnectionStrings["lab2"].ConnectionString;
            try
            {
                SqlConnection cs = new SqlConnection(con);
                string select = ConfigurationManager.AppSettings["selectChild"];
                da.SelectCommand = new SqlCommand(select, cs);
                da.SelectCommand.Parameters.AddWithValue("@pFKid", pFKid);
                ds1.Clear();
                da.Fill(ds1);
                dataGridViewFiu.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewParinte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewParinte.Rows.Count - 1)
            {
                // Obține ID-ul părintelui selectat din coloana cu indexul 0 (presupunând că este prima coloană cu ID)
                pFKid = int.Parse(dataGridViewParinte.Rows[e.RowIndex].Cells[0].Value.ToString());
                LoadChildData(pFKid); // Inserează datele copilului asociate părintelui selectat
            }
        }

        private void dataGridViewParinte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewParinte.Rows.Count - 1)
            {
                int pFKid = int.Parse(dataGridViewParinte.Rows[e.RowIndex].Cells[0].Value.ToString());
                LoadChildData(pFKid);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            // Reîncarcă datele în DataGridView-ul părinte
            string connectionString = ConfigurationManager.ConnectionStrings["lab2"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectParentQuery, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridViewParinte.DataSource = dataTable;

                    // Verifică dacă există un rând selectat în DataGridView-ul părinte
                    if (dataGridViewParinte.SelectedRows.Count > 0)
                    {
                        // Obține ID-ul părintelui selectat
                        int pFKid = int.Parse(dataTable.Rows[dataGridViewParinte.SelectedRows[0].Index]["ID"].ToString());
                        // Reîncarcă datele copilului asociate părintelui selectat
                        LoadChildData(pFKid);
                    }
                    else
                    {
                        // Golește DataGridView-ul fiu dacă nu este selectat niciun părinte
                        dataGridViewFiu.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la reîncărcarea datelor: " + ex.Message);
                }
            }

        }
    }

}