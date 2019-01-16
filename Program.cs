using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo(); // App info

            WelcomeUser(); // Welcome user

            while (true)
            {
                //Get user's input
                string reply = Console.ReadLine().ToUpper();

                // If statement to check user's answer
                if (reply == "Y")
                {
                    while (true)
                    {
                        // Change color while asking user for their skill level
                        ChangeColor(ConsoleColor.Yellow, "What's your skill level as I don't want you to have a brain damage? [Choose - 'B' for 'Basic', 'I' for 'Intermediate', or 'A' for 'Advanced'");
                     
                        string skillLevel = Console.ReadLine().ToUpper();

                        if (skillLevel == "B")
                        {
                            // Function to play by skill level
                            PlayBySkillLevel("Great! I have a number in mind, can you guess what it is?", "Hint: It is between 1 to 10.");

                            // Play game
                            PlayGame(10);

                            break;
                        }

                        else if (skillLevel == "I")
                        {
                            // Function to play by skill level
                            PlayBySkillLevel("Whoa! someone's got experience! Alright, I have a number in mind, can you guess what it is?", "Hint: It is between 1 to 20.");

                            // Play game
                            PlayGame(20);

                            break;
                        }

                        else if (skillLevel == "A")
                        {
                            // Function to play by skill level
                            PlayBySkillLevel("We've got the boss in the house!! :) Alright, I have a number in mind, can you guess what it is?", "Hint: It is between 1 to 30.");

                            // Play game
                            PlayGame(30);

                            break;
                        }

                        else
                        {
                            Console.WriteLine("I'm sorry, I didn't get that. Please try again...");
                            continue;
                        }
                    }
                  
                    // Prompt user to play again 
                    Console.WriteLine("Wanna play again? [Y or N] " + "This time I won't be easy on you.");
                    continue;
                }

                else if (reply == "N")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("I'm sorry, I didn't get that. Please choose between Y or N.");
                    continue;
                }

            }
            
        }

        // ** Funtions **
 
        // Function to get app information
        static void GetAppInfo()
        {
            // Init the parameter for the Introduction
            string appTitle = "Smart Guesser";
            string appVersion = "Version 1.0.0";
            string appAuthor = "Nicole Nwakalor";

            //Change text color
            Console.ForegroundColor = ConsoleColor.Magenta;

            //Print Introduction to console
            Console.WriteLine("{0}: {1} by {2}.", appTitle, appVersion, appAuthor);

            // Reset text color
            Console.ResetColor();
        }

        // Welcome message to user.
        static void WelcomeUser()
        {
            // Welcome Message to user
            Console.WriteLine("Welcome to Smart Guesser! My name is Matt, what is your name?");

            // Read user's input
            string userInput = Console.ReadLine();

            // Welcome user with name and invite to play game
            Console.WriteLine("Hello {0}, wanna play a game? [Y or N]", userInput);
        }

        // Function to change color
        static void ChangeColor(ConsoleColor color, String message)
        {
            // Change color
            Console.ForegroundColor = color;

            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Addresses different skill level
        static void PlayBySkillLevel(String guessMesssage, String hintMessage)
        {
            Console.WriteLine(guessMesssage);

            // Change color
            ChangeColor(ConsoleColor.DarkGreen, hintMessage);

        }

        // Function to play game based on skill level
        static void PlayGame(Int32 number)
        {
            // init a guess value
            int guess = 0;

            // Creating a random number
            Random randomNumber = new Random();

            //Init correct number from 1-10
            int numberInMind = randomNumber.Next(1, number);

            while (guess != numberInMind)
            {
                //Obtain user's input
                string answer = Console.ReadLine();

                // Make sure its a number
                if (!int.TryParse(answer, out guess))
                {
                    // Change color
                    ChangeColor(ConsoleColor.Red, "Please enter an actual number");
                    continue;
                }

                // Assign answer to variable guess and convert from string to integer
                guess = Int32.Parse(answer);

                if(guess != numberInMind)
                {
                    // Change color
                    ChangeColor(ConsoleColor.Red, "Nope, try again...");
                }
                else
                {
                    break;
                }

            }

            // Change color
            ChangeColor(ConsoleColor.Yellow, "WOW! how did you guess correctly? " + "You must be a mind reader!!");
        }

    }

}

