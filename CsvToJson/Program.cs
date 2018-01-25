using System;
using System.Diagnostics;
using System.IO;

namespace CsvToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvToJsonSimple obj = new CsvToJsonSimple();
            if (args.Length > 0)
            {
                obj.JsonParser(args[0], args[1]);
            }
            else
            {
                var path = System.AppDomain.CurrentDomain.BaseDirectory;
                string rootPath =Path.GetFullPath(path + "../../../");
                obj.JsonParser(rootPath+"./Data/India2011.csv",rootPath+ "./Data/Simple.json");
            }

            Console.WriteLine("File Processing is completed!");
        }
    }
}
