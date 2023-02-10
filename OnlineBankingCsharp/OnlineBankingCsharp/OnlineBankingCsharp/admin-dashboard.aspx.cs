using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace OnlineBankingCsharp
{
    public partial class admin_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TotalCus();
            TotalDeposit();
            TotalWithrawal();
        }

        public void TotalCus()
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constring))
                {
                    using (SqlCommand comd = new SqlCommand("SELECT COUNT(*) as Count FROM Customer", cnn))
                    {
                        comd.CommandType = CommandType.Text;
                        cnn.Open();
                        object o = comd.ExecuteScalar();
                        if (o != null)
                        {
                            lblTotalCust.Text = o.ToString();

                        }
                        cnn.Close();

                    }
                }

            }
            catch (Exception)
            {
                //
            }
        }

        public void TotalDeposit()
        {
            try
            {
                string cnnstring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(cnnstring))
                {
                    using (SqlCommand cmd = new SqlCommand("Select SUM(Credit) as Deposit FROM tbl_Transaction", cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        object obj = cmd.ExecuteScalar();
                        lblTotalDeposit.Text = "₦ " + obj.ToString();
                        //if (o != null)
                        //{
                        //    lblTotalDeposit.Text = o.ToString();

                        //}
                        cnn.Close();

                    }
                }

            }
            catch (Exception)
            {
                //
            }
        }

        public void TotalWithrawal()
        {
            try
            {
                string Connectstring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(Connectstring))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Select SUM(Debit) as Withdraw FROM tbl_Transaction", sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCon.Open();
                        object objVal = sqlCommand.ExecuteScalar();
                        lblTotalWithdrawal.Text = "₦ " + objVal.ToString();
                        //if (o != null)
                        //{
                        //    lblTotalDeposit.Text = o.ToString();

                        //}
                        sqlCon.Close();

                    }
                }

            }
            catch (Exception)
            {
                //
            }
        }
    }
}