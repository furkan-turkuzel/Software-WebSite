<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="CommonPage.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.CommonPage" EnableEventValidation="false" %>

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
                            <span>Genel Bilgiler</span>
                            <asp:Label ID="lblInfo" runat="server" Visible="false"></asp:Label>
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
                        <h4 class="page-header">Genel Bilgiler</h4>
                        <div class="form-horizontal" role="form">

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Logo</label>
                                <div class="col-sm-10">
                                    <div class="col-sm-7">
                                        <asp:FileUpload ID="flResim" runat="server" />
                                    </div>
                                    <div class="col-sm-5">
                                        <a class="pull-right">
                                            <asp:Image ID="ImgCommon" runat="server" Width="200" Height="200" CssClass="img-thumbnail" /><br />
                                            <asp:Button ID="btnResim" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="200" OnClick="btnResim_Click" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Şirket İsmi</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtCompanyName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidatorCompanyName" runat="server" ErrorMessage="Şirket İsmi Boş bırakılamaz!" ControlToValidate="txtCompanyName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">URL</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtURL" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Başlık</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Başlık Boş Bırakılamaz!" ControlToValidate="txtTitle" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="form-styles">Writing</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtWriting" TextMode="MultiLine"></asp:TextBox>
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
