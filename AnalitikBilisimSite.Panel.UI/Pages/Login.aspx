<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel Login</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="../Assets/img/logo.png" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/bootstrap.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/material-design-iconic-font.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/animate.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/hamburgers.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/animsition.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/select2.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/daterangepicker.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../Assets/css/util.css" />
    <link rel="stylesheet" type="text/css" href="../Assets/css/login.css" />
    <!--===============================================================================================-->
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="limiter">
                <div class="container-login100" style="background-image: url('../Assets/img/bg-01.jpg');">
                    <div class="wrap-login100">
                        <div class="login100-form validate-form">
                            <span class="login100-form-logo">
                                <asp:Image ID="ImgLoginLogo" runat="server" Width="100" Height="80" />
                            </span>

                            <span class="login100-form-title p-b-34 p-t-27">Admin Girişi
                            </span>

                            <div class="wrap-input100 validate-input" data-validate="Enter username">
                                <input id="txtUserName" class="input100" type="text" name="username" placeholder="Kullanıcı Adı" runat="server" />
                                <span class="focus-input100" data-placeholder="&#xf207;"></span>
                            </div>
                            <asp:RequiredFieldValidator ID="ValidatorUserName" runat="server" ErrorMessage="Kullanıcı Adı Boş Bırakılamaz!" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>

                            <div class="wrap-input100 validate-input" data-validate="Enter password">
                                <input id="txtPassword" class="input100" type="password" name="pass" placeholder="Şifre" runat="server" />
                                <span class="focus-input100" data-placeholder="&#xf191;"></span>
                            </div>
                            <asp:RequiredFieldValidator ID="ValidatorPassword" runat="server" ErrorMessage="Şifre Boş Bırakılamaz!" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator><br />

                            <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            <span class="focus-input100" data-placeholder="&#xf191;"></span>

                        <%--<div class="contact100-form-checkbox">
                                <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me" />
                                <label class="label-checkbox100" for="ckb1">
                                    Beni Hatırla
                                </label>
                            </div>--%>

                            <div class="container-login100-form-btn">
                                <asp:Button ID="BtnLogin" Class="login100-form-btn" runat="server" Text="Giriş" OnClick="BtnLogin_Click" />
                            </div>

                            <div class="text-center p-t-90">
                                <a class="txt1" href="#">Parolanızı mı unuttunuz?
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div id="dropDownSelect1"></div>

            <!--===============================================================================================-->
            <script src="../Assets/js/jquery-3.2.1.min.js"></script>
            <!--===============================================================================================-->
            <script src="../Assets/js/animsition.min.js"></script>
            <!--===============================================================================================-->
            <script src="../Assets/js/popper.js"></script>
            <script src="../Assets/js/bootstrap.min.js"></script>
            <!--===============================================================================================-->
            <script src="../Assets/js/select2.min.js"></script>
            <!--===============================================================================================-->
            <script src="../Assets/js/moment.min.js"></script>
            <script src="../Assets/js/daterangepicker.js"></script>
            <!--===============================================================================================-->
            <script src="../Assets/js/countdowntime.js"></script>
            <!--===============================================================================================-->
            <script src="../Assets/js/login.js"></script>


        </div>
    </form>
</body>
</html>
