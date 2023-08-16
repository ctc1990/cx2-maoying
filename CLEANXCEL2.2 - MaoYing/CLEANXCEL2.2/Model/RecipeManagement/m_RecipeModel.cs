using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Model.RecipeManagement
{
    public class m_RecipeModel
    {
        public List<Recipe_ID> recipe_id_struct = new List<Recipe_ID>();
        public List<Recipe> recipe_struct = new List<Recipe>();
        public List<Process_ID> process_id_struct = new List<Process_ID>();
        public List<Process> process_struct = new List<Process>();
        public List<SubProcess_ID> sub_process_id_struct = new List<SubProcess_ID>();
        public List<SubProcess> sub_process_struct = new List<SubProcess>();

        public struct Recipe_ID
        {
            public string name;
            public string station;
            public string status;
        }

        public struct Recipe
        {
            public string recipe_name;
            public string process_name;
            public string process_time;
            public string parameters;
            public string cycle;
            public string repeat_number;
        }

        public struct Process_ID
        {
            public string name;
            public string station;
            public string status;
        }

        public struct Process
        {
            public string process_name;
            public string sub_process_name;
            public string conditions;
        }

        public struct SubProcess_ID
        {
            public string name;
            public string station;
            public string status;
        }

        public struct SubProcess
        {
            public string sub_process_name;
            public string equipment_name;
            public string equipment_state;
            public string conditions;
        }
    }
}
