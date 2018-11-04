<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.AdminPage" EnableEventValidation="false" %>

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

    <asp:Panel ID="pnlSec" runat="server">
        <asp:Button ID="btnSecKaydet" runat="server" Text="Yeni Kullanıcı Ekle" Class="btn btn-large btn-block btn-success" OnClick="btnSecKaydet_Click" />
        <asp:Button ID="btnSecGuncelle" runat="server" Text="Kullanıcı Güncelle veya Sil" Class="btn btn-large btn-block btn-warning" OnClick="btnSecGuncelle_Click" />
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlGuncelle">
        <div id="Services">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="text-align: center">Kullanıcı</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="AdminList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAdmin" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnGuncelleTable" runat="server" Text="Güncelleştir" Class="btn btn-primary" OnClick="btnGuncelleTable_Click" CommandArgument='<%#Eval("ID") %>' />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSilTable" runat="server" Text="Sil" CssClass="btn btn-danger" OnClick="btnSilTable_Click" CommandArgument='<%#Eval("ID") %>'/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
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
                            <span>Admin</span>
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
                        <h4 class="page-header">Admin Bilgileri</h4>
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
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Kullanıcı Adı Boş Bırakılamaz!" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="ValidatorMail" runat="server" ErrorMessage="Mail Boş Bırakılamaz!" ControlToValidate="txtMail" ForeColor="Red"></asp:RequiredFieldValidator><br />
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
                                <asp:RegularExpressionValidator ID="ValidatorYoutube" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtYoutube" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Linkedin</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtLinkedin" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="ValidatorLinkedin" runat="server" ErrorMessage="Link Formatı Yanlış!" ControlToValidate="txtLinkedin" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
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
                                <asp:RequiredFieldValidator ID="ValidatorPasswordAgain" runat="server" ErrorMessage="Parola Boş Bırakılamaz!" ControlToValidate="txtPasswordAgain" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                <asp:CompareValidator ID="ValidatorComparePassword" runat="server" ErrorMessage="Parolalar Birbiri ile Eşleşmiyor!" ControlToCompare="txtPassword" ControlToValidate="txtPasswordAgain" ForeColor="Red"></asp:CompareValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="Regex2" runat="server" ControlToValidate="txtPasswordAgain" ErrorMessage="Şifreniz en az 8 karakter 1 harf, 1 numara ve 1 özel karakter içermeli" ForeColor="Red" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%.*#?&amp;])[A-Za-z\d$@$!%.*#?&amp;]{8,}$" />
                                <br />
                            </div>
                            <br />
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
                                <label class="col-sm-2 control-label" for="form-styles">Aktif mi</label>
                                <div class="col-sm-10">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Aktif" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Pasif" Value="2" style="margin-left: 20px"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="col-sm-6">
                                    <asp:Button runat="server" Text="Kaydet" class="btn btn-large btn-success" ID="btnKaydet" OnClick="btnKaydet_Click" />
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
