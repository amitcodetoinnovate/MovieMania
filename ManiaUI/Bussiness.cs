using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ManiaUI
{
    internal class Bussiness
    {
        private static readonly string connection = ConfigurationManager.ConnectionStrings["AmitMovie"].ConnectionString;
        private Utility utility = null;
        internal JObject GetActorsList()
        {

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

        internal JObject GetMovies()
        {

            try
            {
                DataAccess dataAccess = new DataAccess(connection);
                DataSet ds = dataAccess.GetMovies();
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

        internal JObject ManageMovie(HttpContext context)
        {

            try
            {
                DataAccess dataAccess = new DataAccess(connection);
                String movieName = context.Request["movieName"];
                int yearRelease = Convert.ToInt32(context.Request["yearRelease"]);
                String textPlot = context.Request["textPlot"];
                String actorList = context.Request["actorList"].ToString();
                int movieId = Convert.ToInt32(context.Request["movieId"]);
                DataTable actorMovieTable = CreateUserDefinedTable(actorList, movieId);
                String producerId = context.Request["producerId"];
                Boolean isUpdate = Convert.ToBoolean(context.Request["isUpdate"]);
                HttpPostedFile postedFile = context.Request.Files["file"];
                JObject responseJObj = new JObject();
                string posterStoragePath = "";
                string filePath = "";
                context.Response.ContentType = "multipart/form-data";
                context.Response.Expires = -1;
                if (postedFile != null)
                {
                    string storagePath = HttpContext.Current.Server.MapPath("~/MoviePosters").ToString();
                    var posterExtension = Path.GetExtension(postedFile.FileName);
                    var posterName = Path.GetFileNameWithoutExtension(postedFile.FileName);

                    var posterNewName = Guid.NewGuid() + posterName;
                    if (!Directory.Exists(storagePath))
                    {
                        Directory.CreateDirectory(storagePath);
                    }
                    if (posterExtension != null)
                    {
                        posterStoragePath = Path.Combine(storagePath, posterNewName + '_' + posterExtension); // to save cr copy
                        postedFile.SaveAs(posterStoragePath);
                    }
                    filePath = "/MoviePosters/" + posterNewName + '_' + posterExtension;
                }
                else
                {
                    filePath = context.Request["upLoadedImageSrc"];
                }
                DataSet ds = dataAccess.ManageMovie(movieId, movieName, yearRelease, textPlot, actorMovieTable, producerId, isUpdate, filePath);
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

        private DataTable CreateUserDefinedTable(string actorList, Nullable<int> movieId = null)
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("ActorId", typeof(Int32));
            temp.Columns.Add("MovieId", typeof(Int32));
            int[] ActorArray = Array.ConvertAll(actorList.Split(','), int.Parse);
            foreach (int actorId in ActorArray)
            {
                temp.Rows.Add(actorId, movieId);
            }
            return temp;
        }
    }
}