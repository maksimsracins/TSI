using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBankingCsharp
{
    public partial class CustLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtEmail.Text == "" || txtPassword.Text == ""))
                {

                    SqlDataReader reader;

                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());

                    lblmsg.Text = "";

                    SqlCommand sqlCommand = new SqlCommand("SELECT Firstname,Lastname,Email,CustID,AcctNum,Password,Status FROM Customer WHERE Email=@email AND Password=@password", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@email", (txtEmail.Text));
                    sqlCommand.Parameters.AddWithValue("@password", Encrypt(txtPassword.Text));

                    sqlConnection.Open();

                    reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        Session.Add("Firstname", reader.GetString(0));
                        Session.Add("Lastname", reader.GetString(1));
                        Session.Add("Email", reader.GetString(2));
                        Session.Add("CustID", reader.GetString(3));
                        Session.Add("AcctNum", reader.GetString(4));
                        Session.Add("Status", reader.GetString(6));
                        Response.Redirect("~/dashboard.aspx", false);
                    }
                    else
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Invalid Username or Password!";
                    }

                    reader.Close();
                    sqlConnection.Close();
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Form cannot be empty";
                }

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.Message;
                lblmsg.Text = "";
                lblmsg.Text = "Connection fail, click on the Login button to try again";
            }
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
    }
}