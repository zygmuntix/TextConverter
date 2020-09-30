using System.IO;
using System.Text;

namespace TextConverter.TextConvertion.Converters
{
    /// <summary>
    /// Subclass of StringWriter created to return xml with utf-8 encoding.
    /// </summary>
    public class StringWriterUtf8 : StringWriter
    {
        public StringWriterUtf8(StringBuilder sb)
            : base(sb)
        {
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}