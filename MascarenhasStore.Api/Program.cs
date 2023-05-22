using MascarenhasStore.Domain.StoreContext.Handlers;
using MascarenhasStore.Domain.StoreContext.Repositories;
using MascarenhasStore.Domain.StoreContext.Services;
using MascarenhasStore.Infra.Services;
using MascarenhasStore.Infra.StoreContext.DataContexts;
using MascarenhasStore.Infra.StoreContext.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //usar rotas de controllers

builder.Services.AddScoped<MascarenhasDataContext, MascarenhasDataContext>();//nosso data context
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<CustomerHandler, CustomerHandler>();

var app = builder.Build();

app.UseRouting();//usar rotas

//rotas
app.MapGet("/", () => " Teste ");
app.MapControllerRoute(name: "hello", pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
