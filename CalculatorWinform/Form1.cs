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
            BackgroundImage = Properties.Resources.baku;
            InitializeComponent();
        }
        public string Result { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operator { get; set; }
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
            label.Text += bottomTextBox.Text;
            SecondNumber = double.Parse(bottomTextBox.Text);        
        }
        private void buttonEQL_Click(object sender, EventArgs e)
        {
            switch (Operator)
            {
                case "+":
                    {

                        Result = (FirstNumber + SecondNumber).ToString();
                        label.Text += " = " + Result;
                        break;
                    }
                case "-":
                    {

                        Result = (FirstNumber - SecondNumber).ToString();
                        label.Text += " = " + Result;
                        break;
                    }
                case "*":
                    {

                        Result = (FirstNumber * SecondNumber).ToString();
                        label.Text += " = " + Result;
                        break;
                    }
                case "/":
                    {
                        if (SecondNumber == 0)
                        {
                            label.Text = "Infinitive";
                            bottomTextBox.Text = "0";
                            break;
                        }
                        Result = (FirstNumber / SecondNumber).ToString();
                        label.Text += " = " + Result;
                        break;
                    }
            }
            FirstNumber = 0;
            SecondNumber = 0;           
        }
        private void operator_click(object sender, EventArgs e)
        {
            FirstNumber = double.Parse(bottomTextBox.Text);
            bottomTextBox.Text = String.Empty;          
            Button button = sender as Button;            
            Operator = button.Text;
            label.Text += Operator;
        }
    }
}
