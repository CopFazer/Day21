using System;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введи четырёхзначное число: ");
            int numbers = int.Parse(Console.ReadLine());

            Task task1 = new Task(() => Calculate(numbers));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Calculate(numbers));

            Task task3 = Task.Run(() => Calculate(numbers));

            Task.WaitAll(task1, task2, task3);

        }

        static void Calculate(int numbers)
        {
            string first = Convert.ToString(numbers / 1000);
            string second = Convert.ToString(numbers / 100 % 10);
            string third = Convert.ToString(numbers % 100);
            int c = int.Parse(second+first+third);
            Console.WriteLine(c);
        }
    }
}
