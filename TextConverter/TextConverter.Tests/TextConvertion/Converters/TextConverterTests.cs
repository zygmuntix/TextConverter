using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TextConverter.Models;
using TextConverter.TextConvertion;
using TextConverter.TextConvertion.Converters;

namespace TextConverter.Tests.TextConvertion.Converters
{
    [TestClass]
    public abstract class TextConverterTests
    {
        protected static ITextFactory textFactory;
        protected static ITextSorter textSorter;
        protected static ITextConverter textConverter;

        protected void ConvertTextTestCommon(string fileWithStringToConvert,
                                             string fileWithExpectedResult)
        {
            string stringToConvert = File.ReadAllText(fileWithStringToConvert);

            Text textToConvert = CreateTextFromString(stringToConvert);
            string actualCsvResult = textConverter.ConvertText(textToConvert);

            string expectedCsvResult = File.ReadAllText(fileWithExpectedResult);
            Assert.AreEqual(expectedCsvResult, actualCsvResult);
        }

        private Text CreateTextFromString(string textToConvert)
        {
            // First modify Text by parsing and sorting it.
            Text parsedText = textFactory.CreateText(textToConvert);
            Text sortedText = textSorter.Sort(parsedText);

            return sortedText;
        }
    }
}
