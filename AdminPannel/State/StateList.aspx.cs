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

public partial class AdminPannel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillGridView();
        }

    }
    #endregion Load Event

    #region fillGridView
    
    private void FillGridView()
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll();

        if (dtState != null && dtState.Rows.Count > 0)
        {
            gvStateList.DataSource = dtState;
            gvStateList.DataBind();
        }
    }

    #endregion fillGridView

    #region gvContactList: RowCommand
    protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StateBAL BalState = new StateBAL();
                if (BalState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = BalState.Message;
                }
            }
            else
            {

            }
        }
    }

    #endregion gvContactList: RowCommand
}