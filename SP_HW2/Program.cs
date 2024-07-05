using System;
using System.Diagnostics;

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
                    Console.WriteLine("Запущен дочерний процесс. Пожалуйста, закройте приложение для продолжения...");
                    proc.WaitForExit();
                    int exit = proc.ExitCode;
                    Console.WriteLine($"Дочерний процесс завершен с кодом {exit}.");
                }
                else
                {
                    Console.WriteLine("Не удалось запустить дочерний процесс.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
