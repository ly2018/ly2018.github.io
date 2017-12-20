using GitServerIService;
using System;
using GitServerModels.GitModel;
using GitServerModels.ReqResModel;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Configuration;
using GitServerUtillty;
using System.Collections;

namespace GitServerService
{
    public class GitServerClientService : IGitServerClientService
    {
        private static LoginSetting loginSetting;

        private static string _url;

        private static ICredentials _credentials;

        public GitServerClientService()
        {
            if (loginSetting == null)
            {
                try
                {
                    string domain = ConfigurationManager.AppSettings["domain"];
                    string loginUrl = ConfigurationManager.AppSettings["loginUrl"];
                    string host = ConfigurationManager.AppSettings["rpcHost"];
                    string rpcUserName = ConfigurationManager.AppSettings["rpcUserName"];
                    string rpcPassword = ConfigurationManager.AppSettings["rpcPassword"];
                    int sleep = 3000;
                    int.TryParse(ConfigurationManager.AppSettings["maxSleepTime"], out sleep);

                    loginSetting = new LoginSetting()
                    {
                        rpcHost = host,
                        rpcUserName = rpcUserName,
                        rpcPassword = rpcPassword,
                        maxSleepTime = sleep,
                        domain = domain,
                        loginUrl = loginUrl
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception("LoginSetting Error: " + ex.Message);
                }
            }

            _url = loginSetting.rpcHost;
            _credentials = new NetworkCredential(loginSetting.rpcUserName, loginSetting.rpcPassword, loginSetting.domain);
        }

        public static void Init(string host, string rpcUserName, string rpcPassword)
        {
            _url = host;
            _credentials = new NetworkCredential(rpcUserName, rpcPassword);
        }

        //private ResponseData<T> InvokeMethod<T>(string a_sMethod, params object[] a_params)
        //{
        //    //模拟先登录，或找到登录API
        //    var _uri = new Uri(string.Format(_url, a_sMethod, ""));
        //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_uri);
        //    webRequest.Credentials = _credentials;
        //    webRequest.ContentType = "application/json-rpc";
        //    webRequest.Method = "POST";

        //    JObject joe = new JObject();
        //    joe["jsonrpc"] = "1";
        //    joe["id"] = "1";

        //    if (a_params != null)
        //    {
        //        if (a_params.Length > 0)
        //        {
        //            JArray props = new JArray();
        //            foreach (var p in a_params)
        //            {
        //                props.Add(p);
        //            }
        //            joe.Add(new JProperty("params", props));
        //        }
        //    }

        //    string s = JsonConvert.SerializeObject(joe);
        //    // serialize json for the request
        //    byte[] byteArray = Encoding.UTF8.GetBytes(s);
        //    webRequest.ContentLength = byteArray.Length;

        //    using (Stream dataStream = webRequest.GetRequestStream())
        //    {
        //        dataStream.Write(byteArray, 0, byteArray.Length);
        //    }

        //    using (WebResponse webResponse = webRequest.GetResponse())
        //    {
        //        using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
        //        {
        //            using (StreamReader sr = new StreamReader(responseStream))
        //            {
        //                string result = sr.ReadToEnd();
        //                return JsonConvert.DeserializeObject<ResponseData<T>>(result);
        //            }
        //        }

        //    }
        //}

        private ResponseData<T> InvokeMethod<T>(string a_sMethod, string name = "", params object[] a_params)
        {
            //模拟先登录，或找到登录API
            var _uri = string.Format(_url, a_sMethod, name);
            HttpUtil _HttpUtil = new HttpUtil(loginSetting.loginUrl, loginSetting.rpcUserName, loginSetting.rpcPassword);

            string s = string.Empty;
            if (a_params != null && a_params.Length > 0)
            {
                s = JsonConvert.SerializeObject(a_params[0]);
            }
            HttpStatusCode gitResultCode = HttpStatusCode.ExpectationFailed;
            string result = _HttpUtil.ExecuteRequest(loginSetting.domain, _uri, loginSetting.rpcUserName, s, ref gitResultCode, DataType.JsonRpc, RequstType.Post);
            var ret = new ResponseData<T>();
            ret.Result = JsonConvert.DeserializeObject<T>(result);
            ret.gitResultCode = gitResultCode;
            if (ret.gitResultCode == HttpStatusCode.OK)
            {
                ret.IsSuccess = true;
            }
            return ret;
        }

        public ResponseData<RepositoryModel> CREATE_REPOSITORY(string repositoryName, RepositoryModel postBody)
        {
            return this.InvokeMethod<RepositoryModel>(RPCMethod.CREATE_REPOSITORY, repositoryName, postBody);
        }

        public ResponseData<RepositoryModel> DELETE_REPOSITORY(string repositoryName, RepositoryModel postBody)
        {
            return this.InvokeMethod<RepositoryModel>(RPCMethod.DELETE_REPOSITORY, repositoryName, postBody);
        }

        public ResponseData<RepositoryModel> EDIT_REPOSITORY(string repositoryName, RepositoryModel postBody)
        {
            return this.InvokeMethod<RepositoryModel>(RPCMethod.EDIT_REPOSITORY, repositoryName, postBody);
        }

        public ResponseData<string> FORK_REPOSITORY(string repositoryName)
        {
            return this.InvokeMethod<string>(RPCMethod.FORK_REPOSITORY, repositoryName);
        }

        public ResponseData<int> GET_PROTOCOL()
        {
            return this.InvokeMethod<int>(RPCMethod.GET_PROTOCOL);
        }

        public ResponseData<UserModel> GET_USER(string UserName)
        {
            return this.InvokeMethod<UserModel>(RPCMethod.GET_USER, UserName);
        }

        public ResponseData<Hashtable> LIST_BRANCHES()
        {
            return this.InvokeMethod<Hashtable>(RPCMethod.LIST_BRANCHES);
        }

        public ResponseData<Hashtable> LIST_REPOSITORIES()
        {
            return this.InvokeMethod<Hashtable>(RPCMethod.LIST_REPOSITORIES);
        }

        public ResponseData<ServerSettings> LIST_SETTINGS()
        {
            return this.InvokeMethod<ServerSettings>(RPCMethod.GET_USER);
        }

        public ResponseData<List<UserModel>> LIST_USERS()
        {
            return this.InvokeMethod<List<UserModel>>(RPCMethod.LIST_USERS);
        }

        public ResponseData<string> CREATE_USER(string userName, UserModel userModel)
        {
            return this.InvokeMethod<string>(RPCMethod.CREATE_USER, userName, userModel);
        }

        public ResponseData<string> EDIT_USER(string userName, UserModel userModel)
        {
            return this.InvokeMethod<string>(RPCMethod.EDIT_USER, userName, userModel);
        }

        public ResponseData<string> DELETE_USER(string userName, UserModel userModel)
        {
            return this.InvokeMethod<string>(RPCMethod.DELETE_USER, userName, userModel);
        }

        public ResponseData<List<TeamModel>> LIST_TEAMS()
        {
            return this.InvokeMethod<List<TeamModel>>(RPCMethod.LIST_TEAMS);
        }

        public ResponseData<string> CREATE_TEAM(string teamName, TeamModel teamModel)
        {
            return this.InvokeMethod<string>(RPCMethod.CREATE_TEAM, teamName, teamModel);
        }

        public ResponseData<string> EDIT_TEAM(string teamName, TeamModel teamModel)
        {
            return this.InvokeMethod<string>(RPCMethod.EDIT_TEAM, teamName, teamModel);
        }

        public ResponseData<string> DELETE_TEAM(string teamName, TeamModel teamModel)
        {
            return this.InvokeMethod<string>(RPCMethod.DELETE_TEAM, teamName, teamModel);
        }

        public ResponseData<List<string>> LIST_REPOSITORY_MEMBERS(string repositoryName)
        {
            return this.InvokeMethod<List<string>>(RPCMethod.LIST_REPOSITORY_MEMBERS, repositoryName);
        }

        public ResponseData<List<RepositoryPermission>> LIST_REPOSITORY_MEMBER_PERMISSIONS(string repositoryName)
        {
            return this.InvokeMethod<List<RepositoryPermission>>(RPCMethod.LIST_REPOSITORY_MEMBER_PERMISSIONS, repositoryName);
        }

        public ResponseData<string> SET_REPOSITORY_MEMBER_PERMISSIONS(string repositoryName, List<RepositoryPermission> permissions)
        {
            return this.InvokeMethod<string>(RPCMethod.SET_REPOSITORY_MEMBER_PERMISSIONS, repositoryName, permissions);
        }

        public ResponseData<List<string>> LIST_REPOSITORY_TEAMS(string repositoryName)
        {
            return this.InvokeMethod<List<string>>(RPCMethod.LIST_REPOSITORY_TEAMS, repositoryName);
        }

        public ResponseData<List<RepositoryPermission>> LIST_REPOSITORY_TEAM_PERMISSIONS(string repositoryName)
        {
            return this.InvokeMethod<List<RepositoryPermission>>(RPCMethod.LIST_REPOSITORY_TEAM_PERMISSIONS, repositoryName);
        }

        public ResponseData<string> SET_REPOSITORY_TEAM_PERMISSIONS(string repositoryName, List<RepositoryPermission> permissions)
        {
            return this.InvokeMethod<string>(RPCMethod.SET_REPOSITORY_TEAM_PERMISSIONS, repositoryName, permissions);
        }

        public ResponseData<string> CLEAR_REPOSITORY_CACHE()
        {
            return this.InvokeMethod<string>(RPCMethod.CLEAR_REPOSITORY_CACHE);
        }

        public ResponseData<string> REINDEX_TICKETS(string repositoryName)
        {
            return this.InvokeMethod<string>(RPCMethod.REINDEX_TICKETS, repositoryName);
        }
    }
}
