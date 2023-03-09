using System.Text.Json.Serialization;

namespace console.client.Features.Auth;

class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
}