using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int org_type = -1;

        public Form1()
        {
            InitializeComponent();
            buildGrid();// так как критерии заданы заранее то выбор на 6 иначе на 5б и сразу строим ГРИД
            tabControl1.SelectTab(6); 
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Criterias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void criterias_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*int i;
            for (i in criterias.SelectedItems)

            criterias.SelectedItems.Count*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox3.Items.Add(listBox2.Items);
            buildGrid();
            tabControl1.SelectTab(6);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) // кредитные
        {
            if (radioButton4.Checked == true)
                org_type = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count != -1)
                while (listBox1.SelectedItems.Count != 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItems[0]);
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count != -1)
                while (listBox2.SelectedItems.Count != 0)
                {
                    listBox1.Items.Add(listBox2.SelectedItems[0]);
                    listBox2.Items.Remove(listBox2.SelectedItems[0]);
                }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void buildGrid()
        {
            dataGridView2.ColumnCount = 2;
            dataGridView2.RowCount = listBox2.Items.Count;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = i + 1;
                dataGridView2.Rows[i].Cells[1].Value = listBox2.Items[i];
            }

            dataGridView1.ColumnCount = listBox2.Items.Count + 1;
            dataGridView1.RowCount = listBox2.Items.Count;
            //dataGridView1.
            //dataGridView1.AutoSizeColumnsMode;
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Name = (i).ToString();
                dataGridView1.Rows[i - 1].Cells[0].Value = i;
                dataGridView1.Rows[i - 1].Cells[0].ReadOnly = true;

                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = 0;
                    if (j + 1 == i)
                    {
                        dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                        dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Gray;
                    }
                }

            }
            if (listBox2.Items.Count >= 0)
                dataGridView1.Columns[0].Name = "K#";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                tabControl1.SelectTab(1);
        }
        int[] a, b;
        int k, l, n;
        private void button7_Click(object sender, EventArgs e)
        {
            int i, j;
            a = new int[dataGridView1.ColumnCount + 1];
            b = new int[dataGridView1.ColumnCount + 1];
            Array.Clear(a, 0, a.Length);
            Array.Clear(b, 0, b.Length);
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                for (j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    if (i + 1 != j)
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != 0)
                    {
                        a[i + 1] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        b[j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
            }
            bool is_correct = true;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                    for (j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        if (i + 1 != j && a[i + 1] > 0 && b[i + 1] > 0 && a[i + 1] - b[i + 1] != 1)
                        {
                            is_correct = false; 
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != 0)
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            if (Convert.ToInt32(dataGridView1.Rows[j - 1].Cells[i + 1].Value) != 0)
                                dataGridView1.Rows[j - 1].Cells[i + 1].Style.BackColor = Color.Red;
                        }
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != 0 && (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != a[i + 1] || Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != b[j]))
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            is_correct = false;
                        }
                }   
             }
            if (is_correct)
            {
                tabControl1.SelectTab(7);
                l = 0;
                k = 0;
                matrixBuild();
                assesemtGrid();
            }
            else
                MessageBox.Show("Некорректрый ввод");
        }
        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Focus();
            string s = Clipboard.GetText();
            string[] lines = s.Replace("\n", "").Split('\r');
            string[] fields;
            int row = 0;
            int column = 0;
            foreach (string l in lines)
            {
                fields = l.Split('\t');
                foreach (string f in fields)
                    dataGridView1[column++, row].Value = f;
                row++;
                column = 0;
            }
        }


        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView4.Focus();
            string s = Clipboard.GetText();
            string[] lines = s.Replace("\n", "").Split('\r');
            string[] fields;
            int row = 0;
            int column = 0;
            foreach (string l in lines)
            {
                fields = l.Split('\t');
                foreach (string f in fields)
                    dataGridView4[column++, row].Value = f;
                row++;
                column = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);
        }
        int temp = 0, curL;
        double [ , , ] w = new double [10, 100, 100];

        Dictionary<int, int>[] dict = new Dictionary<int, int>[10];

        private void button11_Click(object sender, EventArgs e)
        {
            int i, j;
            dataGridView4.ColumnCount++;
            n = dataGridView4.ColumnCount;
            dataGridView4.Columns[n - 1].Name = "W";
            dataGridView4.Rows[0].Cells[1].Value = 1;
            for (i = 1; i < dataGridView4.RowCount; i++)
                for (j = 1; j < dataGridView4.ColumnCount - 1; j++)
                {
                    if (j == 1)
                    {
                        if (Convert.ToDouble(dataGridView4.Rows[0].Cells[j].Value) == 0)
                            return;
                        dataGridView4.Rows[i].Cells[j].Value = 1 / Convert.ToDouble(dataGridView4.Rows[0].Cells[i + 1].Value);
                    }
                    else
                        dataGridView4.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value) * Convert.ToDouble(dataGridView4.Rows[0].Cells[j].Value);
                }
            double s, sAll = 0, lambda = 0;
            for (i = 0; i < dataGridView4.RowCount; i++)
            {
                s = 1.0;
                for (j = 1; j < dataGridView4.ColumnCount - 1; j++)
                    s *= Convert.ToDouble(dataGridView4.Rows[i].Cells[j].Value);
                dataGridView4.Rows[i].Cells[n - 1].Value = Math.Pow(s, 1 / Convert.ToDouble(n - 2));
                sAll += Convert.ToDouble(dataGridView4.Rows[i].Cells[n - 1].Value);
            }
            //if (curL != 0 && temp == dict[curL - 1][0])
              //  temp = 0;
            if (curL != 0)
                temp++;
            for (i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Cells[n - 1].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[n - 1].Value) / sAll;
                w[curL, curL == 0 ? 1 : temp, dict[curL][Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value)]] = Convert.ToDouble(dataGridView4.Rows[i].Cells[n - 1].Value);
            }

            for (j = 1; j < dataGridView4.ColumnCount - 1; j++)
            {
                s = 0;
                for (i = 0; i < dataGridView4.RowCount; i++)
                    s += Convert.ToDouble(dataGridView4.Rows[i].Cells[j].Value);
                lambda += s * Convert.ToDouble(dataGridView4.Rows[j - 1].Cells[n - 1].Value);
            }
            dataGridView4.ColumnCount++;
            n++;
            dataGridView4.Columns[n - 1].Name = "lambda";
            dataGridView4.Rows[0].Cells[n - 1].Value = lambda;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void assesemtGrid()
        {
            int i, j;
            string txt = "Какой критерий наиболее предпочтителен с точки зрения: ";
            //for (l = 0; l <= 10; l++)
            {
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                dataGridView4.Columns.Clear();
                dataGridView3.ColumnCount = 3;
                dataGridView3.Columns[0].Name = "#";
                dataGridView3.Columns[1].Name = "Описание критерия";
                dataGridView3.Columns[2].Name = "##";
                curL = l;
                if (k == 0)
                    temp = 0;
                if (l == 0)
                {
                    txt = txt + "Цель";
                    n = 0;
                    for (i = 0; i < dataGridView1.RowCount; i++)
                        if (a[i + 1] == 1)
                            dataGridView3.Rows.Add(++n, dataGridView2.Rows[i].Cells[1].Value, dataGridView2.Rows[i].Cells[0].Value);
                    dataGridView4.ColumnCount = n + 1;
                    dataGridView4.RowCount = n;
                    for (i = 1; i < dataGridView4.ColumnCount; i++)
                    {
                        dataGridView4.Columns[i].Name = (i).ToString();
                        dataGridView4.Rows[i - 1].Cells[0].Value = i;
                        dataGridView4.Rows[i - 1].Cells[0].ReadOnly = true;
                        dataGridView4.Rows[0].Cells[i].Value = 0;
                    }
                    if (n >= 0)
                        dataGridView4.Columns[0].Name = "K#";
                    textBox1.Text = txt;
                }
                else
                {
                    while (k < dataGridView1.RowCount && a[k + 1] != l)
                        k++;
                    if (k < dataGridView1.RowCount && a[k + 1] == l)
                    {
                        txt = txt + dataGridView2.Rows[k].Cells[1].Value;
                        n = 0;
                        for (i = 1; i < dataGridView1.ColumnCount; i++)
                            if (Convert.ToInt32(dataGridView1.Rows[k].Cells[i].Value) == a[k + 1])
                                dataGridView3.Rows.Add(++n, dataGridView2.Rows[i - 1].Cells[1].Value, dataGridView2.Rows[i - 1].Cells[0].Value);
                        dataGridView4.ColumnCount = n + 1;
                        dataGridView4.RowCount = n;
                        for (i = 1; i < dataGridView4.ColumnCount; i++)
                        {
                            dataGridView4.Columns[i].Name = (i).ToString();
                            dataGridView4.Rows[i - 1].Cells[0].Value = i;
                            dataGridView4.Rows[i - 1].Cells[0].ReadOnly = true;
                            dataGridView4.Rows[0].Cells[i].Value = 0;
                        }
                        if (n >= 0)
                            dataGridView4.Columns[0].Name = "K#";
                        textBox1.Text = txt;
                        k++;
                    }     
                }
            }

            if (l == 0 || k >= dataGridView1.RowCount)
            {
                k = 0;
                l++;
            }
        }


        int lev;
        void matrixBuild()
        {
            int i, j, kol = 0;
            for (lev = 0; ; lev++)
            {
                dict[lev] = new Dictionary<int, int>();
                kol = 0;
                if (lev == 0)
                {
                    for (i = 0; i < dataGridView1.RowCount; i++)
                        if (a[i + 1] == 1)
                           dict[lev].Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value), ++kol);
                }
                else
                    for (i = 1; i < dataGridView1.ColumnCount; i++)
                        if (b[i] == lev)
                           dict[lev].Add(Convert.ToInt32(dataGridView2.Rows[i - 1].Cells[0].Value), ++kol);

                if (kol == 0)
                {
                    lev--;
                    break;
                }
                dict[lev].Add(0, kol);
            }
            
        }


        private void button9_Click(object sender, EventArgs e)
        {
            if (l <= 10 && dataGridView3.RowCount > 0)
                assesemtGrid();
            else
            {
                weightAssessment();
                tabControl1.SelectTab(8);
            }
        }
        void weightAssessment()
        {
            dataGridView5.ColumnCount = 100;
            dataGridView5.Columns[0].Name = "#";
            dataGridView5.RowCount = 100;
            int i = 1, j, q, m = 0;
            for (q = 0; q <= lev; q++)
            {
                
                for (i = 1; i <= (q == 0 ? 1 : dict[q - 1][0]); i++)
                {
                    dataGridView5.Rows[m].Cells[0].Value = q;
                    for (j = 1; j <= dict[q][0]; j++)
                        dataGridView5.Rows[m].Cells[j].Value = w[q, i, j];
                    m++;
                }
            }
            for (j = 1; j < 100; j++)
                dataGridView5.Rows[m].Cells[j].Style.BackColor = Color.Red;

            q = 0;
            while (q <= lev)
            {
                m++;
                dataGridView5.Rows[m].Cells[0].Value = "Веса " + Convert.ToString(q) + " уровня";
                if (q == 0)
                    for (j = 1; j <= dict[q][0]; j++)
                        dataGridView5.Rows[m].Cells[j].Value = w[q, 1, j];
                else
                    for (j = 1; j <= dict[q][0]; j++) 
                    {
                        dataGridView5.Rows[m].Cells[j].Value = 0;
                        for (i = 1; i <= dict[q - 1][0]; i++)
                            dataGridView5.Rows[m].Cells[j].Value = Convert.ToDouble(dataGridView5.Rows[m].Cells[j].Value) + 
                                Convert.ToDouble(dataGridView5.Rows[m - 1].Cells[i].Value) * w[q, i, j];
                    }
                q++;
            }
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void kreditnie_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void mikrofin_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void banki_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }



    }
}
