<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="DMallReports.aspx.cs" Inherits="WebForms_DMallReports" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
    <tr>
              <td  align="center" style="height: 28px">
                    &nbsp;</td>
    
    </tr>
    <tr>
              <td  align="center" style="height: 31px">
                    <table style="width: 100%; height: 238px">
                        <tr>
                            <td style="height: 72px">
                    <asp:Label ID="LabProj" runat="server" Font-Bold="False" Text="الإدارة : " 
                        CssClass="Label"></asp:Label>
                            </td>
                            <td style="height: 72px">
                    <asp:Label ID="Label3" runat="server" CssClass="Label"></asp:Label>
                            </td>
                            <td style="height: 72px">
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 45px">
                    <asp:LinkButton ID="IndicatortypeLBdeptMang" runat="server" Font-Bold="False" 
                        onclick="IndicatortypeLBdeptMang_Click" CssClass="Text"> مؤشرات القياس</asp:LinkButton>
                            </td>
                            <td style="height: 45px">
                                &nbsp;</td>
                            <td style="height: 45px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 34px">
                    <asp:LinkButton ID="PActivitiesPMLB" runat="server" Font-Bold="False" 
                        onclick="PActivitiesPMLB_Click" CssClass="Text">الخطة التنفيذية</asp:LinkButton>
                                </td>
                            <td style="height: 34px">
    <table style="width: 100%">
        <tr>
            <td style="height: 41px; width: 109px;">
                <asp:Label ID="LabProj_Mang0" runat="server" Font-Bold="False" Text="مدير المشروع : "
                    CssClass="Label"></asp:Label>
            </td>
            <td style="height: 41px" valign="middle">
                <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop" 
                    Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 109px; height: 30px;">
                <asp:Label ID="LabProj0" runat="server" Font-Bold="False" Text="المشروع : " 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="height: 30px" dir="rtl">
                <asp:DropDownList ID="DropProj" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropProj_SelectedIndexChanged" CssClass="drop" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
                                </td>
                            <td style="height: 34px">
                                </td>
                        </tr>
                        <tr>
                            <td>
                  
                 
                  
                    &nbsp;&nbsp;
                                <br />
                    <asp:LinkButton ID="PDemandsLB" runat="server" Font-Bold="False" 
                        onclick="PDemandsLB_Click" CssClass="Text">مطالب المشروعات</asp:LinkButton>
                  
                 
                  
                            </td>
                            <td>
                   
                 <asp:DropDownList ID="DropDate" runat="server" CssClass="drop" Width="203px">
                 </asp:DropDownList>
                   
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 38px">
                   <asp:LinkButton ID="PFollowUpPMLB" runat="server" Font-Bold="False" 
                        onclick="PFollowUpPMLB_Click" CssClass="Text">الانجازات و متابعة الأعمال</asp:LinkButton>  
                                </td>
                            <td style="height: 38px">
                <asp:Label ID="Label4" runat="server" Font-Bold="False" 
                        Text="التاريخ المخطط للتوريد من :" CssClass="Label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"
                    CssClass="Label" Font-Bold="True" Width="114px" ontextchanged="TextBox1_TextChanged" >
                </asp:TextBox>
                <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox1" PopupButtonID ="ImageButton1" PopupPosition="BottomLeft">
                </cc1:CalendarExtender>
                
                <cc1:FilteredTextBoxExtender ID ="gh"  runat="server"  FilterType ="Custom" ValidChars ="0123456789/\" TargetControlID="TextBox1">
                </cc1:FilteredTextBoxExtender>                
        
               <asp:ImageButton ID="ImageButton1" runat="Server" 
                ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
                Height="20px" Width="20px" ToolTip="تقويم" />
      
       
          
                                <br />
                    <asp:Label ID="Label5" runat="server" Font-Bold="False" 
                            Text="التاريخ المخطط للتوريد إلي :" CssClass="Label"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" 
                        Height="29px" Width="114px" ontextchanged="TextBox2_TextChanged" 
                         CssClass="Label"></asp:TextBox>
                    <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox2" PopupButtonID="ImageButton2">
                    </cc1:CalendarExtender>
        
       <asp:ImageButton ID="ImageButton2" runat="Server" 
        ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
        Height="20px" Width="20px" ToolTip="تقويم" />
      
       
          
                                </td>
                            <td style="height: 38px">
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 50px">
                  
                 
                  
                    <asp:LinkButton ID="ProjectneedReportLB" runat="server" Font-Bold="False" 
                        onclick="ProjectneedReportLB_Click" CssClass="Text">احتياجات المشروع</asp:LinkButton>
                  
                 
                  
                            </td>
                            <td style="height: 50px">
                                &nbsp;</td>
                            <td style="height: 50px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 48px">
            <asp:LinkButton ID="commitedandRefusedProjectsLB" runat="server" Font-Bold="False" 
                                    onclick="commitedandRefusedProjectsLB_Click" CssClass="Text">ميزانية 
                                المشروعات بقطاع البنية المعلوماتية</asp:LinkButton>
                                </td>
                            <td style="height: 48px">
                                </td>
                            <td style="height: 48px">
                                </td>
                        </tr>
                         <tr>
                            <td style="height: 43px">
            <asp:LinkButton ID="CurrentProjectsLB" runat="server" Font-Bold="False" 
                                    onclick="CurrentProjectsLB_Click" CssClass="Text"> المشروعات الجارية بقطاع 
                                البنية المعلوماتية</asp:LinkButton>
                             </td>
                            <td style="height: 43px">
                                </td>
                            <td style="height: 43px">
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 43px">
           
            <asp:LinkButton ID="ProjectsEmloyeesLB" runat="server" Font-Bold="False" 
                                    onclick="ProjectsEmloyeesLB_Click" CssClass="Text">الموظفين فى الإدارات</asp:LinkButton>
           
                             </td>
                            <td style="height: 43px">
                                </td>
                            <td style="height: 43px">
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 43px">
           
            <asp:LinkButton ID="projAchievmentLB" runat="server" Font-Bold="False" 
                                    onclick="projAchievmentLB_Click" CssClass="Text">إنجازات المشروعات</asp:LinkButton>
           
                             </td>
                            <td style="height: 43px">
                                </td>
                            <td style="height: 43px">
                                </td>
                        </tr>
                    </table>
              </td>
    
    </tr>
    </table>   

</asp:Content>

