<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Store_Resources.aspx.cs" Inherits="WebForms_Store_Resources" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="height: 184px; width: 753px">
   
   <tr>
    <td colspan="3" style="height: 60px; text-align: center;"> 
        <asp:Label ID="Label1" runat="server" CssClass="PageTitle" 
            Text="إدارة الموارد بالمخازن "></asp:Label>
       </td>
   </tr>
   
   <tr>
    <td colspan="3" style="height: 60px; text-align: center;"> 
   <asp:Label ID="labcheck" runat="server" Visible="False" CssClass="Label" 
           ForeColor="Red" style="text-align: center" ></asp:Label>
       <br />
       <asp:RegularExpressionValidator ID="RegularExp" runat="server" 
           ControlToValidate="txtdate" CssClass="Label" Display="Dynamic" 
           ErrorMessage="التاريخ غير صحيح ادخل (يوم / شهر / سنة)" SetFocusOnError="True" 
           
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
           
           Font-Size="18px"></asp:RegularExpressionValidator>
       <br />
       </td>
   </tr>
   
   <tr>
<td dir="rtl" align="justify" style="height: 38px" >
    <asp:Label ID="lbldate" runat="server" 
        Text="تاريخ المتاح :" CssClass="Label" ></asp:Label>
   </td>

   <td  colspan="2" style="height: 38px">
    <asp:TextBox ID="txtdate" runat="server" Text="" CssClass="Text" 
        EnableViewState="False" ></asp:TextBox>


       <cc1:CalendarExtender ID="CalAvailbleDate" runat="server" 
        TargetControlID="txtdate" PopupButtonID="ImageButton1" Enabled="True" 
        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                                       

       <asp:ImageButton ID="ImageButton1" runat="Server" 
        ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
        Height="20px" Width="20px" ToolTip="تقويم" />
       
                                        

</td>

</tr>
<tr>

<td align="justify" dir="rtl" style="width: 259px; height: 38px;" ><asp:Label ID="lblserver" 
        runat="server" Text="عدد الخوادم :" 
        CssClass="Label"></asp:Label></td>
<td style="height: 38px; width: 246px;" >
<asp:TextBox ID="txtserver" runat="server" Text="" CssClass="Text" 
        CausesValidation="True"></asp:TextBox>
        

    </td>
    <td style="height: 38px"> 
        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtserver"
                    Display="Dynamic" ErrorMessage="يجب إدخال أرقام فقط" Operator="DataTypeCheck"
                    SetFocusOnError="True" Type="Integer" CssClass="Label" 
            Font-Size="12pt"></asp:CompareValidator></td>
   
</tr>
<tr>
   <td align="justify" style="width: 259px; height: 45px;" dir="rtl">
     <asp:Label ID="lblpc" runat="server" Text="عدد حاسب آلي :" CssClass="Label" 
           Font-Bold="True"></asp:Label>
   </td>
   <td style="width: 246px; height: 45px;">
<asp:TextBox ID="txtpc" runat="server" Text="" CssClass="Text" 
           CausesValidation="True" ></asp:TextBox>
       </td>
       <td style="height: 45px" class="style2"> 
           <asp:CompareValidator ID="CompareValidator5" 
               runat="server" ControlToValidate="txtpc"
                    Display="Dynamic" ErrorMessage="يجب إدخال أرقام فقط" Operator="DataTypeCheck"
                    SetFocusOnError="True" Type="Integer" CssClass="Label" 
               Font-Size="11pt"></asp:CompareValidator></td>

</tr>

<tr>

     <td align="justify" dir="rtl" style="width: 259px; height: 35px;">
     <asp:Label ID="lblpcb" runat="server" Text="عدد حاسب آلي (Brand name) :" 
         CssClass="Label"></asp:Label>
      </td>
   <td style="width: 246px; height: 35px;">
    <asp:TextBox ID="txtpcb" runat="server" Text="" CssClass="Text" 
           CausesValidation="True"></asp:TextBox>
      
     
    </td>
   <td style="height: 35px"> 
          <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtpcb"
                    Display="Dynamic" ErrorMessage="يجب إدخال أرقام فقط" Operator="DataTypeCheck"
                    SetFocusOnError="True" Type="Integer" CssClass="Label" 
              Font-Size="11pt"></asp:CompareValidator>
           </td>
