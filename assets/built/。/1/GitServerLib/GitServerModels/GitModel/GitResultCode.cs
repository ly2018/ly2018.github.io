using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitServerModels.GitModel
{
    /// <summary>
    /// Git 请求返回状态枚举
    /// </summary>
    public enum GitResultCode
    {
        failed = 417,//   Gitblit processed the request failed
        success = 200,//   Gitblit processed the request successfully
        unauthorized = 401,   //    Gitblit requires user credentials to process the request
        forbidden = 403,//     Gitblit can not process the request for the supplied credentials
        methodNotAllowed=405,//Gitblit has disallowed the processing the specified request
        serverError = 500,//    Gitblit failed to process the request likely because the input object created a conflict
        unknownRequest = 501,// Gitblit does not recognize the RPC request type
    }
}
