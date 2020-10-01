using System.Collections.Generic;
using TextConverter.Models;

namespace TextConverter.Tests.TextConvertion.Converters
{
    public class SampleTextGenerator
    {
        public static Text CreateTextToConvert()
        {
            string textToConvertString = "";

            List<Word> wordsForSentence1 = new List<Word>
            {
                new Word { Id = 1, Text = "a"},
                new Word { Id = 2, Text = "had"},
                new Word { Id = 3, Text = "lamb"},
                new Word { Id = 4, Text = "little"},
                new Word { Id = 5, Text = "Mary"}
            };
            Sentence sentence1 = new Sentence
            {
                Id = 1,
                Words = wordsForSentence1
            };

            List<Word> wordsForSentence2 = new List<Word>
            {
                new Word { Id = 1, Text = "Aesop"},
                new Word { Id = 2, Text = "and"},
                new Word { Id = 3, Text = "called"},
                new Word { Id = 4, Text = "came"},
                new Word { Id = 5, Text = "for"},
                new Word { Id = 6, Text = "Peter"},
                new Word { Id = 7, Text = "the"},
                new Word { Id = 8, Text = "wolf"}
            };
            Sentence sentence2 = new Sentence
            {
                Id = 2,
                Words = wordsForSentence2
            };

            List<Word> wordsForSentence3 = new List<Word>
            {
                new Word { Id = 1, Text = "Cinderella"},
                new Word { Id = 2, Text = "likes"},
                new Word { Id = 3, Text = "shoes"}
            };
            Sentence sentence3 = new Sentence
            {
                Id = 3,
                Words = wordsForSentence3
            };

            List<Sentence> sentences = new List<Sentence> { sentence1, sentence2, sentence3 };

            Text textToConvert = new Text
            {
                Id = 1,
                Sentences = sentences,
                TextToConvert = textToConvertString
            };

            return textToConvert;
        }
    }
}
