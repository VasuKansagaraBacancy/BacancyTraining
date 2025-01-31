using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class task1
    {
        private int balance;
        private readonly object balanceLock = new object();

        public task1(int initialBalance)
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

    
}


