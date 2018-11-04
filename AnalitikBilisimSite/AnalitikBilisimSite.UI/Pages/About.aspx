<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="about" style="margin-top: 80px;">
        <div class="container">
            <header class="section-header">
                <h3>
                    <asp:Label ID="lblAboutTitle" runat="server"></asp:Label>
                </h3>
                <p>
                    <asp:Label ID="lblAboutWriting" runat="server"></asp:Label>
                </p>
            </header>

            <div class="row about-cols">

                <div class="col-md-12 wow fadeInUp">
                    <div class="about-col">
                        <h2 class="title" style="padding-top:10px;">
                            <asp:Label ID="lblMissionTitle" runat="server"></asp:Label>
                        </h2>
                        <div class="col-md-4" style="float: left;max-width: 300px;margin-top:-20px;">
                            <asp:Image ID="ImgMission" runat="server" Width="250" Height="150" />
                        </div>
                        <div class="col-md-9" style="max-width: 100%">
                            <p>
                                <asp:Label ID="lblMissionWriting" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 wow fadeInUp" data-wow-delay="0.1s">
                    <div class="about-col">
                        <h2 class="title" style="padding-top:10px;">
                            <asp:Label ID="lblPlanTitle" runat="server"></asp:Label>
                        </h2>
                        <div class="col-md-4 img" style="float: left;max-width: 300px;margin-top:-20px;">
                            <asp:Image ID="ImgPlan" runat="server" Width="250" Height="150" />
                        </div>
                        <div class="col-md-9" style="max-width: 100%">
                            <p>
                                <asp:Label ID="lblPlanWriting" runat="server"></asp:Label>
                            </p>
                        </div>

                    </div>
                </div>

                <div class="col-md-12 wow fadeInUp" data-wow-delay="0.2s">
                    <div class="about-col">
                        <h2 class="title" style="padding-top:10px;">
                            <asp:Label ID="lblVisionTitle" runat="server"></asp:Label>
                        </h2>
                        <div class="col-md-4 img" style="float: left;max-width: 300px;margin-top:-20px;">
                            <asp:Image ID="ImgVision" runat="server" Width="250" Height="150"/>
                        </div>
                        <div class="col-md-9" style="max-width: 100%">
                            <p>
                                <asp:Label ID="lblVisionWriting" runat="server"></asp:Label>
                            </p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
