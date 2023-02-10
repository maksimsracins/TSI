<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustLogin.aspx.cs" Inherits="OnlineBankingCsharp.CustLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer's Login</title>
    <%--<meta charset="utf-8" />--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
</head>
<body class="bg-info">
    <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header"><h3 class="text-center font-weight-light my-4">Online Banking System</h3></div>
                                    <%--<div><h5 class="text-center font-weight-light my-4">Login</h5></div>--%>
                                    <div class="card-body">
                                        <form id="form1" runat="server">
                                            <div class="form-floating mb-3">
                                                <asp:TextBox runat="server" ID="txtEmail" type="email" class="form-control" placeholder="name@example.com"></asp:TextBox>
                                                <label for="Email">Email address</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox runat="server" ID="txtPassword" type="password" class="form-control" placeholder="Password"></asp:TextBox>
                                                <label for="Password">Password</label>
                                            </div>
                                            <div class="form-check mb-3">
                                                <input class="form-check-input" id="inputRememberPassword" type="checkbox" value="" />
                                                <label class="form-check-label" for="inputRememberPassword">Remember Password</label>
                                            </div>
                                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                                <a class="small" href="login.aspx">Admin Login</a>
                                                <%--<a class="btn btn-primary" href="index.html">Login</a>--%>
                                                <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary" Text="Login" OnClick="BtnLogin_Click" />
                                            </div>
                                        </form>
                                    </div>
                                    <div class="card-footer text-center py-3">
                                        <div class="small"><a href="account-opening-form.aspx">Need an account? Sign up!</a></div>
                                    </div>
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
            <div id="layoutAuthentication_footer">
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; 2022 Online Banking System in ASP.NET using C#</div>
                            <div>
                                <a href="#">Privacy Policy</a>
                                &middot;
                                <a href="#">Terms &amp; Conditions</a>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js/scripts.js"></script>
</body>
</html>
