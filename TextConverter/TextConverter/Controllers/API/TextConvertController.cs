using Microsoft.AspNetCore.Mvc;
using TextConverter.Models;
using TextConverter.TextConvertion;
using TextConverter.TextConvertion.Converters;

namespace TextConverter_Nordea.Controllers.API
{
    /// <summary>
    /// ApiController used for Text convertions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TextConvertController : ControllerBase
    {
        private ITextFactory textFactory;
        private ITextSorter textSorter;

        public TextConvertController(ITextFactory textFactory, ITextSorter textSorter)
        {
            this.textFactory = textFactory;
            this.textSorter = textSorter;
        }

        /// <summary>
        /// Url for API: POST /api/textconvert
        /// Modifies text and converts it into format specified
        /// in textDto ResultType.
        /// </summary>
        /// <param name="text">Text object</param>
        /// <returns>HttpResponseMessage with modified Text in string format</returns>
        [HttpGet]
        public string GetConvertedText(string textToConvert, string resultType)
        {
            if (!ModelState.IsValid)
            {
                return string.Empty;
            }
            
            // First modify Text by parsing and sorting it.
            Text parsedText = textFactory.CreateText(textToConvert);
            Text sortedText = textSorter.Sort(parsedText);

            // Convert Text into appropiate format.
            ITextConverter textConverter;
            if (resultType == "xml")
            {
                textConverter = new XmlTextConverter();
            }
            else
            {
                textConverter = new CsvTextConverter();
            }

            string result = textConverter.ConvertText(sortedText);
            return result;
        }
    }
}
