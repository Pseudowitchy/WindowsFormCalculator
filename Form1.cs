using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        readonly string excludes = "+-×÷";

        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) { }

        private void ButtonClick(object sender, EventArgs e)
        {
            string buttonLabel = (sender as Button).Text;
            if (Results.Text == "∞") Results.Text = "0";
            if (excludes.Contains(Results.Text[Results.Text.Length - 1]) && excludes.Contains(buttonLabel))
            { Results.Text = Results.Text.Remove(Results.Text.Length - 1); }
            if (Results.Text == "0")
            {
                if (buttonLabel == "0") { }
                else if (excludes.Contains(buttonLabel)) { Results.Text += buttonLabel; }
                else Results.Text = buttonLabel;
            }
            else { Results.Text += buttonLabel; }
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            string equation = Results.Text.Replace("×", "*").Replace("÷", "/");
            Results.Text = new DataTable().Compute(equation, null).ToString();
        }

        private void ButtonClear_Click(object sender, EventArgs e) { Results.Text = "0"; }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Results.Text = Results.Text.Remove(Results.Text.Length - 1);
            if (Results.Text == "") Results.Text = "0";
        }
    }
}