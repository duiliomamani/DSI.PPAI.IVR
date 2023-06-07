using CurrieTechnologies.Razor.SweetAlert2;
using DSI.PPAI.IVR;
using DSI.PPAI.IVR.Business;
using DSI.PPAI.IVR.Domain;
using DSI.PPAI.IVR.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("address");
});

//Inicializamos un Cliente que ya anteriormente llamo para simular que se comunica con el operador
var cliente = new Cliente(41042229, "Duilio", "Mamani", "+543516514522", new List<InformacionCliente>()
{
    new InformacionCliente("29/05/1998",
    OpcionValidacion.Opcion3,
    TipoInformacion.FechaNacimiento,
    Validacion.FechaNacimiento),
    new InformacionCliente("4610",
    OpcionValidacion.Opcion6,
    TipoInformacion.CodPostal,
    Validacion.CodPostal)
});

var categoria = CategoriaLlamada.Robo;

var opcionSeleccionada = OpcionLlamada.InfRoboNvaTarjeta;

var subOpcion = SubOpcionLlamada.ComunicarseConOperador;

var llamada = new Llamada(cliente, Estado.Iniciada);

builder.Services.AddSingleton<ContainerValues>();
builder.Services.AddSingleton<GestorLlamada>();
builder.Services.AddSweetAlert2();

var app = builder.Build();

var gestor = app.Services.GetRequiredService<GestorLlamada>();

gestor.comunicarseOP(categoria, opcionSeleccionada, subOpcion, llamada);

await app.RunAsync();