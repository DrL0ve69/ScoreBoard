using ScoreBoard.Models;

namespace ScoreBoard.DataBase
{
    public class DB_JeuxRepository : IJeu
    {
        private readonly DB_ScoreBoardContext _context;
        public DB_JeuxRepository(DB_ScoreBoardContext context)
        {
            _context = context; // Récupération du contexte de la base de données pour le service
        }
        public List<Jeu> ListeJeux => _context.Jeux.ToList();

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
            throw new NotImplementedException();
        }

        public List<Jeu> GetJeuxParJoueur(int joueurId)
        {
            throw new NotImplementedException();
        }

        public void Modifier(Jeu jeu)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
