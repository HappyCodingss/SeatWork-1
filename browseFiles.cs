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
        String filePath;
        public browseFiles()
        {
            InitializeComponent();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV file only |*.csv";
            int ItCount = 0, MathCount = 0,CECount = 0, EECount = 0;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    filePath = ofd.FileName;
                    textBox1.Text = filePath;
                    dataGridView1.Columns.Add("student_id", "Student ID");
                    dataGridView1.Columns.Add("student_name", "Name");
                    dataGridView1.Columns.Add("student_course", "Course");
                    dataGridView1.Columns.Add("student_year", "Year");
                    dataGridView1.Columns.Add("student_section", "Section");
                    dataGridView1.Columns.Add("student_subject", "Subject");
                    dataGridView1.Columns.Add("student_grade", "Grade");
                    float totalGrade = 0;
                    int validLines = 0;

                    while (!sr.EndOfStream)
                    {
                        String handle = sr.ReadLine();
                        string[] data = handle.Split(',');

                        if (data.Length >= 7)
                        {
                            dataGridView1.Rows.Add(data);
                            totalGrade += float.Parse(data[6]);
                            validLines++;

                            switch (data[2].ToUpper())
                            {
                                case "IT":
                                    ItCount++;
                                    break;

                                case "BSIT":
                                    ItCount++;
                                    break;

                                case "MATH":
                                    MathCount++;
                                    break;

                                case "BSMATH":
                                    MathCount++;
                                    break;

                                case "CE":
                                    CECount++;
                                    break;

                                case "BSCE":
                                    CECount++;
                                    break;

                                case "EE":
                                    EECount++;
                                    break;

                                case "BSEE":
                                    EECount++;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid data format: " + handle);
                        }
                    }

                    textBox2.Text = (ItCount + MathCount + CECount + EECount).ToString();
                    textBox3.Text = ItCount.ToString();
                    textBox4.Text = MathCount.ToString();
                    textBox5.Text = CECount.ToString();
                    textBox6.Text = EECount.ToString();

                    // Calculate average grade only if there are valid lines
                    if (validLines > 0)
                    {
                        float averageGrade = totalGrade / validLines;
                        textBox7.Text = averageGrade.ToString();
                    }
                    else
                    {
                        textBox7.Text = "N/A"; // or any other suitable indication when there are no valid lines
                    }

                    panel1.Visible = true;
                    textBox1.Visible = true;
                    label1.Visible = true;

                }

            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            string searchName = searchBar.Text.ToLower();

            // Assuming the name is in the second column (index 1)
            int nameColumnIndex = 1;

            bool found = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[nameColumnIndex] != null && row.Cells[nameColumnIndex].Value != null)
                {
                    string name = row.Cells[nameColumnIndex].Value.ToString().ToLower();

                    if (name == searchName)
                    {
                        // Display the data in TextBoxes
                        textBox8.Text = GetValueFromCell(row, "student_name");
                        textBox9.Text = GetValueFromCell(row, "student_course");
                        textBox10.Text = GetValueFromCell(row, "student_year");
                        textBox11.Text = GetValueFromCell(row, "student_section");
                        textBox12.Text = GetValueFromCell(row, "student_grade");

                        found = true;
                        break; // Exit the loop since the name is found
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show("Name not found");
            }
            else
            {
                UnHideLables(); // Show the labels and TextBoxes for the found data
            }
        }
        private string GetValueFromCell(DataGridViewRow row, string columnName)
        {
            // Check if the cell and its value are not null
            if (row.Cells[columnName] != null && row.Cells[columnName].Value != null)
            {
                return row.Cells[columnName].Value.ToString();
            }

            return string.Empty; // Return an empty string if the value is null
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void UnHideLables()
        {
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
        }
    }
}

