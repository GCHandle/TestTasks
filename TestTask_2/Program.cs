namespace TestTask_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void WriteCount()
            {
                while (true)
                    Console.WriteLine(Server.GetCount());   //4 + 4 + 4 + 6 + 6 + 6 = 30
            }

            Console.WriteLine("Это программа, создающая некоторое количество задач, имитирующих подключение к классу Server");
            Console.WriteLine("На сервер всегда записывается число 30");
            Console.WriteLine("Данный код не требуется, он добавлен для наглядности. Нажмите любую кнопку чтобы продолжить.");
            Console.ReadKey();
            var tasks = new Task[10];
            tasks[0] = new Task(delegate { Server.AddToCount(4); });
            tasks[1] = new Task(delegate { Server.AddToCount(4); });
            tasks[3] = new Task(delegate { Server.AddToCount(4); });
            tasks[4] = new Task(delegate { Server.GetCount(); });
            tasks[5] = new Task(delegate { Server.GetCount(); });
            tasks[6] = new Task(delegate { Server.GetCount(); });
            tasks[7] = new Task(delegate { Server.GetCount(); });
            tasks[8] = new Task(delegate { Server.AddToCount(6); });
            tasks[9] = new Task(delegate { Server.AddToCount(6); });
            tasks[2] = new Task(delegate { Server.AddToCount(6); });
            var thread = new Thread(new ThreadStart(WriteCount)) { IsBackground = true };
            thread.Start();
            Thread.Sleep(1000);
            Array.ForEach(tasks, x => x.Start());
            Task.WaitAll();
            Thread.Sleep(1000);
        }
    }
}
