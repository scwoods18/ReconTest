using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReconTest.Domain.Entities;
using ReconTest.Services.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconTest.API.Controllers
{
    //public class Result
    //{
    //    public string subtext { get; set; }
    //    public string result { get; set; }
    //}

    //public class Candidate
    //{
    //    public string candidate { get; set; }
    //    public string text { get; set; }
    //    public List<Result> results { get; set; }
    //}



    //public class SubTextModel
    //{
    //    public SubTextModel() { }
    //    public string[] subTexts { get; set; }
    //}


    //public class TextModel
    //{
    //    public TextModel( string _text) 
    //    {
    //       text = _text;
    //    }
        
    //    public string text { get; set; }
    //}

    [ApiController]
    [Route("/test2")]
    public class TextController : ControllerBase
    {
        private readonly ILogger<TextController> _logger;
        private readonly IText _textService;

        public TextController(ILogger<TextController> logger, IText textService)
        {
            _logger = logger;
            _textService = textService;
        }

       
        [HttpPost]
        [Route("textToSearch/{text}")]
        public async Task<IActionResult> InsertText([FromRoute] string text)
        {
            try
            {
                _logger.LogInformation($"Inserting text name: {text} for search processing");

                var textModel = new Text(text);
                HttpContext.Session.SetString("text", text);
                return new JsonResult(JsonConvert.SerializeObject(textModel));
                _logger.LogInformation($"Text name: {text} has been added for text processing");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("subTexts")]
        public async Task<IActionResult> InsertSubText([FromQuery(Name ="text")] string[] subTexts)
        {
            try
            {
                _logger.LogInformation($"Inserting subtexts for search processing");
                var subTextModel = new SubText(subTexts);
                HttpContext.Session.SetString("subTexts", JsonConvert.SerializeObject(subTexts));
                return new JsonResult(JsonConvert.SerializeObject(subTextModel));
                _logger.LogInformation($"Subtexts has been added for text processing");

            }

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("submitResults/{candidate}")]
        public async Task<IActionResult> ShowTextResults([FromRoute] string candidate)
        {
            try
            {
                _logger.LogInformation("Showing the text and subtext processing result...");

                var jsonSubTexts = HttpContext.Session.GetString("subTexts");

                if (String.IsNullOrEmpty(jsonSubTexts))
                    return NotFound();

                var text = HttpContext.Session.GetString("text");
                string[] subTexts = (string[])JsonConvert.DeserializeObject(jsonSubTexts, typeof(string[]));
                var candidateModel = new Candidate(candidate, text);
                foreach (string subText in subTexts)
                {
                    List<int> indexes = await _textService.FindSubTextIndexes(text, subText);
                    StringBuilder indexbuilder = new StringBuilder();
                   
                    foreach (int i  in indexes)
                        indexbuilder.Append(i.ToString()).Append(",");
                  
                    if (indexes.Count >= 1)
                        candidateModel.Results.Add(new Result(subText, indexbuilder.ToString().TrimEnd(new char[] { ',' })));
                    else 
                        candidateModel.Results.Add(new Result(subText, "<No Output>"));
                }
                _logger.LogInformation("Text processing result has been shown successfully.");


                return new JsonResult(JsonConvert.SerializeObject(candidateModel));
            }

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
