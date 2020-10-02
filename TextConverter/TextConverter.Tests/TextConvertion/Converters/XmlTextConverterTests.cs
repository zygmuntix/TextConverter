using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter.TextConvertion;
using TextConverter.TextConvertion.Converters;

namespace TextConverter.Tests.TextConvertion.Converters
{
    [TestClass]
    public class XmlTextConverterTests : TextConverterTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            textFactory = new TextFactory();
            textSorter = new TextSorter();
            textConverter = new XmlTextConverter();
        }

        [TestMethod]
        [DeploymentItem("TestData/ConvertText/SimpleTest.xml")]
        [DeploymentItem("TestData/ConvertText/SimpleTest.txt")]
        public void ConvertTextToXmlSimpleTest()
        {
            ConvertTextTestCommon("SimpleTest.txt", "SimpleTest.xml");
        }

        [TestMethod]
        [DeploymentItem("TestData/ConvertText/SimpleTest.xml")]
        [DeploymentItem("TestData/ConvertText/SimpleTestWhitespace.txt")]
        public void ConvertTextToXmlSimpleTestWhitespace()
        {
            ConvertTextTestCommon("SimpleTestWhitespace.txt", "SimpleTest.xml");
        }

        [TestMethod]
        [DeploymentItem("TestData/ConvertText/LongTest.xml")]
        [DeploymentItem("TestData/ConvertText/LongTest.txt")]
        public void ConvertTextToXmlLongTest()
        {
            ConvertTextTestCommon("LongTest.txt", "LongTest.xml");
        }
    }
}
