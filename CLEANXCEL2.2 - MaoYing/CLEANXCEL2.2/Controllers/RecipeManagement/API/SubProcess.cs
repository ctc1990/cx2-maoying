using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class SubProcess
    {
        public static bool Create_SQLSubProcessId(string SubProcessName)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Parameters.AddWithValue("@sub_process_name", SubProcessName);
                mySqlCommand.Parameters.AddWithValue("@status", "1");
                Controllers.SQL.Query.ExecuteNonQuery("insert into sub_process_id (name, status) values(@sub_process_name, @status);", mySqlCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLSubProcessId()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from sub_process_id;", new string[] { "id", "name", "status" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLSubProcessId_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from sub_process_id where id = '" + id + "';", new string[] { "id", "name", "status" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static bool Create_SQLSubProcess(string EquipmentName, string EquipmentState, string Conditions)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Parameters.AddWithValue("@equipment_name", EquipmentName);
                mySqlCommand.Parameters.AddWithValue("@equipment_state", EquipmentState);
                mySqlCommand.Parameters.AddWithValue("@conditions", Conditions);
                Controllers.SQL.Query.ExecuteNonQuery("insert into sub_process (sub_process_name, equipment_name, equipment_state, conditions) values(" +
                    "(select max(id) from sub_process_id), @equipment_name, @equipment_state, @conditions);", mySqlCommand);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLSubProcess()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from sub_process;", new string[] { "id", "sub_process_name", "equipment_name", "equipment_state", "conditions" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLSubProcess_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from sub_process where id = '" + id + "';", new string[] { "id", "sub_process_name", "equipment_name", "equipment_state", "conditions" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLSubProcess_By_SubProcessID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from sub_process where sub_process_name = '" + id + "';", new string[] { "id", "sub_process_name", "equipment_name", "equipment_state", "conditions" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }
    }
}
