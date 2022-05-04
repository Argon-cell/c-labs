using System;
using System.Linq;
using System.Collections.Generic;  

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst1 = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine("Изначальный список: " + string.Join(" ",lst1));
            lst1.Add(6);
            Console.WriteLine("Список после добавления: " + string.Join(" ", lst1));
            var lst2 = new List<int>() { 8, 9, 0 };
            Console.WriteLine("Второй список: " + string.Join(" ", lst2));
            lst1.InsertRange(2, lst2);
            Console.WriteLine("Элементы первого списка" + string.Join(" ", lst1));
            Console.WriteLine("Количество элементов: " + lst1.Count);
            Console.WriteLine("Максимальный элемент: " + lst1.Max());
            Console.WriteLine("Минимальный элемент: " + lst1.Min());
            var arr2 = lst2.ToArray();
            Console.WriteLine("Скопированный список: " + string.Join(" ", arr2));
            lst2.RemoveAt(1);
            Console.WriteLine("Список после удаления: " + string.Join(" ", lst2));
        }
    }
}
