Imports System.Data.SqlClient
Imports System.Data
Imports VB_Classes.Dates

Partial Class WebForms_Projects
    Inherits System.Web.UI.Page
    'Session_CS Session_CS



#Region "Variables"
    Dim Project_ENTITY As New BLL.Project

    Dim previousCat As String = ""
    Dim firstRow As Integer = -1
    Public con As New SqlConnection
    Private Const _ENGLISH As String = "ENGL"
    Dim Obj_General_Helping As New General_Helping
    Dim sql_Connection As String = DBL.Universal.GetConnectionString()
#End Region

#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)



        Smart_Search_man.sql_Connection = sql_Connection
        Smart_Search_man.Text_Field = "pmp_name "
        Smart_Search_man.Value_Field = "pmp_id "
        Dim Query As String = "select pmp_id,pmp_name from employee JOIN Roles ON Rol_ID = rol_rol_id WHERE rol_rol_id NOT IN (1,2,3)"
        Smart_Search_man.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_man.DataBind()
        MyBase.OnInitComplete(e)

        If Smart_Search_man.Items_Count = 0 Then
            Smart_Search_man.Clear_Controls()
        End If

    End Sub

#End Region

#Region "Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim qryStr As String = ""
        qryStr = " select *,'0' as Value from Project_Funding_Sources "
       
        If Not IsPostBack Then
            'tblfinance tbldoc1

            If Request.QueryString("mode") = "new" Then
                tblfinance.Visible = False
                tbldoc1.Visible = False
            End If

            provide_src.DataSource = General_Helping.GetDataTable(qryStr)
            provide_src.DataBind()
            Dim str As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            txtStartDate.Text = str.ToString("dd/MM/yyyy")
            FillDDls()
            If Request.QueryString("mode") = "new" Then
                BtnSave.CommandArgument = "new"
                BtnSave.Text = "حفــــــظ"
                tblnew.Visible = True
                gvMain.Visible = False
            ElseIf Request.QueryString("mode") = "edit" Then
                BtnSave.CommandArgument = "edit"
                BtnSave.Text = "تعديــــل"
                Proj_id.Value = Request.QueryString("proj_id")
                tblnew.Visible = True
                GView.Visible = True
                gvMain.Visible = False
                Dim _dt As DataTable = General_Helping.GetDataTable("select * ,prio_prio_id,Proj_InitValue as Proj_InitValue_integer from Project where proj_id=" & Proj_id.Value)
                If Not _dt.Rows(0)("Proj_Creation_Date") Is DBNull.Value Then
                    txtStartDate.Text = _dt.Rows(0)("Proj_Creation_Date")
                End If
                txtCoast.Text = _dt.Rows(0)("Proj_InitValue_integer")
                Smart_Search_man.SelectedValue = General_Helping.GetDataTable("select Project_team.pmp_pmp_id from  Project join Project_team on proj_proj_id = Proj_id where proj_id = " & Proj_id.Value).Rows(0)("pmp_pmp_id")

                If _dt.Rows.Count > 0 Then
                    txtProjBrief.Text = _dt.Rows(0)("Proj_Brief").ToString()
                    txtProjTitle.Text = _dt.Rows(0)("Proj_Title").ToString()
                End If
                If Not _dt.Rows(0)("prio_prio_id") Is DBNull.Value Then
                    DDLPriority.SelectedValue = _dt.Rows(0)("prio_prio_id")
                End If
                Dim str2 As String = ""
                str2 = " select PDOC_FileName ,PDOC_ID from projects_documents where Proj_Proj_id= " & Proj_id.Value
                GView.DataSource = General_Helping.GetDataTable(str2)
                GView.DataBind()
                lblPageStatus.Text = ""
            ElseIf Request.QueryString("mode") = "delete" Then
                BtnSave.CommandArgument = "delete"
                BtnSave.Text = "حـــــذف"
                Proj_id.Value = Request.QueryString("proj_id")
                tblnew.Visible = True
                GView.Visible = True
                gvMain.Visible = False
                Dim _dt As DataTable = General_Helping.GetDataTable("select * ,prio_prio_id,Proj_InitValue as Proj_InitValue_integer from Project where proj_id=" & Proj_id.Value)
                If Not _dt.Rows(0)("Proj_Creation_Date") Is DBNull.Value Then
                    txtStartDate.Text = _dt.Rows(0)("Proj_Creation_Date")
                End If
                txtCoast.Text = _dt.Rows(0)("Proj_InitValue_integer")
                Smart_Search_man.SelectedValue = General_Helping.GetDataTable("select Project_team.pmp_pmp_id from  Project join Project_team on proj_proj_id = Proj_id where proj_id = " & Proj_id.Value).Rows(0)("pmp_pmp_id")
                txtProjBrief.Text = _dt.Rows(0)("Proj_Brief")
                txtProjTitle.Text = _dt.Rows(0)("Proj_Title")
                If Not _dt.Rows(0)("prio_prio_id") Is DBNull.Value Then
                    DDLPriority.SelectedValue = _dt.Rows(0)("prio_prio_id")
                End If

                Dim str2 As String = ""
                str2 = " select PDOC_FileName ,PDOC_ID from projects_documents where Proj_Proj_id= " & Proj_id.Value
                GView.DataSource = General_Helping.GetDataTable(str2)
                GView.DataBind()
                lblPageStatus.Text = ""
                dimmed()
            End If

            Dim dtime As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            Dim currentYear As String = dtime.ToString("yyyy")
            Dim currentYearInt As Integer
            currentYearInt = Convert.ToInt16(currentYear)
            Dim prevYearInt As Integer = currentYearInt - 10
            Dim nextYearInt As Integer = currentYearInt + 10
            For i As Integer = prevYearInt To nextYearInt
                Quarter_year.Items.Add(i.ToString())
            Next i
            Quarter_year.SelectedValue = currentYearInt.ToString()
            Quarter.DataBind()
            If Request.QueryString("mode") = "edit" Then
                FillSources()
                FillMainGrid()
            End If
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        txtStartDate.Text = ""
        txtCoast.Text = ""
        txtProjBrief.Text = ""
        txtProjTitle.Text = ""
        'DDLProjectManager.SelectedValue = "...اختر مديرا للمشــــروع..."
        DDLPriority.SelectedValue = "....اختر أولويه....."
        'txtpartamount.Text = ""

    End Sub
