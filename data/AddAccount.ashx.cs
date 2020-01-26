using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TieBaManage.Class;
using TieBaManage.Model;

namespace TieBaManage.data
{
    /// <summary>
    /// AddAccount 的摘要说明
    /// </summary>
    public class AddAccount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bduss = Convert.ToString(HttpContext.Current.Request["bduss"]);
            string username = TieBaHelper.GetUserInfo(bduss);
            //string sql = "insert into SignInStatus values('{0}','{1}','未签到')";
            //sql = string.Format(sql,username,bduss);
            //DBHelper.Update(sql);

            //  MyTieBa mytieba = new MyTieBa();
            List<MyTieBa> myList = new List<MyTieBa>();
            myList = TieBaHelper.GetUserTieBa(bduss);

            for (int i = 0; i < myList.Count; i++)
            {
                string sql = "insert into UserTieBa values('" + username + "','" + myList[i].TBName + "','" + myList[i].TBLV + "','" + myList[i].TBEXP + "','未知')";
                DBHelper.Update(sql);
            }
            context.Response.Write("success");
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