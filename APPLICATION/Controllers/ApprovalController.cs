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
    [RoutePrefix("api/approvals")]
    public class ApprovalController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = ApprovalService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("byexpense/{expenseId}")]
        public HttpResponseMessage GetByExpense(int expenseId)
        {
            var data = ApprovalService.Get().Where(a => a.ExpenseID == expenseId).ToList();
            if (data.Any()) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No approvals for this expense");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ApprovalDTO dto)
        {
            var result = ApprovalService.Create(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Approval created");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to create approval");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(ApprovalDTO dto)
        {
            var result = ApprovalService.Update(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Approval updated");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to update approval");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = ApprovalService.Delete(id);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Approval deleted");
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Approval not found");
        }
    }
}
