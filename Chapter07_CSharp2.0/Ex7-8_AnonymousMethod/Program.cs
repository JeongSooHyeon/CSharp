static void Main(string[] args)
{
    Thread thread = new Thread(
        delegate (object obj)
        {
            Console.WriteLine("ThreadFunc in anonymous method called!");
        });
    thread.Start();
    thread.Join();
}