using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{/*
 Tous les champs sont obligatoires sauf Equipe et Telephone.
 Le champs équipe doit avoir 2 à 4 lettres majuscules.
 Les champs nom et prénom doivent entre 2 et 20 caractères.
 Le champ courriel doit être une adresse courriel valide, de format Identifiant@scoreboard.ca. Identifiant étant l'identifiant du joueur. Vous avez le choix de la méthode de validations (client et/ou serveur).
 */
    public class Joueur
    {
        public int Id { get; set; } // Clé primaire
        [Required(ErrorMessage = "Nom ne peut pas être nul")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 20 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prénom ne peut pas être nul")]
        [DisplayName("Prénom")]
        [Length(2,20,ErrorMessage = "Le prénom doit contenir entre 2 et 20 caractères.")]
        public string Prenom { get; set; }

        [DisplayName("Équipe")]
        [RegularExpression(@"^[A-Z]{2,4}$", ErrorMessage = "Le nom d'équipe doit contenir entre 2 et 4 lettres majuscules.")]
        public string? Equipe { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^\(?\d{3}\)?-?\d{3}-?\d{4}$", ErrorMessage = "Le numéro de téléphone doit être au format 123-456-7890 ou (123)-456-7890 ou 1234567890")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Courriel ne peut pas être nul")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse courriel valide.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@scoreboard\.ca$", ErrorMessage = "Attention aux caractères spéciaux & doit se terminé par @scoreboard.ca")]
        public string Courriel { get; set; }
        public List<Jeu>? Jeux { get; set; } // Liste des jeux associés au joueur, navigation property
    }
}
