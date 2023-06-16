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

namespace LINQ_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ricxvi_1 = 5;
            int ricxvi_2 = 10;
            var ricxvi_3 = ricxvi_1 + ricxvi_2;
            var ricxvi_4 = 5.5;
            var ricxvi_5 = ricxvi_1 + ricxvi_4;
            var masivi1 = new[] { 1, 2, 3, 4, 5 };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            string[] saxelebi = { "რომანი", "ანა", "გიორგი", "არჩილი", "სანდრო", "დავითი", 
                        "ვახტანგი", "ბექა", "ალექსანდრე", "საბა", "სიმონი", "ლია", "ლუკა" };
            // LINQ მოთხოვნის ფორმირება
            var shedegi = 
            from cvladi in saxelebi
            where cvladi.StartsWith("ს")
            select cvladi;

            foreach (var elementi in shedegi)
                label1.Text += elementi.ToString() + "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            string[] saxelebi = { "რომანი", "ანა", "გიორგი", "არჩილი", "სანდრო", "დავითი",
                        "ვახტანგი", "ბექა", "ალექსანდრე", "საბა", "სიმონი", "ლია", "ლუკა" };
            // LINQ მოთხოვნის ფორმირება
            var shedegi =
            from cvladi in saxelebi
            where cvladi.StartsWith("ს")
            orderby cvladi
            select cvladi;

            foreach (var elementi in shedegi)
                label2.Text += elementi.ToString() + "\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            string[] saxelebi = { "რომანი", "ანა", "გიორგი", "არჩილი", "სანდრო", "დავითი",
                        "ვახტანგი", "ბექა", "ალექსანდრე", "საბა", "სიმონი", "ლია", "ლუკა" };
            // LINQ მოთხოვნის ფორმირება
            var shedegi =
            from cvladi in saxelebi
            where cvladi.StartsWith("ს")
            orderby cvladi descending 
            select cvladi;

            foreach (var elementi in shedegi)
                label3.Text += elementi.ToString() + "\n";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Random Shemtxveviti_Ricxvebi = new Random();
            int[] masivi = new int[10000000];
            for (int i = 0; i < masivi.Length; i++)
                masivi[i] = Shemtxveviti_Ricxvebi.Next();
            // LINQ მოთხოვნის ფორმირება
            var shedegi =
            from cvladi in masivi
            where cvladi < 10500 && cvladi % 2 == 1
            select cvladi;

            foreach (var elementi in shedegi)
                label1.Text += elementi.ToString() + " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random Shemtxveviti_Ricxvebi = new Random();
            int[] masivi = new int[50345678];
            for (int i = 0; i < masivi.Length; i++)
                masivi[i] = Shemtxveviti_Ricxvebi.Next();
            // LINQ მოთხოვნის ფორმირება
            var shedegi =
            from cvladi in masivi
            where cvladi < 10000 
            select cvladi;
            // 
            label1.Text = "იმ რიცხვების რაოდენობა, რომელთა მნიშვნელობები < 10000" + " -   ";
            label1.Text += shedegi.Count().ToString() + '\n';
            label1.Text += "მაქსიმალური რიცხვი, რომელიც < 10000" + " -   ";
            label1.Text += shedegi.Max().ToString() + '\n';
            label1.Text += "მინიმალური რიცხვი, რომელიც < 10000" + " -   ";
            label1.Text += shedegi.Min().ToString() + '\n';
            label1.Text += "იმ რიცხვების საშუალო არითმეტიკული, რომელთა მნიშვნელობები < 10000" + " -   ";
            label1.Text += shedegi.Average().ToString() + '\n';
            label1.Text += "იმ რიცხვების ჯამი, რომელთა მნიშვნელობები < 10000" + " -   ";
            label1.Text += shedegi.Sum(cvladi => (long)cvladi);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Studenti1[] obj = new Studenti1[10];
            obj[0] = new Studenti1("სამხარაძე",  21, 1200.50, 4, "ინფორმატიკის");
            obj[1] = new Studenti1("კაპანაძე",   20, 1250.50,  3, "ენერგეტიკის");
            obj[2] = new Studenti1("კირვალიძე", 18, 1300.50, 1, "არქიტექტურის");
            obj[3] = new Studenti1("ჭუმბურიძე", 19, 1100.50, 2, "ინფორმატიკის");
            obj[4] = new Studenti1("ხუციშვილი", 20, 1400.50, 3, "სამშენებლო");
            obj[5] = new Studenti1("კიკნაძე",     21, 1200.50, 4, "ინფორმატიკის");
            obj[6] = new Studenti1("ნონიაშვილი", 20, 1250.50, 3, "ენერგეტიკის");
            obj[7] = new Studenti1("ქევხიშვილი", 18, 1300.50, 1, "ინფორმატიკის");
            obj[8] = new Studenti1("ხოშტარია",   19, 1100.50, 2, "არქიტექტურის");
            obj[9] = new Studenti1("ქარცივაძე",   20, 1400.50, 3, "სამშენებლო");
            // LINQ მოთხოვნის ფორმირება
            var shedegi =
            from cvladi in obj
            where cvladi.fakulteti == textBox1.Text
            select cvladi;
            // 
            foreach (Studenti1 cvladi in shedegi)
                label1.Text += cvladi.gvari + " " + cvladi.fakulteti + " " + cvladi.asaki.ToString() 
                    + " " + cvladi.kursi.ToString() + " " + cvladi.tanxa.ToString() + "\n";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            SqlConnection conn_Shekveta = new SqlConnection("server=BTU317-M;database=Shekveta;uid=sa;pwd=1");
            SqlDataAdapter adap_Personali = new SqlDataAdapter("SELECT * FROM Personali", conn_Shekveta);
            DataSet ds_1 = new DataSet();
            adap_Personali.Fill(ds_1, "Personali");
            conn_Shekveta.Close();
            dataGridView1.DataSource = ds_1;
            dataGridView1.DataMember = "Personali";
            // 
            var Personalis = ds_1.Tables["Personali"].AsEnumerable();
            var result_Personali = from variable in Personalis
                                   //where int.Parse(variable["asaki"].ToString()) > 30
           //where DateTime.Parse(variable["tarigi_dabadebis"].ToString()) > DateTime.Parse("2003-01-01")
                                   //where variable["ganyofileba"].ToString() == "სასპორტო"
                                   where double.Parse(variable["xelfasi"].ToString()) > 1500.43
                                   orderby variable["gvari"] descending
                                   select variable;
            //
            foreach (var variable_1 in result_Personali)
                label1.Text += variable_1["gvari"] + "     " +
                variable_1["asaki"].ToString() + "     " +
                variable_1["xelfasi"].ToString() + "     " +
                variable_1["tarigi_dabadebis"].ToString() + "\n";
        }
    }
}
/*//where DateTime.Parse(variable["tarigi_dabadebis"].ToString()) >
//DateTime.Parse("2003-01-01") //+dateTimePicker1.Value

//where double.Parse(variable["xelfasi"].ToString()) > 1500.43
//where variable["department"].ToString() == "sport"*/
