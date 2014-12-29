Imports System.Data

Partial Class WebForms_Main_Needs_Type_Entry_Screen
    Inherits System.Web.UI.Page

#Region "Variables"

#End Region

#Region "Load"
    'Dim rowindeces As New List(Of Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillGrid()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        txtName.Text = ""
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtName.Text = "" Then
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
        sql = "select * from Needs_Main_Type "
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then
                Dim Needs_Main_Type_ENTITY As New BLL.Needs_Main_Type()
                Needs_Main_Type_ENTITY.Nmt_Desc = txtName.Text
                Needs_Main_Type_ENTITY.Save()

                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                Dim Needs_Main_Type_ENTITY As New BLL.Needs_Main_Type(ID)
                Needs_Main_Type_ENTITY.Nmt_Desc = txtName.Text
                Needs_Main_Type_ENTITY.Save()

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
                SaveDataForClasses(NMT_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable
        Dim Sql As String = "select NMT_Desc from Needs_Main_Type where NMT_ID = " & CType(sender, ImageButton).CommandArgument
        _dt = General_Helping.GetDataTable(Sql)
        txtName.Text = _dt.Rows(0)("NMT_Desc")

        NMT_ID.Value = CType(sender, ImageButton).CommandArgument
        lblPageStatus.Visible = False
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Needs_Main_Type_ENTITY As New BLL.Needs_Main_Type(CType(sender, ImageButton).CommandArgument)
            Needs_Main_Type_ENTITY.Delete()
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