using Feed_Production.Sql_Conection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Repository
{
    public class ClsFunction
    {
        public void Errorlog(String ClassName,string FunctionName,string ErrorMessage,string ErrorData,string ErrorLine,DateTime ErrorDate)
        {
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            try
            {
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_ErrorLog]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@ClassName", ClassName);
                sqlcmd.Parameters.AddWithValue("FunctionName", FunctionName);
                sqlcmd.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);
                sqlcmd.Parameters.AddWithValue("@ErrorData", ErrorData);
                sqlcmd.Parameters.AddWithValue("@ErrorLine", ErrorLine);
                sqlcmd.Parameters.AddWithValue("@ErrorDate", ErrorDate);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                throw(ex);
            }
            finally
            {
                sqlcon.Close(); 
                sqlcmd.Dispose();
            }
        }
        public void ErrorlogEnity(String ClassName, string FunctionName, string ErrorMessage, string ErrorData, string ErrorLine, DateTime ErrorDate)
        {
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            try
            {
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_ErrorLog]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@ClassName", ClassName);
                sqlcmd.Parameters.AddWithValue("FunctionName", FunctionName);
                sqlcmd.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);
                sqlcmd.Parameters.AddWithValue("@ErrorData", ErrorData);
                sqlcmd.Parameters.AddWithValue("@ErrorLine", ErrorLine);
                sqlcmd.Parameters.AddWithValue("@ErrorDate", ErrorDate);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                sqlcon.Close();
                sqlcmd.Dispose();
            }
        }
    }
}
