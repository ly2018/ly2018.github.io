using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitServerModels.GitModel
{
    public class GitConstants
    {
        public const string NAME = "Gitblit";

        public const string FULL_NAME = "Gitblit - a pure Java Git solution";

        public const string ADMIN_ROLE = "#admin";

        public const string FORK_ROLE = "#fork";

        public const string CREATE_ROLE = "#create";

        public const string NOT_FEDERATED_ROLE = "#notfederated";

        public const string NO_ROLE = "#none";

        public const string EXTERNAL_ACCOUNT = "#externalAccount";

        public const string PROPERTIES_FILE = "gitblit.properties";

        public const string DEFAULT_USER_REPOSITORY_PREFIX = "~";

        public const string R_PATH = "/r/";

        public const string GIT_PATH = "/git/";

        public const string REGEX_SHA256 = "[a-fA-F0-9]{64}";

        /**
         * This regular expression is used when searching for "mentions" in tickets
         * (when someone writes @thisOtherUser)
         */
        public const string REGEX_TICKET_MENTION = "\\B@(?<user>[^\\s]+)\\b";

        public const string ZIP_PATH = "/zip/";

        public const string SYNDICATION_PATH = "/feed/";

        public const string FEDERATION_PATH = "/federation/";

        public const string RPC_PATH = "/rpc/";

        public const string PAGES = "/pages/";

        public const string SPARKLESHARE_INVITE_PATH = "/sparkleshare/";

        public const string RAW_PATH = "/raw/";

        public const string PT_PATH = "/pt";

        public const string BRANCH_GRAPH_PATH = "/graph/";

        public const string BORDER = "*****************************************************************";

        public const string BORDER2 = "#################################################################";

        public const string FEDERATION_USER = "$gitblit";

        public const string PROPOSAL_EXT = ".json";

        public const string ENCODING = "UTF-8";

        public const int LEN_SHORTLOG = 78;

        public const int LEN_SHORTLOG_REFS = 60;

        public const int LEN_FILESTORE_META_MIN = 125;

        public const int LEN_FILESTORE_META_MAX = 146;

        public const string DEFAULT_BRANCH = "default";

        public const string CONFIG_GITBLIT = "gitblit";

        public const string CONFIG_CUSTOM_FIELDS = "customFields";

        public const string ISO8601 = "yyyy-MM-dd'T'HH:mm:ssZ";

        public const string baseFolder = "baseFolder";



        public const string HEAD = "HEAD";

        public const string R_META = "refs/meta/";

        public const string R_HEADS = "refs/heads/";

        public const string R_NOTES = "refs/notes/";

        public const string R_CHANGES = "refs/changes/";

        public const string R_PULL = "refs/pull/";

        public const string R_TAGS = "refs/tags/";

        public const string R_REMOTES = "refs/remotes/";

        public const string R_FOR = "refs/for/";

        public const string R_TICKET = "refs/heads/ticket/";

        public const string R_TICKETS_PATCHSETS = "refs/tickets/";

        public const string R_MASTER = "refs/heads/master";

        public const string MASTER = "master";

        public const string R_DEVELOP = "refs/heads/develop";

        public const string DEVELOP = "develop";

        public static string ATTRIB_AUTHTYPE = NAME + ":authentication-type";

        public static string ATTRIB_AUTHUSER = NAME + ":authenticated-user";

        public const string R_LFS = "info/lfs/";


        public bool isValidPermission(string accessPermission)
        {
            switch (accessPermission)
            {
                case AccessPermission.VIEW:
                    // VIEW restriction
                    // all access permissions are valid
                    return true;
                case AccessPermission.CLONE:
                    // CLONE restriction
                    // only CLONE or greater access permissions are valid
                    return true;// permission.atLeast(AccessPermission.CLONE);
                case AccessPermission.PUSH:
                    // PUSH restriction
                    // only PUSH or greater access permissions are valid
                    return true;//permission.atLeast(AccessPermission.PUSH);
                case AccessPermission.NONE:
                    // NO access restriction
                    // all access permissions are invalid
                    return false;
            }
            return false;
        }
    }

    public enum Role
    {
        NONE, ADMIN, CREATE, FORK, NOT_FEDERATED
    }


    /**
     * 没有，推，克隆，查看
     * Enumeration representing the four access restriction levels.
     */
    public enum AccessRestrictionType
    {
        NONE, PUSH, CLONE, VIEW

    }
    /**
     * 认证，命名
     * Enumeration representing the types of authorization control for an
     * access restricted resource.
     */
    public enum AuthorizationControl
    {
        AUTHENTICATED, NAMED
    }


    /**
     * Enumeration representing the types of federation tokens.
     */
    public enum FederationToken
    {
        ALL, USERS_AND_REPOSITORIES, REPOSITORIES
    }

    /**
     * Enumeration representing the types of federation requests.
     */
    public enum FederationRequest
    {
        POKE, PROPOSAL, PULL_REPOSITORIES, PULL_USERS, PULL_TEAMS, PULL_SETTINGS, PULL_SCRIPTS, STATUS
    }

    /**
     * Enumeration representing the statii of federation requests.
     */
    public enum FederationPullStatus
    {
        PENDING, FAILED, SKIPPED, PULLED, MIRRORED, NOCHANGE, EXCLUDED
    }

    /**
     * Enumeration representing the federation types.
     */
    public enum FederationStrategy
    {
        EXCLUDE, FEDERATE_THIS, FEDERATE_ORIGIN
    }

    /**
     * Enumeration representing the possible results of federation proposal
     * requests.
     */
    public enum FederationProposalResult
    {
        ERROR, FEDERATION_DISABLED, MISSING_DATA, NO_PROPOSALS, NO_POKE, ACCEPTED

    }

    /**
     * Enumeration representing the possible remote procedure call requests from
     * a client.
     */
    public enum RpcRequest
    {
        // Order is important here.  anything after LIST_SETTINGS requires
        // administrator privileges and web.allowRpcManagement.
        CLEAR_REPOSITORY_CACHE, REINDEX_TICKETS, GET_PROTOCOL, LIST_REPOSITORIES, LIST_BRANCHES, GET_USER,
        FORK_REPOSITORY, LIST_SETTINGS,
        CREATE_REPOSITORY, EDIT_REPOSITORY, DELETE_REPOSITORY,
        LIST_USERS, CREATE_USER, EDIT_USER, DELETE_USER,
        LIST_TEAMS, CREATE_TEAM, EDIT_TEAM, DELETE_TEAM,
        LIST_REPOSITORY_MEMBERS, SET_REPOSITORY_MEMBERS, LIST_REPOSITORY_TEAMS, SET_REPOSITORY_TEAMS,
        LIST_REPOSITORY_MEMBER_PERMISSIONS, SET_REPOSITORY_MEMBER_PERMISSIONS, LIST_REPOSITORY_TEAM_PERMISSIONS, SET_REPOSITORY_TEAM_PERMISSIONS,
        LIST_FEDERATION_REGISTRATIONS, LIST_FEDERATION_RESULTS, LIST_FEDERATION_PROPOSALS, LIST_FEDERATION_SETS,
        EDIT_SETTINGS, LIST_STATUS
    }

    /**
     * Enumeration of the search types.
     */
    public enum SearchType
    {
        AUTHOR, COMMITTER, COMMIT
    }

    /**
     * Enumeration of the feed content object types.
     */
    public enum FeedObjectType
    {
        COMMIT, TAG
    }


    public enum RegistrantType
    {
        REPOSITORY, USER, TEAM
    }

    //失踪的，匿名的，明确的，团队，正则表达式，所有者，管理员
    public enum PermissionType
    {
        MISSING, ANONYMOUS, EXPLICIT, TEAM, REGEX, OWNER, ADMINISTRATOR
    }



    public enum AuthenticationType
    {
        PUBLIC_KEY, CREDENTIALS, COOKIE, CERTIFICATE, CONTAINER, HTTPHEADER
    }


    public enum AccountType
    {
        LOCAL, CONTAINER, LDAP, REDMINE, SALESFORCE, WINDOWS, PAM, HTPASSWD, HTTPHEADER
    }

    public enum CommitMessageRenderer
    {
        PLAIN, MARKDOWN

    }



    public enum Transport
    {
        // ordered for url advertisements, assuming equal access permissions
        SSH, HTTPS, HTTP, GIT
    }



    /**
     * The type of merge Gitblit will use when merging a ticket to the integration branch.
     * <p>
     * The default type is MERGE_ALWAYS.
     * <p>
     * This is modeled after the Gerrit SubmitType.
     */
    public enum MergeType
    {
        /** Allows a merge only if it can be fast-forward merged into the integration branch. */
        FAST_FORWARD_ONLY,
        /** Uses a fast-forward merge if possible, other wise a merge commit is created. */
        MERGE_IF_NECESSARY,
        // Future REBASE_IF_NECESSARY,
        /** Always merge with a merge commit, even when a fast-forward would be possible. */
        MERGE_ALWAYS,
        // Future?
        CHERRY_PICK
    }


    /**
     * <option value="1">X (排除)</option>
<option value="2">V (浏览)</option>
<option selected="selected" value="3">R (克隆)</option>
<option value="4">RW (推送)</option>
<option value="5">RWC (推送, 创建ref)</option>
<option value="6">RWD (推送, 创建删除ref)</option>
<option value="7">RW+ (推送, 创建删除以及rewind ref)</option>
     * The access permissions available for a repository.
     */
    public class AccessPermission
    {
        /// <summary>
        /// 删除权限
        /// </summary>
        public const string NONE = ("N");
        /// <summary>
        /// 排除
        /// </summary>
        public const string EXCLUDE = ("X");
        /// <summary>
        /// 浏览
        /// </summary>
        public const string VIEW = ("V");
        /// <summary>
        /// 克隆
        /// </summary>
        public const string CLONE = ("R");
        /// <summary>
        /// 推送
        /// </summary>
        public const string PUSH = ("RW");
        /// <summary>
        /// 推送, 创建ref
        /// </summary>
        public const string CREATE = ("RWC");
        /// <summary>
        /// 推送, 创建删除ref
        /// </summary>
        public const string DELETE = ("RWD");
        /// <summary>
        /// 推送, 创建删除以及rewind ref
        /// </summary>
        public const string REWIND = ("RW+");
        /// <summary>
        /// 推送, 创建删除以及rewind ref
        /// </summary>
        public const string OWNER = ("RW+");
    };

}
