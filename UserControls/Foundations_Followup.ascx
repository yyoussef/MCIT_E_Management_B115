<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Foundations_Followup.ascx.cs" Inherits="UserControls_Foundations_Followup" %>


<head>
<title>متابعة الجهات </title>
 <script language="javascript" type="text/javascript">
        function printDiv(divID) {

            var divElements = document.getElementById(divID);

            var oldPage = document.body.innerHTML;


            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";


            window.print();


            document.body.innerHTML = oldPage;


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
    <table > 
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
    <td>
        <input type="button" value="طباعة" onclick="javascript:printDiv('div_grid')"  class="Button"  runat="server" id="btn_print"/>

    </td>
    </tr>
     </table>
     </div> 
       
  