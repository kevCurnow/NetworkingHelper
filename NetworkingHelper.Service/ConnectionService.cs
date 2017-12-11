using NetworkingHelper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkingHelper.Models.ConnectionModels;
using NetworkingHelper.Data;

namespace NetworkingHelper.Services
{
    public class ConnectionService : IConnection
    {
        private readonly Guid _userId;

        public ConnectionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateConnection(ConnectionCreateModel model)
        {
            var entity =
                new ConnectionEntity
                {
                    UserID = _userId,
                    ConnectionName = model.ConnectionName,
                    Job = model.Job,
                    Employer = model.Employer,
                    Phone = model.Phone,
                    Email = model.Email,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Connections.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConnection(int connectionID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConnectionListModel> GetConections()
        {
            throw new NotImplementedException();
        }

        public ConnectionDetailModel GetConnectionById(int connectionID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateConnection(ConnectionEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
