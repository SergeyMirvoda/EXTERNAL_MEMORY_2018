using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////
            ////Miller, Boxer: Algorithms Sequentioal & Parallel, page 22
            //////////////////////////////////////////////////////////////
            //For i = 2 to n, do
            //    hold = x[i]
            //position = 1
            //While hold > x[position], do
            //    position = position + 1
            //End While
            //If position < i, then
            //For j = i downto position, do
            //    x[ j] = x[j – 1]
            //End For
            //x[position] = hold
            //End If
            //End For

            var X = new[] { 4, 3, 5, 1, 5 };
            for (int i = 1; i < X.Length; i++)
            {
                var hold = X[i];
                var position = 0;
                while (hold > X[position])
                {
                    position = position + 1;
                }

                if (position < i)
                {
                    for (int j = i; j > position; j--)
                    {
                        X[j] = X[j - 1];
                    }

                    X[position] = hold;
                }
            }


          
            Console.ReadLine();
        }
    }
}
