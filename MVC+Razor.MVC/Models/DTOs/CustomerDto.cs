namespace MVC_Razor.MVC.Models.DTOs;

public class CustomerDto
{
    public string Id { get; set; } = string.Empty;

    [Required]
    [DisplayName("First Name")]
    [StringLength(50, ErrorMessage = "Name is too big. 100 characters Max!")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [DisplayName("Last Name")]
    [StringLength(50, ErrorMessage = "Name is too big. 100 characters Max!")]
    public string LastName { get; set; } = string.Empty;

    [DisplayName("Date of Birth")]
    [Required]
    [ValidAge]
    public DateTime Birthdate { get; set; }

    [StringLength(20, ErrorMessage = "number is too big. Check your input!")]
    [Phone]
    [Range(0, Int64.MaxValue, ErrorMessage = "Contact number should not contain characters")]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(300, ErrorMessage = "Email is too big. 300 characters Max!")]
    public string Email { get; set; } = string.Empty;

    public string Username() => FirstName + " " + LastName;

    public CustomerDto()
    {

    }
}
