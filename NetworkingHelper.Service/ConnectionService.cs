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
                    Notes = model.Notes,
                    EventID = model.EventID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Connections.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ConnectionListModel> GetConnections()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Connections
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new ConnectionListModel
                                {
                                    ConnectionID = e.ConnectionID,
                                    ConnectionName = e.ConnectionName,
                                    Job = e.Job,
                                    Employer = e.Employer,
                                    EventID = e.EventID
                                }
                        );
                return query.ToArray();
            }
        }

        public ConnectionDetailModel GetConnectionById(int connectionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Connections
                        .Single(e => e.ConnectionID == connectionID && e.UserID == _userId);

                return
                    new ConnectionDetailModel
                    {
                        ConnectionID = entity.ConnectionID,
                        ConnectionName = entity.ConnectionName,
                        Job = entity.Job,
                        Employer = entity.Employer,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        Notes = entity.Notes,
                        EventID = entity.EventID
                    };
            }
        }

        public bool UpdateConnection(ConnectionEditModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Connections
                        .Single(e => e.ConnectionID == model.ConnectionID && e.UserID == _userId);

                entity.ConnectionName = model.ConnectionName;
                entity.Job = model.Job;
                entity.Employer = model.Employer;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConnection(int connectionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Connections
                        .Single(e => e.ConnectionID == connectionID && e.UserID == _userId);

                ctx.Connections.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
