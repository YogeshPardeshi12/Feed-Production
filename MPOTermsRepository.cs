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
    public class MPOTermsRepository
    {
        public int SaveOrUpdate(MPOTerms_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.POtermsId == 0)
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
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MPOTerms]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@POtermsId ", _Models.POtermsId);
                sqlcmd.Parameters.AddWithValue("@CompanyId ", _Models.CompanyId);
                sqlcmd.Parameters.AddWithValue("@Module ", _Models.Module);
                sqlcmd.Parameters.AddWithValue("@POtermsCode ", _Models.POtermsCode);
                sqlcmd.Parameters.AddWithValue("@POtermsName ", _Models.POtermsName);
                sqlcmd.Parameters.AddWithValue("@Description ", _Models.Description);
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
                function.Errorlog("MPOTermsRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MPOTerms_Models models)
        {
            int _return = 0;
            if (models.POtermsId == 0) 
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MPOTerm mpo = new MPOTerm()
                    {
                        POtermsId = models.POtermsId,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        POtermsCode = models.POtermsCode,
                        POtermsName = models.POtermsName,
                        Description = models.Description,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark

                    };
                    db.Entry(mpo).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MPOTerm mpo = new MPOTerm()
                    {
                        POtermsId = models.POtermsId,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        POtermsCode = models.POtermsCode,
                        POtermsName = models.POtermsName,
                        Description = models.Description,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark

                    };
                    db.Entry(mpo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                };
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MPOTerms_EntityReport().ToList();
            }
        }

        public void ReportMPOTerms()
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MPOTerms");
                List<MPOTerms_Models> list = new List<MPOTerms_Models>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MPOTerms_Models models = new MPOTerms_Models();
                    models.POtermsId = Convert.ToInt32(dt.Rows[i]["POtermsId"]);
                    models.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"]);
                    models.Module = dt.Rows[i]["Module"].ToString();
                    models.POtermsCode = dt.Rows[i]["POtermsCode"].ToString();
                    models.POtermsName = dt.Rows[i]["POtermsName"].ToString();
                    models.Description = dt.Rows[i]["Description"].ToString();
                    models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    models.Remark = dt.Rows[i]["Remark"].ToString();
                    list.Add(models);
                }
            }
            catch (Exception ex)
            {
                MPOTerms_Models model = new MPOTerms_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPOTermsRepository", "ReportMPOTerms", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                List<MPOTerms_Models> list = new List<MPOTerms_Models>();
                {
                    MPOTerms_Models models = new MPOTerms_Models();
                    models.POtermsId = Convert.ToInt32(dt.Rows[0]["POtermsId"]);
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.POtermsCode = dt.Rows[0]["POtermsCode"].ToString();
                    models.POtermsName = dt.Rows[0]["POtermsName"].ToString();
                    models.Description = dt.Rows[0]["Description"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                }
            }
            catch (Exception ex)
            {
                MPOTerms_Models model = new MPOTerms_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPOTermsRepository", "ReportMPOTerms", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                List<MPOTerms_Models> list = new List<MPOTerms_Models>();
                {
                    MPOTerms_Models models = new MPOTerms_Models();
                    models.POtermsId = Convert.ToInt32(dt.Rows[0]["POtermsId"]);
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.POtermsCode = dt.Rows[0]["POtermsCode"].ToString();
                    models.POtermsName = dt.Rows[0]["POtermsName"].ToString();
                    models.Description = dt.Rows[0]["Description"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                }
            }
            catch (Exception ex)
            {
                MPOTerms_Models model = new MPOTerms_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPOTermsRepository", "ReportMPOTerms", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}

    

