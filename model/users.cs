using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using View;

namespace Model
{
    public class User
    {
        private readonly string csvPath = @"C:\Users\jaisree.anandhakumar\Desktop\hangman\hangman\words.csv";
        public void Run()
        {
            if (!File.Exists(csvPath))
            {
                HangmanView.ShowMessage("csv file should be added");
                return;
            }
            string[] words=File.ReadAllText(csvPath).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(w => w.Trim().ToLower()).ToArray();
            if (words.Length==0)
            {
                HangmanView.ShowMessage("No words available");
                return;
            }
            Random rnd = new Random();
            string word = words[rnd.Next(words.Length)];
            List<char> correctGuesses = new List<char>();
            List<char> wrongGuesses = new List<char>();
            int attemptsLeft = 3;
            while (true)
            {
                Console.Clear();
                HangmanView.DisplayWord(word, correctGuesses);
                HangmanView.DisplayWrongGuesses(wrongGuesses, attemptsLeft);
                HangmanView.DisplayHangman(3-attemptsLeft);
                if (correctGuesses.Count==word.Length)
                {
                    HangmanView.ShowMessage("Congratulations!You won!!","green");
                    HangmanView.ShowMessage("\nThe word was: " + word,"green");
                    break;
                }
                if (attemptsLeft<=0)
                {
                    HangmanView.ShowMessage("You lost!!","red");
                    HangmanView.ShowMessage("The word was: " + word,"red");
                    break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter a character: ");
                char guess = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (word.Contains(guess))
                {
                    if (!correctGuesses.Contains(guess))
                        correctGuesses.Add(guess);
                    attemptsLeft=3; 
                }
                else
                {
                    if (!wrongGuesses.Contains(guess))
                    {
                        wrongGuesses.Add(guess);
                        attemptsLeft--;
                    }
                }
            }
        }
    }
}

