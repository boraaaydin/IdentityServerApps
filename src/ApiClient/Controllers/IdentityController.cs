using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace MyWebAPI.Controllers
{
    public class IdentityController : ControllerBase
    {
        private IdentityService _service;

        public IdentityController(IdentityService service)
        {
            _service = service;
        }
        public async Task<ActionResult> GetDiscoveryDocument()
        {
            var result = await _service.GetDiscoveryDocument();
            if (result.Status == ServiceStatus.Ok)
            {
                return Ok("Token Endpoint:" + result.Model.TokenEndpoint);
            }
            return Ok(result.ErrorMessage);

        }

        [Route("/identity")]
        public async Task<ActionResult> GetDiscoveryDocumentAndToken()
        {
            var result = await _service.GetDiscoveryDocumentAndToken();
            if (result.Status == ServiceStatus.Ok)
            {
                return Ok("Token :" + _service.AccessToken);
            }
            return Ok(result.ErrorMessage);
        }
    }
}