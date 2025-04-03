using SingnalRDemo.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add Services to Container.
builder.Services.AddSignalR();

builder.Services.AddControllers();



//Add Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>(pattern: "/Chat");
// app.MapGet("/", () => "Hello World!");

app.Run();
