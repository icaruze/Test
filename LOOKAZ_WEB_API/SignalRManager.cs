using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LOOKAZ_WEB_API
{
    public class SignalRManager
    {
        public HubConnection SignalR { get; set; }

        public SignalRManager()
        {
            
        }

        public async Task<HubConnection> init()
        {
            //string url = "http://192.168.1.26:81/lookaz";/*DataManager.GetSystemVariable("SignalR_URL");*/
            string url = "http://192.168.1.88:30001/lookaz";

            var array = new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(60) };

            //1. signalR build
            SignalR = new HubConnectionBuilder().WithUrl(url).WithAutomaticReconnect(array).Build();
            SignalR.ServerTimeout = TimeSpan.FromSeconds(60);
            
            bool connection = false;

            try
            {
                await SignalR.StartAsync();
                connection = true;
            }
            catch (Exception ex)
            {
                connection = false;
            }
             
            if (connection == false) return null;

            signalR_mapping();

            return SignalR;
        }

        private void signalR_mapping()
        {
            //Receive 관련
            SignalR.On<string>("SendMessage", new Action<string>(x => SendMessage(x)));
            //SignalR.On<LOOKAZ_UPDATE_FLAG>("ReceiveDCGUpdateFlag", new Action<LOOKAZ_UPDATE_FLAG>((x) => ReceiveDCGUpdateFlag(x)));
        }

        private void SendMessage(string message)
        {

        }

        public void Dispose()
        {
            SignalR.DisposeAsync();
        }
    }
}
