using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Voter;
using ServiceLayer.Services.VoterServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
    public class VoterRepository : BaseSpecificRepository, IVoterRepository
    {
        public VoterRepository()
        { }

        public VoterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VoterModel GetVoterById(int loggedInUserId)
        {
            VoterModel voterModel = new VoterModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = "SELECT FirstName, LastName, DateOfBirth, AddressLine1, AddressLine2, Postcode, NationalInsurance, ElectionId " +
                         "FROM Users WHERE UserId = @UserId";

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqlLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@UserId", loggedInUserId));


                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                voterModel.FirstName = reader["FirstName"].ToString();
                                voterModel.LastName = reader["LastName"].ToString();
                                voterModel.DateOfBirth = reader["DateOfBirth"].ToString();
                                voterModel.AddressLine1 = reader["AddressLine1"].ToString(); 
                                voterModel.AddressLine1 = reader["AddressLine2"].ToString();
                                voterModel.Postcode = reader["Postcode"].ToString();
                                voterModel.NationalInsurance = reader["NationalInsurance"].ToString();
                                voterModel.ElectionId = Int32.Parse(reader["ElectionId"].ToString());
                            }
                        }
                        
                        sqlLiteConnection.Close();
                    }
                }
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Voter Model for requested user id", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    //throw e;
                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "", customMessage: $"Record not found. Unable to get User Model for user {loggedInUserId}. It does not exist in the database.", helpLink: "", errorCode: 0, stackTrace: "");

                    throw new DataAccessException(dataAccessStatus);
                    //throw e;
                }

                return voterModel;
            }
        }

        public void RegisterVoter(IVoterModel voterModel, int loggedInUserId)
        {
            int result = -1;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqlLiteConnection.Open();
                }
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to update/register voter. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string updateSql =
                       "UPDATE Users "
                     + "SET FirstName = @FirstName, "
                     + "LastName = @LastName, "
                     + "DateOfBirth = @DateOfBirth, "
                     + "AddressLine1 = @AddressLine1, "
                     + "AddressLine2 = @AddressLine2, "
                     + "Postcode = @Postcode, "
                     + "NationalInsurance = @NationalInsurance, "
                     + "ElectionId = @ElectionId "
                     + "WHERE UserId = @UserId";


                using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
                {
                    // User exists check not needed because already logged in as the user that you are updating
                    try
                    {
                        UserExistsCheck(cmd, loggedInUserId, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.CustomMessage = "User model could not be added because it is already in the database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
                        ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
                        throw ex;
                    }


                    cmd.CommandText = updateSql;

                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@FirstName", voterModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", voterModel.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", voterModel.DateOfBirth);
                    cmd.Parameters.AddWithValue("@AddressLine1", voterModel.AddressLine1);
                    cmd.Parameters.AddWithValue("@AddressLine2", voterModel.AddressLine2);
                    cmd.Parameters.AddWithValue("@Postcode", voterModel.Postcode);
                    cmd.Parameters.AddWithValue("@NationalInsurance", voterModel.NationalInsurance);
                    cmd.Parameters.AddWithValue("@ElectionId", voterModel.ElectionId);
                    cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: String.Copy(e.Message), customMessage: "Unable to update User Model", helpLink: String.Copy(e.HelpLink), errorCode: e.ErrorCode, stackTrace: String.Copy(e.StackTrace));

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                }
                sqlLiteConnection.Close();
            }


        }
        private bool UserExistsCheck(SQLiteCommand cmd, int loggedInUserId, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            cmd.Prepare();

            if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
            {
                //cmd.CommandText = "Select count(*) from Users where UserId=@UserId";
                //cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
            }
            else if ((requestType == RequestType.Update) || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete)) // Remove some 
            {
                cmd.CommandText = "Select count(*) from Users where UserId=@UserId";
                cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
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
