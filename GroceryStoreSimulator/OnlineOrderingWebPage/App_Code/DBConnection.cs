using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBConnection
/// </summary>
namespace OnlineOrder.App_Code
{
    public static class DBConnection
    {
        /** Read the connection string from the web.config file. 
        * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
        * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
        */
        private static System.Configuration.ConnectionStringSettings ReadConnectionString()
        {
            String strPath;
            strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

            System.Configuration.ConnectionStringSettings connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["MarlerKWConnectionString"];
            }
            return connString;
        }

        /**
        * Open the connection to the database
        */
        public static System.Data.SqlClient.SqlConnection OpenConnection()
        {
            System.Configuration.ConnectionStringSettings strConn;
            strConn = ReadConnectionString();
            // Console.WriteLine(strConn.ConnectionString);

            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);
            return conn;
        }

    }
}