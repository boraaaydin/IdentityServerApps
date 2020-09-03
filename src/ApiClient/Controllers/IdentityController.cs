using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace MyWebAPI.Controllers
{
    public class IdentityController : ControllerBase
    {
        private Newtonsoft.Json.Linq.JObject Token { get; set; }
        private const string IdServerUrl = "https://localhost:5001";
        private const string ClientId = "oauthClient";
        private const string ClientSecret = "SuperSecretPassword";
        private const string Api = "api1.read";

        public async Task<ActionResult> GetDiscoveryDocument()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(IdServerUrl);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return Ok(disco.Error);
            }
            //TokenEndPoint = disco.TokenEndpoint;
            return Ok("Token Endpoint:" + disco.TokenEndpoint);
        }

        [Route("/")]
        public async Task<ActionResult> GetDiscoveryDocumentAndToken()
        {

            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(IdServerUrl);
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Scope = Api
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return Ok("Error:" + tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);
            Token = tokenResponse.Json;
            return Ok(Token.ToString());
        }
    }
}