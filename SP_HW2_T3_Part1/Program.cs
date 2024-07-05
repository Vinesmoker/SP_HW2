#nullable enable
using System;
using System.Diagnostics;
using static System.Console;

class ParentProgram
{
    static void Main()
    {
        bool cont = true;
        while (cont)
        {
            WriteLine("Введите первое число:");
            string? num1 = ReadLine();
            WriteLine("Введите действие (+, -, *, /):");
            string? act = ReadLine();
            WriteLine("Введите второе число:");
            string? num2 = ReadLine();
            if (num1 != null && act != null && num2 != null)
            {
                ProcessStartInfo start = new()
                {
                    FileName = @"C:\\Users\\User\\source\\repos\\SP_HW2\\SP_HW2_T3_Part2_Child\\bin\\Debug\\net8.0\\SP_HW2_T3_Part2_Child.exe",
                    Arguments = $"{num1} {act} {num2}"
                };

                using Process? childProc = Process.Start(start);
                if (childProc != null)
                {
                    childProc.WaitForExit();
                }
                else
                {
                    WriteLine("Не удалось запустить дочерний процесс.");
                }
            }
            else
            {
                WriteLine("Одно из введенных значений было пустым. Пожалуйста, попробуйте снова.");
            }
            WriteLine("Нажмите (Y) для повтора или любую клавишу для выхода.");
            string? choice = ReadLine()?.ToLower();
            if (choice != "y" && choice != "н" && choice != "да" && choice != "yes")
            {
                cont = false;
            }
        }
    }
}
