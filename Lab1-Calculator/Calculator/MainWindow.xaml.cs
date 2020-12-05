using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int caretIndex;
        private CalculateExpression calculator;

        public MainWindow()
        {
            InitializeComponent();
            caretIndex = fieldIn.SelectionStart + 1;
            fieldIn.Focus();
        }

        private void buttonBackspace_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text = Constant.VOID;
            fieldIn.CaretIndex = 0;
            fieldOut.Text = Constant.VOID;
        }

        private void buttonE_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.E;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonPi_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.PI;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonExponent_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.EXPONENT;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonRAD_Click(object sender, RoutedEventArgs e)
        {
            Constant.isRadian = !Constant.isRadian;

            if (Constant.isRadian)
                buttonRAD.Content = Constant.RAD;
            else
                buttonRAD.Content = Constant.DEG;

            if (calculator != null)
            {
                fieldOut.Text = calculator.getCalculate();
                fieldOut.Focus();
            }
        }

        private void buttonINV_Click(object sender, RoutedEventArgs e)
        {
            Constant.isInverse = !Constant.isInverse;

            if (Constant.isInverse)
            { 
                buttonINV.BorderBrush = buttonDelete.BorderBrush;
                buttonSin.Content = Constant.CONST_ARCSIN;
                buttonCos.Content = Constant.CONST_ARCCOS;
                buttonTan.Content = Constant.CONST_ARCTAN;
            } else
            {
                buttonINV.BorderBrush = buttonRAD.BorderBrush;
                buttonSin.Content = Constant.CONST_SIN;
                buttonCos.Content = Constant.CONST_COS;
                buttonTan.Content = Constant.CONST_TAN;
            }
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.DIVIDE;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonNine_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.NINE;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonEight_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.EIGHT;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonSeven_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.SEVEN;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonRoot_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.ROOT;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonTan_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            if (Constant.isInverse)
            {
                fieldIn.Text += Constant.ARCTAN + Constant.OPEN_BRACKET;
                caretIndex += Constant.ARCTAN.Length + Constant.OPEN_BRACKET.Length;
                fieldIn.CaretIndex = caretIndex;
            }
            else
            {
                fieldIn.Text += Constant.TAN + Constant.OPEN_BRACKET;
                caretIndex += Constant.TAN.Length + Constant.OPEN_BRACKET.Length;
                fieldIn.CaretIndex = caretIndex;
            }
        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.MULTIPLY;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonSix_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.SIX;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonFive_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.FIVE;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonFour_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.FOUR;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonPercent_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.PERCENT;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonCos_Click(object sender, RoutedEventArgs e)
        {
            if (Constant.isInverse)
            {
                fieldIn.Text += Constant.ARCCOS + Constant.OPEN_BRACKET;
                caretIndex += Constant.ARCCOS.Length + Constant.OPEN_BRACKET.Length;
                fieldIn.CaretIndex = caretIndex;
            }
            else
            {
                fieldIn.Text += Constant.COS + Constant.OPEN_BRACKET;
                caretIndex += Constant.COS.Length + Constant.OPEN_BRACKET.Length;
                fieldIn.CaretIndex = caretIndex;
            }
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.MINUS;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonThree_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.THREE;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonTwo_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.TWO;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonOne_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.ONE;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonFactorial_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.FACTORIAL;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonSin_Click(object sender, RoutedEventArgs e)
        {
            if (Constant.isInverse)
            {
                fieldIn.Text += Constant.ARCSIN + Constant.OPEN_BRACKET;
                caretIndex += Constant.ARCSIN.Length + Constant.OPEN_BRACKET.Length;
                fieldIn.CaretIndex = caretIndex;
            }
            else
            {
                fieldIn.Text += Constant.SIN + Constant.OPEN_BRACKET;
                caretIndex += Constant.SIN.Length + Constant.OPEN_BRACKET.Length;
                fieldIn.CaretIndex = caretIndex;
            }
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.PLUS;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
            calculator = new CalculateExpression(fieldIn.Text);
            fieldOut.Text = calculator.getCalculate();
            fieldOut.Focus();
        }

        private void buttonZero_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.ZERO;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonPoint_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.POINT;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonDelimiter_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.DELIMITER;
            fieldIn.CaretIndex = caretIndex++;
        }

        private void buttonRandom_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            Random random = new Random();
            string text = String.Concat((float)random.NextDouble());
            fieldIn.Text += text;
            fieldIn.CaretIndex = caretIndex + text.Length;
        }

        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.LOG + Constant.OPEN_BRACKET;
            caretIndex += Constant.LOG.Length + Constant.OPEN_BRACKET.Length;
            fieldIn.CaretIndex = caretIndex;
        }

        private void buttonOpenBracket_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.OPEN_BRACKET;
            caretIndex += Constant.OPEN_BRACKET.Length;
            fieldIn.CaretIndex = caretIndex;
        }

        private void buttonCloseBracket_Click(object sender, RoutedEventArgs e)
        {
            fieldIn.Focus();
            fieldIn.Text += Constant.CLOSE_BRACKET;
            caretIndex += Constant.CLOSE_BRACKET.Length;
            fieldIn.CaretIndex = caretIndex;
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
