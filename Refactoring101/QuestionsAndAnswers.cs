using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101
{
    // Do Refactoring the following code:
    public class QuestionsAndAnswers
    {
        // 1. Mysterious Name
        public double FindMaximum(double a, double b)
        {
            return a > b ? a : b;
        }

        // 2. Duplicate Code
        public void Print()
        {
            string name = "Mr.Harry Potter";
            
            PrintName(name);
            PrintName(name);
            PrintName(name);

            /*Console.WriteLine("***********************");
            Console.WriteLine("   Mr.Harry Potter");
            Console.WriteLine("***********************");
            Console.WriteLine();

            Console.WriteLine("***********************");
            Console.WriteLine("   Ms.Mary Poppin");
            Console.WriteLine("***********************");
            Console.WriteLine();

            Console.WriteLine("***********************");
            Console.WriteLine("   Mr.Johny Black");
            Console.WriteLine("***********************");
            Console.WriteLine();
            */
        }

        public void PrintName(string name)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("   " + name);
            Console.WriteLine("***********************");
            Console.WriteLine();
        }

        // 3. Shotgun Surgery
        public class Constant
        {
            public const double StudentCount = 48;
        }

        public class Shotgun1
        {
            public void DisplayStudents()
            {
                Console.WriteLine("Student Count = " + Constant.StudentCount);
            }
        }
        public class Shotgun2
        {
            public void PrintTotal()
            {
                Console.WriteLine("Total Students : " + Constant.StudentCount);
            }
        }

        // 4. Data Clump
        public void PrintDate(Date date)
        {
            //Console.WriteLine($"{day:00}/{month:00}/{year:0000}");
            date.Format();
        }

        public class Date
        {
            public required int Day { get; set; }
            public required int Month { get; set; }
            public required int Year { get; set; }

            // ข้อ 5
            public void Format()
            {
                Console.WriteLine($"{Day:00}/{Month:00}/{Year:0000}");
            }
        }

        // 5. Feature Envy
        //    จากข้อที่แล้ว น่าจะได้สร้างคลาส Date ขึ้นมา
        //    ในคลาส Date นั้นให้สร้าง method: public string Format()
        //    ปรับให้ PrintDate(...) ของเดิม ไปเรียก date.Format() ดังกล่าว
    }   
}
