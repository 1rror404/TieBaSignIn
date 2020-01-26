using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;

namespace TieBaManage.api
{
    /// <summary>
    /// SignInStatus 的摘要说明
    /// </summary>
    public class SignInStatus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pag = Convert.ToInt32(HttpContext.Current.Request["page"]);
            int limt = Convert.ToInt32(HttpContext.Current.Request["limit"]);
            string sql = "select top {0} * from SignInStatus where ID not in(select top {1} ID from SignInStatus )";
            sql = string.Format(sql, limt, (pag - 1) * limt);
            DataTable dt = new DataTable();
            dt = DBHelper.Select(sql);
            //JObject jobj = JObject.Parse(JsonConvert.SerializeObject(dt));
            string a = JsonConvert.SerializeObject(dt);
            context.Response.Write(a);

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