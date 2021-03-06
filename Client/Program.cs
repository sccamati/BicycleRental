global using BicycleRental.Shared;
using BicycleRental.Client;
using BicycleRental.Client.Services;
using BicycleRental.Client.Services.Auth;
using BicycleRental.Client.Services.Bike;
using BicycleRental.Client.Services.BikesType;
using BicycleRental.Client.Services.Rental;
using BicycleRental.Client.Services.Role;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MatBlazor;
using BicycleRental.Client.Services.User;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBikesTypeService, BikesTypeService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IBikeService, BikeService>();

builder.Services.AddMatBlazor();
builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.BottomRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 3000;
});

await builder.Build().RunAsync();
