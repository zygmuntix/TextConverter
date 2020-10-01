using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter.Models;
using TextConverter.TextConvertion.Converters;

namespace TextConverter.Tests.TextConvertion.Converters
{
    [TestClass]
    public class CsvTextConverterTests
    {
        [TestMethod]
        [DeploymentItem("TestData/ConvertTextToCsv.csv")]
        public void ConvertTextToCsvTest()
        {
            Text textToConvert = SampleTextGenerator.CreateTextToConvert();
            string expectedCsvString = File.ReadAllText("ConvertTextToCsv.csv");

            CsvTextConverter csvTextConverter = new CsvTextConverter();
            string actualCsvString = csvTextConverter.ConvertText(textToConvert);

            Assert.AreEqual(expectedCsvString, actualCsvString);
        }
    }
}
