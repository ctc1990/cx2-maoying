using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.SubProcessBlock
{
    class Degassing
    {
        public static void Encode_Degassing(string ProcessName, int start_time, int ultrasonic_time, int steady_time, int pulses)
        {
            int start, stop = start_time;
            int ultrasonic_count = Convert.ToInt32(Controllers.SQL.Query.ExecuteSingleQuery("select count(sub_process.equipment_name) as vacuum_count from sub_process where sub_process.sub_process_name = 'ULTRASONIC WASH'", "vacuum_count")[0]);
            int steady_count = Convert.ToInt32(Controllers.SQL.Query.ExecuteSingleQuery("select count(sub_process.equipment_name) as vacuum_count from sub_process where sub_process.sub_process_name = 'TEMPLATE STEADY STATE'", "vacuum_count")[0]);

            string ultrasonic_conditions = "", steady_conditions = "";

            for (int i = 0; i < pulses; i++)
            {
                ultrasonic_conditions = "";

                start = stop;
                stop = start + ultrasonic_time;
                for (int j = 0; j < ultrasonic_count; j++)
                {
                    ultrasonic_conditions += start + ":" + stop + (j == (ultrasonic_count - 1) ? "" : "~");
                }
                Encode_Process(ProcessName, "ULTRASONIC WASH", ultrasonic_conditions);

                start = stop;
                stop = start + steady_time;
                for (int j = 0; j < steady_count; j++)
                {
                    steady_conditions += start + ":" + stop + (j == (steady_count - 1) ? "" : "~");
                }
                Encode_Process(ProcessName, "TEMPLATE STEADY STATE", steady_conditions);
            }
        }

        private static void Encode_Process(string ProcessName, string Title, string conditions)
        {
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Parameters.AddWithValue("@process_name", ProcessName);
            mySqlCommand.Parameters.AddWithValue("@sub_process_name", Title);
            mySqlCommand.Parameters.AddWithValue("@conditions", conditions);
            mySqlCommand.Parameters.AddWithValue("@status", "1");
            Controllers.SQL.Query.ExecuteNonQuery("insert into process (process_name, sub_process_name, conditions, status) values(" +
                "@process_name, @sub_process_name, @conditions, @status);", mySqlCommand);
        }
    }
}
