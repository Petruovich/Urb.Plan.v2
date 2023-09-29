using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Urb.Plan.v2
{
    public class Project_Manhattan
    {
        public class UserControllere
        {
            public int Mnty(int r)
            {
                return r;
            }

        }
        public class Rtyu
        {
            public static int REav()
            {

                UserControllere userControllers = new UserControllere();

                Func<int, int> Myex = r => r + 1;

                int Result = userControllers.Mnty(Myex(1));

                return Result;

            }

            public class Nrte
            {
                public List<int> Erett()
                {
                    List<int> list = new List<int> { 1, 2, 3, 4 };

                    list.Sort((x, y) => x.CompareTo(y));

                    return list;

                }
            }

            //public class Oneq
            //{
            //   public int fty { get;  }
            //    public  int Onew()
            //    {

            //        var r = 1;
            //        var e = 2;
            //        int t = r + e;
            //        return t;
            //    }
            //}
            //public class Onerj
            //{
            //    public void Onet(Oneq onert)
            //    {
            //        onert.fty = 1;                    
            //    }
            //}
            //public class ERdsj
            //{
            //    public string Rvdjs()
            //    {
            //        var config = new ConfigurationBuilder()
            //        .AddJsonFile("appsettings.json") 
            //        .Build();
            //        var appSettings = new AppSettings();
                    
            //       return config.GetSection("JWTAuth").Bind(appSettings.JWTAuth);
                    
            //    }
            //}
        }
    }
}
