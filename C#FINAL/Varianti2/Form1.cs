using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Varianti2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 obj = new Class1();
            int ricxvi = Convert.ToInt32(textBox1.Text);

            obj.ChemiTviseba = ricxvi;
            label2.Text = obj.ChemiTviseba.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            Random Shemtxveviti_Ricxvebi = new Random();
            int[] masivi = new int[15000];
            for (int i = 0; i < masivi.Length; i++)
                masivi[i] = Shemtxveviti_Ricxvebi.Next();

            // LINQ მოთხოვნის ფორმირება
            var shedegi =
            from cvladi in masivi
            where cvladi < 55000 && cvladi % 2 == 1
            select cvladi;

            foreach (var elementi in shedegi)
                label3.Text += elementi.ToString() + " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn_1 = new SqlConnection("server=BTU306-L\\SQLEXPRESS; database=Shekveta; uid=sa; pwd=1");
            conn_1.Open();
            SqlCommand comm_1 = conn_1.CreateCommand();
            comm_1.CommandText = "SELECT COUNT(*) FROM Personali";
            object countResult = comm_1.ExecuteScalar();
            label3.Text = countResult.ToString();
         
        }




    }
    }
}
