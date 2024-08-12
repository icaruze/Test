//using LOOKAZ_MODBUS_API.Model;
using LOOKAZ_WEB_API.Model;
using Microsoft.AspNetCore.SignalR;

namespace LOOKAZ_WEB_API.SignalR
{
    public class LOOKAZ : Hub
    {
        public override Task OnConnectedAsync()
        {
            string name = Context.ConnectionId;
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// DEVICE 그룹 가입
        /// </summary>
        /// <returns></returns>
        public async Task AddGroupLOOKAZ() => await Groups.AddToGroupAsync(Context.ConnectionId, "LOOKAZ");

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}: {message}");
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public async Task SendPrivateMessage(string user, string message)
        {
            await Clients.Client(user).SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// Start 명령
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task TestCaseStart(TestCmd data) => await Clients.Group("LOOKAZ").SendAsync("TestStart", data);
        //await Clients.Group("LOOKAZ").SendAsync("TestStart", message);

        // <summary>
        /// 일시정지 명령
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task TestCasePause(TestCmd data) => await Clients.Group("LOOKAZ").SendAsync("TestPause", data);

        // <summary>
        /// 정지 명령
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task TestCaseStop(TestCmd data) => await Clients.Group("LOOKAZ").SendAsync("TestStop", data);

        // <summary>
        /// 테스트 NG 명령
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task TestNG(TestCmd data) => await Clients.Group("LOOKAZ").SendAsync("TestNG", data);

        // <summary>
        /// 테스트 OK 명령
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task TestOK(TestCmd data) => await Clients.Group("LOOKAZ").SendAsync("TestOK", data);

        // <summary>
        /// Start 명령
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task TestCaseAction(string message) => await Clients.Group("LOOKAZ").SendAsync("TestAction", message);

        /// <summary>
        /// 기준정보 갱신
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task RefreshInfoServer(string message = "Hello") => await Clients.Group("LOOKAZ").SendAsync("RefreshServer", message);

#if false
        /// <summary>
        /// DEVICE CMD 처리
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task SendControllerCommand(SignalR_CMD_Model model) => await Clients.Group("LOOKAZ").SendAsync("ControlCommnand", model);

        /// <summary>
        /// 기준정보 갱신
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task RefreshInfoServer(string message = "Hello") => await Clients.Group("LOOKAZ").SendAsync("RefreshServer", message);


        /// <summary>
        /// DEVICE 데이터베이스 기록 여부 갱신
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task CheckRecodeDevice(string message = "Hello") => await Clients.Group("LOOKAZ").SendAsync("RecodeStateCheck", message);

        /// <summary>
        /// DEVICE 데이터베이스 기록 여부
        /// </summary>
        /// <param name="device"></param>
        /// <param name="is_Recode"></param>
        /// <returns></returns>
        public async Task SetRecordDevice(string deviceName, bool is_Recode) => await Clients.Group("LOOKAZ").SendAsync("SetRecordDevice", deviceName, is_Recode);

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}: {message}");
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public async Task SendPrivateMessage(string user, string message)
        {
            await Clients.Client(user).SendAsync("ReceiveMessage", message);
        }
#endif
    }
}
