using LibraryWebAPI.Models;
using LibraryWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        MyContext _context;

        public ProcessController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            List<ProcessViewModel> processlist = new List<ProcessViewModel>();
            var StudentList = _context.Students.ToList();
            var BookList = _context.Books.ToList();

            foreach (var item in _context.Processes.Where(x=> x.ReturnDate == null))
            {
                ProcessViewModel process = new ProcessViewModel();
                process.PurchaseDate = item.PurchaseDate;
                process.processId = item.ProcessId;

                var studentbool = StudentList.Any(x => x.studentId == item.StudentId);
                if (studentbool)
                {
                    var studentId = StudentList.FirstOrDefault(x => x.studentId == item.StudentId);
                    string studentName = (studentId == null) ? "" : studentId.studentName;
                    process.StudentName = studentName;
                }
                else
                {
                    process.StudentName = "";
                }
                var bookbool = BookList.Any(x => x.BookId == item.BookId);

                if (bookbool)
                {
                    var bookId = BookList.FirstOrDefault(x => x.BookId == item.BookId);
                    string bookName = (bookId == null) ? "" : bookId.BookName;
                    process.BookName = bookName;
                }
                else
                {
                    process.BookName = "";
                }
                processlist.Add(process);

            }
            return Ok(processlist);
        }

        [HttpGet]
        [Route("getendall")]
        public IActionResult GetFinnish()
        {
            List<ProcessEndViewModel> processlist = new List<ProcessEndViewModel>();
            var StudentList = _context.Students.ToList();
            var BookList = _context.Books.ToList();
            var endProcessList = _context.Processes.Where(x => x.ReturnDate != null);
            foreach (var item in endProcessList)
            {
                ProcessEndViewModel process = new ProcessEndViewModel();
                process.PurchaseDate = item.PurchaseDate;
                process.processId = item.ProcessId;
                process.ReturnDate = (DateTime)item.ReturnDate;

                var studentId = StudentList.FirstOrDefault(x => x.studentId == item.StudentId);
                string studentName = (studentId == null) ? "" : studentId.studentName;
                process.StudentName = studentName;

                var bookId = BookList.FirstOrDefault(x => x.BookId == item.BookId);
                string bookName = (bookId == null) ? "" : bookId.BookName;
                process.BookName = bookName;

                processlist.Add(process);

            }
            return Ok(processlist);
        }

        //Ekleme İşlemi 
        [HttpPost]
        [Route("add")]
        public IActionResult Create(ProcessAddViewModel newProcess)
        {
            var boolStudent = _context.Students.Any(x => x.studentName == newProcess.StudentName);
            var boolBook = _context.Books.Any(x => x.BookName == newProcess.BookName);
            if (boolStudent && boolBook)
            {
                try
                {
                    var studentId = _context.Students.FirstOrDefault(x => x.studentName == newProcess.StudentName).studentId;
                    var bookId = _context.Books.FirstOrDefault(x => x.BookName == newProcess.BookName).BookId;

                    var process = new Process()
                    {
                        BookId = bookId,
                        StudentId = studentId,
                        PurchaseDate = DateTime.UtcNow
                    };
                    var result = _context.Processes.Add(process);
                    _context.SaveChanges();
                    return Ok("Process işlemi eklendi");
                }
                catch
                {
                    return Ok("Ekleme işlemi yapılamadı");
                }
            }
            else
            {
                return Ok("Ekleme işlemi yapılamadı");
            }
        }


        //Silme İşlemi
        [HttpPost]
        [Route("return/{id}")]
        public IActionResult Return(int id)
        {
            try
            {
                var receiveBook  = _context.Processes.FirstOrDefault(x => x.ProcessId == id);
                receiveBook.ReturnDate = DateTime.UtcNow;
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
