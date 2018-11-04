<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.NewsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="features" class="section md-padding bg-grey" style="padding-top:150px;padding-bottom:50px;padding-left:50px;padding-right:50px;">
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
                    <asp:Image ID="ImgAbout" runat="server" Class="img-responsive" Width="600" Height="400" />
					</div>
				</div>
			</div>
		</div>

</asp:Content>
