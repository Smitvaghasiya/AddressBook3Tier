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

public partial class AdminPannel_ContactCategory_ContactCategoryAddEditList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region Edit Record
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblAddEditMode.Text = "Edit Contact Category";
                fillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
            #endregion Edit Record
            
            #region Insert Record
            else
            {
                lblAddEditMode.Text = "Add Contact Category";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
            }
            #endregion Insert Record
        }
        //else
        //{
        //    lblAddEditMode.Text = "Add Contact Category";
        //    txtContactCategoryName.Text = "";
        //    txtContactCategoryName.Focus();
        //}
    }

    #endregion Load Event

    #region Button : Submit

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string errorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        if (txtContactCategoryName.Text.Trim() == "")
            errorMessage += "Enter Contact Category Name<br/>";

        
        #endregion Server Side Validation

        #region Gather Data

        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        if (txtContactCategoryName.Text.Trim() != "")
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();



        #endregion Gather Data

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if (Request.QueryString["ContactCategoryID"] == null)
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                lblErrorMessage.Text = "State Added Successfully";
                ClearFillControl();
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balContactCategory.Message;
            }
        }
        else
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);

            if (balContactCategory.Update(entContactCategory))
            {
                ClearFillControl();
                Response.Redirect("~/AdminPannel/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = balContactCategory.Message;
            }
        }

    }


    #endregion Button : Submit

    #region fillControls
    private void fillControls(SqlInt32 strContactCategory)
    {

        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(strContactCategory);

        if (!entContactCategory.ContactCategoryName.IsNull)
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.ToString();

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
        //        #endregion Open Connection & Set Command Object

        //        #region Read Data
        //        objCmd.CommandText = "PR_ContactCategory_SelectByPK";
        //        objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategory);

        //        SqlDataReader objSDR = objCmd.ExecuteReader();

        //        if (objSDR.HasRows)
        //        {
        //            while (objSDR.Read())
        //            {
        //                if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
        //                {
        //                    txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
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
        //        if (objConn.State == ConnectionState.Open)
        //            objConn.Close();
        //    }
    }

    #endregion fillControls

    #region Clear Form Field
    private void ClearFillControl()
    {
       
        txtContactCategoryName.Text = null;
        txtContactCategoryName.Focus();

    }
    #endregion Clear Form Field

}