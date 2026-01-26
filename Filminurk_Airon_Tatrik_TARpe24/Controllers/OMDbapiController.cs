﻿using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class OMDbapiController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}