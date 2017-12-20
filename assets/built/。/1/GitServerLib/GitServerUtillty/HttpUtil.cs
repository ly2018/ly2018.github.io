using GitServerModels.GitModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitServerUtillty
{

    public class HttpUtil
    {
        static Dictionary<string, CookieContainer> CookieDic = new Dictionary<string, CookieContainer>();

        public HttpUtil(string loginUrl, string name, string pwd, string code = "")
        {
            if (CookieDic == null || CookieDic.Count == 0)
            {
                GetCurrUserCookie(loginUrl, name, pwd, code);
            }
        }

        #region 获取当前用户Cookie
        public CookieContainer GetCurrUserCookie(string loginUrl, string name, string pwd, string code = "")
        {
            if (!CookieDic.Keys.Contains(name))
            {
                string loginData = "wicket:bookmarkablePage=:com.gitblit.wicket.pages.MyDashboardPage&id1_hf_0=&username={0}&password={1}";
                var cookie = GetCookie(string.Format(loginData, name, pwd), loginUrl);
                CookieDic.Add(name, cookie);
                return cookie;
            }
            else
            {
                return CookieDic[name];
            }
        }
        #endregion


        public string ExecuteRequest(string domain, string url, string userName, string postString, ref HttpStatusCode gitResultCode, DataType dataType = DataType.Json, RequstType requstType = RequstType.Post)
        {
            try
            {
                //postString 这里即为传递的参数，根据数据格式传递，可以用工具抓包分析，也可以自己分析，主要是form里面每一个name都要加进来

                WebClient webClient = new WebClient();
                if (!string.IsNullOrEmpty(domain))
                {
                    webClient.Headers.Add("Host", domain);
                }

                if (requstType == RequstType.Post)
                {
                    switch ((int)dataType)
                    {
                        case (int)DataType.Json:
                            {
                                webClient.Headers.Add("Content-Type", " application/json");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                            }
                            break;
                        case (int)DataType.JsonRpc:
                            {
                                webClient.Headers.Add("Content-Type", " application/json-rpc");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                            }
                            break;
                        case (int)DataType.XML:
                            {
                                webClient.Headers.Add("Content-Type", "application/xml");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                            }
                            break;
                        case (int)DataType.FormData:
                        default:
                            {
                                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                            }
                            break;
                    }
                }
                return GetContent(CookieDic[userName], url, postString, ref gitResultCode, dataType, requstType);

            }
            catch (Exception ex)
            {
                return DateTime.Now + ":失败！\n" + ex.ToString();
            }
        }


        #region Cookie操作
        public static CookieContainer GetCookie(string postString, string postUrl)
        {
            CookieContainer cookie = new CookieContainer();
            try
            {
                HttpWebRequest httpRequset = (HttpWebRequest)HttpWebRequest.Create(postUrl);//创建http 请求
                httpRequset.CookieContainer = cookie;//设置cookie
                httpRequset.Method = "POST";//POST 提交
                httpRequset.KeepAlive = true;
                httpRequset.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                httpRequset.Accept = "text/html, application/xhtml+xml, */*";
                httpRequset.ContentType = "application/x-www-form-urlencoded";//以上信息在监听请求的时候都有的直接复制过来
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postString);
                httpRequset.ContentLength = bytes.Length;
                Stream stream = httpRequset.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();//以上是POST数据的写入
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequset.GetResponse();//获得 服务端响应
                using (Stream responsestream = httpResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responsestream, System.Text.Encoding.UTF8))
                    {
                        string s = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return cookie;//拿到cookie
        }
        #endregion

        #region HttpGet&&HttpPost操作
        public static string GetContent(CookieContainer cookie, string url, string postString, ref HttpStatusCode gitResultCode, DataType dataType = DataType.Json, RequstType requstType = RequstType.Post)
        {
            string content = string.Empty;
            try
            {
                HttpWebRequest httpRequset = (HttpWebRequest)HttpWebRequest.Create(url);//创建http 请求
                httpRequset.CookieContainer = cookie;//设置cookie
                httpRequset.Method = requstType == RequstType.Post ? "POST" : "GET";//POST 提交
                httpRequset.KeepAlive = true;
                httpRequset.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                httpRequset.Accept = "text/html, application/xhtml+xml, */*";

                switch ((int)dataType)
                {
                    case (int)DataType.Json:
                        {
                            httpRequset.ContentType = "application/json";//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                        }
                        break;
                    case (int)DataType.JsonRpc:
                        {
                            httpRequset.ContentType = "application/json-rpc";//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                        }
                        break;
                    case (int)DataType.XML:
                        {
                            httpRequset.ContentType = "application/xml";//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                        }
                        break;
                    case (int)DataType.FormData:
                    default:
                        {
                            httpRequset.ContentType = "application/x-www-form-urlencoded";//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可                                                                             // int[] ss = new int[4] { 2000, 3000, 4000, 5000 };

                        }
                        break;
                }
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postString);
                httpRequset.ContentLength = bytes.Length;
                Stream stream = httpRequset.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();//以上是POST数据的写入


                HttpWebResponse httpResponse = (HttpWebResponse)httpRequset.GetResponse();

                using (Stream responsestream = httpResponse.GetResponseStream())
                {

                    using (StreamReader sr = new StreamReader(responsestream, System.Text.Encoding.UTF8))
                    {
                        content = sr.ReadToEnd();
                    }
                }
                gitResultCode = httpResponse.StatusCode;
            }
            catch (System.Net.WebException e)
            {
                gitResultCode = ((System.Net.HttpWebResponse)((System.Net.WebException)e).Response).StatusCode;
            }
            return content;
        }
        #endregion

    }
    /// <summary>
    /// 请求参数类型
    /// </summary>
    public enum DataType
    {
        Json = 1,
        XML = 2,
        FormData = 3,
        JsonRpc = 4
    }

    public enum RequstType
    {
        Post = 1,
        Get = 2
    }
}
