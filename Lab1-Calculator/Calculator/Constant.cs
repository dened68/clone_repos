using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Constant
    {
        public static bool isRadian = true;
        public static bool isInverse = false;

        public const string OPEN_BRACKET = "(";
        public const string CLOSE_BRACKET = ")";

        public const string VOID = "";

        public const string PI = "π";
        public const string E = "e";

        public const string UNARY_MINUS = "u-";

        public const string EXPONENT = "^";
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string MULTIPLY = "×";
        public const string DIVIDE = "÷";
        public const string OLD_MULTIPLY = "*";
        public const string OLD_DIVIDE = "/";

        public const string FACTORIAL = "!";
        public const string PERCENT = "%";
        public const string ROOT = "√";

        public const string POINT = ".";
        public const string DELIMITER = ";";

        public const string CONST_ARCSIN = "ASIN";
        public const string CONST_ARCCOS = "ACOS";
        public const string CONST_ARCTAN = "ATAN";

        public const string CONST_SIN = "SIN";
        public const string CONST_COS = "COS";
        public const string CONST_TAN = "TAN";

        public const string ARCSIN = "asin";
        public const string ARCCOS = "acos";
        public const string ARCTAN = "atan";

        public const string SIN = "sin";
        public const string COS = "cos";
        public const string TAN = "tan";

        public const string LOG = "log";

        public const string ZERO = "0";
        public const string ONE = "1";
        public const string TWO = "2";
        public const string THREE = "3";
        public const string FOUR = "4";
        public const string FIVE = "5";
        public const string SIX = "6";
        public const string SEVEN = "7";
        public const string EIGHT = "8";
        public const string NINE = "9";

        public const string RAD = "RAD";
        public const string DEG = "DEG";

        public static string[] FUNCTIONS 
            = {SIN, COS, TAN, LOG, ROOT, FACTORIAL, ARCSIN, ARCCOS, ARCTAN};

        public static string OPERATIONS 
            = PLUS + MINUS + EXPONENT + DIVIDE + MULTIPLY + PERCENT + OLD_DIVIDE + OLD_MULTIPLY;

        public static string DELIMITERS 
            = OPERATIONS + DELIMITER + ROOT + PI + E + OPEN_BRACKET + CLOSE_BRACKET + FACTORIAL;
    }
}
