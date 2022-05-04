using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine();
            Console.WriteLine(magazine.ToShortString());         
            Console.WriteLine();

            foreach (Frequency element in Enum.GetValues(typeof(Frequency)))
                Console.WriteLine($"{element} = {magazine[element]}");

            magazine.AddArticles(
                new Article(new Person("Евгений", "Попов", new DateTime()), "Плевание в потолок", 2),
                new Article(new Person("Наталья", "Петрова", new DateTime()), "Поедание конфет", 5),
                new Article(new Person("Евгений", "Попов", new DateTime()), "Разбивание черепа врага", 7),
                new Article(new Person("Алекснадр", "Нестеров", new DateTime()), "Сквернословие", 3)
            );

            Console.WriteLine(magazine.ToString());

            int nrow, ncolumn;

            Console.WriteLine("Введите количество рядов и столбцов в качестве разделителя используйте пробел: ");
            String[] input = Console.ReadLine().Split();
            nrow = Convert.ToInt32(input[0]);
            ncolumn = Convert.ToInt32(input[1]);
        
            //Обьявление массивов
            Article[] singleArray = new Article[nrow * ncolumn];
            Article[,] doubleArray = new Article[nrow, ncolumn];
            Article[][] steppedArray = new Article[nrow][];

            for (int i = 0; i < nrow; i++) {    
                steppedArray[i] = new Article[ncolumn];
            }

            //Инициализация массивов
            for (int i = 0; i < nrow * ncolumn; i++) {  
                singleArray[i] = new Article(new Person(), "Тестовое значение для проверки скорости работы", -1);
            }

            for (int i = 0; i < nrow; i++) {
                for (int j = 0; j < ncolumn; j++) {  
                    doubleArray[i, j] = new Article(new Person(), "Тестовое значение для проверки скорости работы", -1);
                }
            }

            for (int i = 0; i < nrow; i++) {
                for (int j = 0; j < ncolumn; j++) {  
                    steppedArray[i][j] = new Article(new Person(), "Тестовое значение для проверки скорости работы", -1);
                }
            }

            //Изменение элементов массива и соотвественно проверка времени
            int before = Environment.TickCount;

            for (int i = 0; i < nrow * ncolumn; i++) {  
                singleArray[i].NameArticle = "Измененное тестовое значение для проверки скорости работы";
            }

            int after = Environment.TickCount;
            Console.WriteLine("После проверки по линейному массиву: {0} мс", after - before);
            before = Environment.TickCount;

            for (int i = 0; i < nrow; i++) {
                for (int j = 0; j < ncolumn; j++) {  
                    doubleArray[i, j].NameArticle = "Измененное тестовое значение для проверки скорости работы";
                }
            }

            after = Environment.TickCount;
            Console.WriteLine("После проверки по двумерному массиву: {0} мс", after - before);
            before = Environment.TickCount;

            for (int i = 0; i < nrow; i++) {
                for (int j = 0; j < ncolumn; j++) {  
                    steppedArray[i][j].NameArticle = "Измененное тестовое значение для проверки скорости работы";
                }
            }

            after = Environment.TickCount;
            Console.WriteLine("После проверки по двумерному ступенчатому массиву: {0} мс", after - before);


        }
    }
 
    class Person
    {
        private string Name;
        private string SurName;
        private System.DateTime BirthdayDate;
 
        public Person(string Name, string SurName, DateTime BirthdayDate) {
            this.Name = Name;
            this.SurName = SurName;
            this.BirthdayDate = BirthdayDate;
        }
 
        public Person() { 
            this.Name = "Без имени";
            this.SurName = "Без фамилии"; 
            this.BirthdayDate = new DateTime();
        }
 
        string personName {
            get {
                return Name;
            }
        }
 
       string personSurName {
            get {
                return SurName;
            }
        }
 
       DateTime PersonBirthdayDate {
            get {
                return BirthdayDate;
            }
         
        }
 
        int intPersonBirthdayDate {
            get {
                return Convert.ToInt32(BirthdayDate); 
            }

            set {
                BirthdayDate = Convert.ToDateTime(value);
            }
        }
 
        public override string ToString() 
        {
            return string.Format("Имя автора: {0}, Фамилия автора: {1}\nДата рождения автора: {2}", Name, SurName, BirthdayDate);
        }
 
        public string ToShortString() 
        {
            return "\n" + "Имя: " + Name + "\n" + "Фамилия: " + SurName;
        }
    }
 
    enum Frequency { Weekly, Monthly, Early }
 
    class Article
    {
        public Person Author { get; set; }
        public string NameArticle { get; set; }
       
        public Double Rating { get; set; }
 
        public Article(Person Author, string Name, double Rating) {
            this.NameArticle = Name;
            this.Author = Author;
            this.Rating = Rating;
        }
 
        private Article() { 
            this.NameArticle = "Без названия";
            this.Author = new Person();
            this.Rating = -1;
        }
 
        public override string ToString() 
        {
            return string.Format("Статья: {0}, Автор: {1}, Рейтингом: {2}", NameArticle, Author, Rating);
        }
    }
 
    class Magazine {
        private string NameJournal;
        private System.DateTime DatePublish;
        private int Number;
        private Frequency PeriodPublish; 
        private List<Article> Articles = new List<Article>();         
        
        public Magazine(string Name, Frequency Period, System.DateTime DatePublish, int Number) {
            this.NameJournal = Name;
            this.PeriodPublish = Period;
            this.DatePublish = DatePublish;
            this.Number = Number;
        }
 
        public Magazine(){ 
            this.NameJournal = "Без названия";
            this.PeriodPublish = new Frequency();
            this.DatePublish = new DateTime();
            this.Number = 0;
        }
        
        public string nameOfJournal {
            get {
                return NameJournal;
            }
        }
 
        public Frequency periodOfPublish {
            get {
                return PeriodPublish;
            }
        }
 
        public System.DateTime dateOfPublish {
            get {
                return DatePublish;
            }
        }
 
        public int numberJournal {
            get {
                return Number;
            }
        }
 
        public IReadOnlyList<Article> articles {
            get {
                return Articles.AsReadOnly();
            }
        }
 
        public double averageRating {
            get {
                double result = 0;
                for (int i = 0; i < Articles.Count - 1; i++) {
                    result += Articles[i].Rating;
                }

                result /= Articles.Count;
                return result;
            }
        }
        public bool this [Frequency index] {
            get {
                return index == periodOfPublish; 
            }           
        }
 
       public void AddArticles (params Article[] args) {
           Articles.AddRange(args);
       }
 
       public override string ToString() {
           return string.Format("\nНазвание журнала: {0}\nДата публикации: {1}\nПериод публикации: {2}\nТираж журнала: {3}\nСтатьи: {4}", NameJournal, DatePublish, PeriodPublish, Number, String.Join(", ", Articles));
       }
 
       public string ToShortString() {
           return string.Format("\nНазвание журнала: {0}\nДата публикации: {1}\nПериод публикации: {2}\nТираж журнала: {3}\nСредний рейтинг статей: {4}", NameJournal, DatePublish, PeriodPublish, Number, averageRating);
       }

    }
    
}