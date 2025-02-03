# Bank Account Simulation with Thread Safety

## Overview
This project demonstrates a **thread-safe** implementation of a bank account in **C#**. Multiple threads can concurrently **deposit** and **withdraw** money while ensuring the account balance remains consistent and protected from race conditions using `lock`.

## Features
- Thread-safe **Deposit** and **Withdraw** operations.
- Uses **lock** to prevent race conditions.
- Demonstrates multithreading with `Thread` class.
- Final balance calculation after concurrent transactions.

## Requirements
- .NET Framework or .NET Core installed
- C# compiler

## Usage
1. Compile and run the **C# program**.
2. The program initializes an account with **1000** balance.
3. Five threads perform **deposit (500)** and **withdraw (300)** operations concurrently.
4. The final balance is displayed after all transactions are completed.

## Code
```csharp
using System;
using System.Threading;

class BankAccount
{
    private int balance;
    private readonly object balanceLock = new object();

    public BankAccount(int initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(int amount)
    {
        lock (balanceLock)
        {
            balance += amount;
            Console.WriteLine($"{Thread.CurrentThread.Name} deposited {amount}. New balance: {balance}");
        }
    }

    public void Withdraw(int amount)
    {
        lock (balanceLock)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"{Thread.CurrentThread.Name} withdrew {amount}. New balance: {balance}");
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} attempted to withdraw {amount}, but insufficient balance.");
            }
        }
    }

    public int GetBalance()
    {
        lock (balanceLock)
        {
            return balance;
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(1000);
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
    }
}
```

## Output
```
Thread-1 deposited 500. New balance: 1500
Thread-2 withdrew 300. New balance: 1200
Thread-3 deposited 500. New balance: 1700
Thread-4 withdrew 300. New balance: 1400
...
Final Account Balance: 1700
```
## Authors

[Vasu Kansagara](https://github.com/VasuKansagaraBacancy)

