using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models.Validation
{
    public class JoueurIdValidAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            // JoueurId doit exister dans la base de données
            var joueurRepository = validationContext.GetService(typeof(IJoueurRepository)) as IJoueurRepository;
            var joueurId =  value.ToString();
            if (!joueurRepository.ListeJoueurs.Exists(joueur => joueur.Id == int.Parse(joueurId))) 
            {
                return new ValidationResult("L'identifiant du joueur n'existe pas dans la base de données.", new[] { validationContext.MemberName });
            }
            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-joueuridvalid", ErrorMessage ?? "L'identifiant du joueur n'existe pas dans la base de données.");
            context.Attributes.Add("data-val-joueuridvalid-joueurid", context.ModelMetadata.PropertyName ?? "JoueurId"); // Ajout d'un attribut pour le nom du champ
        }
    }
}
