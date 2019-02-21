using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ManiaUI
{
    internal class Bussiness
    {
        protected static readonly string  connection = ConfigurationManager.ConnectionStrings["AmitMovie"].ConnectionString;
        private Utility utility = null;
        internal JObject GetActorsList()
        {
            utility = new Utility();
            try
            {
                DataAccess dataAccess = new DataAccess(connection);
                DataSet ds = dataAccess.GetActorsList();
                if (ds == null)
                {
                    utility.CreateProperty("Success", "No data returned from database");
                    utility.CreateProperty("Message", false);
                }
                else
                {
                    utility.ParseDataSet(ds);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception In Actors " + ex.ToString());
            }
            return utility.GetResponse();
        }
        internal Bussiness()
        {
            utility = new Utility();
            utility.ResponseFormat = "json";
            utility.InitializeResponseVariables();
        }

        internal JObject GetProducersList()
        {
            utility = new Utility();
            try
            {
                DataAccess dataAccess = new DataAccess(connection);
                DataSet ds = dataAccess.GetProducersList();
                if (ds == null)
                {
                    utility.CreateProperty("Success", "No data returned from database");
                    utility.CreateProperty("Message", false);
                }
                else
                {
                    utility.ParseDataSet(ds);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception In Actors " + ex.ToString());
            }
            return utility.GetResponse();
        }

        internal JObject InsertActorProducer(int actProFlag, string name, string bioGraphy, string dateOfBirth, int sex)
        {
            utility = new Utility();
            try
            {
                DataAccess dataAccess = new DataAccess(connection);
                DataSet ds = dataAccess.InsertActorProducer(actProFlag, name, bioGraphy, dateOfBirth, sex);
                if (ds == null)
                {
                    utility.CreateProperty("Success", "No data returned from database");
                    utility.CreateProperty("Message", false);
                }
                else
                {
                    utility.ParseDataSet(ds);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception In Actors " + ex.ToString());
            }
            return utility.GetResponse();
        }

        
    }
}