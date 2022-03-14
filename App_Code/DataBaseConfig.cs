using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBaseConfig
/// </summary>
namespace AddressBook
{
    public class DataBaseConfig
    {
        public DataBaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

    }
}