using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
	[HttpGet]
	public IEnumerable<Book> Get(string? name = "")
	{
		var db = new BookContext();
		var books = db.Books.AsQueryable();
		if (!string.IsNullOrEmpty(name))
			books = books.Where(x => x.Name.Contains(name));
		return books.ToList();
	}

	[HttpGet]
	[Route("{id}")]
	public Book Get(int id)
	{
		var db = new BookContext();
		return db.Books.Find(id);
	}

	[HttpPost]
	public IActionResult Insert([FromBody] Book book)
	{
		var db = new BookContext();
		db.Add(book);
		db.SaveChanges();
		return Ok();
	}

	[HttpPut]
	public IActionResult Update([FromBody] Book book)
	{
		var db = new BookContext();
		db.Update(book);
		db.SaveChanges();
		return Ok();
	}

	[HttpDelete]
	[Route("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		var db = new BookContext();
		db.Remove(new Book { Id = id });
		db.SaveChanges();
		return Ok();
	}
}