using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.Unused
{
    class RecipeWriter
    {
        //public static bool Process_Write(TcAdsClient adsClient, int i_StationNo, Controllers.RecipeManagement.DS_Recipe.Process DS_Process)
        //{
        //    try
        //    {
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeSavePb", "false", "bool");
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSERStore[" + i_StationNo + "].iStationSequenceRecipeNo", (DS_Process.i_StationSequenceRecipeNo).ToString(), "int");
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSERStore[" + i_StationNo + "].sStationSequenceRecipeDescription", DS_Process.s_StationSequenceRecipeDescription, "string");
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeSavePb", "true", "bool");
        //        Process_StationSubProNo_Write(adsClient, i_StationNo, DS_Process.AR10i_StationSubProNo);
        //        Process_Cycle_Write(adsClient, i_StationNo, DS_Process.AR10i_Cycle);
        //        Process_RepeatFromStepNo_Write(adsClient, i_StationNo, DS_Process.AR10i_RepeatFromStepNo);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private static void Process_StationSubProNo_Write(TcAdsClient adsClient, int i_StationNo, int[] AR10i_StationSubProNo)
        //{
        //    int index = 0;

        //    foreach (int i_StationSubProNo in AR10i_StationSubProNo)
        //    {
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSERStore[" + i_StationNo + "].DsStationSequenceRecipeMemory.AR10iStationSubProNo[" + index++ + "]",
        //           i_StationSubProNo.ToString(), "int");
        //    }

        //}

        //private static void Process_Cycle_Write(TcAdsClient adsClient, int i_StationNo, int[] AR10i_Cycle)
        //{
        //    int index = 0;
            
        //    foreach (int i_Cycle in AR10i_Cycle)
        //    {
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSERStore[" + i_StationNo + "].DsStationSequenceRecipeMemory.AR10iCycle[" + index++ + "]",
        //           i_Cycle.ToString(), "int");
        //    }
        //}

        //private static void Process_RepeatFromStepNo_Write(TcAdsClient adsClient, int i_StationNo, int[] AR10i_RepeatFromStepNo)
        //{
        //    int index = 0;
            
        //    foreach (int i_RepeatFromStepNo in AR10i_RepeatFromStepNo)
        //    {
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSERStore[" + i_StationNo + "].DsStationSequenceRecipeMemory.AR10iRepeatFromStepNo[" + index++ + "]",
        //           i_RepeatFromStepNo.ToString(), "int");
        //    }
        //}

        //public static bool SubProcess_Write(TcAdsClient adsClient, int i_StationNo, Controllers.RecipeManagement.DS_Recipe.SubProcess DS_SubProcess)
        //{
        //    try
        //    {
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeSavePb", "false", "bool");
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].iSubRecipeNo", (DS_SubProcess.i_SubRecipeNo).ToString(), "int");
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].sSubRecipeDescription", DS_SubProcess.s_SubRecipeDescription, "string");
        //        SubProcess_StartCondition_Write(adsClient, i_StationNo, DS_SubProcess.DS_StartCondition);
        //        SubProcess_CompleteCondition_Write(adsClient, i_StationNo, DS_SubProcess.DS_CompleteCondition);
        //        SubProcess_InstrumentOutput_Write(adsClient, i_StationNo, DS_SubProcess.DS_InstrumentOutput);
        //        SubProcess_ValueSetting_Write(adsClient, i_StationNo, DS_SubProcess.DS_ValueSetting);
        //        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bRecipeSavePb", "true", "bool");

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private static void SubProcess_StartCondition_Write(TcAdsClient adsClient, int i_StationNo, Controllers.RecipeManagement.DS_Recipe.SubProcess_StartCondition DS_SubProcess_StartCondition)
        //{
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon1EnProLowLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon1EnProLowLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon1EnProLowLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon1EnProLowLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon2EnProRegLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon2EnProRegLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon3EnProHighLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon3EnProHighLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon4EnSubLowLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon4EnSubLowLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon5EnSubRegLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon5EnSubRegLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon6EnSubHighLiquidLevel",
        //        DS_SubProcess_StartCondition.b_StCon6EnSubHighLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon7EnLowVacuumLevel",
        //        DS_SubProcess_StartCondition.b_StCon7EnLowVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon8EnRegVacuumLevel",
        //        DS_SubProcess_StartCondition.b_StCon8EnRegVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon9EnLowPressureLevel",
        //        DS_SubProcess_StartCondition.b_StCon9EnLowPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon10EnRegPressureLevel",
        //        DS_SubProcess_StartCondition.b_StCon10EnRegPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon11EnBelowTargetVacuumLevel",
        //        DS_SubProcess_StartCondition.b_StCon11EnBelowTargetVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon12EnAboveTargetVacuumLevel",
        //        DS_SubProcess_StartCondition.b_StCon12EnAboveTargetVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon13EnBelowTargetPressureLevel",
        //        DS_SubProcess_StartCondition.b_StCon13EnBelowTargetPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon14EnAboveTargetPressureLevel",
        //        DS_SubProcess_StartCondition.b_StCon14EnAboveTargetPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon15EnBelowTargetProTankTempLevel",
        //        DS_SubProcess_StartCondition.b_StCon15EnBelowTargetProTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon16EnAboveTargetProTankTempLevel",
        //        DS_SubProcess_StartCondition.b_StCon16EnAboveTargetProTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon17EnBelowTargetSubTankTempLevel",
        //        DS_SubProcess_StartCondition.b_StCon17EnBelowTargetSubTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon18EnAboveTargetSubTankTempLevel",
        //        DS_SubProcess_StartCondition.b_StCon18EnAboveTargetSubTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bStCon19ExternalActivation",
        //        "false", "bool");

        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iStCon1TargetVacuumLevel",
        //        DS_SubProcess_StartCondition.i_StCon1TargetVacuumLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iStCon2TargetPressureLevel",
        //        DS_SubProcess_StartCondition.i_StCon2TargetPressureLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iStCon3TargetProTankTempLevel",
        //        DS_SubProcess_StartCondition.i_StCon3TargetProTankTempLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iStCon4TargetSubTankTempLevel",
        //        DS_SubProcess_StartCondition.i_StCon4TargetSubTankTempLevel.ToString(), "int");
        //}

        //private static void SubProcess_CompleteCondition_Write(TcAdsClient adsClient, int i_StationNo, Controllers.RecipeManagement.DS_Recipe.SubProcess_CompleteCondition DS_SubProcess_CompleteCondition)
        //{
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon1EnProLowLiquidLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon1EnProLowLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon2EnProRegLiquidLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon2EnProRegLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon3EnProHighLiquidLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon3EnProHighLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon4EnSubLowLiquidLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon4EnSubLowLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon5EnSubRegLiquidLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon5EnSubRegLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon6EnSubHighLiquidLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon6EnSubHighLiquidLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon7EnLowVacuumLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon7EnLowVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon8EnRegVacuumLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon8EnRegVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon9EnLowPressureLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon9EnLowPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon10EnRegPressureLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon10EnRegPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon11EnBelowTargetVacuumLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon11EnBelowTargetVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon12EnAboveTargetVacuumLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon12EnAboveTargetVacuumLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon13EnBelowTargetPressureLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon13EnBelowTargetPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon14EnAboveTargetPressureLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon14EnAboveTargetPressureLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon15EnBelowTargetProTankTempLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon15EnBelowTargetProTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon16EnAboveTargetProTankTempLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon16EnAboveTargetProTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon17EnBelowTargetSubTankTempLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon17EnBelowTargetSubTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon18EnAboveTargetSubTankTempLevel",
        //        DS_SubProcess_CompleteCondition.b_ComCon18EnAboveTargetSubTankTempLevel.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon19EnExternalActivation",
        //        "false", "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bComCon20EnProcessTimer",
        //        DS_SubProcess_CompleteCondition.b_ComCon20EnProcessTimer.ToString(), "bool");

        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iComCon1TargetVacuumLevel",
        //        DS_SubProcess_CompleteCondition.i_ComCon1TargetVacuumLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iComCon2TargetPressureLevel",
        //        DS_SubProcess_CompleteCondition.i_ComCon2TargetPressureLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iComCon3TargetProTankTempLevel",
        //        DS_SubProcess_CompleteCondition.i_ComCon3TargetProTankTempLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iComCon4TargetSubTankTempLevel",
        //        DS_SubProcess_CompleteCondition.i_ComCon4TargetSubTankTempLevel.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iComCon5ProcessTimer",
        //        DS_SubProcess_CompleteCondition.i_ComCon5ProcessTimer.ToString(), "int");
        //}

        //private static void SubProcess_InstrumentOutput_Write(TcAdsClient adsClient, int i_StationNo, Controllers.RecipeManagement.DS_Recipe.SubProcess_InstrumentOutput DS_SubProcess_InstrumentOutput)
        //{
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut1ActValve1",
        //        DS_SubProcess_InstrumentOutput.b_Out1ActValve1.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut2ActValve2",
        //        DS_SubProcess_InstrumentOutput.b_Out2ActValve2.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut3ActValve3",
        //        DS_SubProcess_InstrumentOutput.b_Out3ActValve3.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut4ActValve4",
        //        DS_SubProcess_InstrumentOutput.b_Out4ActValve4.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut5ActValve5",
        //        DS_SubProcess_InstrumentOutput.b_Out5ActValve5.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut6ActValve6",
        //        DS_SubProcess_InstrumentOutput.b_Out6ActValve6.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut7ActValve7",
        //        DS_SubProcess_InstrumentOutput.b_Out7ActValve7.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut8ActValve8",
        //        DS_SubProcess_InstrumentOutput.b_Out8ActValve8.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut9ActValve9",
        //        DS_SubProcess_InstrumentOutput.b_Out9ActValve9.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut10ActValve10",
        //        DS_SubProcess_InstrumentOutput.b_Out10ActValve10.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut11ActValve11",
        //        DS_SubProcess_InstrumentOutput.b_Out11ActValve11.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut12ActValve12",
        //        DS_SubProcess_InstrumentOutput.b_Out12ActValve12.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut13ActValve13",
        //        DS_SubProcess_InstrumentOutput.b_Out13ActValve13.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut14ActValve14",
        //        DS_SubProcess_InstrumentOutput.b_Out14ActValve14.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut15ActValve15",
        //        DS_SubProcess_InstrumentOutput.b_Out15ActValve15.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut16ActValve16",
        //        DS_SubProcess_InstrumentOutput.b_Out16ActValve16.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut17ActValve17",
        //        DS_SubProcess_InstrumentOutput.b_Out17ActValve17.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut18ActValve18",
        //        DS_SubProcess_InstrumentOutput.b_Out18ActValve18.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut19ActValve19",
        //        DS_SubProcess_InstrumentOutput.b_Out19ActValve19.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut20ActValve20",
        //        DS_SubProcess_InstrumentOutput.b_Out20ActValve20.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut16EnProTankChangeTemperature",
        //        DS_SubProcess_InstrumentOutput.b_Out16EnProTankChangeTemperature.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut17EnSubTankChangeTemperature",
        //        DS_SubProcess_InstrumentOutput.b_Out17EnSubTankChangeTemperature.ToString(), "bool");


        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut1EnProTankPump",
        //        DS_SubProcess_InstrumentOutput.b_Out1EnProTankPump.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut2EnProTankHeater",
        //        DS_SubProcess_InstrumentOutput.b_Out2EnProTankHeater.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut3EnProTankBottomUltrasonicA",
        //        DS_SubProcess_InstrumentOutput.b_Out3EnProTankBottomUltrasonicA.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut4EnProTankBottomUltrasonicB",
        //        DS_SubProcess_InstrumentOutput.b_Out4EnProTankBottomUltrasonicB.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut5EnProTankBottomUltrasonicC",
        //        DS_SubProcess_InstrumentOutput.b_Out5EnProTankBottomUltrasonicC.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut6EnProTankSideUltrasonicA",
        //        DS_SubProcess_InstrumentOutput.b_Out6EnProTankSideUltrasonicA.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut7EnProTankSideUltrasonicB",
        //        DS_SubProcess_InstrumentOutput.b_Out7EnProTankSideUltrasonicB.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut8EnSubTankPump",
        //        DS_SubProcess_InstrumentOutput.b_Out8EnSubTankPump.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut9EnSubTankHeater",
        //        DS_SubProcess_InstrumentOutput.b_Out9EnSubTankHeater.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut10EnBlower",
        //        DS_SubProcess_InstrumentOutput.b_Out10EnBlower.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut11EnVacuumPump",
        //        DS_SubProcess_InstrumentOutput.b_Out11EnVacuumPump.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut12EnSlowPull",
        //        DS_SubProcess_InstrumentOutput.b_Out12EnSlowPull.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut13EnInstrument2",
        //        DS_SubProcess_InstrumentOutput.b_Out13EnInstrument2.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut14EnInstrument3",
        //        DS_SubProcess_InstrumentOutput.b_Out14EnInstrument3.ToString(), "bool");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.bOut15EnInstrument4",
        //        DS_SubProcess_InstrumentOutput.b_Out15EnInstrument4.ToString(), "bool");
        //}

        //private static void SubProcess_ValueSetting_Write(TcAdsClient adsClient, int i_StationNo, Controllers.RecipeManagement.DS_Recipe.SubProcess_ValueSetting DS_SubProcess_ValueSetting)
        //{
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut1ProTankPumpLPM",
        //        DS_SubProcess_ValueSetting.i_Out1ProTankPumpLPM.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut2ProTankPumpHz",
        //        DS_SubProcess_ValueSetting.i_Out2ProTankPumpHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut3ProTankBtmUsAPwrPercent",
        //        DS_SubProcess_ValueSetting.i_Out3ProTankBtmUsAPwrPercent.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut4ProTankBtmUsBPwrPercent",
        //        DS_SubProcess_ValueSetting.i_Out4ProTankBtmUsBPwrPercent.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut5ProTankBtmUsCPwrPercent",
        //        DS_SubProcess_ValueSetting.i_Out5ProTankBtmUsCPwrPercent.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut6ProTankSideUsAPwrPercent",
        //        DS_SubProcess_ValueSetting.i_Out6ProTankSideUsAPwrPercent.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut7ProTankSideUsBPwrPercent",
        //        DS_SubProcess_ValueSetting.i_Out7ProTankSideUsBPwrPercent.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut8ProTankBtmUsAkHz",
        //        DS_SubProcess_ValueSetting.i_Out8ProTankBtmUsAkHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut9ProTankBtmUsBkHz",
        //        DS_SubProcess_ValueSetting.i_Out9ProTankBtmUsBkHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut10ProTankBtmUsCkHz",
        //        DS_SubProcess_ValueSetting.i_Out10ProTankBtmUsCkHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut11ProTankSideUsAkHz",
        //        DS_SubProcess_ValueSetting.i_Out11ProTankSideUsAkHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut12ProTankSideUsBkHz",
        //        DS_SubProcess_ValueSetting.i_Out12ProTankSideUsBkHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut13ProTankBlowerHz",
        //        DS_SubProcess_ValueSetting.i_Out13ProTankBlowerHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.rOut14ProTankChangeTemperatureDegC",
        //        DS_SubProcess_ValueSetting.r_Out14ProTankChangeTemperatureDegC.ToString(), "real");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.rOut15SubTankChangeTemperatureDegC",
        //        DS_SubProcess_ValueSetting.r_Out15SubTankChangeTemperatureDegC.ToString(), "real");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut16SubTankPumpLPM",
        //        DS_SubProcess_ValueSetting.i_Out16SubTankPumpLPM.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut17SubTankPumpHz",
        //        DS_SubProcess_ValueSetting.i_Out17SubTankPumpHz.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut18SlowPullVelocity",
        //        DS_SubProcess_ValueSetting.i_Out18SlowPullVelocity.ToString(), "int");
        //    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".AR10DSStationSSURStore[" + i_StationNo + "].DsSubRecipeMemory.iOut19SlowPullDelayTime",
        //        DS_SubProcess_ValueSetting.i_Out19SlowPullDelayTime.ToString(), "int");
        //}
    }
}
