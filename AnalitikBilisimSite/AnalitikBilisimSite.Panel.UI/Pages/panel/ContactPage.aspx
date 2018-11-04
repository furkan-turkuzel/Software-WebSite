<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.panel.ContactPage" EnableEventValidation="false" %>

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
                        <span>İletişim</span>
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
                    <h4 class="page-header">İletişim Bilgileri</h4>
                    <div class="form-horizontal" role="form">

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Telefon</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPhone" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Telefon Boş Bırakılamaz!" ControlToValidate="txtPhone" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Telefon Formatı Yanlış!" ControlToValidate="txtPhone" ForeColor="Red" ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Faks</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtFax" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Faks Boş Bırakılamaz!" ControlToValidate="txtFax" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Faks Formatı Yanlış!" ControlToValidate="txtFax" ForeColor="Red" ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtMail" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email Boş Bırakılamaz!" ControlToValidate="txtMail" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Mail Formatı Yanlış!" ControlToValidate="txtMail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Adres</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Adres Boş Bırakılamaz!" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Facebook</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtFacebook" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="URL Formatı Yanlış!" ControlToValidate="txtFacebook" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Twitter</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtTwitter" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="URL Formatı Yanlış!" ControlToValidate="txtTwitter" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">İnstagram</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtInstagram" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="URL Formatı Yanlış!" ControlToValidate="txtInstagram" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Youtube</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtYoutube" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="URL Formatı Yanlış!" ControlToValidate="txtYoutube" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Linkedin</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtLinkedin" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="URL Formatı Yanlış!" ControlToValidate="txtLinkedin" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Google Plus</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtGoogle" runat="server" class="form-control" data-toggle="tooltip" data-placement="bottom" title="Tooltip for name"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="URL Formatı Yanlış!" ControlToValidate="txtGoogle" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-md-2 control-label" for="form-styles">Google Map</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" class="form-control" Rows="5" ID="txtMap" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Google Map alanı Boş Bırakılamaz!" ControlToValidate="txtMap" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />

                        <%--<div class="form-group">
                            <label class="col-sm-2 control-label" for="form-styles">Aktif mi</label>
                            <div class="col-sm-10">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Aktif" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Pasif" Value="2" style="margin-left: 20px"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <br />--%>

                        <div class="form-group" style="float: right">
                            <div class="col-sm-2">
                                <asp:Button ID="btnAbout" runat="server" Text="Güncelle" class="btn btn-primary btn-label-left btn" OnClick="btnAbout_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

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
