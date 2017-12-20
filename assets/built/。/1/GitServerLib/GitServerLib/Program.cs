using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GitServerService;
using GitServerModels.GitModel;
using GitServerUtillty;

namespace GitServerLib
{
    class Program
    {
        //private static System.Timers.Timer _updateTimer;
        static void Main(string[] args)
        {
            Console.WriteLine(getASCIIArt());
            string menuStr = "测试案例导航菜单：";
            menuStr += "\r\n 1、创建仓库 \r\n 2、修改仓库 \r\n 3、删除仓库\n";
            menuStr += "\r\n 4、创建用户 \r\n 5、修改用户 \r\n 6、删除用户\n";
            menuStr += "\r\n 7、创建团队 \r\n 8、修改团队 \r\n 9、删除团队\n";
            menuStr += "\r\n 10、查询仓库用户列表 \r\n 11、查询仓库用户权限列表 \r\n 12、设置仓库用户权限\n";
            menuStr += "\r\n 13、查询仓库团队列表 \r\n 14、查询仓库团队权限列表 \r\n 15、设置仓库团队权限\n";
            menuStr += "\r\n 回车开始案例测试，输入esc退出：\n";
            Console.WriteLine(menuStr);
            GitServerClientService service = new GitServerClientService();
            while (Console.ReadLine() != "esc")
            {
                menuStr = "请输入数字选择测试案例，回车完成：";
                Console.WriteLine(menuStr);
                int s = 0;
                while (!int.TryParse(Console.ReadLine(), out s))
                {
                    Console.WriteLine("只允许输入数字，请重试！");
                }
                Console.WriteLine("=======================操作开始=======================================");
                switch (s)
                {
                    case 1:
                        {
                            Console.WriteLine("请输入仓库类别编号（1、LOCAL,2、admin）：");
                            string onwer = Console.ReadLine() == "1" ? "LOCAL" : "admin";
                            Console.WriteLine("请输入仓库名称：");
                            string name = Console.ReadLine();
                            CreateRepositories(service, name, onwer);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("请输入要修改的仓库名称，例如、开发盟友.git：");
                            string name = Console.ReadLine();
                            Console.WriteLine("请输入新的仓库名称，例如、新开发盟友.git：");
                            string newName = Console.ReadLine();
                            Console.WriteLine("确认要执行修改吗：y/n");
                            if (Console.ReadLine().ToLower() != "y")
                            {
                                break;
                            }
                            EditRepositories(service, name, newName);
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("请输入要删除的仓库名称：");
                            string name = Console.ReadLine();
                            Console.WriteLine("确认要删除，此操作不可恢复：y/n");
                            if (Console.ReadLine().ToLower() != "y")
                            {
                                break;
                            }
                            DeleteRepositories(service, name);
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("请输入账号信息英文*隔开(用户名*密码*邮箱)，例如、jake*test123*jake@hotmail.com：");
                            string name = Console.ReadLine();
                            if (string.IsNullOrEmpty(name) || !name.Contains("*") || name.Split('*').Length != 3)
                            {
                                Console.WriteLine("输入格式错误！");
                                break;
                            }
                            string[] arr = name.Split('*');
                            CreateUser(service, arr);
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("请输入账号用户名：");
                            string userName = Console.ReadLine();
                            Console.WriteLine("请输入修改后的账号信息英文*隔开(用户名*密码*邮箱)，例如、jake*test123*jake@hotmail.com：");
                            string name = Console.ReadLine();
                            if (string.IsNullOrEmpty(name) || !name.Contains("*") || name.Split('*').Length != 3)
                            {
                                Console.WriteLine("输入格式错误！");
                                break;
                            }
                            string[] arr = name.Split('*');
                            EditUser(service, userName, arr);
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("请输入要删除的账号用户名：");
                            string userName = Console.ReadLine();
                            Console.WriteLine("确认要删除，此操作不可恢复：y/n");
                            if (Console.ReadLine().ToLower() != "y")
                            {
                                break;
                            }
                            DeleteUser(service, userName);
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("请输入团队名称：");
                            string name = Console.ReadLine();
                            CreateTeam(service, name);
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("请输入团队名称和新团队名称以*隔开，例如：火星队*战神队");
                            string name = Console.ReadLine();
                            if (string.IsNullOrEmpty(name) || !name.Contains("*") || name.Split('*').Length != 2)
                            {
                                Console.WriteLine("输入格式错误！");
                                break;
                            }
                            string[] arr = name.Split('*');
                            EditTeam(service, arr[0], arr[1]);

                        }
                        break;
                    case 9:
                        {
                            Console.WriteLine("请输入要删除的团队名称：");
                            string userName = Console.ReadLine();
                            Console.WriteLine("确认要删除，此操作不可恢复：y/n");
                            if (Console.ReadLine().ToLower() != "y")
                            {
                                break;
                            }
                            DeleteTeam(service, userName);
                        }
                        break;
                    case 10:
                        {
                            Console.WriteLine("请输入要查询的仓库名称，例如、开发盟友.git：");
                            string name = Console.ReadLine();
                            if (!name.ToLower().EndsWith(".git"))
                            {
                                name += ".git";
                            }
                            var ret10 = service.LIST_REPOSITORY_MEMBERS(name);
                            GetErrorMsg(ret10.gitResultCode);
                            Console.WriteLine(ToJson(ret10));
                        }
                        break;
                    case 11:
                        {
                            Console.WriteLine("请输入要查询的仓库名称，例如、开发盟友.git：");
                            string name = Console.ReadLine();
                            if (!name.ToLower().EndsWith(".git"))
                            {
                                name += ".git";
                            }
                            var ret11 = service.LIST_REPOSITORY_MEMBER_PERMISSIONS(name);
                            GetErrorMsg(ret11.gitResultCode);
                            Console.WriteLine(ToJson(ret11));
                        }
                        break;
                    case 12:
                        {
                            Console.WriteLine("请输入要分配权限的仓库名称:");
                            string name = Console.ReadLine();
                            Console.WriteLine("请输入输入用户名称*隔开，例如、张三*李四*项目经理王五：");
                            string data = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                break;
                            }
                            var arr = data.Split('^').ToList();
                            if (!name.ToLower().EndsWith(".git"))
                            {
                                name += ".git";
                            }
                            List<RepositoryPermission> list = new List<RepositoryPermission>();
                            foreach (var item in arr)
                            {
                                list.Add(new RepositoryPermission()
                                {
                                    mutable = true,
                                    permission = AccessPermission.PUSH,
                                    permissionType = PermissionType.EXPLICIT.ToString(),
                                    registrant = item,
                                    registrantType
                                  = RegistrantType.USER.ToString()
                                });
                            }
                            var ret12 = service.SET_REPOSITORY_MEMBER_PERMISSIONS(name, list);
                            GetErrorMsg(ret12.gitResultCode);
                        }
                        break;
                    case 13:
                        {
                            Console.WriteLine("请输入要查询的团队名称：");
                            string name = Console.ReadLine();
                            var ret13 = service.LIST_REPOSITORY_TEAMS(name);
                            GetErrorMsg(ret13.gitResultCode);
                            Console.WriteLine(ToJson(ret13));
                        }
                        break;
                    case 14:
                        {
                            Console.WriteLine("请输入要查询的团队名称：");
                            string name = Console.ReadLine();
                            var ret14 = service.LIST_REPOSITORY_TEAM_PERMISSIONS(name);
                            GetErrorMsg(ret14.gitResultCode);
                            Console.WriteLine(ToJson(ret14));
                        }
                        break;
                    case 15:
                        {
                            Console.WriteLine("请输入要分配权限的仓库名称:");
                            string name = Console.ReadLine();
                            Console.WriteLine("请输入团队名称*隔开,例如、勇士队*骑士队*梦之队：");
                            string data = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(data))
                            {
                                break;
                            }
                            var arr = data.Split('^').ToList();
                            if (!name.ToLower().EndsWith(".git"))
                            {
                                name += ".git";
                            }
                            List<RepositoryPermission> list = new List<RepositoryPermission>();
                            foreach (var item in arr)
                            {
                                list.Add(new RepositoryPermission()
                                {
                                    mutable = true,
                                    permission = AccessPermission.NONE,
                                    permissionType = PermissionType.EXPLICIT.ToString(),
                                    registrant = item,
                                    registrantType
                                  = RegistrantType.TEAM.ToString()
                                });
                            }
                            var ret12 = service.SET_REPOSITORY_TEAM_PERMISSIONS(name, list);
                            GetErrorMsg(ret12.gitResultCode);
                        }
                        break;
                    case 20015:
                        {
                            int count = 0;
                            //列出分支
                            var data = service.LIST_BRANCHES();
                            //批量删除仓库LIST_REPOSITORIES
                            var deleteRepos = service.LIST_REPOSITORIES();
                            if (deleteRepos.Result != null)
                            {
                                foreach (var Key in deleteRepos.Result.Keys)
                                {
                                    string k = Key.ToString().Replace("/r/", "^").Split('^')[1];
                                    if (service.DELETE_REPOSITORY(k, new RepositoryModel()
                                    {
                                        name = k,

                                    }).IsSuccess)
                                    {
                                        count++;

                                    };
                                }
                            }

                            Console.WriteLine("累计删除仓库：" + count);
                            count = 0;
                            //批量删除用户
                            string[] uids = new string[] { "lt2", "lt3", "lt4", "lt9", "lt14", "federation", "liyang", "test", "wanghui2" };
                            for (int i = 0; i < uids.Length; i++)
                            {
                                string name = uids[i];
                                var user = service.GET_USER(name);
                                if (service.DELETE_USER(name, user.Result).IsSuccess)
                                {
                                    count++;
                                }
                            }
                            Console.WriteLine("累计删除用户：" + count);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("您输入的案例不存在或者正在开发中！");
                        }
                        break;
                }
                Console.WriteLine("=======================操作结束,回车继续,输入esc回车结束===============");
            }
            return;



