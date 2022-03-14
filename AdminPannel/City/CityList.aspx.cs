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

public partial class AdminPannel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCityGridView();
        }
    }
    #endregion Load Event

    #region FillCityGridView
    private void FillCityGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll();

        if (dtCity != null && dtCity.Rows.Count > 0)
        {
            gvCityList.DataSource = dtCity;
            gvCityList.DataBind();
        }
    }
    #endregion FillCityGridView

    #region gvContactList: RowCommand
    protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL BalCity = new CityBAL();
                if (BalCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillCityGridView();
                }
                else
                {
                    lblMessage.Text = BalCity.Message;
                }
            }
            else
            {

            }
        }
    }

    #endregion gvContactList: RowCommand
}