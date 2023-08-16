using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.SQL
{
    class Backup
    {
        private static string server = "localhost";
        private static string database = "fe01fs";
        private static string uid = "root";
        private static string password = "abcd1234";
        private static string connString = "server=" + server + ";database=" + database + ";uid=" + uid + ";password=" + password + ";SSL Mode=none;" +
                                           "charset=utf8;convertzerodatetime=true;";

        public static bool XML2Database(string filepath)
        {
            try
            {
                Model.RecipeManagement.m_RecipeModel recipeModel = Controllers.Security.Format_Conversion.XML2OBJECT<Model.RecipeManagement.m_RecipeModel>("", filepath);

                // insert into recipe_id
                foreach (Model.RecipeManagement.m_RecipeModel.Recipe_ID recipe_id in recipeModel.recipe_id_struct)
                {
                    string query = "insert into recipe_id (name, status) values (@name, @status)";
                    MySqlCommand mySqlCommand = new MySqlCommand();

                    mySqlCommand.Parameters.AddWithValue("@name", recipe_id.name);
                    mySqlCommand.Parameters.AddWithValue("@station", recipe_id.station);
                    mySqlCommand.Parameters.AddWithValue("@status", (recipe_id.status == "True")?"1":"0");

                    Controllers.SQL.Query.ExecuteNonQuery(query, mySqlCommand);
                }

                // insert into recipe
                foreach (Model.RecipeManagement.m_RecipeModel.Recipe recipe in recipeModel.recipe_struct)
                {
                    string query = "insert into recipe (recipe_name, process_name, process_time, parameters, cycle, repeat_number)" +
                                               "values (@recipe_name, @process_name, @process_time, @parameters, @cycle, @repeat_number)";
                    MySqlCommand mySqlCommand = new MySqlCommand();

                    mySqlCommand.Parameters.AddWithValue("@recipe_name", recipe.recipe_name);
                    mySqlCommand.Parameters.AddWithValue("@process_name", recipe.process_name);
                    mySqlCommand.Parameters.AddWithValue("@process_time", recipe.process_time);
                    mySqlCommand.Parameters.AddWithValue("@parameters", recipe.parameters);
                    mySqlCommand.Parameters.AddWithValue("@cycle", recipe.cycle);
                    mySqlCommand.Parameters.AddWithValue("@repeat_number", recipe.repeat_number);

                    Controllers.SQL.Query.ExecuteNonQuery(query, mySqlCommand);
                }

                // insert into process_id
                foreach (Model.RecipeManagement.m_RecipeModel.Process_ID process_id in recipeModel.process_id_struct)
                {
                    string query = "insert into process_id (name, status) values (@name, @status)";
                    MySqlCommand mySqlCommand = new MySqlCommand();

                    mySqlCommand.Parameters.AddWithValue("@name", process_id.name);
                    mySqlCommand.Parameters.AddWithValue("@station", process_id.station);
                    mySqlCommand.Parameters.AddWithValue("@status", (process_id.status == "True") ? "1" : "0");

                    Controllers.SQL.Query.ExecuteNonQuery(query, mySqlCommand);
                }

                // insert into process
                foreach (Model.RecipeManagement.m_RecipeModel.Process process in recipeModel.process_struct)
                {
                    string query = "insert into process (process_name, sub_process_name, conditions) " +
                                               "values (@process_name, @sub_process_name, @conditions)";
                    MySqlCommand mySqlCommand = new MySqlCommand();
                    
                    mySqlCommand.Parameters.AddWithValue("@process_name", process.process_name);
                    mySqlCommand.Parameters.AddWithValue("@sub_process_name", process.sub_process_name);
                    mySqlCommand.Parameters.AddWithValue("@conditions", process.conditions);

                    Controllers.SQL.Query.ExecuteNonQuery(query, mySqlCommand);
                }

                // insert into sub_process_id
                foreach (Model.RecipeManagement.m_RecipeModel.SubProcess_ID sub_process_id in recipeModel.sub_process_id_struct)
                {
                    string query = "insert into sub_process_id (name, status) values (@name, @status)";
                    MySqlCommand mySqlCommand = new MySqlCommand();

                    mySqlCommand.Parameters.AddWithValue("@name", sub_process_id.name);
                    mySqlCommand.Parameters.AddWithValue("@station", sub_process_id.station);
                    mySqlCommand.Parameters.AddWithValue("@status", (sub_process_id.status == "True") ? "1" : "0");

                    Controllers.SQL.Query.ExecuteNonQuery(query, mySqlCommand);
                }

                // insert into sub_process
                foreach (Model.RecipeManagement.m_RecipeModel.SubProcess sub_process in recipeModel.sub_process_struct)
                {
                    string query = "insert into sub_process (sub_process_name, equipment_name, equipment_state, conditions) " +
                                               "values (@sub_process_name, @equipment_name, @equipment_state, @conditions)";
                    MySqlCommand mySqlCommand = new MySqlCommand();

                    mySqlCommand.Parameters.AddWithValue("@sub_process_name", sub_process.sub_process_name);
                    mySqlCommand.Parameters.AddWithValue("@equipment_name", sub_process.equipment_name);
                    mySqlCommand.Parameters.AddWithValue("@equipment_state", sub_process.equipment_state);
                    mySqlCommand.Parameters.AddWithValue("@conditions", sub_process.conditions);

                    Controllers.SQL.Query.ExecuteNonQuery(query, mySqlCommand);
                }

                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static bool Database2XML_By_ID_List(string filepath, int[] ids)
        {
            Model.RecipeManagement.m_RecipeModel recipeModel = new Model.RecipeManagement.m_RecipeModel();

            foreach (int id in ids)
            {
                // query and structured all recipe_id data
                List<List<string>> recipe_id = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipeId_By_ID(id);
                for (int i = 0; i < recipe_id[1].Count(); i++)
                {
                    recipeModel.recipe_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.Recipe_ID()
                    { name = recipe_id[1][i], status = recipe_id[2][i] });

                    // query and structured all recipe data
                    List<List<string>> recipe = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipe_By_RecipeID(Convert.ToInt32(recipe_id[0][i]));
                    for (int j = 0; j < recipe[1].Count(); j++)
                    {
                        recipeModel.recipe_struct.Add(new Model.RecipeManagement.m_RecipeModel.Recipe()
                        { recipe_name = recipe[1][j], process_name = recipe[2][j], process_time = recipe[3][j], parameters = recipe[4][j], cycle = recipe[5][j], repeat_number = recipe[6][j] });

                        // query and structured all process_id data
                        List<List<string>> process_id = Controllers.RecipeManagement.API.Process.Get_SQLProcessId_By_ID(Convert.ToInt32(recipe[2][j]));
                        for (int k = 0; k < process_id[1].Count(); k++)
                        {
                            recipeModel.process_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.Process_ID()
                            { name = process_id[1][k], status = process_id[2][k] });

                            // query and structured all process data
                            List<List<string>> process = Controllers.RecipeManagement.API.Process.Get_SQLProcess_By_ProcessID(Convert.ToInt32(process_id[0][k]));
                            for (int l = 0; l < process[1].Count(); l++)
                            {
                                recipeModel.process_struct.Add(new Model.RecipeManagement.m_RecipeModel.Process()
                                { process_name = process[1][l], sub_process_name = process[2][l], conditions = process[3][l] });

                                // query and structured all sub_process_id data
                                List<List<string>> sub_process_id = Controllers.RecipeManagement.API.SubProcess.Get_SQLSubProcessId_By_ID(Convert.ToInt32(process[2][l]));
                                for (int m = 0; m < sub_process_id[0].Count(); m++)
                                {
                                    recipeModel.sub_process_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.SubProcess_ID()
                                    { name = sub_process_id[1][m], status = sub_process_id[2][m] });

                                    // query and structured all sub_process data
                                    List<List<string>> sub_process = Controllers.RecipeManagement.API.SubProcess.Get_SQLSubProcess_By_SubProcessID(Convert.ToInt32(sub_process_id[0][m]));
                                    for (int n = 0; n < sub_process[0].Count(); n++)
                                    {
                                        recipeModel.sub_process_struct.Add(new Model.RecipeManagement.m_RecipeModel.SubProcess()
                                        { sub_process_name = sub_process[1][n], equipment_name = sub_process[2][n], equipment_state = sub_process[3][n], conditions = sub_process[4][n] });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Controllers.Security.Format_Conversion.OBJECT2XML<Model.RecipeManagement.m_RecipeModel>(recipeModel, filepath);

            return true;
        }

        public static bool Database2XML_By_ID(string filepath, int id)
        {
            Model.RecipeManagement.m_RecipeModel recipeModel = new Model.RecipeManagement.m_RecipeModel();

            // query and structured all recipe_id data
            List<List<string>> recipe_id = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipeId_By_ID(id);
            for (int i = 0; i < recipe_id[1].Count(); i++)
            {
                recipeModel.recipe_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.Recipe_ID()
                { name = recipe_id[1][i], status = recipe_id[2][i] });
                
                // query and structured all recipe data
                List<List<string>> recipe = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipe_By_RecipeID(Convert.ToInt32(recipe_id[0][i]));
                for (int j = 0; j < recipe[1].Count(); j++)
                {
                    recipeModel.recipe_struct.Add(new Model.RecipeManagement.m_RecipeModel.Recipe()
                    { recipe_name = recipe[1][j], process_name = recipe[2][j], process_time = recipe[3][j], parameters = recipe[4][j], cycle = recipe[5][j], repeat_number = recipe[6][j] });
                    
                    // query and structured all process_id data
                    List<List<string>> process_id = Controllers.RecipeManagement.API.Process.Get_SQLProcessId_By_ID(Convert.ToInt32(recipe[2][j]));
                    for (int k = 0; k < process_id[1].Count(); k++)
                    {
                        recipeModel.process_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.Process_ID()
                        { name = process_id[1][k], status = process_id[2][k] });

                        // query and structured all process data
                        List<List<string>> process = Controllers.RecipeManagement.API.Process.Get_SQLProcess_By_ProcessID(Convert.ToInt32(process_id[0][k]));
                        for (int l = 0; l < process[1].Count(); l++)
                        {
                            recipeModel.process_struct.Add(new Model.RecipeManagement.m_RecipeModel.Process()
                            { process_name = process[1][l], sub_process_name = process[2][l], conditions = process[3][l] });

                            // query and structured all sub_process_id data
                            List<List<string>> sub_process_id = Controllers.RecipeManagement.API.SubProcess.Get_SQLSubProcessId_By_ID(Convert.ToInt32(process[2][l]));
                            for (int m = 0; m < sub_process_id[0].Count(); m++)
                            {
                                recipeModel.sub_process_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.SubProcess_ID()
                                { name = sub_process_id[1][m], status = sub_process_id[2][m] });

                                // query and structured all sub_process data
                                List<List<string>> sub_process = Controllers.RecipeManagement.API.SubProcess.Get_SQLSubProcess_By_SubProcessID(Convert.ToInt32(sub_process_id[0][m]));
                                for (int n = 0; n < sub_process[0].Count(); n++)
                                {
                                    recipeModel.sub_process_struct.Add(new Model.RecipeManagement.m_RecipeModel.SubProcess()
                                    { sub_process_name = sub_process[1][n], equipment_name = sub_process[2][n], equipment_state = sub_process[3][n], conditions = sub_process[4][n] });
                                }
                            }
                        }
                    }
                }
            }

            Controllers.Security.Format_Conversion.OBJECT2XML<Model.RecipeManagement.m_RecipeModel>(recipeModel, filepath);

            return true;
        }

        public static bool Database2XML(string filepath)
        {
            Model.RecipeManagement.m_RecipeModel recipeModel = new Model.RecipeManagement.m_RecipeModel();

            // query and structured all recipe_id data
            List<List<string>> recipe_id = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipeId();
            for(int i = 0; i< recipe_id[1].Count();i++)
            {
                recipeModel.recipe_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.Recipe_ID()
                { name = recipe_id[1][i], status = recipe_id[2][i] });
            }

            // query and structured all recipe data
            List<List<string>> recipe = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipe();
            for (int i = 0; i < recipe[1].Count(); i++)
            {
                recipeModel.recipe_struct.Add(new Model.RecipeManagement.m_RecipeModel.Recipe()
                { recipe_name = recipe[1][i], process_name = recipe[2][i], process_time = recipe[3][i], parameters = recipe[4][i], cycle = recipe[5][i], repeat_number = recipe[6][i] });
            }

            // query and structured all process_id data
            List<List<string>> process_id = Controllers.RecipeManagement.API.Process.Get_SQLProcessId();
            for (int i = 0; i < process_id[1].Count(); i++)
            {
                recipeModel.process_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.Process_ID()
                { name = process_id[1][i], status = process_id[2][i] });
            }

            // query and structured all process data
            List<List<string>> process = Controllers.RecipeManagement.API.Process.Get_SQLProcess();
            for (int i = 0; i < process[1].Count(); i++)
            {
                recipeModel.process_struct.Add(new Model.RecipeManagement.m_RecipeModel.Process()
                { process_name = process[1][i], sub_process_name = process[2][i], conditions = process[3][i] });
            }

            // query and structured all sub_process_id data
            List<List<string>> sub_process_id = Controllers.RecipeManagement.API.SubProcess.Get_SQLSubProcessId();
            for (int i = 0; i < sub_process_id[0].Count(); i++)
            {
                recipeModel.sub_process_id_struct.Add(new Model.RecipeManagement.m_RecipeModel.SubProcess_ID()
                { name = sub_process_id[1][i], status = sub_process_id[2][i] });
            }

            // query and structured all sub_process data
            List<List<string>> sub_process = Controllers.RecipeManagement.API.SubProcess.Get_SQLSubProcess();
            for (int i = 0; i < sub_process[0].Count(); i++)
            {
                recipeModel.sub_process_struct.Add(new Model.RecipeManagement.m_RecipeModel.SubProcess()
                { sub_process_name = sub_process[1][i], equipment_name = sub_process[2][i], equipment_state = sub_process[3][i], conditions = sub_process[4][i] });
            }

            Controllers.Security.Format_Conversion.OBJECT2XML<Model.RecipeManagement.m_RecipeModel>(recipeModel, filepath);

            return true;
        }

        public static bool Backup_SQL(string filepath)
        {
            string apppath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\CLEANXCEL2";
            string strpath = apppath + "\\" + filepath;

            CheckFolderExist(apppath);
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);
                MySqlCommand mySqlCommand = new MySqlCommand();
                MySqlBackup mySqlBackup = new MySqlBackup(mySqlCommand);

                mySqlCommand.Connection = mySqlConnection;
                mySqlConnection.Open();
                mySqlBackup.ExportToFile(strpath);
                mySqlConnection.Close();

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        private static bool CheckFolderExist(string folderpath)
        {
            if (!System.IO.File.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            return true;
        }

        public static bool Modify_StatusBLOBStructure()
        {
            try
            {
                string nonquery =
                    "update history_status set parameters = replace(parameters, 'Process Chamber Actual Temperature', 'Process Chamber Temperature (°C) Actual') where parameters like '%Process Chamber Actual Temperature%';" +
                    "update history_status set parameters = replace(parameters, 'Process Chamber Set Temperature', 'Process Chamber Temperature (°C) Set') where parameters like '%Process Chamber Set Temperature%';" +

                        "update history_status set parameters = replace(parameters, 'Storage Tank 1 Actual Temperature', 'Storage Tank 1 Temperature (°C) Actual') where parameters like '%Storage Tank 1 Actual Temperature%';" +
                        "update history_status set parameters = replace(parameters, 'Storage Tank 1 Set Temperature', 'Storage Tank 1 Temperature (°C) Set') where parameters like '%Storage Tank 1 Set Temperature%';" +

                        "update history_status set parameters = replace(parameters, 'Storage Tank 2 Actual Temperature', 'Storage Tank 2 Temperature (°C) Actual') where parameters like '%Storage Tank 2 Actual Temperature%';" +
                        "update history_status set parameters = replace(parameters, 'Storage Tank 2 Set Temperature', 'Storage Tank 2 Temperature (°C) Set') where parameters like '%Storage Tank 2 Set Temperature%';" +

                        "update history_status set parameters = replace(parameters, 'Distiller Tank (Top) Actual Temperature', 'Distiller Tank (Top) Temperature (°C) Actual') where parameters like '%Distiller Tank (Top) Actual Temperature%';" +
                        "update history_status set parameters = replace(parameters, 'Distiller Tank (Top) Set Temperature', 'Distiller Tank (Top) Temperature (°C) Set') where parameters like '%Distiller Tank (Top) Set Temperature%';" +

                        "update history_status set parameters = replace(parameters, 'Distiller Tank (Bottom) Actual Temperature', 'Distiller Tank (Bottom) Temperature (°C) Actual') where parameters like '%Distiller Tank (Bottom) Actual Temperature%';" +
                        "update history_status set parameters = replace(parameters, 'Distiller Tank (Bottom) Set Temperature', 'Distiller Tank (Bottom) Temperature (°C) Set') where parameters like '%Distiller Tank (Bottom) Set Temperature%';" +

                        "update history_status set parameters = replace(parameters, 'Vacuum Pump Actual Pressure', 'Vacuum Pump Pressure (kPa) Actual') where parameters like '%Vacuum Pump Actual Pressure%';" +

                        "update history_status set parameters = replace(parameters, 'Ultrasonic Actual Power Percentage', 'Ultrasonic Power Percentage (%) Actual') where parameters like '%Ultrasonic Actual Power Percentage%';" +
                        "update history_status set parameters = replace(parameters, 'Ultrasonic Set Power Percentage', 'Ultrasonic Power Percentage (%) Set') where parameters like '%Ultrasonic Set Power Percentage%';" +

                        "update history_status set parameters = replace(parameters, 'Ultrasonic Actual Frequency', 'Ultrasonic Frequency (kHz) Actual') where parameters like '%Ultrasonic Actual Frequency%';" +
                        "update history_status set parameters = replace(parameters, 'Ultrasonic Set Frequency', 'Ultrasonic Frequency (kHz) Set') where parameters like '%Ultrasonic Set Frequency%'";

                Controllers.SQL.Query.ExecuteNonQuery(nonquery, new MySqlCommand());

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}
