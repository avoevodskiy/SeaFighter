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
            bool inputCheck,shootCheck=false;//флаги проверок
            int shipBowX = 0 ,shipBowY = 0, shipLength=4; //координаты носа корабля по X,Y и его длина. Корабль размещается только по горизонтали
            int[,] sea = new int[9, 9]; ; //объявляем массив - симуляция сектора обстрела. Используем int, т.к. у клетки может быть 3 состояния - 0 - пусто,1 - корабль,2 - подбитый корабль,3-промахи
            int x, y; //координаты удара
            sea = SeaInit( shipBowX, shipBowY, shipLength);
            SeaDraw(sea);
            while (!shootCheck) 
            {
                inputCheck = CoordInput(out x, out y); //нанесение удара
                if (inputCheck)
                    shootCheck=CheckShoot(x, y, sea);  //проверка попадания
            }


            Console.Read();
        }

        static void SeaDraw(int[,] sea)
        {
         Console.WriteLine("0 - пусто,1 - корабль,2 - подбитый корабль,3 - промахи");
         for (int i = 0; i <= 8; i++)
         {
             for (int j = 0; j <= 8; j++)   
             {
             
                    //Console.Write("|" + sea[i, j].ToString() + "");
                    Console.Write("|"+sea[i, j].ToString()+"");
             }
                Console.WriteLine();
          }


        }

        private static int[,] SeaInit(int shipBowX, int shipBowY, int shipLength)
        {
            int[,]  sea = new int[9, 9];
            for (int i = 0; i <= 8; i++) //заполняем массив. 0 - пустота, 1 - размещен корабль. i - идем по x, j-по у
            {
                for (int j = 0; j <= 8; j++)   
                {
                    if ((i >= shipBowX) && (j == shipBowY) && (i <= shipBowY + shipLength))
                    {
                        sea[j, i] = 1;//помечаем сектор моря где установлен корабль
                    }
                    else
                        sea[j, i] = 0;

                }
            }
            return sea;
        }


        static bool CheckShoot(int x, int y, int[,] sea)
        {
            
                //проверка попадания 
                if (sea[x-1 , y-1] == 1)
                {
                    sea[x - 1, y - 1] = 2;//помечаем часть корабля куда было попадание
                    Console.Clear();//очищаем экран
                    Console.WriteLine("Есть попадание! Корабль горит адским пламенем! Его команда в панике!");
                    SeaDraw(sea);//заново рисуем сектор обстрела
                    return true;
                }
                else
                {
                    sea[x - 1, y - 1] = 3;//помечаем промах
                    Console.Clear();//очищаем экран
                    Console.WriteLine("Мимо!");
                    SeaDraw(sea);//заново рисуем сектор обстрела
                    return false;
                }
            
        }
        static bool CoordInput(out int x, out int y)
        {
            Console.WriteLine("Введите координаты удара x,y:");
            x = Int32.Parse(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            if ((x < 1 || x > 9)
               || (y < 1 || y > 9)) //проверка правильности координат
            {
                Console.WriteLine("Неверно заданы координаты удара");
                return false;
            }
            else
            {
                Console.WriteLine("Удар нанесен по {0},{1}", x.ToString(), y.ToString());
                return true;
            }

        }

    }
}
