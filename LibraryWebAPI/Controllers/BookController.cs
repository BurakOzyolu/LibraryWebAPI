﻿using LibraryWebAPI.ViewModels;
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
            
            foreach (var item in _context.Books)
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
                booklist.Add(book);
            }  
            
            return Ok(booklist);
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            /*
             
            var TypeList = _context.Types.ToList();
            var WriterList = _context.Writes.ToList();
            var type = TypeList.FirstOrDefault(x => x.typeId == book.TypeId);
            var typeName = type.typeName;
            var Writer = WriterList.FirstOrDefault(x => x.WriterId == book.WriterId);
            string WriterName = Writer.WriterName;
            */

            BookViewModel bookVM = new BookViewModel()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                CreatedYear = book.CreatedYear,
                NumberOfPages = book.NumberOfPages,
                Type = _context.Types.FirstOrDefault(x => x.typeId == book.TypeId).typeName ?? "",
                Writer = _context.Writes.FirstOrDefault(x => x.WriterId == book.WriterId).WriterName ?? ""
            };
            
            return Ok(bookVM);
        }
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(string book,int id)
        {
            return Ok($"{id}. Kitap, {book} güncellendi");
        }
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"{id} ye sahip kitap silindi");
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Create(string book)
        {
            return Ok($"{book} isimli kitap sahip kitap eklendi");
        }
    }
}
