using ScoreBoard.DataBase;
using ScoreBoard.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{

    /*
    Tous les champs sont requis.
    Les propriété DateSortie et DateEnregistrement doivent être des dates antérieures à la date du jour.
    L'identifiant du joueur doit exister.
    Le score doit être compris entre 0 et 100.
     */

    public class Jeu : IValidatableObject
    {
        public int Id { get; set; } // Clé primaire

        [Required(ErrorMessage = "Le nom du jeu est obligatoire.")]
        public string Nom { get; set; }

        private DateTime _dateSortie;
        [Required(ErrorMessage = "La date de sortie est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DatePasseeValid]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie 
        { 
            get => _dateSortie;
            set 
            {
                if (value > DateTime.Now)
                {
                    _validationResults.Add(new ValidationResult("class Jeu setter: La date ne peut pas être dans le futur.", ["DateEnregistrement"]));
                }
                _dateSortie = value;
            }
        }
        
        [Required(ErrorMessage = "La description est obligatoire.")]
        public string Description { get; set; }

        [JoueurIdValid(ErrorMessage ="Helllooooooooo")]
        public int JoueurId { get; set; } // Clé étrangère vers Joueur 
        public Joueur? Joueur { get; set; } // Navigation

        [Required(ErrorMessage = "Le score du joueur est obligatoire.")]
        [Range(0, 100, ErrorMessage = "Le score doit être compris entre 0 et 100.")]
        public int ScoreJoueur { get; set; }

        private DateTime _dateEnregistrement;
        [Required(ErrorMessage = "La date d'enregistrement est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DatePasseeValid]
        [Display(Name = "Date d'enregistrement")]
        public DateTime DateEnregistrement 
        {
            get => _dateEnregistrement;
            set 
            {
                if (value > DateTime.Now)
                {
                    _validationResults.Add(new ValidationResult("class Jeu setter: La date ne peut pas être dans le futur.", ["DateEnregistrement"]));
                }
                _dateEnregistrement = value;
            }
        }
        private List<ValidationResult> _validationResults = new List<ValidationResult>();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return _validationResults;
        }
    }
}
