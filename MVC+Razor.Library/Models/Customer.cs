namespace MVC_Razor.Library.Models;


public class Customer
{
    [Key]
    [StringLength(36)]
    public Guid Guid { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [ValidAge]
    public DateTime Birthdate { get; set; }

    [StringLength(50)]
    [Phone]
    [Range(0, Int64.MaxValue, ErrorMessage = "Contact number should not contain characters")]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(300)]
    public string Email { get; set; } = string.Empty;

    public List<Customer_Book> Customer_Book { get; set; } = new List<Customer_Book>();

    public Customer()
    {

    }


    public string Username() => FirstName + " " + LastName;
}
