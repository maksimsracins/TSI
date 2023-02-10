using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace OnlineBankingCsharp
{
    public partial class transfer_funds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session.IsNewSession || Session["CustID"] == null)
            {
                Response.Redirect("~/CustLogin.aspx", false);
            }
            else
            {
                txtAccountNum.Text = Session["AcctNum"].ToString();
                txtAccName.Text = Session["Firstname"].ToString() + " " + Session["Lastname"].ToString();
                txtStatus.Text = Session["Status"].ToString();
            }

            CheckLastSourcedID();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtAccountNum.Text == ""))
                {
                    lblmsg.Text = "";
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    cnn.Open();

                    string strcom = "select AcctNum, Firstname, Lastname from Customer where AcctNum='" + txtBenAccountNum.Text + "'";
                    SqlDataAdapter daDetails = new SqlDataAdapter(strcom, cnn);
                    DataSet dsDetails = new DataSet();
                    daDetails.Fill(dsDetails);

                    string firstname, lastname;

                    if (dsDetails.Tables[0].Rows.Count > 0)
                    {
                        firstname = dsDetails.Tables[0].Rows[0][1].ToString();
                        lastname = dsDetails.Tables[0].Rows[0][2].ToString();

                        txtBenAccName.Text = firstname + " " + lastname;
                        CheckLastBenID();
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

        protected void BtnTransfer_Click(object sender, EventArgs e)
        {
            if(!(txtStatus.Text == "Active"))
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Customer account is not Active";
            }
            else
            {
                DebitSourcedAccount();
            }
            
        }

        public void CheckLastSourcedID()
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

                    CheckSourcedBalance();
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

        public void CheckSourcedBalance()
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

        public void CheckLastBenID()
        {
            try
            {

                string dsm;
                SqlDataReader sqldataReader;
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
                dsm = "select AccountNumber from tbl_Transaction where AccountNumber ='" + txtBenAccountNum.Text + "'";
                sql.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = dsm;
                command.Connection = sql;
                sqldataReader = command.ExecuteReader();

                if (sqldataReader.Read())
                {
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
                    sqlConnection.Open();

                    string sm = "select Max(Id) from tbl_Transaction where AccountNumber ='" + txtBenAccountNum.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sm;
                    sqlCommand.Connection = sqlConnection;

                    object o = sqlCommand.ExecuteScalar();
                    txtBenID.Text = o.ToString();

                    sqlConnection.Close();

                    CheckBenBalance();
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

        public void CheckBenBalance()
        {
            try
            {
                SqlConnection conet = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                conet.Open();

                string strcom = "select Balance from tbl_Transaction where Id='" + txtBenID.Text + "'";
                SqlDataAdapter daDetails = new SqlDataAdapter(strcom, conet);
                DataSet dsDetails = new DataSet();
                daDetails.Fill(dsDetails);

                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    txtBenOldBalance.Text = dsDetails.Tables[0].Rows[0][0].ToString();
                }

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        public void DebitSourcedAccount()
        {
            try
            {
                if (!(txtAccountNum.Text == "" || txtAccName.Text == "" || txtID.Text == "" || txtOldBalance.Text == "" || txtStatus.Text == "" || txtTransferAmount.Text == "" || txtBenAccountNum.Text == "" || txtBenAccName.Text == "" || txtBenID.Text == "" || txtBenOldBalance.Text == "" || txtBenStatus.Text == ""))
                {

                    int OldBalance = Convert.ToInt32(txtOldBalance.Text);
                    int NewBalance;
                    int Withdrawal = Convert.ToInt32(txtTransferAmount.Text);

                    if (!(OldBalance < Withdrawal))
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
                                cmd.Parameters.AddWithValue("@4", "CR/" + txtBenAccName.Text);
                                cmd.Parameters.AddWithValue("@5", Withdrawal);
                                cmd.Parameters.AddWithValue("@6", NewBalance);
                                cmd.Connection = con;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    CreditBenAccount();
                                }
                                else
                                {
                                    lblmsg.ForeColor = System.Drawing.Color.Red;
                                    lblmsg.Text = "Oops! Try again..";
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
                    lblmsg.Text = "Transfer input fields cannot be empty";
                }
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        public void CreditBenAccount()
        {
            try
            {
                int OldBalance;
                int NewBalance;
                int TransferAmt;

                OldBalance = Convert.ToInt32(txtBenOldBalance.Text);
                TransferAmt = Convert.ToInt32(txtTransferAmount.Text);
                NewBalance = OldBalance + TransferAmt;

                string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
                using (SqlConnection con = new SqlConnection(constr))
                    {

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Transaction(Name,AccountNumber,Date,Description,Credit,Balance) VALUES(@1, @2, @3, @4, @5, @6)"))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@1", txtBenAccName.Text.Trim());
                            cmd.Parameters.AddWithValue("@2", txtBenAccountNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@3", System.DateTime.Now.ToShortDateString());
                            cmd.Parameters.AddWithValue("@4", txtTrancDescrip.Text + " from " + txtAccName.Text);
                            cmd.Parameters.AddWithValue("@5", TransferAmt);
                            cmd.Parameters.AddWithValue("@6", NewBalance);
                            cmd.Connection = con;
                            con.Open();

                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                lblmsg.ForeColor = System.Drawing.Color.Green;
                                lblmsg.Text = "Transfer Successful";
                                Reset();
                                CheckLastSourcedID();
                        }
                            else
                            {
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                                lblmsg.Text = "Oops! Try again..";
                            }
                            con.Close();
                        }
                    }
                    
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        public void Reset()
        {
            txtTrancDescrip.Text = "";
            txtTransferAmount.Text = "";
            txtBenAccountNum.Text = "";
            txtBenAccName.Text = "";
            txtBenID.Text = "";
            txtBenOldBalance.Text = "";

        }
    }
}