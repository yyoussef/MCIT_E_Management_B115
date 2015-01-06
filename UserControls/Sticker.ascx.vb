Imports System.Data

Partial Public Class UserControls_Sticker
    Inherits System.Web.UI.UserControl
    ''Session_CS Session_CS




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Request.QueryString("proj_id") Is Nothing Or CDataConverter.ConvertToInt(Session_CS.Project_id) > 0 Then

                Dim Project_id As String = ""

                If Not Request.QueryString("proj_id") Is Nothing Then
                    Project_id = Request.QueryString("proj_id")
                ElseIf CDataConverter.ConvertToInt(Session_CS.Project_id) > 0 Then
                    Project_id = Session_CS.Project_id
                End If




                If Project_id <> "" Then



                    TblMain.Visible = True
                    Dim sql As String = ""
                    Dim i As Integer = 0
                    sql = " select DISTINCT proj_id ,Proj_Title ,Dept_name,org_desc ,pmp_name ,proj_start_date,Dist_Name,convert(varchar(20), convert(money, Proj_InitValue), 1)as Proj_InitValue_integer,internal_external ,Proj_Creation_Date" _
                        & " FROM Project " _
                        & " left join Departments ON Dept_Dept_id = Dept_ID " _
                        & " left join EMPLOYEE ON pmp_ID = pmp_pmp_id " _
                        & " left join Project_Distrebition ON Proj_id = proj_proj_id " _
                        & " left join Distrebitions on dist_dist_id = Dist_ID " _
                        & " left join project_organization ON Proj_id = project_organization.proj_proj_id and type=1 " _
                        & " left join organization on org_org_id = org_ID  " _
                        & " where proj_id = " & Project_id
                    Dim _dt As DataTable = General_Helping.GetDataTable(sql)
                    If _dt.Rows.Count > 0 Then


                        If Not _dt.Rows(0)("Proj_Title") Is DBNull.Value Then
                            lblProjName.Text = _dt.Rows(0)("Proj_Title")
                        End If
                        If Not _dt.Rows(0)("Dept_name") Is DBNull.Value Then
                            lblDepart.Text = _dt.Rows(0)("Dept_name")
                        End If
                        If Not _dt.Rows(0)("pmp_name") Is DBNull.Value Then
                            lblProjManger.Text = _dt.Rows(0)("pmp_name")
                        End If
                        If Not _dt.Rows(0)("Proj_Creation_Date") Is DBNull.Value Then
                            lblStartDate.Text = _dt.Rows(0)("Proj_Creation_Date")
                        End If
                        If Not _dt.Rows(0)("proj_start_date") Is DBNull.Value Then
                            lblActStartDate.Text = _dt.Rows(0)("proj_start_date")
                        End If
                        If Not _dt.Rows(0)("Proj_InitValue_integer") Is DBNull.Value Then
                            lblCoast.Text = _dt.Rows(0)("Proj_InitValue_integer")
                        End If

                        If Not _dt.Rows(0)("org_desc") Is DBNull.Value Then
                            For Each row As DataRow In _dt.Rows
                                If i = 0 Then
                                    lblUsesDest.Text = row("org_desc")
                                Else
                                    lblUsesDest.Text = lblUsesDest.Text + " , " + row("org_desc")
                                End If
                                i += 1
                            Next
                        End If
                        If Not _dt.Rows(0)("Dist_Name") Is DBNull.Value Then
                            For Each row As DataRow In _dt.Rows
                                If i = 0 Then
                                    lblExeDest.Text = row("Dist_Name")
                                Else
                                    lblExeDest.Text = lblExeDest.Text + " , " + row("Dist_Name")
                                End If
                                i += 1
                            Next
                        End If

                        If Not _dt.Rows(0)("internal_external") Is DBNull.Value Then
                            If _dt.Rows(0)("internal_external") = 1 Then
                                lblproject_type.Text = "داخلي"
                            ElseIf _dt.Rows(0)("internal_external") = 2 Then
                                lblproject_type.Text = "خارجي"
                            End If
                        Else
                            lblproject_type.Text = ""
                        End If




                        If lblCoast.Text = "" Then
                            lblCoast_Show.Visible = False
                        End If
                        If lblDepart.Text = "" Then
                            lblDepart_Show.Visible = False
                        End If
                        If lblExeDest.Text = "" Then
                            lblExeDest_Show.Visible = False
                        End If
                        If lblProjManger.Text = "" Then
                            lblProjManger_Show.Visible = False
                        End If
                        If lblStartDate.Text = "" Then
                            lblStartDate_Show.Visible = False
                        End If
                        If lblActStartDate.Text = "" Then
                            lblActStartDate_Show.Visible = False
                        End If
                        If lblUsesDest.Text = "" Then
                            lblUsesDest_Show.Visible = False
                        End If
                        If lblProjName.Text = "" Then
                            lblProjname_Show.Visible = False
                        End If
                        If lblproject_type.Text = "" Then
                            lblproject_type_show.Visible = False
                        End If
                    End If
                End If
            End If
        End If
    End Sub

End Class