using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PhoneDirectory
{
    public partial class Phone : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Phone;Integrated Security=True");
        public Phone()
        {
            InitializeComponent();
        }
        private void Phone_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Clear();
            textBox2.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox5.Clear();
            textBox6.Text = "";
            textBox6.Clear();
            textBox7.Text = "";
            textBox7.Clear();
            textBox1.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "INSERT INTO [Table](UUID,Name,Surname,Company,PhoneNumber,Email,Location) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = textBox2.Text;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = textBox3.Text;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = textBox4.Text;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = textBox5.Text;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = textBox6.Text;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = textBox7.Text;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM [Table] WHERE Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Deleted Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from [Table]",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE [Table] (UUID,Name,Surname,Company,PhoneNumber,Email,Location) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7) WHERE UUID ='@UUID'", con);
            cmd.Parameters.AddWithValue("@param1", textBox1.Text);
            cmd.Parameters.AddWithValue("@param2", textBox2.Text);
            cmd.Parameters.AddWithValue("@param3", textBox3.Text);
            cmd.Parameters.AddWithValue("@param4", textBox4.Text);
            cmd.Parameters.AddWithValue("@param5", textBox5.Text);
            cmd.Parameters.AddWithValue("@param6", textBox6.Text);
            cmd.Parameters.AddWithValue("@param7", textBox7.Text);

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Updated Successfully");
        }
    }
}
