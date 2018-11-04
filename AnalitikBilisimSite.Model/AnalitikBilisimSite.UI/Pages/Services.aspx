<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="about" style="margin-top: 80px;">
        <div class="container">
            <header class="section-header">
                <h3>
                    <asp:Label ID="lblServicesTitle" runat="server"></asp:Label>
                </h3>
            </header>



            <div class="row about-cols">

                <asp:ListView ID="ListServices" runat="server">
                    <ItemTemplate>
                        <div class="col-md-12 wow fadeInUp">
                            <div class="about-col" style="min-height:200px;">
                                <h2 class="title" style="padding-top: 10px;">
                                    <asp:Label ID="lblServicesTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                </h2>
                                <div class="col-md-4" style="float: left; max-width: 300px;">
                                    <asp:Image ID="ImgServices" runat="server" Width="250" Height="150" ImageUrl='<%#Eval("Image") %>'/>
                                </div>
                                <div class="col-md-9" style="max-width: 100%">
                                    <p>
                                        <asp:Label ID="lblServicesWriting" runat="server" Text='<%#Eval("BigWriting") %>'></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </section>

</asp:Content>
