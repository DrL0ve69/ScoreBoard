using ScoreBoard.DataBase;
using ScoreBoard.Models;

namespace ScoreBoard.ViewModels;

public class DataViewmodel
{
    public List<Joueur> Joueurs_VM { get; set; }
    public List<Jeu> Jeux_VM { get; set; }
    public Jeu? JeuSelectionne { get; set; } = null;
    public Joueur? JoueurSelectionne => Joueurs_VM[0];
    public int NombreJoueurs => Joueurs_VM.Count;
    public int NombreJeux => Jeux_VM.Count;
}
