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
    public partial class statement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }

        protected void BindGridview()
        {
            string AccNo = Session["AcctNum"].ToString();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_Transaction where AccountNumber ='" + AccNo + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridview();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string AccNo = Session["AcctNum"].ToString();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_Transaction where AccountNumber ='" + AccNo + "' and Date >= '" + DateFrom.Text + "' and Date <= '" + DateTo.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {

        }
    }
}