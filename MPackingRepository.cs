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
    public class MPackingRepository
    {
        public int SaveOrUpdate(MPacking_Models _Models)
        {
            int _return;
            string flag = "";
            if(_Models.PackingId==0)
            {
                _return = 1;
                flag = "I";
            }
            else
            {
                _return = 2;
                flag ="U";
            }
            SqlCommand sqlcmd = new SqlCommand();
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            try
            {
                sqlcmd.CommandText = ("Ado_Sp_MPacking");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@PackingId", _Models.PackingId);
                sqlcmd.Parameters.AddWithValue("@PackingCode", _Models.PackingCode);
                sqlcmd.Parameters.AddWithValue("@PackingName ", _Models.PackingName);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@Remark ", _Models.Remark);
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MPackingRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MPacking_Models models)
        {
            int _return = 0;
            if (models.PackingId == 0)
            {
                using(DbEntitty db = new DbEntitty())
                {
                    MPacking packing = new MPacking()
                    {
                        PackingId = models.PackingId,
                        PackingCode = models.PackingCode,
                        PackingName = models.PackingName,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark

                    };
                    db.Entry(packing).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MPacking packing = new MPacking()
                    {
                        PackingId = models.PackingId,
                        PackingCode = models.PackingCode,
                        PackingName = models.PackingName,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark

                    };
                    db.Entry(packing).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MPacking_EntityReport().ToList();
            }
        }
        public void ReportMPacking()
        {
            try
            { 
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            DataTable dt = new DataTable();
            dt = con.Report("Select * from MPacking");
            List<MPacking_Models> list = new List<MPacking_Models>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MPacking_Models models = new MPacking_Models();
                models.PackingId = Convert.ToInt32(dt.Rows[i]["PackingId"]);
                models.PackingCode = dt.Rows[i]["PackingCode"].ToString();
                models.PackingName = dt.Rows[i]["PackingName"].ToString();
                models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                models.Remark = dt.Rows[i]["Remark"].ToString();
                list.Add(models);
            }
        }
            catch(Exception ex)
            {
                MPacking_Models model = new MPacking_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPackingRepository", "ReportMPacking", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MPacking where CompanyId =" + id);
                List<MPacking_Models> list = new List<MPacking_Models>();
                {
                    MPacking_Models models = new MPacking_Models();
                    models.PackingId = Convert.ToInt32(dt.Rows[0]["PackingId"]);
                    models.PackingCode = dt.Rows[0]["PackingCode"].ToString();
                    models.PackingName = dt.Rows[0]["PackingName"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                }
            }
            catch (Exception ex)
            {
                MPacking_Models model = new MPacking_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPackingRepository", "ReportMPacking", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MPacking where Name like = % Name %");
                List<MPacking_Models> list = new List<MPacking_Models>();
                {
                    MPacking_Models models = new MPacking_Models();
                    models.PackingId = Convert.ToInt32(dt.Rows[0]["PackingId"]);
                    models.PackingCode = dt.Rows[0]["PackingCode"].ToString();
                    models.PackingName = dt.Rows[0]["PackingName"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                }
            }
            catch (Exception ex)
            {
                MPacking_Models model = new MPacking_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPackingRepository", "ReportMPacking", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
