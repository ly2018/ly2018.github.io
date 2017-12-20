using System;
using System.Collections.Generic;
using System.Text;

namespace GitServerModels.GitModel
{
    /// <summary>
    /// 权限
    /// </summary>
    public class Permissions
    {
        
    }

    public class TeamsItem
    {
        /// <summary>
        /// 开发盟友
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string canAdmin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string canFork { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string canCreate { get; set; }
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

    public class RepositoryPreferences
    {
    }

    public class UserPreferences
    {
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string emailMeOnMyTicketChanges { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RepositoryPreferences repositoryPreferences { get; set; }
    }

    public class UserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        /// <summary>
        ///格式为：  "MD5:" + CryptoUtil.Md5("密码"),
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cookie { get; set; }
        /// <summary>
        /// 注册邮箱
        /// </summary>
        public string emailAddress { get; set; }
        /// <summary>
        /// Gitblit 服务器管理员
        /// </summary>
        public bool canAdmin { get; set; }
        /// <summary>
        /// 允许派生认证版本库到私人版本库
        /// </summary>
        public bool canFork { get; set; }
        /// <summary>
        /// 允许创建私人版本库
        /// </summary>
        public bool canCreate { get; set; }
        /// <summary>
        /// 禁止已 federated 的 Gitblit 实例从本账户拉取
        /// </summary>
        public bool excludeFromFederation { get; set; }
        /// <summary>
        /// 禁止当前账户进行认证
        /// </summary>
        public bool disabled { get; set; }
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
        public List<TeamsItem> teams { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isAuthenticated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserPreferences userPreferences { get; set; }
    }
}
