using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LOOKAZ_WEB_API.WorkerManagers;
using Microsoft.AspNetCore.SignalR.Client;
using LOOKAZ_WEB_API.SignalR;
using LOOKAZ_WEB_API.Model;

namespace LOOKAZ_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

        //Test 시작
        [HttpPost("TestStart")]
        public void TestStart([FromBody] TestCmd data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestCaseStart", data);

            manager.Dispose();
        }

        //Test 일시 정지
        [HttpPost("TestPause")]
        public void TestPause([FromBody] TestCmd data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestCasePause", data);

            manager.Dispose();
        }

        //Test 정지 및 종료
        [HttpPost("TestStop")]
        public void TestStop([FromBody] TestCmd data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestCaseStop", data);

            manager.Dispose();
        }

        //Test 시나리오 OK - SEMI_AUTO (Chiller의 경우만) 
        [HttpPost("TestOK")]
        public void TestOK([FromBody] TestCmd data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestOK", data);

            manager.Dispose();
        }

        //Test 시나리오 NG - SEMI_AUTO (Chiller, Scrubber)
        [HttpPost("TestNG")]
        public void TestNG([FromBody] TestCmd data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestNG", data);

            manager.Dispose();
        }

        [HttpPost("TestAction")]
        //public void CustommerAction([FromBody] string data)
        public void TestAction([FromBody] string data)
        {
            var manager = new SignalRManager();
            HubConnection hub = manager.init().Result;

            hub.InvokeAsync("TestCaseAction", data);

            manager.Dispose();
        }

    }
}
