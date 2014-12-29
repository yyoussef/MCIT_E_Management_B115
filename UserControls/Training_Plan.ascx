<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_Plan.ascx.cs" Inherits="UserControls_Training_Plan" %>

<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table dir="rtl" style="line-height: 2; width: 99%;">

  <tr>
   <td align="center" colspan="4" style="height: 33px">
       <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text=" الخطة التدريبية" />
 </td>
 </tr>

<tr>

 <td>
      <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم الموظف : "  Visible="false" />
 </td>
<td>
      <uc1:Smart_Search ID="Smart_Pmp_Id" runat="server" EnableTheming="True" Visible="false"   />
 </td>
</tr>
            
<tr id="main_cat_subj" runat="server">
  <td id="Td1" runat="server">
    <asp:Label ID="Label44" runat="server" CssClass="Label" Text=" البرامج التدريبية  :" />
    </td>
   <td id="Td2" align="right" runat="server" colspan="3">
   <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 180px"
    dir="rtl" class="borderControl">
  <asp:CheckBoxList ID="Chk_training" CellPadding="5" AutoPostBack="True" CellSpacing="5"
    RepeatColumns="6" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal"
   DataTextField="prog_name" DataValueField="prog_id" runat="server"  OnSelectedIndexChanged="Chk_main_cat_SelectedIndexChanged">
   </asp:CheckBoxList>
   </div>
 </td>
</tr>

    <tr id="tr_emp_list" runat="server">
     <td id="Td3" runat="server">
        <asp:Label ID="Label47" runat="server" CssClass="Label" Text="  الدورات التدريبية :" />
      </td>
   <td id="Td4" align="right" runat="server">
      <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
           dir="rtl" class="borderControl">
      <asp:CheckBox ID="chk_ALL" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal"
      Text="اختر الكل" AutoPostBack="True" runat="server" OnCheckedChanged="chk_ALL_CheckedChanged">
     </asp:CheckBox>
      <asp:CheckBoxList ID="chklst_train_All" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                  CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="course_name"
                   DataValueField="prog_id" runat="server">
        </asp:CheckBoxList>
        </div>
     </td>
  <td id="Td5" runat="server">
        <asp:Button ID="btn_add" OnClick="btn_add_Click" Text="إضافة" runat="server" CssClass="Button" />
          <asp:Button ID="btn_delete" OnClick="btn_delete_Click" Text="مسح" runat="server"
                    CssClass="Button" />
  </td>
  <td id="Td6" runat="server">
       <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
               dir="rtl" class="borderControl">
    <asp:ListBox ID="lst_train" runat="server" Height="270px" Width="300px" Font-Size="Small" DataTextField="course_name" DataValueField="course_id">
         </asp:ListBox>
    </div>
      </td>
    </tr>
    <tr>
    <td>
          
    </td>
    <td>
     <asp:Button ID="btn_save" OnClick="btn_save_Click" ValidationGroup="B" Text="حفظ"
            runat="server" CssClass="Button" />
    </td>

    </tr>
    
  </table> 
