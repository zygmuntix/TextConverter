using System.Collections.Generic;
using TextConverter.Models;

namespace TextConverter.Dtos
{
    /// <summary>
    /// Text data transfer object. Used when sending data between client
    /// (jQuery/Javascript code) and server (Web Api Controllers).
    /// </summary>
    public class TextDto
    {
        public int Id { get; set; }

        public string TextToConvert { get; set; }

        public virtual IList<Sentence> Sentences { get; set; }

        public string ResultType { get; set; }
    }
}