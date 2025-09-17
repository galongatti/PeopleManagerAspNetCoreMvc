using System.ComponentModel.DataAnnotations.Schema;
using ManagerPeople.Models.Enum;

namespace ManagerPeople.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The Name field is required.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "The Email field is invalid.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "The Birthdate field is required.")]
    [DataType(DataType.Date, ErrorMessage = "The Birthdate field is invalid.")]
    [CustomValidation(typeof(Person), "ValidateBirthDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime BirthDate
    {
        get => _birthDate.Date;
        set => _birthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    private DateTime _birthDate;
    
    [Required(ErrorMessage = "The CPF field is required.")]
    public string CPF { get; set; }
    
    [Required(ErrorMessage = "The BloodType field is required.")]
    public EBloodType BloodType { get; set; }
    
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public static ValidationResult ValidateBirthDate(DateTime birthDate)
    {
        return birthDate > DateTime.Today ? new ValidationResult("The Birthdate cannot be in the future.") : ValidationResult.Success;
    }
}