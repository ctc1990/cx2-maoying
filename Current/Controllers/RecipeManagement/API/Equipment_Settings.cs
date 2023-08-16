using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Equipment_Settings
    {
        public static bool UploadSettings_Heater(TcAdsClient adsClient, int index, string Setpoint, string FirstAlarm, string SecondAlarm, string Hysteresis, string PreparationTemp, string PreparationTime)
        {
            try
            {
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnTempSV[" + index.ToString() + "]", Setpoint, "real");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnTemp1stLimitSv[" + index.ToString() + "]", FirstAlarm, "real");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnTempHALsv[" + index.ToString() + "]", SecondAlarm, "real");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnTempHYSsv[" + index.ToString() + "]", Hysteresis, "real");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnTempRDYsv[" + index.ToString() + "]", PreparationTemp, "real");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARiStnPreparationTempSv[" + index.ToString() + "]", PreparationTime, "int");

                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + Setpoint + "' " +
                    "where variable_name = '.ARrStnTempSV[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + FirstAlarm + "' " +
                    "where variable_name = '.ARrStnTemp1stLimitSv[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + SecondAlarm + "' " +
                    "where variable_name = '.ARrStnTempHALsv[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + Hysteresis + "' " +
                    "where variable_name = '.ARrStnTempHYSsv[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + PreparationTemp + "' " +
                    "where variable_name = '.ARrStnTempRDYsv[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + PreparationTime + "' " +
                    "where variable_name = '.ARiStnPreparationTempSv[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> DownloadSettings_Heater(TcAdsClient adsClient, int index)
        {
            try
            {
                List<string> list = new List<string>();

                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnTempSV[" + index.ToString() + "]"));
                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnTemp1stLimitSv[" + index.ToString() + "]"));
                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnTempHALsv[" + index.ToString() + "]"));
                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnTempHYSsv[" + index.ToString() + "]"));
                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnTempRDYsv[" + index.ToString() + "]"));
                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARiStnPreparationTempSv[" + index.ToString() + "]"));

                return list;
            }
            catch
            {
                return new List<string>();
            }
        }

        public static bool UploadSettings_Pressure(TcAdsClient adsClient, int index, string LowerBoundary, string UpperBoundary)
        {
            try
            {
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnLowVacuumLevelSV[" + index.ToString() + "]", LowerBoundary, "real");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnHighVacuumLevelSV[" + index.ToString() + "]", UpperBoundary, "real");

                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + LowerBoundary + "' " +
                    "where variable_name = '.ARrStnLowVacuumLevelSV[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                Controllers.SQL.Query.ExecuteNonQuery("update memory_machine set variable_value = '" + UpperBoundary + "' " +
                    "where variable_name = '.ARrStnHighVacuumLevelSV[" + index.ToString() + "]'", new MySql.Data.MySqlClient.MySqlCommand());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> DownloadSettings_Pressure(TcAdsClient adsClient, int index)
        {
            try
            {
                List<string> list = new List<string>();

                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnLowVacuumLevelSV[1]"));
                list.Add(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnHighVacuumLevelSV[1]"));

                return list;
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}
