using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string equation;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
            equation += 7;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
            equation += 8;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
            equation += 9;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
            equation += "/";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "pi";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            equation = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
            equation += 4;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
            equation += 5;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
            equation += 6;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "x";
            equation += "*";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
            equation += "(";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
            equation += ")";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
            equation += 1;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
            equation += 2;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
            equation += 3;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
            equation += "+";
        }
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sin(";
            equation += "sin(";
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += "cos(";
            equation += "cos(";
        }
        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
            equation += 0;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
            equation += ".";
        }
        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += "x10";
            equation += "*10";
        }
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
            equation += "-";
        }
        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += "tan(";
            equation += "tan(";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 8;
            equation += 8;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "cos(";
            equation += "cos(";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 5;
            equation += 5;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 2;
            equation += 2;
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 3;
            equation += 3;
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 0;
            equation += 0;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "pi";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "/";
            equation += "/";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            equation = "";
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "*";
            equation += "*";
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "(";
            equation += "(";
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += ")";
            equation += ")";
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "+";
            equation += "+";
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            textBox1.Text +="sin(";
            equation += "sin(";
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += ".";
            equation += ".";
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "*10";
            equation += "*10";
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "-";
            equation += "-";
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "tan(";
            equation += "tan(";
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string answerp = ReplacePi(input);
            string answers = ReplaceSin(answerp);
            string answerc = ReplaceCos(answers);
            string answert = ReplaceTan(answerc);
            //object realanswer = new DataTable().Compute(answer, "").ToString();
            double doubleanswer = CalculateExpression(answert);
            string realanswer = Convert.ToString(doubleanswer);
            textBox1.Text = Convert.ToString(realanswer);
        }

        static string ReplaceSin(string input)
        {
            string pattern = @"sin\(([^)]+)\)";

            MatchEvaluator evaluator = new MatchEvaluator(ReplaceSinMatch);

            string result = Regex.Replace(input, pattern, evaluator);

            return result;
        }

        static string ReplaceSinMatch(Match match)
        {
            string argument = match.Groups[1].Value;

            double value = double.Parse(argument);
            double sinValue = Math.Sin(value);

            return sinValue.ToString();
        }

        static string ReplaceCos(string input)
        {
            string pattern = @"cos\(([^)]+)\)";

            MatchEvaluator evaluator = new MatchEvaluator(ReplaceCosMatch);

            string result = Regex.Replace(input, pattern, evaluator);

            return result;
        }

        static string ReplaceCosMatch(Match match)
        {
            string argument = match.Groups[1].Value;

            double value = double.Parse(argument);
            double cosValue = Math.Cos(value);

            return cosValue.ToString();
        }

        static string ReplaceTan(string input)
        {
            string pattern = @"tan\(([^)]+)\)";

            MatchEvaluator evaluator = new MatchEvaluator(ReplaceTanMatch);

            string result = Regex.Replace(input, pattern, evaluator);

            return result;
        }

        static string ReplaceTanMatch(Match match)
        {
            string argument = match.Groups[1].Value;

            double value = double.Parse(argument);
            double tanValue = Math.Tan(value);

            return tanValue.ToString();
        }

        static string ReplacePi(string expression)
        {
            string replaced = expression.Replace("pi", Math.PI.ToString());
            return replaced;
        }

        static double CalculateExpression(string expression)
        {
            expression = expression.Replace(" ", "");

            expression = expression.Replace(",", ".");

            expression = expression.Replace("*", "*");

            double result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
            return result;
        }


    }

}
