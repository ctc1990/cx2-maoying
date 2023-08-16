using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Time_Management
    {
        public static List<List<string>> ExecuteTimeCutter(List<Controllers.RecipeManagement.API.Process_Extraction.SubProcess> subProcessList)
        {
            List<int> ListParseTime = new List<int>();
            List<string> ListTimeCutter = new List<string>();
            List<string> ListDescription = new List<string>();

            for (int i = 0; i < subProcessList.Count; i++)
            {
                int starttime = Convert.ToInt32(subProcessList[i].StartTime);
                int stoptime = Convert.ToInt32(subProcessList[i].StopTime);
                if (starttime == stoptime)
                {
                    for (int j = ListParseTime.Select(x => x == starttime).Count(); j < 2; j++)
                    {
                        ListParseTime.Add(starttime);
                        ListDescription.Add("");
                    }
                }
                else
                {
                    if (!ListParseTime.Contains(starttime))
                    {
                        ListParseTime.Add(starttime);
                        ListDescription.Add("");
                    }
                    if (!ListParseTime.Contains(stoptime))
                    {
                        ListParseTime.Add(stoptime);
                        ListDescription.Add("");
                    }
                }
            }
            ListParseTime.Sort();

            for (int i = 0; i < ListParseTime.Count - 1; i++)
            {
                int timelapsed = ListParseTime[i + 1] - ListParseTime[i];
                if (timelapsed == 0)
                    ListTimeCutter.Add("bComCon20EnProcessTimer=false~iComCon5ProcessTimer=" + timelapsed.ToString());
                else
                    ListTimeCutter.Add("bComCon20EnProcessTimer=true~iComCon5ProcessTimer=" + timelapsed.ToString());
            }

            for (int i = 0; i < ListParseTime.Count - 1; i++)
            {
                for (int j = 0; j < subProcessList.Count; j++)
                {
                    if (subProcessList[j].StartTime <= ListParseTime[i] && subProcessList[j].StopTime >= ListParseTime[i + 1])
                    {
                        ListTimeCutter[i] += "~" + subProcessList[j].Equipment;
                        ListDescription[i] = IncludeDescription(subProcessList[j].Description, ListDescription[i]);
                    }
                    if (subProcessList[j].StartTime == ListParseTime[i])
                        ListTimeCutter[i] += (subProcessList[j].StartConditions == null ? "" : "~") + subProcessList[j].StartConditions;
                    if (subProcessList[j].StopTime == ListParseTime[i + 1])
                        ListTimeCutter[i] += (subProcessList[j].StopConditions == null ? "" : "~") + subProcessList[j].StopConditions;
                }
            }

            return new List<List<string>>() { ListTimeCutter, ListDescription };
        }

        private static string IncludeDescription(string Source, string Destination)
        {
            if (Destination.Trim().Contains(Source.Trim()))
                return Destination;
            else
            {
                if (Destination == "")
                    return Destination += Source;
                else
                    return Destination += " & " + Source;
            }
        }
    }
}
