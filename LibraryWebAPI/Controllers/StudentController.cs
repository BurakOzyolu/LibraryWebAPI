using LibraryWebAPI.Models;
using LibraryWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;


namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        MyContext _context;

        public StudentController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {

            List<StudentViewModel> studentlist = new List<StudentViewModel>();
            var students = _context.Students.Where(x=> x.IsDeleted == false);
            var Grade = _context.Grades.ToList();

            foreach (var item in students)
            {
                StudentViewModel student = new StudentViewModel();
                student.studentId = item.studentId;
                student.studentName = item.studentName;

                var gradeBool = Grade.FirstOrDefault(x => x.GradeId == item.GradeId);
                string gradeName = (gradeBool==null) ? "": gradeBool.GradeName;
                student.GradeName = gradeName;
                student.GradeId = item.GradeId;
                studentlist.Add(student);
                 }
                return Ok(studentlist);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.studentId == id);
            return Ok(student);
        }

        //Ekleme İşlemi 
        [HttpPost]
        [Route("add")]
        public IActionResult Create(StudentViewModel student)
        {
            var gradeBool = _context.Grades.Any(x => x.GradeName == student.GradeName);
            int gradeId;
            if (gradeBool)
            {
                gradeId = _context.Grades.FirstOrDefault(x => x.GradeName == student.GradeName).GradeId;
                var newStudent = new Student()
            {
                studentName = student.studentName,
                GradeId = gradeId,
                IsDeleted = false
            };
                 _context.Students.Add(newStudent);
                _context.SaveChanges();
                 return Ok($"{student.studentName} eklendi");
            }
            else
            {
                return Ok("Ekleme işlemi yapılamadı");
            }
        }

        //Güncelleme İşlemi Yapar
        [HttpPut]
        [Route("update")]
        public IActionResult Update(StudentViewModel student)
        {
            try
            {
                var editdata = _context.Students.FirstOrDefault(x => x.studentId == student.studentId);
                var gradeBool = _context.Grades.Any(x => x.GradeName == student.GradeName);
                int gradeId;
                if (gradeBool)
                {
                    gradeId = _context.Grades.FirstOrDefault(x => x.GradeName == student.GradeName).GradeId;
                    editdata.studentName = student.studentName;
                    editdata.IsDeleted = false;
                    editdata.GradeId = gradeId;
                    _context.SaveChanges();
                    return Ok($"{student.studentName} güncellendi");
                }
                else
                {
                    return Ok("Güncelleme işlemi yapılamadı");
                }
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
                var deleteddata = _context.Students.FirstOrDefault(x => x.studentId == id);
                var result = _context.Students.Remove(deleteddata);
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
