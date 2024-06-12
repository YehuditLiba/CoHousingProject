using BL;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// הוספת BL Manager לשירותים
builder.Services.AddScoped<BlManager>();
builder.Services.AddControllers();

// בניית ServiceProvider לקבלת IConfiguration
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

// הוספת הגדרות CORS
builder.Services.AddCors(options =>
{
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // הוסף אם אתה משתמש בקובצי עוגיות או מידע הזדהות אחר
    });
});

var app = builder.Build();

// הגדרת השימוש ב-CORS
app.UseCors();

// הגדרת הפנייה מחדש ל-HTTPS
app.UseHttpsRedirection();

// מיפוי ה-Controllers
app.MapControllers();

// הפעלת האפליקציה
app.Run();
