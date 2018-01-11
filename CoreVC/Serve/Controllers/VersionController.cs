﻿using Microsoft.AspNetCore.Mvc;

namespace CoreVC.Serve.Controllers
{
    using Models;

    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        [HttpGet]
        public Version Get()
        {
            return new Version() { Major = 0, Minor = 1, Build = 1 };
        }
    }
}
