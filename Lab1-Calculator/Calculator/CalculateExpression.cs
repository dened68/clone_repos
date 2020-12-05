using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalculateExpression
    {
        private string expression;

        private Stack<string> numbers = new Stack<string>();
        private Stack<string> operations = new Stack<string>();

        public CalculateExpression(string expression)
        {
            this.expression = expression;
        }

        public void setExpression(string expression)
        {
            this.expression = expression;
        }

        public string getExpression()
        {
            return expression;
        }

        public string getCalculate()
        {
            try {
                return startCalculating();
            } catch (Exception exc)
            {
                return "Error";
            }
        }

        private int getPriority(string token)
        {
            switch (token)
            {
                case Constant.PLUS:
                case Constant.MINUS:
                    return 1;
                case Constant.MULTIPLY:
                case Constant.DIVIDE:
                    return 2;
                case Constant.EXPONENT:
                    return 3;
                case Constant.UNARY_MINUS:
                    return 4;
                case Constant.FACTORIAL:
                case Constant.PERCENT:
                    return 5;
                case Constant.SIN:
                case Constant.COS:
                case Constant.TAN:
                case Constant.ARCSIN:
                case Constant.ARCCOS:
                case Constant.ARCTAN:
                case Constant.LOG:
                case Constant.ROOT:
                    return 6;
                default:
                    return 0;
            };
        }

        private bool isUnaryMinus(string previous)
        {
            return (isDelimiter(previous) && !previous.Equals(Constant.CLOSE_BRACKET) 
                && !previous.Equals(Constant.FACTORIAL) && !previous.Equals(Constant.PERCENT) 
                && !previous.Equals(Constant.PI) && !previous.Equals(Constant.E))
                    || previous.Equals(Constant.VOID) || previous.Equals(Constant.UNARY_MINUS);
        }

        private bool isOperation(string token)
        {
            return Constant.OPERATIONS.Contains(token);
        }

        private bool isDelimiter(string token)
        {
            return Constant.DELIMITERS.Contains(token);
        }

        private bool isNumber(string token)
        {
            if (token.Equals(Constant.PI) || token.Equals(Constant.E)) return true;
            return !isDelimiter(token) && !isFunction(token) && !token.Equals(Constant.UNARY_MINUS);
        }

        private bool isFunction(string token)
        {
            bool isTrue = false;
            foreach (string element in Constant.FUNCTIONS)
                if (element.Equals(token))
                {
                    isTrue = true;
                    break;
                }
            return isTrue;
        }

        private void tryInsertNumericFactor(string previous)
        {
            if (previous.Equals(Constant.CLOSE_BRACKET) || isNumber(previous) ||
                    previous.Equals(Constant.FACTORIAL) || previous.Equals(Constant.PERCENT))
            {
                while (numbers.Count >= 2 && operations.Count != 0 
                    && getPriority(Constant.MULTIPLY) <= getPriority(operations.Peek()))
                {
                    calculate();
                }
                operations.Push(Constant.MULTIPLY);
            }
        }

        private bool isContainsFunction(string token)
        {
            foreach (string function in Constant.FUNCTIONS)
                if (token.Contains(function)) return true;
            return false;
        }

        private int getFunctionLength(string token)
        {
            foreach (string function in Constant.FUNCTIONS)
                if (token.Contains(function)) return function.Length;
            return -1;
        }

        private void showArray(object[] array, string prefix)
        {
            Console.Write("\n" + prefix + ": ");
            foreach (string element in array)
            {
                Console.Write(element + ", ");
            }
        }

        private string[] letsGOTokenize(string str)
        {
            str = str.Replace(Constant.PLUS, " " + Constant.PLUS + " ");
            str = str.Replace(Constant.MINUS, " " + Constant.MINUS + " ");
            str = str.Replace(Constant.MULTIPLY, " " + Constant.MULTIPLY + " ");
            str = str.Replace(Constant.DIVIDE, " " + Constant.DIVIDE + " ");
            str = str.Replace(Constant.OLD_DIVIDE, " " + Constant.OLD_DIVIDE + " ");
            str = str.Replace(Constant.OLD_MULTIPLY, " " + Constant.OLD_MULTIPLY + " ");
            str = str.Replace(Constant.PI, " " + Constant.PI + " ");
            str = str.Replace(Constant.E, " " + Constant.E + " ");
            str = str.Replace(Constant.OPEN_BRACKET, " " + Constant.OPEN_BRACKET + " ");
            str = str.Replace(Constant.CLOSE_BRACKET, " " + Constant.CLOSE_BRACKET + " ");
            str = str.Replace(Constant.PERCENT, " " + Constant.PERCENT + " ");
            str = str.Replace(Constant.FACTORIAL, " " + Constant.FACTORIAL + " ");
            str = str.Replace(Constant.ROOT, " " + Constant.ROOT + " ");
            str = str.Replace(Constant.EXPONENT, " " + Constant.EXPONENT + " ");
            str = str.Replace(Constant.PI, " " + Constant.PI + " ");
            str = str.Replace(Constant.DELIMITER, " " + Constant.DELIMITER + " ");
            while (str.Contains("  "))
                str = str.Replace("  ", " ");
            return str.Split(' ');
        }

        private string startCalculating()
        {
            if (expression.Equals(Constant.VOID) || expression.Length <= 0) return Constant.VOID;

            string[] tokens = letsGOTokenize(expression);
            showArray(tokens, "tokens");
            string token, previous = Constant.VOID;

            foreach (string el in tokens)
            {
                token = el;
                Console.WriteLine("\n");
                showArray(numbers.ToArray(), "Numbers Before");
                showArray(operations.ToArray(), "Operations Before");

                // is Delimiter
                if (isDelimiter(token))
                {
                    switch (token)
                    {
                        case Constant.OPEN_BRACKET:
                            tryInsertNumericFactor(previous);
                            operations.Push(Constant.OPEN_BRACKET);
                            break;
                        case Constant.CLOSE_BRACKET:
                            while (operations.Count != 0 && !operations.Peek().Equals(Constant.OPEN_BRACKET))
                            {
                                calculate();
                            }
                            operations.Pop();
                            break;
                    }
                }

                // is Operation or Function
                if (isOperation(token) || isFunction(token))
                {
                    if (operations.Count == 0)
                    {
                        if (token.Equals(Constant.MINUS) && isUnaryMinus(previous))
                            token = Constant.UNARY_MINUS;
                        else if (isFunction(token) && !token.Equals(Constant.FACTORIAL))
                            tryInsertNumericFactor(previous);
                    }
                    else
                    {
                        // operations not empty
                        if (isFunction(token) && !token.Equals(Constant.FACTORIAL))
                            tryInsertNumericFactor(previous);
                        else if (token.Equals(Constant.MINUS) && isUnaryMinus(previous))
                            token = Constant.UNARY_MINUS;
                        if (!previous.Equals(Constant.EXPONENT) && !token.Equals(Constant.UNARY_MINUS))
                        {
                            while (operations.Count != 0 && getPriority(token) <= getPriority(operations.Peek()))
                                calculate();
                        }
                    }
                    operations.Push(token);
                }

                // is Number
                if (isNumber(token))
                {
                    tryInsertNumericFactor(previous);
                    if (token.Equals(Constant.PI)) token = String.Concat(Math.PI);
                    else if (token.Equals(Constant.E)) token = String.Concat(Math.E);
                    if (isContainsFunction(token))
                    {
                        int len = getFunctionLength(token);
                        String number = token.Substring(0, token.Length - len);
                        String function = token.Substring(token.Length - len);
                        numbers.Push(number);

                        while (operations.Count != 0 && getPriority(Constant.MULTIPLY) <= getPriority(operations.Peek()))
                            calculate();

                        operations.Push(Constant.MULTIPLY);
                        operations.Push(function);
                        token = function;
                    }
                    else
                    {
                        numbers.Push(token);
                    }
                }

                previous = token;

                Console.WriteLine("\n");
                showArray(numbers.ToArray(), "Numbers After");
                showArray(operations.ToArray(), "Operations After");
            }

            while (operations.Count != 0)
            {
                calculate();
            }

            Console.WriteLine("\n");
            showArray(numbers.ToArray(), "Numbers End");
            showArray(operations.ToArray(), "Operations End");

            return numbers.Pop();
        }

        private void calculate()
        {
            string temp = null;

            switch (operations.Peek())
            {
                case Constant.PLUS:
                case Constant.MINUS:
                case Constant.MULTIPLY:
                case Constant.DIVIDE:
                case Constant.EXPONENT:
                case Constant.LOG:
                case Constant.OLD_MULTIPLY:
                case Constant.OLD_DIVIDE:
                    Decimal apfloat2 = Decimal.Parse(numbers.Pop());
                    Decimal apfloat1 = Decimal.Parse(numbers.Pop());

                    switch (operations.Pop())
                    {
                        case Constant.PLUS:
                            temp = String.Concat((apfloat1 + apfloat2));
                            break;
                        case Constant.MINUS:
                            temp = String.Concat((apfloat1 - apfloat2));
                            break;
                        case Constant.MULTIPLY:
                        case Constant.OLD_MULTIPLY:
                            temp = String.Concat((apfloat1 * apfloat2));
                            break;
                        case Constant.DIVIDE:
                        case Constant.OLD_DIVIDE:
                            temp = String.Concat((apfloat1 / apfloat2));
                            break;
                        case Constant.EXPONENT:
                            temp = String.Concat((Math.Pow((double)apfloat1, (double)apfloat2)));
                            break;
                        case Constant.LOG:
                            temp = String.Concat((Math.Log((double)apfloat2) / Math.Log((double)apfloat1)));
                            break;
                    }

                    break;
                case Constant.FACTORIAL:
                case Constant.PERCENT:
                case Constant.SIN:
                case Constant.COS:
                case Constant.TAN:
                case Constant.ROOT:
                case Constant.UNARY_MINUS:
                case Constant.ARCSIN:
                case Constant.ARCCOS:
                case Constant.ARCTAN:
                    string myStringNumber = numbers.Pop();

                    switch (operations.Pop())
                    {
                        case Constant.FACTORIAL:
                            {
                                temp = String.Concat(factorial(Int64.Parse(myStringNumber)));
                            }
                            break;
                        case Constant.PERCENT:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                apfloat2 = Decimal.Parse("100");
                                temp = String.Concat((apfloat1 / apfloat2));
                            }
                            break;
                        case Constant.ROOT:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                temp = String.Concat((Math.Sqrt((double)apfloat1)));
                            }
                            break;
                        case Constant.SIN:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                if (Constant.isRadian)
                                {
                                    temp = String.Concat((Math.Sin((double)apfloat1)));
                                }
                                else
                                {
                                    temp = String.Concat((Math.Sin(toDegrees((double)apfloat1))));
                                }
                            }
                            break;
                        case Constant.COS:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                if (Constant.isRadian)
                                {
                                    temp = String.Concat((Math.Cos((double)apfloat1)));
                                }
                                else
                                {
                                    temp = String.Concat((Math.Cos(toDegrees((double)apfloat1))));
                                }
                            }
                            break;
                        case Constant.TAN:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                if (Constant.isRadian)
                                {
                                    temp = String.Concat((Math.Tan((double)apfloat1)));
                                }
                                else
                                {
                                    temp = String.Concat((Math.Tan(toDegrees((double)apfloat1))));
                                }
                            }
                            break;
                        case Constant.ARCSIN:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                if (Constant.isRadian)
                                {
                                    temp = String.Concat((Math.Asin((double)apfloat1)));
                                }
                                else
                                {
                                    temp = String.Concat((Math.Asin(toDegrees((double)apfloat1))));
                                }
                            }
                            break;
                        case Constant.ARCCOS:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                if (Constant.isRadian)
                                {
                                    temp = String.Concat((Math.Acos((double)apfloat1)));
                                }
                                else
                                {
                                    temp = String.Concat((Math.Acos(toDegrees((double)apfloat1))));
                                }
                            }
                            break;
                        case Constant.ARCTAN:
                            {
                                apfloat1 = Decimal.Parse(myStringNumber);
                                if (Constant.isRadian)
                                {
                                    temp = String.Concat((Math.Atan((double)apfloat1)));
                                }
                                else
                                {
                                    temp = String.Concat((Math.Atan(toDegrees((double)apfloat1))));
                                }
                            }
                            break;
                        case Constant.UNARY_MINUS:
                            {
                                decimal myNumber = Decimal.Parse(myStringNumber);
                                temp = String.Concat(myNumber * -1);
                            }
                            break;
                    }

                    break;

                default:
                    if (operations.Count != 0)
                        operations.Pop();
                    break;
            }

            if (temp != null)
                numbers.Push(temp);
        }

        private long factorial(long x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * factorial(x - 1);
            }
        }

        private double toDegrees(double y)
        {
            return (y * 180) / Math.PI;
        }
    }
}
