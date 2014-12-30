Imports System.Data

Partial Class WebForms_project_status
    Inherits System.Web.UI.Page
    'Session_CS Session_CS



#Region "Variables"
    Dim Project_Status_ENTITY As New BLL.Poject_status
    Dim Obj_General_Helping As New General_Helping

#End Region

#Region "Load"
    Protected Sub stat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillDDls()
            FillGrid()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        txtDateStatus.Text = ""
        DDLProjects.SelectedValue = "...أختار مشــــــــــروع..."
        DDLStatus.SelectedValue = "...أختار حالة للمشروع..."
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtDateStatus.Text = "" Or DDLProjects.SelectedValue = "...أختار مشــــــــــروع..." Or DDLStatus.SelectedValue = "...أختار حالة للمشروع..." Then
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
        Dim _dt As New DataTable
        sql = "select Poject_Status.* ,stat_desc, Proj_title from Poject_Status " _
            & " join Project on Proj_proj_id = Proj_id" _
            & " join status on stst_stat_id = stat_id" _
            & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where proj_is_commit = 1"

        _dt = General_Helping.GetDataTable(sql)
        gvMain.DataSource = _dt
        gvMain.DataBind()
    End Sub

    Private Sub FillDDls()
        Dim dt As New DataTable
        If Session_CS.pmp_id > 0 Then
            dt = General_Helping.GetDataTable("select Proj_id,Proj_title from Project join project_Team on project_Team.proj_proj_id = proj_id where proj_is_commit <> 0 and project_Team.pmp_pmp_id = " & Session_CS.pmp_id)
            Obj_General_Helping.SmartBindDDL(DDLProjects, dt, "Proj_id", "Proj_title", "...أختار مشــــــــــروع...")
        End If
        dt = General_Helping.GetDataTable("select Stat_id,Stat_Desc from Status")
        Obj_General_Helping.SmartBindDDL(DDLStatus, dt, "Stat_id", "Stat_Desc", "...أختار حالة للمشروع...")
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then

                Dim Project_Status_ENTITY As New BLL.Poject_status()
                Project_Status_ENTITY.Proj_Proj_Id = DDLProjects.SelectedValue
                Project_Status_ENTITY.Stst_Stat_Id = DDLStatus.SelectedValue
                Project_Status_ENTITY.Pstat_Date = Date.Parse(txtDateStatus.Text)
                Project_Status_ENTITY.Save()

                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                Dim Project_Status_ENTITY As New BLL.Poject_status(ID)
                Project_Status_ENTITY.Proj_Proj_Id = DDLProjects.SelectedValue
                Project_Status_ENTITY.Stst_Stat_Id = DDLStatus.SelectedValue
                Project_Status_ENTITY.Pstat_Date = txtDateStatus.Text
                Project_Status_ENTITY.Save()

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
                SaveDataForClasses(PStat_id.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable

        _dt = Project_Status_ENTITY.Get(CType(sender, ImageButton).CommandArgument)

        DDLProjects.SelectedValue = _dt.Rows(0)("Proj_Proj_id")
        DDLStatus.SelectedValue = _dt.Rows(0)("stst_stat_id")
        txtDateStatus.Text = _dt.Rows(0)("PStat_Date")

        PStat_id.Value = CType(sender, ImageButton).CommandArgument
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Project_Status_ENTITY As New BLL.Poject_status(CType(sender, ImageButton).CommandArgument)
            Project_Status_ENTITY.Delete()
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

End Class


