using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class CompanyProcessingController : ODataController    
    {
        public IQueryable<Company> Get()
        {
            return CompanyRep.list.AsQueryable();
        }
        //Fetch company information by Id   
        public HttpResponseMessage Get([FromODataUri]int key)
        {
            var com = CompanyRep.list.Where(e => e.Id == key).SingleOrDefault();
            if (com == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, com);
        } 
    }
}
