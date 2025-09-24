using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APPLICATION.Controllers
{
    [RoutePrefix("api/users/notifications")]

    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = NotificationService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
