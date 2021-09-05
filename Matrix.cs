using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Matrices
{
    class Matrix
    {
        private static Random rnd = new Random();
        public double[,] Mat { get; set; }
        public int Height
        {
            get
            {
                if (Mat != null)
                    return this.Mat.GetLength(0);
                return -1;
            }
           private set
            {
                
            }
        }
        public int Width
        {
            get
            {
                return this.Mat.GetLength(1);
            }
            private set
            {

            }
        }
        /*
        public Matrix(int height, int width)
        {
            if(Mat !=null)
                Mat = new double[height, width];
            else
                Console.WriteLine("Mat is null ! ");
        }
        */
        public Matrix(double[,] matrix)
        {
            Mat = matrix;
            
        }
       
        public double[,] Copy()
        {
            double[,] newMatrix = new double[Height, Width];
            for (int i = 0; i < Height; i++) { for (int j = 0; j < Width; j++) newMatrix[i, j] = this.Mat[i, j];}
            return newMatrix;  
        }
        public void AddOrSub(Matrix other, bool addOrSub)
        {
            // Adds another matrix
            if (Mat.GetLength(0) != other.Mat.GetLength(0) || other.Mat.GetLength(1) != Mat.GetLength(1))
                return;
            double temp = 0;
            for(int i = 0; i<Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    temp = other.Mat[i, j] * (addOrSub ? 1 : -1);
                    Mat[i, j] += temp;
                }
                   
            }
        }
        public void Add(Matrix other) { AddOrSub(other, true);}
        public void Sub(Matrix other) { AddOrSub(other, false);}
        public void Add(params Matrix[] matrices) { foreach (Matrix m in matrices) Add(m); }
        public void ScalarMulRow(double scalar, int rowIndex)
            // WORKS BY INDICES
        {
            for (int j = 0; j < Width; j++)
                Mat[rowIndex, j] *= scalar;
        }
        public void ScalarMultiply(double scalar)
        {
            // WORKS BY INDICES
            for (int i = 0; i < Height; i++)
                ScalarMulRow(scalar, i);
        }
        
        public void ScalarDivRow(double scalar,int rowIndex)
        {
            // WORKS BY INDICES
            if (scalar == 0) throw new DivideByZeroException();
            ScalarMulRow(1 / scalar, rowIndex);
        }
        public void ScalarMulLine(double scalar, int rowIndex)
        {
            // WORKS BY LINE NUMBERS
            if (rowIndex < 1 || rowIndex-- > Height) throw new IndexOutOfRangeException();
            for (int j = 0; j < Width; j++)
                Mat[rowIndex, j] *= scalar;
        }
       
        public void ScalarsMultiply(params double[] scalars){ foreach (double scalar in scalars) ScalarMultiply(scalar); }
            
        public void ScalarDivision(double scalar)
        {
            if (scalar == 0) throw new DivideByZeroException();
            ScalarMultiply(1 / scalar);
        }
        public void ScalarsDivision(params double[] scalars) { foreach (double scalar in scalars) ScalarDivision(scalar); }
        public void ReplaceLines(int lineNum, int otherLineNum)
        {
            // WORKS BY LINE NUMBERS
            if (lineNum < 1 || otherLineNum < 1) return;
            lineNum--; otherLineNum--;
            if (lineNum >= Height || otherLineNum >= Height) return;
            double temp = 0;
            for(int i = 0; i < Width; i++)
            {
                temp = this.Mat[lineNum, i];
                this.Mat[lineNum, i] = this.Mat[otherLineNum, i];
                this.Mat[otherLineNum, i] = temp;
            }
        }
        
        public void AddLines(int lineNum, int otherLineNum)
        {
            // WORKS BY LINE NUMBERS
            if (lineNum < 1 || otherLineNum < 1) return;
            lineNum--; otherLineNum--;
            if (lineNum >= Height || otherLineNum >= Height) return;

            for (int i = 0; i < Width; i++)
                this.Mat[lineNum, i] += this.Mat[otherLineNum, i];
        }
        public void AddWithMul(int lineNum,int otherLineNum, double scalar)
        {
            if (lineNum < 1 || otherLineNum < 1) return;
            lineNum--; otherLineNum--;
            if (lineNum >= Height || otherLineNum >= Height) return;
            for (int i = 0; i < Width; i++)
                this.Mat[lineNum, i] += this.Mat[otherLineNum, i]*scalar;

        }
        public int GetNotZero(int i)
        {
            // getting the first line that the [i,i] item is not zero
            for(int j = i+1; j<Height; j++) if (this.Mat[j, i] != 0) return j; return -1;
        }
        public void Guass()
        {
            for (int i = 0; i < Height; i++)
            {
                // making sure it's not 0 
                if(i<Width && this.Mat[i,i] == 0) this.ReplaceLines(i + 1, this.GetNotZero(i) + 1);
                if (this.Mat[i, i] != 0) ScalarDivRow(this.Mat[i, i], i);
                // division by the item in location i,i to get 1
                for (int j = 0; j <Height; j++)
                {
                    if (i != j)
                    {
                        AddWithMul(j + 1, i + 1, -this.Mat[j, i]);
                    }
                }
                
            }
            
        }
        public static string CleanSpaces(string equation) => equation.Replace(" ", "");
       
        public static string[] SplitSide(string side)
        {
            side = side.Replace("-","+-");
            return side.Split('+');
        }
       
        public static string[][] SplitEquation(string equation)
        {
            // using SplitSide() for each side of the equation .
            string[] sides = equation.Split('=');
            return new string[][] { SplitSide(sides[0]), SplitSide(sides[1])};
        }
        public static Dictionary<char,double>[] EquationToMatrix(string[] equations)
        {
            for (int i = 0; i < equations.Length; i++) equations[i] = CleanSpaces(equations[i]);
            // assuming it's placed right
            int numOfVariables = 0;
            // determining the number of variables
            Dictionary<char, double> d = new Dictionary<char, double>();
            List<char> vars = new List<char>();
            foreach(string equation in equations)
            {
                foreach(char character in equation)
                {
                    if(Char.IsLetter(character) && !vars.Contains(character))
                    {
                        vars.Add(character);
                        numOfVariables++;
                    }
                }
            }
            //foreach (char variable in vars) Console.WriteLine($"{variable} is a variable");
            Dictionary<char, double>[] data = new Dictionary<char, double>[equations.Length];
            for(int i = 0; i<equations.Length; i++)
            {
                data[i] = new Dictionary<char, double>();
                foreach (char variable in vars) // initializing every dictionary
                {
                    data[i].Add(variable, 0);
                }
                data[i].Add('n', 0);
            }
            if(numOfVariables > equations.Length)
            {
                Console.WriteLine("Equation is not solveable");
                return null;
            }
            else
            {
                for(int i = 0; i<equations.Length; i++) 
                {
                    string[][] arr = SplitEquation(equations[i]);
                   // Program.PrintArray(arr[0]);
                    //Console.WriteLine(arr[0][1] + "is the first " );
                    foreach(string expression in arr[0]) // dealing with the first side
                    {
                        if (expression.Trim() == "") continue;
                        string temp = expression.Trim();
                        if (temp.Length == 1 && char.IsLetter(temp[0]))
                            temp = $"1{temp}";
                        else if (temp.Length == 2 && temp[0] == '-' && char.IsLetter(temp[1]))
                            temp = $"{temp[0]}1{temp[1]}";
                        //Console.WriteLine(temp + " is temp");
                        if (!data[i].ContainsKey(temp[temp.Length - 1]))
                        {
                            //Console.Write($" doesn't have {temp[temp.Length-1]}");
                        }
                        if (Char.IsLetter(temp[temp.Length -1]) && data[i].ContainsKey(temp[temp.Length-1]))
                        {
                            data[i][temp[temp.Length - 1]] += double.Parse(temp.Substring(0,temp.Length-1)); // gets the coefficient
                        }
                        else
                        { 
                            //Console.WriteLine($"trying to convert {temp}");
                            data[i]['n'] += double.Parse(temp.Substring(0,temp.Length));
                        }
                    }
                    foreach (string expression in arr[1]) // dealing with the first side
                    {
                        if (expression.Trim() == "") continue;
                        string temp = expression.Trim();
                        if (temp.Length == 1 && char.IsLetter(temp[0]))
                            temp = $"1{temp}";
                        else if (temp.Length == 2 && temp[0] == '-' && char.IsLetter(temp[1]))
                            temp = $"{temp[0]}1{temp[1]}";
                        //Console.WriteLine(temp + " is temp");
                        if (!data[i].ContainsKey(temp[temp.Length - 1]))
                        {
                            //Console.Write($" doesn't have {temp[temp.Length - 1]}");
                        }
                        if (Char.IsLetter(temp[temp.Length - 1]) && data[i].ContainsKey(temp[temp.Length - 1]))
                        {
                            data[i][temp[temp.Length - 1]] -= double.Parse(temp.Substring(0, temp.Length - 1)); // gets the coefficient
                        }
                        else
                        {
                            //Console.WriteLine($"trying to convert {temp}");
                            data[i]['n'] -= double.Parse(temp.Substring(0, temp.Length));
                        }
                    }
                    data[i]['n'] *= -1;
                }
                return data;

            }
        }
        public static string GetVariables(string[] equations)
        {
            string variables = "";
            foreach (string equation in equations)
                foreach (char character in equation) if (Char.IsLetter(character) && !variables.Contains(character)) variables += character;
            return variables;
        }
        public static string Solve(string[] equations)
        {
            Dictionary<char, double>[] dicts = EquationToMatrix(equations);
            string variables = "";
            string solution = "";
            foreach (char variable in dicts[0].Keys) variables += variable;
            double[,] matrix = MatrixTests.MatrixFromDictionaryArray(dicts);
            Matrix matrixObj = new Matrix(matrix);
            matrixObj.Guass();
            Console.WriteLine(matrixObj);
            for(int i = 0; i<matrixObj.Mat.GetLength(0); i++)
            {
                solution += $"{variables[0]} = {matrixObj.Mat[i, matrixObj.Mat.GetLength(1) - 1]}\n";
                variables = variables.Substring(1, variables.Length - 1);
            }
            return solution;
        }
        public static string[] ReceiveQuery()
        {
            // Receives a system of equations via a file
            using (StreamReader reader = new StreamReader(@"C:\Users\user\Desktop\C#\Matrices\queries.txt"))
            {
                return reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
        }
        public override string ToString()
        {
            string accumulator = "";
            for (int i = 0; i < Height; i++)
            {
                accumulator += "|";
                for(int j = 0; j<Width; j++)
                {
                    accumulator += $" {Mat[i, j]} ";

                }
                accumulator += "| \n";
                
            }
            return accumulator;
        }

    }
}
 