using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = -100; i < 0; i++)
            {
                Console.WriteLine(f91(i));
            }

            Console.ReadLine();
        }

        public static int f91(int x)
        {
            if (x>100)
            {
                return x - 10;
            }

            return f91(f91(x + 11));
        }
    }
}
