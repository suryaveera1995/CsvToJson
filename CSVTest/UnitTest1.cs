using Xunit;
using CsvToJson;
using System.IO;

namespace CSVTest
{
    public class CSVSimpleTest
    {
        private readonly CsvToJsonSimple csvsimple;
        public CSVSimpleTest()
        {
            csvsimple = new CsvToJsonSimple();
        }
        [Fact]
        public void JsonFileCreated()
        {
            //Arrange
            string inputFile = "../../../../India2011.csv";
            string outputFile = "../../../../India2011.json";

            //Act
            csvsimple.JsonParser(inputFile,outputFile);
         
            //Assert
            Assert.True(File.Exists(outputFile));
        }
    }
}
