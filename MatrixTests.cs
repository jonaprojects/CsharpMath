using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Matrices
{

    class MatrixTests
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine(Matrix.Solve(new string[] { " x + y = 10 ", " x - y = 6 " }));
            Console.WriteLine(); 
            string[] equations = { "x+y+z=3", "2x + 5y-8z = 5x+2y+7", "3x+6y-8z = 5+4z+3x-y+6" }; 
            string solutions = Matrix.Solve(equations);
            Console.WriteLine(solutions);
        }
        public static void PrintArray<T>(T[] arr)
        {
            foreach (T value in arr) Console.WriteLine(value);
            Console.WriteLine();
        }
        public static void PrintDictionary(Dictionary<char, double> dict)
        {
            foreach (KeyValuePair<char, double> duo in dict)
                Console.Write($"{duo.Key}:{duo.Value} ");
        }
        public static void PrintArrayOfDictionaries(Dictionary<char, double>[] dicts)
        {
            foreach (Dictionary<char, double> dict in dicts)
            {
                Console.Write("|");
                PrintDictionary(dict);
                Console.Write("|");
            }
        }
        public static double[,] MatrixFromDictionaryArray(Dictionary<char,double>[] dictArr)
        {
            double[,] matrix = new double[dictArr.Length,dictArr[0].Keys.Count];
            double[] values;
            for(int i = 0; i<matrix.GetLength(0); i++)
            {
                values = dictArr[i].Values.ToArray();
                for(int j = 0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }              
            return matrix;
        }
        

    }
}
