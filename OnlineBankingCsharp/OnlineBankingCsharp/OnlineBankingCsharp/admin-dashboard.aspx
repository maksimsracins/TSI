<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin-dashboard.aspx.cs" Inherits="OnlineBankingCsharp.admin_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 30px;">
    <div class="row">
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-primary text-white mb-4">
                                    <div class="card-body">Total Customers</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <a class="small text-white stretched-link" href="customer-lists.aspx"><asp:Label ID="lblTotalCust" runat="server" Font-Size="Medium" CssClass="small text-white stretched-link"></asp:Label></a>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-success text-white mb-4">
                                    <div class="card-body">Total Deposit</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:Label ID="lblTotalDeposit" runat="server" Font-Size="Medium" CssClass="small text-white stretched-link"></asp:Label>
                                        <%--<div class="small text-white"><i class="fas fa-angle-right"></i></div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-danger text-white mb-4">
                                    <div class="card-body">Total Withdrawal</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:Label ID="lblTotalWithdrawal" runat="server" Font-Size="Medium" CssClass="small text-white stretched-link"></asp:Label>
                                        <%--<div class="small text-white"><i class="fas fa-angle-right"></i></div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-warning text-white mb-4">
                                    <div class="card-body">Customer's Profile</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <a class="small text-white stretched-link" href="update-profile.aspx">View Details</a>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
</asp:Content>
