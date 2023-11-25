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
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using DataContext; 

namespace Feed_Production.Repository
{
    public class CompanyRepository
    {

        public int SaveOrUpdate(Company_Models _Models)
        {
            int _return;
            string ErrorData = "@CompanyId" + _Models.CompanyId +
                "@CompanyCode" + _Models.CompanyCode +
                "@CompanyName" + _Models.CompanyName +
                "@CompanyAddress" + _Models.CompanyAdddess +
                "@PhoneNo" + _Models.PhoneNo +
                "@CellNo" + _Models.CellNo +
                "@EmailId" + _Models.EmailId +
                "@PanNo" + _Models.PANNo +
                "@CST" + _Models.CST +
                "@BST" + _Models.BST +
                "@AcFlag" + _Models.AcFlag +
                "@CreatedBy" + _Models.CreatedBy +
                "@CreatedOn" + _Models.CreatedOn +
                "@Remark" + _Models.Remark +
                "@TallyId" + _Models.TallyId;
            
            String flag = "";
            if (_Models.CompanyId == 0)
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
            SqlConnection Sqlcon = con.Connect();
            try
            {
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MCompany]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = Sqlcon;
                sqlcmd.Parameters.AddWithValue("@Companyid", _Models.CompanyId);
                sqlcmd.Parameters.AddWithValue("@CompanyCode", _Models.CompanyCode.ToString());
                sqlcmd.Parameters.AddWithValue("@CompanyName ", _Models.CompanyName.ToString());
                sqlcmd.Parameters.AddWithValue("@CompanyAdddess ", _Models.CompanyAdddess.ToString());
                sqlcmd.Parameters.AddWithValue("@PhoneNo ", _Models.PhoneNo.ToString());
                sqlcmd.Parameters.AddWithValue("@CellNo ", _Models.CellNo.ToString());
                sqlcmd.Parameters.AddWithValue("@EmailId ", _Models.EmailId.ToString());
                sqlcmd.Parameters.AddWithValue("@PANNo ", _Models.PANNo.ToString());
                sqlcmd.Parameters.AddWithValue("@CST ", _Models.CST.ToString());
                sqlcmd.Parameters.AddWithValue("@BST ", _Models.BST.ToString());
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag.ToString());
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy.ToString());
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@Remark ", _Models.Remark.ToString());
                sqlcmd.Parameters.AddWithValue("@TallyId ", _Models.TallyId.ToString());
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType.ToString());
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("CompanyRepository", "SaveOrUpdate", ex.Message.ToString(), ErrorData, " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                Sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEnity(Company_Models models)
        {
            int _return = 0;
            try
            {
                long Letest_Id;
                if (models.CompanyId == 0)
                {
                    using (DbEntitty db = new DbEntitty())
                    {
                        using (var Transaction = db.Database.BeginTransaction())
                        {
                            try
                            {

                                MCompany company = new MCompany()
                                {
                                    CompanyCode = models.CompanyCode,
                                    CompanyName = models.CompanyName,
                                    CompanyAdddess = models.CompanyAdddess,
                                    PhoneNo = models.PhoneNo,
                                    CellNo = models.CellNo,
                                    EmailId = models.EmailId,
                                    PANNo = models.PANNo,
                                    CST = models.CST,
                                    BST = models.BST,
                                    AcFlag = models.AcFlag,
                                    CreatedBy = models.CreatedBy,
                                    CreatedOn = models.CreatedOn,
                                    Remark = models.Remark,
                                    TallyId = models.TallyId,
                                    EntryType = models.EntryType
                                };
                                db.Entry(company).State = System.Data.Entity.EntityState.Added;
                                db.SaveChanges();
                                Letest_Id = models.CompanyId;
                            }
                            catch (Exception ex)
                            {
                                Transaction.Rollback();
                            }
                            finally
                            {
                                Transaction.Commit();
                                Transaction.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    using (DbEntitty db = new DbEntitty())
                    {
                        MCompany company = new MCompany()
                        {
                            CompanyId = models.CompanyId,
                            CompanyCode = models.CompanyCode,
                            CompanyName = models.CompanyName,
                            CompanyAdddess = models.CompanyAdddess,
                            PhoneNo = models.PhoneNo,
                            CellNo = models.CellNo,
                            EmailId = models.EmailId,
                            PANNo = models.PANNo,
                            CST = models.CST,
                            BST = models.BST,
                            AcFlag = models.AcFlag,
                            CreatedBy = models.CreatedBy,
                            CreatedOn = models.CreatedOn,
                            Remark = models.Remark,
                            TallyId = models.TallyId,
                            EntryType= models.EntryType,

                        };
                        db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                ClsFunction function = new ClsFunction();
                function.ErrorlogEnity("CompanyRepository", "SaveOrUpdate", ex.Message.ToString(), "ErrorData", " ", System.DateTime.Now);
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MCompany_EntityReport().ToList();
            }
        }

        public List<Company_Models> ReportMCompany()
        {
            List<Company_Models> list = new List<Company_Models>();

            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MCompany");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Company_Models models = new Company_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"]);
                    models.CompanyCode = dt.Rows[i]["CompanyCode"].ToString();
                    models.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                    models.CompanyAdddess = dt.Rows[i]["CompanyAdddess"].ToString();
                    models.PhoneNo = dt.Rows[i]["PhoneNo"].ToString();
                    models.CellNo = dt.Rows[i]["CellNo"].ToString();
                    models.EmailId = dt.Rows[i]["EmailId"].ToString();
                    models.PANNo = dt.Rows[i]["PANNo"].ToString();
                    models.CST = dt.Rows[i]["CST"].ToString();
                    models.BST = dt.Rows[i]["BST"].ToString();
                    models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    models.Remark = dt.Rows[i]["Remark"].ToString();
                    models.TallyId = dt.Rows[i]["TallyId"].ToString();
                    list.Add(models);
                }

            }
            catch (Exception ex)
            {
                Company_Models model = new Company_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MCompanyRepo", "ReportMCompany", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MCompany where CompanyId =" + id);
                {
                    Company_Models models = new Company_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.CompanyCode = dt.Rows[0]["CompanyCode"].ToString();
                    models.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    models.CompanyAdddess = dt.Rows[0]["CompanyAdddess"].ToString();
                    models.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    models.CellNo = dt.Rows[0]["CellNo"].ToString();
                    models.EmailId = dt.Rows[0]["EmailId"].ToString();
                    models.PANNo = dt.Rows[0]["PANNo"].ToString();
                    models.CST = dt.Rows[0]["CST"].ToString();
                    models.BST = dt.Rows[0]["BST"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                    models.TallyId = dt.Rows[0]["TallyId"].ToString();
                }

            }
            catch (Exception ex)
            {
                Company_Models model = new Company_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MCompanyRepo", "ReportMCompany", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
        public void GetByName(string CompanyName)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                string query = "Select*from MCompany where CompanyName like '%" + CompanyName + "%'";
                dt = con.Report(query);
                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    Company_Models models = new Company_Models();
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.CompanyCode = dt.Rows[0]["CompanyCode"].ToString();
                    models.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    models.CompanyAdddess = dt.Rows[0]["CompanyAdddess"].ToString();
                    models.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    models.CellNo = dt.Rows[0]["CellNo"].ToString();
                    models.EmailId = dt.Rows[0]["EmailId"].ToString();
                    models.PANNo = dt.Rows[0]["PANNo"].ToString();
                    models.CST = dt.Rows[0]["CST"].ToString();
                    models.BST = dt.Rows[0]["BST"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                    models.TallyId = dt.Rows[0]["TallyId"].ToString();

                }

            }
            catch (Exception ex)
            {
                Company_Models model = new Company_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MCompanyRepo", "ReportMCompany", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
    
    


