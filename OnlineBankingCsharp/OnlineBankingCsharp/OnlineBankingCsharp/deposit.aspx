<%@ Page Title="Deposit Money" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="deposit.aspx.cs" Inherits="OnlineBankingCsharp.deposit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">Deposit Money </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Transaction > Deposit</p>
       
    <hr />
         <div class="container">
             <div class="row">
             
                            <div class="col-xl-6">
                                <div class="card mb-4" style="width: 800px;">
                                    <div class="card-header alert-info">
                                        <i class="fas fa-chart-area me-1"></i>
                                        Customer Deposit Form
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-4 col-md-6" style="padding-left: 18px; padding-top: 18px; padding-bottom: 5px; padding-right: 2px;">
                                         <div class="form-group">
                                              <asp:TextBox runat="server" ID="txtAccountNum" CssClass="form-control" placeholder="Enter Account Number" ></asp:TextBox>
                                         </div>
                                        </div>
                                        <div class="col-xl-4 col-md-6" style="padding-top: 18px; padding-bottom: 5px; padding-right: 2px;" >
                                             <div class="form-group">
                                                  <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-secondary" Text="Search" OnClick="btnSearch_Click" />
                                                 <asp:Button ID="BtnDeposit" runat="server" CssClass="btn btn-primary" Text="Deposit" Visible="false" OnClick="BtnDeposit_Click" />
                                                 <asp:Button ID="BtnReset" runat="server" CssClass="btn btn-danger" Visible="false" Text="Reset" />
                                             </div>
                                        </div>
                                        <div class="col-xl-4 col-md-6" style="padding-top: 18px; padding-bottom: 5px;">
                                             <div class="form-group">
                                                
                                            </div>
                                        </div>
                                        
                                    </div>

                                 <div class="row">
                                     <div class="col-xl-4 col-md-6" style="padding-top: 18px; padding-bottom: 5px; padding-right: 2px; padding-left: 18px;">
                                         <div class="form-group">
                                              <label for="AccName">Account Name</label>
                                              <asp:TextBox runat="server" ID="txtAccName" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                                         </div>
                                        </div>
                                    <div class="col-xl-4 col-md-6" style="padding: 18px;">
                                         <div class="form-group">
                                              <label for="DepositAmount">Amount to Deposit</label>
                                              <asp:TextBox runat="server" ID="txtDepositAmount" CssClass="form-control" placeholder="Enter Amount Here"></asp:TextBox>
                                         </div>
                                    </div>

                                    <div class="col-xl-4">
                                        <asp:Image ID="ImgCustomer" runat="server" Width="90px" Height="90px" Visible="false"/>
                                    </div>

                            
                                </div>

                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                     <div class="row">
                                     <asp:GridView ID="GridView1" class="table table-bordered table-condensed table-responsive table-hover " runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="Date" HeaderText="Date" />
                                            <asp:BoundField DataField="Description" HeaderText="Transaction Description" />
                                            <asp:BoundField DataField="Debit" HeaderText="Debit" />
                                            <asp:BoundField DataField="Credit" HeaderText="Credit" />
                                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                        
                                        </Columns>
                                    </asp:GridView>
                                 </div>

                                </asp:Panel>

                                 
                                    <br />
                                    <asp:Label runat="server" ID="lblmsg"></asp:Label>
                                    
                                </div>
                                 
                            </div>
                            
                            <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtOldBalance" runat="server" Visible="false" ></asp:TextBox>
                            <asp:TextBox ID="txtStatus" runat="server" Text="Active" Visible="false"></asp:TextBox>
            </div>
    </div>
</asp:Content>
