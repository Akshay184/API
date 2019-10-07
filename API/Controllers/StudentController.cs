using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace API.Controllers
{
    public class StudentController : ApiController

        // List of student
        
    {
        // GET: Student
        public IEnumerable<Student> Get()
        {
            Student student = new Student();
            return student.AllStudents();
        }

        public HttpResponseMessage GET(int id)
        {
            Student Student = new Student();
            var entity = Student.Students(id);
            if (entity != null)
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee id does not exist");
        }

        public HttpResponseMessage Post([FromBody]Student Student)
        {
            Student student = new Student();
            student.AddStudent(Student);
            var message = Request.CreateResponse(HttpStatusCode.Created, Student);
            message.Headers.Location = new Uri(Request.RequestUri + Student.id.ToString());
            return message;
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Student student = new Student();
                var entity = student.RemoveStudent(id);
                if (entity == 1)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student id does not exist");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }

        public HttpResponseMessage Put(int id,[FromBody]Student Student)
        {
            try
            {
                Student student = new Student();
                int entity = student.Update(id,Student);
                if (entity == 1)
                    return Request.CreateResponse(HttpStatusCode.OK,Student);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student does not exist");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}