using System.Collections.Generic;

namespace TextConverter.Models
{
    public class Text
    {
        public int Id { get; set; }

        public string TextToConvert { get; set; }

        public virtual IList<Sentence> Sentences { get; set; }
    }
}
