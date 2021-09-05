using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args) //CALC  PROJECT
        {
           
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(LogDerivative("3x+1",Math.E));
            Console.WriteLine( "\u221Ax ^ 3 + 8x ^ 7 - 9");
            Console.WriteLine(RootDerivative("Sqr(4x^3+8x^7-9)"));
            Console.WriteLine(AdavancedAlgebricMul("3x^2*0.8x*6"));
            CsharpCodeCleaner("int i=0;string b=a;if(a==100){return true;}//Console.WriteLine(ASSEMBLY);");
                // temp += a[i];"));
                 //Console.WriteLine(RootDerivative("Sqr(2x^3+x^4-23x+6)"));
                 //Console.WriteLine(AdavancedAlgebricMul("32x^6*5x^7*78x^8"));
                 // Console.WriteLine(AlgebraMultiply("35x^2", "1" )); 
                 //string tester = "2x^3+8x^4+5";
                 //Console.WriteLine("FUNCTION: \u221A" + tester);
                 // crucial for the square root sign
                 // Console.WriteLine("Square root = \u221A");
                 //Console.WriteLine("DERIVATIVE: \n "+ RootDerivative("Sqr("+tester+")"));
                 //Console.WriteLine("Console.WriteLine();if(tomp.genius==true){tomp=genius;} //int i = 50;");
                 //Console.WriteLine();
                 //Console.WriteLine();
                 //  CsharpCodeCleaner("Console.WriteLine();if(tomp.genius==true){tomp=genius;} //int i = 50;");
                 //Console.WriteLine(CsharpCodeCleaner("//if()//{}//else{}"));
                 //string number = Root1("SQR(124x^67)");
                 //Console.WriteLine(number);
                 //Console.WriteLine(Root1("sqr(4x^-1)"));
                 //Console.WriteLine(MathSerieSum(31,64,7));
                 // Console.WriteLine(GetInSerie1(4,3,2)); // מציאת איבר בסדרה חשבונית לפי האיבר הראשון וההפרש.
                 // להוריד  trigo ?
                 //bool check=Console.CapsLock;
                 // Process.Start("http://www.google.com");

                    //Console.WriteLine("function :"+"-32*x^5");
                    // Console.WriteLine("integral :"+Integral("0x^2")+"+c");
                    // Console.WriteLine(("function :3*x^5+x-8*x^9-2x^4+235x^4+5x-2"));
                    // Console.WriteLine("derivative"+PolynomalDers("3*x^5+x-8*x^9-2x^4+235x^4+5x-2"));
                    int helper = 0;
            Console.Title = "Math Console";
            string d = "";
            string a = "";
            string b = "";
            double c = 0;
            double num = 0;
            char help = ' ';
            double temp1 = 0;
            double temp = 0;
            while (true) {
                b = "";
                c = 0;
                Console.WriteLine("Enter commands");
                a = Console.ReadLine();
                a = GetLetters(a).ToLower();
                switch (a)
                {
                    case "trigo":
                        Console.WriteLine("Insert commmand");
                        b = Console.ReadLine();
                        if (GetNumbers(b) == "")
                        {
                            Console.WriteLine("You must enter a valid value:");
                            d = Console.ReadLine();
                            if (GetNumbers(d) == "")
                            {
                                Console.WriteLine("You must enter a valid value:");
                                d = Console.ReadLine();
                                while (GetNumbers(d) == "")
                                {
                                    Console.WriteLine("You must enter a valid value:");
                                    d = Console.ReadLine();
                                }
                                d = GetNumbers(d);
                                c = double.Parse(d) / 180 * Math.PI;
                            }
                            else
                            {
                                d = GetNumbers(d);
                                c = double.Parse(d) / 180 * Math.PI;
                            }
                        }
                        else
                        {
                            c = double.Parse(GetNumbers(b)) / 180 * Math.PI;
                        }
                        switch (GetFunc(b))
                        {
                            case "sin":
                                Console.WriteLine(Math.Sin(c));
                                break;
                            case "cos":
                                Console.WriteLine(Math.Cos(c));
                                break;
                            case "tan":
                                Console.WriteLine(Math.Tan(c));
                                break;
                        }
                        break;
                    case "calc":
                        Console.WriteLine("insert the excerise");
                        b = Console.ReadLine();
                        if (b.Contains('*') || b.Contains('/') && !b.Contains('+') && !b.Contains('-'))
                        {

                            Console.WriteLine(AdvancedMul(b));
                        }

                        else if (b.Contains('+') || b.Contains('-') && !b.Contains('*') && !b.Contains('/'))
                        {
                            Console.WriteLine(Advanced(b));
                        }
                        break;
                    case "cmd":
                        Console.WriteLine("*V1.2 Commands: 9/1/2020");
                        Console.WriteLine("trigo : sin x, cos x, tan x");
                        Console.WriteLine("calc");
                        Console.WriteLine("time");
                        Console.WriteLine("date");
                        Console.WriteLine("title");
                        Console.WriteLine("color");
                        Console.WriteLine("loop");
                        Console.WriteLine("cls");
                        Console.WriteLine("der");
                        Console.WriteLine("linear");
                        Console.WriteLine("dot - checks if a dot is on a given linear");
                        Console.WriteLine("dots- checks if two dots are on a the same given linear");
                        Console.WriteLine("binary");
                        Console.WriteLine("ascii");
                        Console.WriteLine("web");
                        Console.WriteLine("weather");
                        Console.WriteLine("exit");

                        break;
                    case "cls":
                        Console.Clear();
                        break;
                    case "time":
                        Console.Write(DateTime.Now.Hour);
                        if (DateTime.Now.Minute < 10)
                        {
                            Console.Write("0");
                        }
                        Console.Write(":" + DateTime.Now.Minute);
                        Console.WriteLine();
                        break;
                    case "date":
                        Console.WriteLine(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                        break;
                    case "title":
                        Console.WriteLine("Insert your new title");
                        b = Console.ReadLine();
                        Console.Title = b;
                        break;
                    case "color":
                        Console.WriteLine("Insert your new text color");
                        b = GetLetters(Console.ReadLine());
                        switch (b) {
                            case "red":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "blue":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "green":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "yellow":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case "white":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                    case "loop":
                        Console.WriteLine("Enter the phrase you wish to repeat");
                        b = Console.ReadLine();
                        Console.WriteLine("Enter the number of times");
                        helper = int.Parse(Console.ReadLine());
                        Loop(b, helper);
                        break;
                    case "der":
                        Console.WriteLine("Enter a function");
                        b = Console.ReadLine();
                        // input validation check + if..
                        Console.WriteLine(PolynomalDers(b));
                        break;
                    case "linear":
                        double x, y, z, m;
                        Console.WriteLine("Enter an x value");
                        x = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter an y value");
                        y = double.Parse(Console.ReadLine());
                        Console.WriteLine("Second dot or a coefficient? D(dot)/C(coef)");
                        if (Console.ReadLine().ToLower() == "d")
                        {
                            Console.WriteLine("Enter an x value");
                            z = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter a y value");
                            m = double.Parse(Console.ReadLine());
                            Console.WriteLine(LinearGraph1(x, y, z, m));
                        }
                        else
                        {
                            Console.WriteLine("Enter the coefficient:");
                            double coef = double.Parse(Console.ReadLine());
                            Console.WriteLine(LinearGraph(x, y, coef));
                        }
                        break;
                    case "dot":
                        Console.WriteLine("Enter the X value of the dot");
                        d = Console.ReadLine();
                        if (d.Length == 1 && char.IsLetter(d[0]))
                            c = d[0] - 0;
                        else
                            c = double.Parse(d);
                        Console.WriteLine("Enter the Y Value of the dot");
                        d = Console.ReadLine();
                        if (d.Length == 1 && char.IsLetter(d[0])) // -אולי להשתמש בGetLetters() למקרה של רווחים?
                            num = d[0] - 0;
                        else
                            num = double.Parse(d);
                        Console.WriteLine("Enter the linear equation");
                        b = Console.ReadLine();
                        if (IsDot(b, c, num))
                            Console.WriteLine(c + "," + num + " is a dot on " + b);
                        else
                            Console.WriteLine(c + "," + num + " is not a dot on " + b);
                        break;
                    case "dots":
                        Console.WriteLine("Enter the X value of the dot");
                        d = Console.ReadLine();
                        if (d.Length == 1 && char.IsLetter(d[0]))
                            c = d[0] - 0;
                        else
                            c = double.Parse(d);
                        Console.WriteLine("Enter the Y Value of the dot");
                        d = Console.ReadLine();
                        if (d.Length == 1 && char.IsLetter(d[0]))
                            num = d[0] - 0;
                        else
                            num = double.Parse(d);

                        Console.WriteLine("Enter the X Value of the second dot");
                        d = Console.ReadLine();
                        if (d.Length == 1 && char.IsLetter(d[0]))
                            temp = d[0] - 0;
                        else
                            temp = double.Parse(d);
                        Console.WriteLine("Enter the Y Value of the second dot");
                        d = Console.ReadLine();
                        if (d.Length == 1 && char.IsLetter(d[0]))
                            temp1 = d[0] - 0;
                        else
                            temp1 = double.Parse(d);
                        Console.WriteLine("Enter the linear equation");
                        d = Console.ReadLine();
                        if (IsInLinear(d, c, num, temp, temp1))
                            Console.WriteLine("The dots ({0},{1}) and ({2},{3}) are on the linear {4}", c, num, temp, temp1, d);
                        else
                            Console.WriteLine("The dots ({0},{1}) and ({2},{3}) are not on the linear {4}", c, num, temp, temp1, d);
                        break;
                    case "binary":
                        Console.WriteLine("Enter a number");
                        helper = int.Parse(Console.ReadLine()); // validation needed that's an int type
                        Console.WriteLine(ToBinary(helper));
                        break;
                    case "ascii":
                        Console.WriteLine("Enter a letter");
                        help = char.Parse(Console.ReadLine());
                        Console.WriteLine(help - 0);
                        break;
                    default: Console.WriteLine("Command not found, please try again");
                        break;
                    case "web":
                        Console.WriteLine("Enter the name of the site, or the full domain");
                        b = Console.ReadLine();
                        b = b.ToLower();
                        if (ValidDomain(b))
                        {
                            Process.Start(b);
                        }
                        else
                        {
                            try
                            {
                                b = "www." + b + ".com"; // אולי למחוק רווחים בקלט?
                                // some websites don't end with "-com" 
                                Process.Start(b);
                            }
                            catch
                            {
                                Console.WriteLine("oops, an error has occured!");
                            }
                        }

                        break;
                    case "weather":
                        Process.Start("https://weather.com/weather/today/l/32.07,34.78?par=google&temp=c");
                        break;
                    case "exit":
                        return;
                }
            }
        }
        public static int OneDigitAdd(string input) { // מחבר ספרות
            string mid = " ";
            mid = Convert.ToString(input[0]);
            int sum = int.Parse(mid);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] == '+')
                {
                    mid = Convert.ToString(input[i]);
                    sum += int.Parse(mid);
                }

            }
            return sum;
        }
        public static int DigitAdd(string input)//מחבר מספרים
        {
            int sum = 0;
            string mid = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '+')
                {
                    mid += input[i];
                }
                else {
                    sum += int.Parse(mid);
                    mid = "";
                }
            }
            sum += int.Parse(mid);
            return sum;
        }
        public static int Advanced(string a)// מחבר ומחסר כמה מספרים ששמים, כל עוד הקלט תקין
        {
            int start = 0;
            int sum = 0;
            string mid = "";
            char sign = '+';
            if (a[0] == '-')
            {
                sign = '-';
                start = 1;
            }

            for (int i = start; i < a.Length; i++)
            {
                if (a[i] != '+' && a[i] != '-')
                {
                    mid += a[i];
                }
                else {
                    if (sign == '+')
                    {
                        sum += int.Parse(mid);
                    }
                    else {
                        if (sign == '-')
                        {
                            sum -= int.Parse(mid);

                        }
                    }
                    sign = a[i];
                    mid = "";
                }
            }
            if (sign == '+')
            {
                sum += int.Parse(mid);
            }
            else
            {
                sum -= int.Parse(mid);
            }
            return sum;
        }
        public static double AdvancedMul(string a)// מחבר ומחסר כמה מספרים ששמים, כל עוד הקלט תקין
        {
            double sum = 1;
            string mid = "";
            char sign = '*';
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != '*' && a[i] != '/' && a[i] != ':')
                {
                    mid += a[i];
                }
                else
                {
                    switch (sign)
                    {
                        case '*':
                            sum *= double.Parse(mid);
                            break;
                        case '/':
                            sum /= double.Parse(mid);
                            break;
                        case ':':
                            sum /= double.Parse(mid);
                            break;
                        default:
                            Console.WriteLine("Undefined operator");
                            break;
                    }
                    sign = a[i];
                    mid = "";
                }
            }
            switch (sign)
            {
                case '*':
                    sum *= double.Parse(mid);
                    break;
                case '/':
                    sum /= double.Parse(mid);
                    break;
                case ':':
                    sum /= double.Parse(mid);
                    break;
                default:
                    Console.WriteLine("Undefined operator");
                    break;
            }
            return sum;
        }
        public static string GetFunc(string a) { // מקבל מילה ומחזיר את 3 האותיות הראשונות, ממשיך כל עוד הקלט תקין cosine->cos , sine-> sin
            string sum = "";
            for (int i = 0; i < a.Length && i < 3 && char.IsLetter(a[i]) == true; i++) sum += a[i];
            return sum.ToLower();
        }
        public static void AdvancedPrintValues(string function, double range, double jump)// 
        {
            throw new NotImplementedException();
        }
        public static void PrintValues(string function, int from, double to) {// מדפיס את כל הערכים בין הטווח בפונקציה שנבחרה.
            function = GetFunc(function);
            double temp = 0;
            switch (function) {
                case "sin":
                    for (double i = from; i <= to; i++)
                    {
                        temp = i / 180.0 * Math.PI;
                        Console.WriteLine(i + ", " + Math.Sin(temp));
                    }
                    break;
                case "cos":
                    for (double i = from; i <= to; i++)
                    {
                        temp = i / 180.0 * Math.PI;
                        Console.WriteLine(Math.Cos(temp));
                    }
                    break;
                case "tan":
                    for (double i = from; i <= to; i++)
                    {
                        temp = i / 180.0 * Math.PI;
                        Console.WriteLine(i + ", " + Math.Tan(temp));
                    }
                    break;
                default:
                    Console.WriteLine(" Invalid input");
                    break;
            }
        }
        public static bool IsValid(string a) // returns if there's something else than numbers
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!Char.IsDigit(a[i]))
                    return false;
            }
            return true;
        }
        public static string GetNumbers(string a) {// this function returns only the numbers in the string: '54f3h5'->5435
            string sum = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    sum += a[i];
            }
            return sum;

        }
        public static string GetLetters(string a) // just like GetNumbers(), for letters.
        {
            string sum = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsLetter(a[i]))
                    sum += a[i];
            }
            return sum;
        }
        public static void Loop(string a, int b) {for (int i = 0; i < b; i++) Console.WriteLine(a); } // // prints a for b times
        public static string PolynomalDer(string a) { // calculates a single derivative for an expression.
            a = a.ToLower();
            int b = a.IndexOf('x');
            if (a == "" || a == null) {
                return "";
            }
            if (b == -1)
                return "0";
            string coef = "";
            int start = 0;
            switch (a[0]) {
                case '-':
                    start = 1;
                    coef = "-";
                    break;
                case '+':
                    start = 1;
                    break;
            }
            for (int i = start; i < b && char.IsNumber(a[i]); i++)
            {
                coef += a[i];
            }
            if (coef == "")
                coef = "1";
            string pow = "";
            int c = a.IndexOf('^') + 1;
            if (c == 0)
            {
                return coef;
            }
            for (int i = c; i < a.Length && char.IsNumber(a[i]); i++)
            {
                pow += a[i];
            }
            if (pow == "")
                pow = "1";
            if (pow == "0")
                return "0";
            int poww = int.Parse(pow);
            int coeff = int.Parse(coef) * poww;
            poww--;
            if (poww > 1)
                return coeff + "x" + "^" + poww;
            return coeff + "x";



        }
        public static string PolynomalDers(string a) { // does multiple expressions derivative, using the function "der".
            string sum = "";
            string current = "";
            char sign = '+';
            int start = 0;
            if (a[0] == '-')
            {
                sum = "-";
                start = 1;
            }


            string signs = "+-*/";
            for (int i = start; i < a.Length; i++)
            {
                if (signs.IndexOf(a[i]) == -1 || (a[i + 1] == 'x' && a[i] == '*'))
                {
                    current += a[i];
                }
                else {
                    sign = a[i];
                    if(!(PolynomalDer(current)=="0"))
                    {
                        sum += PolynomalDer(current) + sign;
                    }
                    current = "";
                }
            }
            if (!(PolynomalDer(current) == "0"))
            {
                sum += PolynomalDer(current) + sign;
            }
            if (sum[0] == '+')
                sum = sum.Remove(0, 1);
            if (sum[sum.Length-1] == '+' || sum[sum.Length-1]=='-')
                sum = sum.Remove(sum.Length - 1, 1);
            return sum;
        }
        public static string Integral(string a)
        {
            string coeff = "";
            int index = a.IndexOf('x');
            if (index == -1)
                return a + 'x';
            if (a[0] == 'x')
            {
                coeff = "1";
            }
            else
            {
                for (int i = 0; i < index && a[i] != '*'; i++)
                {
                    coeff += a[i];
                }
            }
            int coef = int.Parse(coeff);
            if (coef == 0)
                return "c";
            int pow = a.IndexOf('^') + 1; // the place after the '^'
            if (pow == 0)
            {
                if (coeff == "2")
                {
                    return "x^2";
                }
                return coef / 2 + "x^2";

            }
            string poww = "";
            for (int i = pow; i < a.Length; i++)
            {
                poww += a[i];
            }
            if (poww == "0") // 5*x^0 = 5 -> the integral is 5x
            {
                if (coeff == "1")
                    return "x";
                return coeff + "x";
            }
            pow = int.Parse(poww) + 1;
            if (coef == pow)
                return "x^" + pow;
            return Math.Round((double)coef / (double)(pow), 2) + "x^" + pow; // המרה ל  double ואיחזור 
        }
        public static string LinearGraph(double x, double y, double coef)
        {
            if (coef == 0)
                return "y= " + y + "";
            double b = Math.Round((-coef * x + y), 3);
            coef = Math.Round(coef, 3);
            if (b == 0)
                return "y = " + coef + "x";
            if (b < 0)
                return "y = " + coef + "x" + b;
            return "y = " + coef + "x" + "+" + b;
        }
        public static string LinearGraph1(double x1, double y1, double x2, double y2)
        {
            double coef = Math.Round((y2 - y1) / (x2 - x1));
            if (x1 == x2 && y1 != y2)
                return "The input is not a function: the same X can't have a different Y"; // x1-x2 =0.. can't divide by 0 
            if (x1 == x2 && y1 == y2)
                return "Those are the same dots!";
            return LinearGraph(x1, y1, coef);
        }
        public static bool IsDot(string graph, double x, double y) // בודק אם נקודה על הגרף
        {
            double coef = 0;
            string mone = "";
            double b = 0;
            int start = 0;
            int index = graph.IndexOf('x');
            if (index == -1)
            {
                start = graph.IndexOf('=') + 1;// y=564;
                for (int i = start; i < graph.Length && !char.IsLetter(graph[i]); i++)
                {
                    mone += graph[i];
                }
                if (Math.Round(double.Parse(mone), 7) == Math.Round(y, 7))// The Y value should be equal to the number.
                    return true;
                return false;
            }
            else
            {
                start = graph.IndexOf('=') + 1;
                if (start == index)
                {
                    coef = 1;
                }
                else
                {
                    for (int i = start; i < index && !char.IsLetter(graph[i]); i++)//y=32x+5 -> y=[32]x+5
                    {
                        mone += graph[i];
                    }
                    coef = double.Parse(mone);
                }

                mone = "";
                int plus = graph.LastIndexOf('+');
                int minus = graph.LastIndexOf('-');
                index = Math.Max(plus, minus);// if the one is -1, it'll not qualify..
                double y1 = 0;
                if (plus == -1 && minus == -1)
                {
                    y1 = x * coef;
                    if (y1 == y)
                        return true;
                    return false;
                }// no need for else because of the return command;
                for (int i = index + 1; i < graph.Length && !char.IsLetter(graph[i]); i++)
                {
                    mone += graph[i];
                }
                if (minus != -1) // if there is a minus
                {
                    b = double.Parse('-' + mone); // add minus  to the number
                }
                else
                {
                    b = double.Parse(mone);
                }
                y1 = x * coef + b;
                if (y == y1)
                    return true;

                return false;
            }
        }
        public static bool IsInLinear(string linear, double x1, double y1, double x2, double y2)// checks if the two dots are on the linear given
        {
            return IsDot(linear, x1, y1) && IsDot(linear, x2, y2);
        }
        public static string ToBinary(int a)
        {
            string res = "";
            while (a != 0)
            {
                if (a % 2 == 0)
                    res += '0';
                else
                    res += '1';
                a /= 2;
            }
            string b = "";
            for (int i = res.Length - 1; i >= 0; i--)
            {
                b += res[i];
            }
            return b;
        }
        public static bool ValidDomain(string a)
        {

            string sum = "";
            int sign = a.IndexOf('w'); // https://www.google.com
            if (sign == -1)
                return false;
            if (sign != 0)
            {
                for (int i = 0; i < sign; i++)
                {
                    sum += a[i];
                }
                if (sum != "http://" && sum != "https://" && sum != " ")
                {
                    Console.WriteLine("before w not good.");
                    return false;
                }
            }
            if (a[sign + 1] != 'w' && a[sign + 2] != 'w' && a[sign + 3] != '.')
                return false;
            sign = a.LastIndexOf('.');
            if (sign == -1)
                return false;
            if (a.Length - sign != 4)
            {
                Console.WriteLine("DOT INDEX WRONG!");
                return false;
            }
            return true;
        }
        /*
        public static int And(string a) // x>88 and x>98 -> 88
        {
            a = a.ToLower();
            if (!a.Contains("and"))
            {
                Console.WriteLine("Not valid");
                return -1;
            }
            int index = a.IndexOf(a);
            string sum = "";
            for (int i = 0; i < index; i++)
            {
                if(char.IsNumber(a[i]))
                sum += a[i];
            }
            int one = int.Parse(Console.ReadLine()); // TryParse()?
            index = a.IndexOf('d') + 1;
            sum = "";
            for (int i = index; i <a.Length; i++)
            {
                if (char.IsNumber(a[i]))
                    sum += a[i];
            }
            index = int.Parse(Console.ReadLine());
      }
            */
       public static double LawOfSine(double a, double alpha, double c) // to find an angle 
        {
            alpha = alpha / 180 * Math.PI;
            double res = c * Math.Sin(alpha) / a;
            if(res<=1 && res>=-1)
                return Math.Asin(res) * 180 / Math.PI;
            Console.WriteLine(" Invalid parameters. Values are not possible");
            return -1;
        }     
        public static double LawOfSine1(double a, double alpha, double gamma)// to find c
        {
            alpha = alpha / 180 * Math.PI;
            gamma = gamma/180 * Math.PI;
           return a * Math.Sin(gamma) / Math.Sin(gamma);
            
        }
        public static double LawOfCosine(double a, double b, double gamma)// returns c..
        {
            gamma = gamma / 180 * Math.PI;
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(gamma));
        }
        public static string TrigoIdentity(string a) // insert a method that erases empty chars..
        { // A basic method ..
            a = a.ToLower();
            switch(a)
            {
                case "sinx":
                    return "cos(90-x)";
                case "sin(a+b)":
                    return "sin a * cos b + sin b * cos a"; // TO BE CONTINUED ..
                default:
                    return "Identity not found. Check for Typos and Syntax Errors";
            }
        }
        public static double GetInSerie1(double a1, double d, int n) //סדרה חשבונית איבר
        {
            return a1 + d * (n - 1);
        }
        public static double MathSerieSum(double a1, double d, int n) //סכום של סדרה חשבונית
        {
            return (n / 2) * (2 * a1 + d * (n - 1));
        }
        public static double GeometricProg(double a1, double q, int n)// איבר בסדרה הנדסית
        {
            return a1 * Math.Pow(q, n - 1);
        }
        public static double GeometricProgSum(double a1, double q, int n)//סכום של סדרה הנדסית
        {
            return (a1 * (Math.Pow(q, n) - 1)) / (q - 1);
        }
        public static  string  Root1(string a)
        {
            
            // DO: IsValid()
           // Console.WriteLine(a);
            a = a.ToLower();
            int index = a.IndexOf("sqr")+2;
            if (a.IndexOf('(') != index + 1)
                return "NOT A VALID SYNTAX";
            index = a.IndexOf('(');
            string root = a.Substring(index+1, a.IndexOf(')') - index-1);
            //Console.WriteLine(root);
            //Console.WriteLine(HasLetters(root));
            if (!HasLetters(root))
                return Math.Sqrt(double.Parse(root)).ToString();
            if(root.StartsWith("x^"))
            {
                root="1"+root;
            }
            // Console.WriteLine(root);
            // Console.WriteLine((root.Length - root.IndexOf('^')-1));
            //a = root.Substring(root.IndexOf('^')+1 , root.Length - root.IndexOf('^') - 1);
            a = "";
            index = 0;
            if(root.IndexOf('x')==root.Length-1 || root[root.IndexOf('x')+1]!='^')
            {
               root= root.Insert(root.IndexOf('x') + 1, "^1");
               
            }
            for (int i = 0; i < root.IndexOf('x'); i++)
            {
                a += root[i];
            }
            double container = double.Parse(a);
            container = Math.Round(Math.Sqrt(container),3);
            a = container.ToString();
            //Console.WriteLine(a);
            string b = "";
            for (int i = root.IndexOf('^') + 1;  i < root.Length; i++)
            {
                b += root[i];
            }
            //Console.WriteLine(b+"m");
            container = double.Parse(b) / 2;
            if (container == 0)
                return a;
            if(double.Parse(b)<0) // מעריך שלילי
            {
                return "1/" + (a +"^" +(double.Parse(b)) * (-1)/2);
            }
            b= a+"x^"+container;
            if (b.StartsWith("1x"))
            {
                b = b.Substring(1, b.Length - 1);
            }


            Console.WriteLine(b);
            return b ;
        }
        public static bool HasLetters(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!char.IsDigit(a[i]))
                    return true;
            }
            return false ;
        }
        public static string CsharpCodeCleaner(string a) // Makes the code tidy. Basic. Needed : MultiComment,Keywords colors.
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            bool comment = false;
            bool multicomment = false;
            string b = "";
            int lineCounter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                b += a[i];
                if (a[i] == ';')
                {
                    b += "\n";
                    lineCounter++;
                    comment = false;
                }
                else if (a[i] == '}' || a[i] == ')' && a[i + 1] != ')' && a[i + 1] != '}' && a[i + 1] != ';')
                {
                    b += "\n";
                    lineCounter++;
                    comment = false;
                }
                else if (a[i] == '{')
                {
                    b += "\n";
                    lineCounter++;
                    comment = false;
                }
               // if(i<a.Length-1 && a[i+1]=='}')
               // {
               //     b += "\n";
               // }
                


            }
            for (int i = 0; i < b.Length; i++)
            { 
                if (b[i] == ';')
                    comment = false;
                if (b[i] == '}' || b[i] == ')' && b[i + 1] != ')' && b[i + 1] != '}' && b[i + 1] != ';')
                    comment = false;
                if (b[i] == '{')
                    comment = false;

                if (b[i] == '/' && b[i + 1] == '/')
                {
                    comment = true;
                }
                if (comment)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(b[i]);
                }
                else
                {
                    Console.Write(b[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return b;
        }
        public static string RootDerivative(string a) // syntax : Sqr() DOING DERIVATIVES OF SQUARE (REAL) EXPERSSIONS.
        {
            string b = a.Substring(a.IndexOf('(') + 1, a.IndexOf(')') - a.IndexOf('('));
            string c = "2\u221A" + "(" + b; // 2 * the square root
            a = "";
            for (int i = 0; i < Math.Max(PolynomalDers(b).Length,c.Length); i++)
            {
                a += '-';
            }
            return PolynomalDers(b) +"\n"+a +"\n"+ c ;
        }
        public static string LogDerivative(string expression, double logBase)
        {
            // Logarithm Derivative,
            string accumulator = PolynomalDers(expression);
            if (logBase == 1) accumulator = "0";
            else accumulator += logBase != Math.E ? $" * ln({logBase})" : "";
            accumulator += " \n";
            int len = accumulator.Length;
            for (int i = 0; i < Math.Max(len, expression.Length); i++)
                accumulator += '-';
            accumulator += $"\n{expression}";
            return accumulator;
        }
        public static string LnDerivative(string expression) => LogDerivative(expression, Math.E);
        // remove space chars function ..
        public static double GetPower(string a) // format: 45^4
        {
            if (!a.Contains('^'))
                return -1;
            string d = a.Substring(0, a.IndexOf('^'));
           // Console.WriteLine(d+",,,,res");
            double b = double.Parse(d); // extract first number from string 
           // Console.WriteLine(b);
            double c = double.Parse(a.Substring(a.IndexOf('^') + 1, a.Length - 1-a.IndexOf('^'))); // extract second number from string
            //Console.WriteLine(c);
            return Math.Pow(b, c);
        }
        public static string AlgebraMultiply(string first, string second)
        {
            
            string coefFirst, coefSec = "";
            if(first.Contains('x'))
            { // 34x^2
                coefFirst = first.Substring(0, first.IndexOf('x')); //34
                first = first.Substring(first.IndexOf('x'), first.Length - first.IndexOf('x'));  // x^2
            }
            else
            {
                if (first.Contains('^'))
                    coefFirst = GetPower(first).ToString();
                else
                coefFirst = first;
                first ="x^0";
            }
            // *****************************************************************************************************
            if (second.Contains('x'))
            {
                coefSec = second.Substring(0, second.IndexOf('x'));
                second = second.Substring(second.IndexOf('x'), second.Length  - second.IndexOf('x'));
            }
            else
            {
                if (second.Contains('^'))
                    coefSec = GetPower(second).ToString();
                else
                    coefSec = second;
                second = "x^0";
                
            }
           
            double totalCoeff = double.Parse(coefFirst) * double.Parse(coefSec);
            // *****************************************************************************************************
            if (first.EndsWith("x"))
                first = first + "^1";

            if (second.EndsWith("x"))
                second = second + "^1";
            // *****************************************************************************************************
            
            if (first.Contains('^'))
            {
                first = first.Substring(first.IndexOf('^') + 1, first.Length - first.IndexOf('^') - 1);// 3x^54 ->54
                Console.WriteLine(first+"f");
            }
            else
                Console.WriteLine("Something went wrong. (ERROR '^' NOT FOUND !");
            if (second.Contains('^'))
            {
                second = second.Substring(second.IndexOf('^') + 1, second.Length-second.IndexOf('^')-1);// 3x^54 ->54
                Console.WriteLine(second+"s");
            }
            else
                Console.WriteLine("Something went wrong. (ERROR '^' NOT FOUND !");
            // *****************************************************************************************************
            double finalx = double.Parse(first) + double.Parse(second);
            return totalCoeff + "x^" + finalx; 
        }
        public static string AdavancedAlgebricMul(string a) // using the AlgebraMultiply() method: 3x^2*953x^7*32x^77 ...
        {
            string all = "1";
            string temp = "";
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i]=='*')
                {
                   
                    all = AlgebraMultiply(all, temp);
                    temp = "";
                }
                else
                {
                    temp += a[i];
                }
                
            }
           // Console.WriteLine(all); // check
           // Console.WriteLine(temp); // check
            
            all = AlgebraMultiply(all, temp);
            temp = "";
            return all;
        }
        public static double GetDivisor(double frequency) // 1193180hz/frequency   TO DO : PARSE IT TO HEXADECIMAL BASE OF COUNT.
        {
            return 1193180 / frequency;
        }
    }
    
     // TO DO REVERSE BINARY
 }
    
        
    

