<%@ Page Title="Withdrawal Deposit List" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Withrawal-Lists.aspx.cs" Inherits="OnlineBankingCsharp.Withrawal_Lists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">Withdrawal List </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Withdrawal > List</p>
       
    <hr />
         <div class="container">
             <div class="row">
            <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="DateFrom">Date From</label>
                      <asp:TextBox runat="server" ID="DateFrom" type="Date" CssClass="form-control"></asp:TextBox>
                 </div>
            </div>
           <div class="col-xl-3 col-md-6">
                 <div class="form-group">
                      <label for="Date To">Date To</label>
                    <asp:TextBox runat="server" ID="DateTo" type="Date" CssClass="form-control"></asp:TextBox>
                 </div>
            </div>
            
            <div class="col-xl-3 col-md-6" style="padding-top: 24px;">
                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" /><br />
                <asp:Label ID="lblmsg" runat="server"></asp:Label> 
            </div>
                            
        </div>
             <p></p>
             <div class="row">
                 <asp:GridView ID="GridView1" class="table table-bordered table-condensed table-responsive table-hover " runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#" />
                        <asp:BoundField DataField="Name" HeaderText="Customer" />
                        <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Debit" HeaderText="Debit" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" />
                        
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
         </div>
</asp:Content>
