using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.DataBase;

public class DB_JoueursRepository : IJoueurRepository
{
    private readonly DB_ScoreBoardContext _context;
    public DB_JoueursRepository(DB_ScoreBoardContext context)
    {
        _context = context; // Récupération du contexte de la base de données pour le service
    }
    List<Joueur> IJoueurRepository.ListeJoueurs => _context.Joueurs.Include(j => j.Jeux).ToList();

    public void Ajouter(Joueur joueur)
    {
        _context.Joueurs.Add(joueur ?? throw new ArgumentNullException(nameof(joueur), "Joueur cannot be null."));
        _context.SaveChanges();
    }

    public Joueur? GetJoueur(int id)
    {
        return _context.Joueurs.Include(j => j.Jeux).FirstOrDefault(j => j.Id == id);
    }

    public void Modifier(Joueur joueur)
    {
        _context.Joueurs.Update(joueur ?? throw new ArgumentNullException(nameof(joueur), "Joueur cannot be null."));
        _context.SaveChanges(); // Save changes to the database
    }

    public void Supprimer(int id)
    {
        _context.Joueurs.Remove(GetJoueur(id) ?? throw new InvalidOperationException("Joueur not found."));
        _context.SaveChanges();
    }
}
