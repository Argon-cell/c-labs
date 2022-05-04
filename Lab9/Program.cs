using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public interface IRateAndCopy { 
        double Rating { get; }
        object DeepCopy();
    }

    class Program {
        static void Main(string[] args)
        {
            Edition edition1 = new Edition();
            Edition edition2 = new Edition();
            Console.WriteLine(edition1 == edition2);  
            Console.WriteLine(edition1.Equals(edition2));         
            Console.WriteLine("hash1: {0}, hash2: {1}", edition1.GetHashCode(), edition2.GetHashCode());
            Console.WriteLine();

            try {
                edition1.circulation = 0;
            }
            catch (Exception error) {
                Console.WriteLine(error);
            }
            Console.WriteLine();

            Magazine magazine = new Magazine();
            magazine.addArticles(new Article(new Person(), "Золушка", 2));
            magazine.addArticles(new Article(new Person(), "Колобок", 3));
            magazine.AddPersons(new Person("Ильгам", "Нафиков", new DateTime()));
            magazine.AddPersons(new Person("Олег", "Матвеев", new DateTime()));
            Console.WriteLine(magazine.ToString());

            Console.WriteLine(magazine.ToShortString());
            Magazine magazineCopy = (Magazine)magazine.DeepCopy();
            magazine.numberJournal = 4;
            Console.WriteLine(magazineCopy.ToShortString());
            Console.WriteLine();

            foreach (Article art in magazine.ArticlesWithUpperThanRating(1))
            {
                Console.WriteLine(art);
            }
            Console.WriteLine();

            foreach (Article pers in magazine.ArticlesContainsString("Зол")) {
                Console.WriteLine(pers);
            }
        }
    }
 
    class Person {
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
            return string.Format("{0} {1}\nДата рождения: {2}", Name, SurName, BirthdayDate);
        }
 
        public string ToShortString() 
        {
            return "\n" + "Имя: " + Name + "\n" + "Фамилия: " + SurName;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            
            Person objPers = obj as Person;
            if (obj as Person == null) {
                return false;
            }
            
            return objPers.Name == Name && objPers.SurName == SurName && objPers.BirthdayDate == BirthdayDate;
        }

        public override int GetHashCode() {
            int hashcode = 0;
            char[] NameChar = Name.ToCharArray();

            foreach (char ch in NameChar) {
                hashcode += Convert.ToInt32(ch);
            }
            char[] SurnameChar = SurName.ToCharArray();
            foreach (char ch in SurnameChar) {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += BirthdayDate.Year * BirthdayDate.Month;
            return hashcode;
        }

        public static bool operator ==(Person lpers, Person rpers) {
            if (ReferenceEquals(lpers, rpers)) {
                return true;
            }
            if ((object)lpers == null || (object)rpers == null) {
                return false;
            }
            
            return lpers.Name == rpers.Name && lpers.BirthdayDate == rpers.BirthdayDate && lpers.SurName == rpers.SurName;
        }
        
        public static bool operator !=(Person lpers, Person rpers) {
            return !(lpers == rpers);
        }
        
        public virtual object DeepCopy() {
            Person persCopy = new Person(this.Name, this.SurName, this.BirthdayDate);
            return persCopy;
        }

    }
 
    enum Frequency { 
        Weekly, 
        Monthly, 
        Early 
    }
 
    class Article: IRateAndCopy {
        public Person Author { get; set; }
        public string NameArticle { get; set; }

        public double Rating { get; set; }
 
        public Article(Person Author, string Name, double Rating) {
            this.NameArticle = Name;
            this.Author = Author;
            this.Rating = Rating;
        }
 
        public Article() { 
            this.NameArticle = "Без названия";
            this.Author = new Person();
            this.Rating = -1;
        }
 
        public override string ToString() 
        {
            return string.Format("Автор {1} написал статью {0} под номером {2}", NameArticle, Author, Rating);
        }
    
        public virtual object DeepCopy() {
            return new Article(this.Author, this.NameArticle, this.Rating);
        }

        string IRateAndCopy {
            get {   
                return string.Format("Рейтинг статьи: {0}", Rating);
            }
        }
    }
 
    class Magazine: IRateAndCopy {
        private string NameJournal;
        private Frequency PeriodPublish; 
        private System.DateTime DatePublish;
        private int Number;
        private List<Article> Articles = new List<Article>();    
        private List<Person> Persons = new List<Person>();         
        
        public double Rating {get; set;}
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
        
        public IReadOnlyList<Article> articles {
            get {
                return Articles.AsReadOnly();
            }
        }

        public IReadOnlyList<Person> persons {
            get {
                return Persons.AsReadOnly();
            }
        }

        public void addArticles (params Article[] args) {
           Articles.AddRange(args);
       }

        public void AddPersons (params Person[] args) {
           Persons.AddRange(args);
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

            set {
                Number = value;
            }
        }
 
        public bool this [Frequency index] {
            get {
                return index == periodOfPublish; 
            }           
        }
        
        public virtual new string ToString() {
           return string.Format("\nНазвание журнала: {0}\nДата публикации: {1}\nПериод публикации: {2}\nТираж журнала: {3}\nСтатьи: [{4}]\nАвторы: [{5}]", NameJournal, DatePublish, PeriodPublish, Number, String.Join(", ", Articles), String.Join(", ", Persons));
       }
     
        public string ToShortString() {
           return string.Format("\nНазвание журнала: {0}\nДата публикации: {1}\nПериод публикации: {2}\nТираж журнала: {3}\nСредний рейтинг статей: {4}", NameJournal, DatePublish, PeriodPublish, Number, averageRating);
       }

        public virtual object DeepCopy() {
            return new Magazine(this.NameJournal, this.PeriodPublish, this.DatePublish, this.Number);
        }

        string IRateAndCopy {
            get {   
                return string.Format("Рейтинг журнала: {0}", averageRating);
            }
        }


        public IEnumerable<Article> ArticlesWithUpperThanRating(int number) {
            for (int i = 0; i < articles.Count; i++) {
                if (((Article)articles[i]).Rating > number) {
                    yield return (Article)articles[i];
                    
                }
            }
        }

        public IEnumerable<Article> ArticlesContainsString(string text) {
            for (int i = 0; i < articles.Count; i++) {
                if ((((Article)articles[i]).NameArticle).Contains(text)) {
                    yield return (Article)articles[i];
                }
            }
        }    
    }
    
    class Edition {
        protected string Name;
        protected DateTime DatePublish;
        protected int Circulation;

        public Edition(string NameEdition, DateTime DatePublcation, int Circulation) {
            this.Name = NameEdition;
            this.DatePublish = DatePublcation;
            this.Circulation = Circulation;
        }

        public Edition() {
            this.Name = "Без названия";
            this.DatePublish = new DateTime();
            this.Circulation = 1;
        }

        public virtual object DeepCopy() {
            return new Edition(this.Name, this.DatePublish, this.Circulation);
        }

        public virtual new bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            
            Edition objAsEdition = obj as Edition;
            
            if (objAsEdition as Edition == null) {
                return false;
            }

            return objAsEdition.Name == this.Name && objAsEdition.DatePublish == this.DatePublish && objAsEdition.Circulation == this.Circulation;
        }
        static public bool operator == (Edition l_Edition,Edition r_Edition) {
            if (ReferenceEquals(l_Edition, r_Edition)) {
                return true;
            } else {
                return false;
            }

        }

        public int circulation {
            get { 
                return Circulation; 
            }

            set {
                if (value <= 0) {
                    throw new ArgumentOutOfRangeException(paramName: nameof(Circulation), message: "Тираж журнала должен быть больше 0");
                }
                else {
                    Circulation = value;
                }
            }
        }

        static public bool operator !=(Edition l_Edition, Edition r_Edition) {
            return !(l_Edition == r_Edition);
        }

        public virtual new int GetHashCode() {
            int HashCode = 0;

            foreach (char ch in Name.ToCharArray()) {
                HashCode += (int) Convert.ToUInt32(ch);
            }
            
            HashCode += Circulation;
            return HashCode;
        }

        public virtual new string ToString() {
            return string.Format("Название издания: {0}, Дата публикации: {1}, Номер тиража: {2}", Name, DatePublish, Circulation);
        }
    }

}