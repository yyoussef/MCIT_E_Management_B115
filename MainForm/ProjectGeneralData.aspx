<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="ProjectGeneralData.aspx.cs" Inherits="ProjectGeneralData" Title="البيانات الأساسية للمشروع"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/ProjectInfo.ascx" TagName="ProjectInfo" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/BudDetails.ascx" TagName="BudDetails" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/Project_Exchange.ascx" TagName="Project_Exchange"
    TagPrefix="uc3" %>
<%@ Register Src="../UserControls/Project_Objective.ascx" TagName="Project_Objective"
    TagPrefix="uc4" %>
<%@ Register Src="../UserControls/Project_Attitudes.ascx" TagName="Project_Attitudes"
    TagPrefix="uc5" %>
<%@ Register Src="../UserControls/Project_excution_stages.ascx" TagName="Project_excution_stages"
    TagPrefix="uc6" %>
<%@ Register Src="../UserControls/Project_success_elements.ascx" TagName="Project_success_elements"
    TagPrefix="uc7" %>
<%@ Register Src="../UserControls/geographic_scope.ascx" TagName="geographic_scope"
    TagPrefix="uc8" %>
<%@ Register Src="../UserControls/Project_Team.ascx" TagName="Project_Team" TagPrefix="uc9" %>
<%@ Register Src="../UserControls/proj_classification.ascx" TagName="proj_classification"
    TagPrefix="uc10" %>
<%@ Register Src="../UserControls/Project_Organizations.ascx" TagName="Project_Organizations"
    TagPrefix="uc11" %>
<%@ Register Src="../UserControls/Project_Scope_Assumptions_Dlev.ascx" TagName="Project_Scope_Assumptions_Dlev"
    TagPrefix="uc12" %>
