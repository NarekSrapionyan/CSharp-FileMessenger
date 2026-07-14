namespace ReaderApp;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "messages.txt");
        filePath = Path.GetFullPath(filePath);
        long lastPosition = 0;

        Console.WriteLine("Reader started.");
        Console.WriteLine("Watching file: " + filePath);
        Console.WriteLine("Press Control + ESC to stop.");
        Console.WriteLine();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.WriteLine("Reader stopped.");
                    break;
                }
            }

            string newText = ReadNewContent(filePath, ref lastPosition);
            if (!string.IsNullOrEmpty(newText))
            {
                Console.Write(newText);
            }

            Thread.Sleep(300);
        }

        return;
    }

    static string ReadNewContent(string filePath, ref long lastPosition)
    {
        if (!File.Exists(filePath))
        {
            return string.Empty;
        }

        using FileStream fileStream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite);

        if (fileStream.Length <= lastPosition)
        {
            if (fileStream.Length < lastPosition)
            {
                // File got smaller than what we already read — it was
                // probably deleted and recreated. Start over from 0.
                lastPosition = 0;
            }
            return string.Empty;
        }

        fileStream.Seek(lastPosition, SeekOrigin.Begin);

        int bytesToRead = (int)(fileStream.Length - lastPosition);
        byte[] buffer = new byte[bytesToRead];
        int bytesRead = fileStream.Read(buffer, 0, bytesToRead);

        lastPosition += bytesRead;

        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
    }
}