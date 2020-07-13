using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using ReactWebApi.Models;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ReactWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        EmployeeDC objEmployye = new EmployeeDC();
        // GET api/values
        public string Get()
        
        {
            
           DataTable dt= objEmployye.GetAllEmployee();        
          string Json= JsonConvert.SerializeObject(dt, Formatting.Indented);
          return Json;
           // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string  Get(int id)
        {
            DataTable dt = objEmployye.GetEmployee(id.ToString());
            string Json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json;
            //return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]EmployeeMo value)
        {
            bool Status = objEmployye.SaveEmployee(value);
            if(Status)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

        }

        // PUT api/values/5
        public HttpResponseMessage  Put(int id, [FromBody]EmployeeMo value)
        {
           bool status= objEmployye.UpdateEmployee(id,value);
            if(status)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            bool status = objEmployye.DeleteEmployee(id.ToString());
            if (status)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}