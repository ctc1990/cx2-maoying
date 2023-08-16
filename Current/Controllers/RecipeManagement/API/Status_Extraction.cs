using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLEANXCEL2._2.Controllers.ADS;
using CLEANXCEL2._2.UserControls;
using MySql.Data.MySqlClient;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Controllers.RecipeManagement.API
{
    class Status_Extraction
    {
        public static string ExecuteStatusExtraction(TcAdsClient adsClient)
        {
            MySqlCommand mySqlCommand = new MySqlCommand();
            string parameters = "";
            //try
            //{
                List<IO> list = InitiateMapping();

                foreach (IO io in list)
                {
                    try
                    {
                        parameters += io.tag + ":" + ADS_ReadWrite.ADS_ReadValue(adsClient, io.input) + "~";
                    }
                    catch
                    {
                        parameters += io.tag + ":null~";
                    }
                }

                foreach (Sensor sensor in sensors)
                {
                    try
                    {
                        parameters += sensor.tag + ":" + ADS_ReadWrite.ADS_ReadValue(adsClient, sensor.input) + "~";
                    }
                    catch
                    {
                        parameters += sensor.tag + ":null~";
                    }
                }

                return parameters.Remove(parameters.Length-1);
            //}
            //catch (Exception ex) { return ex.Message.ToString(); }
        }

        private static readonly List<Sensor> sensors = new List<Sensor>() {
            new Sensor(){ tag = "187 Actual", input = ".ARrStnTempPV[1]" },
            new Sensor(){ tag = "187 Set", input = ".ARrStnTempSV[1]" },
            new Sensor(){ tag = "188 Actual", input = ".ARrStnTempPV[6]" },
            new Sensor(){ tag = "188 Set", input = ".ARrStnTempHALsv[6]" },
            new Sensor(){ tag = "189 Actual", input = ".ARrStnTempPV[2]" },
            new Sensor(){ tag = "189 Set", input = ".ARrStnTempSV[2]" },
            new Sensor(){ tag = "190 Actual", input = ".ARrStnTempPV[3]" },
            new Sensor(){ tag = "190 Set", input = ".ARrStnTempSV[3]" },
            new Sensor(){ tag = "191 Actual", input = ".ARrStnTempPV[5]" },
            new Sensor(){ tag = "191 Set", input = ".ARrStnTempSV[5]" },
            new Sensor(){ tag = "192 Actual", input = ".ARrStnTempPV[4]" },
            new Sensor(){ tag = "192 Set", input = ".ARrStnTempSV[4]" },
            new Sensor(){ tag = "193 Actual", input = ".ARrStnVacuumPV[1]" },
            new Sensor(){ tag = "268 Actual", input = ".ARrRevVacuumPV[1]" },
            new Sensor(){ tag = "194 Actual", input = ".ARiUsPowerPV_percent[1]" },
            new Sensor(){ tag = "194 Set", input = ".ARDsStnSeqProcessCtrl[1].Out_DSStnSeqProOutput.i3ProTankBtmUsAPwrPercent" },
            new Sensor(){ tag = "195 Actual", input = ".ARDsStnSeqProcessCtrl[1].Out_DSStnSeqProOutput.i8ProTankBtmUsAkHz" },
            new Sensor(){ tag = "195 Set", input = ".ARDsStnSeqProcessCtrl[1].Out_DSStnSeqProOutput.i8ProTankBtmUsAkHz" }
        };

        private static List<IO> InitiateMapping()
        {
            List<IO> Mapping = new List<IO>();

            // Equipments
            Mapping.Add(new IO { tag = "CH1", input = ".Y100_06", output = ".WY10006_15", bypass = "." });
            Mapping.Add(new IO { tag = "P1", input = ".Y100_10", output = ".WY10010_15", bypass = ".DE10010" });
            Mapping.Add(new IO { tag = "PV1", input = ".Y100_09", output = ".WY10009_15", bypass = ".DE10009" });
            Mapping.Add(new IO { tag = "US1", input = ".Y100_08", output = ".WY10008_15", bypass = ".DE10008" });
            Mapping.Add(new IO { tag = "H1", input = ".Y100_11", output = ".WY10011_15", bypass = ".DE10011" });
            Mapping.Add(new IO { tag = "H2", input = ".Y100_12", output = ".WY10012_15", bypass = ".DE10012" });
            Mapping.Add(new IO { tag = "H3", input = ".Y100_13", output = ".WY10013_15", bypass = ".DE10013" });

            // Air Valve
            Mapping.Add(new IO { tag = "AV1_1", input = ".Y101_00", output = ".WY10100_15", bypass = ".DE10100" });
            Mapping.Add(new IO { tag = "AV1_2", input = ".Y101_01", output = ".WY10101_15", bypass = ".DE10102" });
            Mapping.Add(new IO { tag = "AV1_3", input = ".Y101_02", output = ".WY10102_15", bypass = ".DE10103" });
            Mapping.Add(new IO { tag = "AV1_4", input = ".Y101_03", output = ".WY10103_15", bypass = ".DE10104" });
            Mapping.Add(new IO { tag = "AV1_5", input = ".Y101_04", output = ".WY10104_15", bypass = ".DE10105" });
            Mapping.Add(new IO { tag = "AV1_6", input = ".Y101_05", output = ".WY10105_15", bypass = ".DE10106" });
            Mapping.Add(new IO { tag = "AV1_7", input = ".Y101_06", output = ".WY10106_15", bypass = ".DE10107" });
            Mapping.Add(new IO { tag = "AV1_8", input = ".Y101_07", output = ".WY10107_15", bypass = ".DE10108" });
            Mapping.Add(new IO { tag = "AV1_9", input = ".Y101_08", output = ".WY10108_15", bypass = ".DE10109" });
            Mapping.Add(new IO { tag = "AV1_10", input = ".Y101_09", output = ".WY10109_15", bypass = ".DE10110" });
            Mapping.Add(new IO { tag = "AV1_11", input = ".Y101_10", output = ".WY10110_15", bypass = ".DE10111" });
            Mapping.Add(new IO { tag = "AV1_12", input = ".Y101_11", output = ".WY10111_15", bypass = ".DE10112" });
            Mapping.Add(new IO { tag = "AV1_13", input = ".Y101_12", output = ".WY10112_15", bypass = ".DE10113" });
            Mapping.Add(new IO { tag = "AV1_14", input = ".Y101_13", output = ".WY10113_15", bypass = ".DE10114" });
            Mapping.Add(new IO { tag = "AV1_15", input = ".Y101_14", output = ".WY10114_15", bypass = ".DE10115" });
            Mapping.Add(new IO { tag = "AV1_16", input = ".Y101_15", output = ".WY10115_15", bypass = ".DE10115" });
            Mapping.Add(new IO { tag = "AV1_17", input = ".Y102_00", output = ".WY10200_15", bypass = ".DE10200" });
            Mapping.Add(new IO { tag = "AV1_18", input = ".Y103_00", output = ".WY10300_15", bypass = ".DE10300" });
            Mapping.Add(new IO { tag = "AV1_19", input = ".Y103_01", output = ".WY10301_15", bypass = ".DE10301" });
            Mapping.Add(new IO { tag = "AV1_20", input = ".Y103_02", output = ".WY10302_15", bypass = ".DE10302" });
            Mapping.Add(new IO { tag = "AV1_21", input = ".Y103_03", output = ".WY10303_15", bypass = ".DE10303" });
            Mapping.Add(new IO { tag = "AV1_22", input = ".Y103_04", output = ".WY10304_15", bypass = ".DE10304" });
            Mapping.Add(new IO { tag = "AV1_23", input = ".Y103_05", output = ".WY10305_15", bypass = ".DE10305" });
            Mapping.Add(new IO { tag = "AV1_24", input = ".Y103_06", output = ".WY10306_15", bypass = ".DE10306" });
            Mapping.Add(new IO { tag = "AV1_25", input = ".Y103_07", output = ".WY10307_15", bypass = ".DE10307" });
            Mapping.Add(new IO { tag = "AV1_26", input = ".Y103_08", output = ".WY10308_15", bypass = ".DE10308" });

            // Solenoid Valve
            Mapping.Add(new IO { tag = "SV1_1", input = ".Y102_01", output = ".WY10201_15", bypass = ".DE10202" });

            // Gateway
            Mapping.Add(new IO { tag = "Door Close", input = ".X101_04", output = ".WY10014_15", bypass = ".DE10206" }); //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            Mapping.Add(new IO { tag = "Door Open", input = ".X101_03", output = ".WY10015_15", bypass = ".DE10207" }); //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)

            // Others
            Mapping.Add(new IO { tag = "Clamp Left", input = ".X102_08", output = ".WY10206_15", bypass = "." }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            Mapping.Add(new IO { tag = "Unclamp Left", input = ".X102_09", output = ".WY10207_15", bypass = "." }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            Mapping.Add(new IO { tag = "Clamp Right", input = ".X102_10", output = ".WY10206_15", bypass = "." }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            Mapping.Add(new IO { tag = "Unclamp Right", input = ".X102_11", output = ".WY10207_15", bypass = "." }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            //Mapping.Add(new IO { tag = "CH1", button = Circulation, input = ".wPumpCircFunction", output = ".wPumpCircFunction", bypass = "." });
            //Mapping.Add(new IO { tag = "CH1", button = SolventTopUp, input = ".wSolventTopupFunction.15", output = ".wSolventTopupFunction.15", bypass = "." });

            return Mapping;
        }

        private struct IO
        {
            public string tag;
            public string output;
            public string input;
            public string bypass;
        }

        private struct Sensor
        {
            public string tag;
            public string input;
        }
    }
}
