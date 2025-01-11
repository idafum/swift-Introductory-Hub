// See https://aka.ms/new-console-template for more information
/*
    The "Swift Console Applicaiton" serves as an introcutory hub for the swift ecosystem
*/

class Program
{
    const string companyName = "Swift";

    static void Main(string[] args)
    {
        Console.Clear(); //Clear the console

        DisplayWelcomeMessage();

        PrintBreakLine();
    }

    /// <summary>
    /// Display Welcome message
    /// </summary>
    static void DisplayWelcomeMessage()
    {
        string title = $"Welcome to {companyName}";
        Console.WriteLine();
        Console.WriteLine(title);
        Console.WriteLine();
    }

    static void PrintBreakLine()
    {
        char character = '-';
        int length = 40;

        for(int i = 0; i < length; i++)
        {
            Console.Write(character);
        }

        Console.WriteLine();
    }

}