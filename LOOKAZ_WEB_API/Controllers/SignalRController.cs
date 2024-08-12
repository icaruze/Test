using LOOKAZ_WEB_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LOOKAZ_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
#if true
        [HttpPost("UpdateDevice")]
        public void UpdateDevice([FromBody] string message)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("RefreshInfoServer", message);

            manager.Dispose();
        }

        //[HttpPost("TestStart")]
        //public void TestStart([FromBody] TestCmd message)
        //{
        //    var manager = new SignalRManager();
        //    HubConnection hub = manager.init().Result;

        //    hub.InvokeAsync("TestCaseStart", message);

        //    manager.Dispose();
        //}
#else

        [HttpPost("UpdateDevice")]
        public void UpdateDevice([FromBody] string message)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("RefreshInfoServer", message);

            manager.Dispose();
        }

        [HttpPost("SendControllerCommand")]
        public void SendControllerCommand([FromBody] SignalR_CMD_Model model)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("SendControllerCommand", model);

            manager.Dispose();
        }

        [HttpPost("SetRecordDevice")]
        public void SetRecordDevice([FromBody] SetRecordState model)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("SetRecordDevice", model.DEVICE_NAME, model.IS_Record);

            manager.Dispose();
        }
#endif
    }
}
