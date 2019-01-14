using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var item in Controls)
            {
                if (item is Button button)
                {
                    button.Font = new Font("Italic", 16);
                }
            }
            buttonCE.Font = new Font("Italic", 14);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            bottomTextBox.Text += button.Text;
        }
        /// <summary>
        /// YARIMCHIQ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEQL_Click(object sender, EventArgs e)
        {
            topTextBox.Text = bottomTextBox.Text;
            string result = String.Empty;
            char op = '_';
            if (topTextBox.Text.Contains('+'))
            {
                op = '+';
            }
            else if (topTextBox.Text.Contains('-'))
            {
                op = '-';
            }
            else if (topTextBox.Text.Contains('*'))
            {
                op = '*';
            }
            else if (topTextBox.Text.Contains('/'))
            {
                op = '/';
            }
            var item = topTextBox.Text.Split(op);
            double myres = 0;
            switch (op)
            {
                case '+':
                    {
                        myres = Convert.ToDouble(item[0]) + Convert.ToDouble(item[1]);
                        break;
                    }
                case '-':
                    {
                        myres = Convert.ToDouble(item[0]) - Convert.ToDouble(item[1]);
                        break;
                    }
                case '*':
                    {
                        myres = Convert.ToDouble(item[0]) * Convert.ToDouble(item[1]);
                        break;
                    }
                case '/':
                    {
                        if (Convert.ToDouble(item[1]) == 0)
                        {
                            myres = 0;
                            break;
                        }
                        else
                        {
                            myres = Convert.ToDouble(item[0]) / Convert.ToDouble(item[1]);
                        }

                        break;
                    }
            }
            result += myres.ToString();
            topTextBox.Text += "=" + result;
        }
    }
}
