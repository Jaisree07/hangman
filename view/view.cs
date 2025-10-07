using System;
using System.Collections.Generic;
using System.Linq;

namespace View
{
    public static class HangmanView
    {
        public static void DisplayWord(string word, List<char> correctGuesses)
        {
            string display = string.Join(" ", word.ToCharArray().Select(c => correctGuesses.Contains(c) ? c : '_'));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Word: " + display);
        }
        public static void DisplayWrongGuesses(List<char> wrongGuesses, int attemptsLeft)
        {
            Console.WriteLine($"Wrong characters ({attemptsLeft} left): {string.Join(", ", wrongGuesses)}");
        }

        public static void DisplayHangman(int wrongCount)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hangman");
            Console.ForegroundColor = ConsoleColor.Red;
            switch (wrongCount)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("=========");
                    Console.ResetColor();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("+---+");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("=========");
                    Console.ResetColor();
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("+---+");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    Console.WriteLine("|  /|\\");
                    Console.WriteLine("|  / \\");
                    Console.WriteLine("|");
                    Console.WriteLine("=========");
                    Console.ResetColor();
                    break;
            }
        }

        public static void DisplayWord(string maskedWord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Word: {maskedWord}");
            Console.ResetColor();
        }

        public static void ShowPrompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Write(message);
            Console.ResetColor();
        }
        public static void ShowMessage(string message, string color = "white")
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            switch (color.ToLower())
            {
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = prevColor; 
        }
    }
}
