namespace ManagerPeople.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Person
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The Name field is required.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "The Email field is invalid.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "The Birthdate field is required.")]
    [DataType(DataType.Date, ErrorMessage = "The Birthdate field is invalid.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [CustomValidation(typeof(Person), "ValidateBirthDate")]
    public DateTime BirthDate { get; set; }
    
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public static ValidationResult ValidateBirthDate(DateTime birthDate)
    {
        return birthDate > DateTime.Today ? new ValidationResult("The Birthdate cannot be in the future.") : ValidationResult.Success;
    }
}