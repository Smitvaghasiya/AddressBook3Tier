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

public partial class AdminPannel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillContactGridView();
        }

    }
    #endregion Load Event

    #region FillContactGridView

    private void FillContactGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        if (dtContact!= null && dtContact.Rows.Count>0)
        {
            gvContactList.DataSource = dtContact;
            gvContactList.DataBind();
        }
    }

    #endregion FillContactGridView


    #region gvContactList: RowCommand
    protected void gvContactList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactBAL BalContact = new ContactBAL();
                if (BalContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillContactGridView();
                }
                else
                {
                    lblMessage.Text = BalContact.Message;
                }
            }
            else
            {

            }
        }
    }
    
    #endregion gvContactList: RowCommand
}
