using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextConverter.Models;

namespace TextConverter.TextConvertion
{
    /// <summary>
    /// TextParser is class that converts string
    /// into Text object with Sentences containing Words.
    /// </summary>
    public class TextParser
    {
        #region Operations

        /// <summary>
        /// Creates new TextParser instance.
        /// </summary>
        /// <param name="textToParse">String to be converted into Text object</param>
        public TextParser(string textToParse)
        {
            this.textToParse = textToParse;
        }

        /// <summary>
        /// Parses string to Text object.
        /// </summary>
        /// <returns>Parsed Text object</returns>
        public Text ParseToTextObject()
        {
            if (textToParse == null)
            {
                return null;
            }

            Text textResult = new Text
            {
                Id = 1,
                Sentences = new List<Sentence>(),
                TextToConvert = textToParse
            };

            // Remove all whitespaces from beginning and end of the text.
            string trimmedText = textToParse.Trim();

            // Remove all occurences of . ? ! at the beginning or end of the text.
            trimmedText = trimmedText.Trim('.', '?', '!');

            // Split text into Sentences by using '.', '?' and '!' as delimiters.
            char[] sentenceSeparators = new char[] {'.', '?', '!'};
            string[] sentences = trimmedText.Split(sentenceSeparators);

            int sentenceNr = 1;
            foreach (string sentenceText in sentences)
            {
                // Replace all occurences of such elements with space: , ; : " ' -
                string trimmedSentence = Regex.Replace(sentenceText, @"[,|;|:|""|'|-]", " ");

                // Remove all whitespaces from beginning and end of the sentence text.
                trimmedSentence = trimmedSentence.Trim();

                // Replace any occurence of multiple whitespaces with only one space.
                trimmedSentence = Regex.Replace(trimmedSentence, @"\s+", " ");

                // Split sentence into words using all possible whitespaces as delimiters.
                string[] sentenceWords = trimmedSentence.Split(null);

                Sentence sentence = new Sentence {Id = sentenceNr, Words = new List<Word>()};

                int wordId = 1;
                foreach (string wordText in sentenceWords)
                {
                    // Remove all elements in word, that are not letters or digits.
                    string trimmedWord = new string((from c in wordText
                        where char.IsLetterOrDigit(c)
                        select c
                    ).ToArray());

                    Word word = new Word { Id = wordId, Text = trimmedWord };
                    sentence.Words.Add(word);

                    wordId++;
                }

                textResult.Sentences.Add(sentence);
                sentenceNr++;
            }

            return textResult;
        }

        #endregion

        #region Data Members

        private readonly string textToParse;

        #endregion
    }
}
