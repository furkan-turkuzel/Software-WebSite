<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.panel.ProfilePage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlAlert" runat="server">
        <div class="col-md-12" id="alert">
            <div class="alert alert-<%=alert %>">
                <asp:Label ID="lblUyari" runat="server"></asp:Label>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlIslem">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="box">
                    <div class="box-header">
                        <div class="box-name">
                            <i class="fa fa-search"></i>
                            <span>Profil</span>
                            <asp:Label ID="lblInfo" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblInfo2" runat="server" Visible="false"></asp:Label>
                        </div>
                        <div class="box-icons">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="expand-link">
                                <i class="fa fa-expand"></i>
                            </a>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                        <div class="no-move"></div>
                    </div>
                    <div class="box-content">
                        <h4 class="page-header">Profil Bilgileri</h4>
                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Resim</label>
                                <div class="col-sm-10">
                                    <div class="col-sm-7">
                                        <asp:FileUpload ID="flResim" runat="server" />
                                    </div>
                                    <div class="col-sm-5">
                                        <a class="pull-right">
                                            <asp:Image ID="ImgAdmin" runat="server" Width="200" Height="200" CssClass="img-thumbnail" /><br />
                                            <asp:Button ID="btnResim" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="200" OnClick="btnResim_Click" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Kullanıcı Adı</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">İsim</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidatorFirstName" runat="server" ErrorMessage="İsim boş bırakılamaz!" ControlToValidate="txtFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Soyisim</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidatorLastName" runat="server" ErrorMessage="Soyisim Boş Bırakılamaz!" ControlToValidate="txtLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">E-mail</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtMail" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidatorMail" runat="server" ErrorMessage="Mail Boş Bırakılamaz!" ControlToValidate="txtMail" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="ValidatorMailFormat" runat="server" ErrorMessage="Mail Formatı Yanlış!" ControlToValidate="txtMail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Facebook</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtFacebook" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="ValidatorFacebook" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtFacebook" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Twitter</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtTwitter" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="ValidatorTwitter" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtTwitter" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">İnstagram</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtInstagram" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="ValidatorInstagram" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtInstagram" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Youtube</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtYoutube" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="ValidatorYoutube" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtYoutube" ForeColor="Red" ValidationExpression="Link(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Linkedin</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtLinkedin" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="ValidatorLinkedin" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtYoutube" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Parola</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidatorPassword" runat="server" ErrorMessage="Parola Boş Bırakılamaz!" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Parola Tekrar</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtPasswordAgain" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidatorPasswordAgain" runat="server" ErrorMessage="Parola Boş Bırakılamaz!" ControlToValidate="txtPasswordAgain" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValidatorComparePassword" runat="server" ErrorMessage="Parolalar Birbiri ile Eşleşmiyor!" ControlToCompare="txtPassword" ControlToValidate="txtPasswordAgain" ForeColor="Red"></asp:CompareValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Admin Rolü</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="drpAdminRole" runat="server" Class="dropdown">
                                        <asp:ListItem>High</asp:ListItem>
                                        <asp:ListItem>Middle</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="form-styles">Dil</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="col-sm-6">
                                    <asp:Button runat="server" Text="Güncelle" class="btn btn-large btn-primary" ID="btnGuncelle" OnClick="btnGuncelle_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>


</asp:Content>
