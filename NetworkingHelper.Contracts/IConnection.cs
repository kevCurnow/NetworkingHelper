using NetworkingHelper.Models.ConnectionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Contracts
{
    public interface IConnection
    {
        bool CreateConnection(ConnectionCreateModel model);
        IEnumerable<ConnectionListModel> GetConnections();
        ConnectionDetailModel GetConnectionById(int connectionID);
        bool UpdateConnection(ConnectionEditModel model);
        bool DeleteConnection(int connectionID);
    }
}
