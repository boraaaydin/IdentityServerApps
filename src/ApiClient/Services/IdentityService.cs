using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

public class IdentityService
{
    public string AccessToken{ get; set; }
    private const string IdServerUrl = "https://localhost:5001";
    private const string ClientId = "oauthClient";
    private const string ClientSecret = "SuperSecretPassword";
    private const string Api = "api1.read";

    public async Task<ServiceResult<DiscoveryDocumentResponse>> GetDiscoveryDocument()
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(IdServerUrl);
        if (disco.IsError)
        {
            return new ServiceResultError<DiscoveryDocumentResponse>("Error:" + disco.Error);
        }
        return new ServiceResultOk<DiscoveryDocumentResponse>(disco);
    }

    public async Task<ServiceResult> GetDiscoveryDocumentAndToken()
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
            return new ServiceResultError("Error:" + tokenResponse.Error);
        }

        AccessToken = tokenResponse.AccessToken;
        return new ServiceResultOk<TokenResponse>(tokenResponse);
    }
}