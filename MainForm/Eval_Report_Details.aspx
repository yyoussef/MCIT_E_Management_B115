<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Eval_Report_Details.aspx.cs"
    Inherits="MainForm_Eval_Report_Details" Title="Untitled Page" %>

<style type="text/css">
    .Label
    {
        font-family: Arial;
        font-weight: bold;
        font-size: 18px;
        color: #1F4569;
        margin-left: 3px;
        text-align: right;
    }
    .Text
    {
        font-family: Arial;
        font-size: 19px;
        height: 27px;
        text-align: right;
    }
    .Button
    {
        font-family: Arial;
        font-weight: 500;
        font-size: large;
        color: #1F4569;
        background-color: #C2DDF0;
        width: 85px;
    }
    .mGrid
    {
        width: 100%;
        background-color: #fff;
        margin: 5px 5px 10px 0;
        border: solid 1px #A1D4E9;
        border-square_arrow_flipped: square_arrow_flipped;
        text-align: right;
    }
    .style1
    {
        width: 1020px;
        text-align: right;
    }
    .style2
    {
        width: 590px;
    }
    .style3
    {
        width: 633px;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Untitled Page</title>

   <script language="javascript" type="text/javascript">
        function printDiv(divID) {

            var divElements = document.getElementById(divID).innerHTML;

            var oldPage = document.body.innerHTML;


            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";


            window.print();


            document.body.innerHTML = oldPage;


        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <input type="button" value="طباعة" onclick="javascript:printDiv('div1')" />
    <div id="div1" runat="server" align="right">
        <table>
            <tr>
                <td dir="ltr" style="text-align: right" class="style3">
                    &nbsp;
                </td>
                <td class="style2" style="text-align: right">
                    <asp:Label ID="Label20" runat="server" Text="تقرير تقييم الاداء الوظيفي للمديرين"
                        CssClass="Label"></asp:Label>
                </td>
                <td class="style1">
                    <img id="headerImage" runat="server" src="~/new_images/1.gif" />
                </td>
            </tr>
        </table>
        <table style="width: 50%" border="1px">
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" ">
                              
                    </asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="إسم المدير المباشر ">
                              
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label7" runat="server" CssClass="Label" Text="  ">
                              
                    </asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label15" runat="server" CssClass="Label" Text="الإدارة  ">
                              
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label8" runat="server" CssClass="Label" Text="  ">
                              
                    </asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label16" runat="server" CssClass="Label" Text="القطاع  ">
                              
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label9" runat="server" CssClass="Label" Text="  ">
                              
                    </asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label17" runat="server" CssClass="Label" Text="تاريخ التعيين  ">
                              
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label10" runat="server" CssClass="Label" Text="">
                              
                    </asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label18" runat="server" CssClass="Label" Text="المسمي الوظيفي ">
                              
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label11" runat="server" CssClass="Label" Text="">
                              
                    </asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الرقم الوظيفي">
                              
                    </asp:Label>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
        </table>
        <table dir="rtl">
            <tr>
                <td  align="right">
                    <asp:GridView runat="server" ID="GvDetails" CssClass="mGrid" CellPadding="3" 
                        GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" 
                        BorderStyle="None" BorderWidth="1px">
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle CssClass="pgr" BackColor="#E7E7FF" ForeColor="#4A3C8C" 
                            HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <AlternatingRowStyle CssClass="alt" BackColor="#F7F7F7" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lbl_total" style="font:red;font-size:medium;font-weight:bold" runat="server"></asp:Label>
                </td>
            </tr>
            
             <tr>
                <td align="right">
                    <asp:Label ID="lbl_average" style="font:red;font-size:medium;font-weight:bold" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
