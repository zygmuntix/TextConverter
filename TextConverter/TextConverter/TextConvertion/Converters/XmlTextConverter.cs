using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TextConverter.Models;

namespace TextConverter.TextConvertion.Converters
{
    public class XmlTextConverter: ITextConverter
    {
        /// <summary>
        /// Converts Text into xml string.
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>Xml string converted from Text</returns>
        public string ConvertText(Text text)
        {
            XmlDocument xmlDocument = ConvertTextToXmlDocument(text);

            // Parse xml document so that all indices and new lines will be set.
            XDocument parsedDocument = XDocument.Parse(xmlDocument.InnerXml);

            // Save XDocument to TextWriter to get utf-8 encoded document at the end.
            StringBuilder stringBuilder = new StringBuilder();
            using (TextWriter writer = new StringWriterUtf8(stringBuilder))
            {
                parsedDocument.Save(writer);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts Text to XmlDocument.
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>Converted XmlDocument</returns>
        private XmlDocument ConvertTextToXmlDocument(Text text)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(docNode);

            XmlNode textNode = doc.CreateElement("text");
            doc.AppendChild(textNode);

            foreach (Sentence sentence in text.Sentences)
            {
                XmlNode sentenceNode = doc.CreateElement("sentence");
                textNode.AppendChild(sentenceNode);

                foreach (Word word in sentence.Words)
                {
                    XmlNode wordNode = doc.CreateElement("word");
                    wordNode.InnerText = word.Text;

                    sentenceNode.AppendChild(wordNode);
                }
            }
            return doc;
        }
    }
}
