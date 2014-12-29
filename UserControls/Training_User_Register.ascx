<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_User_Register.ascx.cs"
    Inherits="UserControls_Training_User_Register" %>
<style type="text/css">
    .style2
    {
        height: 251px;
    }
</style>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <tr>
        <td>
            <asp:Label ID="label1" runat="server" Text="اسم الدوره التدريبيه" CssClass="PageTitle" ></asp:Label>
        </td>
        
        <td >
            <asp:TextBox ID="tx_coursename" runat="server" Enabled="False" CssClass="Text"  Height="69px" TextMode="MultiLine" 
                                         Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label2" runat="server" Text="مكان اللانعقاد" CssClass="PageTitle" ></asp:Label> 
        </td>
        
        <td >
            <asp:TextBox ID="tx_courseplace" runat="server" Enabled="False" CssClass="Text" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label3" runat="server" Text="القائم بالتدريس" 
                CssClass="PageTitle" ></asp:Label>
        </td>
        
        <td>
            <asp:TextBox ID="tx_organization" runat="server" Enabled="False" CssClass="Text"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label4" runat="server" Text="اخر تاريخ للتسجيل" CssClass="PageTitle" ></asp:Label>
        </td>
       
        <td >
            <asp:TextBox ID="tx_lastgenertiondate" runat="server" CssClass="Text" 
                Enabled="False"></asp:TextBox>
        </td>
    </tr>
    
      <tr>
              <td >
     
                 <asp:Label ID="Label9" runat="server" Text="تاريخ البداية" 
                CssClass="PageTitle"></asp:Label>

                </td>
                <td>
                                <asp:TextBox ID="txt_startdate" runat="server" Enabled="False"></asp:TextBox>

                </td>
                </tr>
                <tr>
              
              <td >
                     
                 <asp:Label ID="Label11" runat="server" Text="تاريخ النهايه" 
                CssClass="PageTitle"></asp:Label>
                     
           </td>

           <td>
              <asp:TextBox ID="txt_enddate" runat="server" Enabled="False"></asp:TextBox>

           </td>
              
            </tr>
    
    <tr>
        <td>
            <asp:Label ID="label5" runat="server" Text="عدد الموظفين المطلوب" CssClass="PageTitle" ></asp:Label>
        </td>
        
        <td c>
            <asp:TextBox ID="tx_noofemployee" runat="server" CssClass="Text" 
                Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="شروط الترشح" CssClass="PageTitle"></asp:Label>
        </td>
        
        <td >
            <asp:TextBox ID="txt_candidatecriteria" runat="server" Enabled="False" 
                Height="96px" TextMode="MultiLine" Width="346px"  CssClass="Text" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="المده بالايام" CssClass="PageTitle"></asp:Label>
        </td>
       
        <td >
            <asp:TextBox ID="txt_duration" runat="server" Enabled="False"  CssClass="Text" ></asp:TextBox>
        </td>
    </tr>
    
     <tr>
        <td>
            <asp:Label ID="lbl_cost" runat="server" Text=" القيمة المالية" CssClass="PageTitle" ></asp:Label>
        </td>
       
        <td >
            <asp:TextBox ID="txt_cost" runat="server" Enabled="False"  CssClass="Text" ></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td class="style2">
            <asp:Label ID="Label8" runat="server" Text="ملفات الدوره التدريبيه" 
                CssClass="PageTitle"></asp:Label>
      </td>
      
        <td class="style2" >
            <asp:GridView ID="gv_files" runat="server" AlternatingRowStyle-CssClass="alt" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" CssClass="mGrid" 
                EmptyDataText="... عفوا لا يوجد بيانات ..." Font-Size="17px" ForeColor="Black" 
                PagerStyle-CssClass="pgr" 
                utoGenerateColumns="False" Width="100%" CellPadding="3" 
                GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="الوثيقة">
                        <ItemTemplate>
                            <a href='<%# "ALL_Document_Details.aspx?type=training&category=1&id="+ Eval("id") %>'>
                                                        <%# Eval("file_name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
        </td>
    </tr>
  
            
    <tr>
                                    <td>
                                        <asp:Label runat="server" Text="ملاحظات" CssClass="Label" ID="Label25" ></asp:Label>

                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" ReadOnly=true CssClass="Text" Height="100px" Width="700px" ID="txt_desc"></asp:TextBox>

                                    </td>
                                </tr>
  
            
    <tr align="center">
    <td colspan=2>
    <asp:Button ID="Button1" runat="server" Text="تسجيل" onclick="Button1_Click" ValidationGroup="A"
            CssClass="Button" Enabled="true"   ></asp:Button>
    </td>
    <td>
        &nbsp;</td>
    </tr>
    </table>
