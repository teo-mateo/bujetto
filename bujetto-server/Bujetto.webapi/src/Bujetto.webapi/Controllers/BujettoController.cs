using Bujetto.webapi.BujettoDB;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bujetto.webapi.Controllers
{

    public class BujettoController : Controller
    {
        protected BujettoDbContext _db;
        public BujettoController(BujettoDbContext db)
        {
            _db = db;
        }
    }
}
