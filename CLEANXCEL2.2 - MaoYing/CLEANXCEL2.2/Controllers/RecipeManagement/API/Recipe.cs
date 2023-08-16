using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Recipe
    {
        public static bool Create_SQLRecipeId(string RecipeName)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Parameters.AddWithValue("@recipe_name", RecipeName);
                mySqlCommand.Parameters.AddWithValue("@status", "1");
                Controllers.SQL.Query.ExecuteNonQuery("insert into recipe_id (name, status) values(@recipe_name, @status);", mySqlCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLRecipeId()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from recipe_id;", new string[] { "id", "name", "status" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLRecipeId_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from recipe_id where id = '" + id + "';", new string[] { "id", "name", "status" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static bool Create_SQLRecipe(string ProcessName, string ProcessTime, string Power, string Frequency)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Parameters.AddWithValue("@process_name", ProcessName);
                mySqlCommand.Parameters.AddWithValue("@process_time", ProcessTime);
                mySqlCommand.Parameters.AddWithValue("@parameters", "iOut3ProTankBtmUsAPwrPercent=" + Power + "~iOut8ProTankBtmUsAkHz=" + Frequency);
                mySqlCommand.Parameters.AddWithValue("@cycle", "1");
                mySqlCommand.Parameters.AddWithValue("@repeat_number", "1");
                Controllers.SQL.Query.ExecuteNonQuery("insert into recipe (recipe_name, process_name, process_time, parameters, cycle, repeat_number) values(" +
                    "(select max(id) from recipe_id), (select id from process_id where process_id.name = @process_name), @process_time, @parameters, @cycle, @repeat_number);", mySqlCommand);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLRecipe()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from recipe;", new string[] { "id", "recipe_name", "process_name", "process_time", "parameters", "cycle", "repeat_number" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLRecipe_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from recipe where id = '" + id + "';", new string[] { "id", "recipe_name", "process_name", "process_time", "parameters", "cycle", "repeat_number" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLRecipe_By_RecipeID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from recipe where recipe_name = '" + id + "';", new string[] { "id", "recipe_name", "process_name", "process_time", "parameters", "cycle", "repeat_number" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }
    }
}
