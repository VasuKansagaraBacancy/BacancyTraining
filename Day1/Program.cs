// See https://aka.ms/new-console-template for more information



using Day1;
using System;

task1 t1= new task1();

Console.WriteLine("Enter the number up to which you want to find the count of odd and even numbers.");

int number=Convert.ToInt32(Console.ReadLine());

t1.countnum(number);