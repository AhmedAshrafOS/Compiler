using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
namespace WebApplication3.Services
{
    public class Compiler
    {

        static List<string> Condition = new List<string>()
            {
                "If",
                "Else"
            };
        static List<string> Integer = new List<string>()
            {
                "Iow"
            };
        static List<string> SInteger = new List<string>()
            {
                "SIow"
            };
        static List<string> Character = new List<string>()
            {
                "Chlo"
            };
        static List<string> String = new List<string>()
            {
                "Chain"
            };
        static List<string> Float = new List<string>()
            {
                "Iowf"
            };
        static List<string> SFloat = new List<string>()
            {
                "SIowf"
            };
        static List<string> Void = new List<string>()
            {
                "Worthless"
            };
        static List<string> Loop = new List<string>()
            {
                "Loopwhen",
                "Iteratewhen"
            };
        static List<string> Return = new List<string>()
            {
                "Turnback"
            };
        static List<string> Break = new List<string>()
            {
                "Stop"

            };
        static List<string> Struct = new List<string>()
            {
                "Loli"
            };
        static List<string> ArithmeticOperation = new List<string>()
            {
                "+",
                "-",
                "*",
                "/"
            };

        static List<string> LogicOperators = new List<string>()
            {
                "&",
                "|",
                "~"
            };
        static List<string> relationalOperator = new List<string>()
            {
                "<",
                ">",
                "!"
            };
        static List<string> AssignmentOperators = new List<string>()
            {
                "="
            };
        static List<string> AccessOperator = new List<string>()
            {
                "->"
            };
        static List<string> Braces = new List<string>()
            {
                "{",
                "}",
                "[",
                "]",
                "(",
                ")"
            };
        static List<string> QuaotationMark = new List<string>()
            {
                "\"",
                "'"
            };


