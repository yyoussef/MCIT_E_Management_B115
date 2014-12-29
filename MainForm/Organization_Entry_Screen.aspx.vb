Imports System.Data

Partial Class WebForms_Organization_Entry_Screen
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS

#Region "Variables"
    Dim ORGINIZATION_ENTITY As New BLL.Organization

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
        txt_org_name.Text = ""
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txt_org_name.Text = "" Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
            Return False
        Else
            lblPageStatus.Visible = False
            Return True
        End If
    End Function
#End Region

#Region "fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        Dim _dt As New DataTable

        sql = "select Organization.* from Organization"

        _dt = General_Helping.GetDataTable(sql)
        gvMain.DataSource = _dt
        gvMain.DataBind()
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try

            If ID = 0 Then
                Dim ORGINIZATION_ENTITY As New BLL.Organization
                ORGINIZATION_ENTITY.Org_Desc = txt_org_name.Text
                ORGINIZATION_ENTITY.Save()
                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else
                Dim ORGINIZATION_ENTITY As New BLL.Organization(ID)
                ORGINIZATION_ENTITY.Org_Desc = txt_org_name.Text
                ORGINIZATION_ENTITY.Save()
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
                SaveDataForClasses(Org_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable
        _dt = ORGINIZATION_ENTITY.Get(CType(sender, ImageButton).CommandArgument)
        txt_org_name.Text = _dt.Rows(0)("org_desc")
        Org_ID.Value = CType(sender, ImageButton).CommandArgument

    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim ORGINIZATION_ENTITY As New BLL.Organization(CType(sender, ImageButton).CommandArgument)
            ORGINIZATION_ENTITY.Delete()
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

#End Region

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRows(gvMain)
    End Sub




End Class

