using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
namespace AddressBook.DAL
{

    public class ContactDAL : DataBaseConfig
    {
        #region Local Variables

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variables

        #region Constructor
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor 

        #region Insert Operation

        public Boolean Insert(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_Insert";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = entContact.ContactNo;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }


        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_UpdateByPK";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = entContact.ContactID;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = entContact.ContactNo;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }


        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }
        #endregion SelectAll

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);

                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);

                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                    entContact.ContactName = Convert.ToString(objSDR["ContactName"]);

                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                    entContact.ContactNo = Convert.ToString(objSDR["ContactNo"]);

                                if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                                    entContact.WhatsAppNo = Convert.ToString(objSDR["WhatsAppNo"]);

                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                    entContact.BirthDate = Convert.ToString(objSDR["BirthDate"]);

                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entContact.Email = Convert.ToString(objSDR["Email"]);

                                if (!objSDR["Age"].Equals(DBNull.Value))
                                    entContact.Age = Convert.ToInt32(objSDR["Age"]);

                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entContact.Address = Convert.ToString(objSDR["Address"]);

                                if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                                    entContact.BloodGroup = Convert.ToString(objSDR["BloodGroup"]);

                                if (!objSDR["FacebookID"].Equals(DBNull.Value))
                                    entContact.FacebookID = Convert.ToString(objSDR["FacebookID"]);

                                if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                                    entContact.LinkedINID = Convert.ToString(objSDR["LinkedINID"]);

                            }
                        }
                        return entContact;

                        #endregion ReadData and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion SelectByPK

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectForDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }
        #endregion SelectForDropDownList

        #region FillCountryList
        public DataTable FillCountryList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectForDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }
        #endregion SelectForDropDownListByStateID

        #region FillStateListByCountryID
        public DataTable FillStateListByCountryID(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectForFillDropDownListByCountryID";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }
        #endregion FillStateListByCountryID

        #region FillCityListByStateID
        public DataTable FillCityListListByStateID(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectForFillDropDownListByStateID";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }
        #endregion FillCityListByStateID

        #endregion Select Operation

    }
}