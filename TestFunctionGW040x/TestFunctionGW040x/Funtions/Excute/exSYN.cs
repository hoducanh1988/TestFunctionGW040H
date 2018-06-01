using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestFunctionGW040x.Funtions {
    public class exSYN : baseFunctions, IDisposable, ISyn {

        private OLT oltdevice = new OLT(GlobalData.initSetting.OLTIP, 23);
        public exSYN() {
            GlobalData.testingInfo.logstep.logSYN += "Kết nối telnet vào OLT...\r\n";
            bool ret = oltdevice.Connection();
            GlobalData.testingInfo.logstep.logSYN += string.Format("...{0}\r\n", ret == true ? "PASS" : "FAIL");
            if (oltdevice.IsConnected == true) {
                string message = "";
                GlobalData.testingInfo.logstep.logSYN += "Đăng nhập vào ONT {User=" + GlobalData.initSetting.OLTTELNETUSER + ",Pass=" + GlobalData.initSetting.OLTTELNETPASS + "}...\r\n";
                ret = oltdevice.Login0(GlobalData.initSetting.OLTTELNETUSER, GlobalData.initSetting.OLTTELNETPASS, out message);
                GlobalData.testingInfo.logstep.logSYN += message + "\r\n";
                GlobalData.testingInfo.logstep.logSYN += string.Format("...{0}\r\n", ret == true ? "PASS" : "FAIL");
                Thread.Sleep(2000);
            }
            else GlobalData.testingInfo.ONTSYN = "\"don't connect\"";
        }

        //Kiem tra dong bo quang 3 lan/ Neu 1 trong 3 lan OK => PASS
        public bool Excute() {
            try {
                int count = 0;
                REPEAT:
                oltdevice.WriteLine("environment inhibit-alarms");
                Thread.Sleep(1000);
                string incomeData = string.Empty;
                oltdevice.WriteLine(string.Format("{0}{1}", GlobalData.initSetting.OLTCOMMAND, GlobalData.initSetting.OLTPORT));
                Thread.Sleep(300);
                incomeData = oltdevice.Read();
                bool ret = incomeData.Contains(GEN_SERIAL_ONT(GlobalData.testingInfo.MACADDRESS));
                if (ret == false) {
                    count++;
                    if (count < 3) goto REPEAT;
                }
                return ret;
            }
            catch {
                return false;
            }
        }

        public void Dispose() {
            oltdevice.Close();
        }
    }
}
