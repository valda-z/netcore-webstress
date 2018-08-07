﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStress.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [Route("/")]
        public string Probe()
        {
            DateTime start = DateTime.Now;

            {
                var sha1 = System.Security.Cryptography.SHA1.Create();

                byte[] hash = new byte[32];
                System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(hash);
                for (int i = 0; i < (256*1024); i++)
                {
                    hash = sha1.ComputeHash(hash);
                }
            }

            var ts = DateTime.Now - start;

            return string.Format("execution time: {0}ms", ts.TotalMilliseconds);
        }
    }
}
