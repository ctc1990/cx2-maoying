using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Process_Extraction
    {
        private static string server = "localhost";
        private static string database = "fe01fs";
        private static string uid = "root";
        private static string password = "abcd1234";
        string connString = "server=" + server + ";database=" + database + ";uid=" + uid + ";password=" + password + ";SSL Mode=none;";

        //public SubProcess ExecuteProcessExtraction(string equipment, int StartTime, int StopTime)
        //{
        //    SubProcess subProcess = new SubProcess();
        //    MySqlCommand mySqlCommand = new MySqlCommand();
        //    try
        //    {
        //        subProcess.StartTime = StartTime;
        //        subProcess.StopTime = StopTime;

        //        MySqlConnection mySqlConnection = new MySqlConnection(connString);

        //        mySqlCommand.Connection = mySqlConnection;
        //        mySqlCommand.CommandText = "select sub_process.equipment_state, sub_process.conditions from sub_process where sub_process.id = '" + equipment + "'";

        //        mySqlConnection.Open();

        //        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
        //        while (mySqlDataReader.Read())
        //        {
        //            subProcess.Equipment = mySqlDataReader["equipment_state"].ToString();
        //            string condition = mySqlDataReader["conditions"].ToString();

        //            subProcess = Decode(condition, subProcess);
        //            condition = condition.Replace("<", "=");
        //            condition = condition.Replace(">", "=");
        //            if (condition.Contains("StCon"))
        //            {
        //                subProcess.StartConditions += (subProcess.StartConditions == null ? "" : "~") + condition;
        //            }
        //            if (condition.Contains("ComCon"))
        //            {
        //                subProcess.StopConditions += (subProcess.StopConditions == null ? "" : "~") + condition;
        //            }
        //        }
        //        mySqlConnection.Close();

        //        return subProcess;
        //    }
        //    catch { return subProcess; }
        //}

        public static SubProcess ExecuteProcessExtraction(string equipment, int StartTime, int StopTime, string Description)
        {
            SubProcess subProcess = new SubProcess();

            try
            {
                subProcess.Description = Description;
                subProcess.StartTime = StartTime;
                subProcess.StopTime = StopTime;

                List<List<string>> equipment_conditions = Controllers.SQL.Query.ExecuteMultiQuery("select sub_process.equipment_state, sub_process.conditions " +
                                               "from sub_process where sub_process.id = '" + equipment + "'", new string[] { "equipment_state", "conditions" });
                subProcess.Equipment = equipment_conditions[0][0];

                foreach (string condition in equipment_conditions[1])
                {
                    string temp = condition;
                    subProcess = Decode(temp, subProcess);
                    temp = temp.Replace("<", "=");
                    temp = temp.Replace(">", "=");
                    if (temp.Contains("StCon"))
                    {
                        subProcess.StartConditions += (subProcess.StartConditions == null ? "" : "~") + temp;
                    }
                    if (temp.Contains("ComCon"))
                    {
                        subProcess.StopConditions += (subProcess.StopConditions == null ? "" : "~") + temp;
                    }
                }
            }
            catch { }

            return subProcess;
        }

        private static SubProcess Decode(string condition, SubProcess subProcess)
        {
            string addcondition = "";
            if (condition.Contains(">"))
            {
                addcondition = (Initialize())[condition.Substring(0, condition.IndexOf(">") + 1)].ToString() + "=True";
                subProcess.StartConditions += (subProcess.StartConditions == null ? "" : "~") + addcondition;
            }

            if (condition.Contains("<"))
            {
                addcondition = (Initialize())[condition.Substring(0, condition.IndexOf("<") + 1)].ToString() + "=True";
                subProcess.StopConditions += (subProcess.StartConditions == null ? "" : "~") + addcondition;
            }

            return subProcess;
        }

        private static Hashtable Initialize()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("iStCon1TargetVacuumLevel<", "bStCon11EnBelowTargetVacuumLevel");
            hashtable.Add("iStCon1TargetVacuumLevel>", "bStCon12EnAboveTargetVacuumLevel");
            hashtable.Add("iStCon2TargetPressureLevel<", "bStCon13EnBelowTargetPressureLevel");
            hashtable.Add("iStCon2TargetPressureLevel>", "bStCon14EnAboveTargetPressureLevel");
            hashtable.Add("iStCon3TargetProTankTempLevel<", "bStCon15EnBelowTargetProTankTempLevel");
            hashtable.Add("iStCon3TargetProTankTempLevel>", "bStCon16EnAboveTargetProTankTempLevel");
            hashtable.Add("iStCon4TargetSubTankTempLeve<", "bStCon17EnBelowTargetSubTankTempLevel");
            hashtable.Add("iStCon4TargetSubTankTempLeve>", "bStCon18EnAboveTargetSubTankTempLevel");

            hashtable.Add("iComCon1TargetVacuumLevel<", "bComCon11EnBelowTargetVacuumLevel");
            hashtable.Add("iComCon1TargetVacuumLevel>", "bComCon12EnAboveTargetVacuumLevel");
            hashtable.Add("iComCon2TargetPressureLevel<", "bComCon13EnBelowTargetPressureLevel");
            hashtable.Add("iComCon2TargetPressureLevel>", "bComCon14EnAboveTargetPressureLevel");
            hashtable.Add("iComCon3TargetProTankTempLevel<", "bComCon15EnBelowTargetProTankTempLevel");
            hashtable.Add("iComCon3TargetProTankTempLevel>", "bComCon16EnAboveTargetProTankTempLevel");
            hashtable.Add("iComCon4TargetSubTankTempLevel<", "bComCon17EnBelowTargetSubTankTempLevel");
            hashtable.Add("iComCon4TargetSubTankTempLevel>", "bComCon18EnAboveTargetSubTankTempLevel");

            return hashtable;
        }

        public struct SubProcess
        {
            public string Description;
            public string Equipment;
            public int StartTime;
            public int StopTime;
            public string StartConditions;
            public string StopConditions;
        }
    }
}
