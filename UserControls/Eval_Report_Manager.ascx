<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Eval_Report_Manager.ascx.cs" Inherits="UserControls_Eval_Report_Manager" %>
<table style="width: 51%; display: block; height: 238px; line-height: 2;" id="tbl_Report"
    runat="server">
  
<tr id="Tr1" runat="server">
        <td style="width: 288px">
            <div id="div1" style="display: block; width: 493px;">
                <table style="line-height: 2; width: 121%">
                    <tr id="tr_empevalfunc" runat="server" >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="eval_empLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_empLB_Click">  طباعة تقرير تقييم الأداء الوظيفي</asp:LinkButton>
                        </td>
                    </tr>
                    </table>
                    </div>
                    </td>
                    </tr>
 </table>
