using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SGBDLAB1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOPEL\\SQLEXPRESS;Initial Catalog=DepartamentBd;Integrated Security=True");
        SqlDataAdapter departmentsAdapter = new SqlDataAdapter();
        SqlDataAdapter employeesAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'departamentBdDataSet2.Angajati' table. You can move, or remove it, as needed.
            this.angajatiTableAdapter.Fill(this.departamentBdDataSet2.Angajati);
            // TODO: This line of code loads data into the 'departamentBdDataSet1.Departamente' table. You can move, or remove it, as needed.
            this.departamenteTableAdapter.Fill(this.departamentBdDataSet1.Departamente);

        }

        //DEPARTAMENT = PARINTE,  ANGAJATI = FIU
        //CERINTA1:- să se afişeze toate înregistrările tabelei părinte;
        private void conectareD_Click(object sender, EventArgs e)
        {
           // Incarcare date Departamente
            departmentsAdapter.SelectCommand = new SqlCommand("SELECT * FROM Departamente", connection);
            departmentsAdapter.Fill(dataSet, "Departamente");
            dataGridView1.DataSource = dataSet.Tables["Departamente"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Incarcare date Angajati (initial fara filtrare)
            employeesAdapter.SelectCommand = new SqlCommand("SELECT * FROM Angajati", connection);
            employeesAdapter.Fill(dataSet, "Angajati");
            dataGridView2.DataSource = dataSet.Tables["Angajati"];

        }

        //CERINTA2: a selectarea unei înregistrări din părinte, se vor afişa toate înregistrările tabelei fiu
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificăm dacă a fost introdus un ID de DEPARTAMENT valid în TextBox1
                if (!int.TryParse(textBox1.Text, out int DepartamentID))
                {
                    MessageBox.Show("Introduceți un ID de Departament valid.");
                    return;
                }

                // Interogare SQL pentru a selecta angajatii pentru departamentul dat
                string query = "SELECT * FROM Angajati WHERE DepartamentID = @did";

                // Creăm comanda SQL și adăugăm parametrul pentru ID-ul departamentului
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@did", DepartamentID);

                // Deschidem conexiunea și executăm comanda SQL pentru a obține rezultatele
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Verificăm dacă există rânduri de date
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Afișăm rezultatele în DataGridView
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Nu s-au găsit angajati pentru departamentul specificat.");
                }

                // Închidem conexiunea
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul afișării angajatilor: " + ex.Message);
            }
        }
        //CERINTA4: având selectată o înregistrare din părinte, se permite adăugarea unei noi înregistrări fiu.
        //INSERT INTO ANGAJATI
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                employeesAdapter.InsertCommand = new SqlCommand("INSERT INTO Angajati (NumeAngajat, DepartamentID) VALUES(@na, @did)", connection);
                employeesAdapter.InsertCommand.Parameters.Add("@na", SqlDbType.VarChar).Value = textBox2.Text;
                employeesAdapter.InsertCommand.Parameters.Add("@did", SqlDbType.Int).Value =
               Int32.Parse(textBox3.Text);
                
                connection.Open();
                employeesAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted Succesfull to the Database");
                connection.Close();
                // already inserted - apear in the list
                employeesAdapter.Fill(dataSet);
                dataGridView2.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        //CERINTA 3: a selectarea unei înregistrări din fiu, trebuie să se permită ştergerea sau actualziarea datelor acesteia
        //DELETE ANGAJAT DUPA ID BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox4.Text, out int AngajatID))
                {
                    
                    return;
                }
                // Ștergem înregistrarea fiu
                SqlCommand cmd = new SqlCommand("DELETE FROM Angajati WHERE AngajatID = @aid", connection);
                cmd.Parameters.AddWithValue("@aid", AngajatID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                // Afișăm un mesaj de confirmare
                MessageBox.Show("angajatul a fost șters cu succes.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul ștergerii angajatului: " + ex.Message);
            }
        }


        ////UPDATE ANGAJAT DUPA ID BUTTON
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Obținem ID-ul angajatului pentru actualizare
                int AngajatID = int.Parse(textBox5.Text);

                // Obținem noile valori pentru câmpurile algajatului din TextBox-urile corespunzătoare
                string newName = textBox6.Text;
                int newIDD = int.Parse(textBox7.Text);
                
                // Actualizăm înregistrarea fiu cu noile valori
                SqlCommand cmd = new SqlCommand("UPDATE Angajati SET NumeAngajat = @name, DepartamentID = @did WHERE AngajatID = @aid", connection);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@did", newIDD);
                cmd.Parameters.AddWithValue("@aid", AngajatID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                // Afișăm un mesaj de confirmare
                MessageBox.Show("Angajatul a fost actualizat cu succes.");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare în timpul actualizării angajatului: " + ex.Message);
            }
        }
    }
}
