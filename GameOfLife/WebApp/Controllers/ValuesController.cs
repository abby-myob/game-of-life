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
            string display = GenerateOutput.GetOutputString(Program.game.World);
            string responseString = @"
            <div style='text-align:center;'> 
            <h1 style='padding-top:10%; padding-bottom:20px;'>
                Game of Life
            </h1>" + $"<pre>{display}<pre> " +
                                    "<form action=\"\" method=\"get\"> " +
                                    "<button name=\"foo\" value=\"tick \">" +
                                    "tick" +
                                    "</button>" +
                                    "</form>" +
                                    "</div>";
            return responseString;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                List<string> input = new List<string>();
                input.Add(await reader.ReadLineAsync());
                input.Add(await reader.ReadLineAsync());

                GenerateInput genInput = new GenerateInput(input);

                var worldSize = genInput.GetWorldSize();
                var cellCount = worldSize[0] * worldSize[1];
                var initialInput = genInput.GetInitialInput();

                Program.game.Start(initialInput, cellCount, worldSize);
            }

            return "post successful";
        }

//        [HttpPost]
//        public async Task<string> Tick()
//        {
//            Program.game.Tick();
//
//            return "post successful";
//        }
    }

    public class HtmlOutputFormatter : StringOutputFormatter
    {
        public HtmlOutputFormatter()
        {
            SupportedMediaTypes.Add("text/html");
        }
    }
}