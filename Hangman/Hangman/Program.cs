using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGame
    {
        private string[] words = { "apple", "banana", "orange", "grape", "pineapple" };
        private string secretWord;
        private char[] guessedLetters;
        private int attemptsLeft = 6; // Number of attempts allowed
        private bool isGameOver = false;

        public void StartGame()
        {
            // Choose a random word from the words array
            Random random = new Random();
            int randomIndex = random.Next(0, words.Length);
            secretWord = words[randomIndex];

            // Initialize guessedLetters array with underscores for each letter in the word
            guessedLetters = new char[secretWord.Length];
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Try to guess the word.");
            DisplayWord();

            // Main game loop
            while (!isGameOver)
            {
                // Prompt the user for a letter guess
                Console.Write("\nEnter a letter: ");
                char guess = char.ToLower(Console.ReadKey().KeyChar);

                // Validate the guess
                if (!char.IsLetter(guess))
                {
                    Console.WriteLine("\nPlease enter a valid letter.");
                    continue;
                }

                // Check if the guessed letter is in the secret word
                bool isCorrectGuess = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedLetters[i] = guess;
                        isCorrectGuess = true;
                    }
                }

                // Update game status
                if (!isCorrectGuess)
                {
                    attemptsLeft--;
                    Console.WriteLine("\nIncorrect guess! Attempts left: " + attemptsLeft);
                }

                // Display the current state of the word
                DisplayWord();

                // Check if the game is over (win or lose)
                if (attemptsLeft == 0 || new string(guessedLetters) == secretWord)
                {
                    isGameOver = true;
                    if (attemptsLeft == 0)
                    {
                        Console.WriteLine("\nGame over! You ran out of attempts. The word was: " + secretWord);
                    }
                    else
                    {
                        Console.WriteLine("\nCongratulations! You guessed the word: " + secretWord);
                    }
                }
            }

            Console.WriteLine("\nThanks for playing Hangman!");
            Console.ReadKey();
        }

        private void DisplayWord()
        {
            Console.Write("\nWord: ");
            foreach (char letter in guessedLetters)
            {
                Console.Write(letter + " ");
            }
        }

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            HangmanGame hangmanGame = new HangmanGame();
            hangmanGame.StartGame();
        }
    }
}
