using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Lab12
{

    class Doctor
    {
        public string Surname { get; set; }
        public string Specializtaion { get; set; }
        public int Category { get; set; }
        
        public Doctor(string surname, string specialization, int category) {   
            this.Surname = surname;
            this.Specializtaion = specialization;
            this.Category = category;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var path = "doctors.txt";

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            Doctor[] doctors = new Doctor[15];
            for (int i = 0; i < lines.Length; i++)
            {
                doctors[i] = new Doctor(lines[i].Split()[0], lines[i].Split()[1], Convert.ToInt16(lines[i].Split()[2]));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Врачи офтальмологов и неврологов, 1 категории:");
            Console.ForegroundColor = ConsoleColor.White;
            

            var filtration1 = from d in doctors where (d.Specializtaion == "Невролог" || d.Specializtaion == "Офтальмологов") && d.Category == 1 select d;
            foreach (Doctor d in filtration1)
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);
            
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Самостоятельно все с 1 категории:");
            Console.ForegroundColor = ConsoleColor.White;

            var filtration = from d in doctors where d.Category == 1 select d;
            foreach (Doctor d in filtration)
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);
            
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Фамилия врача, опытный/новичок (стаж меньше 2 лет):");
            Console.ForegroundColor = ConsoleColor.White;

            var proection = from d in doctors select new { Surname = d.Surname, Type = d.Category < 2 ? "Новичок" : "Опытный"};
            foreach (var d in proection)
                Console.WriteLine("{0} - {1}", d.Surname, d.Type);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сортировка фамилии и категории:");
            Console.ForegroundColor = ConsoleColor.White;

            var sorting = from doctor in doctors orderby doctor.Surname, doctor.Category select doctor;
            foreach (Doctor d in sorting)
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Группировка специализации:");
            Console.ForegroundColor = ConsoleColor.White;

            var group = from doctor in doctors group doctor by doctor.Specializtaion;
            foreach (IGrouping<string, Doctor> s in group)
            {
                Console.WriteLine(s.Key);
                foreach (Doctor d in s)
                Console.WriteLine(d.Surname);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Количество врачей хирургов:");
            Console.ForegroundColor = ConsoleColor.White;

            int agregation = (from d in doctors where d.Specializtaion == "Хирург" select d).Count();
            Console.WriteLine(agregation);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Извлечь из списка вторую половину элементов:");
            Console.ForegroundColor = ConsoleColor.White;

            var skip = doctors.Skip(7);
            foreach (Doctor d in skip)
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);

            Console.WriteLine();

            var take = doctors.Take(7);
            foreach (Doctor d in take)
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);

            Console.WriteLine();

            foreach (var d in doctors.SkipWhile(x => x.Surname.EndsWith("в"))) 
            {
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);
            }

            Console.WriteLine();

            foreach (var d in doctors.TakeWhile(x => x.Surname.EndsWith("в")))
                Console.WriteLine("{0} - {1} {2} категории", d.Surname, d.Specializtaion, d.Category);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Имеется хотя бы один хирург:");
            Console.ForegroundColor = ConsoleColor.White;

            bool all = doctors.All(d => d.Specializtaion == "Хирург"); // true
            if (all)
                Console.WriteLine("Все докторы - хирурги");
            else
                Console.WriteLine("Данные доктора не только хирурги");

            Console.WriteLine();
            
            bool any = doctors.Any(d => d.Specializtaion == "Хирург"); //false
            if (any)
                Console.WriteLine("Есть хотя бы один хирург"); 
            else
                Console.WriteLine("Хирургов нет");


        }
    }

}

