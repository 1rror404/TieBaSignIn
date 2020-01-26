using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;


namespace TieBaManage.data
{
    /// <summary>
    /// UserTieba 的摘要说明
    /// </summary>
    public class UserTieba : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int pag = Convert.ToInt32(HttpContext.Current.Request["page"]);
            int limt = Convert.ToInt32(HttpContext.Current.Request["limit"]);
            string sql = "select top {0} * from UserTieba where ID not in(select top {1} ID from UserTieba ) ";
            sql = string.Format(sql, limt, (pag - 1) * limt);
            DataTable dt = new DataTable();
            dt = DBHelper.Select(sql);
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