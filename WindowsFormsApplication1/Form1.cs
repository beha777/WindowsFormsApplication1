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
        private void OnListBoxMouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = listBox1.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < listBox1.Items.Count))
                strTip = listBox1.Items[nIdx].ToString();

            toolTip1.SetToolTip(listBox1, strTip);
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
                    if (j + 1 >= i)
                    {
                        dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                        dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Gray;
                    }
                }

            }
            if (listBox2.Items.Count >= 0)
                dataGridView1.Columns[0].Name = "K#";
        }
    }
}
