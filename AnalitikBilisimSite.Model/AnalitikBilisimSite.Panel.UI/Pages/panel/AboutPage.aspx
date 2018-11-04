<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="AboutPage.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.panel.AboutPage" EnableEventValidation="false" %>

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

    <div class="row">
        <div class="col-xs-12 col-sm-12">
            <div class="box">
                <div class="box-header">
                    <div class="box-name">
                        <i class="fa fa-search"></i>
                        <span>Hakkımızda</span>
                        <asp:Label ID="lblInfo" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblInfo1" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblInfo2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblInfo3" runat="server" Visible="false"></asp:Label>
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
                    <h4 class="page-header">Hakkımızda Bilgileri</h4>
                    <div class="form-horizontal" role="form">

                        <div class="form-group">
                            <label class="col-md-2 control-label">Resim</label>
                            <div class="col-md-10">
                                <div class="col-md-12" style="margin-bottom: 30px;">
                                    <asp:FileUpload ID="flResim" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <a>
                                        <asp:Image ID="ImgAbout" runat="server" Width="100" Height="100" Class="img-thumbnail" /><br />
                                        <asp:Button ID="btnResim" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="100" OnClick="btnResim_Click" />
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a>
                                        <asp:Image ID="ImageMission" runat="server" Width="100" Height="100" Class="img-thumbnail" /><br />
                                        <asp:Button ID="btnMission" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="100" OnClick="btnResim_Click" />
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a>
                                        <asp:Image ID="ImagePlan" runat="server" Width="100" Height="100" Class="img-thumbnail" /><br />
                                        <asp:Button ID="btnPlan" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="100" OnClick="btnResim_Click" />
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a>
                                        <asp:Image ID="ImageVision" runat="server" Width="100" Height="100" Class="img-thumbnail" /><br />
                                        <asp:Button ID="btnVision" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="100" OnClick="btnResim_Click" />
                                    </a>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-2 control-label">Başlık</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBaslik" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Başlık Alanı Boş Bırakılamaz!" ControlToValidate="txtBaslik" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label" for="form-styles">Küçük Yazı</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtKucukYazi" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Küçük Yazı Alanı Boş Bırakılamaz!" ControlToValidate="txtKucukYazi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-group">
                            <label class="col-md-2 control-label" for="form-styles">Büyük Yazı</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtBuyukYazi" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Büyük Yazı alanı Boş Bırakılamaz!" ControlToValidate="txtBuyukYazi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label">Misyon Başlık</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMissionTitle" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Misyon Başlık Alanı Boş Bırakılamaz!" ControlToValidate="txtBaslik" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label" for="form-styles">Misyon Yazı</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtMssionWriting" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Misyon Yazı Alanı Boş Bırakılamaz!" ControlToValidate="txtKucukYazi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label">Plan Başlık</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPlanTitle" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Plan Başlık Alanı Boş Bırakılamaz!" ControlToValidate="txtBaslik" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label" for="form-styles">Plan Yazı</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtPlanWriting" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Plan Yazı Alanı Boş Bırakılamaz!" ControlToValidate="txtKucukYazi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label">Vizyon Başlık</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVisionTitle" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Vizyon Başlık Alanı Boş Bırakılamaz!" ControlToValidate="txtBaslik" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label" for="form-styles">Vizyon Yazı</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtVisionWriting" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Vizyon Yazı Alanı Boş Bırakılamaz!" ControlToValidate="txtKucukYazi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group" style="float: right">
                            <div class="col-md-2">
                                <asp:Button ID="btnAbout" runat="server" Text="Güncelle" class="btn btn-primary btn-label-left btn" OnClick="btnAbout_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

<script type="text/javascript">
       
</script>

</asp:Content>
