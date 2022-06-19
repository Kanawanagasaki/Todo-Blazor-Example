using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5001");
builder.Services.AddRazorPages();
builder.Services.AddSingleton<HttpClient>(sp =>
{
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    var baseAddress = addressFeature?.Addresses?.FirstOrDefault();
    if (baseAddress is null) return new HttpClient();
    else return new HttpClient { BaseAddress = new Uri(baseAddress) };
});

var app = builder.Build();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapFallbackToPage("/_Host");
});
app.Run();
