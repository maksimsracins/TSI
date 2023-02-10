<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="OnlineBankingCsharp.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 30px;">
    <div class="row">
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-primary text-white mb-4">
                                    <div class="card-body">Account Balance</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:Label ID="lblBalance" runat="server" Font-Size="Medium" CssClass="small text-white stretched-link"></asp:Label>
                                        <%--<div class="small text-white"><i class="fas fa-angle-right"></i></div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-success text-white mb-4">
                                    <div class="card-body">Transfer</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <a class="small text-white stretched-link" href="transfer-funds.aspx">View Details</a>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-danger text-white mb-4">
                                    <div class="card-body">Profile</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <a class="small text-white stretched-link" href="profile.aspx">View Details</a>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
</asp:Content>
