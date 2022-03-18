using CommonComponents;
using CommonComponets;
using DomainLayer.Models.User;
using ServiceLayer.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
    public class UserRepository : BaseSpecificRepository, IUserRepository
    {
        public UserRepository()
        { }

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserModel LoginUser(IUserModel userLoginModel)
        {
            UserModel userModel = new UserModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = "SELECT UserId, Username, Password, IsVoter, IsAdmin, IsAuditor " +
                         "FROM Users WHERE Username = @Username AND Password = @Password";

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqlLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@Username", userLoginModel.Username));
                        cmd.Parameters.Add(new SQLiteParameter("@Password", userLoginModel.Password));


                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                userModel.UserId = Int32.Parse(reader["UserId"].ToString());
                                userModel.Username = reader["Username"].ToString();
                                userModel.IsVoter = Convert.ToBoolean(reader["IsVoter"]);
                                userModel.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                                userModel.IsAuditor = Convert.ToBoolean(reader["IsAuditor"]);
                            }
                        }
                        sqlLiteConnection.Close();
                    }
                }
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get User Model for requested user", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    //throw e;
                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "", customMessage: $"Record not found. Unable to get User Model for Username {userLoginModel.Username}. It does not exist in the database.", helpLink: "", errorCode: 0, stackTrace: "");

                    throw new DataAccessException(dataAccessStatus);
                    //throw e;
                }

                return userModel;
            }
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="userModel"></param>
        /// <exception cref="DataAccessException"></exception>
        public void RegisterUser(IUserModel userModel)
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
                       "INSERT INTO Users (Username, Password) " +
                       "VALUES (@Username, @Password) ";

                using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
                {
                    try
                    {
                        UserExistsCheck(cmd, userModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.CustomMessage = "User model could not be added because it is already in the database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
                        ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
                        throw ex;
                    }

                    cmd.CommandText = SqlText;

                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", userModel.Username);
                    cmd.Parameters.AddWithValue("@Password", userModel.Password);
                    //cmd.Parameters.AddWithValue("@IsVoter", userModel.IsVoter);
                    //cmd.Parameters.AddWithValue("@IsAdmin", userModel.IsAdmin);
                    //cmd.Parameters.AddWithValue("@IsAuditor", userModel.IsAuditor);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to register User Model", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }


                    try //Confirm the User Model was added to the database
                    {
                        UserExistsCheck(cmd, userModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.Status = "Error";
                        ex.DataAccessStatusInfo.OperationSucceeded = false;
                        ex.DataAccessStatusInfo.CustomMessage = "Failed to find user model in database after add operation completed.";
                        ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
                        ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

                        throw ex;
                    }
                    sqlLiteConnection.Close();
                }
            }
        }

        private bool UserExistsCheck(SQLiteCommand cmd, IUserModel userModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            cmd.Prepare();

            if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
            {
                cmd.CommandText = "Select count(*) from Users where Username=@Username AND Password=@Password";
                cmd.Parameters.AddWithValue("@Username", userModel.Username);
                cmd.Parameters.AddWithValue("@Password", userModel.Password);
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



        //public UserModel RegisterUser(UserModel registerUserModel)
        //{
        //    return new UserModel();
        //}

        //public UserModel GetById(string userId)
        //{
        //    return new UserModel();
        //}
    }

}
