<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TrainingCounter.ascx.cs" Inherits="UserControls_TrainingCounter" %>


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
    <tr  id="train2">
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('trainingDiv','trainingImage');">
                        <img border="0" id="trainingImage" src="../Images/square_arrow_down.gif"  />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('trainingDiv','trainingImage');">
                        <asp:Label ID="lblTraining" runat="server" Text=" التدريب"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="trainingDiv" style="display: block">
                <table>
                    <tr id="tr_lnk_Tran_Request" runat="server" visible="true">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image50" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td" runat="server">
                            <asp:LinkButton ID="LinkButton68" OnClick="lnk_Tran_Request_Click" runat="server"
                                 Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="lnk_Tran_Request" OnClick="lnk_Tran_Request_Click" runat="server"
                                     Font-Size="20px" Visible="true"  Text="0"
                                    ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton73" OnClick="lnk_Tran_Request_Click" runat="server"
                                     Visible="true"  Text="طلب تدريب" Font-Size="20px"
                                    ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Train_New" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image51" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td2" runat="server">
                            <asp:LinkButton ID="LinkButton71" OnClick="lnk_Tran_New_Click" runat="server" 
                                Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnk_Tran_New" OnClick="lnk_Tran_New_Click" runat="server" 
                                    Font-Size="20px" Visible="true"  Text="0" ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton75" OnClick="lnk_Tran_New_Click" runat="server" 
                                    Visible="true"  Text=" تدريب جديد" Font-Size="20px" ForeColor="#808080" font-underline="false"
                                    Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    
                    
                       <tr id="tr1" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td1" runat="server">
                            <asp:LinkButton ID="LinkButton1" OnClick="lnk_Trainplan_New_Click" runat="server" 
                                Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnk_trainplan" OnClick="lnk_Trainplan_New_Click" runat="server" 
                                    Font-Size="20px" Visible="true"  Text="0" ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton3" OnClick="lnk_Trainplan_New_Click" runat="server" 
                                    Visible="true"  Text="  خطط تدريبية" Font-Size="20px" ForeColor="#808080" font-underline="false"
                                    Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    
                </table>
            </div>
        </td>
    </tr>
</table>