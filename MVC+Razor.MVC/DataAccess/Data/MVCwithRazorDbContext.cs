namespace MVC_Razor.MVC.DataAccess.Data;

public class MVCwithRazorDbContext : DbContext
{
	private readonly IConfiguration _config;

	public MVCwithRazorDbContext(DbContextOptions<MVCwithRazorDbContext> options, IConfiguration config)
		: base(options)
	{
		_config = config;
	}


	public DbSet<Customer>? Customer { get; set; }
	public DbSet<Customer_Book>? Customer_book { get; set; }
	public DbSet<Book>? Book { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		if (options.IsConfigured == false)
		{
			options.UseSqlite(_config.GetConnectionString("Default"));
		}
	}
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
