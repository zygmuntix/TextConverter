using System.Collections.Generic;

namespace TextConverter.Models
{
    /// <summary>
    /// Sentence containing Words.
    /// </summary>
    public class Sentence
    {
        public int Id { get; set; }

        public virtual IList<Word> Words { get; set; }
    }
}
