using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace TestFunctionGW040x.Funtions {
    public class exPowerOptical : baseFunctions, IDisposable, ISyn {

        private ONT ontdevice = new ONT(GlobalData.initSetting.DUTIP, 23);
        private bool Connect() {
            try {
                GlobalData.testingInfo.logstep.logPowerOptical += "Kết nối telnet vào ONT...\r\n";
                bool ret = ontdevice.Connection();
                GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...{0}\r\n", ret == true ? "PASS" : "FAIL");
                if (ontdevice.IsConnected == true) {
                    string message = "";
                    GlobalData.testingInfo.logstep.logPowerOptical += "Đăng nhập vào ONT {User=" + GlobalData.initSetting.DUTTELNETUSER + ",Pass=" + GlobalData.initSetting.DUTTELNETPASS + "}...\r\n";
                    ret = ontdevice.Login0(GlobalData.initSetting.DUTTELNETUSER, GlobalData.initSetting.DUTTELNETPASS, out message);
                    GlobalData.testingInfo.logstep.logPowerOptical += message + "\r\n";
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...{0}\r\n", ret == true ? "PASS" : "FAIL");
                    return ret;
                }
                else { GlobalData.testingInfo.ONTPOWER = "\"don't connect\""; return false; }
            }
            catch {
                return false;
            }
        }

        public exPowerOptical() {

        }

        private double _InttodBm(string _Number) {
            try {
                double value = double.Parse(_Number);
                double x = value / 10000;
                double logx = System.Math.Log(x);
                double log10 = System.Math.Log(10);
                double tmp = logx / log10;
                double ret = System.Math.Round(tmp * 100, 2) / 10;
                return ret;
            }
            catch {
                return double.MinValue;
            }
        }

        public bool Excute() {
            //1.Connect to ONT
            int count = 0;
            REPEAT:
            count++;
            if (!Connect()) {
                if (count <= 3) goto REPEAT;
                else {
                    object obj = new object();
                    lock (obj) { GlobalData.testingInfo.ERRORCODE += "Fpo0#0001, "; }
                    return false;
                }
            }

            //2.Excute commandline
            try {
                //RX
                GlobalData.testingInfo.logstep.logPowerOptical += "Đọc giá trị công suất thu RX...\r\n";
                ontdevice.WriteLine("tcapi get Info_PonPhy RxPower");
                Thread.Sleep(300);
                bool rxRet = false;
                string rxData = ontdevice.Read0();
                GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...{0}\r\n", rxData);
                double rxPower = double.MinValue;
                if (rxData.Contains("tcapi get Info_PonPhy RxPower")) {
                    rxData = rxData.Replace("tcapi get Info_PonPhy RxPower", "").Replace("#", "").Replace("\r\n", "").Replace("\r", "").Trim();
                    rxPower = _InttodBm(rxData);
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...Giá trị quy đổi {0}dBm\r\n", rxPower);
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...Tiêu chuẩn từ {0}dBm đến {1}dBm\r\n", GlobalData.initSetting.DUTRXMIN, GlobalData.initSetting.DUTRXMAX);
                    //compare rxData with standard
                    rxRet = (rxPower <= GlobalData.initSetting.DUTRXMAX) && (rxPower >= GlobalData.initSetting.DUTRXMIN);
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("Kết quả đo công suất thu RX là: {0}\r\n", rxRet == true ? "PASS" : "FAIL");
                    GlobalData.testingInfo.POWERRXSTATUS = rxRet == true ? TestingStatuses.Pass : TestingStatuses.Fail;
                }
                else {
                    GlobalData.testingInfo.POWERRXSTATUS = TestingStatuses.Fail;
                }

                //TX - check lap lai 10 lan, neu 10 lan deu NG => hien thi NG
                count = 0;
                REPEAT1:
                GlobalData.testingInfo.logstep.logPowerOptical += "Đọc giá trị công suất phát TX...\r\n";
                ontdevice.WriteLine("tcapi get Info_PonPhy TxPower");
                Thread.Sleep(1000);
                bool txRet = false;
                string txData = ontdevice.Read0();
                GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...{0}\r\n", txData);
                double txPower = double.MinValue;

                if (txData.Contains("tcapi get Info_PonPhy TxPower")) {
                    txData = txData.Replace("tcapi get Info_PonPhy TxPower", "").Replace("#", "").Replace("\r\n", "").Replace("\r", "").Trim();
                    txPower = _InttodBm(txData);
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...Giá trị quy đổi {0}dBm\r\n", txPower);
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("...Tiêu chuẩn từ {0}dBm đến {1}dBm\r\n", GlobalData.initSetting.DUTTXMIN, GlobalData.initSetting.DUTTXMAX);
                    //compare txData with standard
                    txRet = (txPower <= GlobalData.initSetting.DUTTXMAX) && (txPower >= GlobalData.initSetting.DUTTXMIN);
                    if (txRet == false) {
                        count++;
                        if (count < 10) goto REPEAT1; 
                    }
                    GlobalData.testingInfo.logstep.logPowerOptical += string.Format("Kết quả đo công suất phát TX là: {0}\r\n", txRet == true ? "PASS" : "FAIL");
                    GlobalData.testingInfo.POWERTXSTATUS = txRet == true ? TestingStatuses.Pass : TestingStatuses.Fail;
                }
                else {
                    GlobalData.testingInfo.POWERTXSTATUS = TestingStatuses.Fail;
                }

                GlobalData.testingInfo.ONTPOWER = string.Format("\"TX={0}dBm,RX={1}dBm\"", txPower, rxPower);
                if (txRet == false || rxRet == false) {
                    object obj = new object();
                    lock (obj) { GlobalData.testingInfo.ERRORCODE += string.Format("Fpo1#{0}, ", GEN_ERRORCODE(txRet, rxRet)); }
                }
                return txRet && rxRet;
            }
            catch {
                object obj = new object();
                lock (obj) { GlobalData.testingInfo.ERRORCODE += "Fpo0#0002, "; }
                return false;
            }
        }

        public void Dispose() {
            ontdevice.Close();
        }
    }
}
