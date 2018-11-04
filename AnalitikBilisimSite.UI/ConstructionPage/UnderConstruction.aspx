<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnderConstruction.aspx.cs" Inherits="AnalitikBilisimSite.UI.ConstructionPage.UnderConstruction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Analitik Bilişim</title>

    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,700%7CPoppins:400,500" rel="stylesheet" />
    <link href="common-css/ionicons.css" rel="stylesheet" />
    <link rel="stylesheet" href="common-css/jquery.classycountdown.css" />
    <link href="03-comming-soon/css/styles.css" rel="stylesheet" />
    <link href="03-comming-soon/css/responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="main-area center-text" style="background-image: url(images/countdown-3-1600x900.jpg);">

            <div style="height: 20%; width: 100%;">
                <asp:Image ID="Image1" runat="server" ImageUrl="images/logo.png" Height="120" Width="340" />
            </div>

            <div style="width: 49%; height: 70%;float: left;border-right-color:#F84982;border-right-style:solid;border-right-width:1px">

                <div class="display-table">
                    <div class="display-table-cell">
                        <h1 class="title font-white"><b>Sitemiz Yapım Aşamasındadır</b></h1>
                        <p class="desc font-white">
                            Sizlerle olana kadar, bize sayfanın altındaki sosyal medya linklerindeki bilgilerden ulaşabilirisiniz.
                        </p>
                        <div style="height: 100px">
                            Telefon :
                            <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                            E-Posta :
                            <asp:Label ID="lblMail" runat="server"></asp:Label><br />
                            Adres :
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>
            <div style="width: 49%; height: 70%;float: right">

                <div class="display-table">
                    <div class="display-table-cell">
                        <h1 class="title font-white"><b>Our site is in the construction stage.</b></h1>
                        <p class="desc font-white">
                            Until our site is completed, you can contact us below.
                        </p>
                        <br />
                        <div style="height: 100px">
                            Phone :
                            <asp:Label ID="lblPhone1" runat="server"></asp:Label><br />
                            E-Mail :
                            <asp:Label ID="lblMail1" runat="server"></asp:Label><br />
                            Address :
                            <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>

            <div style="width: 100%; height: 10%;">
                <ul class="social-btn font-white">
                    <li><a href="<%=Facebook %>">Facebook</a></li>
                    <li><a href="<%=Linkedin %>">Linkedin</a></li>
                </ul>
            </div>

        </div>

    </form>
</body>
</html>
