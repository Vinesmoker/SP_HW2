using System;
using System.Diagnostics;
using System.Threading;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine("Введите имя исполняемого файла дочернего процесса:");
        string? fileName = ReadLine();
        ProcessStartInfo startInfo = new()
        {
            FileName = fileName,
            Arguments = @"C:\\Users\\User\\Desktop\\2.txt"
        };
        using Process? proc = Process.Start(startInfo);
        if (proc == null)
        {
            WriteLine("Не удалось запустить дочерний процесс.");
            return;
        }
        WriteLine("Выберите действие:");
        WriteLine("1 - Ожидать завершения дочернего процесса");
        WriteLine("2 - Принудительно завершить дочерний процесс");
        string? choice = ReadLine();
        switch (choice)
        {
            case "1":
                proc.WaitForExit();
                WriteLine($"Дочерний процесс завершен с кодом {proc.ExitCode}.");
                break;
            case "2":
                if (!proc.HasExited)
                {
                    proc.Kill();
                    WriteLine("Дочерний процесс был принудительно завершен.");
                }
                break;
            default:
                WriteLine("Неверный выбор.");
                break;
        }
    }
}
