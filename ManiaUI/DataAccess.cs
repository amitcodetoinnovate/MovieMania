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

        internal DataSet GetProducersList()
        {
            _cmd = new SqlCommand();
            _ds = new DataSet();
            _da = new SqlDataAdapter();
            try
            {
                _cmd.CommandText = "uspGetProducer";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;
                _cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                _cmd.Parameters.Add("@Success", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _da.SelectCommand = _cmd;
                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    _ds.Tables[0].TableName = "Producers";
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

        internal DataSet GetMovies()
        {
            _cmd = new SqlCommand();
            _ds = new DataSet();
            _da = new SqlDataAdapter();
            try
            {
                _cmd.CommandText = "uspGetMovies";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;
                _cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                _cmd.Parameters.Add("@Success", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _da.SelectCommand = _cmd;
                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    _ds.Tables[0].TableName = "Movies";
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
                _cmd.CommandText = actProFlag==1 ? "uspInsertProducer" : "uspInsertActor";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;
                _cmd.Parameters.Add(actProFlag == 1 ? "@ProducerName": "@ActorName", SqlDbType.VarChar,30).Value = name;
                _cmd.Parameters.Add("@Sex", SqlDbType.Int).Value = sex;
                _cmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar,10).Value = dateOfBirth;
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

        

        internal DataSet ManageMovie(int movieId, string movieName, int yearRelease, string textPlot, DataTable actorMovieTable, string producerId, bool isUpdate, string filePath)
        {
            _cmd = new SqlCommand();
            _ds = new DataSet();
            _da = new SqlDataAdapter();
            try
            {
                _cmd.CommandText = "uspMovieManagement";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = Connection;
                _cmd.Parameters.Add("@Mode" , SqlDbType.TinyInt).Value = isUpdate ? 0:1;
                _cmd.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;
                _cmd.Parameters.Add("@MovieName", SqlDbType.VarChar, 30).Value = movieName;
                _cmd.Parameters.Add("@YearOfRelease", SqlDbType.Int).Value = yearRelease;
                _cmd.Parameters.Add("@Poster", SqlDbType.VarChar, -1).Value = filePath  ;
                _cmd.Parameters.Add("@Plot", SqlDbType.VarChar, -1).Value = textPlot;
                _cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = producerId;
                _cmd.Parameters.AddWithValue("@InputActorMovie", actorMovieTable);
                _cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                _cmd.Parameters.Add("@Success", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _da.SelectCommand = _cmd;
                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    _ds.Tables[0].TableName = "Movies";
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