using LibraryWebAPI.Models;
using LibraryWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [Route("getall")]
        public IActionResult GetAll()
        {

            List<BookViewModel> booklist = new List<BookViewModel>();
            var TypeList = _context.Types.ToList();
            var WriterList = _context.Writes.ToList();

            foreach (var item in _context.Books.Where(x => x.IsDeleted == false))
            {
                BookViewModel book = new BookViewModel();
                book.BookId = item.BookId;
                book.BookName = item.BookName;
                book.CreatedYear = item.CreatedYear;
                book.NumberOfPages = item.NumberOfPages;
                var type = TypeList.FirstOrDefault(x => x.typeId == item.TypeId);
                var typeName = type.typeName;
                book.Type = typeName;
                var Writer = WriterList.FirstOrDefault(x => x.WriterId == item.WriterId);
                string WriterName = Writer.WriterName;
                book.Writer = WriterName;
                book.BookImage = item.BookImage;
                booklist.Add(book);
            }

            return Ok(booklist);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id && x.IsDeleted == false);
            return Ok(book);

        }
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(BookViewModel bookVM, int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);

            book.BookName = bookVM.BookName;
            book.NumberOfPages = bookVM.NumberOfPages;
            book.IsDeleted = false;
            book.CreatedYear = bookVM.CreatedYear;
            var TypeBool = _context.Types.Any(x => x.typeName == bookVM.Type);
            if (TypeBool)
            {
                book.TypeId = _context.Types.FirstOrDefault(x => x.typeName == bookVM.Type).typeId;
            }
            var WriterBool = _context.Writes.Any(x => x.WriterName == bookVM.Writer);
            if (WriterBool)
            {
                book.WriterId = _context.Writes.FirstOrDefault(x => x.WriterName == bookVM.Writer).WriterId;
            }
            return Ok($"{id}. Kitap, {bookVM} güncellendi");
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Create(BookViewModel bookVM)
        {
            var book = new Book()
            {
                BookName = bookVM.BookName,
                IsDeleted = false,
                NumberOfPages = bookVM.NumberOfPages,
                CreatedYear = bookVM.CreatedYear
            };
            var result = _context.Books.Add(book);
            _context.SaveChanges();
            return Ok($"{bookVM.BookName} isimli kitap sahip kitap eklendi");
        }
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                return Ok($"{id} Id'ye sahip kitap listede bulunmamaktadır");
            }
            book.IsDeleted = true;
            _context.SaveChanges();
            return Ok($"{book.BookName} isimli kitap silindi");
        }
    }
}
