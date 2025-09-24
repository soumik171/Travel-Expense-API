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
    
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetId(int id)
        {
            var data = new UserService().Get(id);
            if (data != null)
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No User Found");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(UserDTO userDto)
        {
            var result = new UserService().Create(userDto);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, "User Created Successfully");

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to Create User");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(UserDTO userDto)
        {
            var result = new UserService().Update(userDto);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, "User Updated Successfully");

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to Update User");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = new UserService().Delete(id);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, "User Deleted Successfully");

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found");
        }
    }

}

