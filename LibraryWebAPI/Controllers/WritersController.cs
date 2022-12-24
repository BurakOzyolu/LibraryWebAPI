using LibraryWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        MyContext _context;

        public WritersController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var writers = _context.Writes.ToList();
            return Ok(writers);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            var writer = _context.Writes.FirstOrDefault(x => x.WriterId == id);
            return Ok(writer);
        }

        //Ekleme İşlemi 
        [HttpPost]
        [Route("add")]
        public IActionResult Create(Writer writer)
        {
            var newWriter = new Writer()
            {
                WriterName = writer.WriterName
            };
            _context.Writes.Add(newWriter);
            _context.SaveChanges();
            return Ok($"{writer.WriterName} eklendi");
        }

        //Güncelleme İşlemi Yapar
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Writer writer)
        {
            try
            {
                var editWriter = _context.Writes.FirstOrDefault(x => x.WriterId == writer.WriterId);
                editWriter.WriterName = writer.WriterName;
                _context.SaveChanges();
                return Ok($"{writer.WriterName} güncellendi");
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
                var deletedWriter = _context.Writes.FirstOrDefault(x => x.WriterId == id);
                var result = _context.Writes.Remove(deletedWriter);
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
