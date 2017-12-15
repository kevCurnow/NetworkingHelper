using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NetworkingHelper.Services;
using NetworkingHelper.Models.ConnectionModels;
using Microsoft.AspNet.Identity;

namespace NetworkingHelper.WebApi.Controllers
{
    [Authorize]
    public class ConnectionController : ApiController
    {
        // GET /api/event
        public IHttpActionResult GetAll()
        {
            var connectionService = CreateConnectionService();
            var connections = connectionService.GetConnections();
            return Ok(connections);
        }
        public IHttpActionResult Get(int id)
        {
            var connectionService = CreateConnectionService();
            var connection = connectionService.GetConnectionById(id);
            return Ok(connection);
        }

        public IHttpActionResult Post(ConnectionCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateConnectionService();

            if (!service.CreateConnection(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ConnectionEditModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateConnectionService();

            if (!service.UpdateConnection(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateConnectionService();

            if (!service.DeleteConnection(id))
                return InternalServerError();

            return Ok();
        }

        private ConnectionService CreateConnectionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var connectionService = new ConnectionService(userId);
            return connectionService;
        }
    }
}
