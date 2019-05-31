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
                    listBox2.Items.Add(Convert.ToString(sqlReader["Книга"]));
                    listBox3.Items.Add(Convert.ToString(sqlReader["Автор"]));
                    listBox4.Items.Add(Convert.ToString(sqlReader["Год"]));
                    listBox5.Items.Add(Convert.ToString(sqlReader["Издательство"]));
                    listBox6.Items.Add(Convert.ToString(sqlReader["Ценавгривнах"]));
                    listBox7.Items.Add(Convert.ToString(sqlReader["Состояние"]));
                    listBox8.Items.Add(Convert.ToString(sqlReader["Датавыдачичитателю"]));
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
            if (label28.Visible)
                label28.Visible = false;
            if (label30.Visible)
                label30.Visible = false;
            

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                textBox6.Text=="Плохое" || textBox6.Text == "Нормальное" || textBox6.Text == "Хорошое" &&
                textBox3.Text.ToString()== "2019" && textBox3.Text.ToString() == "2018" && textBox3.Text.ToString() == "2017"
                && textBox3.Text.ToString() == "2016" && textBox3.Text.ToString() == "2015" && textBox3.Text.ToString() == "2014" 
                && textBox3.Text.ToString() == "2013" && textBox3.Text.ToString() == "2014" && textBox3.Text.ToString() == "2013"
                && textBox3.Text.ToString() == "2012" && textBox3.Text.ToString() == "2011" && textBox3.Text.ToString() == "2010" 
                && textBox3.Text.ToString() == "2009" && textBox3.Text.ToString() == "2008" && textBox3.Text.ToString() == "2007"
                && textBox3.Text.ToString() == "2006" && textBox3.Text.ToString() == "2007" && textBox3.Text.ToString() == "2005" &&
                textBox3.Text.ToString() == "2004" && textBox3.Text.ToString() == "2003" && textBox3.Text.ToString() == "2002" &&
                textBox3.Text.ToString() == "2001" && textBox3.Text.ToString() == "2000" && textBox3.Text.ToString() == "1999" &&
                textBox3.Text.ToString() == "1998" && textBox3.Text.ToString() == "1997" && textBox3.Text.ToString() == "1996" &&
                textBox3.Text.ToString() == "1995" && textBox3.Text.ToString() == "1994" && textBox3.Text.ToString() == "1993" &&
                textBox3.Text.ToString() == "1992" && textBox3.Text.ToString() == "1991" && textBox3.Text.ToString() == "1990" &&
                textBox3.Text.ToString() == "1989" && textBox3.Text.ToString() == "1988" && textBox3.Text.ToString() == "1987" &&
                textBox3.Text.ToString() == "1986" && textBox3.Text.ToString() == "1985" && textBox3.Text.ToString() == "1984" &&
                textBox3.Text.ToString() == "1983" && textBox3.Text.ToString() == "1982" && textBox3.Text.ToString() == "1981" &&
                textBox3.Text.ToString() == "1980" &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) )
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Library] (Книга,Автор,Год,Издательство,Ценавгривнах,Состояние,Датавыдачичитателю)VALUES(@Книга,@Автор,@Год,@Издательство,@Ценавгривнах,@Состояние,@Датавыдачичитателю)", SqlConnection);
                command.Parameters.AddWithValue("Книга", textBox1.Text);
                command.Parameters.AddWithValue("Автор", textBox2.Text);
                command.Parameters.AddWithValue("Год", textBox3.Text);
                command.Parameters.AddWithValue("Издательство", textBox4.Text);
                command.Parameters.AddWithValue("Ценавгривнах", textBox5.Text);
                command.Parameters.AddWithValue("Состояние", textBox6.Text);
                command.Parameters.AddWithValue("Датавыдачичитателю", textBox7.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (textBox3.Text.ToString() != "2019" && textBox3.Text.ToString() != "2018" && textBox3.Text.ToString() != "2017"
                && textBox3.Text.ToString() != "2016" && textBox3.Text.ToString() != "2015" && textBox3.Text.ToString() != "2014"
                && textBox3.Text.ToString() != "2013" && textBox3.Text.ToString() != "2014" && textBox3.Text.ToString() != "2013"
                && textBox3.Text.ToString() != "2012" && textBox3.Text.ToString() != "2011" && textBox3.Text.ToString() != "2010"
                && textBox3.Text.ToString() != "2009" && textBox3.Text.ToString() != "2008" && textBox3.Text.ToString() != "2007"
                && textBox3.Text.ToString() != "2006" && textBox3.Text.ToString() != "2007" && textBox3.Text.ToString() != "2005" &&
                textBox3.Text.ToString() != "2004" && textBox3.Text.ToString() != "2003" && textBox3.Text.ToString() != "2002" &&
                textBox3.Text.ToString() != "2001" && textBox3.Text.ToString() != "2000" && textBox3.Text.ToString() != "1999" &&
                textBox3.Text.ToString() != "1998" && textBox3.Text.ToString() != "1997" && textBox3.Text.ToString() != "1996" &&
                textBox3.Text.ToString() != "1995" && textBox3.Text.ToString() != "1994" && textBox3.Text.ToString() != "1993" &&
                textBox3.Text.ToString() != "1992" && textBox3.Text.ToString() != "1991" && textBox3.Text.ToString() != "1990" &&
                textBox3.Text.ToString() != "1989" && textBox3.Text.ToString() != "1988" && textBox3.Text.ToString() != "1987" &&
                textBox3.Text.ToString() != "1986" && textBox3.Text.ToString() != "1985" && textBox3.Text.ToString() != "1984" &&
                textBox3.Text.ToString() != "1983" && textBox3.Text.ToString() != "1982" && textBox3.Text.ToString() != "1981" &&
                textBox3.Text.ToString() != "1980")
            {

                label30.Visible = true;
                label30.Text = "Вы ввели неверное значение!";
            }
            else if(textBox6.Text != "Плохое" || textBox6.Text != "Нормальное" || textBox6.Text != "Хорошое") { 

                label28.Visible = true;
                label28.Text = "Вы ввели неверное значение!";
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
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Library]", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]));
                    listBox2.Items.Add(Convert.ToString(sqlReader["Книга"]));
                    listBox3.Items.Add(Convert.ToString(sqlReader["Автор"]));
                    listBox4.Items.Add(Convert.ToString(sqlReader["Год"]));
                    listBox5.Items.Add(Convert.ToString(sqlReader["Издательство"]));
                    listBox6.Items.Add(Convert.ToString(sqlReader["Ценавгривнах"]));
                    listBox7.Items.Add(Convert.ToString(sqlReader["Состояние"]));
                    listBox8.Items.Add(Convert.ToString(sqlReader["Датавыдачичитателю"]));
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

        private async void button2_Click(object sender, EventArgs e)
        {

            if (label18.Visible)
                label18.Visible = false;
            if (label29.Visible)
                label29.Visible = false;
            if (label31.Visible)
                label31.Visible = false;
            if (label32.Visible)
                label32.Visible = false;
            if (label33.Visible)
                label33.Visible = false;

            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                textBox9.Text == "Плохое" || textBox9.Text == "Нормальное" || textBox9.Text == "Хорошое" &&
                textBox12.Text.ToString() == "2019" && textBox12.Text.ToString() == "2018" && textBox12.Text.ToString() == "2017"
                && textBox12.Text.ToString() == "2016" && textBox12.Text.ToString() == "2015" && textBox12.Text.ToString() == "2014"
                && textBox12.Text.ToString() == "2013" && textBox12.Text.ToString() == "2014" && textBox12.Text.ToString() == "2013"
                && textBox12.Text.ToString() == "2012" && textBox12.Text.ToString() == "2011" && textBox12.Text.ToString() == "2010"
                && textBox12.Text.ToString() == "2009" && textBox12.Text.ToString() == "2008" && textBox12.Text.ToString() == "2007"
                && textBox12.Text.ToString() == "2006" && textBox12.Text.ToString() == "2007" && textBox12.Text.ToString() == "2005" &&
                textBox12.Text.ToString() == "2004" && textBox12.Text.ToString() == "2003" && textBox12.Text.ToString() == "2002" &&
                textBox12.Text.ToString() == "2001" && textBox12.Text.ToString() == "2000" && textBox12.Text.ToString() == "1999" &&
                textBox12.Text.ToString() == "1998" && textBox12.Text.ToString() == "1997" && textBox12.Text.ToString() == "1996" &&
                textBox12.Text.ToString() == "1995" && textBox12.Text.ToString() == "1994" && textBox12.Text.ToString() == "1993" &&
                textBox12.Text.ToString() == "1992" && textBox12.Text.ToString() == "1991" && textBox12.Text.ToString() == "1990" &&
                textBox12.Text.ToString() == "1989" && textBox12.Text.ToString() == "1988" && textBox12.Text.ToString() == "1987" &&
                textBox12.Text.ToString() == "1986" && textBox12.Text.ToString() == "1985" && textBox12.Text.ToString() == "1984" &&
                textBox12.Text.ToString() == "1983" && textBox12.Text.ToString() == "1982" && textBox12.Text.ToString() == "1981" &&
                textBox12.Text.ToString() == "1980" &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                !string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                !string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text) && textBox15.Text== textBox21.Text)
            {

                SqlCommand command = new SqlCommand("UPDATE [Library] SET Книга=@Книга,Автор=@Автор,Год=@Год,Издательство=@Издательство,Ценавгривнах=@Ценавгривнах,Состояние=@Состояние,Датавыдачичитателю=@Датавыдачичитателю WHERE Id=@Id", SqlConnection);
                command.Parameters.AddWithValue("@Id", textBox16.Text);
             
                command.Parameters.AddWithValue("@Книга", textBox14.Text);
                command.Parameters.AddWithValue("@Автор", textBox13.Text);
                command.Parameters.AddWithValue("@Год", textBox12.Text);
                command.Parameters.AddWithValue("@Издательство", textBox11.Text);
                command.Parameters.AddWithValue("@Ценавгривнах", textBox10.Text);
                command.Parameters.AddWithValue("@Состояние", textBox9.Text);
                command.Parameters.AddWithValue("@Датавыдачичитателю", textBox8.Text);
                await command.ExecuteNonQueryAsync();


            }
            else if (textBox12.Text.ToString() != "2019" && textBox12.Text.ToString() != "2018" && textBox12.Text.ToString() != "2017"
                && textBox12.Text.ToString() != "2016" && textBox12.Text.ToString() != "2015" && textBox12.Text.ToString() != "2014"
                && textBox12.Text.ToString() != "2013" && textBox12.Text.ToString() != "2014" && textBox12.Text.ToString() != "2013"
                && textBox12.Text.ToString() != "2012" && textBox12.Text.ToString() != "2011" && textBox12.Text.ToString() != "2010"
                && textBox12.Text.ToString() != "2009" && textBox12.Text.ToString() != "2008" && textBox12.Text.ToString() != "2007"
                && textBox12.Text.ToString() != "2006" && textBox12.Text.ToString() != "2007" && textBox12.Text.ToString() != "2005" &&
                textBox12.Text.ToString() != "2004" && textBox12.Text.ToString() != "2003" && textBox12.Text.ToString() != "2002" &&
                textBox12.Text.ToString() != "2001" && textBox12.Text.ToString() != "2000" && textBox12.Text.ToString() != "1999" &&
                textBox12.Text.ToString() != "1998" && textBox12.Text.ToString() != "1997" && textBox12.Text.ToString() != "1996" &&
                textBox12.Text.ToString() != "1995" && textBox12.Text.ToString() != "1994" && textBox12.Text.ToString() != "1993" &&
                textBox12.Text.ToString() != "1992" && textBox12.Text.ToString() != "1991" && textBox12.Text.ToString() != "1990" &&
                textBox12.Text.ToString() != "1989" && textBox12.Text.ToString() != "1988" && textBox12.Text.ToString() != "1987" &&
                textBox12.Text.ToString() != "1986" && textBox12.Text.ToString() != "1985" && textBox12.Text.ToString() != "1984" &&
                textBox12.Text.ToString() != "1983" && textBox12.Text.ToString() != "1982" && textBox12.Text.ToString() != "1981" &&
                textBox12.Text.ToString() != "1980" )
            {

                label31.Visible = true;
                label31.Text = "Вы ввели неверное значение!";
            }
            else if (textBox9.Text != "Плохое" || textBox9.Text != "Нормальное" || textBox9.Text != "Хорошое")
            {

                label29.Visible = true;
                label29.Text = "Вы ввели неверное значение!";
            }

            else if(textBox15.Text != textBox21.Text)
            {
                label32.Visible = true;
                label32.Text = "Вы ввели не верный пароль!";
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                label32.Visible = true;
                label32.Text = "Введите пароль";
            }
            else if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text))
            {
                label33.Visible = true;
                label33.Text = "Пожалуйста,запишите Id!";
            }
            
            else
            {
                label18.Visible = true;
                label18.Text = "Все поля должны быть заполнены!";
            }
        }


        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label19.Visible)
                label19.Visible = false;
            if (!string.IsNullOrEmpty(textBox17.Text) && !string.IsNullOrWhiteSpace(textBox17.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Library] WHERE [Id]=@Id",SqlConnection);
                command.Parameters.AddWithValue("@Id", textBox17.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label19.Visible = true;
                label19.Text = "Все поля должны быть заполнены!";
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Id,Книга,Автор,Год,Издательство,Ценавгривнах,Состояние,Датавыдачичитателю FROM Library WHERE Ценавгривнах>=100", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]));
                    listBox2.Items.Add(Convert.ToString(sqlReader["Книга"]));
                    listBox3.Items.Add(Convert.ToString(sqlReader["Автор"]));
                    listBox4.Items.Add(Convert.ToString(sqlReader["Год"]));
                    listBox5.Items.Add(Convert.ToString(sqlReader["Издательство"]));
                    listBox6.Items.Add(Convert.ToString(sqlReader["Ценавгривнах"]));
                    listBox7.Items.Add(Convert.ToString(sqlReader["Состояние"]));
                    listBox8.Items.Add(Convert.ToString(sqlReader["Датавыдачичитателю"]));
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

        private async void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM Library WHERE Автор='Андерсон'", SqlConnection);
            try
            {
               
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox1.Items.Add(Convert.ToString(sqlReader["Id"]));
                        listBox2.Items.Add(Convert.ToString(sqlReader["Книга"]));
                        listBox3.Items.Add(Convert.ToString(sqlReader["Автор"]));
                        listBox4.Items.Add(Convert.ToString(sqlReader["Год"]));
                        listBox5.Items.Add(Convert.ToString(sqlReader["Издательство"]));
                        listBox6.Items.Add(Convert.ToString(sqlReader["Ценавгривнах"]));
                        listBox7.Items.Add(Convert.ToString(sqlReader["Состояние"]));
                        listBox8.Items.Add(Convert.ToString(sqlReader["Датавыдачичитателю"]));
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
    

        private async void button6_Click(object sender, EventArgs e)
        {
            if (label24.Visible)
                label24.Visible = false;
            if (label34.Visible)
                label34.Visible = false;
            if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text)&& 
                !string.IsNullOrEmpty(textBox20.Text) &&!string.IsNullOrWhiteSpace(textBox20.Text) &&
                textBox19.Text == "Плохое" || textBox19.Text == "Нормальное" || textBox19.Text == "Хорошое" &&
                textBox20.Text.ToString() == "2019" && textBox20.Text.ToString() == "2018" && textBox20.Text.ToString() == "2017"
                && textBox20.Text.ToString() == "2016" && textBox20.Text.ToString() == "2015" && textBox20.Text.ToString() == "2014"
                && textBox20.Text.ToString() == "2013" && textBox20.Text.ToString() == "2014" && textBox20.Text.ToString() == "2013"
                && textBox20.Text.ToString() == "2012" && textBox20.Text.ToString() == "2011" && textBox20.Text.ToString() == "2010"
                && textBox20.Text.ToString() == "2009" && textBox20.Text.ToString() == "2008" && textBox20.Text.ToString() == "2007"
                && textBox20.Text.ToString() == "2006" && textBox20.Text.ToString() == "2007" && textBox20.Text.ToString() == "2005" &&
                textBox20.Text.ToString() == "2004" && textBox20.Text.ToString() == "2003" && textBox20.Text.ToString() == "2002" &&
                textBox20.Text.ToString() == "2001" && textBox20.Text.ToString() == "2000" && textBox20.Text.ToString() == "1999" &&
                textBox20.Text.ToString() == "1998" && textBox20.Text.ToString() == "1997" && textBox20.Text.ToString() == "1996" &&
                textBox20.Text.ToString() == "1995" && textBox20.Text.ToString() == "1994" && textBox20.Text.ToString() == "1993" &&
                textBox20.Text.ToString() == "1992" && textBox20.Text.ToString() == "1991" && textBox20.Text.ToString() == "1990" &&
                textBox20.Text.ToString() == "1989" && textBox20.Text.ToString() == "1988" && textBox20.Text.ToString() == "1987" &&
                textBox20.Text.ToString() == "1986" && textBox20.Text.ToString() == "1985" && textBox20.Text.ToString() == "1984" &&
                textBox20.Text.ToString() == "1983" && textBox20.Text.ToString() == "1982" && textBox20.Text.ToString() == "1981" &&
                textBox20.Text.ToString() == "1980")
            {

                SqlCommand command = new SqlCommand("UPDATE [Library] SET Состояние=@Состояние WHERE Год=@Год", SqlConnection);
                command.Parameters.AddWithValue("@Состояние", textBox19.Text);
                command.Parameters.AddWithValue("@Год", textBox20.Text);

                await command.ExecuteNonQueryAsync();


            }
            else if (textBox19.Text != "Плохое" || textBox19.Text != "Нормальное" || textBox19.Text != "Хорошое")
            {

                label24.Visible = true;
                label24.Text = "Вы ввели неверное значение!";
            }
            else if (textBox20.Text.ToString() != "2019" && textBox20.Text.ToString() != "2018" && textBox20.Text.ToString() != "2017"
                && textBox20.Text.ToString() != "2016" && textBox20.Text.ToString() != "2015" && textBox20.Text.ToString() != "2014"
                && textBox20.Text.ToString() != "2013" && textBox20.Text.ToString() != "2014" && textBox20.Text.ToString() != "2013"
                && textBox20.Text.ToString() != "2012" && textBox20.Text.ToString() != "2011" && textBox20.Text.ToString() != "2010"
                && textBox20.Text.ToString() != "2009" && textBox20.Text.ToString() != "2008" && textBox20.Text.ToString() != "2007"
                && textBox20.Text.ToString() != "2006" && textBox20.Text.ToString() != "2007" && textBox20.Text.ToString() != "2005" &&
                textBox20.Text.ToString() != "2004" && textBox20.Text.ToString() != "2003" && textBox20.Text.ToString() != "2002" &&
                textBox20.Text.ToString() != "2001" && textBox20.Text.ToString() != "2000" && textBox20.Text.ToString() != "1999" &&
                textBox20.Text.ToString() != "1998" && textBox20.Text.ToString() != "1997" && textBox20.Text.ToString() != "1996" &&
                textBox20.Text.ToString() != "1995" && textBox20.Text.ToString() != "1994" && textBox20.Text.ToString() != "1993" &&
                textBox20.Text.ToString() != "1992" && textBox20.Text.ToString() != "1991" && textBox20.Text.ToString() != "1990" &&
                textBox20.Text.ToString() != "1989" && textBox20.Text.ToString() != "1988" && textBox20.Text.ToString() != "1987" &&
                textBox20.Text.ToString() != "1986" && textBox20.Text.ToString() != "1985" && textBox20.Text.ToString() != "1984" &&
                textBox20.Text.ToString() != "1983" && textBox20.Text.ToString() != "1982" && textBox20.Text.ToString() != "1981" &&
                textBox20.Text.ToString() != "1980")
            {

                label34.Visible = true;
                label34.Text = "Вы ввели неверное значение!";
            }
            else
            {
                label24.Visible = true;
                label24.Text = "Все поля должны быть заполнены!";
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (label27.Visible)
                label27.Visible = false;
            if (!string.IsNullOrEmpty(textBox21.Text) && !string.IsNullOrWhiteSpace(textBox21.Text))
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO [Library] (Пароль) VALUES (@Пароль) ",SqlConnection);
                command1.Parameters.AddWithValue("@Пароль", textBox21.Text);
                await command1.ExecuteNonQueryAsync();
            }
            else
            {
                label27.Visible = true;
                label27.Text = "Введите пароль!";
            }
            SqlCommand command = new SqlCommand("DELETE FROM [Library] WHERE [Пароль]=@Пароль", SqlConnection);
            command.Parameters.AddWithValue("@Пароль", textBox21.Text);
            await command.ExecuteNonQueryAsync();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
    }

