using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Process
    {
        public static bool Create_SQLProcessId(string ProcessName)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Parameters.AddWithValue("@process_name", ProcessName);
                mySqlCommand.Parameters.AddWithValue("@status", "1");
                Controllers.SQL.Query.ExecuteNonQuery("insert into process_id (name, status) values(@process_name, @status);", mySqlCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLProcessId()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from process_id;", new string[] { "id", "name", "status" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLProcessId_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from process_id where id = '" + id + "';", new string[] { "id", "name", "status" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static bool Create_SQLProcess(string SubProcessName, string Conditions)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Parameters.AddWithValue("@sub_process_name", SubProcessName);
                mySqlCommand.Parameters.AddWithValue("@conditions", Conditions);
                Controllers.SQL.Query.ExecuteNonQuery("insert into process (process_name, sub_process_name, conditions) values(" +
                    "(select max(id) from process_id), (select id from sub_process_id where sub_process_id.name = @sub_process_name), @conditions);", mySqlCommand);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLProcess()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from process;", new string[] { "id", "process_name", "sub_process_name", "conditions" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLProcess_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from process where id = '" + id + "';", new string[] { "id", "process_name", "sub_process_name", "conditions" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLProcess_By_ProcessID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from process where process_name = '" + id + "';", new string[] { "id", "process_name", "sub_process_name", "conditions" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }
    }
}
