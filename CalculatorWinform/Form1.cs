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

            //BackgroundImage = Properties.Resources.baku;
            InitializeComponent();
            bottomTextBox.Text = defaultZero;
        }
        string defaultZero = "";
        public string Result { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operator { get; set; }
        public bool IsClickedToEqual { get; set; }//this property check botton is already clicked to "=" operator or not 
        public bool IsClickedToAnyButton { get; set; }
        public bool IsClickedToOp { get; private set; }

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
        public bool Check { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            IsClickedToAnyButton = true;//it is for number Button
            Button button = sender as Button;
            if (!IsClickedToOp)
            {
                bottomTextBox.Text += button.Text;

            }
            else if (IsClickedToOp)
            {
                FirstNumber = int.Parse(bottomTextBox.Text);
                bottomTextBox.Text = String.Empty;
                Check = true;
                IsClickedToOp = false;
            }
            else
            {
                bottomTextBox.Text += button.Text;
            }
            //string temp = "";
            //if (Check)
            //{
            //    
            //}



            //SecondNumber = bottomTextBox.Text -= button.Text;

        }
        private void buttonEQL_Click(object sender, EventArgs e)
        {
            IsClickedToEqual = true;
            MessageBox.Show($"f {FirstNumber} s {SecondNumber}");
        }
        private void operator_click(object sender, EventArgs e)
        {
            IsClickedToOp = true;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {

        }

        private void buttonC_Click(object sender, EventArgs e)
        {

        }

        private void buttonDot_Click(object sender, EventArgs e)
        {

        }
    }
}