<%@ Register Src="../UserControls/BudDetails.ascx" TagName="Budget" TagPrefix="uc13" %>
<%@ Register Src="../UserControls/proj_info.ascx" TagName="proj_info" TagPrefix="uc14" %>
<%@ Register Src="../UserControls/Project_services.ascx" TagName="Project_services"
    TagPrefix="uc15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
         
        function ChangeMeCase(divid, imgid) 
        {
            
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



        function SelectAll(Div_ID, Div_Chk_ID) {

            var Chk_ID;

            // alert(Div_Chk_ID);
            var elements = document.getElementById(Div_Chk_ID).getElementsByTagName("input");
            //  alert(elements.length);
            for (xx = 0; xx < elements.length; xx++) {
                if (IsCheckBox(elements[xx]))
                    Chk_ID = elements[xx];

            }

            var DIVs = document.getElementsByTagName("DIV");
            for (i = 0; i < DIVs.length; i++) {
                //alert(DIVs[i].ID);
                if (DIVs[i].id == Div_ID) {
                    var elements = DIVs[i].getElementsByTagName("input");
                    for (x = 0; x < elements.length; x++) {
                        if (IsCheckBox(elements[x])) {
                            if (Chk_ID.checked)
                                elements[x].checked = true;
                            else
                                elements[x].checked = false;
                        }
                    }
                    //alert("here");
                }

            }

        }


        function IsCheckBox(chk) {
            if (chk.type == 'checkbox') return true;
            else return false;
        }

        function getImgPath(img) {
            image1 = new Image()
            image1.src = img
            return image1.src
        } 
      
       function isPostBack()
         {
          if ( !document.getElementById('clientSideIsPostBack') )
           return false;

          if ( document.getElementById('clientSideIsPostBack').value == 'Y' )
           return true;
          else
           return false;
        }
    </script>

    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="البيانات الأساسية للمشروع" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 5px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:TabContainer runat="server" ID="TabPanel_All" Height="1500px" ActiveTabIndex="0"
                                ForeColor="Black">
                                <cc1:TabPanel ID="Tab1" runat="server">
                                    <HeaderTemplate>
                                        البيانات الاساسية
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table1" runat="server" style="width: 100%">
                                            <tr id="Tr1" runat="server">
                                                <td id="Td1" runat="server">
                                                    <div style="overflow: auto; height: 1500px; width: 100%">
                                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                            <ContentTemplate>
                                                                <uc1:ProjectInfo ID="proj_info2" runat="server" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="proj_info2" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel1" runat="server">
                                    <HeaderTemplate>
                                        تفاصيل الميزانية</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table2" runat="server" style="width: 100%">
                                            <tr id="Tr2" runat="server">
                                                <td id="Td2" runat="server">
                                                    <div style="overflow: auto; height: 1500px; width: 100%">
                                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                            <ContentTemplate>
                                                                <uc13:Budget ID="proj_info1" runat="server" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="proj_info1" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab3" runat="server">
                                    <HeaderTemplate>
                                        ابواب الصرف</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table3" style="width: 100%" runat="server">
                                            <tr id="Tr3" runat="server">
                                                <td id="Td3" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                            <uc3:Project_Exchange ID="Project_Exchange1" runat="server" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Project_Exchange1" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab4" runat="server">
                                    <HeaderTemplate>
                                        اهداف المشروع</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table4" style="width: 100%" runat="server">
                                            <tr id="Tr4" runat="server">
                                                <td id="Td4" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <uc4:Project_Objective ID="Project_Objective1" runat="server" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Project_Objective1" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab5" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        تنفيذ المشروع</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table17" style="width: 100%" runat="server">
                                            <tr id="Tr22" runat="server">
                                                <td id="Td22" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div6','image11');">
                                                                <img border="0" id="image11" src="../Images/square_arrow_down.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div6','image11');"
                                                                colspan="1">
                                                                الموقف التنفيذي للمشروع
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr23" runat="server">
                                                <td id="Td23" runat="server">
                                                    <div id="div6" style="display: block">
                                                        <table id="Table18" style="width: 100%">
                                                            <tr id="Tr24" runat="server">
                                                                <td id="Td24" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc5:Project_Attitudes ID="Project_Attitudes2" runat="server" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="Project_Attitudes2" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table19" style="width: 100%" runat="server">
                                            <tr id="Tr25" runat="server">
                                                <td id="Td25" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div7','Img11');">
                                                                <img border="0" id="Img11" src="../Images/square_arrow_flipped.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div7','Img11');"
                                                                colspan="1">
                                                                مراحل تنفيذ المشروع
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr26" runat="server">
                                                <td id="Td26" runat="server">
                                                    <div id="div7" style="display: none">
                                                        <table id="Table20" style="width: 100%">
                                                            <tr id="Tr27" runat="server">
                                                                <td id="Td27" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc6:Project_excution_stages ID="Project_excution_stages2" runat="server" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="Project_excution_stages2" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab8" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        فريق العمل</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table5" style="width: 100%" runat="server">
                                            <tr id="Tr5" runat="server">
                                                <td id="Td5" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <uc9:Project_Team ID="Project_Team1" runat="server" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Project_Team1" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                               
                                <cc1:TabPanel ID="Tab10" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        جهات المشروع</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table7" style="width: 100%" runat="server">
                                            <tr id="Tr7" runat="server">
                                                <td id="Td7" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div11','Img00');">
                                                                <img border="0" id="Img00" src="../Images/square_arrow_down.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div11','Img00');"
                                                                colspan="1">
                                                                الجهات المستفيدة
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr8" runat="server">
                                                <td id="Td8" runat="server">
                                                    <div id="div11" style="display: block">
                                                        <table id="Table8" style="width: 100%">
                                                            <tr id="Tr9" runat="server">
                                                                <td id="Td9" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc11:Project_Organizations ID="Project_Organizations1" runat="server" OrgType="1" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="Project_Organizations1" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table9" style="width: 100%" runat="server">
                                            <tr id="Tr10" runat="server">
                                                <td id="Td10" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img1');">
                                                                <img border="0" id="Img1" src="../Images/square_arrow_flipped.gif" alt="" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img1');"
                                                                colspan="1">
                                                                الجهات المنفذة
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr11" runat="server">
                                                <td id="Td11" runat="server">
                                                    <div id="div2" style="display: none">
                                                        <table id="Table10" style="width: 100%">
                                                            <tr id="Tr12" runat="server">
                                                                <td id="Td12" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel_1" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc11:Project_Organizations ID="Project_Organizations2" runat="server" OrgType="2" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="Project_Organizations2" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab11" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        الافتراضات والنطاق والمخرجات</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table11" style="width: 100%" runat="server">
                                            <tr id="Tr13" runat="server">
                                                <td id="Td13" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img2');">
                                                                <img border="0" id="Img2" src="../Images/square_arrow_down.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img2');"
                                                                colspan="1">
                                                                الإفتراضات
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr14" runat="server">
                                                <td id="Td14" runat="server">
                                                    <div id="div3" style="display: block">
                                                        <table id="Table12" style="width: 100%">
                                                            <tr id="Tr15" runat="server">
                                                                <td id="Td15" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc12:Project_Scope_Assumptions_Dlev ID="Project_Scope_Assumptions_Dlev1" runat="server"
                                                                                Type="1" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="Project_Scope_Assumptions_Dlev1" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table13" style="width: 100%" runat="server">
                                            <tr id="Tr16" runat="server">
                                                <td id="Td16" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','Img3');">
                                                                <img border="0" id="Img3" src="../Images/square_arrow_flipped.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','Img3');"
                                                                colspan="1">
                                                                النطاق
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr17" runat="server">
                                                <td id="Td17" runat="server">
                                                    <div id="div4" style="display: none">
                                                        <table id="Table14" style="width: 100%">
                                                            <tr id="Tr18" runat="server">
                                                                <td id="Td18" runat="server">
                                                                    <uc12:Project_Scope_Assumptions_Dlev ID="Project_Scope_Assumptions_Dlev2" runat="server"
                                                                        Type="2" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table15" style="width: 100%" runat="server">
                                            <tr id="Tr19" runat="server">
                                                <td id="Td19" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','Img4');">
                                                                <img border="0" id="Img4" src="../Images/square_arrow_flipped.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','Img4');"
                                                                colspan="1">
                                                                المخرجات
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr20" runat="server">
                                                <td id="Td20" runat="server">
                                                    <div id="div5" style="display: none">
                                                        <table id="Table16" style="width: 100%">
                                                            <tr id="Tr21" runat="server">
                                                                <td id="Td21" runat="server">
                                                                    <uc12:Project_Scope_Assumptions_Dlev ID="Project_Scope_Assumptions_Dlev3" runat="server"
                                                                        Type="3" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab13" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        النطاق الجغرافي وعناصر نجاح وتصنيف المشروع</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table6" style="width: 100%" runat="server">
                                            <tr id="Tr29" runat="server">
                                                <td id="Td29" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div9','Img9');">
                                                                <img border="0" id="Img9" src="../Images/square_arrow_down.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div9','Img9');"
                                                                colspan="1">
                                                                عناصر نجاح المشروع
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr30" runat="server">
                                                <td id="Td30" runat="server">
                                                    <div id="div9" style="display: block">
                                                        <table id="Table21" style="width: 100%">
                                                            <tr id="Tr31" runat="server">
                                                                <td id="Td31" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc7:Project_success_elements ID="Project_success_elements2" runat="server" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="Project_success_elements2" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table22" style="width: 100%" runat="server">
                                            <tr id="Tr32" runat="server">
                                                <td id="Td32" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div10','Img10');">
                                                                <img border="0" id="Img10" src="../Images/square_arrow_flipped.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div10','Img10');"
                                                                colspan="1">
                                                                النطاق الجغرافي
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr33" runat="server">
                                                <td id="Td33" runat="server">
                                                    <div id="div10" style="display: none">
                                                        <table id="Table23" style="width: 100%">
                                                            <tr id="Tr34" runat="server">
                                                                <td id="Td34" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc8:geographic_scope ID="geographic_scope2" runat="server" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="geographic_scope2" />
                                                                       </Triggers>
                                                                   </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table24" style="width: 100%" runat="server">
                                            <tr id="Tr35" runat="server">
                                                <td id="Td35" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div12','Img5');">
                                                                <img border="0" id="Img5" src="../Images/square_arrow_flipped.gif" />
                                                            </td>
                                                            <td 
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div12','Img5');"
                                                                colspan="1">
                                                                تصنيف المشروع
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr36" runat="server">
                                                <td id="Td36" runat="server">
                                                    <div id="div12" style="display: none">
                                                        <table id="Table25" style="width: 100%">
                                                            <tr id="Tr37" runat="server">
                                                                <td id="Td37" runat="server">
                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>
                                                                            <uc10:proj_classification ID="proj_classification2" runat="server" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="proj_classification2" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                 <cc1:TabPanel ID="Tab9" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        خدمات المواطنين والجهات الحكومية</HeaderTemplate>
                                    <ContentTemplate>
                                        <table id="Table26" style="width: 100%" runat="server">
                                            <tr id="Tr6" runat="server">
                                                <td id="Td6" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                        <ContentTemplate>
                                                            <uc15:Project_services ID="Project_services" runat="server" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Project_services" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TabPanel_All" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
