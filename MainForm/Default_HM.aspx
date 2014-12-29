<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Default_HM.aspx.cs" Inherits="MainForm_Default" Title="الرئيسية" %>

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
<%@ Register Src="~/UserControls/ReviewUserControl.ascx" TagName="ReviewUserControl" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Vacations_View.ascx" TagName="Vacations_View" TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/TrainingCounter.ascx" TagName="TrainingCounter"
    TagPrefix="UCTrainingCounter" %>
<%@ Register Src="~/UserControls/EvaluationCounter.ascx" TagName="EvaluationCounter"
    TagPrefix="UCEvaluationCounter" %>
<%@ Register Src="~/UserControls/Archiving_Inbox.ascx" TagName="Archiving_Inbox"
    TagPrefix="UC10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('collapse') != -1) {
                img.src = "../Images/expand.gif";
            }
            else {
                img.src = "../Images/collapse.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
   
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="10000">
            </asp:Timer>
            <input id="proj_id" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;" align="center" id="table1" runat="server">
                <tr runat="server" id="tr_Liks">
                    <td align="center">
                        <table id="tb" runat="server" style="width: 100%" cellpadding="3">
                            <tr id="Tr2" runat="server" visible="false">
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
                            <tr id="Tr3" runat="server" visible="false">
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
                            <tr id="Tr1" runat="server" visible="false">
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
                            <tr id="Tr_file_Archive" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <UC10:Archiving_Inbox ID="pfile1" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr4" runat="server" visible="false">
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
                            <tr id="Tr5" runat="server" visible="false">
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
                            <tr id="Tr6" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc6:ReviewUserControl ID="ReviewUserControl" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr9" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <uc9:Vacations_View ID="Vacations_View" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr10" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <UCTrainingCounter:TrainingCounter ID="UCTrainingCounter" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr11" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <UCEvaluationCounter:EvaluationCounter ID="EvaluationCounter" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr7" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr8" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr12" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr13" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           
                            <tr id="Tr16" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr17" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            
                            <tr id="Tr19" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr20" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr21" runat="server" visible="false">
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
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
