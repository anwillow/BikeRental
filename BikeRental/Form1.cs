using System;
using System.Data;
using System.Data.OleDb;

namespace BikeRentalApp
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dozor\source\repos\BikeRentalApp\BikeRentalApp\Database3.accdb;";
        private OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string password = Microsoft.VisualBasic.Interaction.InputBox("Please, enter admin password.", "Admin confirmation", "");
            if (password == "1231")
            {
                MessageBox.Show("Welcome back, Admin!");

                dataGridView4.Visible = false;
                dataGridView3.Visible = false;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                button3.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
            }
            else
            {
                MessageBox.Show("Incorrect password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                dataGridView4.Visible = false;
                dataGridView3.Visible = false;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                button3.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenConnection();

            string query = "SELECT Type, City, Status FROM Bike WHERE Status = 'available'";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            dataGridView4.ReadOnly = true;

            dataGridView4.Visible = false;
            dataGridView3.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            button3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;

            CloseConnection();
        }


        public void OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connecting with DB opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while opening connection with DB " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Connecting with DB closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while closing connection with DB: " + ex.Message);
            }
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Запрос выполнен успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении запроса: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = false;
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            button3.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenConnection();

            string query = "SELECT * FROM Bike";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            dataGridView2.ReadOnly = false;
            dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.Visible = false;
            }

            dataGridView2.Columns["Type"].Visible = true;
            dataGridView2.Columns["City"].Visible = true;
            dataGridView2.Columns["Status"].Visible = true;

            dataGridView4.Visible = false;
            dataGridView3.Visible = false;
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = false;
            button10.Visible = false;

            CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenConnection();

            string query = "SELECT * FROM Trip";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView3.DataSource = dataTable;
            dataGridView3.ReadOnly = false;
            dataGridView4.CommitEdit(DataGridViewDataErrorContexts.Commit);

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.Visible = false;
            }

            dataGridView3.Columns["Bike_ID"].Visible = true;
            dataGridView3.Columns["Acc_ID"].Visible = true;
            dataGridView3.Columns["City"].Visible = true;

            dataGridView4.Visible = false;
            dataGridView3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = true;
            button10.Visible = false;

            CloseConnection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenConnection();

            string query = "SELECT * FROM Acc";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView4.DataSource = dataTable;
            dataGridView4.ReadOnly = false;
            dataGridView4.CommitEdit(DataGridViewDataErrorContexts.Commit);

            foreach (DataGridViewColumn column in dataGridView4.Columns)
            {
                column.Visible = false;
            }

            dataGridView4.Columns["Name"].Visible = true;
            dataGridView4.Columns["Surname"].Visible = true;
            dataGridView4.Columns["Age"].Visible = true;
            dataGridView4.Columns["Email"].Visible = true;
            dataGridView4.Columns["Phone"].Visible = true;

            dataGridView4.Visible = true;
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = true;

            CloseConnection();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = false;
            dataGridView3.Visible = false;
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            button3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            SaveChanges2();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SaveChanges3();
        }
        private void SaveChanges()
        {
            OpenConnection();

            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Bike", connection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Update((DataTable)dataGridView2.DataSource);

            CloseConnection();
        }
        private void SaveChanges2()
        {
            OpenConnection();

            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Trip", connection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Update((DataTable)dataGridView3.DataSource);

            CloseConnection();
        }
        private void SaveChanges3()
        {
            OpenConnection();

            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Acc", connection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Update((DataTable)dataGridView4.DataSource);

            CloseConnection();
        }
    }
}
