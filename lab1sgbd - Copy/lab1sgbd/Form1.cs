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

namespace lab1sgbd
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=SCOALASGBD;Integrated Security=True");
        SqlDataAdapter profesorAdapter = new SqlDataAdapter();
        SqlDataAdapter cursAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        BindingSource bsParent = new BindingSource();
        BindingSource bsChild = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MessageBox.Show("Starea conexiunii: " + connection.State.ToString());
                profesorAdapter = new SqlDataAdapter("SELECT * FROM Profesori", connection);
                cursAdapter = new SqlDataAdapter("SELECT * FROM Cursuri", connection);
                profesorAdapter.Fill(dataSet, "Profesori");
                cursAdapter.Fill(dataSet, "Cursuri");

                DataColumn pkColumn = dataSet.Tables["Profesori"].Columns["profesorID"];
                DataColumn fkColumn = dataSet.Tables["Cursuri"].Columns["profesorID"];
                DataRelation relation = new DataRelation("FK_Profesori_Cursuri", pkColumn, fkColumn);
                dataSet.Relations.Add(relation);

                bsParent.DataSource = dataSet.Tables["Profesori"];
                bsChild.DataSource = bsParent;
                bsChild.DataMember = "FK_Profesori_Cursuri";

                dataGridViewParinte.DataSource = bsParent;
                dataGridViewFiu.DataSource = bsChild;

                textBox1.DataBindings.Add("Text", bsParent, "numeProfesor", true);

                dataGridViewParinte.CellClick += dataGridViewParinte_CellClick;
                dataGridViewFiu.SelectionChanged += dataGridViewFiu_SelectionChanged;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {

                cursAdapter = new SqlDataAdapter("SELECT * FROM Cursuri", connection);
                dataSet.Tables["Cursuri"].Clear();
                cursAdapter.Fill(dataSet, "Cursuri");

                MessageBox.Show("Datele au fost reîmprospătate cu succes.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul reîmprospătării datelor: " + ex.Message);
            }

        }

        //CERINTA 3: a selectarea unei înregistrări din fiu, trebuie să se permită ştergerea sau actualziarea datelor acesteia
        //DELETE Curs DUPA ID BUTTON


        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificăm dacă a fost selectat un rând în DataGridView
                if (dataGridViewFiu.SelectedRows.Count > 0)
                {
                    // Obținem cursul selectat din DataGridView
                    DataGridViewRow selectedRow = dataGridViewFiu.SelectedRows[0];

                    // Obținem cursID-ul pentru cursul selectat
                    int cursID = Convert.ToInt32(selectedRow.Cells["cursIDDataGridViewTextBoxColumn"].Value);

                    
                    SqlCommand cmd = new SqlCommand("DELETE FROM Cursuri WHERE cursID = @cid", connection);
                    cmd.Parameters.AddWithValue("@cid", cursID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    
                    MessageBox.Show("Cursul a fost șters cu succes.");
                    // Reîncărcăm datele în DataSet și DataGridView-ul fiu
                    dataSet.Tables["Cursuri"].Clear();
                    cursAdapter.Fill(dataSet, "Cursuri");
                }
                else
                {
                    MessageBox.Show("Vă rugăm să selectați un curs înainte de a șterge.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul ștergerii cursului: " + ex.Message);
            }

        }
        ///UPDATE CURS DUPA ID BUTTON

        private void dataGridViewFiu_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFiu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewFiu.SelectedRows[0];
                textBox2.Text = selectedRow.Cells["numeCursDataGridViewTextBoxColumn"].Value.ToString();
                textBox3.Text = selectedRow.Cells["descriereDataGridViewTextBoxColumn"].Value.ToString();
                textBox4.Text = selectedRow.Cells["profesorIDDataGridViewTextBoxColumn1"].Value.ToString();
            }
            else
            {

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }


        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewFiu.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewFiu.SelectedRows[0];

                    int cursID = Convert.ToInt32(selectedRow.Cells["cursIDDataGridViewTextBoxColumn"].Value);

                    if (string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        MessageBox.Show("Vă rugăm să introduceți O DESCRIERE pentru Curs.");
                        return;
                    }

                    string numeProfesor = textBox1.Text;

                    SqlCommand cmd = new SqlCommand("SELECT profesorID FROM Profesori WHERE numeProfesor = @numeProfesor", connection);
                    cmd.Parameters.AddWithValue("@numeProfesor", numeProfesor);
                    connection.Open();
                    int profesorID = (int)cmd.ExecuteScalar();
                    connection.Close();


                    SqlCommand updateCommand = new SqlCommand("UPDATE Cursuri SET nume_curs = @nume_curs, descriere = @descriere, profesorID = @profesorID WHERE cursID = @cursID", connection);
                    updateCommand.Parameters.AddWithValue("@nume_curs", textBox2.Text);
                    updateCommand.Parameters.AddWithValue("@descriere", textBox3.Text);
                    updateCommand.Parameters.AddWithValue("@profesorID", profesorID);
                    updateCommand.Parameters.AddWithValue("@cursID", cursID);

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Cursul a fost actualizată cu succes.");
                    // Reîncărcăm datele în DataSet și DataGridView-ul fiu
                    dataSet.Tables["Cursuri"].Clear();
                    cursAdapter.Fill(dataSet, "Cursuri");
                }
                else
                {
                    MessageBox.Show("Vă rugăm să selectați un curs pentru  actualizare.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul actualizării cursului: " + ex.Message);
                connection.Close();
            }
        }





        // Declarați o variabilă globală pentru a reține ID-ul profesorului selectat
        private int selectedProfessorID = -1;

        private void dataGridViewParinte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewParinte.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridViewParinte.Rows[e.RowIndex];
                object value = selectedRow.Cells[0].Value; // Accesăm prima coloană pentru ID-ul profesorului
                
                selectedProfessorID = Convert.ToInt32(value);
            }
        }





        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (selectedProfessorID != -1)
                {
                    // Obținem valorile pentru noua înregistrare fiu din TextBox-uri sau alte controale
                    string newName = textBox2.Text;
                    string newDescriere = textBox3.Text;
                    int newPid = selectedProfessorID; // ID-ul profesorului selectat
                    textBox2.Clear();
                    textBox3.Clear();

                    // Adăugăm o nouă înregistrare fiu
                    SqlCommand cmd = new SqlCommand("INSERT INTO Cursuri (nume_curs, descriere, profesorID) VALUES (@name, @descriere, @pid)", connection);
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@descriere", newDescriere);
                    cmd.Parameters.AddWithValue("@pid", newPid); // Setăm cheia străină cu cheia primară a înregistrării părinte

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Cursul a fost adăugat cu succes.");

                    // Reîncărcăm datele în DataSet și DataGridView-ul fiu
                    dataSet.Tables["Cursuri"].Clear();
                    cursAdapter.Fill(dataSet, "Cursuri");
                }
                else
                {
                    MessageBox.Show("Vă rugăm să selectați un profesor înainte de a adăuga un curs.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul adăugării cursului: " + ex.Message);
            }
        }






    }

}