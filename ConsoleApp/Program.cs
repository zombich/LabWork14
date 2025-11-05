using ApiServicesLibrary.Services;
using DatabaseLibrary.Models;
using System.Text.Json;

Console.WriteLine("14");

HttpClient client = new()
{
    BaseAddress = new Uri("http://localhost:5035/api/")
};

#region task2

var filmService = new FilmApiService(client);

var films = await filmService.GetFilmsAsync();

foreach (var f in films)
    Console.WriteLine($"{f.Name} - {f.ReleaseYear}");


var film = new Film()
{
    Name = "film1",
    ReleaseYear = 2023
};
film = await filmService.AddFilmAsync(film);
Console.WriteLine("Добавлен фильм");

Console.WriteLine("Нажмите Enter чтобы продолжить...");
Console.ReadKey();

film.Name = "new film";
await filmService.UpdateFilmAsync(film);

Console.WriteLine("Обновлен фильм");

Console.WriteLine("Нажмите Enter чтобы продолжить...");
Console.ReadKey();

await filmService.RemoveFilmAsync(film.FilmId);

Console.WriteLine("Удален фильм");

#endregion

#region task3

Console.WriteLine("visitors");
var jsonOptions = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

var visitorService = new VisitorApiService(client, jsonOptions);

var visitors = await visitorService.GetVisitorsAsync();

foreach (var v in visitors)
    Console.WriteLine($"{v.Name} - {v.Phone}");

var visitor = new Visitor()
{
    Phone = "999913499",
    Name = "coolvisitor"
};

visitor = await visitorService.AddVisitorAsync(visitor);
Console.WriteLine("Добавлен посетитель");

Console.WriteLine("Нажмите Enter чтобы продолжить...");
Console.ReadKey();

visitor.Name = "updatedvisitor";
await visitorService.UpdateVisitorAsync(visitor);

Console.WriteLine("Обновлен посетитель");

Console.ReadLine();

#endregion

