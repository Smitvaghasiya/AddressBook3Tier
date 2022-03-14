using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownList
/// </summary>
public class CommonDropDownList
{
    public CommonDropDownList()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void FillDropDownListCountry(DropDownList ddl)
    {
        CountryBAL balCountry = new CountryBAL();
        ddl.DataSource = balCountry.SelectForDropDownList();
        ddl.DataValueField = "CountryID";
        ddl.DataTextField = "CountryName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("- Select Country -", "-1"));
    }

    public static void FillDropDownListState(DropDownList ddl)
    {
        StateBAL balState = new StateBAL();
        ddl.DataSource = balState.SelectForDropDownList();
        ddl.DataValueField = "StateID";
        ddl.DataTextField = "StateName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("- Select State -", "-1"));
    }

    public static void FillDropDownListStateByCountry(DropDownList ddl, SqlInt32 CountryID)
    {
        StateBAL balState = new StateBAL();
        ddl.DataSource = balState.SelectForDropDownListByCountryID(CountryID);
        ddl.DataValueField = "StateID";
        ddl.DataTextField = "StateName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("- Select State -", "-1"));
    }


    public static void FillDropDownListCity(DropDownList ddl)
    {
        CityBAL balCity = new CityBAL();
        ddl.DataSource = balCity.SelectForDropDownList();
        ddl.DataValueField = "CityID";
        ddl.DataTextField = "CityName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("- Select City -", "-1"));
    }

    public static void FillDropDownListCityByStateID(DropDownList ddl, SqlInt32 StateID)
    {
        CityBAL balCity = new CityBAL();
        ddl.DataSource = balCity.SelectForDropDownListByStateID(StateID);
        ddl.DataValueField = "CityID";
        ddl.DataTextField = "CityName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("- Select City -", "-1"));
    }

    public static void FillDropDownListContactCategory(DropDownList ddl)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ddl.DataSource = balContactCategory.SelectForDropDownList();
        ddl.DataValueField = "ContactCategoryID";
        ddl.DataTextField = "ContactCategoryName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("- Select ContactCategory -", "-1"));
    }



}