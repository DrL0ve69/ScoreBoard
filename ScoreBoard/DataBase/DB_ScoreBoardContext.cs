using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.DataBase;

public class DB_ScoreBoardContext: DbContext
{
    public DB_ScoreBoardContext(DbContextOptions<DB_ScoreBoardContext> options) : base(options)
    {
    }
    public DbSet<Joueur> Joueurs { get; set; } // Table pour les joueurs
    public DbSet<Jeu> Jeux { get; set; } // Table pour les jeux
}
