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
    [RoutePrefix("api/categories")]
    public class ExpenseCategoryController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = ExpenseCategoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ExpenseCategoryDTO dto)
        {
            var result = ExpenseCategoryService.Create(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Category created");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to create category");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(ExpenseCategoryDTO dto)
        {
            var result = ExpenseCategoryService.Update(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Category updated");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to update category");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = ExpenseCategoryService.Delete(id);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Category deleted");
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category not found");
        }
    }
}
