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
    [RoutePrefix("api/trips")]
    public class TripController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = TripService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetId(int id)
        {
            var data = TripService.GetId(id);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Trip not found");
        }
        [HttpGet]
        [Route("name")]
        public HttpResponseMessage GetName(string name)
        {
            var data = TripService.GetName(name);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Trip not found");
        }

        [HttpGet]
        [Route("byuser/{userId}")]
        public HttpResponseMessage GetByUser(int userId)
        {
            var data = TripService.Get().Where(t => t.UserID == userId).ToList();
            if (data.Any()) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No trips for this user");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(TripDTO dto)
        {
            var result = TripService.Create(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Trip created");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to create trip");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(TripDTO dto)
        {
            var result = TripService.Update(dto);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Trip updated");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to update trip");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = TripService.Delete(id);
            if (result) return Request.CreateResponse(HttpStatusCode.OK, "Trip deleted");
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Trip not found");
        }

        [HttpGet]
        [Route("{id}/recommend")]
        public HttpResponseMessage RecommendByTrip(int id)
        {
            var data = TripService.RecommendByTripId(id);
            if (data == null || !data.Any())
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No recommendations found");
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("recommend/destination/{destination}")]
        public HttpResponseMessage RecommendByDestination(string destination)
        {
            var data = TripService.RecommendByDestination(destination);
            if (data.Any())  
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No recommendations found");
        }

    }
}
