<%@ Control Language="C#" AutoEventWireup="true" CodeFile="geographic_scope.ascx.cs"
    Inherits="UserControls_geographic_scope" %>
<style type="text/css">
    .style1
    {
        width: 52px;
    }
    .Button
    {
        height: 26px;
    }
</style>
<table style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="النطاق والتوزيع الجغرافي للمشروع"></asp:Label>
        </td>
    </tr>
   
    <tr>
    <td>
    <asp:Label ID="Label2" runat="server" Text="النطاق الجغرافي :" CssClass="Label"></asp:Label>
            <input id="Hid_id" type="hidden" runat="server" />

    </td>
     <td>
        <asp:DataList ID="datalist_gov" runat="server" DataKeyField ="gov_id" 
                RepeatColumns="5"   >
         <ItemTemplate>
          <td>
          <asp:Checkbox ID ="chk_governments"   Text='<%# Eval("gov_name") %>' runat="server"  >
          </asp:Checkbox>
          
          
          </td> 
          <td>
          <asp:TextBox ID="txt_desc" runat="server" TextMode ="MultiLine" > </asp:TextBox>

          </td>
          <td>
          <asp:Label  ID="lbl_geo" runat="server"  Text='<%# Eval("gov_id") %>' Visible="false" ></asp:Label>

          </td>
            
          </ItemTemplate>
       
           </asp:DataList>
           
        
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label3" runat="server" Text=" التوزيع الجغرافي:" CssClass="Label"></asp:Label>
        </td>
        <td style="width: 198px">
            <asp:TextBox ID="txt_geo" runat="server" TextMode="MultiLine" Width="900px" Height="90px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_geo"
                ErrorMessage="يجب ادخال التوزيع الجغرافي" ValidationGroup="scope"></asp:RequiredFieldValidator>
                   
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_Save_scope" runat="server" CssClass="Button" Text="حفظ" OnClick="btn_Save_scope_Click"
                ValidationGroup="scope" />
        </td>
    </tr>
</table>
