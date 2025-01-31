using Day4;

task1 account = new task1(1000);
Thread[] threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        account.Deposit(500);
        account.Withdraw(300);
    });
    threads[i].Name = $"Thread-{i + 1}";
}

foreach (var thread in threads)
    thread.Start();

foreach (var thread in threads)
    thread.Join();

Console.WriteLine($"Final Account Balance: {account.GetBalance()}");
