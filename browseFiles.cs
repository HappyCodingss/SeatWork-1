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
    public partial class browseFiles : Form
    {
        public browseFiles()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV file only |*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            String handle;
                            handle = sr.ReadLine();
                            String[] data = handle.Split(',');
                            richTextBox1.AppendText(data[0] +"\t"+data[1]+ "\t" + data[2] + "\t" + data[3]+"\t"+ data[4] + data[5] + "\t" + data[6]+"\n");

                            
                        }
                    
                }
                /*catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
