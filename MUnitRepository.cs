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
    public class MUnitRepository
    {
        public int SaveOrUpdate(MUnit_Models _Models)
        {
            int _return;
            string flag = "";
            if(_Models.UnitId==0)
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
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MUnit]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@UnitId ", _Models.UnitId);
                sqlcmd.Parameters.AddWithValue("@UnitCode ", _Models.UnitCode);
                sqlcmd.Parameters.AddWithValue("@UnitName ", _Models.UnitName);
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
                function.Errorlog("MUnitRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MUnit_Models models)
        {
            int _return = 0;
            if (models.UnitId == 0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MUnit unit = new MUnit()
                    {
                        UnitId = models.UnitId,
                        UnitCode = models.UnitCode,
                        UnitName = models.UnitName,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark

                    };
                    db.Entry(unit).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MUnit unit = new MUnit()
                    {
                        UnitId = models.UnitId,
                        UnitCode = models.UnitCode,
                        UnitName = models.UnitName,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark

                    };
                    db.Entry(unit).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                };
            }
            return _return;
            }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MUnit_EntityReport().ToList();
            }
        }
        public void ReportMUnit()
        {
            try
            { 
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            DataTable dt = new DataTable();
            dt = con.Report("Select * from MUnit");
            List<MUnit_Models> list = new List<MUnit_Models>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MUnit_Models models = new MUnit_Models();
                models.UnitId = Convert.ToInt32(dt.Rows[i]["UnitId"]);
                models.UnitCode = dt.Rows[i]["UnitCode"].ToString();
                models.UnitName = dt.Rows[i]["UnitName"].ToString();
                models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                models.Remark = dt.Rows[i]["Remark"].ToString();
                list.Add(models);
            }
        }
            catch(Exception ex)
            {
                MUnit_Models model = new MUnit_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MUnitRepository", "ReportMUnit", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                List<MUnit_Models> list = new List<MUnit_Models>();
                {
                    MUnit_Models models = new MUnit_Models();
                    models.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                    models.UnitCode = dt.Rows[0]["UnitCode"].ToString();
                    models.UnitName = dt.Rows[0]["UnitName"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                }
            }
            catch (Exception ex)
            {
                MUnit_Models model = new MUnit_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MUnitRepository", "ReportMUnit", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                List<MUnit_Models> list = new List<MUnit_Models>();
                {
                    MUnit_Models models = new MUnit_Models();
                    models.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                    models.UnitCode = dt.Rows[0]["UnitCode"].ToString();
                    models.UnitName = dt.Rows[0]["UnitName"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                }
            }
            catch (Exception ex)
            {
                MUnit_Models model = new MUnit_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MUnitRepository", "ReportMUnit", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
    

