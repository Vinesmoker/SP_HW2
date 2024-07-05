using System;
using System.Diagnostics;
using static System.Console;

class Program
{
    static void Main()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = @"C:\\Windows\\System32\\notepad.exe",
            Arguments = ""
        };

        try
        {
            using Process? proc = Process.Start(startInfo);
            {
                if (proc != null)
                {
                    WriteLine("Запущен дочерний процесс. Пожалуйста, закройте приложение для продолжения...");
                    proc.WaitForExit();
                    int exit = proc.ExitCode;
                    WriteLine($"Дочерний процесс завершен с кодом {exit}.");
                }
                else
                {
                    WriteLine("Не удалось запустить дочерний процесс.");
                }
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
