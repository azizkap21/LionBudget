using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.Core
{
    public interface  IStudent
    {
        bool AddStudent(Student student);

        List<Student> GetAll();

        Student FindStudentById(int studentId);
    }


    public class StudentDetail:IStudent
    {
        public static List<Student> StudentList { get; set; }

        public StudentDetail ()
        {
            StudentList = new List<Student>();
            StudentList.Add(new Student() { StudentId = 1, StudentName = "Aziz", Address = "aadfsdfsdf" });
            StudentList.Add(new Student() { StudentId = 2, StudentName = "Amol", Address = "aadfsdfsdf" });
            StudentList.Add(new Student() { StudentId = 3, StudentName = "Rajesh", Address = "aadfsdfsdf" });
            StudentList.Add(new Student() { StudentId = 4, StudentName = "Sachida", Address = "aadfsdfsdf" });
        }

        public bool AddStudent(Student student)
        {
            StudentList.Add(student);
            return true;
        }

        public List<Student> GetAll()
        {
            return StudentList;
        }

        public Student FindStudentById(int studentId)
        {
           return  StudentList.FirstOrDefault(x => x.StudentId == studentId);

        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string  StudentName { get; set; }
        public string  Address { get; set; }
    }

}
