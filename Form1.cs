
using System.Data;

namespace Notetakerapp
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void notetaker_load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousnotes.DataSource = notes;
        }

        private void newnotebutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void deletebutton_Click(Object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousnotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) { Console.Write("not a valid note"); }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[previousnotes.CurrentCell.RowIndex]["Title"] = textBox1.Text;
                notes.Rows[previousnotes.CurrentCell.RowIndex]["Note"] = textBox2.Text;
            }
            else
            {
                notes.Rows.Add(textBox1.Text, textBox2.Text);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            editing = false;
        }

        private void loadbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = notes.Rows[previousnotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            textBox2.Text = notes.Rows[previousnotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}