<%@ Page Title="Statement of Account" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="statement.aspx.cs" Inherits="OnlineBankingCsharp.statement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">Statement of Account </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Customer > Statement</p>
       
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
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Debit" HeaderText="Debit" />
                        <asp:BoundField DataField="Credit" HeaderText="Credit" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" />
                        
                    </Columns>
                </asp:GridView>
             </div>
             <%--<p></p>--%>
             <%--<div class="row">
                 <div class="col-xl-3 col-md-6">
                     <div class="form-group">
                        <asp:Button runat="server" ID="BtnExport" CssClass="btn btn-secondary" Text="Export Statement" OnClick="BtnExport_Click" />
                     </div>
                 </div>
             </div>--%>
             <p></p>
         </div>
</asp:Content>
