var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapOpenApi();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", app.Environment.ApplicationName);
});

app.MapPost("/api/todo", (Todo todo) =>
{
    return TypedResults.Ok();
})
.WithSummary("Create a new todo item")
.WithDescription("If we don't specify a value for the 'title' property, we get a 500 error. If we comment out the 'app.UseExceptionHandler()' line, we'll receive a 400 error instead.");

app.Run();

public class Todo
{
    public int Id { get; set; }

    public required string Title { get; set; }
}