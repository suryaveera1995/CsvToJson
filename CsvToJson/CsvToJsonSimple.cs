using System;
using System.IO;
using System.Text;

namespace CsvToJson
{
    public class CsvToJsonSimple
    {
        public void JsonParser(string source,string destination)
        {
            try
            {
                StreamReader csvFilereader = new StreamReader(new FileStream(source, FileMode.Open));
                string[] headers = csvFilereader.ReadLine().Split(separator: ',');
                StringBuilder sbr = new StringBuilder();

                using (FileStream fs = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("[");
                        while (!csvFilereader.EndOfStream)
                        {
                            string[] data = csvFilereader.ReadLine().Split(separator: ',');//Row of csv file is converted to an array of Strings
                            sbr.Append("{");
                            int counter = 0;
                            while (counter < headers.Length)
                            {
                                sbr.Append(string.Format("\"{0}\":\"{1}\"", headers[counter], data[counter]));
                                if (counter != (headers.Length - 1))
                                {
                                    sbr.Append(",");
                                }
                                counter++;
                            }
                            sbr.Append("}");
                            if (!csvFilereader.EndOfStream) { sbr.Append(","); }
                            sw.WriteLine(sbr.ToString());
                            sw.Flush();
                            sbr.Clear();
                        }
                        sw.WriteLine("]");
                        sw.Close();
                        sw.Dispose();
                    }
                    fs.Close();
                    fs.Dispose();
                }
                csvFilereader.Close();
                csvFilereader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
        }
    }
}
