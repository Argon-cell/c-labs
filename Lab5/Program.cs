using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello my name is Ilgam and this is my simple text";
            int K = 0;
            string[] raw = text.Split();
            
            for (int i = 0; i < raw.Length; i++){
                if (raw[i].Length > 20)
                {
                    Console.WriteLine("Не соответствует условию, слова не должны содержать 20 символам");
                    break;
                }

                if (K <= raw[i].Length)
                {
                    K = raw[i].Length;
                }
            }

            char[] additionalString = text.ToArray();
            for (int i = 0; i < additionalString.Length; i++) {
                
                if ((int)additionalString[i] == 32) {
                    additionalString[i] = (char)(additionalString[i]);
                }
                
                else if ((int)additionalString[i] == 46) {
                    additionalString[i] = (char)(additionalString[i] + K);
                }

                else if ((int)additionalString[i] == 44) {
                    additionalString[i] = (char)(additionalString[i] + K);
                }

                else if (((90 < (int)additionalString[i]) & (97 > (int)additionalString[i])) | ((122 - K) < (int)additionalString[i])) {
                    additionalString[i] = (char)(additionalString[i] + 26);
                }
                
                else {  
                    additionalString[i] = (char)(additionalString[i] + K);
                }
 
            }
        
            Console.WriteLine(additionalString);
            Console.WriteLine("Число К: " + K);
            Console.ReadKey();

        }
    }
}
