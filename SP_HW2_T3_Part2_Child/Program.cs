using System;
using static System.Console;

class ChildProgram
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            WriteLine("Некорректное количество аргументов.");
            return;
        }
        if (!double.TryParse(args[0], out double num1) || !double.TryParse(args[2], out double num2))
        {
            WriteLine("Некорректный ввод чисел.");
            return;
        }

        string? action = args[1];
        double result;

        switch (action)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    WriteLine("На ноль делить нельзя.");
                    return;
                }
                result = num1 / num2;
                break;
            default:
                WriteLine("Некорректное действие.");
                return;
        }
        WriteLine($"Результат: {result}");
    }
}
