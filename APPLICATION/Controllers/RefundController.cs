using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APPLICATION.Controllers
{
    [RoutePrefix("api/refunds")]
    public class RefundController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = RefundService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = RefundService.Get(id);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Refund not found");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(RefundDTO dto)
        {
            var result = RefundService.Create(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Refund created");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to create refund");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(RefundDTO dto)
        {
            var result = RefundService.Update(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Refund updated");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to update refund");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = RefundService.Delete(id);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Refund deleted");
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Refund not found");
        }
    }
}
