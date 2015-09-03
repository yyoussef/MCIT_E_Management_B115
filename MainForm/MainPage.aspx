<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="MainPage.aspx.cs" Inherits="MainForm_MainPage" Title="الرئيسية" %>

<%@ Register Src="~/UserControls/ProjectsUserControl.ascx" TagName="ProjectsUserControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/inboxUserControl.ascx" TagName="inboxUserControl"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/OutboxUserControl.ascx" TagName="OutboxUserControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/PNeedsUserControl.ascx" TagName="PNeedsUserControl"
    TagPrefix="uc4" %>
    <%@ Register Src="~/UserControls/CommissionUserControl.ascx" TagName="CommissionUserControl"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
                img.src = "../Images/square_arrow_down.gif";
            }
            else {
                img.src = "../Images/square_arrow_flipped.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
   
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="proj_id" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;" align="center" id="table1" runat="server">
                <tr runat="server" id="tr_Liks">
                    <td align="center">
                        <table id="tb" runat="server" style="width: 100%" cellpadding="3">
                            <tr id="Tr1" runat="server">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc1:ProjectsUserControl ID="ProjectsUserControl" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc2:inboxUserControl ID="inboxUserControl" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc3:OutboxUserControl ID="OutboxUserControl" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr4" runat="server">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc4:PNeedsUserControl ID="PNeedsUserControl" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                             <tr id="Tr5" runat="server">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc5:CommissionUserControl ID="CommissionUserControl" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
