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
    public partial class update_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CustData();
        }

        public void CustData()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                cnn.Open();

                string strcom = "select CustID,Firstname,Lastname,AcctNum,AcctType,Gender,MobileNo,MaritalStatus,DOB,Address,IDCardType,IDCardNo,Email,Status from Customer where AcctNum='" + txtSearchAccNumber.Text + "'";
                SqlDataAdapter daDetails = new SqlDataAdapter(strcom, cnn);
                DataSet dsDetails = new DataSet();
                daDetails.Fill(dsDetails);

                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    txtCustID.Text = dsDetails.Tables[0].Rows[0][0].ToString();
                    txtFirstname.Text = dsDetails.Tables[0].Rows[0][1].ToString();
                    txtLastname.Text = dsDetails.Tables[0].Rows[0][2].ToString();
                    txtAccountNum.Text = dsDetails.Tables[0].Rows[0][3].ToString();
                    txtAccountType.Text = dsDetails.Tables[0].Rows[0][4].ToString();
                    txtGender.Text = dsDetails.Tables[0].Rows[0][5].ToString();
                    txtMobileNo.Text = dsDetails.Tables[0].Rows[0][6].ToString();
                    txtMaritalStatus.Text = dsDetails.Tables[0].Rows[0][7].ToString();
                    txtDOB.Text = dsDetails.Tables[0].Rows[0][8].ToString();
                    txtAddress.Text = dsDetails.Tables[0].Rows[0][9].ToString();
                    txtIDcard.Text = dsDetails.Tables[0].Rows[0][10].ToString();
                    txtIDCardNo.Text = dsDetails.Tables[0].Rows[0][11].ToString();
                    txtEmail.Text = dsDetails.Tables[0].Rows[0][12].ToString();
                    txtStatus.Text = dsDetails.Tables[0].Rows[0][13].ToString();

                }
                cnn.Close();

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(!(txtAccountNum.Text == ""))
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

                    con.Open();
                    string cb = "update Customer set Status=@d2 where AcctNum=@d1";

                    SqlCommand cmd = new SqlCommand(cb);

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtAccountNum.Text);
                    cmd.Parameters.AddWithValue("@d2", txtStatus.Text.Trim());

                    cmd.ExecuteReader();
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Text = "Customer's Profile Updated Successfully";
                    CustData();


                    con.Close();
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Cannot update an empty form";
                }

            }
                catch (Exception ex)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = ex.Message;
                }
        }
    }
}