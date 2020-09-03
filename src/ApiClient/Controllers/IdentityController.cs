using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace MyWebAPI.Controllers
{
    public class IdentityController : ControllerBase
    {
        [Route("/")]
        public async Task<ActionResult> Get()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return Ok(disco.Error);
            }
            return Ok( "Token Endpoint:"+ disco.TokenEndpoint);
        }
    }
}