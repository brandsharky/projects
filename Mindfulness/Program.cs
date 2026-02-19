/*
Mindfullness Program

Brandon Arroyo
2/4/2026

Enhancements: For this program, I added a reusable spinner animation to Base Activity. I also added a countdown animation to the Base Activity as well so that it can be accessed by all of its children. In addition, this program allows the user to do multiple activities before the program ends. Also, when taking in the user's choice input, it handles invalid options by repeating the loop. Finally, all shared code is added to the Base Activity to make sure the repetitive code is reduced.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfullness Program");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");

            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
            }
            else if (choice == "2")
            {
                new ListingActivity().Run();
            }
            else if (choice == "3")
            {
                new ReflectingActivity().Run();
            }
            else if (choice == "4")
            {
                running = false;
            }
            else
            {
                continue;
            }
        }

        Console.WriteLine("\nThank you using the Mindfullness Program. Have a nice day!");
    }
}