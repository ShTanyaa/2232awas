using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Практика_19_ПТПМ
{
    public partial class Form1 : Form
    {
        string[,] question = new string[10, 6];
        int curr_numb = 0, answer = 0;
        Random rnd = new Random();
        
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] a = question[curr_numb, 4].Split('/');
            Double d = a.Length;
            double h = 1 / d;
            double y = 0;
            if (a.Length > 1)
            {


                for (int j = 0; j < a.Length; j++)
                {

                    if (checkBox1.Checked)
                    {
                        if (checkBox1.Text == a[j])
                        {
                            answer++;
                            y += h;
                        }

                    }
                    if (checkBox2.Checked)
                    {
                        if (checkBox2.Text == a[j])
                        {
                            answer++;
                            y += h;
                        }

                    }
                    if (checkBox3.Checked)
                    {
                        if (checkBox3.Text == a[j])
                        {
                            answer++;
                            y += h;
                        }

                    }
                }
            }
            else
            {


                if (radioButton1.Checked)
                {
                    if (radioButton1.Text == question[curr_numb, 4])
                    {
                        answer++;
                    }
                }
                if (radioButton2.Checked)
                {
                    if (radioButton2.Text == question[curr_numb, 4])
                    {
                        answer++;
                    }
                }
                if (radioButton3.Checked)
                {
                    if (radioButton3.Text == question[curr_numb, 4])
                    {
                        answer++;
                    }
                }
            }

            if (curr_numb < 9)
            {
                curr_numb++;
                this.Text = "вопрос " + (curr_numb + 1);
                label1.Text = question[curr_numb, 0];
                if (question[curr_numb, 5] != "")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(question[curr_numb, 5]);
                }
                else pictureBox1.Visible = false;
                a = question[curr_numb, 4].Split('/');

                if (a.Length > 1)
                {
                    
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox1.Text = question[curr_numb, 1];
                    checkBox2.Text = question[curr_numb, 2];
                    checkBox3.Text = question[curr_numb, 3];
                    
                }
                else
                {

                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox3.Visible = false;
                    radioButton1.Text = question[curr_numb, 1];
                    radioButton2.Text = question[curr_numb, 2];
                    radioButton3.Text = question[curr_numb, 3];

                }
            }
            else
            {
                button1.Enabled = false;
                if (curr_numb + 1 == answer)
                {
                    MessageBox.Show("вы ответили  на все " + answer + " вопросов", "результаты");
                }
                else
                {
                    MessageBox.Show($"вы ответили верно на  {answer} вопросов", "результаты");
                }
            }
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = File.OpenText("quest.txt");
            int i = 0; int j;
            while (!sr.EndOfStream)
            {
                for (j = 0; j < 6; j++)
                {
                    question[i, j] = sr.ReadLine();
                }
                i++;
            }
            sr.Close();
            this.Text = "вопрос " + (curr_numb + 1);
            label1.Text = question[0, 0];
            radioButton1.Text = question[0, 1];
            radioButton2.Text = question[0, 2];
            radioButton3.Text = question[0, 3];
            if (question[0, 5] != "")
            {
                pictureBox1.Image = Image.FromFile(question[0, 5]);
            }
            else pictureBox1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
