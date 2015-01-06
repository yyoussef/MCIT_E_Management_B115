Imports System.Data
Imports VB_Classes.Dates


Partial Class UserControls_ProjectSearch
    Inherits System.Web.UI.UserControl


#Region "variables"

    Dim Obj_General_Helping As New General_Helping
    Dim sql_Connection As String = DBL.Universal.GetConnectionString()
    ''Session_CS Session_CS
#End Region

#Region "On Init"
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        Smart_Search_man.sql_Connection = sql_Connection
        Smart_Search_man.Text_Field = "pmp_name "
        Smart_Search_man.Value_Field = "pmp_id "
        Dim Query As String = "select distinct pmp_name,pmp_id from EMPLOYEE,Project where EMPLOYEE.PMP_ID = Project.pmp_pmp_id "
Smart_Search_man.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_man.DataBind()

        AddHandler Me.Smart_Search_dep.Value_Handler, AddressOf MOnMember_Data
        'AddHandler Me.Smart_Search_man.Value_Handler, AddressOf MOnMan_Data
        MyBase.OnInit(e)
        fill_structure()
    End Sub


#End Region

    Private Sub MOnMember_Data(ByVal Value As String)

        If CDataConverter.ConvertToInt(Value) > 0 Then

            Smart_Search_pr.sql_Connection = sql_Connection
            Smart_Search_pr.Text_Field = "Proj_Title "
            Smart_Search_pr.Value_Field = "Proj_id "
            Dim Query As String = "select Proj_id ,Proj_Title from Project where Dept_Dept_id=" & Smart_Search_dep.SelectedValue
            Smart_Search_pr.datatble = General_Helping.GetDataTable(Query)
            Smart_Search_pr.DataBind()

           

        End If

    End Sub
    Private Sub MOnMan_Data(ByVal Value As String)
        If CDataConverter.ConvertToInt(Value) > 0 Then
            
        End If
    End Sub
        
    Private Sub fill_structure()
        '' Dim Query As String


        Dim Query8 As String = "select Dept_ID ,Dept_name,Dept_parent_id from Departments"

        Smart_Search_dep.datatble = General_Helping.GetDataTable(Query8)
        Smart_Search_dep.Value_Field = "Dept_id"
        Smart_Search_dep.Text_Field = "Dept_name"
        Smart_Search_dep.DataBind()



    End Sub


