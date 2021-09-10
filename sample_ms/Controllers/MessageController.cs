using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sample_ms.Models;

namespace sample_ms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public ActionResult<DemoResponse> Get(DemoEntity demo)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            string sentence = demo.Category;
            DemoResponse demoResponse = new()
            {
                TotalVowels = sentence.Count(c => vowels.Contains(c))
            };
            return demoResponse;
        }
    }
}