#End Region

#Region "dimmed fn"
    Private Sub dimmed()
        Dim str As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
        If BtnSave.Visible = False Or BtnSave.CommandArgument = "delete" Then
            tblnew.Visible = True
            '  tblSearch.Visible = False
            gvMain.Visible = False
            GView.Visible = True
            GView.Enabled = False
            'BtnDocUpload.Enabled = False
            txtProjTitle.Enabled = False
            txtProjBrief.ReadOnly = True
            txtStartDate.Enabled = False
            txtCoast.Enabled = False
            DDLPriority.Enabled = False
            'DDLProjectManager.Enabled = False
        Else
            BtnDocUpload.Enabled = True
            GView.Visible = False
            txtProjTitle.Enabled = True
            txtProjBrief.ReadOnly = False
            txtStartDate.Enabled = True
            txtCoast.Enabled = True
            DDLPriority.Enabled = True
            'DDLProjectManager.Enabled = True
            Clear()
            txtStartDate.Text = str.ToString("dd/MM/yyyy")
        End If
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtProjBrief.Text = "" Or txtProjTitle.Text = "" Or txtCoast.Text = "" Or String.IsNullOrEmpty(Smart_Search_man.SelectedValue) Or txtStartDate.Text = "" Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
            Return False
        Else
            lblPageStatus.Visible = False
            Return True
        End If
    End Function
#End Region

