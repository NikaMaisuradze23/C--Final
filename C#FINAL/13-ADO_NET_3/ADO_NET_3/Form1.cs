using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO_NET_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            comm_1.CommandText = "SELECT COUNT(*) FROM Personali";
            object countResult = comm_1.ExecuteScalar();
            label1.Text = countResult.ToString();
            //
            comm_1.CommandText = "SELECT COUNT(*) FROM Personali WHERE qalaqi = N'თბილისი'";
            object countResult_1 = comm_1.ExecuteScalar();
            label7.Text = countResult_1.ToString();
            //
            comm_1.CommandText = "SELECT SUM(xelfasi) FROM Personali";
            Object sumResult = comm_1.ExecuteScalar();
            label8.Text = sumResult.ToString();
            //
            comm_1.CommandText = "SELECT AVG(xelfasi) FROM Personali";
            Object avgResult = comm_1.ExecuteScalar();
            label9.Text = avgResult.ToString();
            //
            comm_1.CommandText = "SELECT MAX(staji) FROM Personali WHERE tarigi_dabadebis >= '12.22.1980'";
            Object maxResult = comm_1.ExecuteScalar();
            label10.Text = maxResult.ToString();
            //
            comm_1.CommandText = "SELECT MIN(asaki) FROM Personali WHERE staji > 10";
            Object minResult = comm_1.ExecuteScalar();
            label11.Text = minResult.ToString();
            //
            conn_1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlDataAdapter adap_Personali = new SqlDataAdapter("SELECT * FROM Personali", conn_1);
            DataSet ds_1 = new DataSet();
            adap_Personali.Fill(ds_1, "Personali");
            dataGridView1.DataSource = ds_1;
            dataGridView1.DataMember = "Personali";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            comm_1.CommandText = 
              "INSERT INTO Personali (gvari, ganyofileba, xelfasi, asaki, tarigi_dabadebis) " +
              "VALUES (@gvari, @ganyofileba, @xelfasi, @asaki, @tarigi_dabadebis)";
            comm_1.Parameters.Add("@gvari", SqlDbType.NVarChar,20);
            comm_1.Parameters.Add("@ganyofileba", SqlDbType.NVarChar, 20);
            comm_1.Parameters.Add("@xelfasi", SqlDbType.Float, 8);
            comm_1.Parameters.Add("@asaki", SqlDbType.Int);
            comm_1.Parameters.Add("@tarigi_dabadebis", SqlDbType.DateTime, 8);

            comm_1.Parameters["@gvari"].Value = textBox1.Text;
            comm_1.Parameters["@ganyofileba"].Value = textBox2.Text;
            comm_1.Parameters["@xelfasi"].Value = double.Parse(textBox3.Text);
            comm_1.Parameters["@asaki"].Value = int.Parse(textBox4.Text);
            comm_1.Parameters["@tarigi_dabadebis"].Value = dateTimePicker1.Value;
            
            //int asaki = int.Parse(textBox4.Text);
            //comm_1.Parameters.AddWithValue("@asaki", asaki);
            
            int rowsAffected = comm_1.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn_1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            //comm_1.CommandText = "UPDATE Personali SET xelfasi = xelfasi * 1.10";
            //comm_1.CommandText = "UPDATE Personali SET xelfasi = xelfasi * 1.1 WHERE asaki > 35";
            //comm_1.CommandText = "UPDATE Personali SET xelfasi = xelfasi * 1.1 WHERE tarigi_dabadebis >= '01.01.1985'";
            comm_1.CommandText = "UPDATE Personali SET xelfasi = xelfasi * 1.1 WHERE ganyofileba = N'სასპორტო'";

            int rowsAffected = comm_1.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn_1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            comm_1.CommandText = 
                       "UPDATE Personali SET xelfasi = xelfasi + @xelfasi WHERE ganyofileba = @ganyofileba";
            comm_1.Parameters.Add("@xelfasi", SqlDbType.Float, 8);
            comm_1.Parameters.Add("@ganyofileba", SqlDbType.NVarChar, 20);
            comm_1.Parameters["@xelfasi"].Value = double.Parse(textBox3.Text);
            comm_1.Parameters["@ganyofileba"].Value = textBox2.Text;

            int rowsAffected = comm_1.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn_1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            comm_1.CommandText =
                       "UPDATE Personali SET xelfasi = xelfasi + @xelfasi, staji = staji + @staji";
            comm_1.Parameters.Add("@xelfasi", SqlDbType.Float, 8);
            comm_1.Parameters.Add("@staji", SqlDbType.Int, 4);
            comm_1.Parameters["@xelfasi"].Value = double.Parse(textBox3.Text);
            comm_1.Parameters["@staji"].Value = int.Parse(textBox4.Text);

            int rowsAffected = comm_1.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn_1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            comm_1.CommandText = "DELETE FROM Personali WHERE personaliID = @personaliID";
            comm_1.Parameters.Add("@personaliID", SqlDbType.Int);
            comm_1.Parameters["@personaliID"].Value = int.Parse(textBox1.Text);

            int rowsAffected = comm_1.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn_1.Close();
        }
    }
}
