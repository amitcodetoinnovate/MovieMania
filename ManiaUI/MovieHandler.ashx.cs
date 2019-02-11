using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
                Logger.Error(ex.ToString());

            }
        }

        private JObject GetActorsList(HttpContext context)
        {
            _cmd = new SqlCommand();
            _da = new SqlDataAdapter();
            _ds = new DataSet();
            try
            {
                _cmd.CommandText = "TMremoveCategoryId";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;

                _cmd.Parameters.Add("@TMremoveCategoryId", SqlDbType.Int).Value = TMremoveCategoryId;
                _cmd.Parameters.Add("@Success", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _cmd.Parameters.Add("@Message", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                Connection.Open();
                _cmd.ExecuteNonQuery();
                Connection.Close();
                _ds.Tables.Add(_helper.ConvertOutputParametersToDataTable(_cmd.Parameters));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }
            finally
            {
                Connection.Close();
                _cmd = null;
            }
            return _ds;
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