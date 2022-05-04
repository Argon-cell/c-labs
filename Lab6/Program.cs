// using System;
// using System.Linq;
// using System.IO;

// namespace Lab6
// {
//     static class FindinStrings{    
//         public static bool FirtsVowel(this string s) {
//                 if (s[0] == 'a' || s[0] == 'A' || s[0] == 'e' || s[0] == 'E' || s[0] == 'i' || s[0] == 'I' || 
//                 s[0] == 'o' || s[0] == 'O' || s[0] == 'u' || s[0] == 'U' || s[0] == 'y' || s[0] == 'Y') return true;
 
//         else return false;
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             TextReader t = File.OpenText(@"file.txt");
//             string str = t.ReadToEnd();
//             var res = from s in str.Split(' ')
//                     where s.FirtsVowel()
//                     select s;
//             foreach (var i in res) Console.WriteLine(i);
//         }

//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab6
{
    class Program
    {
        static string pathread = "peoplesFile.txt";
        static string pathwrite = "peoplesWithOneSurnameFile.txt";
 
        static string[] linesR;
        static List<string> output = new List<string>();
        static int maxAge = 0;


        static void Main(string[] args) {
            linesR = new string[File.ReadAllLines(pathread).Length];
            linesR = File.ReadAllLines(pathread, Encoding.Default);
            for (int i = 0; i < linesR.Length; i++) {
                Console.WriteLine(linesR[i]);
                for (int j = linesR.Length - 1; j > i; j--) { 
                    
                    Console.Write(linesR[j]);
                    if (linesR[i].Split()[0].Substring(linesR[i].Split()[0].Length - 1, 1) == "a") { 
                        if (linesR[i].Split()[0].Substring(0, linesR[i].Split()[0].Length - 1) == linesR[j].Split()[0]) {
                            output.Add(linesR[i].Split()[1] + " " + linesR[i].Split()[2]);
                            output.Add(linesR[j].Split()[1] + " " + linesR[j].Split()[2]);
                            output.Add(" ");
                        }
                    } else if (linesR[j].Split()[0].Substring(linesR[j].Split()[0].Length - 1, 1) == "a") {  
                        if (linesR[j].Split()[0].Substring(0, linesR[j].Split()[0].Length - 1) == linesR[i].Split()[0]) {
                            output.Add(linesR[i].Split()[1] + " " + linesR[i].Split()[2]);
                            output.Add(linesR[j].Split()[1] + " " + linesR[j].Split()[2]);
                            output.Add(" ");
                        }
                    
                    } else {

                        if (linesR[j].Split()[0] == linesR[i].Split()[0]) {
                            output.Add(linesR[i].Split()[1] + " " + linesR[i].Split()[2]);
                            output.Add(linesR[j].Split()[1] + " " + linesR[j].Split()[2]);
                            output.Add(" ");
                        }
                    }

                }
                
                if (Convert.ToInt32(linesR[i].Split()[3]) > maxAge) {   
                        maxAge = Convert.ToInt32(linesR[i].Split()[3]);
                }
            }

            output.Add(Convert.ToString(maxAge));
            File.WriteAllLines(pathwrite, output, Encoding.Default);
        }
    }
}