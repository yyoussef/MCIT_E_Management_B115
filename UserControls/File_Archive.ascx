<%@ Control Language="C#" AutoEventWireup="true" CodeFile="File_Archive.ascx.cs"
    Inherits="UserControls_Project_Attitude" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
</style>
<script language="javascript" type="text/javascript">

    function Get_Value() {
        var file_Upload = document.getElementById('<%= FileUpload1.ClientID %>').value;

        var slashindex = file_Upload.lastIndexOf("\\");
        var dotindex = file_Upload.lastIndexOf(".");

        //alert(slashindex);
        var name = file_Upload.substring(slashindex + 1, dotindex);

        document.getElementById('<%= tx_filename.ClientID %>').value = name;
        //alert('you selected the file: '+ name);
    }
</script>

<table style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="  تـحـميــل الــملـفــات"></asp:Label>
               <input id="mode" runat="server" type="hidden" value="new"  />
              <input id="Archive_ID" runat="server" type="hidden" value="0"  />
             <input id="file_id" runat="server" type="hidden" value="0"  />



        </td>
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
            <input id="succ_id" type="hidden" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label2" runat="server" CssClass="Label" text=" اختر  ملف  :"></asp:Label>
        </td>
        <td>
           <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" />


            
        </td>
    </tr>
      <tr>
                    <td>
                     <asp:label id="label9" runat="server"  CssClass="Label"  text="اسم الملف"></asp:label>
                    </td>
                    <td>
                    <asp:TextBox ID="tx_filename" runat="server"></asp:TextBox>
                    </td>
                    </tr>
    
    <tr>
        <td style="width: 198px">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" الموضوع  : "></asp:Label>
        </td>
       <td>
       <asp:TextBox ID="txt_desc" runat="server" Width="282px" TextMode="MultiLine" 
               Height="154px"></asp:TextBox>
        
       </td>
       
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" 
                OnClick="btnSave_Click" />
                 <asp:Button ID="btn_clear" runat="server" CssClass="Button" Text="جديد" 
                OnClick="btn_clear_Click"  Visible="false" />
                <asp:Button ID="btn_send" runat="server" CssClass="Button" 
                  Text="إرسال الي المدير المختص " 
                onclick="btn_send_Click" Width="220px" Visible="false" />
               <asp:Label ID="lbl_result" runat="server" CssClass="Label"  Visible="false" ForeColor="Red" ></asp:Label>

        </td>
          <td colspan="2" align="center">
            
        </td>
    </tr>
    <tr>
        <td colspan="2">
        
            <asp:GridView ID="gv_files" runat="server" AutoGenerateColumns="False" utoGenerateColumns="False" Width="100%" 
                            BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                            BorderWidth="1px" 
                            CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                            PagerStyle-CssClass="pgr" 
                              AlternatingRowStyle-CssClass="alt" Font-Size="17px" OnRowCommand="gv_files_RowCommand">
                                  <Columns>
                                  
                                   <asp:BoundField HeaderText=" الموضوع" DataField="file_desc" />
                                   
                                    <asp:TemplateField HeaderText="الوثيقة">
                                                <ItemTemplate>
                                                    <a href='<%# "ALL_Document_Details.aspx?type=archive&id="+ Eval("id") %>'>
                                                        <%# Eval("file_name")%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                  <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                            
                                    <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                        Style="height: 22px" CommandArgument='<%#Eval("id")%>'  />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                     
                                          
                                  </Columns>
                                   <PagerStyle CssClass="pgr" />
                                  <AlternatingRowStyle CssClass="alt" />
           </asp:GridView>
        
        
        </td>
    </tr>
</table>
