// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using console.client;
using console.client.Features.Auth;
using console.client.Features.Weather;

var authService = new AuthorizeService();
var token = await authService.GetToken();
Console.WriteLine(token);


var weatherService = new WeatherService(token);
var weather = await weatherService.GetForecast();

Console.WriteLine(Environment.NewLine);
Console.WriteLine("---------------------------");
Console.WriteLine(Environment.NewLine);
Console.WriteLine(JsonSerializer.Serialize(weather));