</tr>

<tr>

<td align="justify" dir="rtl" style="width: 259px; height: 42px;">
 <asp:Label ID="lblprinter" runat="server" Text="عدد طابعات :" CssClass="Label"></asp:Label>
</td>
<td style="width: 246px; height: 42px;">
<asp:TextBox ID="txtprinter" runat="server" Text="" CssClass="Text" 
        CausesValidation="True"></asp:TextBox>

</td>
<td style="height: 42px">
        
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtprinter"
                    Display="Dynamic" ErrorMessage="يجب إدخال أرقام فقط" Operator="DataTypeCheck"
                    SetFocusOnError="True" Type="Integer" CssClass="Label" 
            Font-Size="11pt"></asp:CompareValidator>
        </td>

</tr>
<tr align="center">

<td  colspan="3" style="height: 43px">
<asp:Button runat="server" ID="SaveBtn" text="حفظ" onclick="SaveBtn_Click" 
        CssClass="Button" Font-Overline="False" Font-Size="19px" 
        Font-Strikeout="False" Font-Underline="False" Width="81px" />
    <br />
<asp:Button runat="server" ID="AnotherSaveBtn" text="إضافة موارد أخري" onclick="AnotherSaveBtn_Click" 
        CssClass="Button" Visible="False" Width="134px" />
</td>
</tr>
<tr>
<td  colspan="3" class="Text" dir="rtl" align="center">
    <asp:GridView ID="GridViewStore" runat="server" AutoGenerateColumns="False" CellPadding="3" 
         GridLines="Vertical" CssClass="mGrid"
               PagerStyle-CssClass="pgr" Width="96%" BorderStyle="Solid" BorderWidth="1px"
        DataSourceID="SqlDataSource1" EmptyDataText="... عفوا لا يوجد بيانات ..." 
        BackColor="White" AllowSorting="True" BorderColor="#999999" 
        ForeColor="Black" >
        
        <Columns>
            <asp:BoundField DataField="Server_No" HeaderText="عدد الخوادم" 
                SortExpression="Server_No" />
            <asp:BoundField DataField="PC_No" HeaderText="عدد الحاسبات" 
                SortExpression="PC_No" />
            <asp:BoundField DataField="PC_BrandName_No" HeaderText="عدد الحاسبات (Brand name)" 
                SortExpression="PC_BrandName_No" />
            <asp:BoundField DataField="Printer_No" HeaderText="عدد الطابعات" 
                SortExpression="Printer_No" />
            <asp:BoundField DataField="available_Date" HeaderText="تاريخ المتاح" 
                SortExpression="available_Date" DataFormatString="{0:dd/MM/yyyy}" />
             <asp:TemplateField HeaderText="تعديل">
             <ItemTemplate>
       <a href="Store_Resources.aspx?edit=<%#DataBinder.Eval(Container.DataItem, "id") %>"> 
                 <img border="0" src="../Images/Edit.jpg" alt="تعديل" width="24px" height="24px" 
                     align="middle" /></a>
       
       </ItemTemplate>
             
             </asp:TemplateField>   
            
                
       <asp:TemplateField HeaderText="حذف">
       <ItemTemplate>
       <a href="Store_Resources.aspx?delete=<%#DataBinder.Eval(Container.DataItem, "id") %>"> 
           <img border="0" src="../Images/delete.gif" alt="حذف" height="20px" 
               width="20px"  /></a>
       
       </ItemTemplate>
       
       
       </asp:TemplateField>
        </Columns>
        
         <FooterStyle BackColor="#CCCCCC" />
        
         <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
       <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />        
    </asp:GridView>
    </td>
    </tr>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MCIT_PROJECTSConnectionString %>" 
        
        
           
           
           SelectCommand="SELECT * FROM [store] ORDER BY [available_Date]">
    </asp:SqlDataSource>
    </table>


</asp:Content>