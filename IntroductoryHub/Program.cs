﻿/*
    The "Swift Console Applicaiton" serves as an introcutory hub for the swift ecosystem
*/

class Program
{
    const string companyName = "Swift";
    static string[] menuOptions = ["About", "Explore Swift Products", "Exit"];
    static int selectedMenu = -1;
    static bool isRunning = true;
    static void Main(string[] args)
    {
        Console.Clear();

        Intro();
        do
        {
            Core();
        }
        while (isRunning);

    }

    /// <summary>
    /// Implement the Introductory Hub's algorithm.
    /// </summary>
    static void Core()
    {
        //Display menu option
        for (int i = 0; i < menuOptions.Length; i++)
        {
            Console.WriteLine($"({i})\t{menuOptions[i]}");
        }

        // 2 User Input -> Select menu to view or close
        string? userInput = null;
        bool isValidMenuOption = false;
        do
        {
            Console.Write("Select a menu (by number): ");
            userInput = Console.ReadLine();
            isValidMenuOption = MenuOptionValidator(userInput, 0, menuOptions.Length);

        } while (isValidMenuOption == false);

        // 3 Display selected menu or exit
        if (selectedMenu == 2)
        {
            //Implement exit
            isRunning = false;
            Console.Clear();

            Console.WriteLine("I hope you enjoyed Swift's Introductory Hub.");
        }
        else
        {
            DisplaySelectedMenu();

            //Prompt user to return to main menu 
            do
            {
                Console.WriteLine();
                Console.Write("Please enter 'nice' to return to main menu: ");
                userInput = Console.ReadLine();
            } while (userInput != null && userInput.ToLower() != "nice");

            Console.Clear();
            Intro();
        }
    }

    static void Intro()
    {
        DisplayWelcomeMessage();
        PrintBreakLine();
    }

    /// <summary>
    /// use the ReadAFle method to display
    /// user selected menu option
    /// </summary>
    /// <param name="selectedMenu">user selected menu</param>
    static void DisplaySelectedMenu()
    {
        Console.Clear();
        switch (selectedMenu)
        {
            case 0:
                ReadAFile("documents/about.txt");
                break;
            case 1:
                ReadAFile("documents/projects.txt");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// reads a file line by line and print to console if it exists
    /// </summary>
    /// <param name="filePath"></param>
    static void ReadAFile(string filePath)
    {
        //Check if file exist
        if (File.Exists(filePath))
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                string? s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        else
        {
            Console.WriteLine("Development in Progress...");
        }
    }

    /// <summary>
    /// validate user selected menu option
    /// </summary>
    /// <param name="userInput">user selection</param>
    /// <param name="lower">Lower bound for current menu option</param>
    /// <param name="upper">Upper bound for current menu option</param>
    /// <returns>False is validation fails</returns>
    static bool MenuOptionValidator(string? userInput, int lower, int upper)
    {
        bool result = false;

        if (int.TryParse(userInput, out selectedMenu))
        {
            //Check menu range
            if (selectedMenu < lower || selectedMenu >= upper)
            {
                Console.WriteLine("Menu: out of range");
                return false;
            }
            else
            {
                return true;
            }
        }
        Console.WriteLine("Invalid Input");
        return result;
    }

    /// <summary>
    /// display welcome message
    /// </summary>
    static void DisplayWelcomeMessage()
    {
        string title = $"Welcome to {companyName}";
        Console.WriteLine();
        Console.WriteLine(title);
        Console.WriteLine();
    }

    /// <summary>
    /// print break line characters
    /// </summary>
    static void PrintBreakLine()
    {
        char character = '-';
        int length = 40;

        for (int i = 0; i < length; i++)
        {
            Console.Write(character);
        }
        Console.WriteLine();
    }

}