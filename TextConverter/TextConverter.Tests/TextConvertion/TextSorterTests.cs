using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TextConverter.Models;
using TextConverter.Tests.TextConvertion.Converters;
using TextConverter.TextConvertion;

namespace TextConverter.Tests.TextConvertion
{
    [TestClass]
    public class TextSorterTests
    {
        [TestMethod]
        public void SortTest()
        {
            Text textToSort = CreateTextForSortTest();
            Text expectedText = CreateExpectedText();

            TextSorter textSorter = new TextSorter();
            Text actualText = textSorter.Sort(textToSort);

            Assert.IsTrue(TextComparer.CompareTexts(expectedText, actualText));
        }

        /// <summary>
        /// Creates Text that will be used in TextParserTest.
        /// </summary>
        /// <returns>Text to test</returns>
        private Text CreateTextForSortTest()
        {
            List<Word> wordsForSentence1 = new List<Word>
            {
                new Word { Id = 1, Text = "Ala"}
            };
            Sentence sentence1 = new Sentence
            {
                Id = 1,
                Words = wordsForSentence1
            };

            List<Word> wordsForSentence2 = new List<Word>
            {
                new Word { Id = 1, Text = ""}
            };
            Sentence sentence2 = new Sentence
            {
                Id = 2,
                Words = wordsForSentence2
            };

            List<Word> wordsForSentence3 = new List<Word>
            {
                new Word { Id = 1, Text = "Kot1"},
                new Word { Id = 2, Text = "hulajnoga"},
                new Word { Id = 3, Text = "Ala"},
                new Word { Id = 4, Text = "Kot2"}
            };
            Sentence sentence3 = new Sentence
            {
                Id = 3,
                Words = wordsForSentence3
            };

            List<Word> wordsForSentence4 = new List<Word>
            {
                new Word { Id = 1, Text = "Pies"},
                new Word { Id = 2, Text = "gepard"},
                new Word { Id = 3, Text = "To"},
                new Word { Id = 4, Text = "jest"},
                new Word { Id = 5, Text = "zwierzę"},
                new Word { Id = 6, Text = "lis"}
            };
            Sentence sentence4 = new Sentence
            {
                Id = 4,
                Words = wordsForSentence4
            };

            List<Word> wordsForSentence5 = new List<Word>
            {
                new Word { Id = 1, Text = "Łasica"},
                new Word { Id = 2, Text = "123Text"},
                new Word { Id = 3, Text = "5%"},
                new Word { Id = 4, Text = "5$"}
            };
            Sentence sentence5 = new Sentence
            {
                Id = 5,
                Words = wordsForSentence5
            };

            List<Sentence> sentences = new List<Sentence> { sentence1, sentence2, sentence3,
                sentence4, sentence5 };

            Text textForSort = new Text
            {
                Id = 1,
                Sentences = sentences,
                TextToConvert = ""
            };

            return textForSort;
        }

        /// <summary>
        /// Creates Text that is expected from TextParserTest.
        /// </summary>
        /// <returns>Expected Text</returns>
        private Text CreateExpectedText()
        {
            List<Word> wordsForSentence1 = new List<Word>
            {
                new Word { Id = 1, Text = "Ala"}
            };
            Sentence sentence1 = new Sentence
            {
                Id = 1,
                Words = wordsForSentence1
            };

            List<Word> wordsForSentence2 = new List<Word>
            {
                new Word { Id = 1, Text = ""}
            };
            Sentence sentence2 = new Sentence
            {
                Id = 2,
                Words = wordsForSentence2
            };

            List<Word> wordsForSentence3 = new List<Word>
            {
                new Word { Id = 1, Text = "Ala"},
                new Word { Id = 2, Text = "hulajnoga"},
                new Word { Id = 3, Text = "Kot1"},
                new Word { Id = 4, Text = "Kot2"}
            };
            Sentence sentence3 = new Sentence
            {
                Id = 3,
                Words = wordsForSentence3
            };

            List<Word> wordsForSentence4 = new List<Word>
            {
                new Word { Id = 1, Text = "gepard"},
                new Word { Id = 2, Text = "jest"},
                new Word { Id = 3, Text = "lis"},
                new Word { Id = 4, Text = "Pies"},
                new Word { Id = 5, Text = "To"},
                new Word { Id = 6, Text = "zwierzę"}
            };
            Sentence sentence4 = new Sentence
            {
                Id = 4,
                Words = wordsForSentence4
            };

            List<Word> wordsForSentence5 = new List<Word>
            {
                new Word { Id = 1, Text = "123Text"},
                new Word { Id = 2, Text = "5$"},
                new Word { Id = 3, Text = "5%"},
                new Word { Id = 4, Text = "Łasica"}
            };
            Sentence sentence5 = new Sentence
            {
                Id = 5,
                Words = wordsForSentence5
            };

            List<Sentence> sentences = new List<Sentence> { sentence1, sentence2, sentence3,
                sentence4, sentence5 };

            Text textToConvert = new Text
            {
                Id = 1,
                Sentences = sentences,
                TextToConvert = ""
            };

            return textToConvert;
        }
    }
}