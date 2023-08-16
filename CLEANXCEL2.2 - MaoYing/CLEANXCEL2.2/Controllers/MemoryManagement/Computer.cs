using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CLEANXCEL2._2.Controllers.MemoryManagement
{
    class Computer
    {
        public static long GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    string partition = ConvertUnit(drive.AvailableFreeSpace);
                    string total = ConvertUnit(drive.TotalSize);
                    MessageBox.Show("Disk Free Size: " + partition + "\nDisk Total Size: " + total);
                    return drive.TotalFreeSpace;
                }
            }
            return -1;
        }

        public static string GetTotalSize(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return ConvertUnit(drive.TotalSize);
                }
            }
            return "";
        }

        public static string GetTotalFreeSpacePercentage(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return ((drive.AvailableFreeSpace / drive.TotalSize) * 100).ToString();
                }
            }
            return "";
        }

        private static string ConvertUnit(long value)
        {
            if (value >= 1000.00)
            {
                if (value >= 1000000.00)
                {
                    if (value >= 1000000000.00)
                    {
                        return (String.Format("{0:0.00}", (value / 1000000000.00)).ToString() + "GB");
                    }
                    else
                    {
                        return (String.Format("{0:0.00}", (value / 1000000.00)).ToString() + "MB");
                    }
                }
                else
                {
                    return (String.Format("{0:0.00}", (value / 1000.00)).ToString() + "kB");
                }
            }
            else
                return value.ToString();
        }

        public static string GetDatabaseSize(string databaseName)
        {
            string query = "select table_schema, round(sum(data_length + index_length) / 1024, 1) \"sizekB\" from information_schema.tables where table_schema = '" + databaseName + "'";

            return Controllers.SQL.Query.ExecuteSingleQuery(query, "sizekB")[0];
        }

        public static void GetOSVersion()
        {
            Debug.WriteLine(Environment.OSVersion.VersionString);
        }
    }
}
