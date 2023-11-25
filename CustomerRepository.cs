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
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.AccessControl;


namespace Feed_Production.Repository
{
    public class CustomerRepository
    {
        public int SaveOrUpdate(Customer_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.CustomerId == 0)
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
            try
            {
                SqlConnection sqlcon = con.Connect();
                Sqlcmd.CommandText = ("[dbo].[Ado_Sp_MCustomer]");
                Sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                Sqlcmd.Connection = sqlcon;
                Sqlcmd.Parameters.AddWithValue("@CustomerId", _Models.CustomerId);
                Sqlcmd.Parameters.AddWithValue("@CustomerCode", _Models.CustomerCode);
                Sqlcmd.Parameters.AddWithValue("@BrokeragePer ", _Models.BrokeragePer);
                Sqlcmd.Parameters.AddWithValue("@CustomerName ", _Models.CustomerName);
                Sqlcmd.Parameters.AddWithValue("@CustomerAddress ", _Models.CustomerAddress);
                Sqlcmd.Parameters.AddWithValue("@PhoneNo ", _Models.PhoneNo);
                Sqlcmd.Parameters.AddWithValue("@CellNo ", _Models.CellNo);
                Sqlcmd.Parameters.AddWithValue("@BankId ", _Models.BankId);
                Sqlcmd.Parameters.AddWithValue("@AccountNo ", _Models.AccountNo);
                Sqlcmd.Parameters.AddWithValue("@IFSCCode ", _Models.IFSCCode);
                Sqlcmd.Parameters.AddWithValue("@VATNo ", _Models.VATNo);
                Sqlcmd.Parameters.AddWithValue("@CSTNo ", _Models.CSTNo);
                Sqlcmd.Parameters.AddWithValue("@BSTNo ", _Models.BSTNo);
                Sqlcmd.Parameters.AddWithValue("@PANNo ", _Models.PANNo);
                Sqlcmd.Parameters.AddWithValue("@TANNo ", _Models.TANNo);
                Sqlcmd.Parameters.AddWithValue("@EmailId ", _Models.EmailId);
                Sqlcmd.Parameters.AddWithValue("@FAXNo ", _Models.FAXNo);
                Sqlcmd.Parameters.AddWithValue("@ContactPerson ", _Models.ContactPerson);
                Sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                Sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                Sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                Sqlcmd.Parameters.AddWithValue("@Remark ", _Models.Remark);
                Sqlcmd.Parameters.AddWithValue("@BankName ", _Models.BankName);
                Sqlcmd.Parameters.AddWithValue("@BranchName ", _Models.BranchName);
                Sqlcmd.Parameters.AddWithValue("@BankAddress ", _Models.BankAddress);
                Sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                Sqlcmd.Parameters.AddWithValue("@flag", flag.ToString());
                Sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("CustomerRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                Sqlcmd.Dispose();
                
            }
            return _return;
        }
        public int SaveOrUpdateEnity(Customer_Models models)
        {
            int _return = 0;
            if (models.CustomerId == 0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MCustomer customer = new MCustomer()
                    {
                        CustomerId = models.CustomerId,
                        CustomerCode = models.CustomerCode,
                        BrokeragePer = models.BrokeragePer,
                        CustomerName = models.CustomerName,
                        CustomerAddress = models.CustomerAddress,
                        PhoneNo = models.PhoneNo,
                        CellNo = models.CellNo,
                        BankId = models.BankId,
                        AccountNo = models.AccountNo,
                        IFSCCode = models.IFSCCode,
                        VATNo = models.VATNo,
                        CSTNo = models.CSTNo,
                        BSTNo = models.BSTNo,
                        PANNo = models.PANNo,
                        TANNo = models.TANNo,
                        EmailId = models.EmailId,
                        FAXNo = models.FAXNo,
                        ContactPerson = models.ContactPerson,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        BankName = models.BankName,
                        BranchName = models.BranchName,
                        BankAddress = models.BankAddress,
                        EntryType = models.EntryType
                    };
                    db.Entry(customer).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MCustomer customer = new MCustomer()
                    {
                        CustomerId = models.CustomerId,
                        CustomerCode = models.CustomerCode,
                        BrokeragePer = models.BrokeragePer,
                        CustomerName = models.CustomerName,
                        CustomerAddress = models.CustomerAddress,
                        PhoneNo = models.PhoneNo,
                        CellNo = models.CellNo,
                        BankId = models.BankId,
                        AccountNo = models.AccountNo,
                        IFSCCode = models.IFSCCode,
                        VATNo = models.VATNo,
                        CSTNo = models.CSTNo,
                        BSTNo = models.BSTNo,
                        PANNo = models.PANNo,
                        TANNo = models.TANNo,
                        EmailId = models.EmailId,
                        FAXNo = models.FAXNo,
                        ContactPerson = models.ContactPerson,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        BankName = models.BankName,
                        BranchName = models.BranchName,
                        BankAddress = models.BankAddress,
                        EntryType=models.EntryType

                    };
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MCustomer_EntityReport().ToList();
            }
        }
        public List<Customer_Models> ReportMCustomer()
        {
            List<Customer_Models> list = new List<Customer_Models>();
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MCustomer");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Customer_Models model = new Customer_Models();
                    model.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                    model.CustomerCode = dt.Rows[i]["CustomerCode"].ToString();
                    model.BrokeragePer = dt.Rows[i]["BrokeragePer"].ToString();
                    model.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                    model.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                    model.PhoneNo = dt.Rows[i]["PhoneNo"].ToString();
                    model.CellNo = dt.Rows[i]["CellNo"].ToString();
                    model.BankId = Convert.ToInt32(dt.Rows[i]["BankId"]);
                    model.AccountNo = dt.Rows[i]["AccountNo"].ToString();
                    model.IFSCCode = dt.Rows[i]["IFSCCode"].ToString();
                    model.VATNo = dt.Rows[i]["VATNo"].ToString();
                    model.CSTNo = dt.Rows[i]["CSTNo"].ToString();
                    model.BSTNo = dt.Rows[i]["BSTNo"].ToString();
                    model.PANNo = dt.Rows[i]["PANNo"].ToString();
                    model.TANNo = dt.Rows[i]["TANNo"].ToString();
                    model.EmailId = dt.Rows[i]["EmailId"].ToString();
                    model.FAXNo = dt.Rows[i]["FAXNo"].ToString();
                    model.ContactPerson = dt.Rows[i]["ContactPerson"].ToString();
                    model.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    model.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                    model.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    model.Remark = dt.Rows[i]["Remark"].ToString();
                    model.BankName = dt.Rows[i]["BankName"].ToString();
                    model.BranchName = dt.Rows[i]["BranchName"].ToString();
                    model.BankAddress = dt.Rows[i]["BankAddress"].ToString();
                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                Customer_Models model = new Customer_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("CustomerRepository", "ReportMCustomer", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MCustomer where CustomerId=" + id);
                List<Customer_Models> list = new List<Customer_Models>();
                {
                    Customer_Models model = new Customer_Models();
                    model.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                    model.CustomerCode = dt.Rows[0]["CustomerCode"].ToString();
                    model.BrokeragePer = dt.Rows[0]["BrokeragePer"].ToString();
                    model.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                    model.CustomerAddress = dt.Rows[0]["CustomerAddress"].ToString();
                    model.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    model.CellNo = dt.Rows[0]["CellNo"].ToString();
                    model.BankId = Convert.ToInt32(dt.Rows[0]["BankId"]);
                    model.AccountNo = dt.Rows[0]["AccountNo"].ToString();
                    model.IFSCCode = dt.Rows[0]["IFSCCode"].ToString();
                    model.VATNo = dt.Rows[0]["VATNo"].ToString();
                    model.CSTNo = dt.Rows[0]["CSTNo"].ToString();
                    model.BSTNo = dt.Rows[0]["BSTNo"].ToString();
                    model.PANNo = dt.Rows[0]["PANNo"].ToString();
                    model.TANNo = dt.Rows[0]["TANNo"].ToString();
                    model.EmailId = dt.Rows[0]["EmailId"].ToString();
                    model.FAXNo = dt.Rows[0]["FAXNo"].ToString();
                    model.ContactPerson = dt.Rows[0]["ContactPerson"].ToString();
                    model.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    model.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    model.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    model.Remark = dt.Rows[0]["Remark"].ToString();
                    model.BankName = dt.Rows[0]["BankName"].ToString();
                    model.BranchName = dt.Rows[0]["BranchName"].ToString();
                    model.BankAddress = dt.Rows[0]["BankAddress"].ToString();
                }
            }
            catch(Exception ex)
            {
                Customer_Models model = new Customer_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("CustomerRepository", "ReportMCustomer", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
          public void GetByName(string CustomerName)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                string query = "Select*from MCompany where CompanyName like '%" + CustomerName + "%'";
                DataTable dt = new DataTable();
                dt = con.Report(query);
                List<Customer_Models> list = new List<Customer_Models>();
                {
                    Customer_Models model = new Customer_Models();
                    model.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                    model.CustomerCode = dt.Rows[0]["CustomerCode"].ToString();
                    model.BrokeragePer = dt.Rows[0]["BrokeragePer"].ToString();
                    model.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                    model.CustomerAddress = dt.Rows[0]["CustomerAddress"].ToString();
                    model.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    model.CellNo = dt.Rows[0]["CellNo"].ToString();
                    model.BankId = Convert.ToInt32(dt.Rows[0]["BankId"]);
                    model.AccountNo = dt.Rows[0]["AccountNo"].ToString();
                    model.IFSCCode = dt.Rows[0]["IFSCCode"].ToString();
                    model.VATNo = dt.Rows[0]["VATNo"].ToString();
                    model.CSTNo = dt.Rows[0]["CSTNo"].ToString();
                    model.BSTNo = dt.Rows[0]["BSTNo"].ToString();
                    model.PANNo = dt.Rows[0]["PANNo"].ToString();
                    model.TANNo = dt.Rows[0]["TANNo"].ToString();
                    model.EmailId = dt.Rows[0]["EmailId"].ToString();
                    model.FAXNo = dt.Rows[0]["FAXNo"].ToString();
                    model.ContactPerson = dt.Rows[0]["ContactPerson"].ToString();
                    model.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    model.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    model.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    model.Remark = dt.Rows[0]["Remark"].ToString();
                    model.BankName = dt.Rows[0]["BankName"].ToString();
                    model.BranchName = dt.Rows[0]["BranchName"].ToString();
                    model.BankAddress = dt.Rows[0]["BankAddress"].ToString();
                }
            }
            catch (Exception ex)
            {
                Customer_Models model = new Customer_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("CustomerRepository", "ReportMCustomer", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
     }
}



