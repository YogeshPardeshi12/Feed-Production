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
    public class MUserRepository
    {
        public int SaveOrUpdate(MUser_Models _Models)
        {
            int _return;
            string flag = "";
            if(_Models.UserId==0)
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
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MUser]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection= sqlcon;
                sqlcmd.Parameters.AddWithValue("@CompanyId ", _Models.CompanyId);
                sqlcmd.Parameters.AddWithValue("@Module ", _Models.Module);
                sqlcmd.Parameters.AddWithValue("@UserId ", _Models.UserId);
                sqlcmd.Parameters.AddWithValue("@UserName ", _Models.UserName);
                sqlcmd.Parameters.AddWithValue("@UserPwd ", _Models.UserPwd);
                sqlcmd.Parameters.AddWithValue("@UserType ", _Models.UserType);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MUserRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MUser_Models models)
        {
            int _return = 0;
            if (models.UserId == 0)
            {
                using(DbEntitty db = new DbEntitty())
                {
                    MUser user = new MUser()
                    {
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        UserId = models.UserId,
                        UserName = models.UserName,
                        UserPwd = models.UserPwd,
                        UserType = models.UserType,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn

                    };
                    db.Entry(user).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MUser user = new MUser()
                    {
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        UserId = models.UserId,
                        UserName = models.UserName,
                        UserPwd = models.UserPwd,
                        UserType = models.UserType,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn

                    };
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MUser_EntityReport().ToList();
            }
        }
        public void ReportMUser()
        {
            try
            { 
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            DataTable dt = new DataTable();
            dt = con.Report("Select * from MUser");
            List<MUser_Models> list = new List<MUser_Models>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MUser_Models models = new MUser_Models();
                models.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"]);
                models.Module = dt.Rows[i]["Module"].ToString();
                models.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                models.UserName = dt.Rows[i]["UserName"].ToString();
                models.UserPwd = dt.Rows[i]["UserPwd"].ToString();
                models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                list.Add(models);
            }
        }
            catch (Exception ex)
            {
                MUser_Models model = new MUser_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MUserRepository", "ReportMUser", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MCompany where CompanyId =" + id);
                List<MUser_Models> list = new List<MUser_Models>();
                {
                    MUser_Models models = new MUser_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    models.UserName = dt.Rows[0]["UserName"].ToString();
                    models.UserPwd = dt.Rows[0]["UserPwd"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                }
            }
            catch (Exception ex)
            {
                MUser_Models model = new MUser_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MUserRepository", "ReportMUser", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
        public void GetByName(String Name)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MCompany where Name like = % Name %");
                List<MUser_Models> list = new List<MUser_Models>();
                {
                    MUser_Models models = new MUser_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    models.UserName = dt.Rows[0]["UserName"].ToString();
                    models.UserPwd = dt.Rows[0]["UserPwd"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                }
            }
            catch (Exception ex)
            {
                MUser_Models model = new MUser_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MUserRepository", "ReportMUser", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
