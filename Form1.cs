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

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(
        @"Data Source=localhost;Initial Catalog=StudentDB;Integrated Security=True;TrustServerCertificate=True");

        public Form1()
        {
            InitializeComponent();
        }

        void LoadData()

        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            btnAdd.BackColor = Color.RoyalBlue;
            btnAdd.ForeColor = Color.White;

            btnEdit.BackColor = Color.SeaGreen;
            btnEdit.ForeColor = Color.White;

            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;

            btnRefresh.BackColor = Color.DimGray;
            btnRefresh.ForeColor = Color.White;

            if (dataGridView1.Columns.Count >= 4)
            {
                dataGridView1.Columns[0].HeaderText = "Student ID";
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[2].HeaderText = "Gender";
                dataGridView1.Columns[3].HeaderText = "Login";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Students (ID, Name, Gender, Login) VALUES (@id,@name,@gender,@login)", conn);

            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@gender", cbGender.Text);
            cmd.Parameters.AddWithValue("@login", txtLogin.Text);

            cmd.ExecuteNonQuery();

            conn.Close();

            LoadData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbGender.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtLogin.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        private void dtBirthDate(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
                "UPDATE Students SET Name=@name, Gender=@gender, Login=@login WHERE ID=@id", conn);

            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@gender", cbGender.Text);
            cmd.Parameters.AddWithValue("@login", txtLogin.Text);

            cmd.ExecuteNonQuery();

            conn.Close();

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Students WHERE ID=@id", conn);

            cmd.Parameters.AddWithValue("@id", txtID.Text);

            cmd.ExecuteNonQuery();

            conn.Close();

            LoadData();
        }
    }
}
