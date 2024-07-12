using Microsoft.AspNetCore.Mvc;
using ApiProject;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.MapGet("todos", ([FromServices] TodoService service) =>
{
  return Results.Ok(service.GetAll());
});

app.MapGet("todos/{id:int}", ([FromRoute] int id, [FromServices] TodoService service) =>
{
  var todo = service.GetById(id);

  if(todo is null) return Results.NotFound();
  return Results.Ok(todo);
});

app.MapGet("todos/active", ([FromServices] TodoService service) =>
{
  return Results.Ok(service.GetAll().Where(t => t.EndDate is null));
});

app.MapPost("todos", ([FromBody] Todo todo, [FromServices] TodoService service) =>
{
  var result = service.Add(todo.Title);
  return Results.Ok(result);
});

app.MapDelete("todos/{id:int}", ([FromRoute] int id, [FromServices] TodoService service) => {
  var result = service.Delete(id);
  if(result)
  {
    return Results.NoContent();
  }
  return Results.NotFound();
});

app.MapPut("todos/{id:int}", (
  [FromRoute] int id, 
  [FromBody] Todo item, 
  [FromServices] TodoService service) =>
{
  service.Update(item);
  return Results.NoContent();
});

app.Run();