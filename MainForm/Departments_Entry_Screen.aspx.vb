Imports System.Data

Partial Class WebForms_Departments_Entry_Screen
    Inherits System.Web.UI.Page

#Region "Variables"

    Dim Obj_General_Helping As New General_Helping

#End Region

#Region "Load"
    'Dim rowindeces As New List(Of Integer)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillDDl()
            FillGrid()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        txtName.Text = ""
        DdlDeptType.SelectedValue = ""
        DdlRelatedDepts.SelectedValue = ""
        DdlSectors.SelectedValue = ""
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtName.Text = "" Or DdlDeptType.SelectedValue = "" Or DdlRelatedDepts.SelectedValue = "" Or DdlSectors.SelectedValue = "" Then
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
        sql = "select *,(select dept_name from Departments dept where Depts.Dept_Parent = dept.Dept_ID)Related_dept_name" _
            & " FROM Departments Depts " _
            & " join Department_Type ON Deptt_Deptt_id = Deptt_ID " _
            & " join Sectors ON sec_sec_id = Sectors.Sec_id"
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()
    End Sub

    Private Sub FillDDl()
        Dim sql As String = ""
        sql = "select Deptt_ID,Deptt_Desc from Department_Type"
        Dim dt As DataTable = General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(DdlDeptType, dt, "Deptt_ID", "Deptt_Desc", "")

        sql = "select Dept_ID,Dept_name from Departments"
        dt = General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(DdlRelatedDepts, dt, "Dept_ID", "Dept_name", "")

        sql = "select Sec_id,Sec_name from Sectors"
        dt = General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(DdlSectors, dt, "Sec_id", "Sec_name", "")
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then
                Dim Departments_ENTITY As New BLL.Departments()
                Departments_ENTITY.Dept_Name = txtName.Text
                Departments_ENTITY.Sec_Sec_Id = DdlSectors.SelectedValue
                Departments_ENTITY.Dept_Parent = DdlRelatedDepts.SelectedValue
                Departments_ENTITY.Deptt_Deptt_Id = DdlDeptType.SelectedValue
                Departments_ENTITY.Save()

                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else
                Dim Departments_ENTITY As New BLL.Departments(ID)
                Departments_ENTITY.Dept_Name = txtName.Text
                Departments_ENTITY.Sec_Sec_Id = DdlSectors.SelectedValue
                Departments_ENTITY.Dept_Parent = DdlRelatedDepts.SelectedValue
                Departments_ENTITY.Deptt_Deptt_Id = DdlDeptType.SelectedValue
                Departments_ENTITY.Save()

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
                SaveDataForClasses(Dept_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable

        Dim Sql As String = "select *,(select dept_name from Departments dept where Depts.Dept_Parent = dept.Dept_ID)Related_dept_name" _
                          & " FROM Departments Depts " _
                            & " join Department_Type ON Deptt_Deptt_id = Deptt_ID " _
                            & " join Sectors ON sec_sec_id = Sectors.Sec_id " _
        & " where Dept_ID = " & CType(sender, ImageButton).CommandArgument

        _dt = General_Helping.GetDataTable(Sql)
        txtName.Text = _dt.Rows(0)("Dept_name")
        DdlDeptType.SelectedValue = _dt.Rows(0)("Deptt_ID")
        DdlRelatedDepts.SelectedValue = _dt.Rows(0)("Dept_Parent")
        DdlSectors.SelectedValue = _dt.Rows(0)("Sec_id")

        Dept_ID.Value = CType(sender, ImageButton).CommandArgument
        lblPageStatus.Visible = False
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Departments_ENTITY As New BLL.Departments(CType(sender, ImageButton).CommandArgument)
            Departments_ENTITY.Delete()
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
