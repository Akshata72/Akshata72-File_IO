using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

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
        public static void ReadCsvFile()
        {
            string path = @"D:\Ak\programs\Akshata72-File_IO\IO File\File\AddressBook.csv";
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Person>().ToList();
                    Console.WriteLine("Read Data successfully from address csv.");
                    foreach (Person record in records)
                    {
                        Console.Write("" + record.firstname);
                        Console.Write("|" + record.lastname);
                        Console.Write("|" + record.address);
                        Console.Write("|" + record.city);
                        Console.Write("|" + record.state);
                        Console.Write("|" + record.zip);
                        Console.Write("|" + record.phonenumber);
                        Console.Write("|" + record.email + "\n");
                    }
                }
            }
        }
        public static void WriteCsvFile()
        {
            string exportpath = @"D:\Ak\programs\Akshata72-File_IO\IO File\File\Address.csv";
            string path = @"D:\Ak\programs\Akshata72-File_IO\IO File\File\AddressBook.csv";
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Person>().ToList();
                    Console.WriteLine("Read Data successfully from address csv.");
                    foreach (Person record in records)
                    {
                        Console.Write("" + record.firstname);
                        Console.Write("|" + record.lastname);
                        Console.Write("|" + record.address);
                        Console.Write("|" + record.city);
                        Console.Write("|" + record.state);
                        Console.Write("|" + record.zip);
                        Console.Write("|" + record.phonenumber);
                        Console.Write("|" + record.email + "\n");
                    }
                    using (var writer = new StreamWriter(exportpath))
                    using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvExport.WriteRecords(records);
                    }
                }
            }
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
                Console.WriteLine("Enter 3 For Csv reader");
                Console.WriteLine("Enter 4 for Csv writer");
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
                        case 3:
                            ReadCsvFile();
                            break;
                        case 4:
                            WriteCsvFile();
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
