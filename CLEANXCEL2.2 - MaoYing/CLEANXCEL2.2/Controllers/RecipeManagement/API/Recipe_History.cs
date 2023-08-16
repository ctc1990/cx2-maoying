using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Recipe_History
    {
        public static bool POST_History_Recipe()
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();

                mySqlCommand.Parameters.AddWithValue("@recipe_name", Globals.currentRecipe);
                mySqlCommand.Parameters.AddWithValue("@part_name", Globals.currentPart);
                Controllers.SQL.Query.ExecuteNonQuery("insert into history_recipe (recipe_name, part_name) values(" +
                        "@recipe_name, @part_name)", mySqlCommand);
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static bool POST_History_Status_Started(TcAdsClient tcAdsClient)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();

                string subdescription = Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(tcAdsClient, ".DSHmiStationDisplayInfo[1].sStationSubDescription");
                string[] description = new string[2];
                try { description = subdescription.Split('\n'); }
                catch { description = new string[] { subdescription, subdescription }; }
                //mySqlCommand.Parameters.AddWithValue("@recipe_name", Globals.currentRecipe);
                mySqlCommand.Parameters.AddWithValue("@process_name", description[0]);
                mySqlCommand.Parameters.AddWithValue("@sub_process_name", description[1]);
                mySqlCommand.Parameters.AddWithValue("@start_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                mySqlCommand.Parameters.AddWithValue("@end_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Controllers.SQL.Query.ExecuteNonQuery("insert into history_status (recipe_name, process_name, sub_process_name, parameters, start_time, end_time, percent) values(" +
                        "(select max(id) from history_recipe), @process_name, @sub_process_name, '" +
                        Controllers.RecipeManagement.API.Status_Extraction.ExecuteStatusExtraction(tcAdsClient) + "', @start_time, @end_time, '0');", mySqlCommand);

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static bool POST_History_Status(TcAdsClient tcAdsClient)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();

                string subdescription = Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(tcAdsClient, ".DSHmiStationDisplayInfo[1].sStationSubDescription");
                string[] description = new string[2];
                if (subdescription.Contains('\n')) { description = subdescription.Split('\n'); }
                else { description = new string[] { subdescription, subdescription }; }
                //mySqlCommand.Parameters.AddWithValue("@recipe_name", Globals.currentRecipe);
                mySqlCommand.Parameters.AddWithValue("@process_name", description[0]);
                mySqlCommand.Parameters.AddWithValue("@sub_process_name", description[1]);
                mySqlCommand.Parameters.AddWithValue("@start_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                mySqlCommand.Parameters.AddWithValue("@end_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                mySqlCommand.Parameters.AddWithValue("@percent", "100");
                Controllers.SQL.Query.ExecuteNonQuery("update history_status set history_status.end_time = @end_time, history_status.percent = @percent order by history_status.id desc limit 1", mySqlCommand);
                Controllers.SQL.Query.ExecuteNonQuery("insert into history_status (recipe_name, process_name, sub_process_name, parameters, start_time, end_time, percent) values(" +
                        "(select max(id) from history_recipe), @process_name, @sub_process_name, '" +
                        Controllers.RecipeManagement.API.Status_Extraction.ExecuteStatusExtraction(tcAdsClient) + "', @start_time, @end_time, '0');", mySqlCommand);

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static bool POST_History_Status_Ended(TcAdsClient tcAdsClient)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();

                mySqlCommand.Parameters.AddWithValue("@end_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                mySqlCommand.Parameters.AddWithValue("@percent", "100");
                Controllers.SQL.Query.ExecuteNonQuery("update history_status set history_status.end_time = @end_time, history_status.percent = @percent order by history_status.id desc limit 1", mySqlCommand);

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static List<List<string>> GET_History_Recipe()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from history_recipe", new string[] { "recipe_name", "part_name" }); ;
            }
            catch (MySqlException)
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> GET_History_Status_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery(
                "select history_recipe.recipe_name, history_status.process_name, history_status.sub_process_name, history_status.parameters, " +
                "time_to_sec(timediff(history_status.end_time, history_status.start_time)) as duration from history_recipe right join history_status " +
                "on history_recipe.id = history_status.recipe_name where history_recipe.id = '" + id + "'",
                new string[] { "recipe_name", "process_name", "sub_process_name", "parameters", "duration" });
            }
            catch (MySqlException)
            {
                return new List<List<string>>();
            }
        }
    }
}
