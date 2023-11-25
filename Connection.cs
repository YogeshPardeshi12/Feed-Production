using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Feed_Production.Sql_Conection
{
    public class Connection
    {
        string cs = "Data Source=DESKTOP-96VFSU5;Initial Catalog=DbBrokerageNew;Integrated Security=True";
        public SqlConnection Connect()
        {
            SqlConnection Sqlcon = new SqlConnection(cs);
            Sqlcon.Close();
            if (Sqlcon.State==System.Data.ConnectionState.Closed)
            {
                Sqlcon.Open();
            }
            return Sqlcon;
        }
        public DataTable Report(string query)
        {
            Connection C = new Connection();
            SqlConnection Sqlcon = C.Connect();
            SqlCommand Sqlcmd = new SqlCommand();
            Sqlcmd.Connection = Sqlcon;
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter(query, Sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }

}

