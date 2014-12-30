Imports System.Data
Imports MCIT.Web.Data
Imports System.Data.SqlClient
Partial Class UserControls_Project_Team
    Inherits System.Web.UI.UserControl

#Region "Variables"
    Dim Project_Team_ENTITY As New BLL.Project_Team
    ''Session_CS Session_CS
    Dim Obj_General_Helping As New General_Helping
    Dim sql_Connection As String = DBL.Universal.GetConnectionString()
    'Private Obj_Browser_Side As New cBrowser(Me, "select JTIT_ID,JTIT_Desc from job_title where JTIT_ID >" & 5, "الفئه", 4)
    'Private Obj_Sql_Con As New SqlConnection(Database.ConnectionString)
#End Region

#Region "On Init"

    'Protected Sub OnInitComplete(ByVal e As System.EventArgs)

    '    Smart_Search1.sql_Connection = sql_Connection
    '    Smart_Search1.Text_Field = "Rol_Desc "
    '    Smart_Search1.Value_Field = "Rol_ID "
    '    Smart_Search1.Query = "select Rol_ID ,Rol_Desc from Roles where Rol_ID >=" & 5 '& " Order by Rol_ID"
    '    Smart_Search1.DataBind()
    '    Smart_Search2.Text_Field = "pmp_name"
    '    Smart_Search2.Value_Field = "pmp_id  "
    '    Smart_Search2.sql_Connection = sql_Connection
    '    Smart_Search2.Query = "select pmp_id ,pmp_name  from employee"
    '    Smart_Search2.DataBind()

    '    MyClass.OnInitComplete(e)


    'End Sub

#End Region

#Region "event handel"

    'Private Sub MOnMember_Data(ByVal VSender As Object, ByVal VArgs As BrowseDataEventArgs)
    '    DDLJobCat.SelectedValue = VArgs.Item(0).ToString()
    '    job_index_changed()
    '    'DDLJobCat_SelectedIndexChanged(VSender, VArgs.Item(0))
    'End Sub

    Private Sub Smart_Search1_Selected(ByVal Value As String)
        'DDLJobCat.SelectedValue = Value
        'job_index_changed()
        ' Me.DataBind()
        Smart_Search2.Text_Field = "pmp_name"
        Smart_Search2.Value_Field = "pmp_id  "
        Smart_Search2.sql_Connection = sql_Connection
        Dim Query = "select pmp_id ,pmp_name  from employee"
        '& Value '& " order by pmp_id"
        Smart_Search2.datatble = General_Helping.GetDataTable(Query)
        Smart_Search2.DataBind()

        If Smart_Search2.Items_Count = 0 Then
            Smart_Search2.Clear_Controls()
        End If

        'DDLJobCat_SelectedIndexChanged(VSender, VArgs.Item(0))
    End Sub

    Private Sub job_index_changed()
        'If DDLJobCat.SelectedIndex <> 0 Then
        '    Dim dt As New DataTable
        '    dt = General_Helping.GetDataTable("select pmp_id,pmp_name from employee where job_job_id =" & DDLJobCat.SelectedValue)
        '    Obj_General_Helping.SmartBindDDL(DDLEmp, dt, "pmp_id", "pmp_name", "...اختر عضو الفريق...")
        '    DDLEmp.DataBind()
        'Else
        '    DDLEmp.Items.Clear()
        '    DDLEmp.Items.Insert(0, "...اختر عضو الفريق...")
        '    DDLEmp.DataBind()
        'End If
    End Sub

#End Region

#Region "Load"

    Protected Sub Team_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)
            FillDDls()
            FillGrid()
            BtnSave.CommandArgument = "new"

            Smart_Search1.sql_Connection = sql_Connection
            Smart_Search1.Text_Field = "Rol_Desc "
            Smart_Search1.Value_Field = "Rol_ID "
            Dim Query = "select Rol_ID ,Rol_Desc from Roles where Rol_ID >=" & 5 '& " Order by Rol_ID"
            Smart_Search1.datatble = General_Helping.GetDataTable(Query)
            Smart_Search1.DataBind()
            Smart_Search2.Text_Field = "pmp_name"
            Smart_Search2.Value_Field = "pmp_id  "
            Smart_Search2.sql_Connection = sql_Connection
            Dim Query2 = "select pmp_id ,pmp_name  from employee"
            Smart_Search2.datatble = General_Helping.GetDataTable(Query2)
            Smart_Search2.DataBind()

        End If
    End Sub

