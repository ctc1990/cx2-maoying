using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Part
    {
        public static bool Create_SQLPartId(string PartName)
        {
            try
            {

                MySqlCommand mySqlCommand = new MySqlCommand();

                mySqlCommand.Parameters.AddWithValue("@part_name", PartName);

                if (!Controllers.SQL.Query.ExecuteCheckQuery("select * from part_id where part_id.part_name=@part_name", mySqlCommand))
                {
                    Controllers.SQL.Query.ExecuteNonQuery("insert into part_id (part_name) values (@part_name)", mySqlCommand);

                    return true;
                }
                else // Stay on the page
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLPartId()
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from part_id;", new string[] { "id", "part_name" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static List<List<string>> Get_SQLPartId_By_ID(int id)
        {
            try
            {
                return Controllers.SQL.Query.ExecuteMultiQuery("select * from part_id where id = '" + id + "';", new string[] { "id", "part_name" });
            }
            catch
            {
                return new List<List<string>>();
            }
        }

        public static bool Create_SQLPart(string Description, string RecipeID, string BatchNo)
        {
            try
            {

                MySqlCommand mySqlCommand = new MySqlCommand();
                
                mySqlCommand.Parameters.AddWithValue("@description", Description);
                mySqlCommand.Parameters.AddWithValue("@recipe_id", RecipeID);
                mySqlCommand.Parameters.AddWithValue("@batch_no", BatchNo);
                Controllers.SQL.Query.ExecuteNonQuery("insert into part (fk_part_id, description, recipe_id, batch_no) " +
                                                    "values ((select max(part_id.id) from part_id), @description, @recipe_id, @batch_no)", mySqlCommand);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> Get_SQLPart()
        {
            List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery("select part_info.fk_part_id, part_info.part_name, part_info.description, part_info.recipe_id, recipe_id.name, part_info.batch_no from " +
                        "(select part.fk_part_id, part_id.part_name, part.description, part.recipe_id, part.batch_no from part right join part_id on part.fk_part_id = part_id.id) " +
                        "as part_info left join recipe_id on part_info.recipe_id = recipe_id.id",
                        new string[] { "fk_part_id", "part_name", "description", "recipe_id", "name", "batch_no" });

            return list;
        }
    }
}
