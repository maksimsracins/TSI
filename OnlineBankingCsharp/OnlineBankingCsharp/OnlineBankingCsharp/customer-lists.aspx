<%@ Page Title="Customer's List" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="customer-lists.aspx.cs" Inherits="OnlineBankingCsharp.customer_lists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">Customer's List </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Customer > List</p>
       
    <hr />
         <div class="container">
             <div class="row">
                 <asp:GridView ID="GridView1" class="table table-bordered table-condensed table-responsive table-hover " runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#" />
                        <asp:BoundField DataField="CustID" HeaderText="Customer ID" />
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                        <asp:BoundField DataField="AcctNum" HeaderText="Acc No." />
                        <asp:BoundField DataField="AcctType" HeaderText="Acc Type" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" />
                        <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        
                    </Columns>
                </asp:GridView>
             </div>
             <%--<p></p>--%>
             <%--<div class="row">
                 <div class="col-xl-3 col-md-6">
                     <div class="form-group">
                        <asp:Button runat="server" ID="BtnExport" CssClass="btn btn-secondary" Text="Export Statement" />
                     </div>
                 </div>
             </div>--%>
             <p></p>
             <asp:Label ID="lblmsg" runat="server"></asp:Label>
         </div>
</asp:Content>
