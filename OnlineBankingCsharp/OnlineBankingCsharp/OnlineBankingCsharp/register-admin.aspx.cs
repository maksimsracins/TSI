using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBankingCsharp
{
    public partial class register_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(!(txtEmail.Text == "" || txtFname.Text == "" || txtLastName.Text == "" || txtMobileNo.Text == "" || txtPassword.Text == "" || ddlGender.Text == "Select"))
                {

                    SqlDataReader reader;

                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());

                    lblmsg.Text = "";

                    SqlCommand sqlCommand = new SqlCommand("SELECT Firstname,Email,Lastname FROM Registration WHERE Email=@email AND Firstname=@firstname", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@email", (txtEmail.Text));
                    sqlCommand.Parameters.AddWithValue("@firstname", Encrypt(txtFname.Text));

                    sqlConnection.Open();

                    reader = sqlCommand.ExecuteReader();

                    if(reader.Read())
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Duplicate User found!";
                    }
                    else
                    {
                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Registration VALUES(@1, @2, @3, @4, @5, @6)"))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@1", txtFname.Text.Trim());
                                cmd.Parameters.AddWithValue("@2", txtLastName.Text.Trim());
                                cmd.Parameters.AddWithValue("@3", ddlGender.Text.Trim());
                                cmd.Parameters.AddWithValue("@4", txtMobileNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@5", txtEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@6", Encrypt(txtPassword.Text.Trim()));
                                cmd.Connection = con;
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    lblmsg.ForeColor = System.Drawing.Color.Green;
                                    lblmsg.Text = "Record Submitted Successfully!";
                                    Reset();
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
            }
            
        }

        public void Reset()
        {
            txtEmail.Text = string.Empty;
            txtFname.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtPassword.Text = string.Empty;
            ddlGender.SelectedIndex = -1;


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