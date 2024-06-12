using BL;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// ����� BL Manager ��������
builder.Services.AddScoped<BlManager>();
builder.Services.AddControllers();

// ����� ServiceProvider ����� IConfiguration
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

// ����� ������ CORS
builder.Services.AddCors(options =>
{
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // ���� �� ��� ����� ������ ������ �� ���� ������ ���
    });
});

var app = builder.Build();

// ����� ������ �-CORS
app.UseCors();

// ����� ������ ���� �-HTTPS
app.UseHttpsRedirection();

// ����� �-Controllers
app.MapControllers();

// ����� ���������
app.Run();
