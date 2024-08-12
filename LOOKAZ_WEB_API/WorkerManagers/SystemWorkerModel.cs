namespace LOOKAZ_WEB_API.WorkerManager
{
    public class QueryInfo
    {
        public string SQL_ID { get; set; }
        public string SQL_TEXT { get; set; }
    }

    public class System_Enviroment
    {
        public string ENV_CODE { get; set; }
        public string ENV_VALUE { get; set; }
        public string ENV_DESC { get; set; }
    }

    public class CodeCategory
    {
        public string Category { get; set; }

        public List<CodeItme> CodeItmes { get; set; } = new List<CodeItme>();
    }

    public class CodeItme
    {
        public string CODE { get; set; }
        public string NM_CODE { get; set; }
        public string DE_CODE { get; set; }
    }

    public class CodeInfo
    {
        public string CD_CATEGORY { get; set; }
        public string CODE { get; set; }
        public string NM_CODE { get; set; }
        public string DE_CODE { get; set; }
    }

    public class SMS_User_Info
    {
        public string ID_USER { get; set; }
        public string PHONE { get; set; }
    }
}
