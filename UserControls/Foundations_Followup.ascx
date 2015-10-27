<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Foundations_Followup.ascx.cs" Inherits="UserControls_Foundations_Followup" %>


<head>
<title>متابعة الجهات </title>
 <script language="javascript" type="text/javascript">

        function printGrid() {
            var gridData = document.getElementById('<%= gv_count.ClientID %>');
            var windowUrl = 'about:blank';
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }



 </script>
 </head> 
<table style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="lbl_found" runat="server" CssClass="Label" Text="متابعة الجهات "></asp:Label>
        </td>
    </tr>
  
       <tr>
        <td style="width: 198px">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم الجهة   :  "></asp:Label>
        </td>
        <td>
         <asp:DropDownList ID="ddl_Foundation" runat="server" AutoPostBack="true" CssClass="drop" 
         Width="290" OnSelectedIndexChanged="ddl_Foundation_SelectedIndexChanged">
         
         </asp:DropDownList>
        </td>
    </tr>
    </table>
     
        
    <div id="div_grid" runat="server" align="center">
    <table  id="tbl_grid"> 
    <tr> 
    <td>
    
   
            <asp:GridView ID="gv_count" runat="server" AutoGenerateColumns="False" 
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                 CellPadding="3" GridLines="Vertical">
                <Columns>
                 <asp:BoundField DataField="found_name" HeaderText="إسم الجهة"  />
                 <asp:BoundField DataField="Employee_count" HeaderText="عدد الموظفين"  />
                 <asp:BoundField DataField="Inbox_count" HeaderText="إجمالي عدد الوارد"  />
                 <asp:BoundField DataField="Visa_count" HeaderText="إجمالي عدد تأشيرات الوارد"  />
                 <asp:BoundField DataField="Follows_count" HeaderText="إجمالي عدد متابعات الوارد"  />
                 <asp:BoundField DataField="outbox_count" HeaderText="إجمالي عدد الصادر"  />
                  <asp:BoundField DataField="Visaoutbox_count" HeaderText="إجمالي عدد تأشيرات الصادر"  />
                 <asp:BoundField DataField="Followsoutbox_count" HeaderText="إجمالي عدد متابعات الصادر"  />
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
  <%--  <td>
        <input type="button" value="طباعة" OnClientClick="printGrid()"   class="Button"  runat="server" id="btn_print" ToolTip="Click to Print All Records"/>

    </td>--%>
        <td align="center"  style="align-content:center">

               <asp:Button runat="server" Text="طـــبــاعــة" ValidationGroup="A" CssClass="Button"
                     ID="btn_print"  OnClientClick="printGrid()"   ></asp:Button>

        </td>
      
    </tr>
     </table>
     </div> 
       
  