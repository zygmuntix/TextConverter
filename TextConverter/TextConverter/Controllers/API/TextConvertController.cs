using Microsoft.AspNetCore.Hosting;
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
        private IWebHostEnvironment _env;

        public TextConvertController(IWebHostEnvironment env)
        {
            _env = env;
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
            TextParser textParser = new TextParser(textToConvert);
            Text parsedText = textParser.ParseToTextObject();

            TextSorter textSorter = new TextSorter();
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
