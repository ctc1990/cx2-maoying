using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.MemoryManagement
{
    class Machine
    {
        public static bool POST_MachineMemory(TcAdsClient adsClient)
        {
            try
            {
                List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery("select * from memory_machine", new string[] { "variable_name", "variable_value", "variable_type" });

                for (int i = 0; i < list[0].Count(); i++)
                {
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, list[0][i], list[1][i], list[2][i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
