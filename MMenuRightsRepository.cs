using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feed_Production.Models;
using Feed_Production.Sql_Conection;
using System.Data.SqlClient;
using Feed_Production.Repository;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Reflection;
using System.Data;

namespace Feed_Production.Repository
{
    public class MMenuRightsRepository
    {
        public int SaveOrUpdate(MMenuRights_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.MenuId == 0)
            {
                _return = 1;
                flag = "I";
            }
            else
            {
                _return = 2;
                flag = "U";
            }
            SqlCommand sqlcmd = new SqlCommand();
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            try
            {
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MMenuRights]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@MenuId", _Models.MenuId);
                sqlcmd.Parameters.AddWithValue("@Module ", _Models.Module);
                sqlcmd.Parameters.AddWithValue("@UserId ", _Models.UserId);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return= 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MMenuRightsRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public void ReportMMenuRights()
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MMenuRights");
                List<MMenuRights_Models> list = new List<MMenuRights_Models>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MMenuRights_Models models = new MMenuRights_Models();
                    models.MenuId = Convert.ToInt32(dt.Rows[i]["MenuId"]);
                    models.Module = Convert.ToInt32(dt.Rows[i]["Module"]);
                    models.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    list.Add(models);
                }
            }
            catch (Exception ex)
            {
                MMenuRights_Models model = new MMenuRights_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMenuRightsRepository", "ReportMMenuRights", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
        public void GetById(int id)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MMenuRights where CompanyId =" + id);
                List<MMenuRights_Models> list = new List<MMenuRights_Models>();
                {
                    MMenuRights_Models models = new MMenuRights_Models();
                    models.MenuId = Convert.ToInt32(dt.Rows[0]["MenuId"]);
                    models.Module = Convert.ToInt32(dt.Rows[0]["Module"]);
                    models.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                }
            }
            catch (Exception ex)
            {
                MMenuRights_Models model = new MMenuRights_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMenuRightsRepository", "ReportMMenuRights", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
        public void GetByName(string Name)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MMenuRights where Name like = % Name %");
                List<MMenuRights_Models> list = new List<MMenuRights_Models>();
                {
                    MMenuRights_Models models = new MMenuRights_Models();
                    models.MenuId = Convert.ToInt32(dt.Rows[0]["MenuId"]);
                    models.Module = Convert.ToInt32(dt.Rows[0]["Module"]);
                    models.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                }
            }
            catch (Exception ex)
            {
                MMenuRights_Models model = new MMenuRights_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMenuRightsRepository", "ReportMMenuRights", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
    

