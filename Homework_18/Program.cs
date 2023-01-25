class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Enter number of threads:");
        int threadsNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter number of iterations:");
        int iterationsNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("------------------------");

        var tasks = new List<Task>();

        for (int j = 0; j < threadsNumber; j++)
        {
            await Task.Delay(1);
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < iterationsNumber; i++)
                    Console.WriteLine($"Thread id: {Task.CurrentId}," +
                    $" iteration number{i + 1}");

            }));

            tasks[j].Wait();
           
            Console.WriteLine("----------");
        }

        Console.WriteLine("Done");
        Console.WriteLine("------------------------");
        Console.ReadKey();
    }
}
