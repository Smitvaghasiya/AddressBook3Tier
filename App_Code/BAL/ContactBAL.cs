using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contact
/// </summary>
namespace AddressBook.BAL
{
    public class ContactBAL
    {
        #region Constructor
        public ContactBAL()
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

        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Delete(ContactID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }

        #endregion Delete Operation

        #region Insert

        public Boolean Insert(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Insert(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }


        #endregion Insert

        #region Update

        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Update(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion Update

        #region Select Operation

        #region SelectAll

        public DataTable SelectAll()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll();
        }

        #endregion SelectAll

        #region SelectForDropDownList

        public DataTable SelectForDropDownList()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropDownList();
        }

        #endregion SelectForDropDownList

        #region SelectByPK

        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID);
        }

        #endregion SelectByPK

        #endregion Select Operation

    }
}