using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteListTracker
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBoxUrgent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxMessage.Clear();
            textBoxTitle.Clear();
            checkBoxUrgent.Checked = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxMessage.Text == "" || textBoxTitle.Text == "")
            {
                string message = "Insert title and message!";
                string title = "Info";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }

            else
            {
                table.Rows.Add(textBoxTitle.Text, textBoxMessage.Text, checkBoxUrgent.Checked);
                textBoxMessage.Clear();
                textBoxTitle.Clear();
                checkBoxUrgent.Checked = false;
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index > -1)
                {
                    textBoxTitle.Text = table.Rows[index].ItemArray[0].ToString();
                    textBoxMessage.Text = table.Rows[index].ItemArray[1].ToString();
                    checkBoxUrgent.Checked = bool.Parse(table.Rows[index].ItemArray[2].ToString());
                }
            }
            else
            {
                string message = "Please select a note!";
                string title = "Info";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index > -1)
                {
                    table.Rows[index].Delete();
                }
            }
            else
            {
                string message = "Please select a note!";
                string title = "Info";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();

            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));
            table.Columns.Add("Urgent", typeof(Boolean));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Urgent"].Visible = false;
            dataGridView1.Columns["Title"].Width = 197;
        }
    }
}
