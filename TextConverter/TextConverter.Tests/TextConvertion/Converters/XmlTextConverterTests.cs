using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter.Models;
using TextConverter.TextConvertion.Converters;

namespace TextConverter.Tests.TextConvertion.Converters
{
    [TestClass]
    public class XmlTextConverterTest
    {
        [TestMethod]
        [DeploymentItem("TestData/ConvertTextToXml.xml")]
        public void ConvertTextToXmlTest()
        {
            Text textToConvert = SampleTextGenerator.CreateTextToConvert();
            string expectedXmlString = File.ReadAllText("ConvertTextToXml.xml");

            XmlTextConverter xmlTextConverter = new XmlTextConverter();
            string actualCsvString = xmlTextConverter.ConvertText(textToConvert);

            Assert.AreEqual(expectedXmlString, actualCsvString);
        }

        public TestContext TestContext { get; set; }
    }
}
