using System;
using System.IO;
using static System.Console;

namespace ChildApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Child process started.");
            if (args.Length < 2)
            {
                WriteLine("Invalid arguments. Exiting...");
                return;
            }
            string filePath = args[0];
            string searchWord = args[1];
            WriteLine($"Processing file: {filePath}");
            WriteLine($"Searching for word: {searchWord}");
            try
            {
                if (!File.Exists(filePath))
                {
                    WriteLine("File does not exist. Exiting...");
                    return;
                }

                int lineCount = CountLines(filePath);
                WriteLine($"The file has {lineCount} lines.");

                int wordCount = CountWordOccurrences(filePath, searchWord);
                WriteLine($"The word '{searchWord}' appears {wordCount} times in the file.");
            }
            catch (Exception ex)
            {
                WriteLine($"Error processing file: {ex.Message}");
            }
            WriteLine("Press any key to exit...");
            ReadKey();
        }
        static int CountLines(string filePath)
        {
            int lineCount = 0;
            using (StreamReader reader = new(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }
        static int CountWordOccurrences(string filePath, string searchWord)
        {
            int wordCount = 0;
            using (StreamReader reader = new(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    wordCount += CountWordInLine(line, searchWord);
                }
            }
            return wordCount;
        }
        static int CountWordInLine(string line, string searchWord)
        {
            int count = 0;
            int index = 0;
            while ((index = line.IndexOf(searchWord, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += searchWord.Length;
            }
            return count;
        }
    }
}
