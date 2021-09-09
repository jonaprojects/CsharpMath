using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promath2._0
{
    class Monomial
    {
        // PRIVATE ATTRIBUTES
        private double _coefficient;
        private Dictionary<string, double> _variables;

        // PROPERTIES
        public double Coefficient
        {
            get { return this._coefficient; }
        }
        public Dictionary<string, double> Variables
        {
            get { return this._variables; }
        }
        // CONSTRUCTORS 
        public Monomial(double coefficient, Dictionary<string, double> variables)
        {
            this._coefficient = coefficient;
            this._variables = variables;
        }
        public Monomial(string expression)
        {
            // anaylze a polynomial from a string 
            throw new NotImplementedException();
        }
        public Monomial(double coefficient) : this(coefficient, null)
        {

        }
        // ADDITIONAL METHODS
        private static bool SameVariables(Dictionary<string, double> d1, Dictionary<string, double> d2)
        {
            // returns true if two dictionaries have the same keys and values, regardless of their order, else, returns false.
            var firstSorted = from pair in d1
                              orderby pair.Key ascending
                              select pair;
            var secondSorted = from pair in d2
                               orderby pair.Key ascending
                               select pair;
            return firstSorted.SequenceEqual(secondSorted);
        }
        public static Monomial operator +(Monomial p1, Monomial p2)
        {
            // override addition operator for two polynomial objects
            if (SameVariables(p1._variables, p2._variables))
            {
                return new Monomial(p1._coefficient + p2._coefficient, new Dictionary<string, double>(p1._variables));
            }
            throw new NotImplementedException();
        }
        public static Monomial operator -(Monomial p1, Monomial p2)
        {
            // override subtraction operator for two polynomial objects

            if (SameVariables(p1._variables, p2._variables))
            {
                return new Monomial(p1._coefficient - p2._coefficient, new Dictionary<string, double>(p1._variables));
            }
            throw new NotImplementedException();
        }
        public static Monomial operator *(Monomial p1, Monomial p2)
        {
            // override multiplication operator for two polynomial objects

            Dictionary<string, double> newVariables = new Dictionary<string, double>();
            double currentPower = 0, finalCoefficient = p1._coefficient * p2._coefficient;
            foreach (KeyValuePair<string, double> pair in p1._variables)
            {
                if (pair.Key == null)
                {
                    finalCoefficient *= pair.Value;
                }
                else
                {
                    currentPower = p1._variables.Where(duo => duo.Key != null && duo.Key == pair.Key).Sum(duo => duo.Value);
                    currentPower += p2._variables.Where(duo => duo.Key != null && duo.Key == pair.Key).Sum(duo => duo.Value);
                    newVariables.Add(pair.Key, currentPower);
                }

            }
            foreach (KeyValuePair<string, double> pair in p2._variables) // the items that were unique to the second dictionary
            {
                if (pair.Key == null)
                    finalCoefficient *= pair.Value;
                else
                {

                    if (!newVariables.Keys.ToList().Contains(pair.Key))
                    {
                        currentPower = p2._variables.Where(duo => duo.Key != null && duo.Key == pair.Key).Sum(duo => duo.Value);
                        newVariables.Add(pair.Key, currentPower);
                    }
                }
            }
            return new Monomial(finalCoefficient, newVariables);
        }
        public static Monomial operator *(Monomial p1, double number)
        {
            // override subtraction operator for a polynomial and a number

            return new Monomial(p1._coefficient * number, new Dictionary<string, double>(p1._variables));
        }
        public static Monomial operator *(double number, Monomial p1)
        {
            // override subtraction operator for a number and a polynomial
            return new Monomial(p1._coefficient * number, new Dictionary<string, double>(p1._variables));
        }
        public static Monomial operator ^(Monomial p1, double number)
        {
            /*
            overrides the bitwise operation '^' as an exponent operator for a polynomial and number
            WARNING: this operator doesn't have precedence in C#.
            For example, 3*x^2 will compute to 9x^2, so you'll need to write (3*x)^2
            */
            Dictionary<string, double> newDictionary = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> pair in p1._variables)
                newDictionary.Add(pair.Key, pair.Value + number);
            return new Monomial(Math.Pow(p1._coefficient, number), newDictionary);
        }
        public static bool operator == (Monomial p1, Monomial p2)
        {
            return p1._coefficient == p2._coefficient && SameVariables(p1._variables, p2._variables);
        }
        public static bool operator != (Monomial p1, Monomial p2)
        {
            return !(p1._coefficient == p2._coefficient) && !(SameVariables(p1._variables, p2._variables));
        }
        public static bool operator == (Monomial p1, double number) => p1._coefficient == number;

        public static bool operator != (Monomial p1, double number) => p1._coefficient != number;

        public static bool operator ==(double number, Monomial p) => p._coefficient == number;

        public static bool operator != (double number, Monomial p) => p._coefficient != number;

        public static Monomial operator - (Monomial p)
        {
            return new Monomial(-p._coefficient, new Dictionary<string, double>(p._variables));
        }
        ~Monomial()
        {
            Console.WriteLine("Destructed a polynomial expression");
        }
        private static string VariablesToString(Dictionary<string,double> dict)
        {
            string accumulator = "";
            foreach(KeyValuePair<string,double> pair in dict)
            {
                accumulator += $"{pair.Key}^{pair.Value} ";
            }
            return accumulator.Trim().Replace(" ", "*");
        }
        public override string ToString()
        {
            string accumulator = "";
            if (this._coefficient == 0) return "0";
            if (this._coefficient == -1)
                accumulator += '-';
            else if (this._coefficient != 1)
                accumulator += $"{this._coefficient}";
            return accumulator + VariablesToString(this._variables);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Var : Monomial
    {
        public Var(string variable)
            : base(coefficient: 1, variables: new Dictionary<string, double> { [variable] = 1 })
        {

        }
    }
    class Polynomial : IEnumerable<Monomial>
    {
        // PRIVATE ATTRIBUTES
        private List<Monomial> _expressions;

        // PROPERTIES

        public List<Monomial> Expressions
        {
            get { return this._expressions; }
        }
        public int NumOfExpressions => this._expressions.Count();
        // CONSTRUCTORS
        public Polynomial(List<Monomial> expressions) => this._expressions = expressions;
        public Polynomial() => this._expressions = new List<Monomial>();
        public Polynomial(Monomial p) => this._expressions = new List<Monomial> { p };

        public IEnumerator<Monomial> GetEnumerator()
        {
            return ((IEnumerable<Monomial>)_expressions).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_expressions).GetEnumerator();
        }
        public Monomial this[int index]
        {
            get { return this._expressions[index]; }
            set { this._expressions[index] = value; }
        }
    }
}
