using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.DataBase
{
    public class DB_JeuxRepository : IJeuRepository
    {
        private readonly DB_ScoreBoardContext _context;
        public DB_JeuxRepository(DB_ScoreBoardContext context)
        {
            _context = context; // Récupération du contexte de la base de données pour le service
        }
        List<Jeu> IJeuRepository.ListeJeux => _context.Jeux.Include(j => j.Joueur).ToList();

        public void Ajouter(Jeu jeu)
        {
            Joueur joueurActif = _context.Joueurs.FirstOrDefault(j => j.Id == jeu.JoueurId); // Récupération du joueur actif
            if (joueurActif != null)
            {
                joueurActif.Jeux.Add(jeu); // Ajout du jeu à la liste des jeux du joueur actif
                _context.Jeux.Add(jeu); // Ajout du jeu à la base de données
                _context.SaveChanges(); // Enregistrement des modifications dans la base de données
            }
            else
            {
                throw new InvalidOperationException("Joueur actif non trouvé."); // Gestion d'erreur si le joueur actif n'est pas trouvé

            }
        }

        public Jeu? GetJeu(int id)
        {
            return _context.Jeux.Include(j => j.Joueur).FirstOrDefault(j => j.Id == id); // Récupération d'un jeu par son ID
        }

        public List<Jeu> GetJeuxParJoueur(int joueurId)
        {
            return _context.Jeux.Include(j => j.Joueur).Where(j => j.JoueurId == joueurId).ToList(); // Récupération des jeux d'un joueur spécifique
        }

        public void Modifier(Jeu jeu)
        {
            _context.Jeux.Update(jeu);
            _context.SaveChanges();
        }

        public void Supprimer(int id)
        {
            _context.Jeux.Remove(GetJeu(id));
            _context.SaveChanges();
        }
    }
}
