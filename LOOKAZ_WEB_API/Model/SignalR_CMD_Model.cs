//using LOOKAZ_MODBUS_API.Enum;

namespace LOOKAZ_WEB_API.Model
{
    public class SignalR_CMD_Model
    {
        public string IX_NO { get; set; }
        public string CD_CONTROLLER { get; set; }
        public string DEVICE_NAME { get; set; }
        public List<SignalR_CMD_Model_Detail> SignalR_CMD_Model_Details { get; set; } = new List<SignalR_CMD_Model_Detail>();
    }

    public class SignalR_CMD_Model_Detail
    {
     
    }

    public class TestCmd
    {
#if true
        public string COMMAND { get; set; } //CMD 명령( NEW_START etc...)
        public string CD_BOX_PC { get; set; }   //BOX PC Name
#else
        public string ActionName { get; set; } = string.Empty;      //액션
        public string ConnectionType { get; set; } = string.Empty;  //연결 방식: TCP/IP or Serial
        public string ModelName { get; set; } = string.Empty;       //모델명
        public string NoItem { get; set; } = string.Empty;          //모델 번호
        //public string Chamber { get; set; } = string.Empty;         //Single/ Dual        
        public string PlcCompany { get; set; } = string.Empty;         //OMRON/ LS/ MODBUS
        public string Position { get; set; } = string.Empty;        //Left / Right

        public bool CheckAuto { get; set; } = true;                 //자동: true, 반자동: false
#endif
    }
}
