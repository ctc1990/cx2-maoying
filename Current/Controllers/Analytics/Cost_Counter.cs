using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.Analytics
{
    class Cost_Counter
    {
        public static double Calculate_Power_Comsumption_for_Recipe(int id)
        {
            List<List<string>> parameters = 
                Controllers.SQL.Query.ExecuteMultiQuery(
                "select history_status.parameters, time_to_sec(timediff(history_status.end_time, history_status.start_time)) as duration " +
                "from history_recipe " +
                "inner join history_status on history_status.recipe_name = history_recipe.id " +
                "where history_recipe.id = '" + id + "'", new string[] { "parameters", "duration" });

            List<List<string>> power_table = Get_Power_Table();

            double sec_for_hour = 3600;
            double[] duration = parameters[1].Select(x => Convert.ToDouble(x)).ToArray();
            double[] kW = power_table[1].Select(x => Convert.ToDouble(x)).ToArray();
            double[] kWh = new double[power_table[0].Count()];

            for (int i = 0; i < parameters[0].Count(); i++)
            {
                for (int j = 0; j < power_table[0].Count(); j++)
                {
                    if (parameters[0][i].Contains("~" + power_table[0][j] + ":True~"))
                    {
                        kWh[j] += duration[i] * kW[j];
                    }
                }
            }

            return kWh.Sum() / sec_for_hour;
        }

        private static List<List<string>> Get_Power_Table()
        {
            return Controllers.SQL.Query.ExecuteMultiQuery("select * from power_table", new string[] { "label", "power_W" });
        }
    }
}
