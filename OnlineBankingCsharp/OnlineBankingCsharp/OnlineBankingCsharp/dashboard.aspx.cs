using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace OnlineBankingCsharp
{
    public partial class dashboard : System.Web.UI.Page
    {
        public string txtID;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLastID();
        }

        public void CheckLastID()
        {
            try
            {

                string dsm;
                SqlDataReader sqldataReader;
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
                dsm = "select AccountNumber from tbl_Transaction where AccountNumber ='" + Session["AcctNum"].ToString() + "'";
                sql.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = dsm;
                command.Connection = sql;
                sqldataReader = command.ExecuteReader();

                if (sqldataReader.Read())
                {
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
                    sqlConnection.Open();

                    string sm = "select Max(Id) from tbl_Transaction where AccountNumber ='" + Session["AcctNum"].ToString() + "'";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sm;
                    sqlCommand.Connection = sqlConnection;

                    object o = sqlCommand.ExecuteScalar();
                    txtID = o.ToString();

                    sqlConnection.Close();

                    CheckBalance();
                }
                else
                {

                }

                sqldataReader.Close();

            }
            catch (Exception)
            {
                

            }

        }

        public void CheckBalance()
        {
            try
            {
                SqlConnection conet = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                conet.Open();

                string strcom = "select Balance from tbl_Transaction where Id='" + txtID + "'";
                SqlDataAdapter daDetails = new SqlDataAdapter(strcom, conet);
                DataSet dsDetails = new DataSet();
                daDetails.Fill(dsDetails);

                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    lblBalance.Text = "NGN " + dsDetails.Tables[0].Rows[0][0].ToString();
                }

            }
            catch (Exception)
            {

            }
        }
    }
}