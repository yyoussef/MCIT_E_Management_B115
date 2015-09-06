<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReviewUserControl.ascx.cs"
    Inherits="UserControls_ReviewUserControl" %>

<script language="javascript" type="text/javascript">
        function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
                img.src = "../Images/square_arrow_down.gif";
            }
            else {
                img.src = "../Images/square_arrow_flipped.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
   
</script>

<table style="width: 100%">
    <tr >
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1000','Img500');"  style="padding-top:7px;">
                        <img border="0" id="Img500" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1000','Img500');">
                       <h1> <asp:Label ID="Label2" runat="server" Text="نشرات التعميم"></asp:Label></h1>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div1000" style="display: none">
                <table>
                    <tr id="tr_Review_Emp_New" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image52" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="Td3" runat="server">
                           
                                <asp:LinkButton ID="lnkbtn_Review_Emp_New" OnClick="lnkbtn_Review_Emp_New_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                              
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Review_emp_closed" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image55" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            
                                <asp:LinkButton ID="lnkbtn_Review_emp_closed" OnClick="lnkbtn_Review_emp_closed_Click"
                                    runat="server"  Font-Size="18px" font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                   
                </table>
            </div>
        </td>
    </tr>
</table>
