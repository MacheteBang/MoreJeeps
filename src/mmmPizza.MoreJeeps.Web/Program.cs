using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using mmmPizza.MoreJeeps.Web;
using mmmPizza.MoreJeeps.Web.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

MoreJeepsApiSettings? apiSettings = new();
builder.Configuration.GetSection("MoreJeepsApi").Bind(apiSettings);
if (apiSettings is null) throw new Exception("Unable to bind configuration for MoreJeepsApi");
builder.Services.AddSingleton(apiSettings);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IMoreJeepsApiService, MoreJeepsApiService>();

await builder.Build().RunAsync();
