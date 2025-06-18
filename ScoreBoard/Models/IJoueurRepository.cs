namespace ScoreBoard.Models
{
    public interface IJoueurRepository
    {
        List<Joueur> ListeJoueurs { get; }
        public Joueur? GetJoueur(int id);
        void Ajouter(Joueur joueur);
        public void Modifier(Joueur joueur);
        public void Supprimer(int id);
    }
}
