using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Candidate;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
    public class CandidateRepository : BaseSpecificRepository, ICandidateRepository
    {
        public CandidateRepository()
        {
        }
        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        //public IEnumerable<ICandidateModel> GetAll()
        //{
        //    List<VoterModel> voterModelList = new List<VoterModel>();
        //    DataAccessStatus dataAccessStatus = new DataAccessStatus();

        //    using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
        //    {
        //        try
        //        {
        //            string sql = "SELECT * FROM Users WHERE IsVoter = 1 AND VoterIdentityConfirmed IS NULL";

        //            sqlLiteConnection.Open();

        //            using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
        //            {
        //                using (SQLiteDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        VoterModel voterModel = new VoterModel();
        //                        voterModel.FirstName = reader["FirstName"].ToString();
        //                        voterModel.LastName = reader["LastName"].ToString();
        //                        voterModel.DateOfBirth = reader["DateOfBirth"].ToString();
        //                        voterModel.AddressLine1 = reader["AddressLine1"].ToString();
        //                        voterModel.AddressLine2 = reader["AddressLine2"].ToString();
        //                        voterModel.Postcode = reader["Postcode"].ToString();
        //                        voterModel.NationalInsurance = reader["NationalInsurance"].ToString();
        //                        voterModelList.Add(voterModel);
        //                    }
        //                }
        //                sqlLiteConnection.Close();
        //            }
        //        }
        //        catch (SQLiteException e)
        //        {
        //            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Department Model list from database", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

        //            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        //        }
        //        return voterModelList;
        //    }
        //}


        /// <summary>
        /// Add
        /// </summary>
        /// <param name="userModel"></param>
        /// <exception cref="DataAccessException"></exception>
        public void AddCandidate(ICandidateModel candidateModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqlLiteConnection.Open();
                }
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to add UserModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string SqlText =
                       "INSERT INTO Candidates (CandidateName, VoteCount, ElectionId) " +
                       "VALUES (@CandidateName, @VoteCount, @ElectionId) ";

                using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
                {
                    try
                    {
                        CandidateExistsCheck(cmd, candidateModel.CandidateName, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.CustomMessage = "Candidate model could not be added because it is already in the database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
                        ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
                        throw ex;
                    }

                    cmd.CommandText = SqlText;

                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@CandidateName", candidateModel.CandidateName);
                    cmd.Parameters.AddWithValue("@VoteCount", candidateModel.VoteCount);
                    cmd.Parameters.AddWithValue("@ElectionId", candidateModel.ElectionId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to register User Model", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }


                    try //Confirm the Candidate Model was added to the database
                    {
                        CandidateExistsCheck(cmd, candidateModel.CandidateName, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.Status = "Error";
                        ex.DataAccessStatusInfo.OperationSucceeded = false;
                        ex.DataAccessStatusInfo.CustomMessage = "Failed to find candidate model in database after add operation completed.";
                        ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
                        ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

                        throw ex;
                    }
                    sqlLiteConnection.Close();
                }
            }
        }

        private bool CandidateExistsCheck(SQLiteCommand cmd, string candidateName, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            cmd.Prepare();

            if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
            {
                cmd.CommandText = "Select count(*) from Candidates where CandidateName=@CandidateName";
                cmd.Parameters.AddWithValue("@CandidateName", candidateName);
            }

            try
            {
                countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SQLiteException e)
            {
                string msg = e.Message;
                throw;
            }

            if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && (countOfRecsFound > 0))
            {
                dataAccessStatus.Status = "Error";
                RecordExistsCheckPassed = false;

                throw new DataAccessException(dataAccessStatus);
            }
            else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesExistInDB) && (countOfRecsFound == 0))
            {
                dataAccessStatus.Status = "Error";
                RecordExistsCheckPassed = false;
                throw new DataAccessException(dataAccessStatus);
            }
            return RecordExistsCheckPassed;
        }
    }
}
