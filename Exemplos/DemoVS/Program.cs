// Configura��o Builder
using DemoVS;
using Serilog;

//WebApplicationBuilder: Classe que possui a responsabilidade de construir uma inst�ncia de aplica��o ASP.NET com todas as configura��es definidas.
var builder = WebApplication.CreateBuilder(args); //Importante

// Configura��o do Pipeline
builder.AddSerilog(); //Aparece dessa forma porque eu extendo o m�todo com o this conforme esta no middleware

builder.Services.AddControllersWithViews();

// Configura��o da App
//WebAplication: A inst�ncia que representa a aplica��o e todas as configura��es dos middlewares em rela��o aos seus comportamentos durante um request.
var app = builder.Build();//Importante

// Configura��o de comportamentos da App

//Adiciona os Middlewares
app.UseLogTempo(); //Aparece dessa forma porque eu extendo o m�todo com o this conforme esta no middleware

app.MapGet("/", () => "Hello World!");
//app.MapGet("/teste", () => "Isso � um teste");

app.MapGet("/teste", () => {
    Thread.Sleep(1500);
    return "Teste 2";
});

app.Run();//Importante
