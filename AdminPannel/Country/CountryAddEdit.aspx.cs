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

public partial class AdminPannel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region Edit Record
            if (Request.QueryString["CountryID"] != null)
            {
                lblCountryMode.Text = "Edit Country";
                fillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            #endregion Edit Record

            #region Add Record
            else
            {
                lblCountryMode.Text = "Add Country";
                txtCountryCode.Text = "";
                txtCountryName.Text = "";
                txtCountryName.Focus();
            }
            #endregion Add Record
        }
    }
    #endregion Load Event

    #region Button : Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        String strMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        if (txtCountryName.Text.Trim() == "")
            strMessage = "Please enter Country Name <br/>";

        if (txtCountryCode.Text.Trim() == "")
            strMessage += "Please enter Country Code";

        if (strMessage.Trim() != "")
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            lblErrorMessage.Text = strMessage;
            return;
        }
        #endregion Server Side Validation

        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            entCountry.CountryCode = txtCountryCode.Text.Trim();

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {

            if (balCountry.Insert(entCountry))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                ClearFormField();
                lblErrorMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balCountry.Message;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);

            if (balCountry.Update(entCountry))
            {
                ClearFormField();
                Response.Redirect("~/AdminPannel/Country/CountryList.aspx");
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balCountry.Message;
            }
        }



        
    }

    #endregion Button : Submit

    #region Fill Controls
    private void fillControls(SqlInt32 CountryID)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Set Connection

        try
        {
            #region Open Connection & Set Object Command 
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

            #endregion Open Connection & Set Object Command

            #region Read the Value & set the Controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }

                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;

                }
            }
            else
            {
                lblErrorMessage.Text = "No Data Available for the StateID = " + CountryID.ToString().Trim();
            }
            #endregion Read the Value & set the Controls

        }

        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }


    }

    #endregion Fill Controls


    private void ClearFormField()
    {
        txtCountryCode.Text = null;
        txtCountryName.Text = null;
        txtCountryName.Focus();
    }
}