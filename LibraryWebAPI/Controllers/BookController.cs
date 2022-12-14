using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        MyContext _context;

        public BookController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();
              return Ok(books);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            return Ok(book);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string book,int id)
        {
            return Ok($"{id}. Kitap, {book} güncellendi");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"{id} ye sahip kitap silindi");
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create(string book)
        {
            return Ok($"{book} isimli kitap sahip kitap eklendi");
        }
    }
}
