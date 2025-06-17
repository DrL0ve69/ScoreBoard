using ScoreBoard.DataBase;
using ScoreBoard.Models;

namespace ScoreBoard.ViewModels;

public class DataViewmodel
{
    private readonly DB_ScoreBoardContext _context;
    public List<Joueur> Joueurs_VM => _context.Joueurs.ToList();
    public List<Jeu> Jeux_VM => _context.Jeux.ToList();
    public Jeu? JeuSelectionne { get; set; } = null;
    public Joueur? JoueurSelectionne { get; set; } = null;
    public int NombreJoueurs => Joueurs_VM.Count;
    public int NombreJeux => Jeux_VM.Count;
}
