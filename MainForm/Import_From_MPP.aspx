<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Import_From_MPP.aspx.cs" Inherits="WebForms2_Import_From_MPP" Title="إستيراد أنشطة المشروع" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="2" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="  استيراد أنشطة المشروع من  Microsoft Project" />
            </td>
        </tr>
        
        <tr>
            <td align="right" >
                <asp:Label ID="Label40" runat="server" CssClass="Label" Text="ملف Microsoft Project :"  />
            </td>
            <td align="right">
                <asp:FileUpload ID="FileUpload" runat="server" ForeColor="Maroon" Width="400px" />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
             <br />
              <br />
                <asp:Button ID="btn_Upload" OnClick="btn_Upload_Click" 
                    Text="تحميل" runat="server" CssClass="Button" />
                    
                    
            </td>
             
        </tr>
       <%-- <tr>
            <td colspan="2" align="center">
             <br />
              <br />
                <asp:Button ID="Button1" OnClick="btn_Create_Click" 
                    Text="Create" runat="server" CssClass="Button" />
                    
                    
            </td>
            
        </tr>--%>
    </table>
</asp:Content>
