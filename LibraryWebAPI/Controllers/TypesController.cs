﻿using LibraryWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        MyContext _context;

        public TypesController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var booktypes = _context.BookTypes.ToList();
            return Ok(booktypes);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            var booktype = _context.BookTypes.FirstOrDefault(x => x.typeId == id);
            return Ok(booktype);
        }

        //Ekleme İşlemi 
        [HttpPost]
        [Route("add")]
        public IActionResult Create(BookType booktype)
        {
            var newbooktype = new BookType()
            {
                typeName= booktype.typeName
            };
            _context.BookTypes.Add(newbooktype);
            _context.SaveChanges();
            return Ok($"{booktype.typeName} eklendi");
        }

        //Güncelleme İşlemi Yapar
        [HttpPut]
        [Route("update")]
        public IActionResult Update(BookType booktype)
        {
            try
            {
                var newbooktype = _context.BookTypes.FirstOrDefault(x => x.typeId == booktype.typeId);
                newbooktype.typeName = booktype.typeName;
                _context.SaveChanges();
                var efbooklist = _context.BookTypes.ToList();
                return Ok($"{booktype.typeName} güncellendi");
            }
            catch
            {
                return Ok("Güncelleme işlemi yapılamadı");
            }
            
        }
        //Silme İşlemi
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletedType = _context.BookTypes.FirstOrDefault(x => x.typeId == id);
                var result = _context.BookTypes.Remove(deletedType);
                _context.SaveChanges();
                return Ok("Silme işlemi yapıldı");
            }
            catch
            {
                return Ok("Hata alındı");
            }
        }
    }
}
