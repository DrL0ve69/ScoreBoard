using System.ComponentModel.DataAnnotations;

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

        private DateTime _dateSortie;
        [Required(ErrorMessage = "La date de sortie est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie 
        { 
            get; set; 
        }
        
        [Required(ErrorMessage = "La description est obligatoire.")]
        public string Description { get; set; }

        private int _joueurId;
        public int JoueurId { get; set; } // Clé étrangère vers Joueur
        public Joueur Joueur { get; set; } // Navigation

        [Required(ErrorMessage = "Le score du joueur est obligatoire.")]
        [Range(0, 100, ErrorMessage = "Le score doit être compris entre 0 et 100.")]
        public int ScoreJoueur { get; set; }

        private DateTime _dateEnregistrement;
        [Required(ErrorMessage = "La date d'enregistrement est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date d'enregistrement'")]
        public DateTime DateEnregistrement { get; set; }
    }
}
