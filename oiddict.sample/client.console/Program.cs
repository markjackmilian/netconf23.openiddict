// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using client.console;
using client.console.Features.Auth;
using client.console.Features.Weather;

var authService = new AuthorizeService();
var token = await authService.GetToken();
Console.WriteLine(token);


var weatherService = new WeatherService(token);
var weather = await weatherService.GetForecast();

Console.WriteLine(Environment.NewLine);
Console.WriteLine("---------------------------");
Console.WriteLine(Environment.NewLine);
Console.WriteLine(JsonSerializer.Serialize(weather));
