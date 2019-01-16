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
        string defaultZero = "0";
        public string Result { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operator { get; set; }
        public bool IsClickedToEqual { get; set; }//this property check botton is already clicked to "=" operator or not 
        public bool IsClickedToAnyButton { get; set; }
        public bool IsClickedToOp { get; private set; }
        private int Count_Calculation = 0;
        private int Count_star = 0;
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
            if (IsClickedToOp && Count_star == 2)
            {
                return;
            }
            Count_star = 0;
            IsClickedToAnyButton = true;//it is for number Button
            Button button = sender as Button;
            if (bottomTextBox.Text.Contains(","))
            {
                if (button.Text == ",")
                {
                    return;
                }
            }
            if (bottomTextBox.Text == "0")
            {
                bottomTextBox.Text = String.Empty;
                if (button.Text == "0")
                {
                    bottomTextBox.Text = "0";
                    bottomTextBox.Text = String.Empty;
                    label.Text = String.Empty;
                }
            }
            if (!IsClickedToOp)
            {
                bottomTextBox.Text += button.Text;
            }
            else if (IsClickedToOp)
            {
                FirstNumber = double.Parse(bottomTextBox.Text);
                bottomTextBox.Text = String.Empty;
                Check = true;
                IsClickedToOp = false;
                bottomTextBox.Text += button.Text;
            }
            label.Text += button.Text;
        }
        private void buttonEQL_Click(object sender, EventArgs e)
        {
            Result += " = ";
            SecondNumber = double.Parse(bottomTextBox.Text);
            IsClickedToEqual = true;

            switch (Operator)
            {
                case "+":
                    {
                        Result += " " + (FirstNumber + SecondNumber).ToString();
                        break;
                    }
                case "*":
                    {
                        Result += " " + (FirstNumber * SecondNumber).ToString();
                        break;
                    }
                case "-":
                    {
                        Result += " " + (FirstNumber - SecondNumber).ToString();
                        break;
                    }
                case "/":
                    {
                        Result += " " + (FirstNumber / SecondNumber).ToString();
                        break;
                    }
            }
            ++Count_Calculation;
            label.Text += Result;
            Result = String.Empty;
            bottomTextBox.Text = String.Empty;
            label.Text += "\r\n ";
        }
        private void operator_click(object sender, EventArgs e)
        {
            IsClickedToOp = true;
            Button button = sender as Button;
            Operator = button.Text;
            var count = bottomTextBox.Text.Count();
            if (button.Text == Operator)
            {
                ++Count_star;
            }
            if (Count_star > 1)
            {
                return;
            }
            label.Text += Operator;
        }
        private void buttonCE_Click(object sender, EventArgs e)
        {
            bottomTextBox.Text = String.Empty;
            label.Text = String.Empty;
        }
        private void buttonC_Click(object sender, EventArgs e)
        {
            bottomTextBox.Text = String.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            if (bottomTextBox.Text == "0"|| bottomTextBox.Text == String.Empty)
            {
                bottomTextBox.Text = String.Empty;
                bottomTextBox.Text += "-";
                label.Text += "-";
            }
          

        }
    }
}