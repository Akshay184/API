using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        static List<string> st = new List<string>
        {
            "value1" , "value2", "value3"
        };
        public IEnumerable<string> Get()
        {
            return st;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return st[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            st.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            st[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            st.RemoveAt(id);
        }
    }
}
