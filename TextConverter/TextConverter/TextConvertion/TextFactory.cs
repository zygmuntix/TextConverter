﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using TextConverter.Models;

namespace TextConverter.TextConvertion
{
    /// <summary>
    /// TextFactory is class that creates Text object
    /// with Sentences containing Words from string.
    /// </summary>
    public class TextFactory : ITextFactory
    {
        #region Operations

        /// <summary>
        /// Creates Text object from string.
        /// </summary>
        /// <returns>Parsed Text object</returns>
        public Text CreateText(string textToParse)
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
            char[] sentenceSeparators = new char[] { '.', '?', '!' };
            string[] sentences = trimmedText.Split(sentenceSeparators);

            int sentenceNr = 1;
            foreach (string sentenceText in sentences)
            {
                // Replace all occurences of such elements with space: , ; : -
                string trimmedSentence = Regex.Replace(sentenceText, @"[,|;|:|-]", " ");

                // Remove all whitespaces from beginning and end of the sentence text.
                trimmedSentence = trimmedSentence.Trim();

                // Replace any occurence of multiple whitespaces with only one space.
                trimmedSentence = Regex.Replace(trimmedSentence, @"\s+", " ");

                // Split sentence into words using all possible whitespaces as delimiters.
                string[] sentenceWords = trimmedSentence.Split(null);

                Sentence sentence = new Sentence { Id = sentenceNr, Words = new List<Word>() };

                int wordId = 1;
                foreach (string wordText in sentenceWords)
                {
                    Word word = new Word { Id = wordId, Text = wordText };
                    sentence.Words.Add(word);

                    wordId++;
                }

                textResult.Sentences.Add(sentence);
                sentenceNr++;
            }

            return textResult;
        }

        #endregion
    }
}
