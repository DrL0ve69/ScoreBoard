using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models.Validation;

public class DatePasseeValidAttribute : ValidationAttribute, IClientModelValidator
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime) 
        {
            return (DateTime)value<= DateTime.Now;
        }
        return false;
    }
    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val", "true");
        context.Attributes.Add("data-val-datepasseevalid", ErrorMessage ?? "La date ne peut pas être dans le futur");
    }
}
