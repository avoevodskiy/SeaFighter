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
            int shipBowX = 0 ,shipBowY = 0, shipLength=4; //координаты носа корабля по X,Y и его длина. Корабль размещается только по горизонтали
            int [,] sea = new int[9,9]; //объявляем массив - симуляция сектора обстрела. Используем int, т.к. у клетки может быть 3 состояния - 0 - пусто,1 - корабль,2 - подбитый корабль
            for (int i = 0; i<= 8; i++) //заполняем массив. 0 - пустота, 1 - размещен корабль. i - идем по x, j-по у
            {
                for (int j = 0; j <= 8; j++) 
                {
                    if ((i == shipBowX) && (j == shipBowY) &&( i<=shipBowX+shipLength))
                    {
                        sea[i, j] = 1;//помечаем сектор моря где установлен корабль
                    }
                    else 
                        sea[i, j] = 0;
                    
                }
            }
            //нанесение удара
            int x, y;
            Console.WriteLine("Веедите координаты удара x,y:");
            x = Int32.Parse(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            if ((x < 0 || x > 8)
                || (y < 0 || y > 8))
            {
                Console.WriteLine("Неверно заданы координаты удара");
            }
            
            else
            {
                Console.WriteLine("Удар нанесен по {0},{1}", x.ToString(), y.ToString());
                //проверка попадания 
                if (sea[x, y] == 1)
                {
                    Console.WriteLine("Есть попадание! Корабль горит адским пламенем! Его команда в панике!");
                }
                else
                {
                    Console.WriteLine("Мимо!");
                }
            }
            
            Console.Read();
        }
    }
}
