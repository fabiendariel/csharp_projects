using Microsoft.AspNetCore.Mvc;
using ApiProject;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ArticleService>();

var app = builder.Build();

app.MapGet("/api/get", () => "Hello GET");
app.MapPost("/api/post", () => "Hello POST");
app.MapDelete("/api/delete", () => "Hello DELETE");
app.MapPut("/api/put", () => "Hello PUT");
app.MapPatch("/api/patch", () => "Hello PATCH");

app.MapMethods("/api/methods", new [] { "GET", "POST" }, () => "Hello methods");


app.MapGet("/api/articles/{id:int}", (int id, [FromServices] ArticleService service) =>
{
  var article = service.GetAll().Find(a => a.Id == id);
  if (article is not null) return Results.Ok(article);
  return Results.NotFound();
});

app.MapGet("/api/personne/{nom}", (
  [FromRoute] string nom,
  [FromQuery] string? prenom,
  [FromHeader(Name = "Accept-Encoding")] string encoding
) => Results.Ok($"{nom} {prenom} {encoding}"));

app.MapPost("/api/article/add", (Article a, [FromServices] ArticleService service) =>
{
  var result = service.Add(a.Title);
  return Results.Ok(result);
});

app.MapPost("/api/personne/identite", (Personne p) => Results.Ok(p));

app.Run();