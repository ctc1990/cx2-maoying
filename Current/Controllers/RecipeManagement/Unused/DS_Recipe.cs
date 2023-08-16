using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.Unused
{
    class DS_Recipe
    {
        //public struct Process
        //{
        //    public int i_StationSequenceRecipeNo;
        //    public string s_StationSequenceRecipeDescription;

        //    public int[] AR10i_StationSubProNo;
        //    public int[] AR10i_Cycle;
        //    public int[] AR10i_RepeatFromStepNo;
        //}

        //public struct Process_Value
        //{
        //    public int i_CycleCount;
        //    public int i_RepeatFrom;
        //}

        //public struct SubProcess
        //{
        //    public int i_SubRecipeNo;
        //    public string s_SubRecipeDescription;
        //    public SubProcess_StartCondition DS_StartCondition;
        //    public SubProcess_CompleteCondition DS_CompleteCondition;
        //    public SubProcess_InstrumentOutput DS_InstrumentOutput;
        //    public SubProcess_ValueSetting DS_ValueSetting;
        //}

        //public struct SubProcess_StartCondition
        //{
        //    string condition;

        //    public bool b_StCon1EnProLowLiquidLevel;
        //    public bool b_StCon2EnProRegLiquidLevel;
        //    public bool b_StCon3EnProHighLiquidLevel;
        //    public bool b_StCon4EnSubLowLiquidLevel;
        //    public bool b_StCon5EnSubRegLiquidLevel;
        //    public bool b_StCon6EnSubHighLiquidLevel;
        //    public bool b_StCon7EnLowVacuumLevel;
        //    public bool b_StCon8EnRegVacuumLevel;
        //    public bool b_StCon9EnLowPressureLevel;
        //    public bool b_StCon10EnRegPressureLevel;
        //    public bool b_StCon11EnBelowTargetVacuumLevel;
        //    public bool b_StCon12EnAboveTargetVacuumLevel;
        //    public bool b_StCon13EnBelowTargetPressureLevel;
        //    public bool b_StCon14EnAboveTargetPressureLevel;
        //    public bool b_StCon15EnBelowTargetProTankTempLevel;
        //    public bool b_StCon16EnAboveTargetProTankTempLevel;
        //    public bool b_StCon17EnBelowTargetSubTankTempLevel;
        //    public bool b_StCon18EnAboveTargetSubTankTempLevel;
        //    public bool b_StCon19ExternalActivation;

        //    public int i_StCon1TargetVacuumLevel;
        //    public int i_StCon2TargetPressureLevel;
        //    public int i_StCon3TargetProTankTempLevel;
        //    public int i_StCon4TargetSubTankTempLevel;
        //}

        //public struct SubProcess_CompleteCondition
        //{
        //    string condition;

        //    public bool b_ComCon1EnProLowLiquidLevel;
        //    public bool b_ComCon2EnProRegLiquidLevel;
        //    public bool b_ComCon3EnProHighLiquidLevel;
        //    public bool b_ComCon4EnSubLowLiquidLevel;
        //    public bool b_ComCon5EnSubRegLiquidLevel;
        //    public bool b_ComCon6EnSubHighLiquidLevel;
        //    public bool b_ComCon7EnLowVacuumLevel;
        //    public bool b_ComCon8EnRegVacuumLevel;
        //    public bool b_ComCon9EnLowPressureLevel;
        //    public bool b_ComCon10EnRegPressureLevel;
        //    public bool b_ComCon11EnBelowTargetVacuumLevel;
        //    public bool b_ComCon12EnAboveTargetVacuumLevel;
        //    public bool b_ComCon13EnBelowTargetPressureLevel;
        //    public bool b_ComCon14EnAboveTargetPressureLevel;
        //    public bool b_ComCon15EnBelowTargetProTankTempLevel;
        //    public bool b_ComCon16EnAboveTargetProTankTempLevel;
        //    public bool b_ComCon17EnBelowTargetSubTankTempLevel;
        //    public bool b_ComCon18EnAboveTargetSubTankTempLevel;
        //    public bool b_ComCon19EnExternalActivation;
        //    public bool b_ComCon20EnProcessTimer;

        //    public int i_ComCon1TargetVacuumLevel;
        //    public int i_ComCon2TargetPressureLevel;
        //    public int i_ComCon3TargetProTankTempLevel;
        //    public int i_ComCon4TargetSubTankTempLevel;
        //    public int i_ComCon5ProcessTimer;
        //}

        //public struct SubProcess_InstrumentOutput
        //{
        //    public bool b_Out1ActValve1;
        //    public bool b_Out2ActValve2;
        //    public bool b_Out3ActValve3;
        //    public bool b_Out4ActValve4;
        //    public bool b_Out5ActValve5;
        //    public bool b_Out6ActValve6;
        //    public bool b_Out7ActValve7;
        //    public bool b_Out8ActValve8;
        //    public bool b_Out9ActValve9;
        //    public bool b_Out10ActValve10;
        //    public bool b_Out11ActValve11;
        //    public bool b_Out12ActValve12;
        //    public bool b_Out13ActValve13;
        //    public bool b_Out14ActValve14;
        //    public bool b_Out15ActValve15;
        //    public bool b_Out16ActValve16;
        //    public bool b_Out17ActValve17;
        //    public bool b_Out18ActValve18;
        //    public bool b_Out19ActValve19;
        //    public bool b_Out20ActValve20;
        //    public bool b_Out16EnProTankChangeTemperature;
        //    public bool b_Out17EnSubTankChangeTemperature;

        //    public bool b_Out1EnProTankPump;
        //    public bool b_Out2EnProTankHeater;
        //    public bool b_Out3EnProTankBottomUltrasonicA;
        //    public bool b_Out4EnProTankBottomUltrasonicB;
        //    public bool b_Out5EnProTankBottomUltrasonicC;
        //    public bool b_Out6EnProTankSideUltrasonicA;
        //    public bool b_Out7EnProTankSideUltrasonicB;
        //    public bool b_Out8EnSubTankPump;
        //    public bool b_Out9EnSubTankHeater;
        //    public bool b_Out10EnBlower;
        //    public bool b_Out11EnVacuumPump;
        //    public bool b_Out12EnSlowPull;
        //    public bool b_Out13EnInstrument2;
        //    public bool b_Out14EnInstrument3;
        //    public bool b_Out15EnInstrument4;
        //}

        //public struct SubProcess_ValueSetting
        //{
        //    public int i_Out1ProTankPumpLPM;
        //    public int i_Out2ProTankPumpHz;
        //    public int i_Out3ProTankBtmUsAPwrPercent;
        //    public int i_Out4ProTankBtmUsBPwrPercent;
        //    public int i_Out5ProTankBtmUsCPwrPercent;
        //    public int i_Out6ProTankSideUsAPwrPercent;
        //    public int i_Out7ProTankSideUsBPwrPercent;
        //    public int i_Out8ProTankBtmUsAkHz;
        //    public int i_Out9ProTankBtmUsBkHz;
        //    public int i_Out10ProTankBtmUsCkHz;
        //    public int i_Out11ProTankSideUsAkHz;
        //    public int i_Out12ProTankSideUsBkHz;
        //    public int i_Out13ProTankBlowerHz;
        //    public float r_Out14ProTankChangeTemperatureDegC;
        //    public float r_Out15SubTankChangeTemperatureDegC;
        //    public int i_Out16SubTankPumpLPM;
        //    public int i_Out17SubTankPumpHz;
        //    public int i_Out18SlowPullVelocity;
        //    public int i_Out19SlowPullDelayTime;
        //}

        //public struct Base_Setting
        //{
        //    public float[] ARr_TempValueSetting;
        //    public float[] ARr_TempRdySetting;
        //    public float[] ARr_TempHighAlarmSetting;
        //    public float[] ARr_TempHysSetting;
        //    public float[] ARr_Temp1stLimitSetting;
        //    public float[] ARr_TempOverideSetting;
        //    public float[] ARr_TempOveride1stLimitSetting;

        //    public int i_VacuumDrainTime;

        //    public bool[] ARb_DayOnEn_IN;
        //    public bool[] ARb_DayOffEn_IN;
        //    public UInt32[] ARw_DayOnHour_IN;
        //    public UInt32[] ARw_DayOnMinute_IN;
        //    public UInt32[] ARw_DayOffHour_IN;
        //    public UInt32[] ARw_DayOffMinute_IN;
        //}

        //public struct PLC_Value
        //{
        //    public bool var_bool;
        //    public double var_lreal;
        //    public int var_bits;
        //    public string var_string;
        //    public string ErrorMsg;

        //    public bool ResponseBool;
        //}

        //public struct Value_From_PLC
        //{
        //    public int i_MainRecipeNo;
        //    public int i_CurrentSubPro;
        //    public int i_ProcessCaseNo;

        //    public bool b_StartConditionSucess;
        //    public bool b_CompleteConditionSucess;
        //    public bool b_StartorComplete;
        //    public bool b_ProcessStart;
        //    public bool b_ProcesstimeDone;


        //    public bool b_ProLowLiquidLevel_NC;
        //    public bool b_ProRegLiquidLevel_NO;
        //    public bool b_ProHighLiquidLevel_NO;

        //    public bool b_SubLowLiquidLevel_NC;
        //    public bool b_SubRegLiquidLevel_NO;
        //    public bool b_SubHighLiquidLevel_NO;

        //    public bool b_LowVacuumLevel_NO;
        //    public bool b_RegVacuumLevel_NO;

        //    public bool b_LowPressureLevel_NO;
        //    public bool b_RegPressureLevel_NO;

        //    public bool b_ExternalActivation_NO;

        //    public int i_VacuumLevelPV;
        //    public int i_PressureLevelPV;
        //    public int i_ProTankTempLevelPV;
        //    public int i_SubTankTempLevelPV;
        //}

        //private struct deactivate
        //{
        //    ////CURRENTLY USING IN FE PLC
        //    //DE10008 = Y100_08; //US1,US2,US3,US4
        //    //DE10009 = Y100_09; //V1
        //    //DE10010 = Y100_10; //P1
        //    //DE10011 = Y100_11; //H1
        //    //DE10012 = Y100_12; //H2
        //    //DE10013 = Y100_13; //H3

        //    ////NOT USING
        //    //DE10006 = Y100_06;
        //    //DE10007 = Y100_07;
        //    //DE10014 = Y100_14;
        //    //DE10015 = Y100_15;

        //    //DE10100 = Y101_00; //AV1-1
        //    //DE10102 = Y101_01; //AV1-2
        //    //DE10103 = Y101_02; //AV1-3
        //    //DE10104 = Y101_03; //AV1-4
        //    //DE10105 = Y101_04; //AV1-5
        //    //DE10106 = Y101_05; //AV1-6
        //    //DE10107 = Y101_06; //AV1-7
        //    //DE10108 = Y101_07; //AV1-8
        //    //DE10109 = Y101_08; //AV1-9
        //    //DE10110 = Y101_09; //AV1-10
        //    //DE10111 = Y101_10; //AV1-11
        //    //DE10112 = Y101_11; //AV1-12
        //    //DE10113 = Y101_12; //AV1-13
        //    //DE10114 = Y101_13; //AV1-14
        //    //DE10115 = Y101_14; //AV1-15
        //    //DE10115 = Y101_15; //AV1-16

        //    //DE10200 = Y102_00; //AV1-17
        //    //DE10202 = Y102_01; //SV1-1
        //    //DE10204 = Y102_03; //SV1-2
        //    //DE10205 = Y102_05; //SV1-3
        //    //DE10206 = Y102_06; //DOOR CLAMP AV
        //    //DE10207 = Y102_07; //DOOR UNCLAMP AV
        //}
    }
}
