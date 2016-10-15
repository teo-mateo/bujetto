using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bujetto.webapi.Controllers
{
    [Route("api")]
    public class EntrypointController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Bujetto API Running! and updated again and again";
        } 
    }
}
