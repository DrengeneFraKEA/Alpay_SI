using Microsoft.AspNetCore.Mvc;
using SI_02a_Data.services;

namespace SI_02a_Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SI02aController : ControllerBase
    {
        private readonly ParseService parseService;
        public SI02aController(ParseService service)
        {
            parseService = service;
        }

        [HttpGet("txt")]
        public string GetTxt() 
        {
            return parseService.ParseTxt();
        }

        [HttpGet("csv")]
        public string GetCsv()
        {
            return parseService.ParseCsv();
        }

        [HttpGet("xml")]
        public string GetXml()
        {
            return parseService.ParseXml();
        }

        [HttpGet("yaml")]
        public string GetYaml()
        {
            return parseService.ParseYaml();
        }

        [HttpGet("json")]
        public string GetJson()
        {
            return parseService.ParseJson();
        }
    }
}
