// See https://aka.ms/new-console-template for more information
/*
    The "Swift Console Applicaiton" serves as an introcutory hub for the swift ecosystem
*/

class Program
{
    const string companyName = "Swift";

    static string[] menuOptions = ["About", "Explore Swift Products", "Exit"];

    static void Main(string[] args)
    {
        Console.Clear(); //Clear the console

        //Display Intro
        Intro();

        //Get user selected menu Number
        int selectedMenu = MenuNavigation();

        //Display Menu
        ShowMenuContent(selectedMenu);
    }

    static void Intro()
    {
        DisplayWelcomeMessage();
        PrintBreakLine();
        DisplayMenuOptions();
        PrintBreakLine();
    }

    /// <summary>
    /// use the ReadAFle method to display
    /// user selected menu option
    /// </summary>
    /// <param name="selectedMenu">user selected menu</param>
    static void ShowMenuContent(int selectedMenu)
    {
        switch (selectedMenu)
        {
            case 0:
                ReadAFile("documents/about.txt");
                break;
            case 1:
                ReadAFile("document/project");
                break;
            case 2:
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
    /// prompt user for menu selection until menu selection is valid. 
    /// </summary>
    /// <returns>the selected menu number for navigation</returns>
    static int MenuNavigation()
    {
        bool validNumber = false;
        int chosenMenu = -1;
        string? userInput;
        do
        {
            Console.WriteLine("Choose a menu option (Enter menu number): ");
            userInput = Console.ReadLine();

            validNumber = int.TryParse(userInput, out chosenMenu);

            if (validNumber)
            {
                if (chosenMenu < 0 || chosenMenu >= menuOptions.Length) //Invalid menu number
                {
                    Console.WriteLine("\tInvaid Menu");
                    validNumber = false;
                }
            }
            else
            {
                Console.WriteLine("\tInvalid");
            }
        } while (validNumber == false);


        return chosenMenu;
    }
    /// <summary>
    /// display numbered menu options
    /// </summary>
    static void DisplayMenuOptions()
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            Console.WriteLine($"({i})\t{menuOptions[i]}");
        }
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