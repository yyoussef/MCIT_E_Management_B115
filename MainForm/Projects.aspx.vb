Imports System.Data.SqlClient
Imports System.Data
Imports VB_Classes.Dates
Imports System.Collections
'Imports System.Windows.Forms

Partial Class MainForm_Projects
    Inherits System.Web.UI.Page
    'Session_CS Session_CS



#Region "Variables"
    Dim Project_ENTITY As New BLL.Project
    Dim Project_Obj_ENTITY As New BLL.Project_Objective
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
        Dim Query As String = " SELECT     EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name,rol_rol_id, Departments.sec_sec_id FROM EMPLOYEE INNER JOIN                       Departments ON EMPLOYEE.Dept_Dept_id = Departments.Dept_ID  where rol_rol_id=4 ORDER BY LTRIM(pmp_name) "
        Smart_Search_man.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_man.Orderby = "ORDER BY LTRIM(pmp_name)"
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

            If Request.QueryString("mode") = "new" Then
                tblfinance.Visible = True
                tbldoc1.Visible = True
                'Check()
            End If
            CheckCategory.DataBind()
            CheckTechnique.DataBind()
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

            ElseIf (Request.QueryString("mode") = "edit") Then
                'Or (Request("Editp") <> Nothing)
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
                Smart_Search_man.SelectedValue = _dt.Rows(0)("pmp_pmp_id") 'General_Helping.GetDataTable("select Project_team.pmp_pmp_id from  Project join Project_team on proj_proj_id = Proj_id where proj_id = " & Proj_id.Value).Rows(0)("pmp_pmp_id")

                If _dt.Rows.Count > 0 Then
                    If Not _dt.Rows(0)("Proj_Brief") Is DBNull.Value Then
                        txtProjBrief.Text = _dt.Rows(0)("Proj_Brief")
                    End If
                    If Not _dt.Rows(0)("Proj_Title") Is DBNull.Value Then
                        txtProjTitle.Text = _dt.Rows(0)("Proj_Title")
                    End If

                    If Not _dt.Rows(0)("prio_prio_id") Is DBNull.Value Then
                        DDLPriority.SelectedValue = _dt.Rows(0)("prio_prio_id")
                    End If
                    If Not _dt.Rows(0)("Protocol_ID") Is DBNull.Value Then
                        Protocol_ID.Value = _dt.Rows(0)("Protocol_ID")
                    End If

                    If _dt.Rows(0)("proj_sug_type") <> "0" Then
                        DDLSuggestType.SelectedValue = _dt.Rows(0)("proj_sug_type")
                    End If

                End If


                Dim str2 As String = ""
                str2 = " select File_name ,File_ID from Departments_Documents where  parent_id <> 0 and  Proj_Proj_id= " & Proj_id.Value
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
                If _dt.Rows.Count > 0 Then
                    If Not _dt.Rows(0)("Proj_Brief") Is DBNull.Value Then
                        txtProjBrief.Text = _dt.Rows(0)("Proj_Brief")
                    End If
                    If Not _dt.Rows(0)("Proj_Title") Is DBNull.Value Then
                        txtProjTitle.Text = _dt.Rows(0)("Proj_Title")
                    End If

                    If Not _dt.Rows(0)("prio_prio_id") Is DBNull.Value Then
                        DDLPriority.SelectedValue = _dt.Rows(0)("prio_prio_id")
                    End If

                    If _dt.Rows(0)("proj_sug_type") <> "0" Then
                        DDLSuggestType.SelectedValue = _dt.Rows(0)("proj_sug_type")
                    End If
                End If


                Dim str2 As String = ""
                str2 = " select File_name ,File_ID from Departments_Documents where parent_id <> 0 and Proj_Proj_id= " & Proj_id.Value
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
            '''''added by Noura '''''
            BtnDocUpload.Enabled = False
            BtnSend.Enabled = False
            BtnSaveGoal.Enabled = False
            btnpartfinance.Enabled = False
            Button1.Enabled = False


            If Request("Editp") <> Nothing Then
                Proj_id.Value = Request.QueryString("Editp")
                Table1.Visible = True
                TableGoals.Visible = True
                tbldoc1.Visible = True
                tblfinance.Visible = True
                tblnew.Visible = True
                Retrive()
                Check()
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
        DDLSuggestType.SelectedValue = "...اختر نوع مقترح المشــــروع..."
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
            DDLSuggestType.Enabled = False

            'DDLProjectManager.Enabled = False
        Else
            'BtnDocUpload.Enabled = True
            GView.Visible = False
            txtProjTitle.Enabled = True
            txtProjBrief.ReadOnly = False
            txtStartDate.Enabled = True
            txtCoast.Enabled = True
            DDLPriority.Enabled = True
            DDLSuggestType.Enabled = True
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
            'BtnSend.Enabled = True
            Return True
        End If
    End Function
    Private Function ValidBudget(Optional ByVal Proj_InitValue As Decimal = 0.0) As Boolean
        Dim sql As String = "SELECT SUM(Proj_InitValue) AS Total_Pro_Balance, Total_Balance_LE " _
                        & "FROM Project INNER JOIN Protocol_Main_Def ON Project.Protocol_ID = Protocol_Main_Def.Protocol_ID AND Protocol_Main_Def.Protocol_ID = " & Protocol_ID.Value & " " _
                        & "WHERE (dbo.Project.Protocol_ID IS NOT NULL) AND Proj_id <> " & Proj_id.Value & " GROUP BY Total_Balance_LE"
        Dim protocolBudget As DataTable = General_Helping.GetDataTable(sql)
        Dim totalProBalance As Decimal = Proj_InitValue
        Dim Total_Balance_LE As Decimal = 0
        If protocolBudget.Rows.Count > 0 Then
            totalProBalance += CDataConverter.ConvertToDecimal(protocolBudget.Rows(0)("Total_Pro_Balance").ToString())
            Total_Balance_LE = CDataConverter.ConvertToDecimal(protocolBudget.Rows(0)("Total_Balance_LE").ToString())
        End If
        If totalProBalance > Total_Balance_LE Then
            Return False
        Else
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
        dt = General_Helping.GetDataTable("select ID,suggest_type from Project_suggestion_types")
        Obj_General_Helping.SmartBindDDL(DDLSuggestType, dt, "ID", "suggest_type", "...اختر نوع مقترح المشــــروع...")

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

                ID = General_Helping.ExcuteQuery("INSERT INTO Project (Proj_Title, Proj_Brief, Proj_Initvalue,Proj_Creation_Date,Pmp_Pmp_Id,Dept_Dept_Id,proj_is_commit, proj_is_refused  , proj_is_repeated,Balance_Suggest_Initial ) VALUES ('" & txtProjTitle.Text & "','" & txtProjBrief.Text & "', " & Decimal.Parse(txtCoast.Text) & ",'" & validated_start_date & "'," & Smart_Search_man.SelectedValue & "," & Session_CS.dept_id & "," & 1 & "," & 0 & "," & 0 & "," & Decimal.Parse(txtCoast.Text) & ") select @@identity")
                If (ID > 0) Then
                    Proj_id.Value = ID.ToString()
                End If
                CheckListControls()
                Dim File_Id As Integer
                File_Id = General_Helping.ExcuteQuery("insert into Departments_Documents (Parent_ID,File_name, proj_proj_id) VALUES ( 0 ,'وثيقة مقترح المشروع'," & Proj_id.Value & ")select @@identity")
                If (File_Id > 0) Then
                    FileDoc_id.Value = File_Id.ToString()
                End If
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

                If DDLSuggestType.SelectedIndex <> 0 Then
                    General_Helping.ExcuteQuery("update project set proj_sug_type = " & DDLSuggestType.SelectedValue & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                Else
                    General_Helping.ExcuteQuery("update project set proj_sug_type = " & 0 & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                End If

                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
                BtnSave.Visible = False
                btnAnother.Visible = True
                Sending_MailClass.sendmail(txtProjBrief.Text, Session_CS.pmp_name)

                dimmed()
                'Proj_id.Value = General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id")
                Dim sd As String = ""
            Else
                Dim canEdit As Boolean = True

                If txtCoast.Text = "0" Then
                    lblPageStatus.Text = "الميزانية لايمكن أن تساوى 0"
                    lblPageStatus.Visible = True
                    txtCoast.Text = ""
                    canEdit = False
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
                        canEdit = False
                    End If
                End If
                If CDataConverter.ConvertToInt(Protocol_ID.Value) > 0 And ValidBudget(CDataConverter.ConvertToDecimal(txtCoast.Text)) = False Then
                    lblPageStatus.Text = "ميزانية المشروع أكبر من ميزانية البروتوكول التابع له"
                    lblPageStatus.Visible = True
                    txtCoast.Text = ""
                    canEdit = False
                End If
                If canEdit Then
                    General_Helping.ExcuteQuery("update project set Proj_Title = '" & txtProjTitle.Text & "',Proj_is_commit=1,Proj_is_repeated=0" & ", Proj_Brief = '" & txtProjBrief.Text & "' , Proj_Initvalue =  " & Decimal.Parse(txtCoast.Text) & ",Proj_Creation_Date = '" & validated_date & "',Pmp_Pmp_Id = " & Smart_Search_man.SelectedValue & " , Dept_Dept_Id=" & Session_CS.dept_id & ",Balance_Suggest_Initial =  " & Decimal.Parse(txtCoast.Text) & " where Proj_id=" & ID)

                    If DDLPriority.SelectedIndex <> 0 Then
                        General_Helping.ExcuteQuery("update project set prio_prio_id = " & DDLPriority.SelectedValue & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                    Else
                        General_Helping.ExcuteQuery("update project set prio_prio_id = " & 3 & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                    End If

                    If DDLSuggestType.SelectedIndex <> 0 Then
                        General_Helping.ExcuteQuery("update project set proj_sug_type = " & DDLSuggestType.SelectedValue & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                    Else
                        General_Helping.ExcuteQuery("update project set proj_sug_type = " & 0 & " where proj_id = " & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                    End If

                    tblnew.Visible = False

                    BtnSave.CommandArgument = "new"
                    BtnSave.Text = "حفــــــظ"
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "تم التعديل بنجاح"
                    If Request.QueryString("mode") = "edit" Then
                        btnAnother.Visible = True

                        tblnew.Visible = True
                        GView.Visible = True
                        GView.Enabled = False
                        'BtnDocUpload.Enabled = False
                        txtProjTitle.Enabled = False
                        txtProjBrief.ReadOnly = True
                        txtStartDate.Enabled = False
                        txtCoast.Enabled = False
                        DDLPriority.Enabled = False
                        DDLSuggestType.Enabled = False
                        'Smart_Search_man.e = False
                        BtnSave.Visible = False
                    End If
                End If

                Dim n As Integer = 0
            End If


        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click

        If BtnSave.CommandArgument = "new" Then
            If Valid() Then
                If Proj_id.Value <> Nothing Then
                    SaveDataForClasses(Proj_id.Value)
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "تم الحفظ بنجاح"
                    Button1.Enabled = True
                Else
                    SaveDataForClasses()
                End If
                tbldoc1.Visible = True
                Table1.Visible = True
                BtnSave.Visible = False
                Quarter.Enabled = True
                Quarter_year.Enabled = True
                Check()
            End If
        ElseIf BtnSave.CommandArgument = "edit" Then
            If Valid() Then
                SaveDataForClasses(Proj_id.Value)
                lblPageStatus.Visible = True
                Button1.Enabled = True
                btnpartfinance.Enabled = True
                BtnSave.Visible = True
                Check()
            End If
        ElseIf Request.QueryString("Editp") <> Nothing Then
            Dim id As Integer
            id = Request.QueryString("Editp")
            UpdateData()
            Check()
            CheckListControls()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "تم التعديل بنجاح"


        ElseIf BtnSave.CommandArgument = "delete" Then
            Try
                Dim str1 As String = ""
                str1 = " delete  from projects_documents where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Project_Distrebition where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Notes where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Poject_status where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Project_Objective where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Project_Organization where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Project_Period_Balance where Proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete from Project_Team where proj_proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Project_Period_Source_Total where Proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Event where ProjID= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Inbox where ProjID= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Meetings where ProjID= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Outbox where ProjID= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                str1 = " delete  from Presentation where ProjID= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                Dim sql_act As String = " select Project_Activities.* from Project_Activities where proj_proj_id= " & Proj_id.Value
                Dim dt_act As DataTable = General_Helping.GetDataTable(sql_act)
                If dt_act.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For Each row_act As DataRow In dt_act.Rows
                        str1 = " delete  from Activity_sitiuation where project_activity_FK= " & dt_act.Rows(i)("PActv_ID")
                        General_Helping.ExcuteQuery(str1)
                        str1 = " delete  from Project_Activities_Budgets where pactv_pactv_id= " & dt_act.Rows(i)("PActv_ID")
                        General_Helping.ExcuteQuery(str1)
                        str1 = " delete  from Project_Activities_gov where activity_id= " & dt_act.Rows(i)("PActv_ID")
                        General_Helping.ExcuteQuery(str1)
                        str1 = " delete  from Project_Activities_Indicators where pactv_pactv_id= " & dt_act.Rows(i)("PActv_ID")
                        General_Helping.ExcuteQuery(str1)
                        str1 = " delete  from Project_Constraints where PActv_PActv_ID= " & dt_act.Rows(i)("PActv_ID")
                        General_Helping.ExcuteQuery(str1)
                        i += 1
                    Next
                    str1 = " delete  from Project_Activities where proj_proj_id= " & Proj_id.Value
                    General_Helping.ExcuteQuery(str1)
                End If


                Dim sql_ned As String = " select Project_Needs.* from Project_Needs where proj_proj_id= " & Proj_id.Value
                Dim dt_ned As DataTable = General_Helping.GetDataTable(sql_ned)
                If dt_ned.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For Each row_act As DataRow In dt_ned.Rows
                        str1 = " delete  from Need_Availble where PNed_PNed_Id= " & dt_ned.Rows(i)("PNed_ID")
                        General_Helping.ExcuteQuery(str1)
                        str1 = " delete  from Need_Recieve where pned_pned_id= " & dt_ned.Rows(i)("PNed_ID")
                        General_Helping.ExcuteQuery(str1)
                        i += 1
                    Next
                    str1 = " delete  from Project_Needs where proj_proj_id= " & Proj_id.Value
                    General_Helping.ExcuteQuery(str1)
                End If
                str1 = " delete from project where proj_id= " & Proj_id.Value
                General_Helping.ExcuteQuery(str1)
                'lblPageStatus.Visible = True
                'lblPageStatus.Text = " تم الحذف بنجاح"
                System.Windows.Forms.MessageBox.Show("تم الحذف بنجاح")
                Response.Redirect("~/WebForms2/default.aspx")



            Catch ex As Exception
                lblPageStatus.Visible = True
                lblPageStatus.Text = "عفوا لايمكن الحذف"
            End Try
        End If
        tblfinance.Visible = True
        tbldoc1.Visible = True


    End Sub
    Protected Sub another_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnother.Click
        Proj_id.Value = Nothing
        btnAnother.Visible = False
        GView.Enabled = True
        BtnSave.Visible = True
        dimmed()
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        tblfinance.Visible = True
        tbldoc1.Visible = True
        Table1.Visible = True
        BtnSave.Visible = True
    End Sub

    Protected Sub Doc_ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        PDOC_id.Value = CType(sender, ImageButton).CommandArgument
        BtnDocUpload.Text = "تعديل وثيقة"
        BtnSave.Visible = False
        PDOC_id.Value = CType(sender.parent.parent.FindControl("PDOC_id"), HtmlControls.HtmlInputHidden).Value
        Dim str1 As String = ""
        Dim dt1 As New DataTable
        str1 = " select File_name,File_ID,File_data from Departments_Documents where File_ID = " & PDOC_id.Value
        dt1 = General_Helping.GetDataTable(str1)
        If Not dt1.Rows(0)("File_name") Is DBNull.Value Then
            txtDocName.Text = dt1.Rows(0)("File_name")
        End If
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In GView.Rows
            If CType(GView.Rows(i).FindControl("PDOC_id"), HtmlControls.HtmlInputHidden).Value = PDOC_id.Value Then
                id = i
            Else
                GView.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next

        GView.Rows(id).BackColor = Drawing.Color.Lavender

    End Sub

    Protected Sub Doc_ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        PDOC_id.Value = CType(sender, ImageButton).CommandArgument
        General_Helping.ExcuteQuery("delete from Departments_Documents where File_ID=" & PDOC_id.Value)
        Dim str As String = ""
        str = " select File_name ,File_ID from Departments_Documents where parent_id <> 0 and Proj_Proj_id= " & Proj_id.Value
        GView.DataSource = General_Helping.GetDataTable(str)
        GView.DataBind()

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
        '    endperiod.Text = dt1.Rows(0)("End_Date")
        'End If
        'If Not dt1.Rows(0)("int_Init_Value") Is DBNull.Value Then
        '    txtpartamount.Text = dt1.Rows(0)("int_Init_Value")
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
        'If lblID.Text <> "" Then
        '    Proj_id.Value = lblID.Text
        'End If
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

        If _dt.Rows(0)("proj_sug_type") <> "0" Then
            DDLSuggestType.SelectedValue = _dt.Rows(0)("proj_sug_type")
        End If

        'Proj_id.Value = CType(sender, ImageButton).CommandArgument
        Dim str As String
        str = " select PDOC_FileName ,PDOC_ID from projects_documents where Proj_Proj_id= " & CType(sender, ImageButton).CommandArgument
        GView.DataSource = General_Helping.GetDataTable(str)
        GView.DataBind()


        BtnSave.Text = "تعديــــل"
        lblPageStatus.Text = ""
    End Sub

    Public Function Check() As Boolean
        If CDataConverter.ConvertToInt(Proj_id.Value) > 0 Then

            BtnSend.Enabled = True
            btnpartfinance.Enabled = True
            BtnDocUpload.Enabled = True
            BtnSaveGoal.Enabled = True
            Button1.Enabled = True

        Else
            btnpartfinance.Enabled = False
            BtnSend.Enabled = False
            BtnDocUpload.Enabled = False
            BtnSaveGoal.Enabled = False
            Button1.Enabled = True
        End If
        Return True

    End Function


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
        Try
            If CDataConverter.ConvertToInt(Proj_id.Value) > 0 Then

                If CDataConverter.ConvertToInt(PDOC_id.Value) = 0 Then

                    Dim myStream As System.IO.Stream
                    Dim fileLen As Integer
                    Dim displayString As New StringBuilder()


                    Dim DocName As String
                    Dim type As String
                    If (DocUpload.HasFile = True) Then

                        fileLen = DocUpload.PostedFile.ContentLength
                        DocName = DocUpload.FileName
                        Dim Input(fileLen) As Byte
                        myStream = DocUpload.FileContent
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
                        cmd.CommandText = " insert into Departments_Documents (File_data,File_name,File_ext,Proj_Proj_id,Parent_ID) VALUES (@File_data,@File_name,@File_ext,@Proj_Proj_id,@Parent_ID)"
                        cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                        cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
                        cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 50)
                        cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)
                        cmd.Parameters.Add("@Parent_ID", SqlDbType.Int)
                        cmd.Parameters("@File_data").Value = Input
                        cmd.Parameters("@File_name").Value = txtDocName.Text
                        cmd.Parameters("@File_ext").Value = type
                        cmd.Parameters("@Proj_Proj_id").Value = Proj_id.Value
                        Dim file_id As DataTable
                        Dim id As Integer
                        file_id = General_Helping.GetDataTable("select File_ID,File_name,Parent_ID,Proj_Proj_id from Departments_Documents where Proj_Proj_id=" & Proj_id.Value)
                        If (file_id.Rows.Count > 0) Then
                            id = file_id.Rows(0)("File_ID")
                        End If

                        cmd.Parameters("@Parent_ID").Value = id
                        'Response.Write(cmd)
                        cmd.ExecuteNonQuery()
                    End If

                ElseIf CDataConverter.ConvertToInt(PDOC_id.Value) > 0 Then

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
                        cmd.CommandText = " update Departments_Documents set File_data= @File_data ,File_name =@File_name,File_ext=@File_ext,Proj_Proj_id =@Proj_Proj_id where File_ID=" & PDOC_id.Value
                        cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                        cmd.Parameters.Add("@File_Name", SqlDbType.NVarChar, 250)
                        cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 50)
                        cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)
                        ' cmd.Parameters.Add("@Parent_ID", SqlDbType.Int)


                        cmd.Parameters("@File_data").Value = Input
                        cmd.Parameters("@File_ext").Value = type
                        cmd.Parameters("@File_name").Value = txtDocName.Text
                        cmd.Parameters("@Proj_Proj_id").Value = Proj_id.Value
                        Dim file_id As DataTable
                        Dim id As Integer
                        file_id = General_Helping.GetDataTable("select File_ID,File_name,Parent_ID,Proj_Proj_id from Departments_Documents where Proj_Proj_id=" & Proj_id.Value)
                        If (file_id.Rows.Count > 0) Then
                            id = file_id.Rows(0)("File_ID")
                        End If
                        'cmd.Parameters("@Parent_ID").Value = id
                        ' Response.Write(cmd)
                        cmd.ExecuteNonQuery()

                    Else
                        Dim Sql As String = "update Departments_Documents set  File_name = '" & txtDocName.Text & "' where File_ID=" & PDOC_id.Value
                        General_Helping.ExcuteQuery(Sql)
                    End If

                End If
            End If

        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub


#End Region

    Private Sub SaveGoals(Optional ByVal ID As Integer = 0)

        Try
            If CDataConverter.ConvertToInt(Proj_id.Value) > 0 Then
                If CDataConverter.ConvertToInt(PObj_ID.Value) = 0 Then

                    Dim Project_Objective_ENTITY As New BLL.Project_Objective()
                    Project_Objective_ENTITY.Proj_Proj_Id = Proj_id.Value
                    Project_Objective_ENTITY.Pobj_Desc = txtProjObjective.Text
                    Project_Objective_ENTITY.Pobj_Num = -1
                    Project_Objective_ENTITY.Save()
                    'Dim dt As DataTable
                    'dt = General_Helping.GetDataTable("select count(pobj_id) as CC from project_objective where Proj_Proj_Id=" & General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id"))
                    'Dim x As Integer = dt.Rows(0)("CC")
                    'General_Helping.ExcuteQuery("update project_objective set pobj_num =" & x & " where Pobj_Num = -1")
                    'FillGridGoals()
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "تم الحفظ بنجاح"
                Else

                    Dim Project_Objective_ENTITY As New BLL.Project_Objective(PObj_ID.Value)
                    'Project_Objective_ENTITY.Pobj_Id = PObj_ID.Value
                    Project_Objective_ENTITY.Proj_Proj_Id = Proj_id.Value
                    Project_Objective_ENTITY.Pobj_Desc = txtProjObjective.Text
                    Project_Objective_ENTITY.Pobj_Num = -1
                    Project_Objective_ENTITY.Save()
                    'FillGridGoals()
                    BtnSaveGoal.CommandArgument = "new"
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = " تم التعديل بنجاح"
                End If
                'FillGridGoals()
                BtnSaveGoal.Text = "حفــــــظ"
                'Clear()
                txtProjObjective.Text = ""
                PObj_ID.Value = ""


            Else
                lblPageStatus.Visible = True
                lblPageStatus.Text = "يجب إدخال بيانات تفاصيل المشروع الرئيسية أولا"
            End If
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub
#Region "Fills"
    Private Sub FillGridGoals(Optional ByVal ID As Integer = 0)
        ID = 0
        Dim sql As String = ""

        Dim _dt As New DataTable
        sql = "select Project_Objective.* from Project_Objective join project on Project_Objective.proj_proj_id = Project.proj_id" _
            & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where" _
            & " proj_proj_id=" & Proj_id.Value _
            & " order by PObj_ID desc"
        _dt = General_Helping.GetDataTable(sql)
        GridGoals.DataSource = _dt
        GridGoals.DataBind()
    End Sub


#End Region

    '''Added by Noura '''''
#Region "RetriveData"

    Public Sub Retrive()
        ''''''''''''''''''Goals''''''''''''''''''''''''''''
        'First line\r\nSecond line'

        Dim id As Integer = Request("Editp").ToString()
        Dim sqlGoal As String
        Dim dt As DataTable
        sqlGoal = "select Project_Objective.* from Project_Objective join project on Project_Objective.proj_proj_id = Project.proj_id" _
              & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where" _
              & " proj_proj_id=" & id _
              & " order by pobj_num"
        dt = General_Helping.GetDataTable(sqlGoal)
        GridGoals.DataSource = dt
        GridGoals.DataBind()
        ''''''''''''''''''Documents''''''''''''''''''''''''
        Dim dt1 As New DataTable
        ''Dim _dt As New DataTable
        dt1 = General_Helping.GetDataTable("select File_name,File_ID from Departments_Documents where parent_id <> 0 and Proj_Proj_id=" & Proj_id.Value & "order by File_ID")

        GView.DataSource = dt1
        GView.DataBind()
        GView.Visible = True
        txtDocName.Text = ""
        ''''''''''''''''''Main'''''''''''''''''''''''''''''
        tblnew.Visible = True

        GView.Visible = True

        Dim _dt As DataTable = General_Helping.GetDataTable("select * ,prio_prio_id,Proj_InitValue as Proj_InitValue_integer from Project where proj_id= " & id)
        If Not _dt.Rows(0)("Proj_Creation_Date") Is DBNull.Value Then
            txtStartDate.Text = _dt.Rows(0)("Proj_Creation_Date")
        End If
        txtCoast.Text = _dt.Rows(0)("Proj_InitValue_integer")

        Smart_Search_man.SelectedValue = General_Helping.GetDataTable("select Project_team.pmp_pmp_id from  Project join Project_team on proj_proj_id = Proj_id where proj_id = " & id).Rows(0)("pmp_pmp_id")
        txtProjBrief.Text = _dt.Rows(0)("Proj_Brief")
        txtProjTitle.Text = _dt.Rows(0)("Proj_Title")

        If Not _dt.Rows(0)("prio_prio_id") Is DBNull.Value Then
            DDLPriority.SelectedValue = _dt.Rows(0)("prio_prio_id")
        End If

        If _dt.Rows(0)("proj_sug_type") <> "0" Then
            DDLSuggestType.SelectedValue = _dt.Rows(0)("proj_sug_type")
        End If

        ''''' select category '''''
        Dim sql As String
        sql = (" SELECT dbo.Category.proj_category, dbo.Category.id, dbo.Project_Category.proj_category_id, dbo.Project_Category.proj_id" _
        & " FROM dbo.Project_Category INNER JOIN  dbo.Category ON dbo.Project_Category.proj_category_id = dbo.Category.id" _
        & " where dbo.Project_Category.proj_id= " & id)
        _dt = General_Helping.GetDataTable(sql)
        If _dt.Rows.Count > 0 Then
            For Each DR As DataRow In _dt.Rows
                Dim Value As String = DR("id").ToString()
                Dim item As ListItem = CheckCategory.Items.FindByValue(Value)
                If Not item Is Nothing Then
                    item.Selected = True
                End If
            Next
        End If

        ''''' select technique '''''''
        Dim sql1 As String
        Dim _dt1 As DataTable
        sql1 = (" SELECT dbo.Technique.technique, dbo.Technique.id, dbo.Project_Technique.technique_id, dbo.Project_Technique.proj_id" _
        & " FROM dbo.Project_Technique INNER JOIN  dbo.Technique ON dbo.Project_Technique.technique_id = dbo.Technique.id" _
        & " where dbo.Project_Technique.proj_id= " & id)
        _dt1 = General_Helping.GetDataTable(sql1)
        If _dt1.Rows.Count > 0 Then
            For Each DR As DataRow In _dt1.Rows
                Dim Value As String = DR("id").ToString()
                Dim item As ListItem = CheckTechnique.Items.FindByValue(Value)
                If Not item Is Nothing Then
                    item.Selected = True
                End If
            Next
        End If
        '''''''''''''''''''''''''''''''
    End Sub
#End Region

    Private Sub UpdateData()
        If Request.QueryString("Editp") <> Nothing Then
            Dim id As Integer
            Dim validated_date As String
            id = Request.QueryString("Editp").ToString()
            'Dim Project_Team_ENTITY As New BLL.Project_Team()
            'Project_Team_ENTITY.Proj_Proj_Id = General_Helping.GetDataTable("select max(proj_id)proj_id from Project").Rows(0)("proj_id")
            'Project_Team_ENTITY.Rol_Rol_Id = 4
            'Project_Team_ENTITY.Ptem_Name = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " & Smart_Search_man.SelectedValue).Rows(0)("pmp_name")
            'Project_Team_ENTITY.Ptem_Task = "مدير المشروع"
            'Project_Team_ENTITY.Ptem_Task_Cat = "مدير المشروع"
            'Project_Team_ENTITY.Pmp_Pmp_Id = Smart_Search_man.SelectedValue
            'Project_Team_ENTITY.Job_Job_Id = 4
            'Project_Team_ENTITY.Save()

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
            ' If txtProjTitle.Text <> "" Then
            Dim str As String

            str = General_Helping.ExcuteQuery("update project set Proj_Title = '" & txtProjTitle.Text & "', Proj_Brief = '" & txtProjBrief.Text & "' , Proj_Initvalue =  " & Decimal.Parse(txtCoast.Text) & ",Proj_Creation_Date = '" & validated_date & "',Pmp_Pmp_Id = " & Smart_Search_man.SelectedValue & " , Dept_Dept_Id=" & Session_CS.dept_id & ", proj_is_commit = 6 , proj_is_refused = 0 , proj_is_repeated = 0,Balance_Suggest_Initial =  " & Decimal.Parse(txtCoast.Text) & " where Proj_id=" & id)
            'End If
            If DDLPriority.SelectedIndex <> 0 Then
                General_Helping.ExcuteQuery("update project set prio_prio_id = " & DDLPriority.SelectedValue & " where proj_id = " & id)
            Else
                General_Helping.ExcuteQuery("update project set prio_prio_id = " & 3 & " where proj_id = " & id)
            End If

            If DDLSuggestType.SelectedIndex <> 0 Then
                General_Helping.ExcuteQuery("update project set proj_sug_type = " & DDLSuggestType.SelectedValue & " where proj_id = " & id)
            Else
                General_Helping.ExcuteQuery("update project set proj_sug_type = " & 0 & " where proj_id = " & id)
            End If


        End If
    End Sub
    Protected Sub ImgBtnGoalEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSaveGoal.CommandArgument = "edit"

        Dim _dt As New DataTable

        _dt = Project_Obj_ENTITY.Get(CType(sender, ImageButton).CommandArgument)
        txtProjObjective.Text = _dt.Rows(0)("PObj_Desc")
        PObj_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In GridGoals.Rows
            If CType(GridGoals.Rows(i).FindControl("PObj_ID_For_Grid"), HtmlControls.HtmlInputHidden).Value = PObj_ID.Value Then
                id = i
            Else
                GridGoals.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next
        GridGoals.Rows(id).BackColor = Drawing.Color.Lavender
        ' BtnSave.Text = "تعديــــل"
        'lblPageStatus.Text = "" 
    End Sub

    Protected Sub ImgBtnGoalDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Project_Objective_ENTITY As New BLL.Project_Objective(CType(sender, ImageButton).CommandArgument)

            Project_Objective_ENTITY.Delete()
            Dim Sql As String = "update project_objective set pobj_num=pobj_num - " & 1 & " where proj_proj_id = " & (CType(sender, ImageButton).CommandArgument)
            General_Helping.ExcuteQuery(Sql)
            FillGridGoals()
            'lblPageStatus.Visible = True
            'lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub
    Private Sub CheckListControls()

        ''''''''''''''' Category  ''''''''''''
        Dim dt As DataTable
        Dim id As Integer
        If Request.QueryString("Editp") <> Nothing Then
            id = Request.QueryString("Editp").ToString()
        Else
            id = Proj_id.Value
        End If
        If CheckCategory.SelectedValue > "0" Then
            dt = General_Helping.GetDataTable("select * from Project_Category where proj_id= " & id)
            If dt.Rows.Count > 0 Then
                General_Helping.ExcuteQuery("delete from Project_Category where proj_id= " & id)
                For Each li As ListItem In CheckCategory.Items
                    If (li.Selected) Then

                        General_Helping.ExcuteQuery("insert into Project_Category (proj_id, proj_category_id) values ( " & id & "," & li.Value & ")")
                    End If
                Next
            Else
                For Each li As ListItem In CheckCategory.Items
                    If (li.Selected) Then
                        General_Helping.ExcuteQuery("insert into Project_Category (proj_id, proj_category_id) values ( " & id & "," & li.Value & ")")

                    End If
                Next
            End If


            '''''' ''''''' Technique  ''''''''''''''''''''''
            If CheckTechnique.SelectedValue > "0" Then
                ' id = General_Helping.ExcuteQuery("select max(proj_id)proj_id from Project")
                dt = General_Helping.GetDataTable("select * from Project_Technique where proj_id= " & id)
                If dt.Rows.Count > 0 Then
                    General_Helping.ExcuteQuery("delete from Project_Technique where proj_id= " & id)
                    For Each li As ListItem In CheckTechnique.Items
                        If (li.Selected) Then
                            General_Helping.ExcuteQuery("insert into Project_Technique (proj_id, technique_id) values (" & id & "," & li.Value & ")")

                        End If
                    Next
                Else
                    For Each li As ListItem In CheckTechnique.Items
                        If (li.Selected) Then
                            General_Helping.ExcuteQuery("insert into Project_Technique (proj_id, technique_id) values (" & id & "," & li.Value & ")")

                        End If
                    Next
                End If
            End If
        End If
    End Sub
    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try

            Dim str As String = ""
            str = " delete  from Departments_Documents where proj_proj_id= " & CType(sender, ImageButton).CommandArgument
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


        'If date_validate(txtStartDate.Text) <> "" Then
        '    txtStartDate.Text = date_validate(txtStartDate.Text)


        If txtStartDate.Text <> "" Then
            txtStartDate.Text = txtStartDate.Text

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

        dt1 = General_Helping.GetDataTable("select File_name,File_ID from Departments_Documents where Proj_Proj_id=" & Proj_id.Value & "order by File_ID")
        GView.DataSource = dt1
        GView.DataBind()
        GView.Visible = True
        txtDocName.Text = ""
    End Sub

    Protected Sub BtnDocUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDocUpload.Click
        Try
            If CDataConverter.ConvertToInt(Proj_id.Value) > 0 Then
                If CDataConverter.ConvertToInt(PDOC_id.Value) = 0 Then
                    Dim dt As New DataTable
                    If txtDocName.Text <> "" Then
                        DisplayFileContents(DocUpload.PostedFile)
                        dt = General_Helping.GetDataTable("select File_name,File_ID from Departments_Documents where parent_id <> 0 and Proj_Proj_id=" & Integer.Parse(Proj_id.Value))
                        If dt.Rows.Count > 0 Then
                            GView.DataSource = dt
                            GView.DataBind()
                            GView.Visible = True
                            txtDocName.Text = ""
                        End If
                    End If


                Else
                    Dim dt1 As New DataTable
                    If txtDocName.Text <> "" Then
                        DisplayFileContents(DocUpload.PostedFile)
                        dt1 = General_Helping.GetDataTable("select File_name,File_ID from Departments_Documents where parent_id <> 0 and Proj_Proj_id=" & Integer.Parse(Proj_id.Value))
                        If dt1.Rows.Count > 0 Then
                            GView.DataSource = dt1
                            GView.DataBind()
                            GView.Visible = True
                            txtDocName.Text = ""
                        End If
                    End If
                End If
            Else
                lblPageStatus.Visible = True
                lblPageStatus.Text = "يجب إدخال بيانات تفاصيل المشروع الرئيسية أولا"
            End If

        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
        lblPageStatus.Visible = True
        lblPageStatus.Text = ""
        BtnDocUpload.Text = "تحميل وثيقة"
        BtnSave.Visible = True
        'BtnSend.Visible = True
        'PDOC_id1.Value = Nothing
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
                    General_Helping.ExcuteQuery("insert into Project_Period_Sources (Period_ID,Sources_ID,Value) values (-1," & hField.Value & "," & Int64.Parse(cb.Text) & ")")
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
                    General_Helping.ExcuteQuery("insert into Project_Period_Source_Total (Proj_id,Sources_ID,Strt_Date,End_Date,Total_Value) values (" & Proj_id.Value & "," & hField.Value & ",'" & "01/07" & "/" & Quarter_year.SelectedValue & "','" & "30/06" & "/" & Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString() & "'," & Int64.Parse(cb.Text) & ")")
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
                    General_Helping.ExcuteQuery("insert into Project_Period_Sources (Period_ID,Sources_ID,Value) values (-1," & hField.Value & "," & Int64.Parse(cb.Text) & ")")
                    General_Helping.ExcuteQuery("insert into Project_Period_Source_Total (Proj_id,Sources_ID,Strt_Date,End_Date,Total_Value) values (" & Proj_id.Value & "," & hField.Value & ",'" & "01/07" & "/" & Quarter_year.SelectedValue & "','" & "30/06" & "/" & Convert.ToInt16(Quarter_year.SelectedValue + 1).ToString() & "'," & Int64.Parse(cb.Text) & ")")
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


    Protected Sub BtnSaveGoal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveGoal.Click

        SaveGoals()
        FillGridGoals()

    End Sub

    Protected Sub BtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        Dim sql As String
        Dim sql2 As String
        Dim dt As DataTable
        Dim dt2 As DataTable
        sql = "select * from Project_Objective where proj_proj_id=" & Proj_id.Value
        sql2 = "select * from Departments_Documents where proj_proj_id= " & Proj_id.Value
        dt = General_Helping.GetDataTable(sql)
        dt2 = General_Helping.GetDataTable(sql2)
        If (dt.Rows.Count > 0) Then
            If (dt2.Rows.Count > 0) Then
                General_Helping.ExcuteQuery(" update Project set Proj_is_commit = 1 , proj_is_refused = 0 , proj_is_repeated = 0 where proj_id=" & Proj_id.Value)
                lblPageStatus.Visible = True
                lblPageStatus.Text = "لقد تم الإرسال بنجاح"
            End If
        Else
            lblPageStatus.Visible = True
            lblPageStatus.Text = "يجب إدخال أهداف المشروع ووثيقة المشروع قبل الإرسال"

        End If


    End Sub
End Class
