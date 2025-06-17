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
 *  Création de la base de données (migrations)
Qu'est-ce qu'une migration? Il s'agit d'un code généré qui permet de synchroniser le modèle (code source) de l'application et la base de données. Une migration doit être faite à chaque fois que vous modifiez votre modèle et que vous voulez retrouver ces modifications dans la base de données.
Étapes de la migration
Se fait dans la Console du Gestionnaire de Package (Affichage --> Autres fenêtres --> Console du Gestionnaire de Package).
1.	add-migration NomMigration: génère le code source de la migration NomMigration (script SQL).
2.	Update-Database: exécute le code généré durant la migration pour créer ou mettre à jour la base de données avec les tables et leurs colonnes.

 */