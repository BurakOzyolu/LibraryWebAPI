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
            var TypeList = _context.BookTypes.ToList();
            var WriterList = _context.Writes.ToList();

            foreach (var item in _context.Books.Where(x => x.IsDeleted == false))
            {
                BookViewModel book = new BookViewModel();
                book.BookId = item.BookId;
                book.BookName = item.BookName;
                book.CreatedYear = item.CreatedYear;
                book.NumberOfPages = item.NumberOfPages;
                book.TypeId = item.TypeId;
                book.WriterId = item.WriterId;
                var type = TypeList.FirstOrDefault(x => x.typeId == item.TypeId);
                string typeName = (type == null) ? "" : type.typeName;
                book.Type = typeName;
                var Writer = WriterList.FirstOrDefault(x => x.WriterId == item.WriterId);
                string WriterName = (Writer == null) ? "": Writer.WriterName;
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
        [HttpPut]
        [Route("update")]
        public IActionResult Update(BookViewModel bookVM)
        {


            try
            {
                var typebool = _context.BookTypes.Any(x => x.typeName == bookVM.Type);
                var writerbool = _context.Writes.Any(x => x.WriterName == bookVM.Writer);
                int typeId;
                int WriterId;

                if (typebool)
                {
                    typeId = _context.BookTypes.FirstOrDefault(x => x.typeName == bookVM.Type).typeId;
                }
                else
                {
                    typeId = 0;
                }
                if (writerbool)
                {
                    WriterId = _context.Writes.FirstOrDefault(x => x.WriterName == bookVM.Writer).WriterId;
                }
                else
                {
                    WriterId = 0;
                }


                var book = _context.Books.FirstOrDefault(x => x.BookId == bookVM.BookId);

                if(book != null)
                {
                book.BookName = bookVM.BookName;
                book.NumberOfPages = bookVM.NumberOfPages;
                book.IsDeleted = false;
                book.CreatedYear = bookVM.CreatedYear;
                book.BookImage = bookVM.BookImage;
                book.WriterId = (typeId == 0) ? null : typeId;
                book.TypeId = (WriterId == 0) ? null : WriterId;
                _context.SaveChanges();
                return Ok($"{bookVM.BookId}. Kitap, {bookVM.BookName} güncellendi");
                }
                else
                {
                    return Ok("Güncelenecek kitap bulunamadı");
                }
            }
            catch
            {
                return Ok("Hata alındı");
            }
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Create(BookViewModel bookVM)
        {
            try
            {

                var typebool = _context.BookTypes.Any(x => x.typeName == bookVM.Type);
                var writerbool = _context.Writes.Any(x => x.WriterName == bookVM.Writer);
                int typeId;
                int WriterId;

                if (typebool)
                {
                    typeId = _context.BookTypes.FirstOrDefault(x => x.typeName == bookVM.Type).typeId;
                }
                else
                {
                    typeId = 0;
                }
                if (writerbool)
                {
                    WriterId = _context.Writes.FirstOrDefault(x => x.WriterName == bookVM.Writer).WriterId;
                }
                else
                {
                    WriterId = 0;
                }


                var book = new Book()
                {
                    BookName = bookVM.BookName,
                    IsDeleted = false,
                    NumberOfPages = bookVM.NumberOfPages,
                    CreatedYear = bookVM.CreatedYear,
                    BookImage = bookVM.BookImage,
                    TypeId = (typeId == 0) ? null : typeId,
                    WriterId = (WriterId == 0) ? null : WriterId
                };
                var result = _context.Books.Add(book);
                _context.SaveChanges();
                return Ok($"{bookVM.BookName} isimli kitap sahip kitap eklendi");
            }

            catch
            {
                return Ok("Hata alındı");
            }
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
