<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="MainReport.aspx.cs" Inherits="WebForms_MainReport" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
   function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('collapse') != -1)
       { img.src = "../Images/expand.gif";
        }
    else
        {img.src = "../Images/collapse.gif";
        }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}
    </script>
    <table style="width: 100%">
   
   
    <tr>
                        <td align="center" colspan="2" dir="rtl" style="height: 39px">
                            <asp:Label ID="Label8" runat="server" CssClass="PageTitle" Font-Bold="False" 
                                Text="تقارير "></asp:Label>
                         </td>
    </tr>
    <tr>
                        <td align="center" colspan="2" dir="rtl" style="height: 39px">
                        <asp:Label ID="Label4" runat="server" Font-Bold="false" 
                            ForeColor="Red" CssClass="Label"></asp:Label>
                         </td>
    </tr>
<tr>
        <td >
        <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="الإدارة : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 50px">
        <asp:DropDownList ID="Deptdrop" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="Deptdrop_SelectedIndexChanged" CssClass="drop" 
                Width="550px">
        </asp:DropDownList>
        </td>
</tr>    
<tr>
        <td>
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="المشروع : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 48px">
        <asp:DropDownList ID="projdrop" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="projdrop_SelectedIndexChanged" CssClass="drop" 
                Width="550px">
        </asp:DropDownList>
        </td>
</tr>
 
<tr>
 <td style="height: 54px" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
        <img alt="ashskd" border="0" id="image0" src="../Images/expand.gif" /></td>
<td onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">jksvbhkshvslkvhhv</td>
</tr>


<tr>
<td>
<div id="div0" style="display:none">

 <table style="line-height: 2; width: 100%">
                        <tr>
        <td colspan="2" style="height: 30px" >
            <asp:LinkButton ID="EmployeeLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="EmployeeLB_Click">تقرير العاملين
            </asp:LinkButton>
        </td>
        </tr>
        </table>
      </div>  
     </td> 
</tr>  



    
<tr>
                    <td colspan="2" style="height: 45px"  >
          <asp:LinkButton ID="commitedandRefusedProjectsLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="commitedandRefusedProjectsLB_Click">تقرير بميزانية المشروعات بقطاع البنية 
                        المعلوماتية</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
            <tr>
                    <td colspan="2" style="height: 41px"  >
            <asp:LinkButton ID="CurrentProjectsLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="CurrentProjectsLB_Click"> تقرير عن المشروعات الجارية بقطاع 
                        البنية المعلوماتية</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
            <tr>
                    <td colspan="2" style="height: 40px"  >
            <asp:LinkButton ID="needmaintypeLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="needmaintypeLB_Click">تقرير عن أنواع الاحتياجات الرئيسية و 
                        الفرعية
            </asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
            <tr>
                    <td colspan="2" style="height: 41px"  >
            <asp:LinkButton ID="OrganizationsProjectsLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="OrganizationsProjectsLB_Click">تقرير عن المشروعات الخاصة بجهات معينة</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
            <tr>
                    <td colspan="2" style="height: 38px"  >
            <asp:LinkButton ID="ProjectsEmloyeesLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="ProjectsEmloyeesLB_Click">تقرير بالموظفين فى المشروعات</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
            <tr>
                    <td colspan="2" style="height: 42px"  >
            <asp:LinkButton ID="projectsneedapproveLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="projectsneedapproveLB_Click">تقريرعن احتياجات المشروعات التي 
                        تحتاج تصديق </asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  <tr>
                    <td colspan="2" style="height: 36px"  >
            <asp:LinkButton ID="projobjectiveLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="projobjectiveLB_Click">تقرير عن أهداف المشروعات</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
            <tr>
                    <td colspan="2" style="height: 36px"  >
            <asp:LinkButton ID="projneedsLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="projneedsLB_Click">تقرير عن احتياجات المشروعات</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
              <tr>
                    <td colspan="2" style="height: 36px"  >
            <asp:LinkButton ID="weightpercentageLB" runat="server" Font-Bold="True" 
                Font-Size="X-Large" onclick="weightpercentageLB_Click">تقرير عن نسبة انجازات الانشطة الفرعية للمشروعات</asp:LinkButton>
                    </td>
                    
                   
                    
            </tr>  
</table>

</asp:Content>

