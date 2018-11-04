<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReferanceDetails.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.ReferanceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="features" class="section md-padding bg-grey">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="section-header">
                        <h2 class="title">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        </h2>
                    </div>
                    <p>
                        <asp:Label ID="lblSmallWriting" runat="server"></asp:Label>
                    </p>
                    <div class="feature">
                        <p>
                            <asp:Label ID="lblBigWriting" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>

                <div class="col-md-6">
                    <asp:Image ID="ImgAbout" runat="server" Class="img-responsive" />
                    <!--<div id="about-slider" class="owl-carousel owl-theme">
						<img class="img-responsive" src="../Assets/./img/about1.jpg" alt="">
						<img class="img-responsive" src="../Assets/./img/about2.jpg" alt="">
						<img class="img-responsive" src="../Assets/./img/about1.jpg" alt="">
						<img class="img-responsive" src="../Assets/./img/about2.jpg" alt="">
                        -->
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
