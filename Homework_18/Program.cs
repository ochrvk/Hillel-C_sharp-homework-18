﻿class Program
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
            //Please notice the next comment
            tasks[j].Wait();

            Console.WriteLine("----------");
        }

        //If threads need to be calculated parallel, "tasks[j].Wait();" should be removed from the loop and the next loop should be added:
        /*
            foreach (var item in tasks)
            {
                item.Wait();
            }
        */

        Console.WriteLine("Done");
        Console.WriteLine("------------------------");
        Console.ReadKey();
    }
}
