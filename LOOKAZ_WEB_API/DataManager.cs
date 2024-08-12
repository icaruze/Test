using LOOKAZ_WEB_API.WorkerManager;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Concurrent;

namespace LOOKAZ_WEB_API
{
    public static class DataManager
    {
        private static object LockItem = new object();
        private static ConcurrentDictionary<string, string>? SystemVariable { get; set; }

        public static void SetSystemVariable(List<System_Enviroment> items)
        {
            lock (LockItem)
            {
                SystemVariable = new();
                items.ForEach(x => SystemVariable.TryAdd(x.ENV_CODE.ToLower(), x.ENV_VALUE.ToLower()));
            }
        }

        public static string GetSystemVariable(string ENV_CODE)
        {
            string retVal = string.Empty;

            lock (LockItem)
            {
                if (SystemVariable.ContainsKey(ENV_CODE.ToLower())) retVal = SystemVariable[ENV_CODE.ToLower()];
            }

            return retVal;
        }
    }
}
