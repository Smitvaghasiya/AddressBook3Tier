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

public partial class AdminPannel_State_StateAddEditList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            FillDropDownList();
            #region Edit Record
            if (Request.QueryString["StateID"] != null)
            {
                lblCountryMode.Text = "Edit Country";
                fillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            #endregion Edit Record

            #region Add State
            else
            {
                lblCountryMode.Text = "Add State";
                ddlCountry.SelectedIndex = 0;
                txtStateCode.Text = "";
                txtStateName.Text = "";
                txtStateName.Focus();
            }
            #endregion Add State
        }
    }
    #endregion Load Event

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string errorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        if (ddlCountry.SelectedIndex == 0)
            errorMessage += "Select State<br/>";

        if (txtStateName.Text.Trim() == "")
            errorMessage += "Enter State Name<br/>";

        if (txtStateCode.Text.Trim() == "")
            errorMessage += "Enter State Code<br/>";

        if (errorMessage != "")
        {
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            lblErrorMessage.Text = errorMessage.ToString();
            return;
        }

        #endregion Server Side Validation

        #region Gather Data

        StateENT entState = new StateENT();

        if (ddlCountry.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();

        if (txtStateCode.Text.Trim() != "")
            entState.StateCode = txtStateCode.Text.Trim();

        #endregion Gather Data

        StateBAL balState = new StateBAL();

        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                lblErrorMessage.Text = "State Added Successfully";
                ClearFillControl();
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balState.Message;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);

            if (balState.Update(entState))
            {
                ClearFillControl();
                Response.Redirect("~/AdminPannel/State/StateList.aspx");
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balState.Message;
            }
        }
    }

    #endregion Button : Submit

    #region fillCountryList

    protected void FillDropDownList()
    {
        CommonDropDownList.FillDropDownListCountry(ddlCountry);
    } 

    #endregion fillCountryList

    #region fillControls
    private void fillControls(SqlInt32 strStateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPK(strStateID);

        if (!entState.CountryID.IsNull)
            ddlCountry.SelectedValue = entState.CountryID.Value.ToString();

        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.ToString();

        if (!entState.StateCode.IsNull)
            txtStateCode.Text = entState.StateCode.ToString();



    //    #region Set Connection
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
    //    #endregion Set Connection

    //    try
    //    {
    //        #region Open Connection & Set Command Object
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_State_SelectByPK";
    //        objCmd.Parameters.AddWithValue("@StateID", strStateID.ToString().Trim());

    //        #endregion Open Connection & Set Command Object

    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        #region Read Data
    //        if (objSDR.HasRows)
    //        {
    //            while (objSDR.Read())
    //            {
                    
    //                if (!objSDR["StateName"].Equals(DBNull.Value))
    //                {
    //                    txtStateName.Text = objSDR["StateName"].ToString().Trim();
    //                }

    //                if (!objSDR["StateCode"].Equals(DBNull.Value))
    //                {
    //                    txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
    //                }

    //                if (!objSDR["CountryID"].Equals(DBNull.Value))
    //                {
    //                    ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
    //                }

    //                break; 
    //            }
    //        }
    //        #endregion Read Data


    //    }

    //    catch (Exception ex)
    //    {
    //        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
    //        lblErrorMessage.Text = ex.Message;
    //    }

    //    finally
    //    {

    //    }

    }

    #endregion fillControls

    private void ClearFillControl()
    {
        ddlCountry.SelectedIndex = 0;
        txtStateName.Text = null;
        txtStateCode.Text = null;
        txtStateName.Focus();

    }
}