#Region "Fills"
    Private Sub FillGrid()
        'Dim dt1 As New DataTable
        Dim sql As String = ""
        sql = "select  distinct proj_id,PTem_Name,Proj_Title,Dept_name" _
       & " from project full outer join projects_documents on Proj_Proj_id = proj_id " _
       & " join project_team on project_team.proj_proj_id = proj_id " _
       & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
       & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID  where  ( 1 = 1 "

        If Request.QueryString("mode") = "edit" Then
            sql = sql & " and Proj_is_repeated = " & 1 & "or Proj_is_commit =" & 0 & " and Proj_is_refused <>" & 1 & " and Dept_id= " & Session_CS.dept_id & ")" 'Session("proj_id_to_edit")
            'dt1 = General_Helping.GetDataTable("select PDOC_FileName,PDOC_id from Projects_Documents where Proj_Proj_id=" & Proj_id.Value)
        Else
            sql = sql & ") "

        End If



        'If DdlProjNameSerach.SelectedValue <> "" Then
        '    sql = sql & " and proj_id = " & DdlProjNameSerach.SelectedValue
        'End If


        If Request.QueryString("mode") = "delete" Then
            sql = sql & " and Proj_is_repeated <> " & 1 & " and Proj_is_commit <>" & 1 & " and Proj_is_commit <> " & 2 & " and Dept_id=" & Session_CS.dept_id
        End If
        'If DdlProjMangSearch.SelectedValue <> "" Then
        '    sql = sql & " and ptem_id = " & DdlProjMangSearch.SelectedValue
        'End If

        'If txtProjCoastSearch.Text <> "" Then
        '    sql = sql & " and Proj_InitValue = " & txtProjCoastSearch.Text
        'End If

        'If txtProjDateSearch.Text <> "" Then
        '    If date_validate(txtProjDateSearch.Text) <> "" Then
        '        Dim Str As String = date_validate(txtProjDateSearch.Text)
        '        sql = sql & " and  Proj_Creation_Date '" & Str & "'"
        '    End If
        'End If


        'If txtDOC.Text <> "" Then
        '    sql = sql & " and PDOC_FileName= " & txtDOC.Text
        'End If



        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()
    End Sub

    Private Sub FillDDls()
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        'dt = General_Helping.GetDataTable("select pmp_id,pmp_name from employee JOIN JOB ON JOB_ID = JOB_JOB_ID WHERE JTIT_JTIT_ID NOT IN (1,2)")
        'Obj_General_Helping.SmartBindDDL(DDLProjectManager, dt, "pmp_id", "pmp_name", "...اختر مديرا للمشــــروع...")

        dt1 = General_Helping.GetDataTable("select prio_id,prio_desc from Priorities")
        Obj_General_Helping.SmartBindDDL(DDLPriority, dt1, "prio_id", "prio_desc", "....اختر أولويه.....")

    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Dim Bt(0) As Byte


        Try
            If ID = 0 Then
                If txtCoast.Text = "0" Then
                    lblPageStatus.Text = "الميزانية لايمكن أن تساوى 0"
                    lblPageStatus.Visible = True
                    txtCoast.Text = ""
                    Return
                End If

                Dim validated_start_date As String = ""
                If txtStartDate.Text <> "" Then

                    If txtStartDate.Text <> "" Then
                        validated_start_date = txtStartDate.Text
                        txtStartDate.Text = txtStartDate.Text

                        'If date_validate(txtStartDate.Text) <> "" Then
                        '    validated_start_date = date_validate(txtStartDate.Text)
                        '    txtStartDate.Text = date_validate(txtStartDate.Text)

                        lblPageStatus.Visible = False

                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If

                'Dim Project_ENTITY As New BLL.Project()
                General_Helping.ExcuteQuery("INSERT INTO Project (Proj_Title, Proj_Brief, Proj_Initvalue,Proj_Creation_Date,Pmp_Pmp_Id,Dept_Dept_Id,proj_is_commit, proj_is_refused  , proj_is_repeated ) VALUES ('" & txtProjTitle.Text & "','" & txtProjBrief.Text & "', " & Decimal.Parse(txtCoast.Text) & ",'" & validated_start_date & "'," & Session_CS.pmp_id & "," & Session_CS.dept_id & "," & 0 & "," & 0 & "," & 0 & ")")

                Dim Project_Team_ENTITY As New BLL.Project_Team()
                Project_Team_ENTITY.Proj_Proj_Id = General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id")
                Project_Team_ENTITY.Rol_Rol_Id = 4
                Project_Team_ENTITY.Ptem_Name = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " & Smart_Search_man.SelectedValue).Rows(0)("pmp_name")
                Project_Team_ENTITY.Ptem_Task = "مدير المشروع"
                Project_Team_ENTITY.Ptem_Task_Cat = "مدير المشروع"
                Project_Team_ENTITY.Pmp_Pmp_Id = Smart_Search_man.SelectedValue
                Project_Team_ENTITY.Job_Job_Id = 4
                Project_Team_ENTITY.Save()
                If DDLPriority.SelectedIndex <> 0 Then
                    General_Helping.ExcuteQuery("update project set prio_prio_id = " & DDLPriority.SelectedValue & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                Else
                    General_Helping.ExcuteQuery("update project set prio_prio_id = " & 3 & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                End If
                'FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
                BtnSave.Visible = False
                btnAnother.Visible = True
                dimmed()
                Proj_id.Value = General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id")
                Dim sd As String = ""

            Else
                If txtCoast.Text = "0" Then
                    lblPageStatus.Text = "الميزانية لايمكن أن تساوى 0"
                    lblPageStatus.Visible = True
                    txtCoast.Text = ""
                    Return
                End If
                Dim validated_date As String = ""
                If txtStartDate.Text <> "" Then

                    If txtStartDate.Text <> "" Then
                        validated_date = txtStartDate.Text

                        'If date_validate(txtStartDate.Text) <> "" Then
                        '    validated_date = date_validate(txtStartDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If
                General_Helping.ExcuteQuery("update project set Proj_Title = '" & txtProjTitle.Text & "', Proj_Brief = '" & txtProjBrief.Text & "' , Proj_Initvalue =  " & Decimal.Parse(txtCoast.Text) & ",Proj_Creation_Date = '" & validated_date & "',Pmp_Pmp_Id = " & Session_CS.pmp_id & " , Dept_Dept_Id=" & Session_CS.dept_id & ", proj_is_commit = 0 , proj_is_refused = 0 , proj_is_repeated = 0 where Proj_id=" & ID)

                Dim dt_1 As DataTable = General_Helping.GetDataTable("select ptem_id from  project_team where proj_proj_id = " & ID)
                If dt_1.Rows.Count > 0 Then
                    Dim Project_Team_id As Integer = dt_1.Rows(0)("ptem_id")
                    Dim Project_Team_ENTITY As New BLL.Project_Team(Project_Team_id)
                    Project_Team_ENTITY.Ptem_Name = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " & Smart_Search_man.SelectedValue).Rows(0)("pmp_name")
                    Project_Team_ENTITY.Pmp_Pmp_Id = Smart_Search_man.SelectedValue
                    Project_Team_ENTITY.Save()
                Else
                    Dim Project_Team_ENTITY As New BLL.Project_Team()
                    Project_Team_ENTITY.Proj_Proj_Id = General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id")
                    Project_Team_ENTITY.Rol_Rol_Id = 4
                    Project_Team_ENTITY.Ptem_Name = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " & Smart_Search_man.SelectedValue).Rows(0)("pmp_name")
                    Project_Team_ENTITY.Ptem_Task = "مدير المشروع"
                    Project_Team_ENTITY.Ptem_Task_Cat = "مدير المشروع"
                    Project_Team_ENTITY.Pmp_Pmp_Id = Smart_Search_man.SelectedValue
                    Project_Team_ENTITY.Job_Job_Id = 4
                    Project_Team_ENTITY.Save()
                End If

                If DDLPriority.SelectedIndex <> 0 Then
                    General_Helping.ExcuteQuery("update project set prio_prio_id = " & DDLPriority.SelectedValue & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                Else
                    General_Helping.ExcuteQuery("update project set prio_prio_id = " & 3 & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                End If

                ' FillGrid()
                tblnew.Visible = False
                '  tblSearch.Visible = True
                ' gvMain.Visible = True

                BtnSave.CommandArgument = "new"
                BtnSave.Text = "حفــــــظ"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
                If Request.QueryString("mode") = "edit" Then
                    btnAnother.Visible = False
                    BtnSave.Visible = True
                    tblnew.Visible = True
                    '  tblSearch.Visible = False
                    '  gvMain.Visible = False
                    GView.Visible = True
                    GView.Enabled = False
                    BtnDocUpload.Enabled = False
                    txtProjTitle.Enabled = False
                    txtProjBrief.ReadOnly = True
                    txtStartDate.Enabled = False
                    txtCoast.Enabled = False
                    DDLPriority.Enabled = False
                    'Smart_Search_man.e = False
                    BtnSave.Visible = False
                End If

            End If

        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click

        Proj_id.Value = Request.QueryString("proj_id")
        If Valid() Then
            If BtnSave.CommandArgument = "new" Then
                If Proj_id.Value <> Nothing Then
                    SaveDataForClasses(Proj_id.Value)
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "تم الحفظ بنجاح"
                Else
                    SaveDataForClasses()
                End If
                tblfinance.Visible = True
                tbldoc1.Visible = True
                Table1.Visible = True
                BtnSave.Visible = True
                Quarter.Enabled = True
                Quarter_year.Enabled = True
            ElseIf BtnSave.CommandArgument = "edit" Then
                SaveDataForClasses(Proj_id.Value)
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
                dimmed()
                btnAnother.Visible = False
                BtnSave.Visible = False
            ElseIf BtnSave.CommandArgument = "delete" Then
                Try
                    Dim str1 As String = ""
                    str1 = " delete  from projects_documents where proj_proj_id= " & Proj_id.Value
                    General_Helping.ExcuteQuery(str1)
                    str1 = " delete from Project_Team where proj_proj_id= " & Proj_id.Value
                    General_Helping.ExcuteQuery(str1)
                    str1 = " delete from project where proj_id= " & Proj_id.Value
                    General_Helping.ExcuteQuery(str1)
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = " تم الحذف بنجاح"
                    dimmed()
                    BtnSave.Visible = False
                    Clear()
                    Smart_Search_man.Clear_Controls()
                Catch ex As Exception
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "عفوا لايمكن الحذف"
                End Try
            End If
            tblfinance.Visible = True
            tbldoc1.Visible = True
        End If
    End Sub

    Protected Sub another_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnother.Click
        Proj_id.Value = Nothing
        btnAnother.Visible = False
        GView.Enabled = True
        BtnSave.Visible = True
        dimmed()
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        tblfinance.Visible = False
        tbldoc1.Visible = False
        Table1.Visible = True
        BtnSave.Visible = True
    End Sub

    Protected Sub Doc_ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        PDOC_id2.Value = CType(sender, ImageButton).CommandArgument
        BtnDocUpload.Text = "تعديل وثيقة"
        BtnSave.Visible = False
        'PDOC_id2.Value = CType(sender.parent.parent.FindControl("PDOC_id2"), HtmlControls.HtmlInputHidden).Value
        Dim str1 As String = ""
        Dim dt1 As New DataTable
        str1 = " select PDOC_FileName,PDOC_ID,PDOC_Image from projects_documents where PDOC_ID = " & PDOC_id2.Value
        dt1 = General_Helping.GetDataTable(str1)
        If Not dt1.Rows(0)("PDOC_FileName") Is DBNull.Value Then
            txtDocName.Text = dt1.Rows(0)("PDOC_FileName")
        End If
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In GView.Rows
            If CType(GView.Rows(i).FindControl("PDOC_id2"), HtmlControls.HtmlInputHidden).Value = PDOC_id2.Value Then
                id = i
            Else
                GView.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next

        GView.Rows(id).BackColor = Drawing.Color.Lavender

    End Sub

    Protected Sub Doc_ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        PDOC_id3.Value = CType(sender, ImageButton).CommandArgument
        General_Helping.ExcuteQuery("delete from Projects_Documents where PDOC_ID=" & PDOC_id3.Value)
        FillDocsGrid()
    End Sub

    Protected Sub finance_ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        btnpartfinance.Text = " تعديل الفترة"
        BtnSave.Visible = False
        'PDOC_id2.Value = CType(sender.parent.parent.FindControl("PDOC_id2"), HtmlControls.HtmlInputHidden).Value
        Dim str1 As String = ""
        Dim dt1 As New DataTable
        str1 = "select Strt_Date,End_Date,Init_Value as int_Init_Value from Project_Period_Balance where Period_ID=" & CType(sender, ImageButton).CommandArgument
        dt1 = General_Helping.GetDataTable(str1)
        If Not dt1.Rows(0)("Strt_Date") Is DBNull.Value Then
            Quarter.SelectedValue = dt1.Rows(0)("Strt_Date")
        End If
        'If Not dt1.Rows(0)("End_Date") Is DBNull.Value Then
        '    Quarter_year.SelectedValue = dt1.Rows(0)("End_Date")
        'End If
        'If Not dt1.Rows(0)("int_Init_Value") Is DBNull.Value Then
        'txtpartamount.Text = dt1.Rows(0)("int_Init_Value")
        'End If
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvfinance.Rows
            If CType(gvfinance.Rows(i).FindControl("Period_ID"), HtmlControls.HtmlInputHidden).Value = CType(sender, ImageButton).CommandArgument Then
                id = i
            Else
                gvfinance.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next

        gvfinance.Rows(id).BackColor = Drawing.Color.Lavender

    End Sub

    Protected Sub finance_ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        General_Helping.ExcuteQuery("delete from Project_Period_Balance where Period_ID=" & CType(sender, ImageButton).CommandArgument)
        Dim dt1 As DataTable
        If lblID.Text <> "" Then
            Proj_id.Value = lblID.Text
        End If
        dt1 = General_Helping.GetDataTable("select Strt_Date,End_Date,Init_Value as int_Init_Value from Project_Period_Balance where Proj_id=" & Proj_id.Value)
        If dt1.Rows.Count > 0 Then
            gvfinance.DataSource = dt1
            gvfinance.DataBind()
            gvfinance.Visible = True
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        tblnew.Visible = True

        GView.Visible = True

        Dim _dt As DataTable = General_Helping.GetDataTable("select * ,prio_prio_id,Proj_InitValue as Proj_InitValue_integer from Project where proj_id=" & CType(sender, ImageButton).CommandArgument)
        If Not _dt.Rows(0)("Proj_Creation_Date") Is DBNull.Value Then
            txtStartDate.Text = _dt.Rows(0)("Proj_Creation_Date")
        End If
        txtCoast.Text = _dt.Rows(0)("Proj_InitValue_integer")
        Smart_Search_man.SelectedValue = General_Helping.GetDataTable("select Project_team.pmp_pmp_id from  Project join Project_team on proj_proj_id = Proj_id where proj_id = " & CType(sender, ImageButton).CommandArgument).Rows(0)("pmp_pmp_id")
        txtProjBrief.Text = _dt.Rows(0)("Proj_Brief")
        txtProjTitle.Text = _dt.Rows(0)("Proj_Title")
        If Not _dt.Rows(0)("prio_prio_id") Is DBNull.Value Then
            DDLPriority.SelectedValue = _dt.Rows(0)("prio_prio_id")
        End If
        Proj_id.Value = CType(sender, ImageButton).CommandArgument
        Dim str As String

        str = " select PDOC_FileName ,PDOC_ID from projects_documents where Proj_Proj_id= " & CType(sender, ImageButton).CommandArgument
        GView.DataSource = General_Helping.GetDataTable(str)
        GView.DataBind()


        BtnSave.Text = "تعديــــل"
        lblPageStatus.Text = ""
    End Sub

    Public Sub GetData()

        Dim _dt As New DataTable
        Dim sql As String = ""
        sql = " select TOP (1) Proj_id as pid FROM Project Order by  Proj_id DESC "
        _dt = General_Helping.GetDataTable(sql)

        If (_dt.Rows.Count > 0) Then
            lblID.Text = _dt.Rows(0)("pid")
            con.Close()
        End If

    End Sub

    Public Function OpenConnection() As Boolean
        Try
            If con.State <> ConnectionState.Open Then
                '''''''''''''specify the ConnectionStrng property'''''''''''''
                Dim conString As String '= "Data Source=migo-pc;Initial Catalog=ForTestOnly;Persist Security Info=True;User ID=WebProjects;Password=sqlasp"
                conString = DBL.Universal.GetConnectionString

                '''''''''''''Initializes a new instance of the SQLConnection'''''''''''''
                con = New SqlConnection(conString)

                ''''''''''''' open the database connection with the property settings'''''''''''''
                '''''''''''''specified by the ConnectionString "conString"'''''''''''''
                con.Open()
                Return True
            End If
        Catch ex As Exception
            con.Close()
            Return False
        End Try
    End Function

    Sub DisplayFileContents(ByVal file As HttpPostedFile)

        If PDOC_id2.Value = Nothing Then
            Dim myStream As System.IO.Stream
            Dim fileLen As Integer
            Dim displayString As New StringBuilder()
            fileLen = DocUpload.PostedFile.ContentLength
            Dim Input(fileLen) As Byte
            myStream = DocUpload.FileContent
            Dim DocName As String
            Dim type As String
            If (DocUpload.HasFile = True) Then

                DocName = DocUpload.FileName
                Dim dotindex As Integer = DocName.LastIndexOf(".")
                type = DocName.Substring(dotindex, DocName.Length - dotindex)

                myStream.Read(Input, 0, fileLen)
                Session("myStream") = Input
                Dim cmd As New SqlCommand()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text

                OpenConnection()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = " insert into Projects_Documents (PDOC_Image,PDOC_FileName,PDOC_Type,Proj_Proj_id) VALUES (@PDOC_Image,@PDOC_FileName,@PDOC_Type,@Proj_Proj_id)"
                cmd.Parameters.Add("@PDOC_Image", SqlDbType.Image)
                cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@PDOC_Type", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)


                cmd.Parameters("@PDOC_Image").Value = Input
                cmd.Parameters("@PDOC_FileName").Value = txtDocName.Text
                cmd.Parameters("@PDOC_Type").Value = type
                cmd.Parameters("@Proj_Proj_id").Value = lblID.Text
                'Response.Write(cmd)
                cmd.ExecuteNonQuery()
            End If

        Else

            Dim myStream As System.IO.Stream
            Dim fileLen As Integer
            Dim displayString As New StringBuilder()
            fileLen = DocUpload.PostedFile.ContentLength
            Dim Input(fileLen) As Byte
            myStream = DocUpload.FileContent
            Dim DocName As String
            Dim type As String
            If (DocUpload.HasFile = True) Then

                DocName = DocUpload.FileName
                Dim dotindex As Integer = DocName.LastIndexOf(".")
                type = DocName.Substring(dotindex, DocName.Length - dotindex)

                myStream.Read(Input, 0, fileLen)
                Session("myStream") = Input
                Dim cmd As New SqlCommand()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text

                OpenConnection()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = " update Projects_Documents set(PDOC_Image,PDOC_FileName,PDOC_Type) VALUES (@PDOC_Image,@PDOC_FileName,@PDOC_Type) where Proj_Proj_id" & PDOC_id2.Value
                cmd.Parameters.Add("@PDOC_Image", SqlDbType.Image)
                cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@PDOC_Type", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)


                cmd.Parameters("@PDOC_Image").Value = Input
                cmd.Parameters("@PDOC_FileName").Value = txtDocName.Text
                cmd.Parameters("@PDOC_Type").Value = type
                cmd.Parameters("@Proj_Proj_id").Value = lblID.Text
                'Response.Write(cmd)
                cmd.ExecuteNonQuery()
            Else
                Dim Sql As String = "update Projects_Documents set  PDOC_FileName = '" & txtDocName.Text & "' where PDOC_ID=" & PDOC_id2.Value
                General_Helping.ExcuteQuery(Sql)
            End If
        End If

    End Sub

#End Region

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try

            Dim str As String = ""
            str = " delete  from projects_documents where proj_proj_id= " & CType(sender, ImageButton).CommandArgument
            General_Helping.ExcuteQuery(str)
            str = " delete from Project_Team where proj_proj_id= " & CType(sender, ImageButton).CommandArgument
            General_Helping.ExcuteQuery(str)
            str = " delete from project where proj_id= " & CType(sender, ImageButton).CommandArgument
            General_Helping.ExcuteQuery(str)
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
            'FillGrid()
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لايمكن الحذف"
        End Try
        'str = " delete from project where proj_id= " & CType(sender, ImageButton).CommandArgument
        'cmd = New SqlCommand(str, con)
        'cmd.ExecuteNonQuery()
        'gvMain.DataBind()


    End Sub

    Protected Sub txtStartDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStartDate.TextChanged


        If txtStartDate.Text <> "" Then
            txtStartDate.Text = txtStartDate.Text

            'If date_validate(txtStartDate.Text) <> "" Then
            '    txtStartDate.Text = date_validate(txtStartDate.Text)

            lblPageStatus.Visible = False

        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            Return
        End If

    End Sub

    Protected Sub txtCoast_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCoast.TextChanged
        If txtCoast.Text = "0" Then
            lblPageStatus.Text = "الميزانية لايمكن أن تساوى 0"
            lblPageStatus.Visible = True
            txtCoast.Text = ""
            Return

        End If
    End Sub

    Private Sub FillDocsGrid()
        Dim dt1 As New DataTable
        dt1 = General_Helping.GetDataTable("select PDOC_FileName,PDOC_id from Projects_Documents where Proj_Proj_id=" & Proj_id.Value & "order by pdoc_id")

        GView.DataSource = dt1
        GView.DataBind()
        GView.Visible = True
        txtDocName.Text = ""

    End Sub

    Protected Sub BtnDocUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDocUpload.Click
        If Proj_id.Value = Nothing Then
            If lblID.Text = "" Then
                General_Helping.ExcuteQuery("insert into Project (Proj_Notes) values ('')")
                Dim dt As DataTable = General_Helping.GetDataTable("select max(Proj_id) as max_id from Project")
                Dim dt1 As New DataTable
                Proj_id.Value = dt.Rows(0)("max_id")
                If txtDocName.Text <> "" Then
                    lblID.Text = Proj_id.Value
                    DisplayFileContents(DocUpload.PostedFile)
                    dt1 = General_Helping.GetDataTable("select PDOC_FileName,PDOC_id from Projects_Documents where Proj_Proj_id=" & Proj_id.Value)
                    If dt1.Rows.Count > 0 Then
                        GView.DataSource = dt1
                        GView.DataBind()
                        GView.Visible = True
                        txtDocName.Text = ""
                    End If
                End If
            Else
                Dim dt1 As New DataTable
                If txtDocName.Text <> "" Then
                    Proj_id.Value = lblID.Text
                    DisplayFileContents(DocUpload.PostedFile)
                    dt1 = General_Helping.GetDataTable("select PDOC_FileName,PDOC_id from Projects_Documents where Proj_Proj_id=" & Proj_id.Value)
                    If dt1.Rows.Count > 0 Then
                        GView.DataSource = dt1
                        GView.DataBind()
                        GView.Visible = True
                        txtDocName.Text = ""
                    End If
                End If
            End If

        Else
            Dim dt1 As New DataTable
            If txtDocName.Text <> "" Then
                lblID.Text = Proj_id.Value
                DisplayFileContents(DocUpload.PostedFile)
                dt1 = General_Helping.GetDataTable("select PDOC_FileName,PDOC_id from Projects_Documents where Proj_Proj_id=" & Proj_id.Value)
                If dt1.Rows.Count > 0 Then
                    GView.DataSource = dt1
                    GView.DataBind()
                    GView.Visible = True
                    txtDocName.Text = ""
                End If
            End If
        End If
        BtnDocUpload.Text = "تحميل وثيقة"
        BtnSave.Visible = True
        PDOC_id2.Value = Nothing
    End Sub

    Protected Sub btnpartfinance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnpartfinance.Click

        Dim i As Integer
        Dim totalAmount As Integer
        Dim qrtrData As DataTable = General_Helping.GetDataTable("select * from Project_Period_Quarter where Quarter_NO=" & Quarter.SelectedValue)
        Dim qryStr As String
        qryStr = " select PB.Period_ID from Project_Period_Balance PB " _
        & " where PB.Proj_id = " & Proj_id.Value & "" _
        & " and PB.Quarter_Year = '" & Quarter_year.SelectedValue & "' " _
        & " and PB.Quarter_NO = '" & Quarter.SelectedValue & "' "
        Dim qrtrData2 As DataTable = General_Helping.GetDataTable(qryStr)

        If qrtrData2.Rows.Count > 0 Then
            General_Helping.ExcuteQuery("DELETE FROM Project_Period_Sources WHERE Period_ID=" & qrtrData2.Rows(0)("Period_ID").ToString())
            For i = 0 To provide_src.Rows.Count - 1
                Dim row As GridViewRow
                row = provide_src.Rows(i)
                Dim cb As TextBox = row.FindControl("txtpartamount")
                Dim hField As HiddenField = row.FindControl("HiddenField1")
                Dim hField2 As HiddenField = row.FindControl("HiddenField2")
                totalAmount = totalAmount + CDataConverter.ConvertToDecimal(cb.Text)
                If CDataConverter.ConvertToDecimal(cb.Text) > 0 Then
                    General_Helping.ExcuteQuery("insert into Project_Period_Sources (Period_ID,Sources_ID,Value) values (-1," & hField.Value & "," & cb.Text & ")")
                End If
                qryStr = " select ID from Project_Period_Source_Total " _
                & " where Proj_id = " & Proj_id.Value & " " _
                & " and Sources_ID = " & hField.Value & " " _
                & " and Strt_Date = '" & "01/07" & "/" & Quarter_year.SelectedValue & "' " _
                & " and End_Date = '" & "30/06" & "/" & Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString() & "' "
                Dim qrtrData3 As DataTable = General_Helping.GetDataTable(qryStr)
                If qrtrData3.Rows.Count > 0 Then
                    Dim diff As Decimal = CDataConverter.ConvertToDecimal(cb.Text) - CDataConverter.ConvertToDecimal(hField2.Value)
                    Dim updateStr As String = "UPDATE Project_Period_Source_Total set Total_Value=Total_Value+(" & diff.ToString() & ")" _
                    & " where Proj_id = " & Proj_id.Value & " " _
                    & " and Sources_ID = " & hField.Value & " " _
                    & " and Strt_Date = '" & "01/07" & "/" & Quarter_year.SelectedValue & "' " _
                    & " and End_Date = '" & "30/06" & "/" & Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString() & "' "
                    General_Helping.ExcuteQuery(updateStr)
                Else
                    General_Helping.ExcuteQuery("insert into Project_Period_Source_Total (Proj_id,Sources_ID,Strt_Date,End_Date,Total_Value) values (" & Proj_id.Value & "," & hField.Value & ",'" & "01/07" & "/" & Quarter_year.SelectedValue & "','" & "30/06" & "/" & Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString() & "'," & cb.Text & ")")
                End If

            Next
            'lblPageStatus.Text = totalAmount.ToString()
            lblPageStatus.Visible = True
            General_Helping.ExcuteQuery("update Project_Period_Balance set Init_Value=" & totalAmount.ToString() & " where Period_ID = " & qrtrData2.Rows(0)("Period_ID") & "")
            If CDataConverter.ConvertToDecimal(totalAmount.ToString()) > 0 Then
                'If Convert.ToInt16(Quarter.SelectedValue) > 2 Then
                Dim strEndYear As String = Quarter_year.SelectedValue
                If Convert.ToInt16(Quarter.SelectedValue) > 2 Then
                    strEndYear = Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString()
                End If

                Dim maxPeriodID As Integer = qrtrData2.Rows(0)("Period_ID")
                General_Helping.ExcuteQuery("UPDATE Project_Period_Sources set Period_ID=" & maxPeriodID & " where Period_ID=-1")
            End If
        Else
            For i = 0 To provide_src.Rows.Count - 1
                Dim row As GridViewRow
                row = provide_src.Rows(i)
                Dim cb As TextBox = row.FindControl("txtpartamount")
                Dim hField As HiddenField = row.FindControl("HiddenField1")
                totalAmount = totalAmount + CDataConverter.ConvertToDecimal(cb.Text)
                If CDataConverter.ConvertToDecimal(cb.Text) > 0 Then
                    General_Helping.ExcuteQuery("insert into Project_Period_Sources (Period_ID,Sources_ID,Value) values (-1," & hField.Value & "," & cb.Text & ")")
                    General_Helping.ExcuteQuery("insert into Project_Period_Source_Total (Proj_id,Sources_ID,Strt_Date,End_Date,Total_Value) values (" & Proj_id.Value & "," & hField.Value & ",'" & "01/07" & "/" & Quarter_year.SelectedValue & "','" & "30/06" & "/" & Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString() & "'," & cb.Text & ")")
                End If
            Next
            '            lblPageStatus.Text = totalAmount.ToString()
            lblPageStatus.Visible = True
            If CDataConverter.ConvertToDecimal(totalAmount.ToString()) > 0 Then
                'If Convert.ToInt16(Quarter.SelectedValue) > 2 Then
                Dim strEndYear As String = Quarter_year.SelectedValue
                If Convert.ToInt16(Quarter.SelectedValue) > 2 Then
                    strEndYear = Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString()
                End If
                General_Helping.ExcuteQuery("insert into Project_Period_Balance (Strt_Date,End_Date,Init_Value,Proj_id,Quarter_NO,Quarter_Year) values ('" & qrtrData.Rows(0)("Quarter_Start_Date") & "/" & strEndYear & "','" & qrtrData.Rows(0)("Quarter_End_Date") & "/" & strEndYear & "'," & totalAmount.ToString() & " , " & Proj_id.Value & " , " & Quarter.SelectedValue & " , " & Quarter_year.SelectedValue & ")")
                Dim maxPeriodDT As DataTable = General_Helping.GetDataTable("select max(Period_ID) as max_id from Project_Period_Balance")
                Dim maxPeriodID As Integer = maxPeriodDT.Rows(0)("max_id")
                General_Helping.ExcuteQuery("UPDATE Project_Period_Sources set Period_ID=" & maxPeriodID & " where Period_ID=-1")
            End If
        End If
        FillSources()
        FillMainGrid()
        Quarter.Enabled = False
        Quarter_year.Enabled = False
    End Sub

    Protected Sub Quarter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Quarter.SelectedIndexChanged
        FillSources()

    End Sub

    Protected Sub Quarter_year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Quarter_year.SelectedIndexChanged
        FillSources()
    End Sub

    Public Function FillSources(Optional ByVal mode As String = "", Optional ByVal priod_id As String = "") As Integer
        Dim qryStr As String = ""
        Dim strEndYear As String = Quarter_year.SelectedValue
        If Convert.ToInt16(Quarter.SelectedValue) > 2 Then
            strEndYear = Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString()
        End If

        Dim qrtrData As DataTable = General_Helping.GetDataTable("select * from Project_Period_Quarter where Quarter_NO=" & Quarter.SelectedValue)
        qryStr = " select PP.Sources_ID,PP.Value,PB.Quarter_NO,PB.Quarter_Year,PB.Period_ID from Project_Period_Sources PP left outer join Project_Period_Balance PB on PB.Period_ID=PP.Period_ID " _
        & " where PB.Proj_id = " & Proj_id.Value & "" _
        & " and PB.Quarter_Year = '" & Quarter_year.SelectedValue & "' " _
        & " and PB.Quarter_NO = '" & Quarter.SelectedValue & "' order by PB.Period_ID desc"

        qrtrData = General_Helping.GetDataTable(qryStr)

        Dim qrtrData2 As DataTable
        qryStr = " select PB.Quarter_NO,PB.Quarter_Year,PB.Period_ID from Project_Period_Balance PB " _
        & " where PB.Proj_id = " & Proj_id.Value & "" _
        & " order by PB.Period_ID desc"

        qrtrData2 = General_Helping.GetDataTable(qryStr)

        For i = 0 To provide_src.Rows.Count - 1
            Dim row As GridViewRow
            row = provide_src.Rows(i)
            Dim cb As TextBox = row.FindControl("txtpartamount")
            cb.Text = ""
        Next
        If qrtrData.Rows.Count > 0 Then
            qrtrData.PrimaryKey = New DataColumn() {qrtrData.Columns("Sources_ID")}

            If mode = "EditItem" Then
                Quarter_year.SelectedValue = qrtrData.Rows(0)("Quarter_Year").ToString()
                Quarter.SelectedValue = qrtrData.Rows(0)("Quarter_NO").ToString()
            ElseIf qrtrData2.Rows(0)("Quarter_NO").ToString() = "4" Then
                Quarter_year.SelectedValue = (Convert.ToUInt16(qrtrData2.Rows(0)("Quarter_Year").ToString()) + 1).ToString()
                Quarter.SelectedValue = "1"
            Else
                Quarter_year.SelectedValue = qrtrData2.Rows(0)("Quarter_Year").ToString()
                Dim sssd As String = (Convert.ToUInt16(qrtrData2.Rows(0)("Quarter_NO").ToString()) + 1).ToString()
                Quarter.SelectedValue = (Convert.ToUInt16(qrtrData2.Rows(0)("Quarter_NO").ToString()) + 1).ToString()
            End If

            If mode = "EditItem" Then
                For i = 0 To provide_src.Rows.Count - 1
                    Dim row As GridViewRow
                    row = provide_src.Rows(i)
                    Dim cb As TextBox = row.FindControl("txtpartamount")
                    Dim hField As HiddenField = row.FindControl("HiddenField1")
                    Dim hField2 As HiddenField = row.FindControl("HiddenField2")
                    Dim foundRow() As DataRow
                    foundRow = qrtrData.Select("Sources_ID = '" & hField.Value & "'")

                    If foundRow.Length > 0 Then
                        If Not (foundRow(0)("Value") Is Nothing) Then
                            hField2.Value = foundRow(0)("Value")
                            cb.Text = foundRow(0)("Value")
                        Else
                            cb.Text = ""
                        End If
                    End If
                Next
            End If
        Else
            Quarter.Enabled = True
            Quarter_year.Enabled = True
        End If
        Return 0
    End Function

    Public Function FillMainGrid() As Integer
        Dim qryStr As String = ""
        Dim qrtrData As DataTable
        qryStr = " select PB.*,PQ.Quarter_Name from Project_Period_Balance PB INNER JOIN Project_Period_Quarter PQ on PB.Quarter_NO=PQ.Quarter_NO " _
        & " where PB.Proj_id = " & Proj_id.Value & " ORDER BY PB.Quarter_Year ASC"
        qrtrData = General_Helping.GetDataTable(qryStr)
        grdView_Main.DataSource = qrtrData
        grdView_Main.DataBind()
        Return 0
    End Function

    Public Function GetDataSet(ByVal ID As String) As DataTable
        Dim qryStr As String = ""
        Dim qrtrData As DataTable
        qryStr = " select PF.Source_Name,PS.Value,PS.Period_ID from Project_Period_Sources PS INNER JOIN Project_Funding_Sources PF ON PF.Sources_ID=PS.Sources_ID" _
        & " where PS.Period_ID = " & ID & ""
        qrtrData = General_Helping.GetDataTable(qryStr)
        Return qrtrData
    End Function

    'Public Sub DataTable GetDataSet(ByVal send string ID)
    '    return General_Helping.GetDataTable("SELECT    * FROM         Project_Activities WHERE     PActv_Parent=" + ID);
    'End Sub

    Protected Sub grdView_Main_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdView_Main.RowCommand
        Dim qryStr As String = ""
        Dim qrtrData As DataTable
        qryStr = " select * from Project_Period_Balance PB " _
            & " where PB.Period_ID = " & e.CommandArgument.ToString()
        qrtrData = General_Helping.GetDataTable(qryStr)

        If e.CommandName = "RemoveItem" Then
            If qrtrData.Rows.Count > 0 Then
                If Not (qrtrData.Rows(0)("Period_ID") Is DBNull.Value) Then
                    General_Helping.ExcuteQuery("DELETE from Project_Period_Balance where Period_ID=" & e.CommandArgument.ToString())
                    General_Helping.ExcuteQuery("DELETE from Project_Period_Sources where Period_ID=" & e.CommandArgument.ToString())
                    FillSources()
                End If
            End If
        ElseIf e.CommandName = "EditItem" Then
            If qrtrData.Rows.Count > 0 Then
                If Not (qrtrData.Rows(0)("Quarter_NO") Is DBNull.Value) Then
                    Quarter.SelectedValue = Convert.ToString(Convert.ToInt16(qrtrData.Rows(0)("Quarter_NO")))
                    Quarter_year.SelectedValue = Convert.ToString(Convert.ToInt16(qrtrData.Rows(0)("Quarter_Year")))
                    FillSources("EditItem", e.CommandArgument.ToString())
                End If
            Else
                Quarter.SelectedIndex = 0
                Quarter_year.SelectedIndex = 0
            End If
        End If
        FillMainGrid()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        FillSources()
    End Sub
End Class
