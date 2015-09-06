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
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('trainingDiv','trainingImage');"  style="padding-top:7px;">
                        <img border="0" id="trainingImage" src="../Images/square_arrow_down.gif"  />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('trainingDiv','trainingImage');">
                       <h1><asp:Label ID="lblTraining" runat="server" Text=" التدريب"></asp:Label></h1> 
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
                            
                                <asp:LinkButton ID="lnk_Tran_Request" OnClick="lnk_Tran_Request_Click" runat="server"
                                     Font-Size="18px"  font-underline="false" />
                              
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Train_New" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image51" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td2" runat="server">
                            
                                <asp:LinkButton ID="lnk_Tran_New" OnClick="lnk_Tran_New_Click" runat="server" 
                                    Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    
                    
                       <tr id="tr1" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td1" runat="server">
                            
                                <asp:LinkButton ID="lnk_trainplan" OnClick="lnk_Trainplan_New_Click" runat="server" 
                                    Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    
                </table>
            </div>
        </td>
    </tr>
</table>