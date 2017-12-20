using GitServerModels.GitModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GitServerModels.ReqResModel
{
    public class ResponseData<T>
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Result { get; set; }
        /// <summary>
        /// 是否标志成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Git请求状态码
        /// </summary>
        public HttpStatusCode gitResultCode { get; set; }
    }
}
