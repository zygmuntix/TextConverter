using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TextConverter.Models
{
    public class Text
    {
        [HiddenInput]
        public int Id { get; set; }

        public string TextToConvert { get; set; }

        public virtual IList<Sentence> Sentences { get; set; }
    }
}
