using ScoreBoard.DataBase;
using ScoreBoard.Models;

namespace ScoreBoard.ViewModels;

public class DataViewmodel
{
    public PaginatedList<Joueur>? PageJoueurs { get; set; }
    public List<Joueur> Joueurs_VM { get; set; }
    public List<Jeu> Jeux_VM { get; set; }
    public Jeu? JeuSelectionne { get; set; } = null;
    public Joueur? JoueurSelectionne => Joueurs_VM[0];
    public int NombreJoueurs => Joueurs_VM.Count;
    public int NombreJeux => Jeux_VM.Count;
    public List<Jeu> OdreAplhaJeu() 
    {
        return Jeux_VM.OrderBy(j => j.Nom).ToList();
    }
    // Changer pour modifier joueur actif huuuum doit avoir un setter
    public int JoueurPrecedent(Joueur joueur)
    {
        int index = Joueurs_VM.IndexOf(joueur);
        if (index > 0)
        {
            return index - 1; // Retourne l'index du joueur précédent
        }
        return -1; // Aucun joueur précédent
    }
    public int JoueurSuivant(Joueur joueur)
    {
        int index = Joueurs_VM.IndexOf(joueur);
        if (index < Joueurs_VM.Count - 1)
        {
            return index + 1; // Retourne l'index du joueur suivant
        }
        return -1; // Aucun joueur suivant
    }
}
