using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.DataModel
{
    partial class Teacher
    {
        private const int MAX_CLASS_SIZE = 8;
        public void EnrollInClass (Student student)
        {
            int numStudents = (from s in Students
                               where s.TeacherUserId ==UserId
                               select s).Count();
            if (numStudents >= MAX_CLASS_SIZE)
            {
                // So throw a ClassFullException and specify the class that is full.
                throw new ClassFullException("Class full: Unable to enroll student", Class);
            }
            if (student.TeacherUserId == null)
            {
                // Set the TeacherID property of the student.
                student.TeacherUserId = UserId;
            }
            else
            {
                // If the student is already assigned to a class, throw an ArgumentException.
                throw new ArgumentException("Student", "Student is already assigned to a class");
            }
        }

    }
}
