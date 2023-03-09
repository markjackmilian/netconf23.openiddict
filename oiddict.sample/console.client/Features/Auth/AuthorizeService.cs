using System.Text.Json;

namespace console.client.Features.Auth;

class AuthorizeService
{
    private readonly HttpClient _client;

    public AuthorizeService()
    {
        this._client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7251")
        };

    }

    public async Task<string> GetToken()
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token");
        var collection = new List<KeyValuePair<string, string>>
        {
            new("grant_type", "client_credentials"),
            new("scope", ""),
            new("client_id", "console"),
            new("client_secret", "388D45FA-B36B-4988-BA59-B187D329C207")
        };
        var content = new FormUrlEncodedContent(collection);
        request.Content = content;
        using var response = await this._client.SendAsync(request);
        
        response.EnsureSuccessStatusCode();
        
        var readAsStringAsync = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(readAsStringAsync);
        
        return tokenResponse.AccessToken;
    }
}