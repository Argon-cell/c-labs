using System;

namespace Lab2
{
    class Program
    {
        // static double f(double x) {
        //     double r = 3;
        //     double y = 0;
 
        //     if (x < -6.0)
        //         y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x + 6, 2)) * -1;
 
        //     if (x >= -6.0 && x <= -3)
        //         y = x + 3; 
 
        //     if (x > -3 && x <= 0)
        //         y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x, 2));
 
        //     if (x > 0 && x <= 3)
        //         y = -x + 3;
 
        //     if (x > 3 && x <= 9)
        //         y = (0.5 * x) - 1.5;
 
        //     return y;
        // }
        static void Main() {
            // double xn = -9;
            // double xk = 9;
            // double dx = 1;
            // for (double x = xn; x < xk + 0.1; x += dx) {
            //   Console.WriteLine("x = {0:F2}, y = {1:F2} ", x, f(x));
            // }
            //  Console.ReadKey();

            for (int x = 10; x < 100; x += 1) {
                int summStart = x % 10 + x / 10;
                int summEnd = (x * 2) % 10 + (x * 2) / 10;

                if (summStart == summEnd) { 
                    Console.WriteLine(x);
                }

            } 
         }        
    }
 }

