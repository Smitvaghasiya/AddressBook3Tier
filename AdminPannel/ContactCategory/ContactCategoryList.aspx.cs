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

public partial class AdminPannel_ContactCategory_ContactCategoryList : System.Web.UI.Page
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
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dtContactCategory = new DataTable();

        dtContactCategory = balContactCategory.SelectAll();

        if (dtContactCategory != null && dtContactCategory.Rows.Count > 0)
        {
            gvContactCategoryList.DataSource = dtContactCategory;
            gvContactCategoryList.DataBind();
        }
    }

    #endregion fillGridView


    #region gvContactList: RowCommand

    protected void gvContactCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactCategoryBAL BalContactCategory = new ContactCategoryBAL();
                if (BalContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = BalContactCategory.Message;
                }
            }
            else
            {

            }
        }
    }
        #endregion gvContactList: RowCommand
}
