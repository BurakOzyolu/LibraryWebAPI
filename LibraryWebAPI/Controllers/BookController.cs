using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
              return Ok("Bütün kitaplar listelendi");
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"{id} ye sahip kitap görüntülendi");
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
