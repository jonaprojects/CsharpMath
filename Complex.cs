using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath
{
    class Complex
    {
        private static Random rnd = new Random();
        public double A { get; set; }
        public double B { get; set; }
        public double Theta { get; set; }
        public double Radius { get; set; }
        // CONSTRUCTOR
        public Complex(double a, double b, bool isAlgebric) // Choosing between creating with trigonometric or algebric approach
        {
            if (isAlgebric)
            {
                A = a;
                B = b;
                UpdatePolarRepresentation();
            }
            else
            {
                Radius = a; Theta = ConvertToRadians(b); // turn theta to radians
                UpdateAlgebricRepresentation();
            }
        }

        public Complex(double a, double b) : this(a, b, true)
        {

        }
        public Complex()
        {

        }
        public Complex(string declaration)
        {
            Complex z = GetComplexFromString(declaration);
            A = z.A;
            B = z.B;
            Radius = z.Radius;
            Theta = z.Theta;
        }
        public double ConvertToDegrees(double x) => x * 180 / Math.PI;
        public double ConvertToRadians(double x) => x / 180 * Math.PI;
        public Complex GetComplexFromString(string declaration)
        {
            declaration = declaration.Trim().ToLower();
            Complex temp = new Complex();
            if (!declaration.Contains("cis"))
            {
                int signIndex = declaration.LastIndexOf('+');
                if (signIndex == -1 || signIndex == 0)
                {
                    signIndex = declaration.LastIndexOf('-');
                    if (signIndex == -1 && signIndex == 0)
                    {
                        throw new Exception("Invalid input ! ");
                    }

                }
                Console.WriteLine(signIndex);
                temp.A = double.Parse(declaration.Substring(0, signIndex).Trim());

                if (!declaration.Contains('i')) temp.B = 0;
                else
                    temp.B = double.Parse(declaration.Substring(signIndex + 1, declaration.IndexOf('i') - signIndex - 1).Trim());
                temp.UpdatePolarRepresentation();

            }
            else
            {
                temp.Radius = double.Parse(declaration.Substring(0, declaration.IndexOf('c')).Trim());
                int startIndex = declaration.IndexOf('(') + 1, endIndex = declaration.IndexOf(')');
                temp.Theta = ConvertToRadians(double.Parse(declaration.Substring(startIndex, endIndex - startIndex)));
                temp.UpdateAlgebricRepresentation();
            }
            return temp;
        }
        public override string ToString()
        {
            return $"Algebric Representation: {A}+{B}i \n Polar Representation: {Radius}* Cis({ConvertToDegrees(Theta)})";
        }
        public void UpdatePolarRepresentation()
        {
            Radius = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
            // needs to match the angle with the quarter
            Theta = Math.Atan(B / A);
            CorrectAngle();
            int desired_quarter = GetQuarterByAlgebric();
            int current_quarter = new Complex(Radius, this.ConvertToDegrees(Theta), false).GetQuarterByAlgebric();
            Theta += (desired_quarter - current_quarter) * Math.PI / 2;
        }
        public void UpdateAlgebricRepresentation()
        {
            A = Radius * Math.Cos(Theta);
            if (A - Math.Floor(A) < 0.000001)
                A = Math.Floor(A);
            B = Radius * Math.Sin(Theta);

        }
        public void CorrectAngle()
        {
            double theta = this.ConvertToDegrees(Theta);
            while (theta < 0)
                theta += 360;
            Theta = ConvertToRadians(theta);
        }
        public Complex Add(Complex z) { A += z.A; B += z.B; UpdatePolarRepresentation(); return this; }
        public Complex Add(params Complex[] complices)
        {
            foreach (Complex complex in complices) this.Add(complex);
            return this;
        }
        public Complex Multiply(Complex z) { Radius *= z.Radius; Theta += z.Theta; UpdateAlgebricRepresentation(); return this; }
        public Complex Multiply(params Complex[] complices)
        {
            foreach (Complex complex in complices) this.Multiply(complex);
            return this;
        }
        public static Complex GetMultiplication(params Complex[] complices)
        {
            Complex holder = complices[0];
            for (int i = 1; i < complices.Length; i++) { holder.Multiply(complices[i]); }
            return holder;

        }
        public static double GetDistance(Complex z, Complex z1) => Math.Sqrt(Math.Pow(z.A - z1.A, 2) + Math.Pow(z.B - z1.B, 2));
        public static bool IsEqualTriangle(Complex z, Complex z1, Complex z2)
        {
            double distance = GetDistance(z, z1);
            if (!(distance == GetDistance(z, z2))) return false;
            return GetDistance(z1, z2) == distance;
        }
        public Complex Divide(Complex z) { Radius /= z.Radius; Theta -= z.Theta; UpdateAlgebricRepresentation(); return this; }
        public int GetQuarterByPolar()
        {
            double theta = ConvertToDegrees(Theta);
            if (theta > 0 && theta < 90) return 1;
            if (theta > 90 && theta < 180) return 2;
            if (theta > 180 && theta < 270) return 3;
            if (theta > 270 && theta < 360) return 4;
            return -1;
        }
        public int GetQuarterByAlgebric()
        {
            if (A > 0 && B > 0) return 1;
            if (A < 0 && B > 0) return 2;
            if (A < 0 && B < 0) return 3;
            return 4;
        }
        public Complex Power(double x)
        {
            Radius = Math.Pow(Radius, x); Theta *= x;
            UpdateAlgebricRepresentation(); return this;
        }
        public Complex[] Root(double x)
        {
            double radius = Math.Pow(Radius, 1 / x);
            double theta = this.ConvertToDegrees(Theta) / x;
            double add = 360 / x;
            Complex[] complices = new Complex[(int)x];
            for (int i = 0; i < (int)x; i++)
                complices[i] = new Complex(radius, theta + add * i, false);
            return complices;
        }
        public static Complex SqrtToComplex(double num)
        {
            // receives square root of a negative / positive number and converts it to a complex number
            if (num < 0)
                return new Complex(0, Math.Sqrt(Math.Abs(num)));
            return new Complex(Math.Sqrt(num), 0);
        }
        public static Complex[] GenerateRandom(int count)
        {
            Complex[] complices = new Complex[count];
            for (int i = 0; i < count; i++)
                complices[i] = new Complex(rnd.Next(-500, 501), rnd.Next(-500, 501));
            return complices;
        }
    }
}

