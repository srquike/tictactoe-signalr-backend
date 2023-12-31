using TicTacToeSignalR.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
    {
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.SetIsOriginAllowed(allowed => true);
        builder.AllowCredentials();
    });
}

app.UseCors(options =>
{
    options
        .WithOrigins("http://localhost:3000", "https://tictactoe-signalr-api-ab53-dev.fl0.io")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(allowed => true);
});

app.UseHttpsRedirection();

app.MapHub<GameHub>("/hubs/game");

app.Run();