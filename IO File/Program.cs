using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOStream
{
    public class FileIO
    {
        public void ReadAddressBook()
        {
            string path = @"D:\Ak\programs\Akshata72-File_IO\IO File\File\AddressBook.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (string item in lines)
            {
                Console.WriteLine(item);
            }
        }
        public void WriteLine()
        {
            string path = @"D:\Ak\programs\Akshata72-File_IO\IO File\File\AddressBook.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (string item in lines)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nEnter what you want Add in text file...");
            string line = Console.ReadLine();
            lines.Add(line);
            File.WriteAllLines(path, lines);
        }
        static void Main(string[] args)
        {
            FileIO file = new FileIO();
            Console.WriteLine("Welcome to File IO...");
            int Option = 0;
            do
            {
                Console.WriteLine("\nEnter 1 for ReadFile");
                Console.WriteLine("Enter 2 for Write Text in file");
                Console.WriteLine("Enter 0 For Exist");
                try
                {
                    Option = int.Parse(Console.ReadLine());
                    switch (Option)
                    {
                        case 1:
                            file.ReadAddressBook();
                            break;
                        case 2:
                            file.WriteLine();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please Choose Correct option");
                }
            }
            while (Option != 0);
        }
    }
}
