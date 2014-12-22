using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lion.Core;

namespace Lion.WebClient.Controllers
{
    public class StudController : Controller
    {
        IStudent Student = new StudentDetail();
        // GET: Stud
        public ActionResult Index1()
        {
            return View();
        }

        

        // GET api/students
        public JsonResult Index()
        {
            List<Student> students = Student.GetAll();

            return Json(students,  JsonRequestBehavior.AllowGet);
        }

        // GET api/students/5
        public Student Get(int id)
        {
            return Student.FindStudentById(id);
        }


    }
}