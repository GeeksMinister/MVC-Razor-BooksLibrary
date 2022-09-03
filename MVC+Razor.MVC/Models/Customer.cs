namespace MVC_Razor.MVC.Models;

public class Customer
{
    [Key]
    [StringLength(36)]
    public Guid Guid { get; set; } = Guid.NewGuid();

    [Required]
    [DisplayName("First Name")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be between 3 - 50 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [DisplayName("Last Name")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be between 3 - 50 characters")]
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

    public List<Customer_Book> Customer_Book { get; set; } = new List<Customer_Book>();


    public string Username() => FirstName + " " + LastName;

    public Customer()
    {

    }
}
