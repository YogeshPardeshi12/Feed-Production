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
    public class MMaterialRepository
    {
        public int SaveOrUpdate(MMaterial_Models _Models )
        {
            int _return;
            string flag = "";
            if(_Models.MaterialId==0)
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
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MMaterial]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@MaterialId", _Models.MaterialId);
                sqlcmd.Parameters.AddWithValue("@MaterialCode ", _Models.MaterialCode);
                sqlcmd.Parameters.AddWithValue("@MaterialName ", _Models.MaterialName);
                sqlcmd.Parameters.AddWithValue("@MatrialUnit ", _Models.MatrialUnit);
                sqlcmd.Parameters.AddWithValue("@PackingId ", _Models.PackingId);
                sqlcmd.Parameters.AddWithValue("@ForCasteFlag ", _Models.ForCasteFlag);
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
                function.Errorlog("MMaterialRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MMaterial_Models models)
        {
            int _return = 0;
            if (models.MaterialId == 0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MMaterial material = new MMaterial()
                    {
                        MaterialId = models.MaterialId,
                        MaterialCode = models.MaterialCode,
                        MaterialName = models.MaterialName,
                        MatrialUnit = models.MatrialUnit,
                        PackingId = models.PackingId,
                        ForCasteFlag = models.ForCasteFlag,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark
                    };
                    db.Entry(material).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MMaterial material = new MMaterial()
                    {
                        MaterialId = models.MaterialId,
                        MaterialCode = models.MaterialCode,
                        MaterialName = models.MaterialName,
                        MatrialUnit = models.MatrialUnit,
                        PackingId = models.PackingId,
                        ForCasteFlag = models.ForCasteFlag,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark
                    };
                    db.Entry(material).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                };
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MMaterial_EntityReport().ToList();
            }
        }
        public void ReportMMaterial()
        {
            try
            { 
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            DataTable dt = new DataTable();
            dt = con.Report("Select * from MMaterial");
            List<MMaterial_Models> list = new List<MMaterial_Models>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MMaterial_Models models = new MMaterial_Models();
                models.MaterialId = Convert.ToInt32(dt.Rows[i]["MaterialId"]);
                models.MaterialCode = dt.Rows[i]["MaterialCode"].ToString();
                models.MaterialName = dt.Rows[i]["MaterialName"].ToString();
                models.MatrialUnit = Convert.ToInt32(dt.Rows[i]["MatrialUnit"]);
                models.PackingId = Convert.ToInt32(dt.Rows[i]["PackingId"]);
                models.ForCasteFlag = dt.Rows[i]["ForCasteFlag"].ToString();
                models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                list.Add(models);
            }
        }
            catch (Exception ex)
            {
                MMaterial_Models model = new MMaterial_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMaterialRepository", "ReportMMaterial", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MMaterial where CompanyId =" + id);
                List<MMaterial_Models> list = new List<MMaterial_Models>();
                {
                    MMaterial_Models models = new MMaterial_Models();
                    models.MaterialId = Convert.ToInt32(dt.Rows[0]["MaterialId"]);
                    models.MaterialCode = dt.Rows[0]["MaterialCode"].ToString();
                    models.MaterialName = dt.Rows[0]["MaterialName"].ToString();
                    models.MatrialUnit = Convert.ToInt32(dt.Rows[0]["MatrialUnit"]);
                    models.PackingId = Convert.ToInt32(dt.Rows[0]["PackingId"]);
                    models.ForCasteFlag = dt.Rows[0]["ForCasteFlag"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                }
            }
            catch (Exception ex)
            {
                MMaterial_Models model = new MMaterial_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMaterialRepository", "ReportMMaterial", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MMaterial where Name like = % Name %");
                List<MMaterial_Models> list = new List<MMaterial_Models>();
                {
                    MMaterial_Models models = new MMaterial_Models();
                    models.MaterialId = Convert.ToInt32(dt.Rows[0]["MaterialId"]);
                    models.MaterialCode = dt.Rows[0]["MaterialCode"].ToString();
                    models.MaterialName = dt.Rows[0]["MaterialName"].ToString();
                    models.MatrialUnit = Convert.ToInt32(dt.Rows[0]["MatrialUnit"]);
                    models.PackingId = Convert.ToInt32(dt.Rows[0]["PackingId"]);
                    models.ForCasteFlag = dt.Rows[0]["ForCasteFlag"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                }
            }
            catch (Exception ex)
            {
                MMaterial_Models model = new MMaterial_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MMaterialRepository", "ReportMMaterial", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    } 
}
