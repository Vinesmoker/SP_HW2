using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Console;

namespace ParentApp
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            WriteLine("Enter the word to search:");
            string searchWord = ReadLine();
            WriteLine("Do you want to select a file? (Y/N)");
            string response = ReadLine();
            if (response.ToLower() == "y" && response.ToLower() == "н")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    WriteLine($"Selected file: {filePath}");
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "C:\\Users\\User\\source\\repos\\SP_HW2\\SP_HW2T4_Part2_Child\\bin\\Debug\\net8.0\\SP_HW2T4_Part2_Child.exe",
                        Arguments = $"\"{filePath}\" \"{searchWord}\"",
                        UseShellExecute = true,
                        CreateNoWindow = false
                    };
                    try
                    {
                        using (Process process = Process.Start(startInfo))
                        {
                            WriteLine("Child process started.");
                            process.WaitForExit();
                            WriteLine("Child process exited.");
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"Error starting child process: {ex.Message}");
                    }
                }
                else
                {
                    WriteLine("No file selected. Exiting...");
                }
            }
            else
            {
                WriteLine("Exiting...");
            }
        }
    }
}