using System;
using GitServerModels;
using GitServerModels.ReqResModel;
using GitServerModels.GitModel;
using System.Collections;
using System.Collections.Generic;

namespace GitServerIService
{
    public interface IGitServerClientService
    {
        //基础操作
        //web.enableRpcServlet=true
        ResponseData<int> GET_PROTOCOL();//2 Integer
        ResponseData<Hashtable> LIST_REPOSITORIES();//1 Map<String, RepositoryModel>
        ResponseData<Hashtable> LIST_BRANCHES();//1 Map<String, List<String>>
        ResponseData<ServerSettings> LIST_SETTINGS();//	-	-	1	-	ServerSettings(basic keys)
        ResponseData<UserModel> GET_USER(string UserName);// user name	-	6	-	UserModel
        ResponseData<string> FORK_REPOSITORY(string repositoryName);//repository name	-	8	-	-

        //web.enableRpcManagement=true
        //仓储控制
        ResponseData<RepositoryModel> CREATE_REPOSITORY(string repositoryName, RepositoryModel postBody);// repository name admin	1	RepositoryModel	-
        ResponseData<RepositoryModel> EDIT_REPOSITORY(string repositoryName, RepositoryModel postBody);// repository name admin	1	RepositoryModel	-
        ResponseData<RepositoryModel> DELETE_REPOSITORY(string repositoryName, RepositoryModel postBody);// repository name admin	1	RepositoryModel	-
        //用户控制
        ResponseData<List<UserModel>> LIST_USERS();//	-	admin	1	-	List<UserModel>
        ResponseData<string> CREATE_USER(string userName, UserModel userModel);// user name   admin	1	UserModel	-
        ResponseData<string> EDIT_USER(string userName, UserModel userModel);// user name admin	1	UserModel	-
        ResponseData<string> DELETE_USER(string userName, UserModel userModel);//user name admin	1	UserModel	-
        //团队接口
        ResponseData<List<TeamModel>> LIST_TEAMS();//	-	admin	2	-	List<TeamModel>
        ResponseData<string> CREATE_TEAM(string teamName, TeamModel teamModel);//team name   admin	2	TeamModel	-
        ResponseData<string> EDIT_TEAM(string teamName, TeamModel teamModel);// team name admin	2	TeamModel	-
        ResponseData<string> DELETE_TEAM(string teamName, TeamModel teamModel);//team name admin	2	TeamModel	-

        //用户权限
        ResponseData<List<string>> LIST_REPOSITORY_MEMBERS(string repositoryName);// repository name admin	1	-	List<String>
        ResponseData<List<RepositoryPermission>> LIST_REPOSITORY_MEMBER_PERMISSIONS(string repositoryName);//repository name admin	5	-	List<String>
        ResponseData<string> SET_REPOSITORY_MEMBER_PERMISSIONS(string repositoryName, List<RepositoryPermission> permissions);//  repository name admin	5	List<String>	-
        //团队权限
        ResponseData<List<string>> LIST_REPOSITORY_TEAMS(string repositoryName);//repository name admin	2	-	List<String>
        ResponseData<List<RepositoryPermission>> LIST_REPOSITORY_TEAM_PERMISSIONS(string repositoryName);//repository name admin	5	-	List<String>
        ResponseData<string> SET_REPOSITORY_TEAM_PERMISSIONS(string repositoryName, List<RepositoryPermission> permissions);//repository name admin	5	List<String>	-

        //string LIST_SETTINGS = "";//-	admin	1	-	ServerSettings(management keys)
        //缓存清理
        ResponseData<string> CLEAR_REPOSITORY_CACHE();//-	-	4	-	-
        ResponseData<string> REINDEX_TICKETS(string repositoryName);//repository name	-	7	-	-


        //web.enableRpcAdministration=true
        /*string LIST_FEDERATION_REGISTRATIONS = "LIST_FEDERATION_REGISTRATIONS";///	-	admin	1	-	List<FederationModel>
        string LIST_FEDERATION_RESULTS = "LIST_FEDERATION_RESULTS";//	admin	1	-	List<FederationModel>
        string LIST_FEDERATION_PROPOSALS = "LIST_FEDERATION_PROPOSALS";//	-	admin	1	-	List<FederationProposal>
        string LIST_FEDERATION_SETS = "LIST_FEDERATION_SETS";//-	admin	1	-	List<FederationSet>
        //string LIST_SETTINGS = "";//	-	admin	1	-	ServerSettings(all keys)
        string EDIT_SETTINGS = "EDIT_SETTINGS";//	-	admin	1	Map<String, String>	-
        string LIST_STATUS = "LIST_STATUS";//-	admin	1	-	ServerStatus(see example below)
        */
    }
}
