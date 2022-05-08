using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RollCallSystem.Client;
using Microsoft.AspNetCore.Cors;
using Syncfusion.Blazor;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjMyNjYzQDMyMzAyZTMxMmUzMEsrN0JyZWY0TStVNGFwRDBsVC9Ed1RSR3hJcVkrY3NMdHRIVDRsbnhUWW89");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("RollCallSystem.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("RollCallSystem.ServerAPI"));

builder.Services.AddApiAuthorization();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
builder.Services.AddStorage();


await builder.Build().RunAsync();

