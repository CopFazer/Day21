namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите трёхзначное число:");
            int count = int.Parse(Console.ReadLine());
            int sum = 0;

            Task task1 = Task.Run(() => sum = Calculate(count));

            Task task2 = task1.ContinueWith(a =>Console.WriteLine($"Сумма первых двух чисел - {sum}"));

            Task.WaitAll(task1, task2);
        }

        static int Calculate(int count)
        {
            int first = count / 100;
            int second = count / 10 % 10;
            return first+second;
        }
    }
}
