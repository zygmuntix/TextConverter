using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TextConverter.Models;

namespace TextConverter.TextConvertion
{
    /// <summary>
    /// TextSorter is class for sorting Text object.
    /// It sorts Words in Text in American alphabetical order.
    /// </summary>
    public class TextSorter : ITextSorter
    {
        /// <summary>
        /// Sorts Words in Text in American alphabet order.
        /// </summary>
        /// <param name="textToSort">Text to sort</param>
        /// <returns>Sorted Text</returns>
        public Text Sort(Text textToSort)
        {
            IList<Sentence> sentences = textToSort.Sentences;
            foreach (Sentence sentence in sentences)
            {
                List<Word> words = sentence.Words.ToList();
                words.Sort((x, y) => string.Compare(x.Text, y.Text, true, new CultureInfo("en-US")));

                int wordI = 1;
                foreach (Word word in words)
                {
                    word.Id = wordI;
                    wordI++;
                }

                sentence.Words = words;
            }

            return textToSort;
        }
    }
}