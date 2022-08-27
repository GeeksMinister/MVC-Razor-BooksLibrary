using Microsoft.EntityFrameworkCore;
using MVC_Razor.Library.Models;

namespace MVC_Razor.Library.Data;


public class MVCwithRazorDbContext : DbContext
{

	public MVCwithRazorDbContext() { }		

	public DbSet<Customer>? Customer { get; set; }
	public DbSet<Customer_Book>? Customer_book { get; set; }
	public DbSet<Book>? Book { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite("Data Source=Data\\MVC&RazorDb.db");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer_Book>()
			.HasOne(customer_book => customer_book.Customer)
			.WithMany(customer => customer.Customer_Book)
			.HasForeignKey(book => book.CustomerId);

		modelBuilder.Entity<Customer_Book>()
			.HasOne(customer_book => customer_book.Book)
			.WithMany(book => book.Customer_Book)
			.HasForeignKey(customer_book => customer_book.BookId);
	}
	
}
