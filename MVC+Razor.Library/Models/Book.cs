namespace MVC_Razor.Library.Models;


public class Book
{
    [Key]
    [StringLength(36)]
    public Guid Guid { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Author { get; set; } = string.Empty;

    [Required]
    [StringLength(13)]
    public string ISBN { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public bool Available { get; set; } = true;

    public List<Customer_Book> Customer_Book { get; set; } = new List<Customer_Book>();

    public Book()
    {

    }
}
