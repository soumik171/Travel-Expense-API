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
    [RoutePrefix("api/expenses")]
    public class ExpenseController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = ExpenseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("bytrip/{tripId}")]
        public HttpResponseMessage GetByTrip(int tripId)
        {
            var data = ExpenseService.GetByTrip(tripId);
            if (data != null && data.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No expenses for this trip");
        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ExpenseDTO dto)
        {
            var result = ExpenseService.Create(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Expense created");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to create expense");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(ExpenseDTO dto)
        {
            var result = ExpenseService.Update(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Expense updated");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to update expense");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = ExpenseService.Delete(id);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Expense deleted");
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Expense not found");
        }

    }
}
