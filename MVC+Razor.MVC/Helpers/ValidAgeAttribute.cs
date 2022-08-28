using System.ComponentModel.DataAnnotations;

public class ValidAgeAttribute : ValidationAttribute
{
	public ValidAgeAttribute() { }

	public string GetErrorMessage() => "Customer must be at least 15 years old";

	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		int years = Convert.ToDateTime(value).Year;
		int age = DateTime.Now.Year - years;

		if (age < 15)
		{
			return new ValidationResult(GetErrorMessage());
		}
		else
		{
			return ValidationResult.Success;
		}
	}
}
