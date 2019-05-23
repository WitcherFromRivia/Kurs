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

namespace Kurs
{
    public partial class Form1 : Form
    {
        SqlConnection SqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Roman\source\repos\Kurs\Kurs\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);
            await SqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Library]", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]));
                    listBox2.Items.Add(Convert.ToString(sqlReader["Название книги"]));
                    listBox3.Items.Add(Convert.ToString(sqlReader["Автор"]));
                    listBox4.Items.Add(Convert.ToString(sqlReader["Год издания"]));
                    listBox5.Items.Add(Convert.ToString(sqlReader["Издательство"]));
                    listBox6.Items.Add(Convert.ToString(sqlReader["Цена в гривнах"]));
                    listBox7.Items.Add(Convert.ToString(sqlReader["Состояние"]));
                    listBox8.Items.Add(Convert.ToString(sqlReader["Дата выдачи читателю"]));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
                SqlConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
                SqlConnection.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label17.Visible)
                label17.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            { 
            SqlCommand command = new SqlCommand("INSERT INTO [Library] (Название книги,Автор,Год издания,Издательство,Цена в гривнах,Состояние,Дата выдачи читателю)VALUES(@Название книги,@Автор,@Год издания,@Издательство,@Цена в гривнах,@Состояние,@Дата выдачи читателю)", SqlConnection);
            command.Parameters.AddWithValue("Название книги", textBox1.Text);
            command.Parameters.AddWithValue("Автор", textBox2.Text);
            command.Parameters.AddWithValue("Год издания", textBox3.Text);
            command.Parameters.AddWithValue("Издательство", textBox4.Text);
            command.Parameters.AddWithValue("Цена в гривнах", textBox5.Text);
            command.Parameters.AddWithValue("Состояние", textBox6.Text);
            command.Parameters.AddWithValue("Дата выдачи читателю", textBox7.Text);
                await command.ExecuteNonQueryAsync();
        }
            else
            {
                label17.Visible = true;
                label17.Text = "Все поля должны быть заполнены!";
            }

        }

        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Library]", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]));
                    listBox2.Items.Add(Convert.ToString(sqlReader["Название книги"]));
                    listBox3.Items.Add(Convert.ToString(sqlReader["Автор"]));
                    listBox4.Items.Add(Convert.ToString(sqlReader["Год издания"]));
                    listBox5.Items.Add(Convert.ToString(sqlReader["Издательство"]));
                    listBox6.Items.Add(Convert.ToString(sqlReader["Цена в гривнах"]));
                    listBox7.Items.Add(Convert.ToString(sqlReader["Состояние"]));
                    listBox8.Items.Add(Convert.ToString(sqlReader["Дата выдачи читателю"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
    }
}
