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
using System.Security.Cryptography;

namespace Feed_Production.Repository
{
    public class MOpeningBalanceRepository
    {
        public int SaveOrUpdate(MOpningBalnce_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.TID == 0)
            {
                _return= 1;
                flag = "I";
            }
            else
            {
                _return= 2;
                flag = "U";
            }
            SqlCommand sqlcmd = new SqlCommand();
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            try
            {
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MOpningBalnce]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@TID", _Models.TID);
                sqlcmd.Parameters.AddWithValue("@CompanyId ", _Models.CompanyId);
                sqlcmd.Parameters.AddWithValue("@Module ", _Models.Module);
                sqlcmd.Parameters.AddWithValue("@TCode ", _Models.TCode);
                sqlcmd.Parameters.AddWithValue("@CustomerId ", _Models.CustomerId);
                sqlcmd.Parameters.AddWithValue("@AcType ", _Models.AcType);
                sqlcmd.Parameters.AddWithValue("@FYear ", _Models.FYear);
                sqlcmd.Parameters.AddWithValue("@OpeningBal ", _Models.OpeningBal);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@Remark ", _Models.Remark);
                sqlcmd.Parameters.AddWithValue("@ProductTypeId ", _Models.ProductTypeId);
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MOpeningBalanceRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MOpningBalnce_Models models)
        {
            int _return = 0;
            if (models.TID == 0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MOpningBalnce MOpning = new MOpningBalnce
                    {
                        TID = models.TID,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        TCode = models.TCode,
                        CustomerId = models.CustomerId,
                        AcType = models.AcType,
                        FYear = models.FYear,
                        OpeningBal = models.OpeningBal,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        ProductTypeId = models.ProductTypeId

                    };
                    db.Entry(MOpning).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MOpningBalnce MOpning = new MOpningBalnce
                    {
                        TID = models.TID,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        TCode = models.TCode,
                        CustomerId = models.CustomerId,
                        AcType = models.AcType,
                        FYear = models.FYear,
                        OpeningBal = models.OpeningBal,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        ProductTypeId = models.ProductTypeId

                    };
                    db.Entry(MOpning).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MOpningBalnce_EntityReport().ToList();
            }
        }
        public void ReportMOpeningBalance()
            {
                try
                {
                    Connection con = new Connection();
                    SqlConnection sqlcon = con.Connect();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    DataTable dt = new DataTable();
                    dt = con.Report("Select * from MOpeningBalance");
                    List<MOpningBalnce_Models> list = new List<MOpningBalnce_Models>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MOpningBalnce_Models models = new MOpningBalnce_Models();
                        models.TID = Convert.ToInt32(dt.Rows[i]["TID"]);
                        models.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"]);
                        models.Module = dt.Rows[i]["Module"].ToString();
                        models.TCode = dt.Rows[i]["TCode"].ToString();
                        models.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                        models.AcType = dt.Rows[i]["AcType"].ToString();
                        models.FYear = dt.Rows[i]["FYear"].ToString();
                        models.OpeningBal = Convert.ToInt32(dt.Rows[i]["OpeningBal"]);
                        models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                        models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                        models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CompanyId"]);
                        models.Remark = dt.Rows[i]["Remark"].ToString();
                        models.ProductTypeId = Convert.ToInt32(dt.Rows[i]["ProductTypeId"]);
                        list.Add(models);
                    }
                }
                catch (Exception ex)
                {
                    MPOTerms_Models model = new MPOTerms_Models();
                    ClsFunction cls = new ClsFunction();
                    cls.Errorlog("MOpeningBalanceRepository", "ReportMOpeningBalance", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                    dt = con.Report("Select * from MOpningBalnce where CompanyId =" + id);
                    List<MOpningBalnce_Models> list = new List<MOpningBalnce_Models>();
                    {
                        MOpningBalnce_Models models = new MOpningBalnce_Models();
                        models.TID = Convert.ToInt32(dt.Rows[0]["TID"]);
                        models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                        models.Module = dt.Rows[0]["Module"].ToString();
                        models.TCode = dt.Rows[0]["TCode"].ToString();
                        models.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                        models.AcType = dt.Rows[0]["AcType"].ToString();
                        models.FYear = dt.Rows[0]["FYear"].ToString();
                        models.OpeningBal = Convert.ToInt32(dt.Rows[0]["OpeningBal"]);
                        models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                        models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                        models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CompanyId"]);
                        models.Remark = dt.Rows[0]["Remark"].ToString();
                        models.ProductTypeId = Convert.ToInt32(dt.Rows[0]["ProductTypeId"]);
                    }
                }
                catch (Exception ex)
                {
                    MPOTerms_Models model = new MPOTerms_Models();
                    ClsFunction cls = new ClsFunction();
                    cls.Errorlog("MOpeningBalanceRepository", "ReportMOpeningBalance", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                    dt = con.Report("Select * from MOpningBalnce where Name like = % Name %");
                    List<MOpningBalnce_Models> list = new List<MOpningBalnce_Models>();
                    {
                        MOpningBalnce_Models models = new MOpningBalnce_Models();
                        models.TID = Convert.ToInt32(dt.Rows[0]["TID"]);
                        models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                        models.Module = dt.Rows[0]["Module"].ToString();
                        models.TCode = dt.Rows[0]["TCode"].ToString();
                        models.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                        models.AcType = dt.Rows[0]["AcType"].ToString();
                        models.FYear = dt.Rows[0]["FYear"].ToString();
                        models.OpeningBal = Convert.ToInt32(dt.Rows[0]["OpeningBal"]);
                        models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                        models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                        models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CompanyId"]);
                        models.Remark = dt.Rows[0]["Remark"].ToString();
                        models.ProductTypeId = Convert.ToInt32(dt.Rows[0]["ProductTypeId"]);
                    }
                }
                catch (Exception ex)
                {
                    MPOTerms_Models model = new MPOTerms_Models();
                    ClsFunction cls = new ClsFunction();
                    cls.Errorlog("MOpeningBalanceRepository", "ReportMOpeningBalance", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
                }
                finally
                {

                }
            }
        }
    } 

