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
    public class MFinancialYearRepository
    {
        public int SaveOrUpdate(MFinancialYear_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.TrId == 0)
            {
                _return = 1;
                flag = "I";
            }
            else
            {
                _return = 2;
                flag = "U";
            }
            SqlCommand Sqlcmd = new SqlCommand();
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            try
            {
                Sqlcmd.CommandText = ("[dbo].[Ado_Sp_MFinancialYear]");
                Sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                Sqlcmd.Connection = sqlcon;
                Sqlcmd.Parameters.AddWithValue("@TrId", _Models.TrId);
                Sqlcmd.Parameters.AddWithValue("@FinancialYear", _Models.FinancialYear);
                Sqlcmd.Parameters.AddWithValue("@FYear", _Models.FYear);
                Sqlcmd.Parameters.AddWithValue("@YearClose", _Models.YearClose);
                Sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                Sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                Sqlcmd.Parameters.AddWithValue("@flag", flag);
                Sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MFinancialYearRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {

                Sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MFinancialYear_Models models)
        {
            int _return = 0;
            if (models.TrId==0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MFinancialYear financialYear = new MFinancialYear()
                    {
                        TrId = models.TrId,
                        FinancialYear = models.FinancialYear,
                        FYear = models.FYear,
                        YearClose = models.YearClose,
                        AcFlag = models.AcFlag 
                        
                    };
                    db.Entry(financialYear).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MFinancialYear financialYear = new MFinancialYear()
                    {
                        TrId = models.TrId,
                        FinancialYear = models.FinancialYear,
                        FYear = models.FYear,
                        YearClose = models.YearClose,
                        AcFlag = models.AcFlag
                    };
                    db.Entry(financialYear).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MFinancialYear_EntityReport().ToList();
            }
        }
        public List<MFinancialYear_Models> ReportMFinancialYear()
        {
            List<MFinancialYear_Models> list = new List<MFinancialYear_Models>();
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MFinancialYear");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MFinancialYear_Models models = new MFinancialYear_Models();
                    models.TrId = Convert.ToInt32(dt.Rows[i]["TrId"]);
                    models.FinancialYear = dt.Rows[i]["FinancialYear"].ToString();
                    models.FYear = dt.Rows[i]["FYear"].ToString();
                    models.YearClose = dt.Rows[i]["YearClose"].ToString();
                    models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    list.Add(models);
                }
            }
            catch (Exception ex)
            {
                MFinancialYear_Models model = new MFinancialYear_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MFinancialYearRepository", "ReportMFinancialYear", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
            return list;
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
                dt = con.Report("Select * from MFinancialYear where CompanyId =" + id);
                List<MFinancialYear_Models> list = new List<MFinancialYear_Models>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MFinancialYear_Models models = new MFinancialYear_Models();
                    models.TrId = Convert.ToInt32(dt.Rows[0]["TrId"]);
                    models.FinancialYear = dt.Rows[0]["FinancialYear"].ToString();
                    models.FYear = dt.Rows[0]["FYear"].ToString();
                    models.YearClose = dt.Rows[0]["YearClose"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                }
            }
            catch (Exception ex)
            {
                MFinancialYear_Models model = new MFinancialYear_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MFinancialYearRepository", "ReportMFinancialYear", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MFinancialYear where Name like = % Name %");
                List<MFinancialYear_Models> list = new List<MFinancialYear_Models>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MFinancialYear_Models models = new MFinancialYear_Models();
                    models.TrId = Convert.ToInt32(dt.Rows[0]["TrId"]);
                    models.FinancialYear = dt.Rows[0]["FinancialYear"].ToString();
                    models.FYear = dt.Rows[0]["FYear"].ToString();
                    models.YearClose = dt.Rows[0]["YearClose"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                }
            }
            catch (Exception ex)
            {
                MFinancialYear_Models model = new MFinancialYear_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MFinancialYearRepository", "ReportMFinancialYear", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}

    



