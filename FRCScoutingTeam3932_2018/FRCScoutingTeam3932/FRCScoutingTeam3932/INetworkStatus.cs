using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace FRCScoutingTeam3932
{
    public enum ConnectionStatus
    {
        NotConnected,
        WifiConnected,
        CellConnected
    }

    interface INetworkStatus
    {
        ConnectionStatus GetConnectionStatus();
    }
}
