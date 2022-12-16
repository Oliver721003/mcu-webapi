
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Models;

public class BookContext : DbContext
{
	public BookContext()
	{
	}

	public BookContext(DbContextOptions<BookContext> options)
		: base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BookDemo;TrustServerCertificate=True;User=sa;Password=Zaq1Xsw2;");
		}
	}

	public DbSet<Book> Books { get; set; }
}