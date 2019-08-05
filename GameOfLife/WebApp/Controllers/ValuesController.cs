using System;
using System.Collections.Generic;
using System.Linq;
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
            </h1>" + $"<pre>{display}<pre> </div>";
            return responseString;
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