﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EvaluationCounter.ascx.cs" Inherits="UserControls_EvaluationCounter" %>



<table style="width: 100%">
    <tr bgcolor="#E6F3FF">
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr bgcolor="#E6F3FF">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('evalDiv','evalImg');">
                        <img border="0" id="evalImg" src="../Images/collapse.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('evalDiv','evalImg');">
                        <asp:Label ID="lblEvaluation" runat="server" Text="تقييم الأداء"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="evalDiv" style="display: none">
                <table>
                    <tr id="tr3" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image22" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td2" runat="server">
                            <asp:LinkButton ID="LinkButton3" OnClick="lnkEvalMng_Click" runat="server" Font-Underline="True"
                                Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnkEvalMng" OnClick="lnkEvalMng_Click" runat="server" CssClass="link"
                                    Font-Size="20px" Visible="true" Font-Underline="true" Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton18" OnClick="lnkEvalMng_Click" runat="server" CssClass="link"
                                    Visible="true" Font-Underline="true" Text="تم تقيمه من المدير المباشر" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td3" runat="server">
                            <asp:LinkButton ID="LinkButton19" OnClick="lnkEvalTop_Click" runat="server" Font-Underline="True"
                                Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnkEvalTop" OnClick="lnkEvalTop_Click" runat="server" CssClass="link"
                                    Font-Size="20px" Visible="true" Font-Underline="true" Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton21" OnClick="lnkEvalTop_Click" runat="server" CssClass="link"
                                    Visible="true" Font-Underline="true" Text="تم تقيمه من المدير الأعلى" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr5" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image24" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td4" runat="server">
                            <asp:LinkButton ID="lnk_not_eval23" OnClick="lnkNotEval_Click" runat="server" Font-Underline="True"
                                Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnkNotEval" OnClick="lnkNotEval_Click" runat="server" CssClass="link"
                                    Font-Size="20px" Visible="true" Font-Underline="true" Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton25" OnClick="lnkNotEval_Click" runat="server" CssClass="link"
                                    Visible="true" Font-Underline="true" Text="لم يتم تقييمه" Font-Size="20px" ForeColor="#275078"
                                    Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
