namespace ScoreBoard.Models
{

    /*
    Tous les champs sont requis.
    Les propriété DateSortie et DateEnregistrement doivent être des dates antérieures à la date du jour.
    L'identifiant du joueur doit exister.
    Le score doit être compris entre 0 et 100.
     */
    public class Jeu
    {
        public int Id { get; set; } // Clé primaire
        public string Nom { get; set; }
        public DateTime DateSortie { get; set; }
        public string Description { get; set; }
        public int JoueurId { get; set; } // Clé étrangère vers Joueur
        public Joueur Joueur { get; set; } // Navigation
        public int ScoreJoueur { get; set; }
        public DateTime DateEnregistrement { get; set; }
    }
}
