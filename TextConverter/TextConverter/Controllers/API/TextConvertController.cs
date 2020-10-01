using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using TextConverter.Dtos;
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
        /// <param name="textDto">Text DTO</param>
        /// <returns>HttpResponseMessage with modified Text in string format</returns>
        [HttpPost]
        public string ModifyText(TextDto textDto)
        {
            if (!ModelState.IsValid)
            {
                return "";
            }
            
            // First modify Text by parsing and sorting it.
            TextParser textParser = new TextParser(textDto.TextToConvert);
            Text parsedText = textParser.ParseToTextObject();

            TextSorter textSorter = new TextSorter();
            Text sortedText = textSorter.Sort(parsedText);

            // Convert Text into appropiate format.
            ITextConverter textConverter;
            string fileExtension;

            if (textDto.ResultType == "xml")
            {
                textConverter = new XmlTextConverter();
                fileExtension = "xml";
            }
            else
            {
                // Should be csv, so convert text to csv.
                textConverter = new CsvTextConverter();
                fileExtension = "csv";
            }

            // Save converted Text string to result file.
            string resultsDirectoryPath = Path.Combine(_env.WebRootPath, "~/Results");
            string filePath = _env.WebRootPath + "/result." + fileExtension;
            string result = textConverter.ConvertText(sortedText);
            System.IO.File.WriteAllText(filePath, result);

            // Return response with content containing Text converted into string.
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "result." + fileExtension
            };

            return result;
        }
    }
}
