// Configuração Builder
using DemoVS;
using Serilog;

//WebApplicationBuilder: Classe que possui a responsabilidade de construir uma instância de aplicação ASP.NET com todas as configurações definidas.
var builder = WebApplication.CreateBuilder(args); //Importante

// Configuração do Pipeline
builder.AddSerilog(); //Aparece dessa forma porque eu extendo o método com o this conforme esta no middleware

builder.Services.AddControllersWithViews();

// Configuração da App
//WebAplication: A instância que representa a aplicação e todas as configurações dos middlewares em relação aos seus comportamentos durante um request.
var app = builder.Build();//Importante

// Configuração de comportamentos da App

//Adiciona os Middlewares
app.UseLogTempo(); //Aparece dessa forma porque eu extendo o método com o this conforme esta no middleware

app.MapGet("/", () => "Hello World!");
//app.MapGet("/teste", () => "Isso é um teste");

app.MapGet("/teste", () => {
    Thread.Sleep(1500);
    return "Teste 2";
});

app.Run();//Importante
