﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="ReferancePage.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.panel.ReferancePage" EnableEventValidation="false" %>

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
        <asp:Button ID="btnSecKaydet" runat="server" Text="Yeni Referans Ekle" Class="btn btn-large btn-block btn-success" OnClick="btnSecKaydet_Click" />
        <asp:Button ID="btnSecGuncelle" runat="server" Text="Referans Güncelle veya Sil" Class="btn btn-large btn-block btn-warning" OnClick="btnSecGuncelle_Click" />
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlGuncelle">
        <div id="Services">

            <div style="text-align: left;">
                <label class="control-label" for="form-styles">Dile göre listele : </label>
                <asp:DropDownList ID="ddlFilterLanguage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterLanguage_SelectedIndexChanged"></asp:DropDownList>&emsp;
                <label class="control-label" for="form-styles">Referans tipine göre listele : </label>
                <asp:DropDownList ID="ddlFilterReferanceType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterReferanceType_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="text-align: center">Başlık</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="RefList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBaslik" runat="server" Text='<%#Convert.ToInt32(Eval("LanguageID")) == 1?Eval("ReferanceName"):Eval("ReferanceName")+"(ing)"%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnGuncelleTable" runat="server" Text="Güncelleştir" Class="btn btn-primary" OnClick="btnGuncelleTable_Click" CommandArgument='<%#Eval("ID") %>' />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSilTable" runat="server" Text="Sil" CssClass="btn btn-danger" OnClick="btnSilTable_Click" CommandArgument='<%#Eval("ID") %>' />
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
                            <span>Referanslar</span>
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
                        <h4 class="page-header">Referans Bilgileri</h4>
                        <div class="form-horizontal" role="form">

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Resim</label>
                                <div class="col-sm-10">
                                    <div class="col-sm-7">
                                        <asp:FileUpload ID="flResim" runat="server" />
                                    </div>
                                    <div class="col-sm-5">
                                        <a class="pull-right">
                                            <asp:Image ID="ImgRef" runat="server" Width="200" Height="200" Class="img-thumbnail" /><br />
                                            <asp:Button ID="btnResim" CssClass="btn btn-xs btn-info" runat="server" Text="Resmi Getir" Width="200" OnClick="btnResim_Click" />
                                        </a>
                                    </div>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Referans Tipi</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtRefType" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Referans Adı</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtRefName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Referans Adı Boş Bırakılamaz!" ControlToValidate="txtRefName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Referans Telefonu</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtRefPhone" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Referans Telefonu Boş Bırakılamaz!" ControlToValidate="txtRefPhone" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Telefon Formatı Yanlış!" ControlToValidate="txtRefPhone" ForeColor="Red" ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})"></asp:RegularExpressionValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Referans Adresi</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtRefAddress" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Referans Adresi Boş Bırakılamaz!" ControlToValidate="txtRefAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div class="form-group">
                                <label class="col-md-2 control-label" for="form-styles">Açıklama</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtDescription" TextMode="MultiLine"></asp:TextBox>
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



    <script type="text/javascript">
        // Run Select2 plugin on elements
        function DemoSelect2() {
            $('#s2_with_tag').select2({ placeholder: "Select OS" });
            $('#s2_country').select2();
        }
        // Run timepicker
        function DemoTimePicker() {
            $('#input_time').timepicker({ setDate: new Date() });
        }
        $(document).ready(function () {
            // Create Wysiwig editor for textare
            TinyMCEStart('#wysiwig_simple', null);
            TinyMCEStart('#wysiwig_full', 'extreme');
            // Add slider for change test input length
            FormLayoutExampleInputLength($(".slider-style"));
            // Initialize datepicker
            $('#input_date').datepicker({ setDate: new Date() });
            // Load Timepicker plugin
            LoadTimePickerScript(DemoTimePicker);
            // Add tooltip to form-controls
            $('.form-control').tooltip();
            LoadSelect2Script(DemoSelect2);
            // Load example of form validation
            LoadBootstrapValidatorScript(DemoFormValidator);
            // Add drag-n-drop feature to boxes
            WinMove();
        });
</script>

</asp:Content>