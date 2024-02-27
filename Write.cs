using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatWork_1
{
    public partial class Write : Form
    {
        public Write()
        {
            InitializeComponent();
        }
        /*string folderPath = Path.Combine(Application.StartupPath, "SampleFile");*/
        string filePath = Path.Combine("SampleFile", "francis.csv");

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void Write_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string[] a = richTextBox1.Text.Split(',');
            string course = a[2].ToUpper();
            if (a.Length == 7)
            {
                if(int.TryParse(a[6], out int grade))
                {
                    if(grade <= 100 && grade > 60) {
                    if (ValidCourse(course)) { 
                        using (StreamWriter sw = new StreamWriter(filePath, true))
                        {
                            String input = richTextBox1.Text;
                            sw.WriteLine(input.ToString());
                            MessageBox.Show("The file has been written");
                            richTextBox1.Clear();

                        }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Enter a valid Course");
                    }
                }
                else
                {
                    MessageBox.Show("The Grade is not Valid");
                }
            }
            else
            {
                MessageBox.Show("Please Insert a VALID data");
            }
        }
        public bool ValidCourse(string kurso)
        {
            if (kurso == "IT" || kurso == "MATH" || kurso == "CE" || kurso == "EE" || kurso == "BSIT" || kurso == "BSMATH" || kurso == "BSEE" || kurso == "BSCE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
