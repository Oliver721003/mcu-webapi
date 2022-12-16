using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
	private static List<Book> _books = new List<Book> {
		new Book { Id = 1, Name = "Book 1", Author = "Author 1", Company = "Company 1" },
		new Book { Id = 2, Name = "Book 2", Author = "Author 2", Company = "Company 2" },
		new Book { Id = 3, Name = "Book 3", Author = "Author 3", Company = "Company 3" },
		new Book { Id = 4, Name = "Book 4", Author = "Author 4", Company = "Company 4" },
		new Book { Id = 5, Name = "Book 5", Author = "Author 5", Company = "Company 5" },
	};

	[HttpGet]
	public IEnumerable<Book> Get()
	{
		return _books;
	}

	[HttpGet]
	[Route("{id}")]
	public Book Get(int id)
	{
		return _books.FirstOrDefault(b => b.Id == id);
	}

	[HttpPost]
	public IActionResult Insert([FromBody] Book book)
	{
		var id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
		book.Id = id;
		_books.Add(book);
		return Ok();
	}

	[HttpPut]
	[Route("{id}")]
	public IActionResult Update([FromRoute] int id, [FromBody] Book book)
	{
		var bookToUpdate = _books.FirstOrDefault(b => b.Id == id);
		if (bookToUpdate == null)
		{
			return NotFound();
		}

		bookToUpdate.Name = book.Name;
		bookToUpdate.Author = book.Author;
		bookToUpdate.Company = book.Company;
		return Ok();
	}

	[HttpDelete]
	[Route("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		_books.RemoveAll(book => book.Id == id);
		return Ok();
	}
}