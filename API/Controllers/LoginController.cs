using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class LoginController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Validate(string token, int id)
        {
            bool exists = new Student().Students(id) != null;
            if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
                 "The user was not found.");
            string tokenUsername = TokenManager.ValidateToken(token);
            if ((id.ToString()).Equals(tokenUsername))
                return Request.CreateResponse(HttpStatusCode.OK,id);
            return Request.CreateResponse(HttpStatusCode.BadRequest,"Bad Request");
        }

        [HttpPost]
        public HttpResponseMessage Login(Student st)
        {
            Student student = new Student();
            var entity = student.Students(st.id);
            if (entity == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "The user does not exist");
            return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(st.id.ToString()));
        }

    }
}
