using TextConverter.Models;

namespace TextConverter.TextConvertion.Converters
{
    /// <summary>
    /// Interface for Text Converters.
    /// </summary>
    public interface ITextConverter
    {
        string ConvertText(Text text);
    }
}