#Region "event handel"
    Private Sub Smart_Search_pr_Selected(ByVal Value As String)
        Smart_Search_man.sql_Connection = sql_Connection
        Smart_Search_man.Text_Field = "pmp_name "
        Smart_Search_man.Value_Field = "pmp_id "
        Dim sql As String = ""
        sql = "select distinct pmp_name,pmp_id  from Project_Team" _
        & " join Project on dbo.Project_Team.proj_proj_id = dbo.Project.Proj_id" _
        & " join EMPLOYEE on dbo.Project_Team.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID" _
        & " WHERE Project_Team.rol_rol_id =4 and Project.proj_id=" & Value
        If Session_CS.UROL_UROL_ID = 2 Then
            sql = sql & " and  Proj_is_commit = 2"
        Else
            If Request.QueryString("mode") = "edit" Then
                sql = sql & " and  Proj_is_repeated=1"
            End If
            If Request.QueryString("mode") = "delete" Then
                sql = sql & " and  Proj_is_refused=1"
            End If
        End If

        ' Smart_Search_man.Query = sql
        ' Smart_Search_man.DataBind()


        If Smart_Search_man.Items_Count = 0 Then
            Smart_Search_man.Clear_Controls()
        End If


    End Sub

    Private Sub Smart_Search_dep_Selected(ByVal Value As String)
        Smart_Search_pr.sql_Connection = sql_Connection
        Smart_Search_pr.Text_Field = "Proj_Title "
        Smart_Search_pr.Value_Field = "Proj_id "
        Dim Query As String = "select Proj_id ,Proj_Title from Project where  Project.Dept_Dept_id=" & Value
        Smart_Search_pr.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_pr.DataBind()

        If Smart_Search_pr.Items_Count = 0 Then
            Smart_Search_pr.Clear_Controls()
        End If


    End Sub

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Smart_Search_dep.Show_OrgTree = True
        If Not IsPostBack Then

            '' fill_structure()
            If Session_CS.UROL_UROL_ID = 2 Then
                deptrow.Visible = True
                orgrow.Visible = True
                exorgrow.Visible = True
                statusrow.Visible = True
                Smart_Search_pr.sql_Connection = sql_Connection
                Smart_Search_pr.Text_Field = "Proj_Title "
                Smart_Search_pr.Value_Field = "Proj_id "
                Dim Query As String = "select Proj_id ,Proj_Title from Project "
                Smart_Search_pr.datatble = General_Helping.GetDataTable(Query)
                Smart_Search_pr.DataBind()

                Smart_Search_org.sql_Connection = sql_Connection
                Smart_Search_org.Text_Field = "Org_Desc "
                Smart_Search_org.Value_Field = "org_org_id "
                Dim Query2 As String = "select distinct org_org_id ,Org_Desc from Project_Organization" _
                & " join Organization on Project_Organization.org_org_id = Organization.Org_ID"
                Smart_Search_org.datatble = General_Helping.GetDataTable(Query2)
                Smart_Search_org.DataBind()

                'Smart_Search_man.sql_Connection = sql_Connection
                'Smart_Search_man.Text_Field = "pmp_name "
                'Smart_Search_man.Value_Field = "pmp_id "
                'Smart_Search_man.Query = "select distinct pmp_name,pmp_id,group_id from employee where group_id <> 3"
                'Smart_Search_man.DataBind()

                Smart_Search_exc.sql_Connection = sql_Connection
                Smart_Search_exc.Text_Field = "Org_Desc "
                Smart_Search_exc.Value_Field = "Org_ID "
                Dim Query3 As String = "select Org_ID ,Org_Desc from Organization"
                Smart_Search_exc.datatble = General_Helping.GetDataTable(Query3)
                Smart_Search_exc.DataBind()

                Smart_Search_dep.sql_Connection = sql_Connection
                Smart_Search_dep.Text_Field = "Dept_name "
                Smart_Search_dep.Value_Field = "Dept_ID "
                Dim Query4 As String = "select Dept_ID ,Dept_name,Dept_parent_id from Departments where Dept_ID<>6"
                Smart_Search_dep.datatble = General_Helping.GetDataTable(Query4)
                Smart_Search_dep.DataBind()
                'AddHandler Me.Smart_Search_pr.Value_Handler, AddressOf Smart_Search_pr_Selected
                'AddHandler Me.Smart_Search_dep.Value_Handler, AddressOf Smart_Search_dep_Selected

            End If

            If Session_CS.UROL_UROL_ID = 3 Then

                deptrow.Visible = True
                orgrow.Visible = True
                exorgrow.Visible = True
                statusrow.Visible = True
                Smart_Search_dep.sql_Connection = sql_Connection
                Dim Query As String = " select distinct Departments.Dept_ID,Departments.Dept_name,Departments.Dept_parent_id from Departments inner join  Employee_Departments   on dbo.Employee_Departments.Dept_id = dbo.Departments.Dept_ID  WHERE   PMP_ID = " & Session_CS.pmp_id ''& Session_CS.sec_id _

                Smart_Search_dep.Value_Field = "Dept_ID"
                Smart_Search_dep.Text_Field = "Dept_name"
                Smart_Search_dep.datatble = General_Helping.GetDataTable(Query)
                Smart_Search_dep.DataBind()
                'Smart_Search_dep.SelectedValue = Session_CS.dept_id.ToString()
                Smart_Search_org.sql_Connection = sql_Connection
                Smart_Search_org.Text_Field = "Org_Desc "
                Smart_Search_org.Value_Field = "org_org_id "
                Dim Query2 As String = "select distinct org_org_id ,Org_Desc from Project_Organization" _
                & " join Organization on Project_Organization.org_org_id = Organization.Org_ID"
                Smart_Search_org.datatble = General_Helping.GetDataTable(Query2)
                Smart_Search_org.DataBind()
                Smart_Search_exc.sql_Connection = sql_Connection
                Smart_Search_exc.Text_Field = "Org_Desc "
                Smart_Search_exc.Value_Field = "Org_ID "
                Dim Query3 As String = "select Org_ID ,Org_Desc from Organization"
                Smart_Search_exc.datatble = General_Helping.GetDataTable(Query3)
                Smart_Search_exc.DataBind()

                'Smart_Search_man.sql_Connection = sql_Connection
                'Smart_Search_man.Text_Field = "pmp_name "
                'Smart_Search_man.Value_Field = "pmp_id "
                'Smart_Search_man.Query = "select distinct pmp_name,pmp_id,group_id from employee where group_id <> 3 and rol_rol_id=3 or rol_rol_id =4"
                'Smart_Search_man.DataBind()
            Else
                'deptrow.Visible = False
                'orgrow.Visible = False
                'exorgrow.Visible = False
                'statusrow.Visible = False
                If Request.QueryString("mode") = "edit" Then
                    Smart_Search_pr.sql_Connection = sql_Connection
                    Smart_Search_pr.Text_Field = "Proj_Title "
                    Smart_Search_pr.Value_Field = "Proj_id "
                    Dim Query As String = "select Proj_id ,Proj_Title from Project where Dept_Dept_id=" & Session_CS.dept_id _
                    & " and Proj_is_repeated=1 or Proj_is_commit=1 "
                    Smart_Search_pr.datatble = General_Helping.GetDataTable(Query)
                    Smart_Search_pr.DataBind()

                    Smart_Search_man.sql_Connection = sql_Connection
                    Smart_Search_man.Text_Field = "pmp_name "
                    Smart_Search_man.Value_Field = "pmp_id "
                    Dim Query2 As String = "select distinct pmp_name,pmp_id  from Project_Team" _
                    & " join Project on dbo.Project_Team.proj_proj_id = dbo.Project.Proj_id" _
                    & " join EMPLOYEE on dbo.Project_Team.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID" _
                    & " WHERE Project_Team.rol_rol_id =4 and Proj_is_repeated=1 or Proj_is_commit=1 and Project.Dept_Dept_id=" & Session_CS.dept_id
                    Smart_Search_man.datatble = General_Helping.GetDataTable(Query2)
                    Smart_Search_man.DataBind()

                End If
                If Request.QueryString("mode") = "delete" Then
                    Smart_Search_pr.sql_Connection = sql_Connection
                    Smart_Search_pr.Text_Field = "Proj_Title "
                    Smart_Search_pr.Value_Field = "Proj_id "
                    Dim Query As String = "select Proj_id ,Proj_Title from Project where Dept_Dept_id=" & Session_CS.dept_id _
                    & " and Proj_is_refused=1"
                    Smart_Search_pr.datatble = General_Helping.GetDataTable(Query)
                    Smart_Search_pr.DataBind()
                    Smart_Search_man.sql_Connection = sql_Connection
                    Smart_Search_man.Text_Field = "pmp_name "
                    Smart_Search_man.Value_Field = "pmp_id "
                    Dim Query2 As String = "select distinct pmp_name,pmp_id  from Project_Team" _
                    & " join Project on dbo.Project_Team.proj_proj_id = dbo.Project.Proj_id" _
                    & " join EMPLOYEE on dbo.Project_Team.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID" _
                    & " WHERE Project_Team.rol_rol_id =4 and Proj_is_refused=1 and Project.Dept_Dept_id=" & Session_CS.dept_id
                    Smart_Search_man.datatble = General_Helping.GetDataTable(Query2)
                    Smart_Search_man.DataBind()
                End If


                ' AddHandler Me.Smart_Search_man.Value_Handler, AddressOf Smart_Search_man_Selected


            End If

            If Request.QueryString("mode") = "edit" Then
                Label10.Text = "تعديل مقترح مشروع"
            End If
            If Request.QueryString("mode") = "delete" Then
                Label10.Text = "حذف مقترح مشروع"
            End If
            Dim sql As String = ""
            sql = "select Stat_id,Stat_Desc from Status"
            Dim dt As DataTable = General_Helping.GetDataTable(sql)
            Obj_General_Helping.SmartBindDDL(DdlProjStatus, dt, "Stat_id", "Stat_Desc", "")
            FillGrid()
            'End If
            If Request.QueryString("mode") = "edit" Then
                Label10.Text = "تعديل مقترح مشروع"
            End If
            If Request.QueryString("mode") = "delete" Then
                Label10.Text = "حذف مقترح مشروع"
            End If


        End If
    End Sub

    Private Sub FillGrid()

        Dim sql As String = ""
        Dim sql2 As String = ""
        sql = "SELECT DISTINCT Project.Proj_id,Project.Proj_is_refused, Project.Proj_is_repeated, EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Project.Proj_Title, Departments.Dept_name,Departments.Dept_parent_id FROM Project INNER JOIN Departments ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID left OUTER JOIN Project_Organization LEFT OUTER JOIN Organization ON Project_Organization.org_org_id = Organization.Org_ID ON Project_Organization.proj_proj_id = Project.Proj_id where 1=1"

        'sql = " SELECT DISTINCT Project.Proj_id, EMPLOYEE.PMP_ID, EMPLOYEE.pmp_name, Project.Proj_Title, Departments.Dept_name " _
        '      & " FROM         Project INNER JOIN                      Departments ON Departments.Dept_ID = Project.Dept_Dept_id INNER JOIN                      EMPLOYEE ON Project.pmp_pmp_id = EMPLOYEE.PMP_ID FULL OUTER JOIN" _
        '      & "       Project_Organization LEFT OUTER JOIN                       Organization ON Project_Organization.org_org_id = Organization.Org_ID ON Project_Organization.proj_proj_id = Project.Proj_id FULL OUTER JOIN " _
        '        & "     Status RIGHT OUTER JOIN                      Poject_status ON Status.Stat_id = Poject_status.stst_stat_id ON Poject_status.proj_proj_id = Project.Proj_id where 1=1"


        'sql = "select distinct proj_id,pmp_id,pmp_name,Proj_Title,Dept_name from project" _
        '      & " left join project_team on project_team.proj_proj_id = proj_id join departments on departments.dept_id = PROJECT.dept_dept_id " _
        '      & " full outer join Project_organization on Project_Organization.proj_proj_id = Project.Proj_id " _
        '      & " left join Organization on Project_Organization.org_org_id = Organization.Org_ID " _
        '      & " full outer join Poject_status on Poject_status.proj_proj_id = Project.Proj_id " _
        '      & " left join Status on Poject_status.stst_stat_id = Status.Stat_id " _
        '      & " left join employee on dbo.Project_Team.pmp_pmp_id = dbo.EMPLOYEE.PMP_ID  where project_team.rol_rol_id= 4"

        If Smart_Search_pr.SelectedValue <> "" Then
            sql = sql & " and proj_id = " & Smart_Search_pr.SelectedValue
        End If

        If Smart_Search_man.SelectedValue <> "" Then
            sql = sql & " and pmp_id = " & Smart_Search_man.SelectedValue
        End If
        If date_validate(txtProjDateSearch.Text) <> "" Then
            If txtProjDateSearch.Text <> "" Then
                sql = sql & " and Proj_Creation_Date = '" & txtProjDateSearch.Text & "'"
            End If
        End If
        If txtProjStartCoastSearch.Text <> "" Then
            sql = sql & " and Proj_InitValue > " & txtProjStartCoastSearch.Text
        End If

        If txtProjEndCoastSearch.Text <> "" Then
            sql = sql & " and Proj_InitValue < " & txtProjEndCoastSearch.Text
        End If

        If Session_CS.UROL_UROL_ID = "2" Then
            'sql = sql & " and project.Dept_Dept_id =" & Session_CS.dept_id
            If Smart_Search_dep.SelectedValue <> "" Then
                sql = sql & " and project.Dept_Dept_id =" & Smart_Search_dep.SelectedValue
            End If
            'Dim dt As DataTable
            'dt = General_Helping.GetDataTable(sql)
            'If dt.Rows.Count < 0 Then
            '    sql = sql & " and project.Dept_Dept_id =" & Smart_Search_dep.SelectedValue
        End If
        If Session_CS.UROL_UROL_ID = "3" Then
            If Smart_Search_dep.SelectedValue <> "" Then
                sql = sql & " and project.Dept_Dept_id =" & Smart_Search_dep.SelectedValue
            Else
                sql = sql & " and project.Dept_Dept_id in (select distinct Dept_ID from Employee_Departments WHERE sec_sec_id = 0 " & " and  pmp_id = " & Session_CS.pmp_id & ")" ''& Session_CS.sec_id _

            End If
        End If


        'Else
        '    sql = sql & " and Proj_is_commit = " & 1

        'If Request.QueryString("mode") = "edit" Then
        '    sql = sql & " and project.Proj_is_repeated =" & 1
        'End If
        'If Request.QueryString("mode") = "delete" Then
        '    sql = sql & " and project.Proj_is_refused =" & 1
        'End If


        'If Smart_Search_dep.SelectedValue <> "" Then
        '    sql = sql & " and project.Dept_Dept_id = " & Smart_Search_dep.SelectedValue
        'End If
        If Smart_Search_org.SelectedValue <> "" Then
            sql = sql & " and org_org_id = " & Smart_Search_org.SelectedValue
        End If

        If Smart_Search_exc.SelectedValue <> "" Then
            sql = sql & " and org_org_id = " & Smart_Search_exc.SelectedValue
        End If

        'If txtProjDateSearch.Text <> "" Then
        '    sql = sql & " and Proj_Creation_Date = " & txtProjDateSearch.Text
        'End If


        If DdlProjStatus.SelectedValue = "1" Then
            sql = sql & " and Project.Proj_is_commit = 1"
        ElseIf DdlProjStatus.SelectedValue = "2" Then
            sql = sql & " and Project.Proj_is_commit = 2"
        ElseIf DdlProjStatus.SelectedValue = "3" Then
            sql = sql & " and Project.Proj_is_commit = 3"
        ElseIf DdlProjStatus.SelectedValue = "4" Then
            sql = sql & " and Project.Proj_is_commit = 0 and Project.Proj_is_refused=0 and Project.Proj_is_repeated=1"
        ElseIf DdlProjStatus.SelectedValue = "5" Then
            sql = sql & " and Project.Proj_is_commit = 0 and Project.Proj_is_refused=1 and Project.Proj_is_repeated=0"
        ElseIf DdlProjStatus.SelectedValue = "6" Then
            sql = sql & " and Project.Proj_is_commit = 4"
        ElseIf DdlProjStatus.SelectedValue = "7" Then
            sql = sql & " and Project.Proj_is_commit = 5"
        End If

        sql = sql & " order by Dept_name,pmp_id"

        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()

        If gvMain.Rows.Count <> 0 Then
            If Request.QueryString("mode") = "delete" Then
                gvMain.HeaderRow.Cells(3).Visible = False
                Dim i As Integer = 0
                For Each row As GridViewRow In gvMain.Rows
                    gvMain.Rows(i).Cells(3).Visible = False
                    gvMain.Rows(i).Cells(4).Visible = True
                    i += 1
                Next
            End If
            If Request.QueryString("mode") = "edit" Then
                'gvMain.HeaderRow.Cells(4).Visible = False
                Dim i As Integer = 0
                For Each row As GridViewRow In gvMain.Rows
                    gvMain.Rows(i).Cells(3).Visible = True
                    ' gvMain.Rows(i).Cells(4).Visible = False
                    i += 1
                Next
            End If
        End If


    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = CType(sender.parent.parent.FindControl("Proj_id"), HtmlControls.HtmlInputHidden).Value

        If Session_CS.UROL_UROL_ID = 2 Then
            Response.Redirect("../MainForm/Project_Details.aspx?Proj_id=" & id)
            'ElseIf Session_CS.UROL_UROL_ID = 3 Then
            '  Response.Redirect("../WebForms2/Project_Details.aspx?Proj_id=" & id)
        ElseIf Session_CS.UROL_UROL_ID = 3 And Request.QueryString("mode") = "edit" Then
            Response.Redirect("../MainForm/Projects.aspx?Proj_id=" & id & "&mode=edit")
        ElseIf Session_CS.UROL_UROL_ID = 3 And Request.QueryString("mode") = "delete" Then
            Response.Redirect("../MainForm/Projects.aspx?Proj_id=" & id & "&mode=delete")
        Else
            Response.Redirect("../MainForm/Project_Details.aspx?Proj_id=" & id)
        End If
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sqlz As String = ""
        Dim _dt As New DataTable
        sqlz = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue " _
                           & " from project " _
                           & " Left join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 2 and PTem_Name='" & CType(sender, LinkButton).CommandArgument & "' order by Dept_name"
        _dt = General_Helping.GetDataTable(sqlz)

        If _dt.Rows.Count <> 0 Then
            gvMain.DataSource = _dt
            gvMain.DataBind()
            gvMain.Visible = True
        End If
    End Sub
    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sqlz As String = ""
        Dim _dt As New DataTable
        sqlz = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue " _
                           & " from project " _
                           & " Left join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 2 and Dept_name='" & CType(sender, LinkButton).CommandArgument & "' and project_team.rol_rol_id= 4 order by PTem_Name"
        _dt = General_Helping.GetDataTable(sqlz)

        If _dt.Rows.Count <> 0 Then
            gvMain.DataSource = _dt
            gvMain.DataBind()
            gvMain.Visible = True
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblPageStatus.Visible = False
        FillGrid()
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        ' DBL.Helper.MergeRows(gvMain)
    End Sub

    Protected Sub txtProjDateSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtProjDateSearch.TextChanged
        If txtProjDateSearch.Text <> "" Then

            If date_validate(txtProjDateSearch.Text) <> "" Then
                txtProjDateSearch.Text = date_validate(txtProjDateSearch.Text)

                lblPageStatus.Visible = False

            Else
                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                lblPageStatus.Visible = True
                Return
            End If
        Else
            lblPageStatus.Visible = False
            Return
        End If
    End Sub

End Class
