using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;

public class Book
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string? Name { get; set; }

	[Required]
	public string? Author { get; set; }

	[Required]
	public string? Company { get; set; }
}