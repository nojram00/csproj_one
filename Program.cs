using csproj_one.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllersWithViews();

// Supabase shits:
// var url =  Environment.GetEnvironmentVariable("SUPABASE_URL") ;
// var key =  Environment.GetEnvironmentVariable("SUPABASE_KEY");

var url = "https://etoebeychxuxbwhqzrei.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImV0b2ViZXljaHh1eGJ3aHF6cmVpIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk4NDQ3OTgsImV4cCI6MjA0NTQyMDc5OH0.Pu0A3X6fJSEFxPbXggj-XcNXwa5bqp_4qy-zLM1tz0c";

var options = new Supabase.SupabaseOptions {
    AutoRefreshToken = true,
    AutoConnectRealtime = true
};


builder.Services.AddSingleton(provider => new Supabase.Client(url, key , options));

var app = builder.Build();

var client = app.Services.GetRequiredService<Supabase.Client>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
);

app.UseHttpsRedirection();

app.Run();
