<%@ Page Title="Account Opening Form" Language="C#" MasterPageFile="~/Normal.Master" AutoEventWireup="true" CodeBehind="account-opening-form.aspx.cs" Inherits="OnlineBankingCsharp.account_opening_form" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">Account Opening Form </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Customer > Account Opening Form</p>
   
    <hr />
         <div class="container">
         
       <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="CustomerID">Customer's ID</label>
                      <asp:TextBox runat="server" ID="txtCustID" CssClass="form-control"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="AccountNumber">Account Number</label>
                      <asp:TextBox runat="server" ID="txtAccountNum" CssClass="form-control" ></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="AccountType">Account Type</label>
                      <asp:DropDownList ID="ddlAccType" runat="server" CssClass="form-control">
                          <asp:ListItem>Select</asp:ListItem>
                          <asp:ListItem>Savings</asp:ListItem>
                          <asp:ListItem>Daily Savings</asp:ListItem>
                          <asp:ListItem>Current</asp:ListItem>
                      </asp:DropDownList>
                 </div>
            </div>
                            
        </div>

          <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="First name">First name</label>
                      <asp:TextBox runat="server" ID="txtFirstname" CssClass="form-control" placeholder="Enter first name"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="Lastname">Last name</label>
                      <asp:TextBox runat="server" ID="txtLastname" CssClass="form-control" placeholder="Enter last name" ></asp:TextBox>
                 </div>
            </div>
                            
        </div>

        <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="gender">Gender</label>
                      <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                          <asp:ListItem>Select</asp:ListItem>
                          <asp:ListItem>Male</asp:ListItem>
                          <asp:ListItem>Female</asp:ListItem>
                      </asp:DropDownList>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="mobileno">Mobile No.</label>
                      <asp:TextBox runat="server" ID="txtMobileNo" type="number" CssClass="form-control" placeholder="Enter Mobile No."></asp:TextBox>
                 </div>
            </div>
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="MaritalStatus">Marital Status</label>
                      <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control">
                          <asp:ListItem>Select</asp:ListItem>
                          <asp:ListItem>Single</asp:ListItem>
                          <asp:ListItem>Married</asp:ListItem>
                          <asp:ListItem>Divorce</asp:ListItem>
                          <asp:ListItem>Others</asp:ListItem>
                      </asp:DropDownList>
                 </div>
            </div>

                            
        </div>
        <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="DOB">Date of Birth</label>
                      <asp:TextBox runat="server" ID="txtDOB" type="date" CssClass="form-control"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="Address">Address</label>
                      <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Enter Address" ></asp:TextBox>
                 </div>
            </div>
                            
        </div>
        <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="IDCardType">ID Card Type</label>
                      <asp:DropDownList ID="ddlIDCardType" runat="server" CssClass="form-control">
                          <asp:ListItem>Select</asp:ListItem>
                          <asp:ListItem>Passport</asp:ListItem>
                          <asp:ListItem>Voters Card</asp:ListItem>
                          <asp:ListItem>Drivers License</asp:ListItem>
                          <asp:ListItem>National Identity Card</asp:ListItem>
                      </asp:DropDownList>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="IDCardNumber">ID Card Number</label>
                      <asp:TextBox runat="server" ID="txtIDCardNo" CssClass="form-control" placeholder="Enter ID Card No." ></asp:TextBox>
                 </div>
            </div>
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="UploadPhoto">Upload Photo</label>
                      <asp:FileUpload ID="fileuploadimages" runat="server" CssClass="form-control" />
                 </div>
            </div>
                            
        </div>

  
        
        <hr />
             <div class="row">
                  <div class="col-xl-4 col-md-6">
                     <div class="form-group">
                          <label for="Email">Email</label>
                          <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" type="email" placeholder="Enter Email Address"></asp:TextBox>
                     </div>
                </div>
                <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="password">Password</label>
                      <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password" placeholder="********"></asp:TextBox>
                 </div>
            </div>
             </div>

         <div class="row">
            <div class="col-xl-3 col-md-6" style="padding-top:15px;">
                 <div class="form-group">
                    <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                 </div>
            </div>
                         
        </div>
             <div class="row" style="padding-bottom: 30px;">
                 <asp:Label ID="lblmsg" runat="server"></asp:Label>
             </div>
             
    </div>
</asp:Content>
