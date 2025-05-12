namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число а:");
            double a = double.Parse(Console.ReadLine());

            Task[] tasks = new Task[2];

            tasks[0] = Task.Run(() =>
            {
                Console.WriteLine("\nЗадача 1 начала выполнение.");
                double result1 = ComputeFunction1(a);
                Console.WriteLine($"Задача 1 завершена. Результат: {Math.Round(result1,3)}");
            });

            tasks[1] = Task.Run(() =>
            {
                Console.WriteLine("Задача 2 начала выполнение.");
                Thread.Sleep(3000);
                double result2 = ComputeFunction2(a);
                Console.WriteLine($"Задача 2 завершена. Результат: {Math.Round(result2,3)}");
            });

            Task.WaitAny(tasks);
            Console.WriteLine("Хотя бы одна задача завершилась!");

            Task.WaitAll(tasks);
            Console.WriteLine("Все задачи завершены!");
        }

        static double ComputeFunction1(double a)
        {
            return Math.Sin(2 * a)+Math.Sin(5*a) - Math.Sin(3*a)/(Math.Cos(a)+1-2*Math.Pow(Math.Sin(2*a),2));
        }

        static double ComputeFunction2(double a)
        {
            return 2*Math.Sin(a); 
        }
    }
}
