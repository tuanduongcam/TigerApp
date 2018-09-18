using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManager.Web.Controllers
{
    public class AppInfoController : ApiController
    {
        // GET: api/AppInfo
        public string GetVersion()
        {
            return "0.9-1.2";
        }

        // GET: api/AppInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AppInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppInfo/5
        public void Delete(int id)
        {
        }
    }
}
