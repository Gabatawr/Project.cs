using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Task_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (Button btn in new[]{ Btn0, Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9 }) 
                btn.Click += BtnNumber_Click;

            foreach (Button btn in new[] { BtnPlus, BtnMin, BtnDiv, BtnMult })
                btn.Click += BtnOperator_Click;

            BtnDot.Click += BtnDot_Click;

            BtnResetChar.Click += BtnResetChar_Click;
            BtnResetNumber.Click += BtnResetNumber_Click;
            BtnResetAll.Click += BtnResetAll_Click;

            BtnCalc.Click += BtnCalc_Click;
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Text.LastIndexOfAny(new[] { '+', '-', '*', '/' }) == Expression.Text.Length - 1)
                BtnResetChar_Click(this, new RoutedEventArgs());
            
            if (Expression.Text.LastIndexOfAny(new[] { '+', '-', '*', '/' }) == -1)
            {
                Result.Text = Expression.Text;
                return;
            }

            var arrNum = Expression.Text.Split('+', '-', '*', '/');
            List<double> numbers = new List<double>();
            foreach (string num in arrNum) numbers.Add(double.Parse(num));

            List<string> operators = Expression.Text.Split(arrNum, StringSplitOptions.RemoveEmptyEntries).ToList();

            void ReList(ref int i, double res)
            {
                numbers.Insert(i, res);
                numbers.RemoveRange(i + 1, 2);
                operators.RemoveAt(i);
                i--;
            }

            try {
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == "*")
                        ReList(ref i, numbers[i] * numbers[i + 1]);
                    else if (operators[i] == "/")
                        ReList(ref i, numbers[i] / numbers[i + 1]);
                }

                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == "+")
                        ReList(ref i, numbers[i] + numbers[i + 1]);
                    else if (operators[i] == "-")
                        ReList(ref i, numbers[i] - numbers[i + 1]);
                }
            }
            catch (DivideByZeroException)
            {
                Expression.Text = "0";
                Result.Text = "0";
            }

            Result.Text = numbers[0].ToString();
        }
        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Text.Length > 0)
            {
                if (char.IsDigit(Expression.Text[^1]))
                {
                    for (int i = 1; i <= Expression.Text.Length; i++)
                    {
                        char c = Expression.Text[^i];
                        if (c == ',') return;
                        if (c == '+' || c == '-' || c == '*' || c == '/' 
                            || i == Expression.Text.Length)
                        {
                            Expression.Text += ',';
                            return;
                        }
                    }
                }
            }
        }
        private void BtnResetAll_Click(object sender, RoutedEventArgs e)
        {
            Expression.Text = "0";
            Result.Text = "0";
        }
        private void BtnResetNumber_Click(object sender, RoutedEventArgs e)
        {
            int opInd = Expression.Text.LastIndexOfAny(new[]{ '+', '-', '*', '/' });

            if (opInd == Expression.Text.Length - 1)
            {
                BtnResetChar_Click(this, new RoutedEventArgs());
                opInd = Expression.Text.LastIndexOfAny(new[] { '+', '-', '*', '/' });
            }

            if (opInd == -1) Expression.Text = "0";
            else Expression.Text = Expression.Text.Substring(0, Expression.Text.Length - opInd);
        }
        private void BtnResetChar_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Text.Length > 0)
            {
                if (Expression.Text.Length == 1)
                {
                    if (Expression.Text != "0") Expression.Text = "0";
                }
                else Expression.Text = Expression.Text.Substring(0, Expression.Text.Length - 1);
            }
        }
        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Text == "0")
            {
                if ((sender as Button).Name == "Btn0") return;
                Expression.Text = "";
            }
            Expression.Text += (sender as Button).Content.ToString();
        }
        private void BtnOperator_Click(object sender, RoutedEventArgs e)
        {
            char c = (sender as Button).Content.ToString()[0];
            if (Expression.Text.Length > 0)
            {
                char l = Expression.Text[^1];
                if (l != '+' && l != '-' && l != '*' && l != '/')
                    Expression.Text += c;
            }
        }
    }
}
