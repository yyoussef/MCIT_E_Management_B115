<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project_services.ascx.cs"
    Inherits="UserControls_Project_services" %>
<div>
    <input id="Presentation_ID" runat="server" type="hidden" value="0" />
    <input id="mode" runat="server" type="hidden" value="new" />
    <input type="hidden" runat="server" id="hidden_Id" />
    <input type="hidden" runat="server" id="hidden_Proj_id" />
    <input type="hidden" runat="server" id="hidden_type" />
    <input type="hidden" runat="server" id="hidden_flag" value="0" />
   
</div>
<div>
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="3" style="height: 33px">
              
                <asp:Label ID="Lbldeliv" runat="server" CssClass="PageTitle" Text="الخدمات" Visible="true" />
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="خدمات مواطنين:" />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txt_citizens" Width="700px" TextMode="MultiLine"
                    Height="100px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="خدمات جهات حكومية:" />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txt_gov" Width="700px" TextMode="MultiLine"
                    Height="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="height: 26px">
                <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
            </td>
        </tr>
       
    </table>
</div>
