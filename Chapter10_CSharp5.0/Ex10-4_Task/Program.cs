using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // 기존의 QueueUserWorkItem으로 별도의 스레드에서 작업을 수행
        ThreadPool.QueueUserWorkItem(
            (obj) =>
            {
                Console.WriteLine("process workitem");
            }, null);

        // .NET 4.0의 Task 타입을 이요해 별도의 스레드에서 작업을 수행
        Task task1 = new Task(
            () =>
            {
                Console.WriteLine("process taskitem");
            });

        task1.Start();

        Task task2 = new Task(
            (obj) =>
            {
                Console.WriteLine("process taskitem(obj)");
            }, null);

        task2.Start();

        Console.ReadLine();


        Task taskSleep = new Task(() => { Thread.Sleep(5000); });
        taskSleep.Start();
        taskSleep.Wait();   // Task의 작업이 완료될 때까지 현재 스레드를 대기


        // Task 객체 생성하지 않고 곧바로 작업 시작
        Task.Factory.StartNew(
            () => { Console.WriteLine("process taskitem"); });
        Task.Factory.StartNew(
            (obj) => { Console.WriteLine("process taskitem(obj)"); }, null);


        // Task<TResult>
        Task<int> task = new Task<int>( 
            () =>
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                return rand.Next();
            }
        );
        task.Start();
        task.Wait();
        Console.WriteLine("무작위 숫자 값 : " + task.Result);

        Task<int> taskReturn = Task.Factory.StartNew<int>(() => 1);
        taskReturn.Wait();
        Console.WriteLine(taskReturn.Result);
    }
}