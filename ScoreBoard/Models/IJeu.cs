namespace ScoreBoard.Models
{
    public interface IJeu
    {
        List<Jeu> ListeJeux { get; }
        public Jeu? GetJeu(int id);
        public void Ajouter(Jeu jeu);
        public void Modifier(Jeu jeu);
        public void Supprimer(int id);
        public List<Jeu> GetJeuxParJoueur(int joueurId); // Pour obtenir les jeux d'un joueur spécifique
    }
}
