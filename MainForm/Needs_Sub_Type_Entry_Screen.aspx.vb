Imports System.Data

Partial Class WebForms_Needs_Sub_Type_Entry_Screen
    Inherits System.Web.UI.Page
    'Session_CS Session_CS

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
        DdlMainTypes.SelectedValue = ""
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtName.Text = "" Or DdlMainTypes.SelectedValue = "" Then
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
        sql = "select Needs_Sup_Type.*,Needs_Main_Type.* from Needs_Sup_Type join Needs_Main_Type on nmt_nmt_id = nmt_id order by nmt_id"
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()
    End Sub

    Private Sub FillDDl()
        Dim sql As String = ""
        sql = "select NMT_ID,NMT_Desc from Needs_Main_Type"
        Dim dt As DataTable = General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(DdlMainTypes, dt, "NMT_ID", "NMT_Desc", "")
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then
                Dim Needs_Sup_Type_ENTITY As New BLL.Needs_Sup_Type()
                Needs_Sup_Type_ENTITY.Nst_Desc = txtName.Text
                Needs_Sup_Type_ENTITY.Nmt_Nmt_Id = DdlMainTypes.SelectedValue
                Needs_Sup_Type_ENTITY.Save()

                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else
                Dim Needs_Sup_Type_ENTITY As New BLL.Needs_Sup_Type(ID)
                Needs_Sup_Type_ENTITY.Nst_Desc = txtName.Text
                Needs_Sup_Type_ENTITY.Nmt_Nmt_Id = DdlMainTypes.SelectedValue
                Needs_Sup_Type_ENTITY.Save()

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
                SaveDataForClasses(NST_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable
        Dim Sql As String = "select * from Needs_Sup_Type nst_id = " & CType(sender, ImageButton).CommandArgument
        _dt = General_Helping.GetDataTable(Sql)
        txtName.Text = _dt.Rows(0)("NST_Desc")
        DdlMainTypes.SelectedValue = _dt.Rows(0)("nmt_nmt_id")

        NST_ID.Value = CType(sender, ImageButton).CommandArgument
        lblPageStatus.Visible = False
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Needs_Sup_Type_ENTITY As New BLL.Needs_Sup_Type(CType(sender, ImageButton).CommandArgument)
            Needs_Sup_Type_ENTITY.Delete()
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