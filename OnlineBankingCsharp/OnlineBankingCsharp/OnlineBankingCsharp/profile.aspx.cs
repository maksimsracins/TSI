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
    public partial class profile : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustData();
            }
            
        }

        public void CustData()
        {
            string AccNo = Session["AcctNum"].ToString();

            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                cnn.Open();

                string strcom = "select CustID,Firstname,Lastname,AcctNum,AcctType,Gender,MobileNo,MaritalStatus,DOB,Address,IDCardType,IDCardNo,Email,Password,Status from Customer where AcctNum='" + AccNo + "'";
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
                    txtPassword.Text = Decrypt(dsDetails.Tables[0].Rows[0][13].ToString());
                    txtStatus.Text = dsDetails.Tables[0].Rows[0][14].ToString();

                }
                cnn.Close();

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            
                con.Open();
                string cb = "update Customer set MobileNo=@d2,Email=@d3,Password=@d4 where AcctNum=@d1";

                SqlCommand cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAccountNum.Text);
                cmd.Parameters.AddWithValue("@d2", txtMobileNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d4", Encrypt(txtPassword.Text));

                cmd.ExecuteReader();
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Customer's Profile Updated Successfully";
                CustData();

                
                con.Close();

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
            }
        }
    }
}