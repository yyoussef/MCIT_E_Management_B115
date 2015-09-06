<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProjectsUserControl.ascx.cs"
    Inherits="UserControls_ProjectsUserControl" %>

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
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divproj','imageproj');"  style="padding-top:7px;">
                        <img border="0" id="imageproj" src="../Images/square_arrow_down.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divproj','imageproj');">
                      <h1>   <asp:Label ID="lbl_Project" runat="server" Text="المشروعات  "></asp:Label> </h1>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="divproj" style="display: block">
                <table>
                    <tr id="Current2" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="lnk_btn_Active_proj_2" OnClick="lnk_btn_Active_proj_2_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                              
                            <br />
                        </td>
                    </tr>
                    <tr id="done_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image54" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                         
                                <asp:LinkButton ID="lbtnProj_done_2" OnClick="lbtnProj_done_2_Click" runat="server"
                                     Font-Size="18px"  font-underline="false"  />
                               
                        </td>
                    </tr>
                    <tr id="donefollow_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image56" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            
                                <asp:LinkButton ID="Lb_Lbdonefollow_2" runat="server"  Font-Size="18px"
                                     font-underline="false" OnClick="Lbdonefollow_2_Click" />
                               
                        </td>
                    </tr>
                    <tr id="stopped_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image58" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="lbtnProj_stopped_2" OnClick="lbtnProj_stopped_2_Click" runat="server"
                                    Font-Size="18px"   font-underline="false"/>
                              
                        </td>
                    </tr>
                    <tr id="tr_Commit_2" runat="server" visible="false" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image60" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="tr_LBtnProj_Suggest_2" runat="server">
                           
                                <asp:LinkButton ID="LBtnProj_Suggest_2" OnClick="LBtnProj_Suggest_2_Click" runat="server"
                                   font-underline="false"  Font-Size="18px"   />
                             
                        </td>
                    </tr>
                    <tr id="tr_Re_Update_2" runat="server" visible="false">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image61" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="lbtnProj_Approved_2" OnClick="lbtnProj_Approved_2_Click" runat="server"
                                     Font-Size="18px"   font-underline="false"  />
                              
                        </td>
                    </tr>
                    <tr id="tr_Repeted_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image62" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="lbtnProj_Repeted_2" OnClick="lbtnProj_Repeted_2_Click" runat="server"
                                    Font-Size="18px"  font-underline="false" />
                               
                        </td>
                    </tr>
                    <tr id="tr_refused_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image63" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                          
                                <asp:LinkButton ID="lbtnProj_refused_2" OnClick="lbtnProj_refused_2_Click" runat="server"
                                    Font-Size="18px"  font-underline="false" />
                              
                        </td>
                    </tr>
                    <tr id="tr_Canceled_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image461" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            
                                <asp:LinkButton ID="lnkProj_Canceled_2" OnClick="lnkProj_Canceled_2_Click" runat="server"
                                    Font-Size="18px"   font-underline="false"  />
                                
                        </td>
                    </tr>
                    
                    
                     <tr id="tr_Project_Constraints" runat="server" visible="false" >
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            
                                <asp:LinkButton ID="lnk_const_count" OnClick="lnk_const_Click" runat="server"
                                   Font-Size="18px"  font-underline="false"/>
                                
                          
                        </td>
                    </tr>
                    
                </table>
            </div>
        </td>
    </tr>
</table>
