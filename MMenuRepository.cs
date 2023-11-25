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
using DataContext;
using System.Security.AccessControl;

namespace Feed_Production.Repository
{
    public class MMenuRepository
    {
        public int SaveOrUpdate(MMenu_Models _Models)
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
                flag= "U";
            }
            SqlCommand sqlcmd = new SqlCommand();
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            try
            {
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MMenu]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@CompanyId ", _Models.CompanyId);
                sqlcmd.Parameters.AddWithValue("@MenuId ", _Models.MenuId);
                sqlcmd.Parameters.AddWithValue("@Module ", _Models.Module);
                sqlcmd.Parameters.AddWithValue("@MenuName ", _Models.MenuName);
                sqlcmd.Parameters.AddWithValue("@ParentId ", _Models.ParentId);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@Tag ", _Models.Tag);
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MMenuRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MMenu_Models models)
        {
            int _return = 0;
            if(models.MenuId == 0)
            {
                using(DbEntitty db = new DbEntitty())
                {
                    MMenu menu = new MMenu()
                    {
                        MenuId = models.MenuId,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        MenuName = models.MenuName,
                        ParentId = models.ParentId,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Tag = models.Tag
                    };
                    db.Entry(menu).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MMenu menu = new MMenu()
                    {
                        MenuId = models.MenuId,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        MenuName = models.MenuName,
                        ParentId = models.ParentId,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Tag = models.Tag
                    };
                    db.Entry(menu).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                };
            }
            return _return;
            }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MMenu_EntityReport().ToList();
            }
        }
        public void ReportMMenu()
        {
            try
            { 
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            DataTable dt = new DataTable();
            dt = con.Report("Select * from MMenu");
            List<MMenu_Models> list = new List<MMenu_Models>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MMenu_Models models = new MMenu_Models();
                models.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"]);
                models.MenuId = Convert.ToInt32(dt.Rows[i]["MenuId"]);
                models.Module = dt.Rows[i]["Module"].ToString();
                models.MenuName = dt.Rows[i]["MenuName"].ToString();
                models.ParentId = dt.Rows[i]["ParentId"].ToString();
                models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                models.Tag = dt.Rows[i]["Tag"].ToString();
                list.Add(models);
            }
        }catch (Exception ex)
            {
                MMenu_Models model = new MMenu_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMenuRepository", "ReportMMenu", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MMenu where CompanyId =" + id);
                List<MMenu_Models> list = new List<MMenu_Models>();
                {
                    MMenu_Models models = new MMenu_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.MenuId = Convert.ToInt32(dt.Rows[0]["MenuId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.MenuName = dt.Rows[0]["MenuName"].ToString();
                    models.ParentId = dt.Rows[0]["ParentId"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Tag = dt.Rows[0]["Tag"].ToString();
                }
            }
            catch (Exception ex)
            {
                MMenu_Models model = new MMenu_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMenuRepository", "ReportMMenu", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MMenu where Name like = % Name %");
                List<MMenu_Models> list = new List<MMenu_Models>();
                {
                    MMenu_Models models = new MMenu_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.MenuId = Convert.ToInt32(dt.Rows[0]["MenuId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.MenuName = dt.Rows[0]["MenuName"].ToString();
                    models.ParentId = dt.Rows[0]["ParentId"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Tag = dt.Rows[0]["Tag"].ToString();
                }
            }
            catch (Exception ex)
            {
                MMenu_Models model = new MMenu_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMenuRepository", "ReportMMenu", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
