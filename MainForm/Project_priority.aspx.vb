Imports System.Data

Partial Class WebForms_Project_priority
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS


#Region "Variables"

    Dim Project_ENTITY As New BLL.Project
    Dim Obj_General_Helping As New General_Helping
    Dim sql_Connection As String = DBL.Universal.GetConnectionString()
#End Region

#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)



        Smart_Search_pr.sql_Connection = sql_Connection
        Smart_Search_pr.Text_Field = "Proj_Title "
        Smart_Search_pr.Value_Field = "Proj_id "
        Dim Query As String = "select Proj_id ,Proj_Title from Project"
        Smart_Search_pr.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_pr.DataBind()


     
        MyBase.OnInitComplete(e)
      
       
    End Sub

#End Region

#Region "Load"
    Protected Sub Team_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillDDls()
            FillGrid()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        'DDLprojects.SelectedValue = "...اختر مشروع..."
        DDLPriority.SelectedValue = "....اختر أولويه....."

        Smart_Search_pr.Clear_Controls()
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If String.IsNullOrEmpty(Smart_Search_pr.SelectedValue) Or DDLPriority.SelectedValue = "....اختر أولويه....." Then
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
            sql = "select Project.* ,prio_desc from Project" _
                & " join priorities on Prio_prio_id = Prio_id" _
                & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where EMPLOYEE.PMP_ID = " & Session_CS.pmp_id _
                & " and Project.Dept_Dept_id=" & Session_CS.dept_id _
                & " order by prio_prio_id,Proj_id"
            _dt = General_Helping.GetDataTable(sql)
            gvMain.Visible = True
            gvMain.DataSource = _dt
            gvMain.DataBind()
        End If
    End Sub

    Private Sub FillDDls()
        Dim dt As New DataTable
        'If Not Session_CS.pmp_id Is Nothing Then

        'End If
        'dt = General_Helping.GetDataTable("select proj_id,proj_title from project join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where EMPLOYEE.PMP_ID = " & Session_CS.pmp_id)
        'Obj_General_Helping.SmartBindDDL(DDLprojects, dt, "proj_id", "proj_title", "...اختر مشروع...")

        dt = General_Helping.GetDataTable("select prio_id,prio_desc from priorities")
        Obj_General_Helping.SmartBindDDL(DDLPriority, dt, "prio_id", "prio_desc", "....اختر أولويه.....")
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then
                General_Helping.ExcuteQuery("update project set prio_prio_id = " & DDLPriority.SelectedValue & " where proj_id = " & Smart_Search_pr.SelectedValue)
                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else
                General_Helping.ExcuteQuery("update project set prio_prio_id = " & DDLPriority.SelectedValue & " where proj_id = " & Smart_Search_pr.SelectedValue)
                FillGrid()
                BtnSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
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
                SaveDataForClasses(Proj_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim Project_ENTITY As New BLL.Project(CType(sender, ImageButton).CommandArgument)
        Smart_Search_pr.SelectedValue = Project_ENTITY.Proj_Id
        DDLPriority.SelectedValue = General_Helping.GetDataTable("select prio_prio_id from project where proj_id = " & CType(sender, ImageButton).CommandArgument).Rows(0)("prio_prio_id")
        proj_id.Value = CType(sender, ImageButton).CommandArgument
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Project_ENTITY As New BLL.Project(CType(sender, ImageButton).CommandArgument)
            Project_ENTITY.Delete()
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRows(gvMain)
    End Sub
#End Region

    'Protected Sub DDLprojects_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDLprojects.SelectedIndexChanged
    '    Dim dt As DataTable
    '    dt = General_Helping.GetDataTable("select prio_prio_id from Project where Proj_id=" & DDLprojects.SelectedValue)
    '    If dt.Rows.Count <> 0 Then
    '        DDLPriority.SelectedValue = dt.Rows(0)("prio_prio_id")
    '    End If
    'End Sub
End Class
