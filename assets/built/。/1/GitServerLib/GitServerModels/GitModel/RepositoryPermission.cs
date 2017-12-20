using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitServerModels.GitModel
{
    public class RepositoryPermission
    {
        /// <summary>
        /// 
        /// </summary>
        public string registrant { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string permission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string registrantType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string permissionType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool mutable { get; set; }
    }
}
