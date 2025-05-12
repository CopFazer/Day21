namespace Task5
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 34, 7, 87, 12 };
            int sumLimit = 4000;
            int productLimit = 50000;
            object lockObj = new object();
            bool stopExecution = false;

            Parallel.ForEach(numbers, (n, state) =>
            {
                if (stopExecution)
                {
                    state.Break();
                    return;
                }

                int sum = 0, product = 1;
                for (int i = 0; i <= n; i++)
                {
                    sum += i;
                    product *= (i == 0) ? 1 : i;

                    if (sum > sumLimit || product > productLimit)
                    {
                        lock (lockObj)
                        {
                            stopExecution = true;
                        }
                        state.Break();
                        return;
                    }
                }

                Console.WriteLine($"N = {n}, сумма = {sum}, произведение = {product}");
            });

            Console.WriteLine("Выполнено прерывание!");
        }
    }
}
