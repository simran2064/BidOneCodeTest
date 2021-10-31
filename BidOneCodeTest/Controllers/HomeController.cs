using BidOneCodeTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BidOneCodeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly BidOneTestContext _cc;
        public HomeController(BidOneTestContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TestData td)
        {
            _cc.Add(td);
            _cc.SaveChanges();
            ViewBag.message = "This user " + td.FirstName + " " + td.LastName + " was saved successfully";
            return View();
        }

    }
}
