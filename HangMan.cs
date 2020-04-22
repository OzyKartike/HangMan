using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Hang_man1
{
    class Program
    {
        static void Main(string[] args)
        {
            string side1;
            string side2;
            string word;
            string hint;
            int GoodGuesses = 0;
            int wrongGuess = 6;
            bool letterChecker = false;
            char letter;
            string dashes = null;
            bool exit = true;
            //Introduction of my game to make it more user friendly
            Console.WriteLine("Welcome to the 'HangMan Game'. Only two players/two opposing sides can play at a time.");
            Thread.Sleep(5000);
            Console.WriteLine("Take a few seconds to separate yourself into side 1 and side 2. Side 1 is tasked with naming the word and side 2 has to guess the word. ");
            Thread.Sleep(5000);
            Console.Clear();
            while (exit == true)
            {
                //This right here clears the message above the loop and it asks side 1 for their team name
                Console.Clear();
                Console.WriteLine("Side 1 please enter your/team name (enter exit to leave the game) ");
                side1 = Console.ReadLine().ToLower();
                //This is how my exit works, if someone wants to exit the code all they have to do is type in exit when it asks for side1 team name
                if (side1 == "exit")
                {
                    Console.WriteLine("You have chosen to exit from this game. It was been a pleasure playing with you.");
                    Thread.Sleep(1000);
                    exit = false;
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else
                {
                    //if exit wasnt chosen the code will proceed as intended
                    Console.WriteLine("Side 2 please enter your/team name ");
                    side2 = Console.ReadLine();
                    Console.WriteLine(side2 + ", please walk away so that " + side1 + " may pick their word");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine(side1 + " You have a few moments to decide your word");
                    Thread.Sleep(4000);
                    Console.WriteLine("Please enter the word you've chosen now");
                    // This converts the chosen word to lowercase I've done this for a lot of stuff including team names so there is no confusion. also lower case also help the person guessing because now they jsut have to worry about lower case letters and not both lower and upper case letters.
                    word = Console.ReadLine().ToLower();
                    Console.WriteLine("Great Word! Now just to be nice to your opponent, please enter a hint that would help the opponent find your word");
                    hint = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Please invite " + side2 + " back");
                    Thread.Sleep(3000);
                    Console.Clear();
                    // Converts the charectors in word and replaces them with dashes
                    foreach (char c in (word))
                    {
                        dashes = dashes + "_";
                        Thread.Sleep(50);

                    }
                    // Displays the number of characters in the word.
                    Console.WriteLine("Please start guessing this " + word.Length + " letter word");
                    Console.WriteLine(dashes);
                    Console.WriteLine();
                    Console.WriteLine("your hint is " + hint);
                    Console.WriteLine();
                    letter = Convert.ToChar(Console.ReadLine());
                    // My whole solving code is under one while loop and it only runs when the number of wrong guesses is above 0. YOu have 6 wrong guesses.
                    while (wrongGuess > 0)
                    {
                        int index = 0;
                        foreach (char ch in word)
                        {
                            // This if statement compares the letter entered with the charector (ch) in word. if they are equivalent it will run this loop until it's checked each position of that word starting at 0 which is why I have declared index as 0. 
                            if (letter == ch)
                            {
                                letterChecker = true;
                                StringBuilder sb = new StringBuilder(dashes);
                                sb[index] = letter;
                                dashes = sb.ToString();
                                GoodGuesses++;
                                Console.WriteLine();
                            }
                            //right here it says index ++ so that this loop will run again and check the next spot of the ch in word
                            index++;
                        }
                        // This is what happens when the letter you've entered is not == to ch in word
                        if (!letterChecker)
                        {
                            // Since you only have 6 wrong guesses it will subtract one each time you enter in a wrong number
                            wrongGuess--;
                            Console.WriteLine("wrong, you have " + wrongGuess + " left");
                            //if you wrong guesses go down all the way to 0 the game will tell you that you got 6 wrong and then it will clear everything and start you from scratch
                            if (wrongGuess == 0)
                            {
                                Console.WriteLine("YOU GUESS 6 WRONG! HOW!! THAT'S IT YOUR GUESSING IS OVER AND YOU LOSE!!!!");
                                Thread.Sleep(6000);
                                Console.Clear();
                                Console.WriteLine("Pathetic, anyone who fails 6 times doesnt deserve to play this game anymore. Close this and start again if you wish to play again.");
                                Console.Clear();
                                Console.WriteLine("Here is your word again hope you can figure out what it was. Close this program and try again. P.S your word was " + word);
                            }
                        }
                        else
                            Console.WriteLine("Good Job");
                        // Now this is the solution I came up with for words that had double letters so it would compare the good guesses with word length and if the whole word had been guessed then it would say congradulation you won and ask you if you wanted to play again.
                        if (GoodGuesses == word.Length)
                        {
                            Console.Clear();
                            wrongGuess = 0;
                            Console.WriteLine("Congratulation you won!");
                            Console.WriteLine("Please leave the game. Bye! ");
                            Thread.Sleep(600);
                        }
                        else
                        // This makes the letter checker false so that the next word can me compared to the other charectors in the word because without this it would've only checked the letter for one carector.
                        {
                            letterChecker = false;
                            Console.WriteLine(dashes);
                            letter = Convert.ToChar(Console.ReadLine());
                        }
                    }

                }
                Console.ReadLine();
            }

        }
    }
}
