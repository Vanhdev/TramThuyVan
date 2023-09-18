using Blazored.LocalStorage;
using dymaptic.GeoBlazor.Core;
using KTTV;
using KTTV.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddGeoBlazor();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<TramService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
