using LOOKAZ_WEB_API.Controllers;
using Microsoft.AspNetCore.SignalR.Client;
using LinkGenesis.System.Redis;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

using LOOKAZ_WEB_API.SignalR;

namespace LOOKAZ_WEB_API.WorkerManagers
{
    public class DeviceWorker
    {
        public void TestStart(string data/*[FromBody] string? data*/)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestStart", data);

            manager.Dispose();
        }

        public void TestPause(string data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestPause", data);

            manager.Dispose();
        }

        public void TestAction(string data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestAction", data);

            manager.Dispose();
        }
    }
}
