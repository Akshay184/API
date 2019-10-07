using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Dbo;

namespace API.Models
{
    public class Student : IStudent
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Student> AllStudents()
        {
            using(StudentDbContext db = new StudentDbContext())
            {
                return db.Students.ToList();
            }
        }

        public Student Students(int id)
        {
            using(StudentDbContext db = new StudentDbContext())
            {
                return db.Students.FirstOrDefault(x => x.id == id);
            }
        }

        public void AddStudent(Student student)
        {
            using(StudentDbContext db = new StudentDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public int RemoveStudent(int id)
        {
            using(StudentDbContext db = new StudentDbContext())
            {
                var entity = db.Students.FirstOrDefault(x => x.id == id);
                
                if (entity != null)
                {
                    db.Students.Remove(entity);
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 0;
            }
        }

        public int Update(int id,Student student)
        {
            using(StudentDbContext db = new StudentDbContext())
            {
                var entity = db.Students.FirstOrDefault(x => x.id == id);
                if (entity != null)
                {
                    entity.Name = student.Name;
                    entity.Email = student.Email;
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 0;
            }
        }
    }

    
}