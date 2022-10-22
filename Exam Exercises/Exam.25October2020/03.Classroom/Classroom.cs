using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.All(s => s.Subject != subject))
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in students.Where(s => s.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName) => students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
