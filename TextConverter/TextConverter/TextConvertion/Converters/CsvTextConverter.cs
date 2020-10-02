using System.Text;
using TextConverter.Models;

namespace TextConverter.TextConvertion.Converters
{
    public class CsvTextConverter : ITextConverter
    {
        /// <summary>
        /// Converts Text into Csv string.
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>Csv string</returns>
        public string ConvertText(Text text)
        {
            int numberOfColumns = CalculateNumberOfColumns(text);

            StringBuilder csvStringBuilder = new StringBuilder("");
            for (int i = 1; i < numberOfColumns; i++)
            {
                csvStringBuilder.Append("Word " + i + ", ");
            }

            // Add last word.
            csvStringBuilder.AppendLine("Word " + numberOfColumns);

            foreach (Sentence sentence in text.Sentences)
            {
                csvStringBuilder.Append("Sentence " + sentence.Id + ", ");

                int j = 1;
                foreach (Word word in sentence.Words)
                {
                    csvStringBuilder.Append(word.Text);

                    if (j != sentence.Words.Count)
                    {
                        csvStringBuilder.Append(", ");
                    }

                    j++;
                }

                if (sentence.Id != text.Sentences.Count)
                {
                    csvStringBuilder.AppendLine();
                }
            }

            return csvStringBuilder.ToString();
        }

        /// <summary>
        /// Calculates number of columns for CSV file created from Text.
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Calculated number of columns</returns>
        private int CalculateNumberOfColumns(Text text)
        {
            int maxWordCount = 0;

            foreach (Sentence sentence in text.Sentences)
            {
                if (sentence.Words.Count > maxWordCount)
                {
                    maxWordCount = sentence.Words.Count;
                }
            }

            return maxWordCount;
        }
    }
}
