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
        string path = @"C:/Users/Francis Alex/SampleFile/francis.csv";

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Dispose();
        }

        private void Write_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                String input = richTextBox1.Text;
                sw.WriteLine(input.ToString());
                MessageBox.Show("The file has been written");

            }
        }
    }
}
