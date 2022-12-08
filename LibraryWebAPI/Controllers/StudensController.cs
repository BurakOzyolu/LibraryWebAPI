using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudensController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok("Bütün öğrenciler listelendi");
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"{id} ye sahip öğrenci görüntülendi");
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string student, int id)
        {
            return Ok($"{id}. Kitap, {student} güncellendi");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"{id} ye sahip öğrenci silindi");
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create(string ogrenci)
        {
            return Ok($"{ogrenci} isimli öğrenci eklendi");
        }
    }
}
