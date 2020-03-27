using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFDemoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : Controller
    {
        readonly OgrenciContext Context;
        public OgrenciController(OgrenciContext c)
        {
            Context = c;
        }

        [HttpGet]
        public IActionResult GetOgrenci()
        {
            var veri = Context.Ogrenci.ToList();
            return Ok(veri);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult CreateOgrenci()
        {
            var veri = new Ogrenci()
            {
                isim = "ömer",
                girisyili = 2001,
                dogumtarihi = new DateTime(2020, 01, 01),
                dogumyeri="istanbul"
                ///  soyisim = "altintas"
            };

            Context.Add(veri);
            Context.SaveChanges();

            return Ok("success");
        }
    }
}
