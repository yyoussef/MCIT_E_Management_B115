Imports System.Data
Partial Class UserControls_Project_Objective
    Inherits System.Web.UI.UserControl
#Region "Variables"
    Dim Project_Obj_ENTITY As New BLL.Project_Objective
    Dim Session_CS As New Session_CS
#End Region

#Region "Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillGrid()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        txtProjObjective.Text = ""

    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtProjObjective.Text = "" Then
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
        Dim sql As String = ""
        Dim test As Integer = Session_CS.Project_id
        Dim _dt As New DataTable
        sql = "select Project_Objective.* from Project_Objective join project on Project_Objective.proj_proj_id = Project.proj_id" _
            & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where" _
            & " proj_proj_id=" & Session_CS.Project_id _
            & " order by pobj_num"
        _dt = General_Helping.GetDataTable(sql)
        gvMain.DataSource = _dt
        gvMain.DataBind()
    End Sub


#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then

                Dim Project_Objective_ENTITY As New BLL.Project_Objective()
                Project_Objective_ENTITY.Proj_Proj_Id = Session_CS.Project_id
                Project_Objective_ENTITY.Pobj_Desc = txtProjObjective.Text
                Project_Objective_ENTITY.Pobj_Num = -1
                Project_Objective_ENTITY.Save()
                Dim dt As DataTable
                dt = General_Helping.GetDataTable("select count(pobj_id) as CC from project_objective where Proj_Proj_Id=" & Session_CS.Project_id)
                Dim x As Integer = dt.Rows(0)("CC")
                General_Helping.ExcuteQuery("update project_objective set pobj_num =" & x & " where Pobj_Num = -1")

                FillGrid()
                'lblPageStatus.Visible = True
                'lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                Dim Project_Objective_ENTITY As New BLL.Project_Objective(ID)
                Project_Objective_ENTITY.Proj_Proj_Id = Session_CS.Project_id
                Project_Objective_ENTITY.Pobj_Desc = txtProjObjective.Text
                Project_Objective_ENTITY.Pobj_Num = Project_Objective_ENTITY.Pobj_Num
                Project_Objective_ENTITY.Save()
                FillGrid()
                BtnSave.CommandArgument = "new"
                'lblPageStatus.Visible = True
                'lblPageStatus.Text = "تم التعديل بنجاح"
            End If
            FillGrid()
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
                SaveDataForClasses(PObj_id.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"

        Dim _dt As New DataTable

        _dt = Project_Obj_ENTITY.Get(CType(sender, ImageButton).CommandArgument)
        txtProjObjective.Text = _dt.Rows(0)("PObj_Desc")
        PObj_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("PObj_ID"), HtmlControls.HtmlInputHidden).Value = PObj_ID.Value Then
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
            Dim Project_Objective_ENTITY As New BLL.Project_Objective(CType(sender, ImageButton).CommandArgument)
            Project_Objective_ENTITY.Delete()
            Dim Sql As String = "update project_objective set pobj_num=pobj_num - " & 1 & " where PObj_ID >" & CType(sender, ImageButton).CommandArgument & " and proj_proj_id = " & Session_CS.Project_id
            General_Helping.ExcuteQuery(Sql)
            FillGrid()
            'lblPageStatus.Visible = True
            'lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    ' Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
    '    DBL.Helper.MergeRows(ReorderListveiw)
    'End Sub
#End Region
End Class
