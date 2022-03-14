using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryBAL
/// </summary>
namespace AddressBook.BAL
{

public class ContactCategoryBAL
{
    #region Constructor
    public ContactCategoryBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region Local Variable

    protected string _Message;

    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }

    #endregion Local Variable

    #region Delete Operation

    public Boolean Delete(SqlInt32 ContactCategoryID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        if (dalContactCategory.Delete(ContactCategoryID))
        {
            return true;
        }
        else
        {
            Message = dalContactCategory.Message;
            return false;
        }
    }

    #endregion Delete Operation

    #region Insert

    public Boolean Insert(ContactCategoryENT entContactCategoryID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        if (dalContactCategory.Insert(entContactCategoryID))
        {
            return true;
        }
        else
        {
            Message = dalContactCategory.Message;
            return false;
        }
    }


    #endregion Insert

    #region Update

    public Boolean Update(ContactCategoryENT entContactCategory)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        if (dalContactCategory.Update(entContactCategory))
        {
            return true;
        }
        else
        {
            Message = dalContactCategory.Message;
            return false;
        }
    }
    #endregion Update

    #region Select Operation

    #region SelectAll

    public DataTable SelectAll()
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        return dalContactCategory.SelectAll();
    }

    #endregion SelectAll

    #region SelectForDropDownList

    public DataTable SelectForDropDownList()
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        return dalContactCategory.SelectForDropDownList();
    }

    #endregion SelectForDropDownList

    #region SelectByPK

    public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
    {
        ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
        return dalContactCategory.SelectByPK(ContactCategoryID);
    }

    #endregion SelectByPK

    #endregion Select Operation

    }
}