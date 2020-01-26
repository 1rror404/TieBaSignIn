using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TieBaManage.Class;

namespace TieBaManage.data
{
    /// <summary>
    /// SignIn 的摘要说明
    /// </summary>
    public class SignIn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bduss = Convert.ToString(HttpContext.Current.Request["bduss"]);
            //TieBaHelper.GetUserTieBa(bduss);
           // TieBaHelper.PCSignIn(bduss);
           // TieBaHelper.ClientSign("1701120", "三国杀", bduss); 
           // TieBaHelper.AddTieBa("116863", "BUG", bduss);
           //TieBaHelper.RemoveTieBa("35143","ABC",bduss);
            TieBaHelper.GetAllFans(bduss);



            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}