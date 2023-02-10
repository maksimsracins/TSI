<%@ Page Title="Transfer Money" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="transfer-funds.aspx.cs" Inherits="OnlineBankingCsharp.transfer_funds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-4">Transfer Money </h3>
    <p class="text-muted text-sm-end" style="font-size: 11px;">Home > Transaction > Transfer</p>
       
    <hr />
         <div class="container">
                    <div class="row">
                            <div class="col-xl-6">
                                <div class="card mb-4">
                                    <div class="card-header alert-info">
                                        <i class="fas fa-chart-area me-1"></i>
                                        Sourced Account
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-6 col-md-6" style="padding-left: 18px; padding-top: 18px; padding-bottom: 5px; padding-right: 8px;">
                                         <div class="form-group">
                                              <label for="AccountNumber">Account Number</label>
                                              <asp:TextBox runat="server" ID="txtAccountNum" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                                         </div>
                                        </div>
                                        <div class="col-xl-6 col-md-6" style="padding-top: 18px; padding-bottom: 5px; padding-right: 20px;">
                                         <div class="form-group">
                                              <label for="AccName">Account Name</label>
                                              <asp:TextBox runat="server" ID="txtAccName" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                                         </div>
                                        </div>
                                    </div>

                                 <div class="row">
                                    <div class="col-xl-6 col-md-6" style="padding: 18px;">
                                         <div class="form-group">
                                              <label for="TransferAmount">Amount to Transfer</label>
                                              <asp:TextBox runat="server" ID="txtTransferAmount" CssClass="form-control" placeholder="Enter Amount Here"></asp:TextBox>
                                         </div>
                                    </div>
                            
                                </div>

                                <div style="padding: 10px" >
                                 <div class="form-group">
                                    <%--<asp:Button ID="BtnDeposit" runat="server" CssClass="btn btn-primary" Text="Deposit" /> &nbsp&nbsp
                                     <asp:Button ID="BtnReset" runat="server" CssClass="btn btn-danger" Text="Reset" />--%>
                                 </div>
                                </div> 
                                    
                                    
                                </div>
                                 
                            </div>

                        <div class="col-xl-6">
                                <div class="card mb-4">
                                    <div class="card-header alert-info">
                                        <i class="fas fa-chart-area me-1"></i>
                                        Beneficiary Account
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-6 col-md-6" style="padding-left: 18px; padding-top: 18px; padding-bottom: 5px; padding-right: 2px;">
                                         <div class="form-group">
                                              <asp:TextBox runat="server" ID="txtBenAccountNum" CssClass="form-control" placeholder="Enter Account Number" ></asp:TextBox>
                                         </div>
                                        </div>
                                        <div class="col-xl-6 col-md-6" style="padding-top: 18px; padding-bottom: 5px; padding-right: 20px;">
                                             <div class="form-group">
                                                  <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-secondary" Text="Search" OnClick="btnSearch_Click" />
                                             </div>
                                        </div>
                                        
                                    </div>

                                 <div class="row">
                                     <div class="col-xl-6 col-md-6" style="padding-top: 18px; padding-bottom: 5px; padding-right: 2px; padding-left: 18px;">
                                         <div class="form-group">
                                              <label for="AccName">Account Name</label>
                                              <asp:TextBox runat="server" ID="txtBenAccName" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                                         </div>
                                        </div>
                                    <div class="col-xl-6 col-md-6" style="padding: 18px;">
                                         <div class="form-group">
                                              <label for="TranDescrip">Transaction Description</label>
                                              <asp:TextBox runat="server" ID="txtTrancDescrip" CssClass="form-control" placeholder="Transaction Description"></asp:TextBox>
                                         </div>
                                    </div>
                            
                                </div>
                                <div style="padding: 10px" >
                                 <div class="form-group">
                                    <%--<asp:Button ID="BtnDeposit" runat="server" CssClass="btn btn-primary" Text="Deposit" /> &nbsp&nbsp
                                     <asp:Button ID="BtnReset" runat="server" CssClass="btn btn-danger" Text="Reset" />--%>
                                 </div>
                                </div> 
                                    
                                </div>
                                 
                            </div>

                         <div style="padding: 10px" >
                                 <div class="form-group">
                                    <asp:Button ID="BtnTransfer" runat="server" CssClass="btn btn-primary" Text="Transfer" OnClick="BtnTransfer_Click" /> &nbsp&nbsp
                                     <asp:Button ID="BtnReset" runat="server" CssClass="btn btn-danger" Text="Reset" />
                                 </div>
                                </div>
                        
                        <asp:TextBox ID="txtID" runat="server" Visible="false" ></asp:TextBox>
                        <asp:TextBox ID="txtOldBalance" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtStatus" runat="server" Visible="false"></asp:TextBox>

                        <asp:TextBox ID="txtBenID" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtBenOldBalance" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtBenStatus" runat="server" Text="Active" Visible="false"></asp:TextBox>


                        </div>
                        <br />
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
</asp:Content>
