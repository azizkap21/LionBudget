using Lion.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lion.API.Controllers
{
    public class StudentsController : ApiController
    {

        IStudent Student = new StudentDetail();

        // GET api/students
        public IEnumerable<Student> Get()
        {
            return Student.GetAll().AsEnumerable(); 
        }

        // GET api/students/5
        public Student Get(int id)
        {
            return Student.FindStudentById (id);
        }

        // POST api/students
        public void Post([FromBody]string value)
        {
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
