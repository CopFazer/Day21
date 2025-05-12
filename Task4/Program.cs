namespace Task4
{
    class Program
    {
        static void Main()
        {
            Parallel.For(-1, 10, a =>
            {
                double result = Math.Cos(1.0 / a);
                Console.WriteLine($"x = {a}, cos(1/x) = {result:F3}");
            });
        }
    }
}
