using System;
using System.Collections.Generic;
using System.Linq;

namespace Едгоров_Альберт_ПИ_2_20_Вариант_13
{
    class Product
    {
        public string Name;
        public int Сalories;
        private double _squirrels;
        private double _fats;
        private double _carbohydrates;

        public double Squirrels { 
            get {
                return _squirrels;
            }

            set {   
                if (value >= 0) {  
                    _squirrels = value;
                }
            }
        }
        public double Fats { 
            get {
                return _fats;
            }

            set {   
                if (value >= 0) {  
                    _fats = value;
                }
            }
        }
        public double Carbohydrates {
            get {
                return _carbohydrates;
            }

            set {   
                if (value >= 0) {  
                    _carbohydrates = value;
                }
            }
        }


        public Product (string name, int calories, double squirrels , double fats, double carbohydrates) {
            Name = name;
            Сalories = calories;
            Squirrels = squirrels;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }

        public int сalorieCalculation(int weight) { 
            return Сalories * weight;
        }

        public void information() {
            Console.WriteLine("Название продукта: " + Name + ", Калорийность: " + Сalories + ", Белки: " + Squirrels + ", Жиры: " + Fats + ", Углеводы: " + Carbohydrates);
        }

        public static Product operator +(Product product1, Product product2) {
            return new Product(
                product1.Name + " + " + product2.Name, 
                product1.Сalories + product2.Сalories, 
                product1.Squirrels + product2.Squirrels,
                product1.Fats + product2.Fats,
                product1.Carbohydrates + product2.Carbohydrates
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Гречневая каша", 343, 13, 3.5, 72);
            Product product2 = new Product("Банан", 89, 1.1, 0.3, 23);
            Product product3 = new Product("Яблоко", 52, 0.3, 0.2, 14);
            Product product4 = new Product("Молоко", 42, 3.4, 1, 5);

            product1.information();

            Console.WriteLine();
            
            (product1 + product2).information();

            Console.WriteLine();

            List<Product> breakfast = new List<Product> { product1, product2, product3, product4};
            var sorting = breakfast.OrderBy(product => product.Carbohydrates);
            
            foreach (Product product in sorting) {    
                product.information();
            }



        }
    }
}
