<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Eval_Reports.aspx.cs" Inherits="WebForms2_Eval_Reports" Title="تقارير التقييم" %>




<%@ Register src="../UserControls/Eval_Reports.ascx" tagname="Eval_Reports" tagprefix="uc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%><uc1:Eval_Reports ID="Eval_Reports" runat="server" />
&nbsp;
</asp:Content>
