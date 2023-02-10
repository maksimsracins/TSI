using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBankingCsharp
{
    public partial class account_opening_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenAcctNo();
            CustID();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtEmail.Text == "" || txtPassword.Text == "" || txtAddress.Text == "" || txtDOB.Text == "" || txtFirstname.Text == "" || txtIDCardNo.Text == "" || txtLastname.Text == "" || txtMobileNo.Text == "" || ddlAccType.Text == "Select" || ddlGender.Text == "Select" || ddlIDCardType.Text == "Select" || ddlMaritalStatus.Text == "Select"))
                {

                    SqlDataReader reader;

                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());

                    lblmsg.Text = "";

                    SqlCommand sqlCommand = new SqlCommand("SELECT Firstname,Lastname,Email,MobileNo FROM Registration WHERE Firstname=@1 AND Lastname=@2 AND Email=@3", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@1", txtFirstname.Text);
                    sqlCommand.Parameters.AddWithValue("@2", txtLastname.Text);
                    sqlCommand.Parameters.AddWithValue("@3", txtEmail.Text);

                    sqlConnection.Open();

                    reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Customer's Account Found!";
                    }
                    else
                    {
                        //Get Filename from fileupload control
                        string filename = Path.GetFileName(fileuploadimages.FileName); ;
                        //Save images into Images folder
                        fileuploadimages.SaveAs(Server.MapPath("images/" + filename));

                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Customer VALUES(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16)"))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@1", txtCustID.Text.Trim());
                                cmd.Parameters.AddWithValue("@2", txtFirstname.Text.Trim());
                                cmd.Parameters.AddWithValue("@3", txtLastname.Text.Trim());
                                cmd.Parameters.AddWithValue("@4", txtAccountNum.Text.Trim());
                                cmd.Parameters.AddWithValue("@5", ddlAccType.Text.Trim());
                                cmd.Parameters.AddWithValue("@6", ddlGender.Text.Trim());
                                cmd.Parameters.AddWithValue("@7", txtMobileNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@8", ddlMaritalStatus.Text.Trim());
                                cmd.Parameters.AddWithValue("@9", txtDOB.Text.Trim());
                                cmd.Parameters.AddWithValue("@10", txtAddress.Text.Trim());
                                cmd.Parameters.AddWithValue("@11", ddlIDCardType.Text.Trim());
                                cmd.Parameters.AddWithValue("@12", txtIDCardNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@13", txtEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@14", Encrypt(txtPassword.Text.Trim()));
                                cmd.Parameters.AddWithValue("@15", "images/" + filename);
                                cmd.Parameters.AddWithValue("@16", "Active");

                                cmd.Connection = con;
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    lblmsg.ForeColor = System.Drawing.Color.Green;
                                    lblmsg.Text = "Record Submitted Successfully!";
                                    Reset();
                                    GenAcctNo();
                                    CustID();

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
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstname.Text = "";
            txtIDCardNo.Text = "";
            txtLastname.Text = "";
            txtMobileNo.Text = "";
            txtPassword.Text = "";
            ddlAccType.SelectedIndex = -1;
            ddlGender.SelectedIndex = -1;
            ddlIDCardType.SelectedIndex = -1;
            ddlMaritalStatus.SelectedIndex = -1;

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

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public void GenAcctNo()
        {
            txtAccountNum.Text = "3010" + GetUniqueKey(6);
        }

        public void CustID()
        {
            txtCustID.Text = "OB" + GetUniqueKey(4);
        }
    }
}