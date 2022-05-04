using System;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static int ReadlnInteger(string s)
        {
            Console.Write(s);
            return int.Parse(Console.ReadLine());
        }
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int[] a = Enumerable.Range(0, n).Select((v, i) => ReadlnInteger($"{i + 1} элемент: ")).ToArray();
            Console.WriteLine($"а) Исходный массив: {String.Join(" ", a)}");
            Console.WriteLine("б) Произведение: " + a.Where((v, i) => i % 2 != 0).Aggregate(1, (x, v) => x * v));
            int nul1 = -1, nul2 = -1;

            for (int i = 0; i < a.Length; i++) if (a[i] == 0) {
                nul1 = i;
                break;
            }

            for (int i = a.Length - 1; i >= 0; i--) if (a[i] == 0 && i != nul1) { 
                nul2 = i; 
                break; 
            }

            Console.WriteLine(nul1 == -1 || nul2 == -1 ? "Нулевые элемент отсутствуют!"
                : $"в) Сумма: {a.Where((v, i) => i > nul1 && i < nul2).Sum()}");
            
            
        }
    }
}

