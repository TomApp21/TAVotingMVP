﻿using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Voter;
using ServiceLayer.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfrastructureLayer.DataAccess.Repositories.Specific.BaseSpecificRepository;

namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
    public class AdminRepository : BaseSpecificRepository, IAdminRepository
    {
        public AdminRepository()
        {
        }
        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<IVoterModel> GetAll()
        {
            List<VoterModel> voterModelList = new List<VoterModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM Users WHERE IsVoter = 1 AND VoterIdentityConfirmed IS NULL";

                    sqlLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VoterModel voterModel = new VoterModel();
                                voterModel.FirstName = reader["FirstName"].ToString();
                                voterModel.LastName = reader["LastName"].ToString();
                                voterModel.DateOfBirth = reader["DateOfBirth"].ToString();
                                voterModel.AddressLine1 = reader["AddressLine1"].ToString();
                                voterModel.AddressLine2 = reader["AddressLine2"].ToString();
                                voterModel.Postcode = reader["Postcode"].ToString();
                                voterModel.NationalInsurance = reader["NationalInsurance"].ToString();
                                voterModelList.Add(voterModel);
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
                return voterModelList;
            }
        }

        public void ConfirmVoterIdentity(IVoterModel voterModel, bool identityConfirmed)
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
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to update voter identity confirmation. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string updateSql =
                       "UPDATE Users "
                     + "SET IdentityConfirmed = @IdentityConfirmed "
                     + "WHERE FirstName = @FirstName "
                     + "AND LastName = @LastName, "
                     + "AND DateOfBirth = @DateOfBirth, "
                     + "AND AddressLine1 = @AddressLine1, "
                     + "AND AddressLine2 = @AddressLine2, "
                     + "AND Postcode = @Postcode, "
                     + "AND NationalInsurance = @NationalInsurance";


                using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
                {
                    // User exists check not needed because already logged in as the user that you are updating
                    try
                    {
                        RecordExistsCheck(cmd, voterModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
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
                    cmd.Parameters.AddWithValue("@IdentityConfirmed", identityConfirmed);
                    cmd.Parameters.AddWithValue("@FirstName", voterModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", voterModel.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", voterModel.DateOfBirth);
                    cmd.Parameters.AddWithValue("@AddressLine1", voterModel.AddressLine1);
                    cmd.Parameters.AddWithValue("@AddressLine2", voterModel.AddressLine2);
                    cmd.Parameters.AddWithValue("@Postcode", voterModel.Postcode);
                    cmd.Parameters.AddWithValue("@NationalInsurance", voterModel.NationalInsurance);
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


        //public VoterModel GetById(int departmentId)
        //{
        //    VoterModel voterModel = new VoterModel();
        //    DataAccessStatus dataAccessStatus = new DataAccessStatus();
        //    bool MatchingRecordFound = false;
        //    string sql = "SELECT DepartmentId, DepartmentName, DepartmentUrl, PhoneNumber, Email, CityLocation, StateLocation " +
        //                 "FROM Departments WHERE DepartmentId = @DepartmentId";

        //    using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
        //    {
        //        try
        //        {
        //            sqlLiteConnection.Open();

        //            using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlLiteConnection))
        //            {
        //                cmd.CommandText = sql;
        //                cmd.Prepare();
        //                cmd.Parameters.Add(new SQLiteParameter("@DepartmentId", departmentId));

        //                using (SQLiteDataReader reader = cmd.ExecuteReader())
        //                {
        //                    MatchingRecordFound = reader.HasRows;
        //                    while (reader.Read())
        //                    {

        //                        departmentModel.DepartmentId = Int32.Parse(reader["DepartmentId"].ToString());
        //                        departmentModel.DepartmentName = reader["DepartmentName"].ToString();
        //                        departmentModel.DepartmentUrl = reader["DepartmentUrl"].ToString();
        //                        departmentModel.PhoneNumber = reader["PhoneNumber"].ToString();
        //                        departmentModel.Email = reader["Email"].ToString();
        //                        departmentModel.CityLocation = reader["CityLocation"].ToString();
        //                        departmentModel.StateLocation = reader["StateLocation"].ToString();
        //                    }
        //                }
        //                sqlLiteConnection.Close();
        //            }
        //        }
        //        catch (SQLiteException e)
        //        {
        //            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to get Department Model for requested ID", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

        //            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        //            //throw e;
        //        }

        //        if (!MatchingRecordFound)
        //        {
        //            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "", customMessage: $"Record not found. Unable to get Department Model for Department ID {departmentId}. Id {departmentId} does not exist in the database.", helpLink: "", errorCode: 0, stackTrace: "");

        //            throw new DataAccessException(dataAccessStatus);
        //            //throw e;
        //        }

        //        return departmentModel;
        //    }
        //}


        //public void Update(IDepartmentModel departmentModel)
        //{
        //    int result = -1;
        //    DataAccessStatus dataAccessStatus = new DataAccessStatus();

        //    using (SQLiteConnection sqlLiteConnection = new SQLiteConnection(_connectionString))
        //    {
        //        try
        //        {
        //            sqlLiteConnection.Open();
        //        }
        //        catch (SQLiteException e)
        //        {
        //            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message, customMessage: "Unable to update DepartmentModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

        //            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        //        }

        //        string updateSql =
        //               "UPDATE Departments "
        //             + "SET DepartmentName = @DepartmentName, "
        //             + "DepartmentUrl = @DepartmentUrl, "
        //             + "PhoneNumber = @PhoneNumber, "
        //             + "Email = @Email, "
        //             + "CityLocation = @CityLocation, "
        //             + "StateLocation = @StateLocation "
        //             + "WHERE DepartmentId = @DepartmentId";

        //        using (SQLiteCommand cmd = new SQLiteCommand(sqlLiteConnection))
        //        {
        //            try
        //            {
        //                RecordExistsCheck(cmd, departmentModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
        //            }
        //            catch (DataAccessException ex)
        //            {
        //                ex.DataAccessStatusInfo.CustomMessage = "Department Model could not be updated because it is not in the database.";
        //                ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
        //                ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);
        //                throw ex;
        //            }

        //            cmd.CommandText = updateSql;

        //            cmd.Prepare();
        //            cmd.Parameters.AddWithValue("@DepartmentName", departmentModel.DepartmentName);
        //            cmd.Parameters.AddWithValue("@DepartmentUrl", departmentModel.DepartmentUrl);
        //            cmd.Parameters.AddWithValue("@PhoneNumber", departmentModel.PhoneNumber);
        //            cmd.Parameters.AddWithValue("@Email", departmentModel.Email);
        //            cmd.Parameters.AddWithValue("@CityLocation", departmentModel.CityLocation);
        //            cmd.Parameters.AddWithValue("@StateLocation", departmentModel.StateLocation);
        //            cmd.Parameters.AddWithValue("@DepartmentId", departmentModel.DepartmentId);
        //            try
        //            {
        //                result = cmd.ExecuteNonQuery();
        //            }
        //            catch (SQLiteException e)
        //            {
        //                dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: String.Copy(e.Message), customMessage: "Unable to update Department Model", helpLink: String.Copy(e.HelpLink), errorCode: e.ErrorCode, stackTrace: String.Copy(e.StackTrace));

        //                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
        //            }
        //        }
        //        sqlLiteConnection.Close();
        //    }
        //}





        private bool RecordExistsCheck(SQLiteCommand cmd, IVoterModel voterModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            cmd.Prepare();


            if ((requestType == RequestType.Update) || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
            {
                cmd.CommandText = "Select count(*) from Users " 
                     + "WHERE FirstName = @FirstName, "
                     + "AND LastName = @LastName, "
                     + "AND DateOfBirth = @DateOfBirth, "
                     + "AND AddressLine1 = @AddressLine1, "
                     + "AND AddressLine2 = @AddressLine2, "
                     + "AND Postcode = @Postcode, "
                     + "AND NationalInsurance = @NationalInsurance"; 
                

                cmd.Parameters.AddWithValue("@FirstName", voterModel.FirstName);
                cmd.Parameters.AddWithValue("@LastName", voterModel.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", voterModel.DateOfBirth);
                cmd.Parameters.AddWithValue("@AddressLine1", voterModel.AddressLine1);
                cmd.Parameters.AddWithValue("@AddressLine2", voterModel.AddressLine2);
                cmd.Parameters.AddWithValue("@Postcode", voterModel.Postcode);
                cmd.Parameters.AddWithValue("@NationalInsurance", voterModel.NationalInsurance);
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