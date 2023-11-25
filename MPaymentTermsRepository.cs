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
    public class MPaymentTermsRepository
    {
        public int SaveOrUpdate(MPaymentTerms_Models _Models)
        {
            int _return;
            string flag = "";
            if (_Models.PaymentTermId == 0)
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
                sqlcmd.CommandText = ("[dbo].[Ado_Sp_MPaymentTerms]");
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@PaymentTermId", _Models.PaymentTermId);
                sqlcmd.Parameters.AddWithValue("@PaymentTermCode ", _Models.PaymentTermCode);
                sqlcmd.Parameters.AddWithValue("@PaymentTermDescription ", _Models.PaymentTermDescription);
                sqlcmd.Parameters.AddWithValue("@Days ", _Models.Days);
                sqlcmd.Parameters.AddWithValue("@AcFlag ", _Models.AcFlag);
                sqlcmd.Parameters.AddWithValue("@CreatedBy ", _Models.CreatedBy.ToString());
                sqlcmd.Parameters.AddWithValue("@CreatedOn ", _Models.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@Remarks ", _Models.Remarks);
                sqlcmd.Parameters.AddWithValue("@EntryType", _Models.EntryType);
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _return = 0;
                ClsFunction function = new ClsFunction();
                function.Errorlog("MPaymentTermsRepository", "SaveOrUpdate", ex.Message.ToString(), _Models.ToString(), " ", System.DateTime.Now);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return _return;
        }
        public int SaveOrUpdateEntity(MPaymentTerms_Models model)
        {
            int _return = 0;
            if (model.PaymentTermId == 0)
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MPaymentTerm paymentTerm = new MPaymentTerm()
                    {
                        PaymentTermId = model.PaymentTermId,
                        PaymentTermCode = model.PaymentTermCode,
                        PaymentTermDescription = model.PaymentTermDescription,
                        Days = model.Days,
                        AcFlag = model.AcFlag,
                        CreatedBy = model.CreatedBy,
                        CreatedOn = model.CreatedOn,
                        Remarks = model.Remarks

                    };
                    db.Entry(paymentTerm).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbEntitty db = new DbEntitty())
                {
                    MPaymentTerm paymentTerm = new MPaymentTerm()
                    {
                        PaymentTermId = model.PaymentTermId,
                        PaymentTermCode = model.PaymentTermCode,
                        PaymentTermDescription = model.PaymentTermDescription,
                        Days = model.Days,
                        AcFlag = model.AcFlag,
                        CreatedBy = model.CreatedBy,
                        CreatedOn = model.CreatedOn,
                        Remarks = model.Remarks

                    };
                    db.Entry(paymentTerm).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            return _return;
        }
        public void ReportEnity()
        {
            using (DbEntitty db = new DbEntitty())
            {
                var report = db.Sp_MPaymentTerms_EntityReport().ToList();
            }
        }

        public void ReportMPaymentTerms()
        {
            try
            {
                Connection con = new Connection();
                SqlConnection sqlcon = con.Connect();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                DataTable dt = new DataTable();
                dt = con.Report("Select * from MPaymentTerms");
                List<MPaymentTerms_Models> list = new List<MPaymentTerms_Models>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MPaymentTerms_Models model = new MPaymentTerms_Models();
                    model.PaymentTermId = Convert.ToInt32(dt.Rows[i]["PaymentTermId"]);
                    model.PaymentTermCode = dt.Rows[i]["PaymentTermCode"].ToString();
                    model.PaymentTermDescription = dt.Rows[i]["PaymentTermDescription"].ToString();
                    model.Days = dt.Rows[i]["Days"].ToString();
                    model.AcFlag = dt.Rows[i]["AcFlag"].ToString();
                    model.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                    model.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    model.Remarks = dt.Rows[i]["Remarks"].ToString();
                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                MPaymentTerms_Models model = new MPaymentTerms_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPaymentTermsRepository", "ReportMPaymentTerms", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MPaymentTerms where CompanyId =" + id);
                List<MPaymentTerms_Models> list = new List<MPaymentTerms_Models>();
                {
                    MPaymentTerms_Models model = new MPaymentTerms_Models();
                    model.PaymentTermId = Convert.ToInt32(dt.Rows[0]["PaymentTermId"]);
                    model.PaymentTermCode = dt.Rows[0]["PaymentTermCode"].ToString();
                    model.PaymentTermDescription = dt.Rows[0]["PaymentTermDescription"].ToString();
                    model.Days = dt.Rows[0]["Days"].ToString();
                    model.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    model.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    model.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    model.Remarks = dt.Rows[0]["Remarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                MPaymentTerms_Models model = new MPaymentTerms_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPaymentTermsRepository", "ReportMPaymentTerms", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
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
                dt = con.Report("Select * from MPaymentTerms where Name like = % Name %");
                List<MPaymentTerms_Models> list = new List<MPaymentTerms_Models>();
                {
                    MPaymentTerms_Models model = new MPaymentTerms_Models();
                    model.PaymentTermId = Convert.ToInt32(dt.Rows[0]["PaymentTermId"]);
                    model.PaymentTermCode = dt.Rows[0]["PaymentTermCode"].ToString();
                    model.PaymentTermDescription = dt.Rows[0]["PaymentTermDescription"].ToString();
                    model.Days = dt.Rows[0]["Days"].ToString();
                    model.AcFlag = dt.Rows[0]["AcFlag"].ToString();
                    model.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    model.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    model.Remarks = dt.Rows[0]["Remarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                MPaymentTerms_Models model = new MPaymentTerms_Models();
                ClsFunction cls = new ClsFunction();
                cls.Errorlog("MPaymentTermsRepository", "ReportMPaymentTerms", ex.Message.ToString(), model.ToString(), "", System.DateTime.Now);
            }
            finally
            {

            }
        }
    }
}

    

