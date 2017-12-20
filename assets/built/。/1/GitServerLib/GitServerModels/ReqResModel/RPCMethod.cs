using System;
using System.Collections.Generic;
using System.Text;

namespace GitServerModels.ReqResModel
{
    /// <summary>
    /// RPC基础方法
    /// </summary>
    public class RPCMethod
    {
        //web.enableRpcServlet=true
        public static string GET_PROTOCOL = "GET_PROTOCOL";//	-	-	2	-	Integer
        public static string LIST_REPOSITORIES = "LIST_REPOSITORIES";//	-	-	1	-	Map<String, RepositoryModel>
        public static string LIST_BRANCHES = "LIST_BRANCHES";//	-	-	1	-	Map<String, List<String>>
        public static string LIST_SETTINGS = "LIST_SETTINGS";//	-	-	1	-	ServerSettings(basic keys)
        public static string GET_USER = "GET_USER";// user name	-	6	-	UserModel
        public static string FORK_REPOSITORY = "FORK_REPOSITORY";//repository name	-	8	-	-
       
        //web.enableRpcManagement=true
        public static string CREATE_REPOSITORY = "CREATE_REPOSITORY";// repository name admin	1	RepositoryModel	-
        public static string EDIT_REPOSITORY = "EDIT_REPOSITORY";// repository name admin	1	RepositoryModel	-
        public static string DELETE_REPOSITORY = "DELETE_REPOSITORY";// repository name admin	1	RepositoryModel	-
        public static string LIST_USERS = "LIST_USERS";//	-	admin	1	-	List<UserModel>
        public static string CREATE_USER = "CREATE_USER";// user name   admin	1	UserModel	-
        public static string EDIT_USER = "EDIT_USER";// user name admin	1	UserModel	-
        public static string DELETE_USER = "DELETE_USER";//user name admin	1	UserModel	-
        public static string LIST_TEAMS = "LIST_TEAMS";//	-	admin	2	-	List<TeamModel>
        public static string CREATE_TEAM = "CREATE_TEAM";//team name   admin	2	TeamModel	-
        public static string EDIT_TEAM = "EDIT_TEAM";// team name admin	2	TeamModel	-
        public static string DELETE_TEAM = "DELETE_TEAM";//team name admin	2	TeamModel	-
        public static string LIST_REPOSITORY_MEMBERS = "LIST_REPOSITORY_MEMBERS";// repository name admin	1	-	List<String>
        public static string SET_REPOSITORY_MEMBERS = "SET_REPOSITORY_MEMBERS";//  repository name admin	1	List<String>	-
        public static string LIST_REPOSITORY_MEMBER_PERMISSIONS = "LIST_REPOSITORY_MEMBER_PERMISSIONS";//repository name admin	5	-	List<String>
        public static string SET_REPOSITORY_MEMBER_PERMISSIONS = "SET_REPOSITORY_MEMBER_PERMISSIONS";//  repository name admin	5	List<String>	-
        public static string LIST_REPOSITORY_TEAMS = "LIST_REPOSITORY_TEAMS";//repository name admin	2	-	List<String>
        public static string SET_REPOSITORY_TEAMS = "SET_REPOSITORY_TEAMS";///repository name admin	2	List<String>	-
        public static string LIST_REPOSITORY_TEAM_PERMISSIONS = "LIST_REPOSITORY_TEAM_PERMISSIONS";//repository name admin	5	-	List<String>
        public static string SET_REPOSITORY_TEAM_PERMISSIONS = "SET_REPOSITORY_TEAM_PERMISSIONS";//repository name admin	5	List<String>	-
        //public static string LIST_SETTINGS = "";//-	admin	1	-	ServerSettings(management keys)
        public static string CLEAR_REPOSITORY_CACHE = "CLEAR_REPOSITORY_CACHE";//-	-	4	-	-
        public static string REINDEX_TICKETS = "REINDEX_TICKETS";//repository name	-	7	-	-
        

        //web.enableRpcAdministration=true
        public static string LIST_FEDERATION_REGISTRATIONS = "LIST_FEDERATION_REGISTRATIONS";///	-	admin	1	-	List<FederationModel>
        public static string LIST_FEDERATION_RESULTS = "LIST_FEDERATION_RESULTS";//	admin	1	-	List<FederationModel>
        public static string LIST_FEDERATION_PROPOSALS = "LIST_FEDERATION_PROPOSALS";//	-	admin	1	-	List<FederationProposal>
        public static string LIST_FEDERATION_SETS = "LIST_FEDERATION_SETS";//-	admin	1	-	List<FederationSet>
        //public static string LIST_SETTINGS = "";//	-	admin	1	-	ServerSettings(all keys)
        public static string EDIT_SETTINGS = "EDIT_SETTINGS";//	-	admin	1	Map<String, String>	-
        public static string LIST_STATUS = "LIST_STATUS";//-	admin	1	-	ServerStatus(see example below)
    }
}
