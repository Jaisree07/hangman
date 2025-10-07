using System;
using System.IO;
using System.Linq;

namespace Hangman.Models
{
    public class WordRepository
    {
        private readonly string csvPath = @"C:\Users\jaisree.anandhakumar\Desktop\hangman\hangman\words.csv";
        public void AddWord(string word)
        {
            word = word.Trim().ToLower();
            if (!File.Exists(csvPath))
            {
                File.WriteAllText(csvPath, word);
            }
            else
            {
                string content = File.ReadAllText(csvPath).Trim();
                string toAppend = string.IsNullOrEmpty(content) ? word : "," + word;
                File.AppendAllText(csvPath, toAppend);
            }
        }

        public string[] GetAllWords()
        {
            if (File.Exists(csvPath))
            {
                string content = File.ReadAllText(csvPath);
                return content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) .Select(w => w.Trim().ToLower())
                              .ToArray();
            }
            return new string[0];
        }
        public string GetRandomWord()
        {
            var words = GetAllWords();
            if (words.Length==0) return string.Empty;
            Random rnd = new Random();
            return words[rnd.Next(words.Length)];
        }
    }
}
