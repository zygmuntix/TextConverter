using TextConverter.Models;

namespace TextConverter.TextConvertion
{
    public interface ITextFactory
    {
        Text CreateText(string textToParse);
    }
}