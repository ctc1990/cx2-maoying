using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Standard_Machine_Command
    {
        public static bool SaveRecipe(TcAdsClient adsClient, bool condition)
        {
            try
            {
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeSavePb", condition.ToString(), "bool");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EmptyRecipe(TcAdsClient adsClient)
        {
            try
            {
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeEmptyPB", "true", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeEmptyPB", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[1].iSubRecipeNo", "2", "int");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[1].iSubRecipeNo", "1", "int");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool StartRecipeNumber(TcAdsClient adsClient, int i)
        {
            try
            {
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bBasketCfmEn", "true", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".DSStnBasketInfo[1].iStationSeqenceRecipeNo", i.ToString(), "int");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool StopProcess(TcAdsClient adsClient)
        {
            try
            {
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bBasketCfmEn", "false", "bool");

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
