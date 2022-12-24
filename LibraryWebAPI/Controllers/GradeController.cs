using LibraryWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        MyContext _context;

        public GradeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var Grades = _context.Grades.ToList();
            return Ok(Grades);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Grade = _context.Grades.FirstOrDefault(x => x.GradeId == id);
            return Ok(Grade);
        }

        //Ekleme İşlemi 
        [HttpPost]
        [Route("add")]
        public IActionResult Create(Grade Grade)
        {
            var newGrade = new Grade()
            {
                GradeName = Grade.GradeName
            };
            _context.Grades.Add(newGrade);
            _context.SaveChanges();
            return Ok($"{Grade.GradeName} eklendi");
        }

        //Güncelleme İşlemi Yapar
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Grade Grade)
        {
            try
            {
                var editGrade = _context.Grades.FirstOrDefault(x => x.GradeId == Grade.GradeId);
                editGrade.GradeName = Grade.GradeName;
                _context.SaveChanges();
                return Ok($"{Grade.GradeName} güncellendi");
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
                var deletedGrade = _context.Grades.FirstOrDefault(x => x.GradeId == id);
                var result = _context.Grades.Remove(deletedGrade);
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
