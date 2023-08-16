using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.EventNotifier
{
    class SubProcess_Notification
    {
        public event Action ActionIntervalStop;
        private static AdsStream adsDataStream;
        private static BinaryReader binRead;
        private TcAdsClient tcAdsClient = new TcAdsClient();
        private static int[] hconnect = new int[1];

        public void SubProcessChangeGenerateNotif(TcAdsClient adsClient, string caseno)
        {
            Debug.WriteLine("Controllers.EventNotifier.SubProcess_Notification.SubProcessChangeGenerateNotif()");
            tcAdsClient = adsClient;
            adsDataStream = new AdsStream(4);
            binRead = new BinaryReader(adsDataStream, Encoding.ASCII);

            try
            {
                hconnect[0] = adsClient.AddDeviceNotification(caseno, adsDataStream, 0, 4, AdsTransMode.OnChange, 100, 0, null);

                adsClient.AdsNotification += new AdsNotificationEventHandler(SubProcessOnChange);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message.ToString());
            }
        }

        private void SubProcessOnChange(object sender, AdsNotificationEventArgs e)
        {
            Debug.WriteLine("Controllers.EventNotifier.SubProcess_Notification.SubProcessOnChange()");
            try
            {
                if (e.NotificationHandle == hconnect[0])
                {
                    if (Globals.InitiatingRecipe)
                    {
                        Controllers.RecipeManagement.API.Recipe_History.POST_History_Status_Started(tcAdsClient);
                        Globals.InitiatingRecipe = false;
                    }
                    else
                    {
                        int value = binRead.ReadInt16();
                        if (Globals.LoggingHistoryStatusDefault)
                        {
                            Debug.WriteLine("Process Case No: " + value);

                            switch (value)
                            {
                                case 1:
                                    Debug.WriteLine("Completion Time : " + Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(tcAdsClient, ".ARDsStnSeqProcessCtrl[1].Out_iComConProcessTimeEV"));
                                    break;
                                // Waiting for Start Condition being met
                                case 2:
                                    break;
                                // Waiting for Stop Condition being met
                                case 3:
                                    Controllers.RecipeManagement.API.Recipe_History.POST_History_Status(tcAdsClient);
                                    Debug.WriteLine("Start Time : " + Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(tcAdsClient, ".ARDsStnSeqProcessCtrl[1].Out_iComConProcessTimeEV"));
                                    break;
                                case 99:
                                    Controllers.RecipeManagement.API.Recipe_History.POST_History_Status_Ended(tcAdsClient);

                                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(tcAdsClient, ".bAutoStartPB", "false", "bool");
                                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(tcAdsClient, ".bBasketCfmEn", "false", "bool");
                                    break;
                            }
                        }
                        else if (value == 99)
                        {
                            ActionIntervalStop();
                        }
                    }
                }
            }
            catch
            {
                //err.Message.ToString();
            }
        }
    }
}
