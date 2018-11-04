<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/panel/Master.Master" AutoEventWireup="true" CodeBehind="VisitorPage.aspx.cs" Inherits="AnalitikBilisimSite.Panel.UI.Pages.panel.VisitorPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Visitor.css" rel="stylesheet" />
    <script src="plugins/jquery-ui-timepicker-addon/i18n/jquery-ui-timepicker-tr.js"></script>
    <link href="plugins/jquery-ui-timepicker-addon/jquery-ui-timepicker-addon.min.css" rel="stylesheet" />
    <script src="plugins/fullcalendar/fullcalendar.js"></script>
    <link href="plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" />
    <script src="plugins/jquery/jquery.min.js"></script>
    <script src="plugins/jquery-ui/jquery-ui.js"></script>
    <link href="plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblControl" runat="server" Visible="false"></asp:Label>
    <div id="container">
        <div id="yanPanel">
            <ul id="yanPanelList">
                <li>
                    <a href="Index.aspx">
                        <i class="fa fa-envelope"></i>
                        <span>
                            <asp:Button ID="btnOkunmayan" runat="server" Text="Okunmayanlar" Style="border: none; background-color: transparent" OnClick="btnOkunmayan_Click" />
                        </span>
                    </a>
                </li>
                <li>
                    <a href="index.html">
                        <i class="fa fa-envelope-o"></i>
                        <span>
                            <asp:Button ID="btnOkunan" runat="server" Text="Okunanlar" Style="border: none; background-color: transparent" OnClick="btnOkunan_Click" />
                        </span>
                    </a>
                </li>
            </ul>
        </div>
        <div id="mesajBlok">

            <div style="text-align: left; margin-left: 20px;">
                <div id="calender1" style="width: 20%; display: inline-block">
                    <asp:Label ID="lblCld1" runat="server" Text="Başlangıç Tarihi" Style="text-align: center; font-weight: bold;" Width="230"></asp:Label>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
                        <SelectedDayStyle BackColor="#666666" />
                    </asp:Calendar>
                    <br />
                    <asp:TextBox ID="txtCalender1" runat="server" Width="230px" Style="text-align: center; font-weight: bold;"></asp:TextBox>
                </div>

                <div id="calender2" style="width: 20%; display: inline-block">
                    <asp:Label ID="lblCld2" runat="server" Text="Bitiş Tarihi" Style="text-align: center; font-weight: bold;" Width="230"></asp:Label>
                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged">
                        <SelectedDayStyle BackColor="#666666" />
                    </asp:Calendar>
                    <br />
                    <asp:TextBox ID="txtCalender2" runat="server" Width="230px" Style="text-align: center; font-weight: bold;"></asp:TextBox>
                </div>

                <div id="calender3" style="width: 40%; display: inline-block; position: absolute; margin-top: 100px;">
                    <asp:Button ID="btnCalender" runat="server" Text="filtrele" CssClass="btn btn-warning btn-block" OnClick="btnCalender_Click" />
                </div>


            </div>
            <asp:ListView ID="ListMessage" runat="server">
                <ItemTemplate>
                    <div id="mesajLine">
                        <div id="mesajNameSubject">
                            <div id="mesajName">
                                <asp:CheckBox ID="cbOkundu" runat="server" Checked='<%#Eval("Readed") %>' />
                                <asp:Label ID="lblModalName" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                            </div>
                            <div id="mesajSubject">
                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                            </div>

                        </div>

                        <div id="mesajYazıTarih">
                            <div id="mesajYazı">
                                <div id="yazı">
                                    <asp:Label ID="lblMessage" runat="server" Text='<%#Eval("Message") %>'></asp:Label>
                                </div>
                                <div id="buton">

                                    <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-danger" Style="float: right;" CommandArgument='<%#Eval("ID") %>' OnClick="btnSil_Click" />
                                    <asp:Button ID="btnOku" runat="server" Text="Oku" class="btn btn-info" Style="float: right; margin-right: 5px;" CommandArgument='<%#Eval("ID") %>' OnClick="btnOku_Click" />
                                    <button id="btnModal" type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal" style="display: none;">Oku</button>
                                </div>

                            </div>

                            <div id="mesajTarih">
                                <div id="tarihBlok">
                                    <asp:Label ID="lblMessageDate" runat="server" Text='<%#Eval("SendTime") %>'></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <asp:Label ID="lblKonu" runat="server"></asp:Label>
                    </h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnModal").click();
        }
    </script>

</asp:Content>
