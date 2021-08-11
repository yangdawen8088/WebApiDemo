using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDataDemo()
        {
            return Ok("网络请求成功！");
        }
    }
}
