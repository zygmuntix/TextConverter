using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter.TextConvertion;
using TextConverter.TextConvertion.Converters;

namespace TextConverter.Tests.TextConvertion.Converters
{
    [TestClass]
    public class CsvTextConverterTests : TextConverterTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            textFactory = new TextFactory();
            textSorter = new TextSorter();
            textConverter = new CsvTextConverter();
        }

        [TestMethod]
        [DeploymentItem("TestData/ConvertText/SimpleTest.csv")]
        [DeploymentItem("TestData/ConvertText/SimpleTest.txt")]
        public void ConvertTextToCsvSimpleTest()
        {
            ConvertTextTestCommon("SimpleTest.txt", "SimpleTest.csv");
        }

        [TestMethod]
        [DeploymentItem("TestData/ConvertText/SimpleTest.csv")]
        [DeploymentItem("TestData/ConvertText/SimpleTestWhitespace.txt")]
        public void ConvertTextToCsvSimpleWhitespaceTest()
        {
            ConvertTextTestCommon("SimpleTestWhitespace.txt", "SimpleTest.csv");
        }

        [TestMethod]
        [DeploymentItem("TestData/ConvertText/LongTest.csv")]
        [DeploymentItem("TestData/ConvertText/LongTest.txt")]
        public void ConvertTextToCsvLongTest()
        {
            ConvertTextTestCommon("LongTest.txt", "LongTest.csv");
        }
    }
}
