using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPannel_Contact_ContactAddEditList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryList();
            FillContactCategoryList();

            #region Edit Record
            if (Request.QueryString["ContactID"] != null)
            {
                lblAddEditMode.Text = "Edit Contact";
                fillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
            #endregion Edit Record

            #region Insert Record
            else
            {
                lblAddEditMode.Text = "Add Contact";
                //ddlCountry.SelectedIndex = 0;
                //ddlCity.SelectedIndex = 0;
                ////ddlContactCategory.SelectedIndex = 0;
                //ddlState.SelectedIndex = 0;
                //txtAddress.Text = "";
                //txtContactName.Text = "";
                //txtContactNo.Text = "";
                //txtEmail.Text = "";
                //txtContactName.Focus();
            }
            #endregion Insert Record
        }
    }

    #endregion Load Event

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        string errorMessage = "";

        #endregion Local Variables

        #region Server Side Validation
        if (ddlCountry.SelectedIndex == 0)
            errorMessage += "Please Select Country <br/>";

        if (ddlState.SelectedIndex == 0)
            errorMessage += "Please Select State <br/>";

        if (ddlCity.SelectedIndex == 0)
            errorMessage += "Please Select City <br/>";

        if (ddlContactCategory.SelectedIndex == 0)
            errorMessage += "Please Select Contact Category <br/>";

        if (txtContactName.Text == "")
            errorMessage += "Please Enter Contact Name <br/>";

        if (txtContactNo.Text == "")
            errorMessage += "Please Enter Contact Number <br/> ";

        if (txtEmail.Text == "")
            errorMessage += "Please Enter Email <br/>";

        if (txtAddress.Text == "")
            errorMessage += "Please Enter Address ";

        if (errorMessage != "")
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = errorMessage;
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }
        #endregion Server Side Validation

        #region Gather Data

        ContactENT entContact = new ContactENT();

        if (ddlCountry.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        }

        if (ddlState.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlState.SelectedValue);
        }

        if (ddlCity.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCity.SelectedValue);
        }

        if (ddlContactCategory.SelectedIndex > 0)
        {
            entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);
        }

        if (txtContactName.Text.Trim() != "")
            entContact.ContactName = txtContactName.Text.Trim();

        if (txtContactNo.Text.Trim() != "")
            entContact.ContactNo = txtContactNo.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            entContact.Email = txtEmail.Text.Trim();

        if (txtAddress.Text.Trim() != "")
            entContact.Address = txtAddress.Text.Trim();

       #endregion Gather Data

        ContactBAL balContact = new ContactBAL();

        if (Request.QueryString["ContactID"] == null)
        {

            if (balContact.Insert(entContact))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                lblErrorMessage.Text = "State Added Successfully";
                ClearFillControl();
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balContact.Message;
            }
        }
        else
        {
            entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);

            if (balContact.Update(entContact))
            {
                ClearFillControl();
                Response.Redirect("~/AdminPannel/Contact/ContactList.aspx");
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balContact.Message;
            }
        }

        //#region Local Variables
        //SqlInt32 strCountryID = SqlInt32.Null;
        //SqlInt32 strStateID = SqlInt32.Null;
        //SqlInt32 strCityID = SqlInt32.Null;
        //SqlInt32 strContactCategoryID = SqlInt32.Null;
        //SqlString strContactName = SqlString.Null;
        //SqlString strContactNo = SqlString.Null;
        //SqlString strEmail = SqlString.Null;
        //SqlString strAddress = SqlString.Null;
        //string errorMessage = "";
        //#endregion Local Variables

        //#region Server Side Validation
        //if (ddlCountry.SelectedIndex == 0)
        //    errorMessage += "Please Select Country <br/>";

        //if (ddlState.SelectedIndex == 0)
        //    errorMessage += "Please Select State <br/>";

        //if (ddlCity.SelectedIndex == 0)
        //    errorMessage += "Please Select City <br/>";

        //if (ddlContactCategory.SelectedIndex == 0)
        //    errorMessage += "Please Select Contact Category <br/>";

        //if (txtContactName.Text == "")
        //    errorMessage += "Please Enter Contact Name <br/>";

        //if (txtContactNo.Text == "")
        //    errorMessage += "Please Enter Contact Number <br/> ";

        //if (txtEmail.Text == "")
        //    errorMessage += "Please Enter Email <br/>";

        //if (txtAddress.Text == "")
        //    errorMessage += "Please Enter Address ";

        //if (errorMessage != "")
        //{
        //    lblErrorMessage.Visible = true;
        //    lblErrorMessage.Text = errorMessage;
        //    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //#endregion Server Side Validation

        //if (ddlCountry.SelectedIndex > 0)
        //{
        //    strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        //}

        //if (ddlState.SelectedIndex > 0)
        //{
        //    strStateID = Convert.ToInt32(ddlState.SelectedValue);
        //}

        //if (ddlCity.SelectedIndex > 0)
        //{
        //    strCityID = Convert.ToInt32(ddlCity.SelectedValue);
        //}

        //if (ddlContactCategory.SelectedIndex > 0)
        //{
        //    strContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);
        //}


        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ToString());
        //// objConn.ConnectionString = "data source = SMIT; initial catalog = AddressBook ; Integrated Security = True;";
        //#endregion Set Connection

        //try
        //{

        //    #region Fill Details
        //    strContactName = txtContactName.Text;
        //    strContactNo = txtContactNo.Text;
        //    strEmail = txtEmail.Text;
        //    strAddress = txtAddress.Text;
        //    #endregion Fill Details


        //    #region Open Connection & Set Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = new SqlCommand();
        //    objCmd.Connection = objConn;

        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
        //    objCmd.Parameters.AddWithValue("@StateID", strStateID);
        //    objCmd.Parameters.AddWithValue("@CityID", strCityID);
        //    objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
        //    objCmd.Parameters.AddWithValue("@ContactName", strContactName);
        //    objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
        //    objCmd.Parameters.AddWithValue("@Email", strEmail);
        //    objCmd.Parameters.AddWithValue("@Address", strAddress);
        //    #endregion Open Connection & Set Command Object


        //    #region Update Record
        //    if (Request.QueryString["ContactId"] != null)
        //    {
        //        objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
        //        objCmd.Parameters.AddWithValue("ContactID", Request.QueryString["ContactID"].ToString().Trim());
        //        objCmd.ExecuteNonQuery();
        //        Response.Redirect("~/AdminPannel/Contact/ContactList.aspx");
        //    }
        //    #endregion Update Record

        //    #region Insert Record
        //    else
        //    {
        //        objCmd.CommandText = "PR_Contact_Insert";
        //        objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //        objCmd.ExecuteNonQuery();

        //        SqlInt32 ContactID = 0;
        //        ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);



        //        lblErrorMessage.Text = "Contact Added Successfully";
        //        lblErrorMessage.ForeColor = System.Drawing.Color.Green;
        //        lblErrorMessage.Visible = true;



        //        //foreach (ListItem liContactCategoryID in cblContactCategory.Items){
        //        //    if (liContactCategoryID.Selected)
        //        //    {
        //        //        SqlCommand objCmdContact = objConn.CreateCommand();
        //        //        objCmdContact.CommandType = CommandType.StoredProcedure;
        //        //        objCmdContact.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";
        //        //        objCmdContact.Parameters.AddWithValue("@ContactID", ContactID.ToString());
        //        //        objCmdContact.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
        //        //        objCmdContact.ExecuteNonQuery();
        //        //    }
        //        //}
        //    }
        //    #endregion Insert Record
        //}

        //catch (Exception ex)
        //{
        //    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
        //    lblErrorMessage.Visible = true;
        //    lblErrorMessage.Text = ex.Message;
        //}

        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //    txtContactName.Text = "";
        //    txtContactNo.Text = "";
        //    txtAddress.Text = "";
        //    txtEmail.Text = "";
        //    txtContactName.Focus();
        //    ddlCountry.SelectedIndex = 0;
        //    ddlState.SelectedIndex = 0;
        //    ddlContactCategory.SelectedIndex = 0;
        //    ddlCity.SelectedIndex = 0;
        //}

    }

    #endregion Button : Submit

    #region FillCountryList
    protected void FillCountryList()
    {
        CommonDropDownList.FillDropDownListCountry(ddlCountry);


        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ToString());
        ////objConn.ConnectionString = "data source = SMIT ; initial catalog = AddressBook ; Integrated Security = True;";
        //#endregion Set Connection

        //try
        //{
        //    #region Open Connection & Set Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = new SqlCommand();
        //    objCmd.Connection = objConn;

        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    #endregion Open Connection & Set Command Object

        //    objCmd.CommandText = "PR_Country_SelectForDropDownList";
        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    #region Read Data
        //    if (objSDR.HasRows)
        //    {
        //        ddlCountry.DataSource = objSDR;
        //        ddlCountry.DataValueField = "CountryID";
        //        ddlCountry.DataTextField = "CountryName";
        //        ddlCountry.DataBind();
        //    }
        //    #endregion Read Data

        //}

        //catch (Exception ex)
        //{
        //    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
        //    lblErrorMessage.Text = ex.Message;
        //}

        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        //ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));

    }

    #endregion FillCountryList

    #region FillStateList
    protected void FillStateList(SqlInt32 CountryID)
    {
        CommonDropDownList.FillDropDownListStateByCountry(ddlState, CountryID);

        //#region Local Variables
        //SqlInt32 strCountryID = SqlInt32.Null;
        //#endregion Local Variables

        //if (ddlCountry.SelectedIndex > 0)
        //{
        //    strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        //}


        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ToString());
        ////objConn.ConnectionString = "data source = SMIT; initial catalog = AddressBook ; Integrated Security = True;";
        //#endregion Set Connection

        //try
        //{
        //    #region Open Connection & Set Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = new SqlCommand();
        //    objCmd.Connection = objConn;
        //    objCmd.CommandType = CommandType.StoredProcedure;

        //    #endregion Open Connection & Set Command Object

        //    objCmd.CommandText = "[dbo].[PR_State_SelectForFillDropDownListByCountryID]";
        //    objCmd.Parameters.AddWithValue("@CountryID", strCountryID);

        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    #region read Data
        //    if (objSDR.HasRows)
        //    {
        //        ddlState.DataSource = objSDR;
        //        ddlState.DataValueField = "StateID";
        //        ddlState.DataTextField = "StateName";
        //        ddlState.DataBind();
        //    }
        //    #endregion read Data
        //}
        //catch (Exception ex)
        //{
        //    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
        //    lblErrorMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}

        //ddlState.Items.Insert(0, new ListItem("Select State", "-1"));



    }
    
    #endregion FillStateList

    #region FillCityList
    protected void FillCityList(SqlInt32 StateID)
    {
        CommonDropDownList.FillDropDownListCityByStateID(ddlCity, StateID);

        //#region Local Variables
        //SqlInt32 strStateID = SqlInt32.Null;
        //#endregion Local Variables

        //if (ddlState.SelectedIndex > 0)
        //{
        //    strStateID = Convert.ToInt32(ddlState.SelectedValue);
        //}


        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ToString());
        ////objConn.ConnectionString = "data source = SMIT; initial catalog = AddressBook ; Integrated Security = True;";
        //#endregion Set Connection

        //try
        //{
        //    #region Open Connection & Set Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = new SqlCommand();
        //    objCmd.Connection = objConn;
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    #endregion Open Connection & Set Command Object

        //    objCmd.CommandText = "[dbo].[PR_City_SelectForFillDropDownListByStateID]";
        //    objCmd.Parameters.AddWithValue("@StateID", strStateID);

        //    SqlDataReader objSDR = objCmd.ExecuteReader();
            
        //    #region Data Read
        //    if (objSDR.HasRows)
        //    {
        //        ddlCity.DataSource = objSDR;
        //        ddlCity.DataValueField = "CityID";
        //        ddlCity.DataTextField = "CItyName";
        //        ddlCity.DataBind();
        //    }
        //    #endregion Data Read
        //}
        //catch (Exception ex)
        //{
        //    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
        //    lblErrorMessage.Text = ex.Message;
        //}

        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        //ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

    }
    
    #endregion FillCityList

    #region FillContactCategory
    protected void FillContactCategoryList()
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ToString());
        //objConn.ConnectionString = "data source = SMIT; initial catalog = AddressBook ; Integrated Security = True;";
        #endregion Set Connection

        try
        {
            #region Open Connection & Set Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            #endregion Open Connection & Set Command Object

            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForCheckBoxList]";

            SqlDataReader objSDR = objCmd.ExecuteReader();
            #region Read Data
            if (objSDR.HasRows)
            {
                ddlContactCategory.DataSource = objSDR;
                ddlContactCategory.DataValueField = "ContactCategoryID";
                ddlContactCategory.DataTextField = "ContactCategoryName";
                ddlContactCategory.DataBind();
            }
            #endregion Read data
        }
        catch (Exception ex)
        {
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            lblErrorMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        ddlContactCategory.Items.Insert(0, new ListItem("Select Contact Category", "-1"));

    }

    #endregion FillContactCategory

    #region fillStateListwithCountryID
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStateList(Convert.ToInt32(ddlCountry.SelectedValue));
    }
    #endregion fillStateListwithCountryID

    #region fillCityListwithStateID
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCityList(Convert.ToInt32(ddlState.SelectedValue));
    }
    #endregion fillCityListwithStateID

    #region fillControls
    private void fillControls(SqlInt32 strContactId)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(strContactId);

        if (!entContact.CountryID.IsNull)
        {
            ddlCountry.SelectedValue = entContact.CountryID.Value.ToString();
            FillStateList(Convert.ToInt32(ddlCountry.SelectedValue));
        }

        if (!entContact.StateID.IsNull)
        {
            ddlState.SelectedValue = entContact.StateID.Value.ToString();
            FillCityList(Convert.ToInt32(ddlState.SelectedValue));
        }

        if (!entContact.CityID.IsNull)
            ddlCity.SelectedValue = entContact.CityID.Value.ToString();
        
        if (!entContact.ContactCategoryID.IsNull)
            ddlContactCategory.SelectedValue = entContact.ContactCategoryID.Value.ToString();

        if (!entContact.ContactName.IsNull)
            txtContactName.Text = entContact.ContactName.Value.ToString();

        if (!entContact.ContactNo.IsNull)
            txtContactNo.Text = entContact.ContactNo.Value.ToString();

        if (!entContact.Email.IsNull)
            txtEmail.Text = entContact.Email.Value.ToString();

        if (!entContact.Address.IsNull)
            txtAddress.Text = entContact.Address.Value.ToString();


        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        //#endregion Set Connection

        //try
        //{
        //    #region Open Connection & Set Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();

        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    #endregion Open Connection & Set Command Object

        //    objCmd.CommandText = "PR_Contact_SelectByPK";
        //    objCmd.Parameters.AddWithValue("@ContactID", strContactId.ToString().Trim());

        //    #region Read Data
        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    if (objSDR.HasRows)
        //    {
        //        while (objSDR.Read())
        //        {
        //            if (!objSDR["CountryID"].Equals(DBNull.Value))
        //            {
        //                ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
        //                //FillStateList();
        //            }

        //            if (!objSDR["StateID"].Equals(DBNull.Value))
        //            {
        //                ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
        //                //FillCityList();
        //            }

        //            if (!objSDR["CityID"].Equals(DBNull.Value))
        //            {
        //                ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
        //            }

        //            //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
        //            //{
        //            //    ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
        //            //}

        //            if (!objSDR["ContactName"].Equals(DBNull.Value))
        //            {
        //                txtContactName.Text = objSDR["ContactName"].ToString().Trim();
        //            }

        //            if (!objSDR["ContactNo"].Equals(DBNull.Value))
        //            {
        //                txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
        //            }

        //            if (!objSDR["Email"].Equals(DBNull.Value))
        //            {
        //                txtEmail.Text = objSDR["Email"].ToString().Trim();
        //            }

        //            if (!objSDR["Address"].Equals(DBNull.Value))
        //            {
        //                txtAddress.Text = objSDR["Address"].ToString().Trim();
        //            }

        //            break;
        //        }
        //    }
        //    #endregion Read Data

        //}
        //catch (Exception ex)
        //{
        //    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
        //    lblErrorMessage.Text = ex.Message;
        //}

        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
    }

    #endregion fillControls


    private void ClearFillControl()
    {
        txtContactName.Text = "";
        txtContactNo.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtContactName.Focus();
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlContactCategory.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;

    }
}