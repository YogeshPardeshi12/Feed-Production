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
    public class MExpensesRpository
    {
        public int SaveOrUpdate(MExpenses_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.ExpenseId == 0)
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
            SqlConnection Sqlcon = con.Connect();
            try
            {
                Sqlcmd.CommandText = ("[dbo].[Ado_sp_MExpenses]");
                Sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.Parameters.AddWithValue("@ExpenseId", _Models.ExpenseId);
                Sqlcmd.Parameters.AddWithValue("@CompanyId", _Models.CompanyId);
                Sqlcmd.Parameters.AddWithValue("@Module", _Models.Module);
                Sqlcmd.Parameters.AddWithValue("@ExpenseCode ", _Models.ExpenseCode);
                Sqlcmd.Parameters.AddWithValue("@ExpenseName ", _Models.ExpenseName);
                Sqlcmd.Parameters.AddWithValue("@Specification ", _Models.Specification);
                Sqlcmd.Parameters.AddWithValue("@MaxLimit ", _Models.MaxLimit);
                Sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                Sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy);
                Sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                Sqlcmd.Parameters.AddWithValue("@Remark ", _Models.Remark);
                Sqlcmd.Parameters.AddWithValue("@ProductionFlag ", _Models.ProductionFlag);
                Sqlcmd.Parameters.AddWithValue("@BatchExpense ", _Models.BatchExpense);
                Sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                Sqlcmd.Parameters.AddWithValue("@flag", flag);
                Sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MExpensesRpository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                Sqlcmd.Dispose();
                Sqlcon.Close();

            }
            return _return;
        }
        public int SaveOrUpdateEnity(MExpenses_Models models)
        {
            int _return = 0;
            if (models.ExpenseId == 0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MExpens expenses = new MExpens()
                    {
                        ExpenseId = models.ExpenseId,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        ExpenseCode = models.ExpenseCode,
                        ExpenseName = models.ExpenseName,
                        Specification = models.Specification,
                        MaxLimit = models.MaxLimit,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        ProductionFlag = models.ProductionFlag,
                        BatchExpense = models.BatchExpense
                    };
                    db.Entry(expenses).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MExpens expenses = new MExpens()
                    {
                        ExpenseId = models.ExpenseId,
                        CompanyId = models.CompanyId,
                        Module = models.Module,
                        ExpenseCode = models.ExpenseCode,
                        ExpenseName = models.ExpenseName,
                        Specification = models.Specification,
                        MaxLimit = models.MaxLimit,
                        AcFlag = models.AcFlag,
                        CreatedBy = models.CreatedBy,
                        CreatedOn = models.CreatedOn,
                        Remark = models.Remark,
                        ProductionFlag = models.ProductionFlag,
                        BatchExpense = models.BatchExpense
                    };
                    db.Entry(expenses).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MExpenses_EntityReport().ToList();
            }
        }

        public List<MExpenses_Models> ReportMExpenses()
        {
            List<MExpenses_Models> list = new List<MExpenses_Models>();
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MExpenses");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MExpenses_Models models = new MExpenses_Models();
                    models.ExpenseId = Convert.ToInt32(dt.Rows[i]["ExpenseId"]);
                    models.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"]);
                    models.Module = dt.Rows[i]["Module"].ToString();
                    models.ExpenseCode = dt.Rows[i]["ExpenseCode"].ToString();
                    models.ExpenseName = dt.Rows[i]["ExpenseName"].ToString();
                    models.Specification = dt.Rows[i]["Specification"].ToString();
                    models.MaxLimit = Convert.ToInt32(dt.Rows[i]["MaxLimit"]);
                    models.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    models.Remark = dt.Rows[i]["Remark"].ToString();
                    models.ProductionFlag = dt.Rows[i]["ProductionFlag"].ToString();
                    models.BatchExpense = dt.Rows[i]["BatchExpense"].ToString();
                    list.Add(models);
                }
            }
            catch (Exception ex)
            {
                MExpenses_Models model = new MExpenses_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MExpensesRpository", "ReportMExpenses", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MExpenses where CompanyId =" + id);
                List<MExpenses_Models> list = new List<MExpenses_Models>();
                {
                    MExpenses_Models models = new MExpenses_Models();
                    models.ExpenseId = Convert.ToInt32(dt.Rows[0]["ExpenseId"]);
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.ExpenseCode = dt.Rows[0]["ExpenseCode"].ToString();
                    models.ExpenseName = dt.Rows[0]["ExpenseName"].ToString();
                    models.Specification = dt.Rows[0]["Specification"].ToString();
                    models.MaxLimit = Convert.ToInt32(dt.Rows[0]["MaxLimit"]);
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                    models.ProductionFlag = dt.Rows[0]["ProductionFlag"].ToString();
                    models.BatchExpense = dt.Rows[0]["BatchExpense"].ToString();
                }
            }
            catch (Exception ex)
            {
                MExpenses_Models model = new MExpenses_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MExpensesRpository", "ReportMExpenses", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MExpenses where Name like = % Name %");
                List<MExpenses_Models> list = new List<MExpenses_Models>();
                {
                    MExpenses_Models models = new MExpenses_Models();
                    models.ExpenseId = Convert.ToInt32(dt.Rows[0]["ExpenseId"]);
                    models.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    models.Module = dt.Rows[0]["Module"].ToString();
                    models.ExpenseCode = dt.Rows[0]["ExpenseCode"].ToString();
                    models.ExpenseName = dt.Rows[0]["ExpenseName"].ToString();
                    models.Specification = dt.Rows[0]["Specification"].ToString();
                    models.MaxLimit = Convert.ToInt32(dt.Rows[0]["MaxLimit"]);
                    models.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    models.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                    models.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    models.Remark = dt.Rows[0]["Remark"].ToString();
                    models.ProductionFlag = dt.Rows[0]["ProductionFlag"].ToString();
                    models.BatchExpense = dt.Rows[0]["BatchExpense"].ToString();
                }
            }
            catch (Exception ex)
            {
                MExpenses_Models model = new MExpenses_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MExpensesRpository", "ReportMExpenses", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}


