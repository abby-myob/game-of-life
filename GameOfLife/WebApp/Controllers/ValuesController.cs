using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApp.Controllers
{
    [Route("api/conway")]
    [ApiController]
    public class GameOfLifeController : ControllerBase
    {
        [HttpGet]
        [Produces("text/html")]
        public string Get()
        {
            Program.game.Tick();
            string display = Program.game.Output();
            string responseString = @"
            <div style='text-align:center;'> 
            <h1 style='padding-top:10%; padding-bottom:20px;'>
                Game of Life
            </h1>" + $"<pre>{display}<pre> " +
                                    "<form action=\"\" method=\"post\"> " +
                                        "<button name=\"foo\" value=\"upvote\">" +
                                            "Upvote" +
                                        "</button>" +
                                    "</form>" +
            "</div> " ;
            return responseString;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                string input = await reader.ReadToEndAsync();
                // Do something with the string 'input' here...
            }

            return "post successful";
        }
    }

    public class HtmlOutputFormatter : StringOutputFormatter
    {
        public HtmlOutputFormatter()
        {
            SupportedMediaTypes.Add("text/html");
        }
    }
}