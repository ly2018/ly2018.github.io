using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitServerModels.GitModel
{
    public class LoginSetting
    {
        public string domain { get; set; }//192.168.20.139:10110
        public string loginUrl { get; set; }//http://192.168.20.139:10110/?wicket:interface=:0:userPanel:loginForm::IFormSubmitListener::
        public string rpcHost { get; set; }//http://192.168.20.139:10110/rpc/?req={0}&amp;name={1}
        public string rpcUserName { get; set; }//vic
        public string rpcPassword { get; set; }//admin123
        public int maxSleepTime { get; set; }//60000
    }
}
