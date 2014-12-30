Imports System.Data

Partial Class WebForms_project_condition
    Inherits System.Web.UI.Page
    'Session_CS Session_CS

    Dim Obj_General_Helping As New General_Helping
    Dim sql_Connection As String = Database.ConnectionString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillDDLs()
        End If
    End Sub
#Region "Fills"
    Private Sub FillDDLs()
        Dim dt As DataTable
        dt = General_Helping.GetDataTable("select proj_id,proj_title from projects")
        'Obj_General_Helping.SmartBindDDL(DDLProjects, dt, "proj_id", "proj_title", "....اختر الاداره.....")

    End Sub
#End Region
End Class
