using System.Text.Json;

namespace client.console.Features.Weather;

public class WeatherService
{
    private readonly string _accessToken;
    private readonly HttpClient _client;

    public WeatherService(string accessToken)
    {
        _accessToken = accessToken;
        this._client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7284")
        };
    }

    public async Task<WeatherForecast[]> GetForecast()
    {
        using var datarequest = new HttpRequestMessage(HttpMethod.Get, "/WeatherForecast");
        datarequest.Headers.Add("Authorization", $"Bearer {this._accessToken}");
        using var dataresponse = await this._client.SendAsync(datarequest);
        var asStringAsync = await dataresponse.Content.ReadAsStringAsync();
        var deserialized = JsonSerializer.Deserialize<WeatherForecast[]>(asStringAsync);
        if (deserialized != null) return deserialized;
        throw new Exception("Deserialization failed");
    }
}