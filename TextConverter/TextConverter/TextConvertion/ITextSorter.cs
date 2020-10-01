using TextConverter.Models;

namespace TextConverter.TextConvertion
{
    public interface ITextSorter
    {
        Text Sort(Text textToSort);
    }
}