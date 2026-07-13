namespace WriterApp;

class Program
{
    static void Main(string[] args)
    {
        // string filePath = "file.txt";

        Console.WriteLine(" Please select mode: ");
        Console.WriteLine(" 1 - Auto flush ");
        Console.WriteLine(" 2 - Manual flush (Use /flush command) ");
        Console.WriteLine(" Enter 1 or 2: ");

        string choice = Console.ReadLine();
        bool isAutoFlush = choice == "1";

        if (isAutoFlush) Console.WriteLine("Working mode: Auto Flush ");
        else Console.WriteLine("Working mode: Manual Flush ");

    }
}