#End Region

#Region "Clear"
    Private Sub Clear()
        'DDLEmp.SelectedValue = "...اختر عضو الفريق..."
        'DDLJobCat.SelectedValue = "....اختار الفئه....."
        ddlrol.SelectedValue = ".... اختار الصفه بالمشروع..... "
        txtrole.Text = ""
        chk_Edit_Project.Checked = False
        Smart_Search2.SelectedValue = "0"
        Smart_Search1.SelectedValue = "0"
        'Smart_Search2.Clear_Controls()
        'Smart_Search1.Clear_Controls()
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If String.IsNullOrEmpty(Smart_Search1.SelectedValue) Or String.IsNullOrEmpty(Smart_Search2.SelectedValue) Or ddlrol.SelectedValue = ".... اختار الصفه بالمشروع..... " Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا يجب ادخال البيانات كاملة اولا"
            Return False
        Else
            lblPageStatus.Visible = False
            Return True
        End If
    End Function
#End Region

#Region "Fills"
    Private Sub FillGrid(Optional ByVal proj_id As Integer = 0)
        Dim sql As String = ""
        Dim _dt As New DataTable
        If Session_CS.pmp_id > 0 Then
            sql = " SELECT     Project_Team.PTem_ID, Project_Team.PTem_Name, Project_Team.PTem_Task_Cat, Project_Team.PTem_Task, Project_Team.rol_rol_id, Project_Team.proj_proj_id,  " _
                & " Project_Team.pmp_pmp_id, Project_Team.job_job_id, Project_Team.Edit_Project, JOB_TITLE.JTIT_Desc, Roles.Rol_Desc, EMPLOYEE.pmp_name " _
                & " FROM         Project_Team INNER JOIN                       Project ON Project_Team.proj_proj_id = Project.Proj_id INNER JOIN                       EMPLOYEE ON Project_Team.pmp_pmp_id = EMPLOYEE.PMP_ID INNER JOIN " _
                & " JOB_TITLE ON Project_Team.job_job_id = JOB_TITLE.JTIT_ID LEFT OUTER JOIN                      Roles ON Project_Team.rol_rol_id = Roles.Rol_ID " _
                & " where  project_team.proj_proj_id = " & Session_CS.Project_id _
                '& " order by rol_Desc"
            _dt = General_Helping.GetDataTable(sql)
            gvMain.Visible = True
            gvMain.DataSource = _dt
            gvMain.DataBind()
        End If
    End Sub

    Private Sub FillDDls()
        Dim dt As New DataTable

        dt = General_Helping.GetDataTable("select JTIT_ID,JTIT_Desc from job_title where JTIT_ID <>" & 4 & " order by JTIT_ID")
        Obj_General_Helping.SmartBindDDL(ddlrol, dt, "JTIT_ID", "JTIT_Desc", ".... اختار الصفه بالمشروع..... ")

        'dt = General_Helping.GetDataTable("select JTIT_ID,JTIT_Desc from job_title where JTIT_ID >" & 5)
        'Obj_General_Helping.SmartBindDDL(DDLJobCat, dt, "JTIT_ID", "JTIT_Desc", "....اختار الفئه.....")
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then

                Dim Project_Team_ENTITY As New BLL.Project_Team()
                Project_Team_ENTITY.Proj_Proj_Id = Session_CS.Project_id
                'Project_Team_ENTITY.Ptem_Name = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " & Smart_Search2.SelectedValue).Rows(0)("pmp_name")
                Project_Team_ENTITY.Pmp_Pmp_Id = Smart_Search2.SelectedValue
                Project_Team_ENTITY.Rol_Rol_Id = Smart_Search1.SelectedValue
                Project_Team_ENTITY.Ptem_Task_Cat = txtrole.Text
                Project_Team_ENTITY.Ptem_Task = txtrole.Text
                Project_Team_ENTITY.Job_Job_Id = ddlrol.SelectedValue
                Project_Team_ENTITY.Edit_Project = chk_Edit_Project.Checked
                Project_Team_ENTITY.Save()

                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                Dim Project_Team_ENTITY As New BLL.Project_Team(ID)
                Project_Team_ENTITY.Proj_Proj_Id = Session_CS.Project_id
                ' Project_Team_ENTITY.Ptem_Name = General_Helping.GetDataTable("select pmp_name from employee where pmp_id = " & Smart_Search2.SelectedValue).Rows(0)("pmp_name")
                Project_Team_ENTITY.Pmp_Pmp_Id = Smart_Search2.SelectedValue
                Project_Team_ENTITY.Rol_Rol_Id = Smart_Search1.SelectedValue
                Project_Team_ENTITY.Ptem_Task_Cat = txtrole.Text
                Project_Team_ENTITY.Ptem_Task = txtrole.Text
                Project_Team_ENTITY.Job_Job_Id = ddlrol.SelectedValue
                Project_Team_ENTITY.Edit_Project = chk_Edit_Project.Checked
                Project_Team_ENTITY.Save()

                FillGrid()
                BtnSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
            End If
            BtnSave.Text = "حفــــــظ"
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
                SaveDataForClasses(PTem_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""
        PTem_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim _dt As New DataTable
        _dt = Project_Team_ENTITY.Get(CType(sender, ImageButton).CommandArgument)
        Smart_Search1.SelectedValue = _dt.Rows(0)("rol_rol_id")
        Smart_Search1_Selected(Smart_Search1.SelectedValue)
        Smart_Search2.SelectedValue = _dt.Rows(0)("pmp_pmp_id")
        'Dim dt As New DataTable
        'dt = General_Helping.GetDataTable("select pmp_id,pmp_name from employee where job_job_id =" & Smart_Search1.SelectedValue)
        'Obj_General_Helping.SmartBindDDL(DDLEmp, dt, "pmp_id", "pmp_name", "...اختر عضو الفريق...")
        'DDLEmp.SelectedValue = General_Helping.GetDataTable("select pmp_pmp_id from Project_Team where PTem_id = " & PTem_ID.Value).Rows(0)("pmp_pmp_id")
        ddlrol.SelectedValue = _dt.Rows(0)("job_job_id")
        txtrole.Text = _dt.Rows(0)("PTem_Task")

        chk_Edit_Project.Checked = _dt.Rows(0)("Edit_Project")
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("PTem_ID"), HtmlControls.HtmlInputHidden).Value = PTem_ID.Value Then
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
            Dim Project_Team_ENTITY As New BLL.Project_Team(CType(sender, ImageButton).CommandArgument)
            Project_Team_ENTITY.Delete()
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        'DBL.Helper.MergeRows(gvMain)
        MergeRows_1cell(gvMain)
    End Sub
    Public Sub MergeRows_1cell(ByVal GridView As GridView)

        If GridView.Rows.Count > 1 Then
            For rowIndex As Integer = GridView.Rows.Count - 2 To rowIndex Step -1
                Dim row As GridViewRow = GridView.Rows(rowIndex)
                Dim previousRow As GridViewRow = GridView.Rows(rowIndex + 1)
                For cellIndex As Integer = 1 To 1
                    If row.Cells(cellIndex).Text = previousRow.Cells(cellIndex).Text Then
                        row.Cells(cellIndex).RowSpan = CInt(IIf(previousRow.Cells(cellIndex).RowSpan < 2, 2, previousRow.Cells(cellIndex).RowSpan + 1))
                        previousRow.Cells(cellIndex).Visible = False
                    End If
                Next
            Next
        End If

    End Sub
#End Region

End Class
