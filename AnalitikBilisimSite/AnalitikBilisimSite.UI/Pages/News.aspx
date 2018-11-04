<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.News" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="about" style="padding-top:130px;">
        <div class="container">
            <header class="section-header">
                <h3>
                    <asp:Label ID="lblNewsTitle" runat="server"></asp:Label>
                </h3>
            </header>
            <div class="row about-cols">
                <asp:ListView ID="ListNews" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 wow fadeInUp">
                            <div class="about-col" style="height:380px;">
                                <div class="img">
                                    <asp:Image ID="ImgNews" runat="server" Width="100%" ImageUrl='<%#Eval("Image") %>' Height="150" />
                                </div>
                                <h2 class="title">
                                    <asp:Label ID="lblNewsTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                </h2>
                                <p>
                                    <asp:Label ID="lblNewsWriting" runat="server" Text='<%#Eval("BigWriting")+"..."%>'></asp:Label>
                                    <asp:LinkButton ID="btnNews" runat="server" OnClick="btnNews_Click" CommandArgument='<%#Eval("ID") %>' style="float:right;"><%=More %></asp:LinkButton>
                                </p>
                                
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </section>

</asp:Content>
