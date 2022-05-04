using System;

namespace Lab8 {
    class Program {
        static void Main(string[] args) {

            Set setFirst = new Set();
            setFirst.ShowSet();

            Console.WriteLine();

            Console.Write("Введите число, которое нужно добавить: ");
            int addedNumber = Convert.ToInt32(Console.ReadLine());
            setFirst.Add(addedNumber);
            setFirst.ShowSet();

            Console.WriteLine();

            Console.Write("Введите число, которое нужно найти: ");
            int numberToFind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Индекс элемента: {0}", setFirst.IndexOf(numberToFind));
            
            Console.WriteLine();

            setFirst.ShowSet();
            setFirst++;
            setFirst.ShowSet();

            Console.WriteLine();

            Set setSecond = new Set();
            setSecond.ShowSet();

            Console.WriteLine();

            setFirst.ShowSet();
            setSecond.ShowSet();
            Set setThird = setFirst + setSecond;
            setThird.ShowSet();

            Console.WriteLine();

            setFirst.ShowSet();
            setSecond.ShowSet();
            setThird = setFirst *  setSecond;
            setThird.ShowSet();

            Console.WriteLine();

            setFirst.ShowSet();
            setSecond.ShowSet();
            setThird = setFirst / setSecond;
            setThird.ShowSet();

            Console.WriteLine();

            setFirst.ShowSet();
            setSecond.ShowSet();
            Console.WriteLine("Первое множество меньше чем второе? {0}", setFirst < setSecond);

            Console.WriteLine();

            setFirst.ShowSet();
            setSecond.ShowSet();
            Console.WriteLine("Первое множество больше чем второе? {0}", setFirst > setSecond);
    
            Console.WriteLine();

            Console.Write("Введите индекс числа первого множества, которого вы хотите увидеть/изменить: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Число: {0}", setFirst[number]);

        }

    }

    public class Set {
        public int[] Elements;
        public int count;
        public int Count {
            get {
                return count;
            }

            set {   
                count = value;
                Array.Resize<int>(ref Elements, count);
            }

        }

        public Set() {
            Console.Write("Введите количество элементов множества: ");

            Count = Int32.Parse(Console.ReadLine());
            Elements = new int[Count];

            Console.WriteLine();
            Fill();

        }

        public Set(int[] array) {
            Elements = new int[array.Length];
            Array.Copy(array, Elements, array.Length);

        }

        public void Fill() {
            for (int i = 0; i < count; i++) {
                Console.Write($"Введите значение элемента №{i + 1}: ");
                Elements[i] = Int32.Parse(Console.ReadLine());

            }

        }

        public void ShowSet() {
            Console.WriteLine("Множество: [{0}]", string.Join(", ", Elements));
        }

        public void Add(int newElement) {
            Array.Resize<int>(ref Elements, Elements.Length + 1);
            Elements[Elements.Length - 1] = newElement;
            Count = Elements.Length;

        }

        public int IndexOf(int value) {
            int tempIndex = 0;

            for (int i = 0; i < Count; i++) {
                if (Elements[i].Equals(value)) {
                    tempIndex = i;
                    break;

                } else {
                    tempIndex = -1;

                }
            }
            return tempIndex;

        }

        public static Set operator ++(Set set) {
            for (int i = 0; i < set.Elements.Length; i++) {
                set.Elements[i]++;
            }

            return set;
        }

        public static Set operator +(Set set1, Set set2) {
            Set tempSet = new Set(new int[0]);
            int i = 0, j = 0;

            while ((i < set1.Elements.Length) && (j < set2.Elements.Length)) {

                if (set1.Elements[i] < set2.Elements[j]) {
                    tempSet.Add(set1.Elements[i++]);

                } else if (set2.Elements[j] < set1.Elements[i]) {
                    tempSet.Add(set2.Elements[j++]);
                
                } else {
                    tempSet.Add(set1.Elements[i++]);
                    ++j;
                }

            }

            while (i < set1.Elements.Length) {
                tempSet.Add(set1.Elements[i++]);

            }

            while (j < set2.Elements.Length) {
                tempSet.Add(set2.Elements[j++]);

            }

            return tempSet;
        }

        public static Set operator *(Set set1, Set set2) {
            Set tempSet = new Set(new int[0]);
            int d = 0;

            for (int i = 0; i < set1.Elements.Length; i++) {
                int j = 0, k = 0;

                while (j < set2.Elements.Length && set2.Elements[j] != set1.Elements[i]) {
                    j++;

                }

                while (k < d && tempSet[k] != set1.Elements[i]) {
                    k++;

                }

                if (j != set2.Elements.Length && k == d) {
                    tempSet.Add(set1.Elements[i]);

                }

            }
            return tempSet;

        }

        public static Set operator /(Set set1, Set set2) {
            Set tempSet = new Set(new int[0]);

            for (int i = 0; i < set1.Elements.Length; i++) {
                int j = 0;

                while (j < set2.Elements.Length && set2.Elements[j] != set1.Elements[i]) {
                    j++;

                }

                if (j == set2.Elements.Length) {
                    tempSet.Add(set1.Elements[i]);

                }
            }
            return tempSet;

        }

        public static bool operator <(Set set1, Set set2) {
            if (set1.Elements.Length < set2.Elements.Length) {
                return true;

            } else {
                return false;

            }

        }

        public static bool operator >(Set set1, Set set2) {
            if (set1.Elements.Length > set2.Elements.Length) {
                return true;

            } else {
                return false;

            }

        }

        public int this[int index] {
            get{
                return Elements[index];

            }

            set {
                Elements[index] = value;
                
            }

        }
    }
}