        static List<string> Inclusion = new List<string>()
            {
                "Include"
            };
        static List<string> Separator = new List<string>()
            {
                ";"
            };
        public static int NumOfError = 0;
        public static int Line = 1;
        private static IDictionary<string, List<string>> keywords = new Dictionary<string, List<string>>()
        {

            {"Condition",Condition},
            {"Integer",Integer},
            {"SInteger",SInteger},
            {"Character",Character},
            {"String",String},
            {"Float",Float},
            {"SFloat",SFloat},
            {"Void",Void},
            {"Loop",Loop},
            {"Return",Return},
            {"Break",Break},
            {"Struct",Struct},
            {"Arithmetic Operation",ArithmeticOperation},
            {"Logic operators",LogicOperators},
            {"relational operator",relationalOperator},
            {"Assignment operator",AssignmentOperators},
            {"Access operator",AccessOperator},
            {"Braces",Braces},
            {"Quaotation Mark",QuaotationMark},
            {"Inclusion",Inclusion},
            {"Separator", Separator}
        };
        private static string check_reserved(string y)
        {
            if (y == keywords["Condition"][0])
            {
                return "Condition";
            }
            if (y == keywords["Condition"][1])
            {
                return "Condition";
            }
            if (y == keywords["Integer"][0])
            {

                return "Integer";

            }
            if (y == keywords["SInteger"][0])
            {
                return "SInteger";
            }
            if (y == keywords["Character"][0])
            {
                return "Character";
            }
            if (y == keywords["String"][0])
            {
                return "String";
            }
            if (y == keywords["Float"][0])
            {
                return "Float";
            }
            if (y == keywords["SFloat"][0])
            {
                return "SFloat";
            }
            if (y == keywords["Void"][0])
            {
                return "Void";
            }
            //loop
            if (y == keywords["Loop"][0])
            {
                return "Loop";
            }
            if (y == keywords["Loop"][1])
            {
                return "Loop";
            }
            if (y == keywords["Return"][0])
            {
                return "Return";
            }
            if (y == keywords["Break"][0])
            {
                return "Break";
            }
            if (y == keywords["Struct"][0])
            {
                return "Struct";
            }

            if (y == keywords["Inclusion"][0])
            {
                return "Inclusion";
            }

            return "Identifier";
        }
        private static bool isArithmeticOperation(char s)
        {
            foreach (var i in keywords["Arithmetic Operation"])
            {
                if (s == char.Parse(i))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool isQuaotationMark(char s)
        {
            foreach (var i in keywords["Quaotation Mark"])
            {
                if (s == char.Parse(i))
                {
                    return true;
                }
            }
            return false;

        }
        private static bool isBraces(char s)
        {
            foreach (var i in keywords["Braces"])
            {
                if (s == char.Parse(i))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool isAlpha(char ch)
        {
            for (int i = (int)'a'; i <= (int)'z'; i++)
            {
                if (ch == (char)(i)) return true;
            }
            for (int i = (int)'A'; i <= (int)'Z'; i++)
            {
                if (ch == (char)(i)) return true;
            }
            if (ch == '_') return true;
            return false;
        }
        private static bool isDigit(char ch)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ch == (char)(i + 48)) return true;
            }
            return false;

        }
        private static bool isAlphaDigit(char ch)
        {
            if (isAlpha(ch)) return true;
            if (isDigit(ch)) return true;
            return false;

        }
        private static bool isWhiteSpace(char ch)
        {
            if (ch == '\t' || ch == '\n' || ch == ' ' || ch == '\r')
            {
                return true;
            }
            return false;
        }
        public static int Index = 0;
        static private int State = 0;
        static private string Code { get; set; }
        List<Token> primeNumbers = new List<Token>();
        private static Token ReturnKeywords()
        {
            int Temp = Index;
            State = 0;
            string lexeme = "";
            Token t = new Token();

            switch (Code[Index])
            {
                case 'S':
                    lexeme += Code[Index];
                    State = 1; Index++;
                    break;
                case 'I':
                    lexeme += Code[Index];
                    State = 27; Index++;
                    break;
                case 'E':
                    State = 33; Index++;
                    break;
                case 'C':
                    lexeme += Code[Index];
                    State = 39; Index++;
                    break;
                case 'W':
                    lexeme += Code[Index];
                    State = 45; Index++;
                    break;
                case 'L':
                    lexeme += Code[Index];
                    State = 52; Index++;
                    break;
                case 'T':
                    lexeme += Code[Index];
                    State = 56; Index++;
                    break;

            }
            if (State == 0)
            {
                Index = Temp;
                t.Text = "fail";
                return t;
            }
            while (true)
            {
                switch (State)
                {
                    case 1:
                        if (Code[Index] == 'T')
                        {
                            lexeme += Code[Index];
                            State = 2; Index++;

                        }
                        else if (Code[Index] == 'I')
                        {
                            lexeme += Code[Index];
                            State = 5; Index++;
                        }
                        else if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 9; Index++;
                        }
                        else if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 16; Index++;
                        }
                        else
                        {
                            t.Text = "fail"; Index--;
                            return t;
                        }
                        break;
                    case 2:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 3; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 3:
                        if (Code[Index] == 'p')
                        {
                            lexeme += Code[Index];
                            State = 4;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 4:
                        t.Text = lexeme;
                        t.Type = "Break";
                        return t;
                        break;
                    case 5:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 6; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 6:
                        if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 7; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 7:
                        if (Code[Index] == 'f')
                        {
                            lexeme += Code[Index];
                            State = 8;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 8:
                        t.Text = lexeme;
                        t.Type = "SFloat";
                        return t;
                        break;
                    case 9:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 10; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 10:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 11; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 11:
                        if (Code[Index] == 'g')
                        {
                            lexeme += Code[Index];
                            State = 12; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 12:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 13; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 13:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 14; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 14:
                        if (Code[Index] == 'y')
                        {
                            lexeme += Code[Index];
                            State = 15;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 15:
                        t.Text = lexeme;
                        t.Type = "Class";
                        return t;
                        break;
                    case 16:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 17; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 17:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 18; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 18:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 19; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 19:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 20; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 20:
                        if (Code[Index] == 'u')
                        {
                            lexeme += Code[Index];
                            State = 21; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 21:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 22; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 22:
                        if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 23; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 23:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 24; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 24:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 25; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 25:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 26;

                        }
                        else
                        {
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    //case 1 fall completed        Index = Temp;
                    case 26:
                        t.Text = lexeme;
                        t.Type = "Loop";
                        return t;
                        break;
                    case 27:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 28; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 28:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 29; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 29:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 30; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 30:
                        if (Code[Index] == 'v')
                        {
                            lexeme += Code[Index];
                            State = 31; Index++;

                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 31:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 32;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 32:
                        t.Text = lexeme;
                        t.Type = "Inheritance";
                        return t;
                        break;
                    //case 27 fall completed
                    case 33:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 34; Index++;

                        }
                        else if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 37; Index++;

                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;

                    case 34:
                        if (Code[Index] == 's')
                        {
                            lexeme += Code[Index];
                            State = 35; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 35:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 36;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 36:
                        t.Text = lexeme;
                        t.Type = "Condition";
                        return t;
                        break;
                    case 37:
                        if (Code[Index] == 'd')
                        {
                            lexeme += Code[Index];
                            State = 38;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 38:
                        t.Text = lexeme;
                        t.Type = "End Statement";
                        return t;
                        break;
                    //case 33 fall completed
                    case 39:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 40; Index++;
                        }
                        else if (Code[Index] == 'f')
                        {
                            lexeme += Code[Index];
                            State = 44;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 40:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 41; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 41:
                        if (Index < Code.Length - 1)
                        {
                            if (Code[Index] == 'p' && (Code[Index + 1] == 'f'))
                            {
                                lexeme += Code[Index];
                                Index++;
                                lexeme += Code[Index];
                                State = 43;
                            }
                        }
                        if (Code[Index] == 'p')
                        {
                            lexeme += Code[Index];
                            State = 42;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 42:
                        t.Text = lexeme;
                        t.Type = "Integer";
                        return t;
                        break;
                    case 43:
                        t.Text = lexeme;
                        t.Type = "Float";
                        return t;
                        break;
                    case 44:
                        t.Text = lexeme;
                        t.Type = "Condition";
                        return t;
                    //case 39 is fall completed
                    case 45:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 46; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 46:
                        if (Code[Index] == 'g')
                        {
                            lexeme += Code[Index];
                            State = 47; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 47:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 48; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 48:
                        if (Code[Index] == 'c')
                        {
                            lexeme += Code[Index];
                            State = 49; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 49:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 50; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 50:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 51;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 51:
                        t.Text = lexeme;
                        t.Type = "Boolean";
                        return t;
                        break;
                    //case 45 is fall completed
                    case 52:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 53; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 53:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 52; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 54:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 55;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 55:
                        t.Text = lexeme;
                        t.Type = "Void";
                        return t;
                        break;
                    //case 52 is completed
                    case 56:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 57; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 57:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 58; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 58:
                        if (Code[Index] == 'g')
                        {
                            lexeme += Code[Index];
                            State = 59; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 59:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 60; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 60:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 61; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 61:
                        if (Code[Index] == 'm')
                        {
                            lexeme += Code[Index];
                            State = 62;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 62:
                        t.Text = lexeme;
                        t.Type = "Stat Statement";
                        return t;
                        break;
                    //case 56 is completed 
                    case 63:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 64; Index++;
                        }
                        else if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 73; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 64:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 65; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 65:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 66; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 66:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 67; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 67:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 68; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 68:
                        if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 69; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 69:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 70; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 70:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 71; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 71:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 72;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 72:
                        t.Text = lexeme;
                        t.Type = "Loop";
                        return t;
                        break;
                    //case 63 is completed 
                    case 73:
                        if (Code[Index] == 'p')
                        {
                            lexeme += Code[Index];
                            State = 74; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 74:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 75; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 75:
                        if (Code[Index] == 'y')
                        {
                            lexeme += Code[Index];
                            State = 76; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 76:
                        if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 77; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 77:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 78; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 78:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 79; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 79:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 80;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 80:
                        t.Text = lexeme;
                        t.Type = "Return";
                        return t;
                        break;
                    //case 63 is completed
                    case 81:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 82; Index++;
                        }
                        else if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 87; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 82:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 83; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 83:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 84; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 84:
                        if (Index < Code.Length - 1)
                        {
                            if (Code[Index] == 'p' && (Code[Index + 1] == 'f'))
                            {
                                lexeme += Code[Index];
                                Index++;
                                lexeme += Code[Index];
                                State = 86;
                            }
                        }
                        if (Code[Index] == 'p')
                        {
                            lexeme += Code[Index];
                            State = 85;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 85:
                        t.Text = lexeme;
                        t.Type = "SInteger";
                        return t;
                        break;
                    case 86:
                        t.Text = lexeme;
                        t.Type = "SFloat";
                        return t;
                        break;
                    //case 81 is completed
                    case 87:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 88; Index++;
                        }
                        else if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 92; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 88:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 89; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 89:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 90; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 90:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 91;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 91:
                        t.Text = lexeme;
                        t.Type = "String";
                        return t;
                    case 92:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 93;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 93:
                        t.Text = lexeme;
                        t.Type = "Struct";
                        return t;
                        break;
                    //case 81 is completed
                    case 94:
                        if (Code[Index] == 's')
                        {
                            lexeme += Code[Index];
                            State = 95; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 95:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 96; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 96:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 97; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 97:
                        if (Code[Index] == 'g')
                        {
                            lexeme += Code[Index];
                            State = 98;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 98:
                        t.Text = lexeme;
                        t.Type = "Inclusion";
                        return t;
                    //case 94 is completed
                    case 99:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 100; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 100:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 101; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 101:
                        if (Code[Index] == 'u')
                        {
                            lexeme += Code[Index];
                            State = 102; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 102:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 103; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 103:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 104; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 104:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 105; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 105:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 106; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 106:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 107; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 107:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 108; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 108:
                        if (Code[Index] == 'f')
                        {
                            lexeme += Code[Index];
                            State = 109;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 109:
                        t.Text = lexeme;
                        t.Type = "Switch";
                        return t;
                        break;
                    //case 99 is completed 
                    case 110:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 111; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 111:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 112; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 112:
                        if (Code[Index] == 'm')
                        {
                            lexeme += Code[Index];
                            State = 113; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 113:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 114; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 114:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 115; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 115:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 116; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 116:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 117; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 117:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 118; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 118:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 119; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 119:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 120; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 120:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 121; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 121:
                        if (Code[Index] == 's')
                        {
                            lexeme += Code[Index];
                            State = 122;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 122:
                        t.Text = lexeme;
                        t.Type = "Wait";
                        return t;
                        break;
                        //case 110 is completed 
                }
            }
        }
        private static Token ReturnSymoble()
        {
            int Temp = Index;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {
                    case 0:
                        if (Code[Index] == '>')
                        {
                            lexeme += Code[Index];
                            State = 123; Index++;
                        }
                        else if (Code[Index] == '<')
                        {
                            lexeme += Code[Index];
                            State = 125; Index++;
                        }
                        else if (Code[Index] == '=')
                        {
                            lexeme += Code[Index];
                            State = 127; Index++;
                        }
                        else if (Code[Index] == '!')
                        {
                            lexeme += Code[Index];
                            State = 129; Index++;
                        }
                        else if (Code[Index] == '~')
                        {
                            lexeme += Code[Index];
                            State = 131; Index++;
                        }
                        else if (Code[Index] == '&')
                        {
                            lexeme += Code[Index];
                            State = 132; Index++;
                        }
                        else if (Code[Index] == '|')
                        {
                            lexeme += Code[Index];
                            State = 134; Index++;
                        }
                        else if (Code[Index] == '.')
                        {
                            lexeme += Code[Index];
                            State = 136; Index++;
                        }
                        else if (isArithmeticOperation(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 137;
                        }
                        else if (isBraces(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 138;
                        }
                        else if (isQuaotationMark(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 139;
                        }
                        else if (Code[Index] == ';')
                        {
                            lexeme += Code[Index];
                            State = 151;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 123:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '=')
                            {
                                lexeme += Code[Index];
                                State = 124;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Relational Operators";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Relational Operators";
                            return T;
                        }
                        break;
                    case 124:
                        T.Text = lexeme;
                        T.Type = "Relational Operator";
                        return T;
                        break;
                    case 125:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '=')
                            {
                                lexeme += Code[Index];
                                State = 126;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Relational Operators";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Relational Operators";
                            return T;
                        }
                        break;
                    case 126:
                        T.Text = lexeme;
                        T.Type = "Relational Operator";
                        return T;
                        break;
                    case 127:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '=')
                            {
                                lexeme += Code[Index];
                                State = 128;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Assignment Operators";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Assignment Operators";
                            return T;

                        }
                        break;
                    case 128:
                        T.Text = lexeme;
                        T.Type = "Relational Operator";
                        return T;
                        break;
                    case 129:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '=')
                            {
                                lexeme += Code[Index];
                                State = 130;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Error";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        break;
                    case 130:
                        T.Text = lexeme;
                        T.Type = "Relational Operator";
                        return T;
                        break;
                    case 131:
                        T.Text = lexeme;
                        T.Type = "Logic Operator";
                        return T;
                        break;
                    case 132:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '&')
                            {
                                lexeme += Code[Index];
                                State = 133;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Error";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        break;
                    case 133:
                        T.Text = lexeme;
                        T.Type = "Logic Operator";
                        return T;
                        break;
                    case 134:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '|')
                            {
                                lexeme += Code[Index];
                                State = 135;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Error";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        break;
                    case 135:
                        T.Text = lexeme;
                        T.Type = "Logic Operator";
                        return T;
                        break;
                    case 136:
                        T.Text = lexeme;
                        T.Type = "Access Operator";
                        return T;
                        break;
                    case 137:
                        T.Text = lexeme;
                        T.Type = "Arithmetic Operator";
                        return T;
                        break;
                    case 138:
                        T.Text = lexeme;
                        T.Type = "Braces";
                        return T;
                        break;
                    case 139:
                        T.Text = lexeme;
                        T.Type = "Quotation Mark";
                        return T;
                        break;
                    case 151:
                        T.Text = lexeme;
                        T.Type = "Seperator";
                        return T;
                        break;
                }
            }

            T.Text = "fail";
            return T;
        }
        private static Token ReturnIdentifier()
        {
            int Temp = Index;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {
                    case 0:
                        if (isAlpha(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 140; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 140:
                        if (Index <= Code.Length - 1)
                        {
                            if (isAlphaDigit(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 141; Index++;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Identifier";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Identifier";
                            return T;
                        }
                        break;
                    case 141:
                        if (Index <= Code.Length - 1)
                        {
                            if (isAlphaDigit(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 141; Index++;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Identifier";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Identifier";
                            return T;
                        }
                        break;



                }
            }
            Index = Temp;
            T.Text = "fail";
            return T;
        }
        private static Token ReturnComment()
        {
            int Temp = Index;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {
                    case 0:
                        if (Code[Index] == '/')
                        {
                            lexeme += Code[Index];
                            State = 142; Index++;
                        }
                        else if (Code[Index] == '$')
                        {
                            lexeme += Code[Index];
                            State = 147; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 142:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] == '$')
                            {
                                lexeme += Code[Index];
                                State = 143; Index++;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 143:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] == '$')
                            {
                                lexeme += Code[Index];
                                State = 145; Index++;
                            }
                            else if (Code[Index] != '$' || isWhiteSpace(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 144; Index++;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 144:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] != '$' || isWhiteSpace(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 144; Index++;
                            }
                            else if (Code[Index] == '$')
                            {
                                lexeme += Code[Index];
                                State = 145; Index++;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            T.Text = lexeme;
                            T.Type = "Mutiple Comment";
                            return T;
                        }
                        break;
                    case 145:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] == '/')
                            {
                                lexeme += Code[Index];
                                State = 146;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 146:
                        T.Text = lexeme;
                        T.Type = "Mutiple Comment";
                        return T;
                        break;
                    //case 142 is completed
                    case 147:
                        if (Code[Index] == '$')
                        {
                            lexeme += Code[Index];
                            State = 148; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;

                    case 148:
                        if (isAlphaDigit(Code[Index]) || Code[Index] == ' ' || Code[Index] == '\t')
                        {
                            lexeme += Code[Index];
                            State = 149; Index++;
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Single Comment";
                            return T;
                        }
                        break;
                    case 149:
                        if (Index <= Code.Length - 1)
                        {
                            if (isAlphaDigit(Code[Index]) || Code[Index] == ' ' || Code[Index] == '\t')
                            {
                                lexeme += Code[Index];
                                State = 149; Index++;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Single Comment";
                                return T;

                            }
                        }
                        else
                        {
                            T.Text = lexeme;
                            T.Type = "Single Comment";
                            return T;
                        }
                        break;


                }
            }

            T.Text = "fail";
            return T;
        }
        private static Token ReturnConstant()
        {
            int Temp = Index;
            int flag = 0;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {

                    case 0:
                        if (isDigit(Code[Index]))
                        {

                            lexeme += Code[Index];
                            State = 145; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;

                        }
                        break;
                    case 145:
                        if (Index <= Code.Length - 1)
                        {
                            if (isDigit(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 145; Index++;
                            }
                            else if (isAlphaDigit(Code[Index]))
                            {
                                if ((Index + 1) <= (Code.Length - 1) && isAlphaDigit(Code[Index + 1]))
                                {
                                    flag = 1;
                                    lexeme += Code[Index];
                                    State = 145; Index++;
                                }
                                else
                                {
                                    lexeme += Code[Index];
                                    T.Text = lexeme;
                                    T.Type = "Error";
                                    return T;
                                }
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Constant";
                                return T;
                            }
                        }
                        else if (flag == 1)
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        else
                        {

                            Index--;
                            T.Text = lexeme;
                            T.Type = "Constant";
                            return T;
                        }
                        break;

                }
            }
            Index = Temp;
            T.Text = "fail";
            return T;
        }
        private static List<Token> Scanner()
        {
            Index = 0;
            int i = 0;
            Console.WriteLine(Code);
            Token a = new Token();
            List<Token> tokens = new List<Token>();
            while (Index < Code.Length)
            {
                if (isWhiteSpace(Code[Index]))
                {
                    if (Code[Index] == '\n')
                    {

                        Line++;
                    }
                    Index++;
                    i++;
                }
                else
                {
                    a = ReturnComment();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;

                        tokens.Add(a); Index++;
                        continue;

                    }

                    a = ReturnKeywords();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    a = ReturnIdentifier();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;
                    }
                    a = ReturnSymoble();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    else if (a.Type == "Error")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    a = ReturnConstant();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    else if (a.Type == "Error")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    Index++;
                    i++;
                }
            }
            return tokens;
        }
        public static List<string> DisplayTokens(string code)
        {
            List<Token> y = new List<Token>();
            List<string> Tok = new List<string>();
            Code = code;
            y = Scanner();
            var x = y;
            foreach (var i in y)
            {
                if (i.Type == "Error")
                {
                    NumOfError++;
                    Tok.Add("Line  : " + i.LineNum + "  " + " Error in Token Text  :  " + i.Text);

                }
                else
                {
                    Tok.Add("Line  : " + i.LineNum + "  " + " Token Text:  " + i.Text + " Token Type  :  " + i.Type);

                }
            }
            if (Tok.Count != 0)
            {
                Tok.Add("Total NO of errors  :" + NumOfError);
                return Tok;
            }
            else
            {

                return Tok;
            }

        }
        public static string getCodeFromFile(string txt)
        {
            string text;
            if (System.IO.File.Exists(@txt))
            {
                text = System.IO.File.ReadAllText(@txt);
            }
            else
                text = txt;

            return text;
        }
    }
}
