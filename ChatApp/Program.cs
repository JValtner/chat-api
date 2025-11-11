using ChatApp.Application.Services;
using ChatApp.Hub;
using ChatApp.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// === Services ===
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IChatService, ChatService>();

// ✅ Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ChatApp API",
        Version = "v1",
        Description = "Simple Chat API with SignalR"
    });
});

// ✅ CORS (for React frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173") // your React dev server
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // only if you need cookies or auth
    });
});

var app = builder.Build();

// === Middleware ===
if (app.Environment.IsDevelopment())
{
    // ✅ Enable Swagger UI in dev
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatApp API v1");
        c.RoutePrefix = "swagger"; // Access at /swagger
    });
}

app.UseCors("AllowReactApp");


app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();
