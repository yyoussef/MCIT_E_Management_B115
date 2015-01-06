Imports MCIT.Web.Data
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports System.Configuration
Imports System.Collections.Specialized

Partial Class WebForms_Project_Constraints
    Inherits System.Web.UI.Page


#Region "Variables"
    'Dim str As String = Session_CS.Project_id.ToString()
    Dim Project_CONS_ENTITY As New BLL.Project_Constraints
    'Session_CS Session_CS
    Dim Obj_General_Helping As New General_Helping
    Dim sql_Connection As String = DBL.Universal.GetConnectionString()
#End Region
    '"select Parent_PActv_Desc from Project_Activities where pactv_parent = 0 and proj_proj_id = " & Session_CS.Project_id & " order by Parent_Actv_Num"
#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)

        Smart_Search_mac.sql_Connection = sql_Connection
        Smart_Search_mac.Text_Field = "PActv_Desc"
        Smart_Search_mac.Value_Field = "PActv_ID "
        Dim Query = "select PActv_ID,PActv_Desc from Project_Activities where proj_proj_id = " & Session_CS.Project_id & "and PActv_Parent=" & 0
        Smart_Search_mac.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_mac.DataBind()
        AddHandler Me.Smart_Search_mac.Value_Handler, AddressOf Smart_Search_mac_Selected

        MyBase.OnInitComplete(e)



    End Sub

#End Region

#Region "event handel"
    Private Sub Smart_Search_mac_Selected(ByVal Value As String)
        'DDLJobCat.SelectedValue = Value
        'job_index_changed()
        ' Me.DataBind()
        Smart_Search_sac.Text_Field = "PActv_Desc "
        Smart_Search_sac.Value_Field = "PActv_ID  "
        Smart_Search_sac.sql_Connection = sql_Connection
        Dim Query = "select PActv_ID,PActv_Desc from Project_Activities where proj_proj_id = " & Session_CS.Project_id & " and PActv_Parent =" & Value
        Smart_Search_sac.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_sac.DataBind()

        If Smart_Search_sac.Items_Count = 0 Then
            Smart_Search_sac.Clear_Controls()
        End If
    End Sub
#End Region

#Region "Load"
    Protected Sub stat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)
            FillDDls()
            FillGrid()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        ' DDLParentActv.SelectedValue = ".....اختر نشاط رئيسى......"
        ' ddlChildActv.Items.Clear()
        txtCONS_DESC.Text = ""
        txtSugg_Solution.Text = ""
        ChBIs_Critical.Checked = 0
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If String.IsNullOrEmpty(Smart_Search_mac.SelectedValue) Or txtCONS_DESC.Text = "" Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفواً يجب إدخال البيانات أولاً"
            Return False
        Else
            lblPageStatus.Visible = False
            Return True
        End If
    End Function
#End Region

#Region "Fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        Dim _dt As New DataTable




        Dim dt As New DataTable
        dt = General_Helping.GetDataTable("select * from Project_Activities join Project_Constraints on Project_Activities.PActv_ID=Project_Constraints.PActv_PActv_ID where proj_proj_id = " & Session_CS.Project_id)

        gvMain.DataSource = dt
        gvMain.DataBind()
    End Sub
    Private Sub FillLog(Optional ByVal ID As Integer = 0)
        Try
            ' Dim dtnow As DateTime = DateTime.Now
            'Dim dateNow As String = dtnow.ToString("d")
            'Dim recordID As String
            'If ID = 0 Then
            '    Dim sql As String = ""
            '    Dim _dt As New DataTable

            '    sql = " select max(PCONS_ID) as recordID from Project_Constraints "
            '    _dt = General_Helping.GetDataTable(sql)


            '    If _dt.Rows.Count > 0 Then
            '        recordID = _dt.Rows(0)("recordID").ToString()
            '        Project_Log_DB.FillLog(recordID, Project_Log_DB.Action.add, Project_Log_DB.operation.Project_Constraints)
            '    End If

            'Else
            '    recordID = ID.ToString()
            '    Project_Log_DB.FillLog(recordID, Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Constraints)
            'End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub FillDDls()
        'Dim dt As New DataTable
        'dt = General_Helping.GetDataTable("select PActv_ID,Parent_PActv_Desc from Project_Activities where proj_proj_id = " & Session_CS.Project_id & "and PActv_Parent=" & 0)
        'Obj_General_Helping.SmartBindDDL(DDLParentActv, dt, "PActv_ID", "Parent_PActv_Desc", ".....اختر نشاط رئيسى......")

    End Sub
