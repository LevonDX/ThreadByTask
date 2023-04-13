namespace ThreadByTask
{
    internal class Program
    {
        static long F()
        {
            Console.WriteLine("F started");

            long sum = 0;
            for (long i = 0; i <= 5E9; i++)
            {
                sum += i;
            }

            return sum;
        }

        static void TaskCompleted()
        {
            Console.WriteLine("Task completed");
        }

        static void Main(string[] args)
        {
            MyTask<long> myTask = new MyTask<long>(F);
            myTask.Start();

            MyTaskAwaiter<long> taskAwaiter = myTask.GetAwaiter();

            taskAwaiter.OnCompleted(TaskCompleted);

            Console.WriteLine("Main finished");
            Console.ReadLine();
        }
    }
}