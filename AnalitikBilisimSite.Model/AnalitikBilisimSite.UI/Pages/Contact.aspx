<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="contact" class="section-bg wow fadeInUp">
        <div class="container">

            <div class="section-header">
                <h3>
                    <asp:Label ID="lblContactTitle" runat="server"></asp:Label>
                </h3>
            </div>

            <div class="row contact-info">

                <div class="col-md-4">
                    <div class="contact-address">
                        <i class="ion-ios-location-outline"></i>
                        <h3>
                            <asp:Label ID="lblAddressTitle" runat="server"></asp:Label>
                        </h3>
                        <p>
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="contact-phone">
                        <i class="ion-ios-telephone-outline"></i>
                        <h3>
                            <asp:Label ID="lblPhoneTitle" runat="server"></asp:Label>
                        </h3>
                        <p>
                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="contact-email">
                        <i class="ion-ios-email-outline"></i>
                        <h3>
                            <asp:Label ID="lblMailTitle" runat="server"></asp:Label>
                        </h3>
                        <p>
                            <asp:Label ID="lblMail" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>

            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-6">

                        <div class="form">
                            <div id="sendmessage">
                            </div>
                            <div id="errormessage"></div>
                            <form action="" method="post" role="form" class="contactForm">
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <input type="text" name="name" class="form-control" id="txtName" placeholder= "İsim" data-rule="minlen:4" data-msg="Please enter at least 4 chars" runat="server" />
                                        <div class="validation"></div>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <input type="email" class="form-control" name="email" id="txtMail" placeholder="E-Posta" data-rule="email" data-msg="Please enter a valid email" runat="server" />
                                        <div class="validation"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" name="subject" id="txtSubject" placeholder="Konu" data-rule="minlen:4" data-msg="Please enter at least 8 chars of subject" runat="server" />
                                    <div class="validation"></div>
                                </div>
                                <div class="form-group">
                                    <textarea class="form-control" name="message" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="Mesaj" id="txtMessage" runat="server"></textarea>
                                    <div class="validation"></div>
                                </div>
                                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
                                <div class="text-center">
                                    <asp:Button ID="btnMessage" runat="server" Text="Mesaj Gönder" class="btn btn-success" OnClick="btnMessage_Click" />
                                </div>
                            </form>
                        </div>

                    </div>
                    <div class="col-md-6">

                        <div id="Map" style="text-align: center;">
                            <%=Map %>
                        </div>

                    </div>
                </div>
            </div>


        </div>
    </section>



</asp:Content>
