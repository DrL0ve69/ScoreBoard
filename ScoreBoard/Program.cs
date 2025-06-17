using ScoreBoard.DataBase;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DB_ScoreBoardContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DB_ScoreBoardContext_Connection"]);
});

builder.Services.AddScoped<IJoueurRepository, DB_JoueursRepository>();
builder.Services.AddScoped<IJeuRepository, DB_JeuxRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

DB_Seeders.Seed(app);
app.Run();


/*
 *  Cr�ation de la base de donn�es (migrations)
Qu'est-ce qu'une migration? Il s'agit d'un code g�n�r� qui permet de synchroniser le mod�le (code source) de l'application et la base de donn�es. Une migration doit �tre faite � chaque fois que vous modifiez votre mod�le et que vous voulez retrouver ces modifications dans la base de donn�es.
�tapes de la migration
Se fait dans la Console du Gestionnaire de Package (Affichage --> Autres fen�tres --> Console du Gestionnaire de Package).
1.	add-migration NomMigration: g�n�re le code source de la migration NomMigration (script SQL).
2.	Update-Database: ex�cute le code g�n�r� durant la migration pour cr�er ou mettre � jour la base de donn�es avec les tables et leurs colonnes.

 */