using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Election;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
    public class ElectionRepository : BaseSpecificRepository, IElectionRepository
    {
        public ElectionRepository()
        {
        }
        public ElectionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<IElectionModel> GetAllValidElections()
        {
            List<ElectionModel> electionModelList = new List<ElectionModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM Elections";

                    sqlLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ElectionModel electionModel = new ElectionModel();
                                electionModel.ElectionId = Int32.Parse(reader["ElectionId"].ToString());
                                electionModel.ElectionName = reader["ElectionName"].ToString();
                                electionModel.StartDate = reader["StartDate"].ToString();
                                electionModel.EndDate = reader["EndDate"].ToString();

                                electionModelList.Add(electionModel);
                            }
                        }
                        sqlLiteConnection.Close();
                    }
                }
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Department Model list from database", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                return electionModelList;
            }
        }
        public ElectionModel GetElectionById(int electionId)
        {
            ElectionModel electionModel = new ElectionModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = "SELECT ElectionId, ElectionName, StartDate, EndDate " +
                         "FROM Elections WHERE ElectionId = @ElectionId";

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqlLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@ElectionId", electionId));


                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                electionModel.ElectionId = Int32.Parse(reader["ElectionId"].ToString());
                                electionModel.ElectionName = reader["ElectionName"].ToString();
                                electionModel.StartDate = reader["StartDate"].ToString();
                                electionModel.EndDate = reader["EndDate"].ToString();
                       
                            }
                        }

                        sqlLiteConnection.Close();
                    }
                }
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Election Model for requested election id", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    //throw e;
                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "", customMessage: $"Record not found. Unable to get Election Model for user {electionId}. It does not exist in the database.", helpLink: "", errorCode: 0, stackTrace: "");

                    throw new DataAccessException(dataAccessStatus);
                    //throw e;
                }

                return electionModel;
            }
        }
    }
}
