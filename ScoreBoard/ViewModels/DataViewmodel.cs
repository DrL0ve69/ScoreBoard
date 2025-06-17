using ScoreBoard.Models;

namespace ScoreBoard.ViewModels;

public class DataViewmodel
{
    public List<Joueur> Joueurs_VM { get; set; } = new List<Joueur>();
    public List<Jeu> Jeux_VM { get; set; } = new List<Jeu>();
    public int NombreJoueurs => Joueurs_VM.Count;
    public int NombreJeux => Jeux_VM.Count;
}
