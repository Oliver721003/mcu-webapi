using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
	private readonly BookContext _context;

	public BookController(BookContext context)
	{
		_context = context;
	}

	[HttpGet]
	public IEnumerable<Book> Get(string? name = "")
	{
		var books = _context.Books.AsQueryable();
		if (!string.IsNullOrEmpty(name))
			books = books.Where(x => x.Name.Contains(name));
		return books.ToList();
	}

	[HttpGet]
	[Route("{id}")]
	public Book Get(int id)
	{
		return _context.Books.Find(id);
	}

	[HttpPost]
	public IActionResult Insert([FromBody] Book book)
	{
		_context.Add(book);
		_context.SaveChanges();
		return Ok();
	}

	[HttpPut]
	public IActionResult Update([FromBody] Book book)
	{
		_context.Update(book);
		_context.SaveChanges();
		return Ok();
	}

	[HttpDelete]
	[Route("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		_context.Remove(new Book { Id = id });
		_context.SaveChanges();
		return Ok();
	}
}