            //获取用户信息
            var getUserRet = service.GET_USER("lt49");
            GetErrorMsg(getUserRet.gitResultCode);

            //列出所有团队
            var retLIST_TEAMS = service.LIST_TEAMS();
            GetErrorMsg(retLIST_TEAMS.gitResultCode);




            //_updateTimer = new System.Timers.Timer(sleep);
            //_updateTimer.Elapsed += _updateTimer_Elapsed;
            //_updateTimer.Enabled = true;

            Console.Write("服务正在运行。。。。，按任意键结束");
            Console.ReadLine();
            Console.WriteLine("服务结束");
            //_updateTimer.Enabled = false;
        }
        /// <summary>
        /// 创建团队
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name"></param>
        private static void CreateTeam(GitServerClientService service, string name)
        {
            var createTeam = service.CREATE_TEAM(name, new TeamModel()
            {
                name = name,
                accountType = AccountType.LOCAL.ToString(),
                canAdmin = false,
                canCreate = false,
                canFork = false,
            });
            GetErrorMsg(createTeam.gitResultCode);
        }
        /// <summary>
        /// 删除团队
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name"></param>
        private static void DeleteTeam(GitServerClientService service, string name)
        {
            var createTeam = service.DELETE_TEAM(name, new TeamModel()
            {
                name = name
            });
            GetErrorMsg(createTeam.gitResultCode);
        }
        /// <summary>
        /// 修改团队
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name"></param>
        /// <param name="newName"></param>
        private static void EditTeam(GitServerClientService service, string name, string newName)
        {
            var createTeam = service.EDIT_TEAM(name, new TeamModel()
            {
                name = newName,
                accountType = AccountType.LOCAL.ToString(),
                canAdmin = false,
                canCreate = false,
                canFork = false,
            });
            GetErrorMsg(createTeam.gitResultCode);
        }

        private static void CreateUser(GitServerClientService service, string[] arr)
        {
            //新建用户
            var createUserRet = service.CREATE_USER(arr[0], new UserModel()
            {
                username = arr[0],
                accountType = "",
                canAdmin = false,
                canCreate = false,
                emailAddress = arr[2],
                canFork = false,
                password = "MD5:" + CryptoUtil.Md5(arr[1]),
                isAuthenticated = false,
                disabled = false,
                excludeFromFederation = true,

            });
            GetErrorMsg(createUserRet.gitResultCode);
        }

        private static void DeleteUser(GitServerClientService service, string userName)
        {
            //删除用户
            var createUserRet = service.DELETE_USER(userName, new UserModel()
            {
                username = userName
            });
            GetErrorMsg(createUserRet.gitResultCode);
        }

        private static void EditUser(GitServerClientService service, string oldName, string[] arr)
        {
            //修改用户
            var editUserRet = service.EDIT_USER(oldName, new UserModel()
            {
                username = arr[0],
                accountType = "",
                canAdmin = false,
                canCreate = false,
                emailAddress = arr[2],
                canFork = false,
                password = "MD5:" + CryptoUtil.Md5(arr[1]),
                isAuthenticated = false,
                disabled = false,
                excludeFromFederation = true,

            });
            GetErrorMsg(editUserRet.gitResultCode);
        }

        private static void DeleteRepositories(GitServerClientService service, string name)
        {
            if (!name.ToLower().EndsWith(".git"))
            {
                name += ".git";
            }
            //删除仓储
            var deleteRet = service.DELETE_REPOSITORY(name, new GitServerModels.GitModel.RepositoryModel()
            {
                name = name
            });
            GetErrorMsg(deleteRet.gitResultCode);
        }

        private static void EditRepositories(GitServerClientService service, string name, string newName)
        {
            if (!name.ToLower().EndsWith(".git"))
            {
                name += ".git";
            }
            if (!newName.ToLower().EndsWith(".git"))
            {
                newName += ".git";
            }
            //编辑
            var editRet = service.EDIT_REPOSITORY(name, new GitServerModels.GitModel.RepositoryModel()
            {
                name = newName,
                description = name,
                owner = "admin",
                lastChange = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                hasCommits = true,
                showRemoteBranches = false,
                useTickets = false,
                useDocs = false,
                accessRestriction = AccessRestrictionType.VIEW.ToString(),
                isFrozen = false,
                showReadme = false,
                federationStrategy = FederationStrategy.FEDERATE_THIS.ToString(),
                federationSets = new List<string>() { "libraries" },

                isFederated = false,
                skipSizeCalculation = false,
                skipSummaryMetrics = false,
                size = "102 KB"
            });
            GetErrorMsg(editRet.gitResultCode);
        }

        private static void CreateRepositories(GitServerClientService service, string name, string onwer)
        {
            if (!name.ToLower().EndsWith(".git"))
            {
                name += ".git";
            }
            ////创建仓储
            var createRet = service.CREATE_REPOSITORY(name, new GitServerModels.GitModel.RepositoryModel()
            {
                name = name,
                description = name,
                owner = string.IsNullOrEmpty(onwer) ? "admin" : onwer,
                lastChange = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                hasCommits = true,
                showRemoteBranches = false,
                useTickets = false,
                useDocs = false,
                accessRestriction = AccessRestrictionType.VIEW.ToString(),
                isFrozen = false,
                showReadme = false,
                federationStrategy = FederationStrategy.FEDERATE_THIS.ToString(),
                federationSets = new List<string>() { "libraries" },

                isFederated = false,
                skipSizeCalculation = false,
                skipSummaryMetrics = false,
                size = "102 KB"
            });
            GetErrorMsg(createRet.gitResultCode);
        }

        private static void GetErrorMsg(HttpStatusCode gitResultCode)
        {
            string msg = string.Empty;
            switch ((int)gitResultCode)
            {
                case (int)GitResultCode.failed:
                    {
                        msg = "Gitblit processed the request failed";
                    }
                    break;
                case (int)GitResultCode.success:
                    {
                        msg = "Gitblit processed the request successfully";
                    }
                    break;
                case (int)GitResultCode.forbidden:
                    {
                        msg = "Gitblit requires user credentials to process the request";
                    }
                    break;
                case (int)GitResultCode.unauthorized:
                    {
                        msg = "Gitblit can not process the request for the supplied credentials";
                    }
                    break;
                case (int)GitResultCode.unknownRequest:
                    {
                        msg = "Gitblit does not recognize the RPC request type";
                    }
                    break;
                case (int)GitResultCode.methodNotAllowed:
                    {
                        msg = "Gitblit has disallowed the processing the specified request";
                    }
                    break;
                case (int)GitResultCode.serverError:
                    {
                        msg = "Gitblit failed to process the request likely because the input object created a conflict";
                    }
                    break;
                default:
                    {
                        msg = "Other HttpStatusMsg";
                    }
                    break;
            }

            Console.WriteLine(string.Format("\r\nExecute StatusCode：{0}，Msg：{1}", (int)gitResultCode, msg));
        }

        public static string ToJson(object data)
        {
            return "\r\n返回数据：" + Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static string getASCIIArt()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  _____  _  _    _      _  _  _").Append('\n');
            sb.Append(" |  __ \\(_)| |  | |    | |(_)| |").Append('\n');
            sb.Append(" | |  \\/ _ | |_ | |__  | | _ | |_").Append('\n');
            sb.Append(" | | __ | || __|| '_ \\ | || || __|").Append("  ").Append("http://gitblit.com").Append('\n');
            sb.Append(" | |_\\ \\| || |_ | |_) || || || |_").Append("   ").Append("@gitblit").Append('\n');
            sb.Append("  \\____/|_| \\__||_.__/ |_||_| \\__|").Append("  ").Append("1.8.0 (2016-06-22)").Append('\n');
            return sb.ToString();
        }

        private static void _updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //_updateTimer.Enabled = false;
            try
            {
                //_handlerDataService = new HandlerDataService();
                //_handlerDataService.Run();
            }
            catch (Exception ex)
            {

            }
            //_updateTimer.Enabled = true;


        }
    }


}
