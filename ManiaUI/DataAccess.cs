using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManiaUI
{
    internal class DataAccess : IDisposable
    {
        SqlCommand _cmd;
        SqlDataAdapter _da;
        DataSet _ds;
        readonly Helper helper = new Helper();
        internal protected DataAccess(string sConnString)
        {
            Connection = new SqlConnection(sConnString);
        }

        protected SqlConnection Connection { get; }
        public string ErrorMessage
        {
            get { return ErrorMessage; }
            protected set { ErrorMessage = value; }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

        internal DataSet GetActorsList()
        {
            _cmd = new SqlCommand();
            _ds = new DataSet();
            _da = new SqlDataAdapter();
            try
            {
                _cmd.CommandText = "uspGetActors";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;
                _cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                _cmd.Parameters.Add("@Success", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _da.SelectCommand = _cmd;
                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    _ds.Tables[0].TableName = "Actors";
                }
                _ds.Tables.Add(helper.ConvertOutputParametersToDataTable(_cmd.Parameters));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _cmd = null;
                _da = null;
            }
            return _ds;
        }

        internal DataSet InsertActorProducer(int actProFlag, string name, string bioGraphy, string dateOfBirth, int sex)
        {
            _cmd = new SqlCommand();
            _ds = new DataSet();
            _da = new SqlDataAdapter();
            try
            {
                _cmd.CommandText = actProFlag==0 ? "uspInsertProducer" : "uspInsertActor";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;
                _cmd.Parameters.Add("@ActorName", SqlDbType.VarChar,30).Value = name;
                _cmd.Parameters.Add("@Sex", SqlDbType.Int).Value = sex;
                _cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth;
                _cmd.Parameters.Add("@Bio", SqlDbType.NVarChar,500).Value = bioGraphy;
                _cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                _cmd.Parameters.Add("@Success", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _da.SelectCommand = _cmd;
                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    _ds.Tables[0].TableName = "Actors";
                }
                _ds.Tables.Add(helper.ConvertOutputParametersToDataTable(_cmd.Parameters));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _cmd = null;
                _da = null;
            }
            return _ds;
        }
    }
}