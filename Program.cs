using WeatherUpdates.Configurations;
using WeatherUpdates.Interfaces;
using WeatherUpdates.MiddleWare;
using WeatherUpdates.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration = new  ConfigurationBuilder();
builder.Services.AddHttpClient<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IWeatherConfig>(builder.Configuration.GetSection("WeatherConfig").Get<WeatherConfig>());
builder.Services.AddLogging(Loger =>
{
    Loger.AddConsole();
   
    
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseApiLogerMiddleWare();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
