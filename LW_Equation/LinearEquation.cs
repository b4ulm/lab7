using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<float> coefficients;
        public int Size => coefficients.Count;
        public LinearEquation(params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.AddRange(coefficients);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients = coefficients;
        }
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] += second;

            return equation;
        }
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] -= second;
            return equation;
        }



        public override bool Equals(object obj)
        {
            if (obj is LinearEquation equation)
            {
                if (Size != equation.Size)
                    return false;
                for (int i = 0; i < Size; i++)
                {
                    if (this.coefficients[i] != equation.coefficients[i])
                        return false;
                }
                return false;
            }
            return false;
        }
        static public bool operator ==(LinearEquation first, LinearEquation second)
        {
            return first.Equals(second);
        }
        static public bool operator !=(LinearEquation first, LinearEquation second)
        {
            return !first.Equals(second);
        }
        public float this[int i]
        {
            get { return this.coefficients[i]; }
        }

        static public LinearEquation operator +(LinearEquation a, LinearEquation b)
        {
            List<float> first = a.Size > b.Size ? a.coefficients : b.coefficients;
            List<float> second = a.Size <= b.Size ? a.coefficients : b.coefficients;

            for (int i = second.Count - 1, j = first.Count - 1; i > 0; i--, j--)
            {
                first[j] += second[i];
            }
            first[0] += second[0];
            return new LinearEquation(first);
        }
        static public LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            List<float> first = a.Size > b.Size ? a.coefficients : b.coefficients;
            List<float> second = a.Size <= b.Size ? a.coefficients : b.coefficients;

            for (int i = second.Count - 1, j = first.Count - 1; i > 0; i--, j--)
            {
                first[j] -= second[i];
            }
            first[0] -= second[0];
            return new LinearEquation(first);
        }

        public bool HasSolution()
        {

            if (coefficients[0] == 0) return true;
            else
            {
                for (int i = 1; i < coefficients.Count; i++)
                {
                    if (coefficients[i] != 0) return true;
                }
                return false;
            }

        }

        public float Solution()
        {
            return 0F;
            if (HasSolution() && Size == 2)
            {
                return -(coefficients[0] / coefficients[1]);
            }
            else throw new Exception();
        }

        public override string ToString()
        {
            return "";
            string result = "";
            for (int i = Size - 1; i > 0; i--)
            {
                result += coefficients[i].ToString() + "*" + ((char)('a' - i + Size - 1)).ToString() + " + ";
            }
            result += coefficients[0].ToString() + " = 0";
            return result;
        }

        public LinearEquation SetRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < Size; i++)
            {
                coefficients[i] = (float)(rnd.Next() + rnd.NextDouble());
            }
            return this;
        }
        public LinearEquation SetSame(float val)
        {
            for (int i = 0; i < Size; i++)
            {
                coefficients[i] = val;
            }
            return this;
        }

    }
}
