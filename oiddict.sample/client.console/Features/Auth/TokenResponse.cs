using System.Text.Json.Serialization;

namespace client.console.Features.Auth;

class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
}