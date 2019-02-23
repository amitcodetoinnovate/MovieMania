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
        
        private string connectionToDb = ConfigurationManager.ConnectionStrings["AmitMovie"].ConnectionString;

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
                        return;
                    case 2:
                        resJObj = GetProducersList(context);
                        context.Response.Write(resJObj);
                        return;
                    case 3:
                        resJObj = InsertActorProducer(context);
                        context.Response.Write(resJObj);
                        return;
                    case 4:
                        resJObj = ManageMovie(context);
                        context.Response.Write(resJObj);
                        return;
                    case 5:
                        resJObj = GetMovies(context);
                        context.Response.Write(resJObj);
                        return;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        private JObject GetMovies(HttpContext context)
        {
            JObject responseJObj = new JObject();
            try
            {

                Bussiness bussiness = new Bussiness();
                responseJObj = bussiness.GetMovies();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return responseJObj;
        }

        private JObject ManageMovie(HttpContext context)
        {
            JObject responseJObj = new JObject();
            try
            {
                Bussiness bussiness = new Bussiness();             
                responseJObj = bussiness.ManageMovie(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return responseJObj;
        }

        private JObject InsertActorProducer(HttpContext context)
        {
            JObject responseJObj = new JObject();
            try
            {
                int actProFlag = Convert.ToInt32(context.Request["actProFlag"]);
                String name = context.Request["name"];
                String bioGraphy = context.Request["bioGraphy"];
                String dateOfBirth = context.Request["dateOfBirth"];
                int sex = Convert.ToInt32(context.Request["sex"]);
                Bussiness bussiness = new Bussiness();
                responseJObj = bussiness.InsertActorProducer(actProFlag, name, bioGraphy, dateOfBirth, sex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return responseJObj;
        }

        private JObject GetProducersList(HttpContext context)
        {
            JObject responseJObj = new JObject();
            try
            {
                
                Bussiness bussiness = new Bussiness();
                responseJObj = bussiness.GetProducersList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return responseJObj;
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