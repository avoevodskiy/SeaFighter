using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFighter
{
    class Program
    {
        static void Main(string[] args)
        {

            int x, y;
            Console.WriteLine("Веедите координаты удара x,y:");
            x = Int32.Parse(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            if ((x < 1 || x > 9)
                || (y < 1 || y > 9))
            {
                Console.WriteLine("Неверно заданы координаты удара");
            }
            
            else
            {
                Console.WriteLine("Удар нанесен по {0},{1}", x.ToString(), y.ToString());
            }

            Console.Read();
        }
    }
}
