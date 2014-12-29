<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" CodeFile="Foundation_localconnection.aspx.cs" Inherits="Admin_Foundation_localconnection" Title="مسار قاعدة البيانات " %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <table style="width: 100%">
    <tr>
       <td>
                <input id="found_id" type="hidden" runat="server" />
            </td>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lbl_found" runat="server" CssClass="Label" Text="مسار قاعدة البيانات الداخلية لحفظ الملفات "></asp:Label>
            </td>
        </tr>
        
         <tr id="tr_local" runat="server" >
            <td style="width: 198px">
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="مسار قاعدة البيانات"  ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_connstring"  runat="server" Width="282px"  Height="70px" TextMode="MultiLine" Text="Data Source=...;Initial Catalog=...;Persist Security Info=True;User ID=...;Password=..."></asp:TextBox>
                
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="برجاء ملئ مكان النقاط بالبيانات الفعلية "  ></asp:Label>
                
            </td>
        </tr>
        
                <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="B"
                    OnClick="btnSave_Click" />
            </td>
            
             <td colspan="2" align="center">
                <asp:Button ID="btn_create" runat="server" CssClass="Button" Text="إنشاء" ValidationGroup="B"
                    OnClick="btn_create_Click"  Visible="false"  />
            </td>
            
        </tr>
   
   
   </table> 
</asp:Content>

