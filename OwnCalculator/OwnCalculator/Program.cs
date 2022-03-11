using System;

namespace OwnCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Add(15, 20);
            Console.WriteLine(calculator.Result);
            calculator.Sub(20, 15);
            Console.WriteLine(calculator.Result);
            calculator.Mul(20, 15);
            Console.WriteLine(calculator.Result);
            calculator.Div(20, 4);
            Console.WriteLine(calculator.Result);
            calculator.Modulo(20, 15);
            Console.WriteLine(calculator.Result);
            calculator.Result = 20;
            Console.WriteLine(calculator.Result);
        }
    }
}