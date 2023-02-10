<%@ Page Title="Update Customer's Profile" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="update-profile.aspx.cs" Inherits="OnlineBankingCsharp.update_profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p></p>
    <h3 class="mt-4">Customers Profile </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Profile > Edit</p>
   
    <hr />
         <div class="container">
             <div class="row">
                 <div class="col-xl-4 col-md-6">
                     <div class="form-group">
                           <asp:TextBox runat="server" ID="txtSearchAccNumber" CssClass="form-control" placeholder="Enter Account Number" ></asp:TextBox>
                     </div>
                 </div>
                 <div class="col-xl-4 col-md-6">
                      <div class="form-group">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-secondary" Text="Search" OnClick="btnSearch_Click" />
                      </div>
                 </div>
                                        
             </div>
         
       <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="CustomerID">Customer's ID</label>
                      <asp:TextBox runat="server" ID="txtCustID" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="AccountNumber">Account Number</label>
                      <asp:TextBox runat="server" ID="txtAccountNum" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="AccountType">Account Type</label>
                      <asp:TextBox runat="server" ID="txtAccountType" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
                            
        </div>

          <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="First name">First name</label>
                      <asp:TextBox runat="server" ID="txtFirstname" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="Lastname">Last name</label>
                      <asp:TextBox runat="server" ID="txtLastname" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
                            
        </div>

        <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="gender">Gender</label>
                      <asp:TextBox runat="server" ID="txtGender" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="mobileno">Mobile No.</label>
                      <asp:TextBox runat="server" ID="txtMobileNo" type="number" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                 </div>
            </div>
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="MaritalStatus">Marital Status</label>
                      <asp:TextBox runat="server" ID="txtMaritalStatus" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>

                            
        </div>
        <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="DOB">Date of Birth</label>
                      <asp:TextBox runat="server" ID="txtDOB" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="Address">Address</label>
                      <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
                            
        </div>
        <div class="row">
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="IDCardType">ID Card Type</label>
                      <asp:TextBox runat="server" ID="txtIDcard" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="IDCardNumber">ID Card Number</label>
                      <asp:TextBox runat="server" ID="txtIDCardNo" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                 </div>
            </div>
            <div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="Status">Status</label>
                      <asp:TextBox runat="server" ID="txtStatus" CssClass="form-control" ></asp:TextBox>
                 </div>
            </div>
                            
        </div>

             <div class="row">
                  <div class="col-xl-4 col-md-6">
                     <div class="form-group">
                          <label for="Email">Email</label>
                          <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" type="email" ReadOnly="true"></asp:TextBox>
                     </div>
                </div>
                <%--<div class="col-xl-4 col-md-6">
                 <div class="form-group">
                      <label for="password">Password</label>
                      <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password"></asp:TextBox>
                 </div>
            </div>--%>
             </div>

         <div class="row">
            <div class="col-xl-3 col-md-6" style="padding-top:15px;">
                 <div class="form-group">
                    <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-primary" Text="Update Status" OnClick="BtnUpdate_Click" />
                 </div>
            </div>
                         
        </div>
             <div class="row" style="padding-bottom: 30px;">
                 <asp:Label ID="lblmsg" runat="server"></asp:Label>
             </div>
             
    </div>
</asp:Content>
