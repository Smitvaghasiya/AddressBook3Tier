using AddressBook.BAL;
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

public partial class AdminPannel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            FillGridView();
        }
        
    }
    #endregion Load Event

    #region fillGridView
    
    private void FillGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountryList.DataSource = dtCountry;
            gvCountryList.DataBind();
        }
    }

    #endregion fillGridView

    #region gvContactList: RowCommand

    protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CountryBAL BalCountry = new CountryBAL();
                if (BalCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = BalCountry.Message;
                }
            }
            else
            {

            }
        }
    }
    #endregion gvContactList: RowCommand
}