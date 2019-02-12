using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManiaUI
{
    /// <summary>
    /// Summary description for MovieHandler
    /// </summary>
    public class MovieHandler : IHttpHandler
    {
        SqlCommand _cmd;
        SqlDataAdapter _da;
        DataSet _ds;
        private Utility utility = null;
        private static string connectionToDb = ConfigurationManager.ConnectionStrings["MovieManiaDb"].ConnectionString;

        public void ProcessRequest(HttpContext context)
        {
            try
            {


                int type = Convert.ToInt32(context.Request["type"]);


                JObject resJObj = new JObject();
                switch (type)
                {
                    case 1:
                        resJObj = GetActorsList(context);
                        context.Response.Write(resJObj);
                        break;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        private JObject GetActorsList(HttpContext context)
        {
            JObject responseJObj = new JObject();
            try
            {
                Bussiness bussiness = new Bussiness();
                responseJObj = bussiness.GetActorsList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return responseJObj;
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