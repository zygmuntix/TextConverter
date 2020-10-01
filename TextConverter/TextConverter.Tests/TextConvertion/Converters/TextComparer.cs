using TextConverter.Models;

namespace TextConverter.Tests.TextConvertion.Converters
{
    public class TextComparer
    {
        /// <summary>
        /// Compares two Text objects.
        /// </summary>
        /// <param name="text1">Text 1</param>
        /// <param name="text2">Text 2</param>
        /// <returns>True if Texts are equal. False otherwise.</returns>
        public static bool CompareTexts(Text text1, Text text2)
        {
            if (text1.Sentences.Count != text2.Sentences.Count ||
                text1.TextToConvert != text2.TextToConvert ||
                text1.Id != text2.Id)
            {
                return false;
            }

            int sentenceI = 0;
            foreach (Sentence sentenceText1 in text1.Sentences)
            {

                Sentence sentenceText2 = text2.Sentences[sentenceI];

                if (sentenceText1.Words.Count != sentenceText2.Words.Count ||
                    sentenceText1.Id != sentenceText2.Id)
                {
                    return false;
                }

                int wordI = 0;
                foreach (Word wordSentence1 in sentenceText1.Words)
                {
                    Word wordSentence2 = sentenceText2.Words[wordI];

                    if (!wordSentence1.Text.Equals(wordSentence2.Text) ||
                        wordSentence1.Id != wordSentence2.Id)
                    {
                        return false;
                    }

                    wordI++;
                }

                sentenceI++;
            }

            return true;
        }
    }
}
