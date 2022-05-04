// using System;
 
// namespace Lab1
// {
//     class Program
//     {
//         static void Main()
//         {
//             double a, b, x; 
            
//             try {
//                 Console.WriteLine("Введите значение a: ");
//                 a = Convert.ToDouble(Console.ReadLine());
//                 Console.WriteLine("Введите значение b: ");
//                 b = Convert.ToDouble(Console.ReadLine());
//                 Console.WriteLine("Введите значение x: ");
//                 x = Convert.ToDouble(Console.ReadLine());
//             }
//             catch (System.FormatException) {  
//                 Console.Out.WriteLine("Ошибка ввода");
//             }

//             double z1 = Math.Round(Math.Cos(a) + Math.Sin(a) + Math.Cos(3 * a) + Math.Sin(3 * a), 3);
//             double z2 = Math.Round(1/4 - 1/4 * Math.Sin(5/2 * Math.PI - 8 * a), 3);
 
//             Console.WriteLine("z1 = " + z1);
//             Console.WriteLine("z2 = " + z2);

//             double y = Math.Round(Math.Sqrt(a + b) < x ? a * Math.Pow(x, 2) + b * Math.Log(Math.Abs(2 * x)) : Math.Sqrt(a + Math.Sin(2 * x)), 3);

//             Console.WriteLine("y = " + y);

//         //     int year;

//         //     Console.WriteLine("Введите год: ");
//         //     year = Convert.ToInt32(Console.ReadLine());
            
//         //     switch (year % 12) {
//         //     case 0: 
//         //         Console.WriteLine("Год Обезьяны");
//         //         break;
//         //     case 1: 
//         //         Console.WriteLine("Год Петуха");
//         //         break;
//         //     case 2: 
//         //         Console.WriteLine("Год Собаки");
//         //         break;
//         //     case 3: 
//         //         Console.WriteLine("Год Свиньи");
//         //         break;
//         //     case 4: 
//         //         Console.WriteLine("Год Крысы");
//         //         break;
//         //     case 5: 
//         //         Console.WriteLine("Год Коровы");
//         //         break;
//         //     case 6: 
//         //         Console.WriteLine("Год Тигра");
//         //         break;
//         //     case 7: 
//         //         Console.WriteLine("Год Зайца");
//         //         break;
//         //     case 8: 
//         //         Console.WriteLine("Год Дракона");
//         //         break;
//         //     case 9: 
//         //         Console.WriteLine("Год Змеи");
//         //         break;
//         //     case 10: 
//         //         Console.WriteLine("Год Лошади");
//         //         break;
//         //     case 11: 
//         //         Console.WriteLine("Год Овцы");
//         //         break;
//         //     }
 
//         }
//     }
// }

using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1
{
    class Driver
    {
        public string Surname { get; set; }
        private List<String> Category { get; set; }

        public string this[int index]
        {
            get
            {
                return Category[index];
            }

            set
            {
                Category[index] = value;
            }
        }
        public int Experience { get; set; }
        public Driver(string surname, List<String> category, int experience) { Surname = surname; Category = category; Experience = experience; }
        public override string ToString()
        {
            return "Фамилия: " + Surname + ", Категории: [" + String.Join(", ", Category) + "], Стаж: " + Experience + ", Хеш код: " + GetHashCode();
        }
        public override int GetHashCode()
        {
            return Surname.Length + Category.Count + Convert.ToString(Experience).Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Driver Driver1 = new Driver ("Нафиков" , new List<string> {"A", "B"} , 12 );
            Driver Driver2 = new Driver ("Нафиковth", new List<string> {"C"},1 );
            Driver Driver3 = new Driver ("Нафиковdfgd", new List<string> {"B"},15 );
            Driver Driver4 = new Driver ("Нафиковs", new List<string> {"C"}, 4 );
            Driver Driver5 = new Driver ("Нафиковsdfsfs", new List<string> {"E"}, 8 );
            var list = new List<Driver>() { Driver1, Driver2, Driver3, Driver4, Driver5 };
            
            Console.WriteLine(String.Join("\n", list));
            Console.WriteLine();

            var sorting = from d in list orderby d[0] select d;
            foreach (Driver d in sorting )
                Console.WriteLine("{0} {1} {2} ", d.Surname, d[0], d.Experience);
            Console.WriteLine(); 

            var filtration = from d in list where (d[0] == "E") select d;
            foreach (Driver d in filtration)
                Console.WriteLine("{0} {1} {2}", d.Surname, d[0], d.Experience);
            Console.WriteLine();

        }
    }
}
