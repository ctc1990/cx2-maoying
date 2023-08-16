using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TwinCAT.Ads;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Recipe_Machine_Com
    {
        private static readonly string DSProcess = ".AR10DSStationSSERStore[1].DsStationSequenceRecipeMemory.";
        private static readonly string DSSubProcess = ".AR10DSStationSSURStore[1].DsSubRecipeMemory.";

        public static void UploadRecipe(TcAdsClient adsClient, string recipe_name, int totaltime)
        {
            List<ProcessFlow> list = UploadSSUR(adsClient, recipe_name);
            UploadSSER(adsClient, recipe_name, totaltime, list);
        }

        private static List<ProcessFlow> UploadSSUR(TcAdsClient adsClient, string recipe_name)
        {
            int k = 0;
            int count = 1;
            int temp_start;
            List<ProcessFlow> process_Run = new List<ProcessFlow>();
            List<Controllers.RecipeManagement.API.Process_Extraction.SubProcess> subProcessList = new List<Controllers.RecipeManagement.API.Process_Extraction.SubProcess>();

            List<List<string>> process = Controllers.SQL.Query.ExecuteMultiQuery(
                "select recipe_id.name, recipe.process_name, recipe.parameters from recipe right join recipe_id on " +
                "recipe_id.id = recipe.recipe_name where recipe_id.id = '" + recipe_name + "' and recipe_id.status = '1'",
                new string[] { "name", "process_name", "parameters" });

            // Set of SSUR

            for (int a = 0; a < process[1].Count(); a++)
            {
                string[] parameters = process[2][a].Split(new char[] { '=', '~' });

                // Time Cutting
                subProcessList = new List<Controllers.RecipeManagement.API.Process_Extraction.SubProcess>();

                List<List<string>> subprocess = Controllers.SQL.Query.ExecuteMultiQuery(
                    "select process.id, process_id.name from process right join process_id on process_id.id = process.process_name where process_id.id = '" + process[1][a] + "' and process_id.status = '1'", new string[] { "id", "name" });

                for (int i = 0; i < subprocess[0].Count(); i++)
                {
                    k = 0;
                    string[] conditions = Controllers.SQL.Query.ExecuteSingleQuery("select process.conditions from process where process.id = '" + subprocess[0][i] + "'", "conditions").First().Split('~');
                    List<List<string>> equipment = Controllers.SQL.Query.ExecuteMultiQuery(
                        "select sub_process.id, sub_process.equipment_state, sub_process_id.name from sub_process " +
                        "right join sub_process_id on sub_process_id.id = sub_process.sub_process_name where sub_process_id.id = " +
                        "(select process.sub_process_name from process where process.id = '" + subprocess[0][i] + "') and sub_process_id.status = '1'",
                        new string[] { "id", "equipment_state", "name" });

                    for (int j = 0; j < equipment[0].Count(); j++)
                    {
                        string[] time = conditions[k].Split(':');
                        if (j < equipment[0].Count() - 1)
                        {
                            if (equipment[1][j] != equipment[1][j + 1])
                                k++;
                        }
                        int StartTime = Convert.ToInt32(time[0]);
                        int StopTime = Convert.ToInt32(time[1]);
                        subProcessList.Add(Controllers.RecipeManagement.API.Process_Extraction.ExecuteProcessExtraction(equipment[0][j], StartTime, StopTime, subprocess[1][i] + "\n" + equipment[2][j]));
                    }
                }
                List<List<string>> timeExtract = Controllers.RecipeManagement.API.Time_Management.ExecuteTimeCutter(subProcessList);

                // Writing SSUR
                temp_start = count;
                for (int i = 0; i < timeExtract[0].Count; i++)
                {
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[1].iSubRecipeNo", (count++).ToString(), "int");
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[1].sSubRecipeDescription", timeExtract[1][i], "string");
                    string[] equipment = timeExtract[0][i].Split('~', '=');
                    for (int j = 0; j < equipment.Count(); j += 2)
                    {
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSSubProcess + equipment[j], equipment[j + 1], datatype(equipment[j]));
                    }
                    for (int j = 0; j < parameters.Count(); j += 2)
                    {
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSSubProcess + parameters[j], parameters[j + 1], datatype(parameters[0]));
                    }
                    Controllers.RecipeManagement.API.Standard_Machine_Command.SaveRecipe(adsClient, true);
                    Controllers.RecipeManagement.API.Standard_Machine_Command.SaveRecipe(adsClient, false);
                }
                //hashtable.Add(process[0][a], new ProcessFlow() { start = temp_start, stop = count - 1 }); //temporary unuse
                process_Run.Add(new ProcessFlow() { start = temp_start, stop = count - 1 });
            }

            return process_Run;
        }

        private static void UploadSSER(TcAdsClient adsClient, string recipe_name, int totaltime, List<ProcessFlow> process_Run)
        {
            int k = 0;
            // Set of SSER
            List<List<string>> recipe = Controllers.SQL.Query.ExecuteMultiQuery(
                "select recipe.cycle, recipe.repeat_number from recipe " +
                "right join recipe_id on recipe_id.id = recipe.recipe_name where recipe_id.id = '" + recipe_name + "' and recipe_id.status = '1'",
                new string[] { "cycle", "repeat_number" });
            List<int> process_start = new List<int>();
            k = 1;

            // Writing SSER
            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSERStore[1].iStationSequenceRecipeNo", "1", "int");
            for (int i = 0; i < recipe[0].Count(); i++)
            {
                ProcessFlow processFlow = process_Run[i];
                //ProcessFlow processFlow = (ProcessFlow)hashtable[recipe[0][i]];
                process_start.Add(k);
                for (int j = processFlow.start; j <= processFlow.stop; j++)
                {
                    if (j == processFlow.stop)
                    {
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "AR10iCycle[" + k + "]", recipe[0][i].ToString(), "int");
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "AR10iRepeatFromStepNo[" + k + "]"
                            , process_start[Convert.ToInt32(recipe[1][i]) - 1].ToString(), "int");
                    }
                    else
                    {
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "AR10iCycle[" + k + "]", "1", "int");
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "AR10iRepeatFromStepNo[" + k + "]", "1", "int");
                    }
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "AR10iStationSubProNo[" + (k++) + "]", j.ToString(), "int");
                    Controllers.RecipeManagement.API.Standard_Machine_Command.SaveRecipe(adsClient, true);
                    Controllers.RecipeManagement.API.Standard_Machine_Command.SaveRecipe(adsClient, false);
                }
            }
            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "iProcessMinTime", totaltime.ToString(), "int");
            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "iProcessMaxTime", totaltime.ToString(), "int");
            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, DSProcess + "iProcessCalculatedTime", totaltime.ToString(), "int");
        }

        private static string datatype(string variable_name)
        {
            switch (variable_name.Substring(0, 1))
            {
                case "b":
                    return "bool";
                case "i":
                    return "int";
                case "r":
                    return "real";
                case "s":
                    return "string";
                default:
                    return "";
            }
        }

        private struct ProcessFlow
        {
            public int start;
            public int stop;
        }
    }
}
