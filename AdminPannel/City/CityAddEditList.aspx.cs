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

public partial class AdminPannel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
            FillDropDownList();
            #region Edit Record

            if (Request.QueryString["CityID"] != null)
                {
                    lblAddEdit.Text = "Edit City";
                    fillControls(Convert.ToInt32(Request.QueryString["CityID"]));
                }
                #endregion Edit Record

                #region Add Record
                else
                {
                    lblAddEdit.Text = "Add City";
                    ddlState.SelectedIndex = 0;
                    txtCityName.Text = "";
                    txtSTDCode.Text = "";
                    txtCityName.Focus();
                }
                #endregion Add Record
            }
            

    }

    #endregion Load Event

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        String strErrorMessage = "";
        #endregion Local Variables

        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        //#endregion Set Connection

        #region Server Side Validation
        if (ddlState.SelectedIndex == 0)
        {
            strErrorMessage = "Please Select State<br/>";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter City Name<br/>";
        }
        if (txtSTDCode.Text.Trim() == "")
        {
            strErrorMessage += "Please Enter STD Code";
        }

        if (strErrorMessage != "")
        {
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            lblErrorMessage.Text = strErrorMessage.ToString();
            return;
        }

        #endregion Server Side Validation

        #region Fatch Data

        CityENT entCity = new CityENT();

        if (ddlState.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlState.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            entCity.STDCode = txtSTDCode.Text.Trim();

        #endregion Fatch Data

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {

            if (balCity.Insert(entCity))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                ClearFormField();
                lblErrorMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balCity.Message;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);

            if (balCity.Update(entCity))
            {
                ClearFormField();
                Response.Redirect("~/AdminPannel/City/CityList.aspx");
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balCity.Message;
            }
        }  
    }

    #endregion Button : Submit

    #region fillStateDropDownList
    
    private void FillDropDownList()
    {
        CommonDropDownList.FillDropDownListState(ddlState);
    }
    
    #endregion fillStateDropDownList

    #region Fill Controls
    private void fillControls(SqlInt32 strCityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(strCityID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();

        if (!entCity.STDCode.IsNull)
            txtSTDCode.Text = entCity.STDCode.Value.ToString();

        if (!entCity.StateID.IsNull)
            ddlState.SelectedValue = entCity.StateID.Value.ToString();

        //#region Set Connection
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        //#endregion Set Connection

        //try
        //{
        //    #region Open Connection  & Set Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();

        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    #endregion Open Connection  & Set Command Object


        //    objCmd.CommandText = "PR_City_SelectByPK";
        //    objCmd.Parameters.AddWithValue("CityID", strCityID.ToString().Trim());

        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    #region Gather Information
        //    if (objSDR.HasRows)
        //    {
        //        while (objSDR.Read())
        //        {
        //            if (!objSDR["CityName"].Equals(DBNull.Value))
        //            {
        //                txtCityName.Text = objSDR["CityName"].ToString().Trim();
        //            }

        //            if (!objSDR["STDCode"].Equals(DBNull.Value))
        //            {
        //                txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
        //            }

        //            if (!objSDR["StateID"].Equals(DBNull.Value))
        //            {
        //                ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
        //            }
        //        }
        //    }
        //    #endregion Gather Information

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

    #endregion Fill Controls

    #region Clear Form
    public void ClearFormField()
    {
        ddlState.SelectedIndex = 0;
        txtSTDCode.Text = "";
        txtCityName.Text = "";
        txtCityName.Focus();

    }

    #endregion Clear Form
}