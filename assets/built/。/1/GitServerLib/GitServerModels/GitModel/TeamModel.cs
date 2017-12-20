using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitServerModels.GitModel
{
    public class TeamModel
    {
        /// <summary>
        /// 开发盟友
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool canAdmin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool canFork { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool canCreate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> repositories { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Permissions permissions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> mailingLists { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> preReceiveScripts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> postReceiveScripts { get; set; }
    }
}
