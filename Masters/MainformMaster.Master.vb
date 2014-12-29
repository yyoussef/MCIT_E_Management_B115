Imports System.Data

Partial Public Class Masters_MainformMaster


    Inherits System.Web.UI.MasterPage

dim Session_CS as new Session_CS 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If Session_CS.Project_id = Nothing Then
            '    Response.Redirect("~/WebForms2/Default.aspx")
            'End If
            Dim found_id As Int32 = CDataConverter.ConvertToInt(Session_CS.foundation_id.ToString())
            Footerlab.Text = Footerlab.Text + DateTime.Now.Year.ToString

            Dim dt As DataTable = Site_Upload_DB.SelectAll(found_id)
            If dt.Rows.Count > 0 Then
                Dim obj As Site_Upload_DT = New Site_Upload_DT()
                obj.File_Name = dt.Rows(0)("File_Name").ToString()
                obj.File_Ext = dt.Rows(0)("File_Ext").ToString()
                Session_CS.e_signature = dt.Rows(0)("e_signature").ToString()

                headerImage.ImageUrl = "~/Uploads/SitesPics/" & obj.File_Name & "." & obj.File_Ext


            End If
            'If Request.UserAgent.Contains("AppleWebKit") Then
            '    Request.Browser.Adapters.Clear()
            'End If

            If Session_CS.pmp_id = Nothing Then
                Response.Redirect("~/Default.aspx")
            End If
            'If Session("System_ID") = Nothing Then
            '    Response.Redirect("~/Default.aspx")
            'End If
            'If Session_CS.UROL_UROL_ID = Nothing Then
            '    Response.Redirect("~/Default.aspx")
            'Else
            If Request.QueryString("LogOut") <> 1 Then
                lblUserName.Text = Session_CS.pmp_name
                lblDepts.Text = Session_CS.dept

            End If
        Else
            'Session.Clear()
            Sticker1.Visible = False
        End If
        If Request.QueryString("main") = 1 Then
            Sticker1.Visible = False
        End If
        'If Session_CS.UROL_UROL_ID = 2 Then
        '    Site_Menu1.Visible = True

        'End If

        'If Session_CS.UROL_UROL_ID <> 2 Then
        '    If Request.QueryString("return") = 1 Or Session("IsCommit") = 0 Or Session("IsRefused") = 1 Or Session("IsRepeated") = 1 Then
        '        Sticker1.Visible = False
        '        ' RightMenu1.Visible = False
        '        'Site_Menu1.Visible = False
        '    End If
        'End If
        'If Session_CS.UROL_UROL_ID = 3 Or Session_CS.UROL_UROL_ID = 6 Or Session_CS.UROL_UROL_ID = 8 Or Session_CS.UROL_UROL_ID = 9 Or Session_CS.UROL_UROL_ID = 10 Then

        '    Site_Menu1.Visible = True


        'End If
        'If Session_CS.UROL_UROL_ID = 4 Then
        '    Sticker1.Visible = True

        '    Site_Menu1.Visible = True

        'End If
        If Not Request.QueryString("proj_id") Is Nothing Then
            Sticker1.Visible = True
        End If
        'End If
        If Not Request.QueryString("proj_id") Is Nothing Or CDataConverter.ConvertToInt(Session_CS.Project_id) > 0 Then
            Sticker1.Visible = True
        Else
            Sticker1.Visible = False
        End If

    End Sub

    Protected Sub lnklogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnklogin.Click
        Session.Clear()
        Response.Redirect("~/Default.aspx")

    End Sub

    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChatTimer.Tick

    '    Dim counter As Integer
    '    counter = Get_Notif_Counter()
    '    If counter > 0 Then



    '        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showNotification", "showNoticeToast('لديك عدد " & counter & " وارد جديد');", True)

    '    End If

    'End Sub

    'Public Function Get_Notif_Counter() As Integer


    '    Dim dt_inbox_new As New DataTable
    '    Dim parent As Integer
    '    parent = CDataConverter.ConvertToInt(Session_CS.parent_id.ToString())
    '    Dim group As Integer
    '    group = CDataConverter.ConvertToInt(Session_CS.group_id.ToString())
    '    Dim pmp As Integer
    '    pmp = CDataConverter.ConvertToInt(Session_CS.pmp_id.ToString())

    '    dt_inbox_new = Inbox_class.new_inbox_all(parent, group, pmp)
    '    Dim count As Integer
    '    count = dt_inbox_new.Rows.Count


    '    Return count


    'End Function

   
End Class