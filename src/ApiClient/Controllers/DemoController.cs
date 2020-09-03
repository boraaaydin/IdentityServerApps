using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityModel;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace MyWebAPI.Controllers
{
    public class DemoController : ControllerBase
    {
        // GET: api/values
        [Route("api/[controller]")]
        public ActionResult<string> Get()
        {
            return "ok";
        }
    }
}