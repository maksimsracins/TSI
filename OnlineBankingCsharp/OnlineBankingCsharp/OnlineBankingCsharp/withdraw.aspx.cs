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
    public partial class withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session.IsNewSession || Session["CustID"] == null)
            //{
            //    Response.Redirect("~/CustLogin.aspx", false);
            //}
            //else
            //{
            //    txtAccountNum.Text = Session["AcctNum"].ToString();
            //    txtAccName.Text = Session["Firstname"].ToString() + " " + Session["Lastname"].ToString();
            //}

            //CheckLastID();
        }

        protected void BtnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                if(!(txtAccountNum.Text == "" || txtAccName.Text == "" || txtID.Text == "" || txtOldBalance.Text == "" || txtStatus.Text == "" || txtWithdrawAmount.Text == ""))
                {

                    int OldBalance = Convert.ToInt32(txtOldBalance.Text);
                    int NewBalance;
                    int Withdrawal = Convert.ToInt32(txtWithdrawAmount.Text);

                    if(!(OldBalance < Withdrawal))
                    {
                        NewBalance = OldBalance - Withdrawal;

                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Transaction(Name,AccountNumber,Date,Description,Debit,Balance) VALUES(@1, @2, @3, @4, @5, @6)"))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@1", txtAccName.Text.Trim());
                                cmd.Parameters.AddWithValue("@2", txtAccountNum.Text.Trim());
                                cmd.Parameters.AddWithValue("@3", System.DateTime.Now.ToShortDateString());
                                cmd.Parameters.AddWithValue("@4", "Cash Withdrawal");
                                cmd.Parameters.AddWithValue("@5", Withdrawal);
                                cmd.Parameters.AddWithValue("@6", NewBalance);
                                cmd.Connection = con;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    lblmsg.ForeColor = System.Drawing.Color.Green;
                                    lblmsg.Text = "Cash Withdrawal Successful!";
                                    Panel1.Visible = true;
                                    DisplayTransaction();
                                    txtWithdrawAmount.Text = "";
                                    txtAccountNum.Text = "";
                                    txtAccName.Text = "";
                                    txtID.Text = "";
                                    txtOldBalance.Text = "";
                                }
                                else
                                {
                                    lblmsg.ForeColor = System.Drawing.Color.Red;
                                    lblmsg.Text = "Oops! Try again..";
                                    Panel1.Visible = false;
                                }
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Customer's Account Balance is low";
                    }
                }
                else
                {
                    //Display Error Message
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = " Withdrawal input fields cannot be empty";
                }
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        public void CheckLastID()
        {
            try
            {

                string dsm;
                SqlDataReader sqldataReader;
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
                dsm = "select AccountNumber from tbl_Transaction where AccountNumber ='" + txtAccountNum.Text + "'";
                sql.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = dsm;
                command.Connection = sql;
                sqldataReader = command.ExecuteReader();

                if (sqldataReader.Read())
                {
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
                    sqlConnection.Open();

                    string sm = "select Max(Id) from tbl_Transaction where AccountNumber ='" + txtAccountNum.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sm;
                    sqlCommand.Connection = sqlConnection;

                    object o = sqlCommand.ExecuteScalar();
                    txtID.Text = o.ToString();

                    sqlConnection.Close();

                    CheckBalance();
                }
                else
                {

                }

                sqldataReader.Close();

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;

            }


        }

        public void CheckBalance()
        {
            try
            {
                SqlConnection conet = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                conet.Open();

                string strcom = "select Balance from tbl_Transaction where Id='" + txtID.Text + "'";
                SqlDataAdapter daDetails = new SqlDataAdapter(strcom, conet);
                DataSet dsDetails = new DataSet();
                daDetails.Fill(dsDetails);

                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    txtOldBalance.Text = dsDetails.Tables[0].Rows[0][0].ToString();
                }

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtAccountNum.Text == ""))
                {
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    cnn.Open();

                    string strcom = "select AcctNum, Firstname, Lastname, Photo from Customer where AcctNum='" + txtAccountNum.Text + "'";
                    SqlDataAdapter daDetails = new SqlDataAdapter(strcom, cnn);
                    DataSet dsDetails = new DataSet();
                    daDetails.Fill(dsDetails);

                    string firstname, lastname, img;

                    if (dsDetails.Tables[0].Rows.Count > 0)
                    {
                        firstname = dsDetails.Tables[0].Rows[0][1].ToString();
                        lastname = dsDetails.Tables[0].Rows[0][2].ToString();
                        img = dsDetails.Tables[0].Rows[0][3].ToString();

                        txtAccName.Text = firstname + " " + lastname;
                        ImgCustomer.ImageUrl = img;

                        CheckLastID();

                        Panel1.Visible = true;
                        DisplayTransaction();
                        BtnWithdraw.Visible = true;
                        BtnReset.Visible = true;
                        ImgCustomer.Visible = true;
                        lblmsg.Text = "";
                    }
                    else
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Customer not found with the account number: " + txtAccountNum.Text;
                    }
                    cnn.Close();
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Customer not found with the account number: " + txtAccountNum.Text;

                }
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        public void DisplayTransaction()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Date,Description,Debit,Credit,Balance from tbl_Transaction where AccountNumber ='" + txtAccountNum.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    //lblmsg.ForeColor = System.Drawing.Color.Red;
                    //lblmsg.Text = "No transaction found: " + txtAccountNum.Text;
                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}