using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Cinema
{
    internal class Program
    {
        // Method for getting price by age
        static int GetPrice(int age)
        {
            if (age < 5)
                return 0;
            else if (age < 20)
                return 80;
            else if (age >= 64 && age < 100)
                return 90;
            else if (age >= 100)
                return 0;
            else
                return 120;
        }

        // Print menu method

        static void PrintMenu()
        {
            Console.WriteLine("Welcome to the theoretical cinematic experience!" +
                "\nWhat would you like to do?" +
                "\n\n1 - Buy ticket" +
                "\n2 - Calculate price for group" +
                "\n3 - The little x10 loop" +
                "\n4 - Split sentence" +
                "\n0 - Exit");
        }



        static void Main(string[] args)
        {
            bool active;
            bool running = true;
            int input;
            int quant = 0;
            int totalPrice = 0;
            int price = 0;
            int age = 0;
            int menu = 99;

            PrintMenu();

            do
            {

                // Try to read menu input, else catch excption and print message  
                try
                {
                    menu = int.Parse(Console.ReadLine());

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }


                switch (menu)
                {
                    // Single customer ticket 
                    case 1:

                        // Try to read menu input, else catch excption and print message  
                        running = true;

                        while (running)
                        {
                            try
                            {
                                Console.Write("\nEnter your age: ");
                                age = int.Parse(Console.ReadLine());
                                running = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"{e.Message}");
                            }
                        }

                        price = GetPrice(age);
                        Console.WriteLine($"Your ticket price is: {price}\n\n");
                        PrintMenu();

                        break;


                    // Group of customers
                    case 2:

                        // Try to read menu input, else catch excption and print message  

                        running = true;

                        while (running)
                        {
                            try
                            {
                                Console.Write("Number of tickets: ");
                                quant = int.Parse(Console.ReadLine());
                                running = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"{e.Message}");
                            }
                        }


                        for (int i = 1; i <= quant; i++)
                        {
                            running = true;
                            // Try to read menu input, else catch excption and print message  

                            while (running)
                            {
                                try
                                {
                                    Console.Write($"Enter age for person nr {i}: ");
                                    age = int.Parse(Console.ReadLine());
                                    price = GetPrice(age);
                                    totalPrice += price;
                                    running = false;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"{e.Message}");
                                }
                            }

                            Console.WriteLine($"Your ticket price is: {price}");
                        }
                        Console.WriteLine($"\nThe total ticket price is: {totalPrice}\n\n");

                        PrintMenu();
                        totalPrice = 0;
                        break;

                    // x10 repeat of one word
                    case 3:
                        string dump = "";
                        bool split = false;
                        Console.Write("Enter a word to be repeated: ");

                        // Try to read menu input, else catch excption and print message  

                        while (split == false)
                        {
                            dump = Console.ReadLine();

                            if (dump.Contains(" "))
                            {
                                Console.Write("Found more than one word, try again: ");

                            }
                            else
                            {
                                split = true;

                            }

                        }


                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write($"{i} {dump} ");
                            if (i == 9)
                                Console.WriteLine("\n");
                        }
                        PrintMenu();
                        break;

                    // Splitting sentence by " " and printing the third word
                    case 4:

                        running = true;
                        string theThird = "";

                        // Try to read menu input, else catch excption and print message  

                        while (running)
                        {
                            try
                            {
                                Console.Write("Enter some words to split (min. 3): ");
                                var toSplit = Console.ReadLine().Split(" ");
                                theThird = toSplit[2];
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"{e.Message}");
                            }
                        }

                        Console.WriteLine($"The third word is: {theThird}\n\n");
                        PrintMenu();

                        break;

                    // Exit loop
                    case 0:

                        active = false;
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Write("\nOnly 0-4" +
                            "\nTry again: ");
                        break;

                }

            }

            while (active = true);

        }

    }

}
