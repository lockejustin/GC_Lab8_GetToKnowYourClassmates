using System;
using System.Collections.Generic;

namespace GC_Lab8_GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> classMembers = new List<string>() { "Wolverine", "Batman", "Superman", "Spiderman"};
            List<string> weakness = new List<string>() { "magnets", "bats and his dead parents", "green rocks", "having no money"};
            List<string> power = new List<string>() { "having a motorcycle and being able to smell really far", "being rich and nuts", "wearing glasses to hide his identity", "doing whatever a spider can"};
            List<string> realName = new List<string>() { "Logan", "Bruce Wayne", "Kal-El", "Peter Parker" };

            int studentCount = classMembers.Count;
            int index = 0;
            bool continueProgram = true;
            
            Console.WriteLine("Welcome to the program that let's you get to know the class!");

            while (continueProgram)
            {
                Console.WriteLine("Please choose a student from the following list (enter a name or number): ");
                
                PrintClassList(classMembers);

                index = ChooseStudent(classMembers)-1;
                    
                if (index >= 0 && index < classMembers.Count)
                {
                    Console.WriteLine($"Student number {index+1} is {classMembers[index]}.\n");
                    ChooseInfo(index, classMembers, weakness, power, realName);
                    continueProgram = ContinueProgramYesNoPrompt("Would you like to find information about another student");

                }
            }
        }

        public static void ChooseInfo(int index, List<string> classMembers, List<string> weakness, List<String> power, List<String> realName)
        {
            bool continueWithCurrent = true;

            while (continueWithCurrent)
            {
                Console.WriteLine($"What would you like to know about {classMembers[index]}?");
                Console.Write($"(Enter \"weakness\" or \"power\" or \"real name\"):");
                string choice = Console.ReadLine();

                while (choice != "weakness" && choice != "power" && choice != "real name")
                {
                    Console.WriteLine($"We don't have that information for {classMembers[index]}.  (Enter \"weakness\" or \"power\" or \"real name\"):");
                    choice = Console.ReadLine();
                }

                if (choice == "weakness")
                    Console.WriteLine($"{classMembers[index]}'s weakness is {weakness[index]}.\n");
                else if (choice == "power")
                    Console.WriteLine($"{classMembers[index]}'s power is {power[index]}.\n");
                else if (choice == "real name")
                    Console.WriteLine($"{classMembers[index]}'s real name is {realName[index]}.\n");

                continueWithCurrent = ContinueWithCurrentStudent(classMembers[index]);
            }
        }

        public static bool ContinueWithCurrentStudent(string name)
        {
            Console.WriteLine($"Would you like to learn more about {name}? (y/n)" );

            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "n")  //checks to make sure the user enters either y or n
            {
                Console.Write("Your entry was invalid.  Please respond (y/n) ");
                response = Console.ReadLine().ToLower();
            }

            if (response == "y")
                return true;
            else
                return false;
        }

        public static void PrintClassList(List<string> classMembers)
        {
            for (int i = 0; i < classMembers.Count; i++)
                Console.WriteLine($"{i+1}) {classMembers[i]}");
        }

        public static int ChooseStudent(List<string> classMembers)
        {
            int menuChoice = 0;
            string name = "";
            bool validChoice = false;
            string input = "";

            while (!validChoice)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out menuChoice))
                {
                    try  //validates correct entry
                    {
                        menuChoice = int.Parse(input);
                        try
                        {
                            name = classMembers[menuChoice - 1];
                        }
                        catch (ArgumentOutOfRangeException e1)
                        {
                            Console.WriteLine(e1 + "\nYour entry was not a number in the list.  Please enter a valid number from the list.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    catch (FormatException e2)
                    {
                        Console.WriteLine(e2 + "\nYour entry was not a number.  Please enter a valid number from the list.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    validChoice = true;
                }
                else
                {
                    for (int i = 0; i < classMembers.Count; i++)
                    {
                        if (input == classMembers[i])
                        {

                            menuChoice = i;
                            validChoice = true;
                            return (menuChoice+1);
                        }
                    }
                    Console.WriteLine($"{input} was not a valid choice.  Please enter a valid choice from the list.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

                
            }
            return (menuChoice);
        }

        public static bool ContinueProgramYesNoPrompt(string message)  //prompts user if they'd like to continue and verifies proper entry
        {
            Console.Write($"{message} (y/n) ");
            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "n")  //checks to make sure the user enters either y or n
            {
                Console.Write("Your entry was invalid.  Please respond (y/n) ");
                response = Console.ReadLine().ToLower();
            }

            if (response == "y")
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Thanks for using this program.  Goodbye!");
                return false;
            }
        }
    }
}
