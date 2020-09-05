
using System.Net.Http;
using IdentityModel.Client;

public class HttpClientService
{
    private IHttpClientFactory _clientFactory;
    private IdentityService _identityService;

    public HttpClientService(IHttpClientFactory clientFactory, IdentityService identityService)
    {
        _clientFactory = clientFactory;
        _identityService = identityService;
    }
    public HttpClient GetClient()
    {
        var client = _clientFactory.CreateClient();
        client.SetBearerToken(_identityService.AccessToken);
        return client;
    }

}