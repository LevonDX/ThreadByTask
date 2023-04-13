using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadByTask
{
    class MyTask<T>
    {
        Func<T> work;
        public Thread thread;

        public MyTask(Func<T> work)
        {
            this.work = work;
            thread = new Thread(() => { work(); });
            thread.IsBackground = true;
        }

        public void Start()
        {
            thread.Start();
        }

        public MyTaskAwaiter<T> GetAwaiter()
        {
            return new MyTaskAwaiter<T>(this);
        }

    }

    class MyTaskAwaiter<T>
    {
        MyTask<T> task;

        public MyTaskAwaiter(MyTask<T> task)
        {
            this.task = task;
        }

        public void OnCompleted(Action action)
        {
            task.thread.Join();

            action();
        }
    }
}
