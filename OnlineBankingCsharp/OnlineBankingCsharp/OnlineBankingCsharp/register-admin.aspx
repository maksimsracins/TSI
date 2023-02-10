<%@ Page Title="Register Administrator" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="register-admin.aspx.cs" Inherits="OnlineBankingCsharp.register_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">New Administrator </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Admin > Register</p>
    <hr />

     <div class="container">
         
       <div class="row">
            <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="firstname">First name</label>
                      <asp:TextBox runat="server" ID="txtFname" CssClass="form-control" placeholder="Enter first name"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="lastname">Last Name</label>
                      <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Enter last name"></asp:TextBox>
                 </div>
            </div>
                            
        </div>

        <div class="row">
            <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="gender">Gender</label>
                      <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                          <asp:ListItem>Select</asp:ListItem>
                          <asp:ListItem>Male</asp:ListItem>
                          <asp:ListItem>Female</asp:ListItem>
                      </asp:DropDownList>
                 </div>
            </div>
           <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="mobileno">Mobile No.</label>
                      <asp:TextBox runat="server" ID="txtMobileNo" type="number" CssClass="form-control" placeholder="Enter Mobile No."></asp:TextBox>
                 </div>
            </div>
                            
        </div>

         <div class="row">
            <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="Email">Email</label>
                      <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" type="email" placeholder="Enter Email Address"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="password">Password</label>
                      <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password" placeholder="********"></asp:TextBox>
                 </div>
            </div>
                            
        </div>

         <div class="row">
            <div class="col-xl-3 col-md-6" style="padding-top:15px;">
                 <div class="form-group">
                    <asp:Button ID="BtnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="BtnSubmit_Click" /> <br /><br />
             <asp:Label ID="lblmsg" runat="server"></asp:Label>
                 </div>
            </div>
                         
        </div>
    </div>
</asp:Content>
