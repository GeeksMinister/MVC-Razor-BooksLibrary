namespace MVC_Razor.MVC.Models;

public class Customer_Book
{
    public int Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = new Customer();
    
    public Guid BookId { get; set; }
    public Book Book { get; set; } = new Book();

    public DateTime Borrowed { get; set; } = DateTime.Now;
    public Customer_Book()
    {

    }
}
