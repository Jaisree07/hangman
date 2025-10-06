using System;
using System.IO;

namespace Model
{
    public class Admin
    {
        private readonly string csvPath = @"C:\Users\jaisree.anandhakumar\Desktop\hangman\hangman\words.csv";
        public void Run()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter new word: ");
            string newWord = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrWhiteSpace(newWord))
            {
                Console.WriteLine("Invalid word");
                return;
            }
            if (!File.Exists(csvPath))
                File.WriteAllText(csvPath, newWord);
            else
                File.AppendAllText(csvPath, "," + newWord);
            Console.WriteLine($"Word '{newWord}' added successfully");
        }
    }
}
