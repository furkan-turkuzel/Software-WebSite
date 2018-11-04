<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Referances.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.Referances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg" style="padding-bottom:170px;padding-top:130px;">
        <div class="container">

            <header class="section-header">
                <h3 class="section-title">
                    <asp:Label ID="lblReferenceTitle" runat="server"></asp:Label>
                </h3>
            </header>


            <div class="row portfolio-container">
                <asp:ListView ID="ListReferance" runat="server">
                    <ItemTemplate>

                        <div class="col-lg-3 col-md-6 portfolio-item filter-app wow fadeInUp" style="max-width:25%">
                            <div class="portfolio-wrap">
                                <figure>
                                    <asp:Image ID="ImgReferance" runat="server" ImageUrl='<%#Eval("ReferanceLogo") %>' style="max-width:100%;height:100%;padding:0" />
                                    <a href="img/portfolio/app1.jpg" data-lightbox="portfolio" data-title="App 1" class="link-preview" title="Preview"><i class="ion ion-eye"></i></a>
                                    <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                                </figure>

                                <div class="portfolio-info">
                                    <h4><a href="#">
                                        <asp:Label ID="lblReferanceName" runat="server" Text='<%#Eval("ReferanceName") %>' style="font-size:14px"></asp:Label>
                                        </a></h4>

                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>




            </div>
        </div>
    </section>

</asp:Content>
