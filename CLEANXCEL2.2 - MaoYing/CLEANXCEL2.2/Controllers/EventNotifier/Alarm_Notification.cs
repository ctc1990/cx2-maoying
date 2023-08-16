using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CLEANXCEL2._2.Controllers.EventNotifier
{
    class Alarm_Notification
    {
        //private static readonly int range = 350;
        private int[] index;
        MySqlCommand mySqlCommand = new MySqlCommand();
        public event Action ActionChange;
        private static AdsStream adsDataStream;
        private TcAdsClient tcAdsClient = new TcAdsClient();
        private static BinaryReader binRead;
        private static int[] hconnect;

        public void AlarmGenerateNotif(TcAdsClient adsClient, string variableName)
        {
            Debug.WriteLine("Controllers.EventNotifier.Alarm_Notification.AlarmGenerateNotif()");
            index = Index();
            int start_ind = 0;
            int size = 1;
            tcAdsClient = adsClient;
            hconnect = new int[index.Count()];
            adsDataStream = new AdsStream(index.Count());
            binRead = new BinaryReader(adsDataStream, Encoding.ASCII);

            try
            {
                for (int i = 1; i < index.Count(); i++)
                {
                    hconnect[i - 1] = adsClient.AddDeviceNotification(variableName + "[" + index[i] + "]", adsDataStream, start_ind, size, AdsTransMode.OnChange, 100, 0, null);
                    start_ind += size;
                    Debug.WriteLine(variableName + "[" + i + "] : " + hconnect[i - 1]);
                }

                adsClient.AdsNotification += new AdsNotificationEventHandler(AlarmOnchange);
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        private void AlarmOnchange(object sender, AdsNotificationEventArgs e)
        {
            Debug.WriteLine("Controllers.EventNotifier.Alarm_Notification.AlarmOnchange()");
            Debug.WriteLine(e.NotificationHandle);
            string dateTime;
            string[] alarm;
            try
            {
                bool status = binRead.ReadBoolean();
                for (int i = 1; i < index.Count(); i++)
                {
                    if (e.NotificationHandle == hconnect[i - 1])
                    {
                        mySqlCommand = new MySqlCommand();
                        dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        alarm = (ADS.ADS_ReadWrite.ADS_ReadValue(tcAdsClient, ".ARsAlarmDescription[" + index[i] + "]").Trim()).Split(new char[] { '-' }, 2);
                        if (status)
                        {
                            mySqlCommand.Parameters.AddWithValue("@code", alarm[0]);
                            mySqlCommand.Parameters.AddWithValue("@io_code", alarm[1]);
                            mySqlCommand.Parameters.AddWithValue("@activated_time", dateTime);
                            SQL.Query.ExecuteNonQuery("insert into alarm_history (code, io_code, activated_time, recover_time, status) values (" +
                                                      "@code, @io_code, @activated_time, '', '1')", mySqlCommand);
                        }
                        else
                        {
                            SQL.Query.ExecuteNonQuery("update alarm_history set status = '0', recover_time = '" + dateTime + "' where (alarm_history.code = '" + alarm[0] + "' and alarm_history.io_code = '" + alarm[1] + "' and alarm_history.status = '1')", mySqlCommand);
                        }

                        ActionChange();
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        private static int[] Index()
        {
            Debug.WriteLine("Controllers.EventNotifier.Alarm_Notification.Index()");
            return Controllers.SQL.Query.ExecuteSingleQuery("select active_index from alarm_index", "active_index").Select(x => Convert.ToInt32(x)).ToArray();
        }
    }
}
