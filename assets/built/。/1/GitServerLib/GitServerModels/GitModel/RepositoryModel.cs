using System;
using System.Collections.Generic;
using System.Text;

namespace GitServerModels.GitModel
{
    public class EditCreateRepositoryModel
    {
        /// <summary>
        /// 开发盟友.git
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 开发盟友
        /// </summary>
        public string description { get; set; }
        public string owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lastChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool hasCommits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool showRemoteBranches { get; set; }

        public bool useTickets { get; set; }
        public bool useDocs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accessRestriction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool isFrozen { get; set; }

        public bool showReadme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string federationStrategy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> federationSets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool isFederated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool skipSizeCalculation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool skipSummaryMetrics { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string size { get; set; }
    }

    public class RepositoryModel : EditCreateRepositoryModel
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> owners { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string lastChangeAuthor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string useIncrementalPushTags { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string authorizationControl { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string allowAuthenticated { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string isBare { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string isMirror { get; set; }
        ///// <summary>
        ///// file:///x.git
        ///// </summary>
        //public string origin { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string HEAD { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> availableRefs { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> indexedBranches { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> preReceiveScripts { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> postReceiveScripts { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> mailingLists { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public CustomFields customFields { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string projectPath { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string allowForks { get; set; }
        ///// <summary>
        ///// 开发盟友.git
        ///// </summary>
        //public string originRepository { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string verifyCommitter { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string gcThreshold { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public int gcPeriod { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public int maxActivityCommits { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<string> metricAuthorExclusions { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string commitMessageRenderer { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string acceptNewPatchsets { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string acceptNewTickets { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string requireApproval { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string mergeTo { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string lastGC { get; set; }
    }

    public class CustomFields
    {
    }
}
