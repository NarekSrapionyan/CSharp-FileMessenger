namespace WriterApp;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        string filePath = "messages.txt";
        StringBuilder buffer = new();

        Console.WriteLine("Please select mode:");
        Console.WriteLine("1 - Auto Flush");
        Console.WriteLine("2 - Manual Flush");
        Console.Write("Enter 1 or 2: ");

        string? choice = Console.ReadLine();
        bool isAutoFlush = choice == "1";

        Console.WriteLine();

        if (isAutoFlush)
        {
            Console.WriteLine("Working mode: Auto Flush");
            Console.WriteLine("Commands:");
            Console.WriteLine("/exit - Exit program");
        }
        else
        {
            Console.WriteLine("Working mode: Manual Flush");
            Console.WriteLine("Commands:");
            Console.WriteLine("/flush - Write buffered text to file");
            Console.WriteLine("/exit  - Exit program");
        }

        Console.WriteLine();
        while (true)
        {
            Console.Write("Enter text: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            if (input == "/exit")
            {
                if (!isAutoFlush && buffer.Length > 0)
                {
                    WriteToFile(filePath, buffer.ToString());
                    buffer.Clear();

                    Console.WriteLine("Buffered text written before exit.");
                }

                Console.WriteLine("Program stopped.");
                break;
            }

            if (!isAutoFlush && input == "/flush")
            {
                if (buffer.Length == 0)
                {
                    Console.WriteLine("Buffer is empty.");
                    continue;
                }

                WriteToFile(filePath, buffer.ToString());
                buffer.Clear();

                Console.WriteLine("Buffer written to file.");
                continue;
            }

            if (isAutoFlush)
            {
                WriteToFile(filePath, input + Environment.NewLine);
                Console.WriteLine("Text written to file.");
            }
            else
            {
                buffer.AppendLine(input);
                Console.WriteLine("Text added to buffer.");
            }
        }

        static void WriteToFile(string filePath, string text)
        {
            using FileStream fileStream = new FileStream(
                filePath,
                FileMode.Append,
                FileAccess.Write,
                FileShare.ReadWrite);

            using StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8);

            writer.Write(text);
            writer.Flush();
        }
    }
}