#End Region
#Region "send Notification"
    Private Sub SendNotificaion()
        Dim SqlDT As New DataTable
        Dim SqlProjDT As New DataTable
        Dim proj_name As String
        SqlDT = General_Helping.GetDataTable("select * from EMPLOYEE where PMP_ID in (57,436) ")
        SqlProjDT = General_Helping.GetDataTable("select * from Project where Proj_id = " & Session_CS.Project_id & "")
        proj_name = SqlProjDT.Rows(0)("Proj_Title")

        If SqlDT.Rows.Count > 0 Then
            Dim message As New MailMessage
            message.Subject = "معوقات تحتاج الي تدخل الادارة العليا"
            'Dim mail As String = SqlDT.Rows(0)("mail").ToString
            Dim mail As String = System.Configuration.ConfigurationManager.AppSettings("ProjectNotification_highManagment").ToString
            'Dim mail2 As String = System.Configuration.ConfigurationManager.AppSettings("ProjectNotification_highManagment1").ToString
            'string[] mailarray = mail.Split('=');
            Dim mailarray() As String = mail.Split("=")



            message.BodyEncoding = System.Text.Encoding.Unicode
            message.SubjectEncoding = System.Text.Encoding.Unicode
            message.IsBodyHtml = True
            message.Body = "<html><body dir='rtl'><h3 >" _
           & "  السيد الدكتور هشام الديب" _
            & "    </h3>  تحيه طيبه وبعد <br/> وصلكم المعوقات الخاصة بمشروع '" & proj_name & "' وهي كالاتي <br/><br/> " _
            & "    </h3>   النشاط الرئيسي : '" & Smart_Search_mac.SelectedText & "'  " _
              & "    </h3>   النشاط الفرعي : '" & Smart_Search_sac.SelectedText & "'  " _
            & "    </h3>    وصف المعوق  : '" & txtCONS_DESC.Text & "'  " _
            & "    </h3>     مقترحات لمواجهة المعوق   : '" & txtSugg_Solution.Text & "'  " _
            & " </body></html> "

            Dim Client As New SmtpClient

            Client.Port = Integer.Parse(ConfigurationManager.AppSettings("SMTP_Port"))
            Client.Host = ConfigurationManager.AppSettings("SMTP_Host")
            Dim UserName As String = ConfigurationManager.AppSettings("SMTP_UserName")
            Dim Password As String = ConfigurationManager.AppSettings("SMTP_Password")
            message.From = New MailAddress(ConfigurationManager.AppSettings("SMTP_FromAddress"))

            Dim SMTPUserInfo As New System.Net.NetworkCredential(UserName, Password)
            Try

                ' For Each dr As DataRow In SqlDT.Rows

                ' message.To.Add(New MailAddress(dr("mail").ToString()))

                For i As Integer = 1 To mailarray.Length

                    message.To.Add(New MailAddress(mailarray(i)))
                Next


                'message.To.Add(New MailAddress(mail))
                'message.To.Add(New MailAddress(mail2))
                '  Next
                Client.Send(message)


            Catch ex As Exception


            End Try


            Client.UseDefaultCredentials = False
            Client.Credentials = SMTPUserInfo
            Client.Timeout = 1000000000





        End If
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            Dim dtnow As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            Dim dateNow As String = dtnow.ToString("d")
            Dim recordID As String = ID.ToString()
            If ID = 0 Then
                If Smart_Search_sac.SelectedValue = "" Then
                    General_Helping.ExcuteQuery("insert into Project_Constraints (PActv_PActv_ID) values (" & Smart_Search_mac.SelectedValue & ")")
                    General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Desc='" & txtCONS_DESC.Text & "' where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)
                    If txtSugg_Solution.Text <> "" Then
                        General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Sugg_Solutions='" & txtSugg_Solution.Text & "' where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)
                    End If
                    If ChBIs_Critical.Checked = True Then
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 1 & "where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)
                        SendNotificaion()
                    Else
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 0 & "where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)
                    End If
                    'Project_CONS_ENTITY.Pcons_Is_Critical = IIf(ChBIs_Critical.Checked = True, 1, 0)

                Else
                    General_Helping.ExcuteQuery("insert into Project_Constraints (PActv_PActv_ID) values (" & Smart_Search_sac.SelectedValue & ")")
                    General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Desc='" & txtCONS_DESC.Text & "' where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)
                    If txtSugg_Solution.Text <> "" Then
                        General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Sugg_Solutions='" & txtSugg_Solution.Text & "' where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)
                    End If
                    If ChBIs_Critical.Checked = True Then
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 1 & "where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)
                        SendNotificaion()
                    Else
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 0 & "where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)
                    End If
                End If
                Dim cDT As DataTable = General_Helping.GetDataTable("select max(PCONS_ID) as PCONS_ID from Project_Constraints")

                If cDT.Rows.Count > 0 Then
                    recordID = cDT.Rows(0)(0).ToString()
                    Project_Log_DB.FillLog(recordID, Project_Log_DB.Action.add, Project_Log_DB.operation.Project_Constraints)
                End If


                FillGrid()
                FillLog(0)

            Else
                Project_Log_DB.FillLog(recordID, Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Constraints)
                If Smart_Search_sac.SelectedValue = "" Then

                    General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Desc='" & txtCONS_DESC.Text & "' where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)

                    General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Sugg_Solutions='" & txtSugg_Solution.Text & "' where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)

                    If ChBIs_Critical.Checked = True Then
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 1 & "where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)
                        SendNotificaion()
                    Else
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 0 & "where PActv_PActv_ID =" & Smart_Search_mac.SelectedValue)
                    End If
                    'Project_CONS_ENTITY.Pcons_Is_Critical = IIf(ChBIs_Critical.Checked = True, 1, 0)

                Else

                    General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Desc='" & txtCONS_DESC.Text & "' where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)

                    General_Helping.ExcuteQuery("update Project_Constraints set Pcons_Sugg_Solutions='" & txtSugg_Solution.Text & "' where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)

                    If ChBIs_Critical.Checked = True Then
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 1 & "where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)
                        SendNotificaion()
                    Else
                        General_Helping.ExcuteQuery("update Project_Constraints set PCONS_IS_CRITICAL=" & 0 & "where PActv_PActv_ID =" & Smart_Search_sac.SelectedValue)
                    End If
                End If
                FillGrid()
                'lblPageStatus.Visible = True

                BtnSave.CommandArgument = "new"
                'lblPageStatus.Text = "تم التعديل بنجاح"
                BtnSave.Text = "حفظ"
                FillLog(ID)

            End If
            Clear()
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If Valid() Then
            If BtnSave.CommandArgument = "new" Then
                SaveDataForClasses()
            Else
                SaveDataForClasses(PCONS_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable

        _dt = Project_CONS_ENTITY.Get(CType(sender, ImageButton).CommandArgument)

        Dim dt As New DataTable
        dt = General_Helping.GetDataTable("select * from Project_Activities where PActv_ID = " & _dt.Rows(0)("PActv_PActv_ID"))
        If dt.Rows(0)("PActv_Parent") <> "0" Then
            Smart_Search_mac.SelectedValue = dt.Rows(0)("PActv_Parent")
            Smart_Search_mac_Selected(Smart_Search_mac.SelectedValue)
            Smart_Search_sac.SelectedValue = dt.Rows(0)("PActv_ID")
        Else
            Smart_Search_mac.SelectedValue = dt.Rows(0)("PActv_ID")
            Smart_Search_mac_Selected(Smart_Search_mac.SelectedValue)

        End If
        txtCONS_DESC.Text = _dt.Rows(0)("PCONS_DESC")
        If Not _dt.Rows(0)("PCONS_Sugg_Solutions") Is DBNull.Value Then
            txtSugg_Solution.Text = _dt.Rows(0)("PCONS_Sugg_Solutions")
        End If
        If _dt.Rows(0)("PCONS_IS_CRITICAL") = 0 Then
            ChBIs_Critical.Checked = False
        Else
            ChBIs_Critical.Checked = True
        End If


        PCONS_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("PCONS_ID"), HtmlControls.HtmlInputHidden).Value = PCONS_ID.Value Then
                id = i
            Else
                gvMain.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next
        gvMain.Rows(id).BackColor = Drawing.Color.Lavender
        BtnSave.Text = "تعديــــل"
        lblPageStatus.Text = ""



    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try

            Dim Project_CONS_ENTITY As New BLL.Project_Constraints(CType(sender, ImageButton).CommandArgument)
            Project_CONS_ENTITY.Delete()
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        'Dim dt_constrain_Level As DataTable = activityLeveling.ActivLevls.leveling(Session_CS.Project_id, 0, 0)
        'Dim rw_indx As Decimal = 0
        'For Each rw As DataRow In dt_constrain_Level.Rows
        '    If rw("PCONS_IS_CRITICAL").ToString() = "0" Then
        '        CType(gvMain.Rows(CInt(rw_indx)).FindControl("CheckBox1"), CheckBox).Checked = False
        '    ElseIf rw("PCONS_IS_CRITICAL").ToString() = "1" Then
        '        CType(gvMain.Rows(CInt(rw_indx)).FindControl("CheckBox1"), CheckBox).Checked = True
        '    Else
        '        CType(gvMain.Rows(CInt(rw_indx)).FindControl("CheckBox1"), CheckBox).Visible = False
        '    End If
        '    rw_indx += 1
        'Next



    End Sub
#End Region

    'Protected Sub DDLParentActv_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDLParentActv.SelectedIndexChanged
    '    Dim dt As New DataTable
    '    If DDLParentActv.SelectedIndex <> 0 Then
    '        dt = General_Helping.GetDataTable("select PActv_ID,PActv_Desc from Project_Activities where proj_proj_id = " & Session_CS.Project_id & " and PActv_Parent =" & DDLParentActv.SelectedValue)
    '        Obj_General_Helping.SmartBindDDL(ddlChildActv, dt, "PActv_ID", "PActv_Desc", ".....اختر نشاط فرعى......")
    '    Else
    '        ddlChildActv.Items.Clear()
    '    End If
    'End Sub

    Protected Sub txtCONS_DESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONS_DESC.TextChanged
        If txtCONS_DESC.Text = "" Then
            ChBIs_Critical.Enabled = False
        Else
            ChBIs_Critical.Enabled = True
            ChBIs_Critical.Focus()

        End If
    End Sub


    Protected Sub ChBIs_Critical_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChBIs_Critical.CheckedChanged
        'txtCONS_DESC.Focus()
    End Sub
End Class