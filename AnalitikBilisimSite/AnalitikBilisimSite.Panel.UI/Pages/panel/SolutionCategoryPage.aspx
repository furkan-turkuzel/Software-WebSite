﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="SolutionCategoryPage.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.panel.SolutionCategoryPage" EnableEventValidation="false" %>

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
        <asp:Button ID="btnSecKaydet" runat="server" Text="Yeni Kategori Ekle" Class="btn btn-large btn-block btn-success" OnClick="btnSecKaydet_Click" />
        <asp:Button ID="btnSecGuncelle" runat="server" Text="Kategori Güncelle veya Sil" Class="btn btn-large btn-block btn-warning" OnClick="btnSecGuncelle_Click" />
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlGuncelle">
        <div id="Services">

            <div style="text-align: left;">
                <label class="control-label" for="form-styles">Dile göre listele : </label>
                <asp:DropDownList ID="ddlFilterLanguage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterLanguage_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="text-align: center">Kategory</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="CategoryList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBaslik" runat="server" Text='<%#Convert.ToInt32(Eval("LanguageID")) == 1?Eval("CategoryName"):Eval("CategoryName")+"(ing)"%>'></asp:Label>
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
                            <span>Çözüm Kategori</span>
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
                        <h4 class="page-header">Çözüm Kategori Bilgileri</h4>
                        <div class="form-horizontal" role="form">

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Kategori Adı</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtCategoryName" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Kategori Adı Boş Bırakılamaz!" ControlToValidate="txtCategoryName" ForeColor="Red"></asp:RequiredFieldValidator>
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

</asp:Content>
