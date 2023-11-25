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
using System.Runtime.InteropServices;
using System.Data;
using DataContext;
using System.Security.AccessControl;

namespace Feed_Production.Repository
{
    public class MSupplierRepository
    {
        public int SaveOrUpdate(MSupplier_Models Models)
        {
            int _return;
            string flag = "";
            if(Models.SupplierId==0)
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
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MSupplier]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@SupplierId ", Models.SupplierId);
                sqlcmd.Parameters.AddWithValue("@SupplierCode ", Models.SupplierCode);
                sqlcmd.Parameters.AddWithValue("@BrokeragePer ", Models.BrokeragePer);
                sqlcmd.Parameters.AddWithValue("@SupplierName ", Models.SupplierName);
                sqlcmd.Parameters.AddWithValue("@SupplierAddress ", Models.SupplierAddress);
                sqlcmd.Parameters.AddWithValue("@PhoneNo ", Models.PhoneNo);
                sqlcmd.Parameters.AddWithValue("@CellNo ", Models.CellNo);
                sqlcmd.Parameters.AddWithValue("@VATNo ", Models.VATNo);
                sqlcmd.Parameters.AddWithValue("@CSTNo ", Models.CSTNo);
                sqlcmd.Parameters.AddWithValue("@BSTNo ", Models.BSTNo);
                sqlcmd.Parameters.AddWithValue("@PANNo ", Models.PANNo);
                sqlcmd.Parameters.AddWithValue("@TANNo ", Models.TANNo);
                sqlcmd.Parameters.AddWithValue("@EmailId ", Models.EmailId);
                sqlcmd.Parameters.AddWithValue("@FAXNo ", Models.FAXNo);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", Models.CreatedBy);
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@Remark ", Models.Remark);
                sqlcmd.Parameters.AddWithValue("@AccountNo ", Models.AccountNo);
                sqlcmd.Parameters.AddWithValue("@BankName ", Models.BankName);
                sqlcmd.Parameters.AddWithValue("@BranchName ", Models.BranchName);
                sqlcmd.Parameters.AddWithValue("@BankAddress ", Models.BankAddress);
                sqlcmd.Parameters.AddWithValue("@EntryType", Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MSupplierRepository", "SaveOrUpdate", ex.Message.ToString(), Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEnity(MSupplier_Models models)
        {
            int _return = 0;
            if(models.SupplierId == 0)
            {
                using(DbEntitty db = new DbEntitty())
                {
                    MSupplier supplier = new MSupplier()
                    {
                        SupplierId = models.SupplierId,
                        SupplierCode = models.SupplierCode,
                        BrokeragePer = models.BrokeragePer,
                        SupplierName = models.SupplierName,
                        SupplierAddress = models.SupplierAddress,
                        PhoneNo = models.PhoneNo,
                        CellNo = models.CellNo,
                        VATNo = models.VATNo,
                        CSTNo = models.CSTNo,
                        BSTNo = models.BSTNo,
                        PANNo = models.PANNo,
                        TANNo = models.TANNo,
                        EmailId = models.EmailId,
                        FAXNo = models.FAXNo,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        AccountNo = models.AccountNo,
                        BankName = models.BankName,
                        BranchName = models.BranchName,
                        BankAddress = models.BankAddress

                    };
                    db.Entry(supplier).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MSupplier supplier = new MSupplier()
                    {
                        SupplierId = models.SupplierId,
                        SupplierCode = models.SupplierCode,
                        BrokeragePer = models.BrokeragePer,
                        SupplierName = models.SupplierName,
                        SupplierAddress = models.SupplierAddress,
                        PhoneNo = models.PhoneNo,
                        CellNo = models.CellNo,
                        VATNo = models.VATNo,
                        CSTNo = models.CSTNo,
                        BSTNo = models.BSTNo,
                        PANNo = models.PANNo,
                        TANNo = models.TANNo,
                        EmailId = models.EmailId,
                        FAXNo = models.FAXNo,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        AccountNo = models.AccountNo,
                        BankName = models.BankName,
                        BranchName = models.BranchName,
                        BankAddress = models.BankAddress

                    };
                    db.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MSupplier_EntityReport().ToList();
            }
        }
        public void ReportMSupplier()
        {
            try
            { 
            Connection con = new Connection();
            SqlConnection sqlcon = con.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            DataTable dt = new DataTable();
            dt = con.Report("Select * from MSupplier");
            List<MSupplier_Models> list = new List<MSupplier_Models>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MSupplier_Models models = new MSupplier_Models();
                models.SupplierId = Convert.ToInt32(dt.Rows[i]["SupplierId"]);
                models.SupplierCode = dt.Rows[i]["SupplierCode"].ToString();
                models.BrokeragePer = dt.Rows[i]["BrokeragePer"].ToString();
                models.SupplierName = dt.Rows[i]["SupplierName"].ToString();
                models.SupplierAddress = dt.Rows[i]["SupplierAddress"].ToString();
                models.PhoneNo = dt.Rows[i]["PhoneNo"].ToString();
                models.CellNo = dt.Rows[i]["CellNo"].ToString();
                models.VATNo = dt.Rows[i]["VATNo"].ToString();
                models.CSTNo = dt.Rows[i]["CSTNo"].ToString();
                models.BSTNo = dt.Rows[i]["BSTNo"].ToString();
                models.PANNo = dt.Rows[i]["PANNo"].ToString();
                models.TANNo = dt.Rows[i]["TANNo"].ToString();
                models.EmailId = dt.Rows[i]["EmailId"].ToString();
                models.FAXNo = dt.Rows[i]["FAXNo"].ToString();
                models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                models.Remark = dt.Rows[i]["Remark"].ToString();
                models.AccountNo = dt.Rows[i]["AccountNo"].ToString();
                models.BankName = dt.Rows[i]["BankName"].ToString();
                models.BranchName = dt.Rows[i]["BranchName"].ToString();
                models.BankAddress = dt.Rows[i]["BankAddress"].ToString();
                list.Add(models);

            }
        }
            catch(Exception ex)
            {
                MSupplier_Models model = new MSupplier_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MSupplierRepository", "ReportMSupplier", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                List<MSupplier_Models> list = new List<MSupplier_Models>();
                {
                    MSupplier_Models models = new MSupplier_Models();
                    models.SupplierId = Convert.ToInt32(dt.Rows[0]["SupplierId"]);
                    models.SupplierCode = dt.Rows[0]["SupplierCode"].ToString();
                    models.BrokeragePer = dt.Rows[0]["BrokeragePer"].ToString();
                    models.SupplierName = dt.Rows[0]["SupplierName"].ToString();
                    models.SupplierAddress = dt.Rows[0]["SupplierAddress"].ToString();
                    models.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    models.CellNo = dt.Rows[0]["CellNo"].ToString();
                    models.VATNo = dt.Rows[0]["VATNo"].ToString();
                    models.CSTNo = dt.Rows[0]["CSTNo"].ToString();
                    models.BSTNo = dt.Rows[0]["BSTNo"].ToString();
                    models.PANNo = dt.Rows[0]["PANNo"].ToString();
                    models.TANNo = dt.Rows[0]["TANNo"].ToString();
                    models.EmailId = dt.Rows[0]["EmailId"].ToString();
                    models.FAXNo = dt.Rows[0]["FAXNo"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                    models.AccountNo = dt.Rows[0]["AccountNo"].ToString();
                    models.BankName = dt.Rows[0]["BankName"].ToString();
                    models.BranchName = dt.Rows[0]["BranchName"].ToString();
                    models.BankAddress = dt.Rows[0]["BankAddress"].ToString();

                }
            }
            catch (Exception ex)
            {
                MSupplier_Models model = new MSupplier_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MSupplierRepository", "ReportMSupplier", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
        public void GetByName(int id)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MCompany where Name like = % Name %");
                List<MSupplier_Models> list = new List<MSupplier_Models>();
                {
                    MSupplier_Models models = new MSupplier_Models();
                    models.SupplierId = Convert.ToInt32(dt.Rows[0]["SupplierId"]);
                    models.SupplierCode = dt.Rows[0]["SupplierCode"].ToString();
                    models.BrokeragePer = dt.Rows[0]["BrokeragePer"].ToString();
                    models.SupplierName = dt.Rows[0]["SupplierName"].ToString();
                    models.SupplierAddress = dt.Rows[0]["SupplierAddress"].ToString();
                    models.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    models.CellNo = dt.Rows[0]["CellNo"].ToString();
                    models.VATNo = dt.Rows[0]["VATNo"].ToString();
                    models.CSTNo = dt.Rows[0]["CSTNo"].ToString();
                    models.BSTNo = dt.Rows[0]["BSTNo"].ToString();
                    models.PANNo = dt.Rows[0]["PANNo"].ToString();
                    models.TANNo = dt.Rows[0]["TANNo"].ToString();
                    models.EmailId = dt.Rows[0]["EmailId"].ToString();
                    models.FAXNo = dt.Rows[0]["FAXNo"].ToString();
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                    models.AccountNo = dt.Rows[0]["AccountNo"].ToString();
                    models.BankName = dt.Rows[0]["BankName"].ToString();
                    models.BranchName = dt.Rows[0]["BranchName"].ToString();
                    models.BankAddress = dt.Rows[0]["BankAddress"].ToString();

                }
            }
            catch (Exception ex)
            {
                MSupplier_Models model = new MSupplier_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MSupplierRepository", "ReportMSupplier", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}
    

