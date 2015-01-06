Imports System.Data
Imports VB_Classes
Imports CrystalDecisions.CrystalReports.Engine
Imports activityLeveling
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq


Partial Class MainForm_Project_Details
    Inherits System.Web.UI.Page
    'Session_CS Session_CS()
    Dim Obj_General_Helping As New General_Helping
    Dim general_sql As String = ""
    ' Dim PMreports As New ReportsClass.Reports
    Public main_dt As New DataTable
    Public final_dt As New DataTable
    Public level As Integer = 0
    Dim Nroot As Boolean = True


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If Session_CS.UROL_UROL_ID <> 2 Then
            Session_CS.Project_id = Request.QueryString("proj_id")
            'End If

            ' test by youssef
            'Dim pmp As Integer = Integer.Parse(Session_CS.pmp_id.ToString())

            If Session_CS.UROL_UROL_ID = 10 Then
                tr_doc_header.Visible = False
                tr_documents.Visible = False
                Dim _dt As DataTable = General_Helping.GetDataTable("select proj_is_commit,Proj_is_refused,Proj_is_repeated from project where proj_id = " & Request.QueryString("proj_id"))
                Dim commit As String = _dt.Rows(0)("proj_is_commit").ToString()
                Dim rep As String = _dt.Rows(0)("Proj_is_repeated").ToString()
                Dim ref As String = _dt.Rows(0)("Proj_is_refused").ToString()
                GeneratePeviousNextURL(commit, Session_CS.UROL_UROL_ID, rep, ref)
            End If
            If Not Request.QueryString("proj_id") Is Nothing Then
                Session("Req_to_edit") = 1
                Session("proj_id_to_edit") = Request.QueryString("proj_id")

            End If

            '''''''''''''''''''''' chek that the user is project manager
            Dim dt_proj As DataTable = General_Helping.GetDataTable("select * from project where proj_id=" & Request.QueryString("proj_id"))

            If CDataConverter.ConvertToInt(dt_proj.Rows(0)("pmp_pmp_id").ToString()) = CDataConverter.ConvertToInt(Session_CS.pmp_id) Then
                If dt_proj.Rows(0)("proj_is_commit") = 3 Then
                    Dim init_value As Decimal = dt_proj.Rows(0)("Proj_InitValue").ToString()
                    General_Helping.ExcuteQuery("update project set Balance_Suggest_Approved = '" & init_value & "',proj_is_commit = 2 where proj_ID = " & Request.QueryString("proj_id"))
                End If
            End If

            If Session_CS.UROL_UROL_ID = 4 Then
                Dim dt As DataTable = General_Helping.GetDataTable("select proj_is_commit from project where proj_id=" & Request.QueryString("proj_id"))
                Dim commit As String = dt.Rows(0)("proj_is_commit").ToString()

                GeneratePeviousNextURL(commit, Session_CS.UROL_UROL_ID, "0", "0")


                'If dt.Rows(0)("proj_is_commit") = 3 Then
                '    General_Helping.ExcuteQuery("update project set proj_is_commit = 2 where proj_ID = " & Request.QueryString("proj_id"))
                'End If
                'txtEditable.Visible = True
                'txtEditable.Enabled = True
                'txtEditable.ReadOnly = True
                'btnCommit.Visible = False
                'btnRefuse.Visible = False
                'btnRetry.Visible = False
                operation.Visible = False
                'Dim dt1 As DataTable = General_Helping.GetDataTable("select count(PDOC_ID) as PDOC_ID_no from Projects_Documents where Proj_Proj_id =" & Request.QueryString("proj_id"))
                'If dt1.Rows(0)("PDOC_ID_no") > 0 Then
                '    GView.Visible = True
                'End If
            ElseIf Session_CS.UROL_UROL_ID = 3 Then


                'txtEditable.Visible = True
                'txtEditable.Enabled = True
                'txtEditable.ReadOnly = True
                'txtNonEditable.Visible = True
                'btnCommit.Visible = False
                'btnRefuse.Visible = False
                'btnRetry.Visible = False
                operation.Visible = False
                'Dim dt1 As DataTable = General_Helping.GetDataTable("select count(PDOC_ID) as PDOC_ID_no from Projects_Documents where Proj_Proj_id =" & Request.QueryString("proj_id"))
                'If dt1.Rows(0)("PDOC_ID_no") > 0 Then
                '    GView.Visible = True
                'End If
                Dim dt As DataTable = General_Helping.GetDataTable("select proj_is_commit,Proj_is_repeated,Proj_is_refused from project where proj_id=" & Request.QueryString("proj_id"))
                Dim commit As String = dt.Rows(0)("proj_is_commit").ToString()
                Dim rep As String = dt.Rows(0)("Proj_is_repeated").ToString()
                Dim ref As String = dt.Rows(0)("Proj_is_refused").ToString()
                GeneratePeviousNextURL(commit, Session_CS.UROL_UROL_ID, rep, ref)
                If dt.Rows(0)("proj_is_commit") = 0 And CDataConverter.ConvertToInt(dt.Rows(0)("Proj_is_refused")) = 1 Then
                    tblTeam.Visible = False
                    tblactiv.Visible = False
                    tblconsts.Visible = False
                    tblneeds.Visible = False
                    tblind.Visible = False
                    tblneedsreceive.Visible = False
                    tblobjs.Visible = False
                    tblorgs.Visible = False
                    newnote.Visible = False

                    lblnewnote.Visible = True

                End If
                If dt.Rows(0)("proj_is_commit") = 0 And CDataConverter.ConvertToInt(dt.Rows(0)("Proj_is_repeated")) = 1 Then
                    tblTeam.Visible = False
                    tblactiv.Visible = False
                    tblconsts.Visible = False
                    tblneeds.Visible = False
                    tblind.Visible = False
                    tblneedsreceive.Visible = False
                    tblobjs.Visible = False
                    tblorgs.Visible = False
                    newnote.Visible = False

                    lblnewnote.Visible = True
                    btnEdit.Visible = True
                End If

                If dt.Rows(0)("proj_is_commit") = 3 Then
                    tblTeam.Visible = False
                    tblactiv.Visible = False
                    tblconsts.Visible = False
                    tblneeds.Visible = False
                    tblind.Visible = False
                    tblneedsreceive.Visible = False
                    tblobjs.Visible = False
                    tblorgs.Visible = False
                    newnote.Visible = False
                    operation.Visible = False
                    lblnewnote.Visible = True


                End If


            ElseIf Session_CS.UROL_UROL_ID = 2 Then
                'Label4.Visible = True
                Dim _dt As DataTable = General_Helping.GetDataTable("select proj_is_commit,Proj_is_refused,Proj_is_repeated from project where proj_id = " & Request.QueryString("proj_id"))
                Dim commit As String = _dt.Rows(0)("proj_is_commit").ToString()
                Dim rep As String = _dt.Rows(0)("Proj_is_repeated").ToString()
                Dim ref As String = _dt.Rows(0)("Proj_is_refused").ToString()
                GeneratePeviousNextURL(commit, Session_CS.UROL_UROL_ID, rep, ref)
                If _dt.Rows.Count > 0 Then


                    If _dt.Rows(0)("proj_is_commit") = 1 Then
                        tblTeam.Visible = False
                        tblactiv.Visible = False
                        tblconsts.Visible = False
                        tblneeds.Visible = False
                        tblind.Visible = False
                        tblneedsreceive.Visible = False
                        tblobjs.Visible = False
                        tblorgs.Visible = False
                        newnote.Visible = False

                        lblnewnote.Visible = True
                        'btnCommit.Visible = True
                        'btnRefuse.Visible = True
                        'btnRetry.Visible = True
                        operation.Visible = True
                        'txtEditable.Visible = True
                        'txtEditable.Enabled = True
                        'txtEditable.ReadOnly = False
                        'btnCommit.Visible = True
                        'btnRefuse.Visible = True
                        'btnRetry.Visible = True
                        'operation.Visible = True
                        'GridView8.Columns(2).Visible = True
                        'GridView8.Columns(3).Visible = True

                        'Dim dt1 As DataTable = General_Helping.GetDataTable("select count(PDOC_ID) as PDOC_ID_no from Projects_Documents where Proj_Proj_id =" & Request.QueryString("proj_id"))
                        'If dt1.Rows(0)("PDOC_ID_no") > 0 Then
                        '    GView.Visible = True
                        'End If

                    ElseIf CDataConverter.ConvertToInt(_dt.Rows(0)("Proj_is_refused")) = 1 Or CDataConverter.ConvertToInt(_dt.Rows(0)("Proj_is_repeated")) = 1 Then
                        tblTeam.Visible = False
                        tblactiv.Visible = False
                        tblconsts.Visible = False
                        tblneeds.Visible = False
                        tblind.Visible = False
                        tblneedsreceive.Visible = False
                        tblobjs.Visible = False
                        tblorgs.Visible = False
                        newnote.Visible = False

                        lblnewnote.Visible = True
                        'btnCommit.Visible = True
                        'btnRefuse.Visible = True
                        'btnRetry.Visible = True
                        operation.Visible = False
                        'Dim dt1 As DataTable = General_Helping.GetDataTable("select count(PDOC_ID) as PDOC_ID_no from Projects_Documents where Proj_Proj_id =" & Request.QueryString("proj_id"))
                        'If dt1.Rows(0)("PDOC_ID_no") > 0 Then
                        '    GView.Visible = True
                        'End If
                    ElseIf _dt.Rows(0)("proj_is_commit") = 3 Then
                        tblTeam.Visible = False
                        tblactiv.Visible = False
                        tblconsts.Visible = False
                        tblneeds.Visible = False
                        tblind.Visible = False
                        tblneedsreceive.Visible = False
                        tblobjs.Visible = False
                        tblorgs.Visible = False
                        newnote.Visible = False
                        operation.Visible = False
                        lblnewnote.Visible = True

                    Else
                        tblTeam.Visible = True
                        tblactiv.Visible = True
                        tblconsts.Visible = True
                        tblneeds.Visible = True
                        tblind.Visible = True
                        'tblneedsappr.Visible = False
                        'tblneedsavail.Visible = False
                        tblneedsreceive.Visible = True
                        tblobjs.Visible = True
                        tblorgs.Visible = True
                        lblnewnote.Visible = True
                        newnote.Visible = True
                        operation.Visible = False
                    End If
                End If
            Else
                operation.Visible = False
            End If

            LoadData()
            FillGrid()
            loadpage()
        End If

    End Sub
    'write by noura For ahmed salah user'
    Private Sub loadpage()
        If Not Session("group_id") Is Nothing And Session("group_id") = 6 Then
            tblneeds.Visible = False
            tblneedsreceive.Visible = False
            operation.Visible = False
            TableNotes.Visible = False
        End If
    End Sub
    ' next previous sub
    Private Sub GeneratePeviousNextURL(ByVal comm As String, ByVal rolID As Integer, ByVal rep As String, ByVal ref As String)
        Select Case comm
            Case "0"
                If rep = "1" Then
                    hypPrev.Text = "<< مشروع سابق مطلوب إعادته"
                    hypNext.Text = "<< مشروع تالى مطلوب إعادته "
                ElseIf ref = "1" Then
                    hypPrev.Text = "<< مشروع سابق مرفوض"
                    hypNext.Text = "<< مشروع تالى مرفوض "
                End If
            Case "1"
                hypPrev.Text = "<< مشروع سابق مقترح"
                hypNext.Text = "<< مشروع تالى مقترح "
            Case "2"
                hypPrev.Text = "<< مشروع سابق جارى"
                hypNext.Text = "<< مشروع تالى جارى "
            Case "3"
                hypPrev.Text = "<< مشروع سابق معتمد"
                hypNext.Text = "<< مشروع تالى معتمد "
            Case "4"
                hypPrev.Text = "<< مشروع سابق منتهى"
                hypNext.Text = "<< مشروع تالى منتهى "
            Case "5"
                hypPrev.Text = "<< مشروع سابق متوقف"
                hypNext.Text = "<< مشروع تالى متوقف "
            Case "6"
                hypPrev.Text = "<< مشروع سابق تحت الإنشاء"
                hypNext.Text = "<< مشروع تالى تحت الإنشاء "
            Case "7"
                hypPrev.Text = "<< مشروع سابق ملغى"
                hypNext.Text = "<< مشروع تالى ملغى "
        End Select
        Dim mySql As String = ""
        If rolID = 4 Then
            mySql = "select proj_id from project where proj_is_commit=" & comm & " and pmp_pmp_id=" & Session_CS.pmp_id & " ORDER BY Project.Dept_Dept_id"
        ElseIf rolID = 3 Then
            If comm = "0" And (rep <> "0" Or ref <> "0") Then
                mySql = "select proj_id from project where proj_is_commit=" & comm & "and Proj_is_repeated=" & rep & "and Proj_is_refused=" & ref & " and ( pmp_pmp_id=" & Session_CS.pmp_id & " or Dept_Dept_id=" & Session_CS.dept_id & "or Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = " & Session_CS.pmp_id & ")) order by Project.Dept_Dept_id,Project.pmp_pmp_id"
            Else

                'mySql = "select proj_id from project where proj_is_commit=" & comm & " and ( pmp_pmp_id=" & Session_CS.pmp_id & " or Dept_Dept_id=" & Session_CS.dept_id & " or Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = " & Session_CS.pmp_id & ")) order by Project.Dept_Dept_id,Project.pmp_pmp_id"
                mySql = " select proj_id from project where proj_is_commit=" & comm & "  and  pmp_pmp_id= " & Session_CS.pmp_id & " or Dept_Dept_id=" & Session_CS.dept_id & " or Dept_Dept_id in (select Dept_id from EMPLOYEE_Departemnts where PMP_ID = " & Session_CS.pmp_id & ")  or Project.Proj_id IN (SELECT Project_Team.proj_proj_id FROM  Project_Team INNER JOIN Project  ON Project_Team.proj_proj_id = Project.Proj_id  WHERE Project.Proj_is_commit =" & comm & "  and Project_Team.pmp_pmp_id = " & Session_CS.pmp_id & " ) "
            End If
        ElseIf rolID = 2 Or rolID = 10 Then
            If comm = "0" And (rep <> "0" Or ref <> "0") Then
                mySql = "select proj_id from project where proj_is_commit=" & comm & "and Proj_is_repeated=" & rep & "and Proj_is_refused=" & ref & " order by Project.Dept_Dept_id,Project.pmp_pmp_id"
            Else
                mySql = "select proj_id from project where proj_is_commit=" & comm & " order by Project.Dept_Dept_id,Project.pmp_pmp_id"
            End If
        End If
        Dim dt As DataTable = General_Helping.GetDataTable(mySql)
        If dt.Rows.Count > 1 Then
            Dim prevRW As Integer = 0
            Dim nextRW As Integer = 0
            For Each rw As DataRow In dt.Rows
                If rw("proj_id") = Request.QueryString("proj_id") Then
                    prevRW -= 1
                    nextRW = prevRW + 2
                    Exit For
                Else
                    prevRW += 1
                End If
            Next
            If prevRW < 0 Then

                hypPrev.Visible = False
            Else
                hypPrev.Visible = True
                '  hypPrev.NavigateUrl = "~/MainForm/Project_Details.aspx?proj_id=" & dt.Rows(prevRW)("proj_id")
            End If
            If nextRW > dt.Rows.Count - 1 Then
                hypNext.Visible = False

            Else
                hypNext.Visible = True
                hypNext.NavigateUrl = "~/MainForm/Project_Details.aspx?proj_id=" & dt.Rows(nextRW)("proj_id")
            End If

        Else

            hypPrev.Visible = False
            hypNext.Visible = False

        End If

    End Sub
    Private Sub LoadData()
        Dim sql As String = ""
        sql = " select proj_id,Proj_InitValue,pmp_name,Proj_is_refused,Proj_is_repeated,PTem_Name,Proj_Title,Proj_Brief,Dept_name,proj_is_commit,proj_notes,PDOC_ID" _
               & " from project " _
               & " left outer join project_team on project_team.proj_proj_id = proj_id " _
               & " left join departments on departments.dept_id = PROJECT.dept_dept_id " _
               & " full outer Join projects_documents on projects_documents.Proj_Proj_id = project.proj_id " _
               & " left join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID" _
        & " where proj_id = " & Request.QueryString("proj_id") _
        & " order by PDOC_ID desc"



        Dim _dt As DataTable = General_Helping.GetDataTable(sql)


        Dim type As String = ""


        'lblprojName.Text = _dt.Rows(0)("Proj_Title")
        'lblprojMan.Text = _dt.Rows(0)("PTem_Name")
        'lbldeptMan.Text = _dt.Rows(0)("pmp_name")
        'lbldept.Text = _dt.Rows(0)("Dept_name")
        'txtNonEditable.Text = _dt.Rows(0)("proj_notes")
        If (_dt.Rows.Count > 0) Then
            Dim comm As Integer = 0
            comm = CDataConverter.ConvertToInt(_dt.Rows(0)("proj_is_commit").ToString())
            If (comm >= 1 And comm <= 8) Then

                If comm = 2 Then
                    type = "Active_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If
                If comm = 4 Then
                    type = "Ended_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If
                If comm = 8 Then
                    type = "underfollow_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If
                If comm = 5 Then
                    type = "stopped_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If
                If comm = 1 Then
                    type = "suggest_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If
                If comm = 3 Then
                    type = "suggest_approved_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If
                If comm = 7 Then
                    type = "Canceled_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If

                'ImgBtnBack.PostBackUrl = "~/WebForms2/Projects_Grid_Page.aspx?type=" + comm.ToString()
                ' Response.Redirect("Projects_Grid_Page.aspx")
            Else
                If (CDataConverter.ConvertToInt(_dt.Rows(0)("Proj_is_refused").ToString()) = 1) Then
                    'ImgBtnBack.PostBackUrl = "~/WebForms2/Default.aspx?status=8"
                    type = "Refused_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type
                ElseIf (CDataConverter.ConvertToInt(_dt.Rows(0)("Proj_is_repeated").ToString()) = 1) Then
                    'ImgBtnBack.PostBackUrl = "~/WebForms2/Default.aspx?status=9"
                    type = "Repeated_proj"
                    ImgBtnBack.PostBackUrl = "~/MainForm/Projects_Grid_Page.aspx?type=" + type

                End If


            End If


            If String.IsNullOrEmpty(_dt.Rows(0)("Proj_InitValue").ToString()) Then
                Session("Budget") = "0"
            Else
                Session("Budget") = _dt.Rows(0)("Proj_InitValue").ToString()

            End If
            'txtEditable.Text = _dt.Rows(0)("proj_notes")
            If Not _dt.Rows(0)("Proj_Brief") Is DBNull.Value Then


                txtProjDesc.Text = _dt.Rows(0)("Proj_Brief").ToString()
            End If
            'HyperLink1.NavigateUrl = "~/WebForms2/Project_Details.aspx?Proj_id= " & Eval("Proj_Document")
        End If
        Dim dt As DataTable = General_Helping.GetDataTable("select count(Note_id) as notes_count from Notes where proj_proj_id=" & Request.QueryString("proj_id"))
        If dt.Rows(0)("notes_count") > 1 Then
            'veiwAllNotes.Visible = True
        End If

    End Sub

    Private Sub LoadX()
        If Not Request.QueryString("proj_id") Is Nothing Then

        End If

        Tree_Files.Nodes.Clear()
        Dim DT_Tree As New DataTable()

        DT_Tree = General_Helping.GetDataTable("select File_ID,File_name,Parent_ID from Departments_Documents where Proj_Proj_id =" & Request.QueryString("proj_id"))
        Dim nodeX As New TreeNode("الوثائق", "0")
        Tree_Files.Nodes.Add(nodeX)
        LoadTree(DT_Tree)

    End Sub


    Private Sub LoadTree(ByVal TreeTable As DataTable)

        For i As Integer = TreeTable.Rows.Count - 1 To 0 Step -1
            Dim treeNode As New TreeNode(TreeTable.Rows(i)("File_Name").ToString(), TreeTable.Rows(i)("File_ID").ToString())

            If (CDataConverter.ConvertToInt(TreeTable.Rows(i)("Parent_ID").ToString()) = 0) Then
                Tree_Files.Nodes(0).ChildNodes.Add(treeNode)
                LoadSubTree(treeNode)
            End If



        Next

    End Sub


    Private Sub LoadSubTree(ByVal treeNode As TreeNode)
        Dim DT As New DataTable()
        DT = General_Helping.GetDataTable("select File_ID,File_name,Parent_ID from Departments_Documents where Parent_ID =" & CDataConverter.ConvertToInt(treeNode.Value))

        If (DT.Rows.Count > 0) Then
            For Each row As DataRow In DT.Rows
                Dim newNode As New TreeNode(row("File_Name").ToString(), row("File_ID").ToString())
                treeNode.ChildNodes.Add(newNode)
                LoadSubTree(newNode)
            Next
        End If
    End Sub


    Private Sub FillGrid()


        Dim sql As String = ""
        Dim sql1 As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim sql4 As String = ""
        Dim sql5 As String = ""
        Dim sql6 As String = ""
        Dim sql7 As String = ""
        Dim sql8 As String = ""
        Dim sql9 As String = ""
        Dim sql10 As String = ""
        Dim sql50 As String = ""
        Dim sql_exc_org As String = ""

        If Not Request.QueryString("proj_id") Is Nothing Then
            'sql = " select File_ID,File_name  " _
            '       & " from Departments_Documents " _
            '       & " where (File_Sytem_Name not like '' or File_data is not null ) and  Proj_Proj_id = " & Request.QueryString("proj_id")
            LoadX()
            'GView.DataSource = General_Helping.GetDataTable(sql)
            'GView.DataBind()
        End If



        If Session_CS.pmp_id > 0 Then
            Dim _dtteam As New DataTable
            sql1 = " SELECT     Project_Team.PTem_ID, Project_Team.PTem_Name, Project_Team.PTem_Task_Cat, Project_Team.PTem_Task, Project_Team.rol_rol_id, Project_Team.proj_proj_id,  " _
                    & " Project_Team.pmp_pmp_id, Project_Team.job_job_id, Project_Team.Edit_Project, JOB_TITLE.JTIT_Desc, Roles.Rol_Desc, EMPLOYEE.pmp_name " _
                    & " FROM         Project_Team INNER JOIN  Project ON Project_Team.proj_proj_id = Project.Proj_id INNER JOIN     EMPLOYEE ON Project_Team.pmp_pmp_id = EMPLOYEE.PMP_ID INNER JOIN " _
                    & " JOB_TITLE ON Project_Team.job_job_id = JOB_TITLE.JTIT_ID LEFT OUTER JOIN   Roles ON Project_Team.rol_rol_id = Roles.Rol_ID " _
                    & " where  project_team.proj_proj_id = " & Request.QueryString("proj_id")
            _dtteam = General_Helping.GetDataTable(sql1)
            gvMain.DataSource = _dtteam
            gvMain.DataBind()






        End If

        sql2 = "select Project_Objective.* from Project_Objective join project on Project_Objective.proj_proj_id = Project.proj_id" _
            & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where " _
            & "  proj_proj_id=" & Request.QueryString("proj_id") _
            & " order by pobj_num"

        GridView1.DataSource = General_Helping.GetDataTable(sql2)
        GridView1.DataBind()


        sql3 = "select Project_Needs.*,Availble_Amount,Availble_Amount_Date,Availble_Item,Proj_InitValue,NMT_Desc,NST_Desc from Project_Needs" _
                & " join project on Project_Needs.proj_proj_id = Proj_id" _
                & " join Needs_Sup_Type on Project_Needs.nst_nst_id = nst_ID" _
                & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = NMT_ID" _
                & " full outer join Need_Availble on PNed_ID = PNed_PNed_Id" _
                & " where proj_proj_id =" & Request.QueryString("proj_id") _
                & " order by NMT_Desc,NST_Desc,PNed_ID"


        Dim dtt As New DataTable
        dtt = Project_Attitude_DB.SelectAll(CDataConverter.ConvertToInt(Request.QueryString("proj_id")))
        GridView9.DataSource = dtt
        GridView9.DataBind()


        Dim dts As New DataTable
        dts = project_excution_stages_DB.SelectAll(CDataConverter.ConvertToInt(Request.QueryString("proj_id")))
        GridView10.DataSource = dts
        GridView10.DataBind()

        Dim dts2 As New DataTable
        dts2 = project_success_elemets_DB.SelectAll(CDataConverter.ConvertToInt(Request.QueryString("proj_id")))
        GridView12.DataSource = dts2
        GridView12.DataBind()


        GridView2.DataSource = General_Helping.GetDataTable(sql3)
        GridView2.DataBind()

        'sql4 = "select Project_Needs.* ,NMT_Desc,NST_Desc from Project_Needs" _
        '    & " join Needs_Sup_Type on Project_Needs.nst_nst_id = Needs_Sup_Type.NST_ID" _
        '    & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID" _
        '    & " where proj_proj_id=" & Request.QueryString("proj_id") _
        '    & " order by NMT_Desc,NST_Desc,PNed_ID"

        'GridView3.DataSource = General_Helping.GetDataTable(sql4)
        'GridView3.DataBind()




        sql6 = "select need_Recieve.*,NMT_Desc,NST_Desc,PNed_Name,convert(nvarchar,PNed_Date,103) as needDate,PNed_Number,approved_amount,(PNed_Number-TotalDelievered) as remain from need_recieve" _
            & " join Project_Needs on need_recieve.pned_pned_id = Project_Needs.PNed_ID" _
            & " join Needs_Sup_Type on Project_Needs.nst_nst_id = Needs_Sup_Type.NST_ID" _
            & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID" _
            & " where Project_Needs.proj_proj_id=" & Request.QueryString("proj_id") _
            & " order by recieved_amount_date"

        GridView5.DataSource = General_Helping.GetDataTable(sql6)
        GridView5.DataBind()

        Dim dt_Level As DataTable = ActivLevls.leveling(Request.QueryString("proj_id"), 0, 0, 0, 0)

        'Dim dt_Level As DataTable = VB_Classes.Activities.Activities_Levl.Activities_levels_for_Grid(Request.QueryString("proj_id"))
        'Dim dt As DataTable = Activities_levels_DT(Request.QueryString("proj_id"))
        gvSub.DataSource = dt_Level
        gvSub.DataBind()


        If dt_Level.Rows.Count > 0 Then
            Dim rw_indx As Integer = 0
            Dim projProgress As Decimal = 0
            For Each rw As DataRow In dt_Level.Rows
                If CDataConverter.ConvertToInt(rw("PActv_Parent")) = 0 Then
                    projProgress += CDataConverter.ConvertToDecimal(rw("PActv_wieght")) * CDataConverter.ConvertToDecimal(rw("PActv_Progress")) / 100
                End If
                CType(gvSub.Rows(rw_indx).FindControl("SubPB"), ProgressBar).SetProgress(CDataConverter.ConvertToInt(rw("PActv_Progress")), 100)
                'gvSub.Rows(CInt(rw_indx)).Cells(0).BackColor = Drawing.Color.FromArgb(255, 255, 153)

                rw_indx += 1
            Next
            If projProgress <> 0D Then
                lblProgProgress.Text = (projProgress).ToString("#.00") + "%"
            Else
                lblProgProgress.Text = (projProgress).ToString() + "%"
            End If
        Else
            lblProgProgress.Text = "0%"
        End If








        Dim dt_Ind_Level As DataTable = activityLeveling.ActivLevls.leveling(Request.QueryString("proj_id"), 0, 0, 0, 1)
        '        sql50 = "select Project_Activities_Indicators.PAI_attainment_value,Project_Activities_Indicators.PAI_Unit,"_
        '        & " Project_Activities_Indicators.PAI_Desc, Indicators_Type.IndT_Desc, Project_Activities.PActv_Desc"_
        '       & " ,(Case When Project_Activities.PActv_Parent=0 Then 'رئيسي' Else 'فرعي' End)as parent"_

        '     & " ,Project_Activity_indicator_period.period_desc from Project_Activities_Indicators inner(Join)"_
        '    & " Indicators_Type on Project_Activities_Indicators.indt_indt_id=Indicators_Type.IndT_id inner(Join)"_
        '   & " Project_Activity_indicator_period on Project_Activities_Indicators.PAIP_period_id=Project_Activity_indicator_period.ID"_
        '& " inner join Project_Activities on Project_Activities.PActv_ID = Project_Activities_Indicators.pactv_pactv_id"_
        '& " inner join project on project.Proj_id=Project_Activities.proj_proj_id where(project.Proj_id = 299)"

        GridView3.DataSource = dt_Ind_Level
        GridView3.DataBind()






        sql5 = "select * ,Project_Activities_Indicators.PAI_Desc as indicator_type,Project_Activities_Indicators.PAI_Desc as indicator_period from Project_Activities_Indicators where proj_proj_id=" & Request.QueryString("proj_id") _
        & " and Project_Activities_Indicators.pactv_pactv_id = 0"

        Dim dt As New DataTable
        dt = General_Helping.GetDataTable(sql5)

        For Each rw As DataRow In dt.Rows
            If rw("indt_indt_id").ToString() = "1" Then
                rw("indicator_type") = "كمى"
            ElseIf rw("indt_indt_id").ToString() = "2" Then
                rw("indicator_type") = "كيفى"
            ElseIf rw("indt_indt_id").ToString() = "0" Then
                rw("indicator_type") = ""
            End If

            If rw("PAIP_period_id").ToString() = "4" Then
                rw("indicator_period") = "شهرى"
            ElseIf rw("PAIP_period_id").ToString() = "3" Then
                rw("indicator_period") = "ربع سنوى"
            ElseIf rw("PAIP_period_id").ToString() = "2" Then
                rw("indicator_period") = "نصف سنوى"
            ElseIf rw("PAIP_period_id").ToString() = "1" Then
                rw("indicator_period") = "سنوى"
            ElseIf rw("PAIP_period_id").ToString() = "0" Then
                rw("indicator_period") = ""
            End If
        Next
        GridView4.DataSource = dt
        GridView4.DataBind()


        Dim _dt As New DataTable


        Dim dt_constrain_Level As DataTable = activityLeveling.ActivLevls.leveling(Request.QueryString("proj_id"), 0, 0, 1, 0)



        GridView6.DataSource = dt_constrain_Level
        GridView6.DataBind()




        sql9 = "select Project_Organization.* , Org_Desc from Project_Organization " _
            & " join Project on Proj_proj_id = Proj_id" _
            & " join Organization on org_org_id = org_id" _
            & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where Proj_proj_id=" & Request.QueryString("proj_id") _
              & " and Project_Organization.type=1"

        _dt = General_Helping.GetDataTable(sql9)
        GridView7.DataSource = _dt
        GridView7.DataBind()



        sql_exc_org = "select Project_Organization.* , Org_Desc from Project_Organization " _
            & " join Project on Proj_proj_id = Proj_id" _
            & " join Organization on org_org_id = org_id" _
            & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where Proj_proj_id=" & Request.QueryString("proj_id") _
              & " and Project_Organization.type=2"

        _dt = General_Helping.GetDataTable(sql_exc_org)
        GridView11.DataSource = _dt
        GridView11.DataBind()

        sql10 = "select Notes.* ,convert(nvarchar,Note_date,103) as note_mod_Date from Notes where Proj_proj_id=" & Request.QueryString("proj_id") _
                & " order by Note_id desc"
        _dt = General_Helping.GetDataTable(sql10)
        GridView8.DataSource = _dt
        GridView8.DataBind()
        GridView8.Visible = True
        'If _dt.Rows.Count = 0 Then
        '    GridView8.Visible = False

        'End If
    End Sub




    Private Sub GridView2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PreRender
        MergeRows_3cells(GridView2)
    End Sub
    Public Sub MergeRows_3cells(ByVal GridView As GridView)
        For rowIndex As Integer = GridView.Rows.Count - 2 To rowIndex Step -1
            Dim row As GridViewRow = GridView.Rows(rowIndex)
            Dim previousRow As GridViewRow = GridView.Rows(rowIndex + 1)
            For cellIndex As Integer = 0 To 2 'row.Cells.Count - 1
                If row.Cells(cellIndex).Text = previousRow.Cells(cellIndex).Text Then
                    row.Cells(cellIndex).RowSpan = CInt(IIf(previousRow.Cells(cellIndex).RowSpan < 2, 2, previousRow.Cells(cellIndex).RowSpan + 1))
                    previousRow.Cells(cellIndex).Visible = False
                End If
            Next
        Next
    End Sub
    Private Sub gvSub_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSub.PreRender

        MergeRows_1cell(gvSub)
        Dim i As Integer = 0
        For Each row As GridViewRow In gvSub.Rows
            If CType(gvSub.Rows(i).FindControl("SubPB"), ProgressBar).MainValue = 100 Then
                ' row.BackColor = Drawing.Color.Chartreuse

            End If
            i += 1
        Next
    End Sub

    Public Sub MergeRows_1cell(ByVal GridView As GridView)
        '''''''''''

        ' Dim dt_Level As DataTable = ActivLevls.leveling(Request.QueryString("proj_id"), 0, 0, 0, 0)
        If GridView.Rows.Count > 1 Then


            For rowIndex As Integer = GridView.Rows.Count - 2 To rowIndex Step -1
                Dim row As GridViewRow = GridView.Rows(rowIndex)
                Dim previousRow As GridViewRow = GridView.Rows(rowIndex + 1)
                Dim lvl_row As Integer = CDataConverter.ConvertToInt(CType(row.FindControl("txtLevel"), TextBox).Text)
                Dim lvl_previousRow As Integer = CDataConverter.ConvertToInt(CType(previousRow.FindControl("txtLevel"), TextBox).Text)

                If lvl_previousRow < 5 Then
                    previousRow.Font.Size = 16 - lvl_previousRow * 2
                Else
                    previousRow.Font.Size = 8
                End If

                If lvl_row = 1 Then
                    row.Font.Bold = True
                    row.Font.Size = 14
                    row.BackColor = Drawing.Color.FromArgb(235, 236, 239)
                    row.ForeColor = Drawing.Color.Black

                End If
                If lvl_previousRow = 1 Then
                    previousRow.Font.Bold = True
                    previousRow.Font.Size = 14
                    previousRow.BackColor = Drawing.Color.FromArgb(235, 236, 239)
                    previousRow.ForeColor = Drawing.Color.Black

                End If
                If lvl_previousRow = 2 Then
                    previousRow.BackColor = Drawing.Color.FromArgb(138, 173, 198)
                End If
                If lvl_previousRow = 3 Then
                    previousRow.BackColor = Drawing.Color.FromArgb(175, 207, 229)
                End If
                If lvl_previousRow = 4 Then
                    previousRow.BackColor = Drawing.Color.FromArgb(194, 221, 238)
                End If
                If lvl_previousRow = 5 Then
                    previousRow.BackColor = Drawing.Color.FromArgb(212, 226, 243)
                End If
                If lvl_previousRow = 6 Then
                    previousRow.BackColor = Drawing.Color.FromArgb(240, 226, 243) '194, 221, 238 '178, 207, 228
                End If
                If lvl_previousRow = 7 Then
                    previousRow.BackColor = Drawing.Color.White
                End If
                If lvl_previousRow = 8 Then
                    previousRow.BackColor = Drawing.Color.White
                End If
                If lvl_previousRow = 9 Then
                    previousRow.BackColor = Drawing.Color.White
                End If



                If previousRow.Cells(1).Text = "&nbsp;" Then
                    row.Cells(1).RowSpan = CInt(IIf(previousRow.Cells(1).RowSpan < 2, 2, previousRow.Cells(1).RowSpan + 1))
                    previousRow.Cells(1).Visible = False

                End If


            Next

        ElseIf GridView.Rows.Count = 1 Then

            GridView.Rows(0).Cells(1).Font.Bold = True
            GridView.Rows(0).Cells(1).Font.Size = 14
            GridView.Rows(0).Cells(1).BackColor = Drawing.Color.FromArgb(235, 236, 239)

        End If




    End Sub


    Private Sub GridView3_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.PreRender
        MergeRows_1cell(GridView3)
    End Sub
    'Private Sub GridView4_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.PreRender
    '    DBL.Helper.MergeRows(GridView4)
    'End Sub
    'Private Sub GridView5_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView5.PreRender
    '    DBL.Helper.MergeRows(GridView5)
    'End Sub
    Private Sub GridView6_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView6.PreRender

        Dim dt_constrain_Level As DataTable = activityLeveling.ActivLevls.leveling(Request.QueryString("proj_id"), 0, 0, 1, 0)

        Dim rw_indx As Decimal = 0
        For Each rw As DataRow In dt_constrain_Level.Rows
            If rw("PCONS_IS_CRITICAL").ToString() = "0" Then
                CType(GridView6.Rows(CInt(rw_indx)).FindControl("CheckBox1"), CheckBox).Checked = False
            ElseIf rw("PCONS_IS_CRITICAL").ToString() = "1" Then
                CType(GridView6.Rows(CInt(rw_indx)).FindControl("CheckBox1"), CheckBox).Checked = True
            Else
                CType(GridView6.Rows(CInt(rw_indx)).FindControl("CheckBox1"), CheckBox).Visible = False
            End If
            rw_indx += 1
        Next





    End Sub

    'Private Sub GridView7_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView7.PreRender
    '    DBL.Helper.MergeRows(GridView7)
    'End Sub



    Protected Sub btnCommit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCommit.Click

        Dim str As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
        Dim str1 As String = str.ToString("dd/MM/yyyy")

        Dim _dt As DataTable = General_Helping.GetDataTable("select Proj_InitValue from project where proj_id = " & Request.QueryString("proj_id"))
        Dim initValue As Decimal = Decimal.Parse(_dt.Rows(0)("Proj_InitValue").ToString())

        General_Helping.ExcuteQuery("update project set proj_start_date='" & str1 & "' , proj_is_commit = 3 , proj_is_refused = 0 , proj_is_repeated = 0,Balance_Suggest_Finial='" & initValue & "' where proj_ID = " & Request.QueryString("proj_id"))
        General_Helping.ExcuteQuery("insert into Poject_status (stst_stat_id,proj_proj_id) values ( 2 , " & Request.QueryString("proj_id") & " )")
        Session("IsCommit") = 3
        'Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لقد تم اعتماد المشروع')</script>")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "msg", "alert('لقد تم اعتماد المشروع')", True)
        InsertActivitiesForCategories(CDataConverter.ConvertToInt(Request.QueryString("proj_id")))
        Response.Redirect("~/MainForm/default.aspx")
    End Sub
    Private Sub InsertActivitiesForCategories(ByVal ProjID As Integer)
        Dim sqlCat As String = "select * from Project_Category where proj_id=" & ProjID
        Dim CatDT As DataTable = General_Helping.GetDataTable(sqlCat)
        If CatDT.Rows.Count > 0 Then
            Dim strCat As String = "("
            Dim index As Integer = 0
            For Each rw As DataRow In CatDT.Rows
                If index = CatDT.Rows.Count - 1 Then
                    strCat &= rw("proj_category_id").ToString() & ")"
                Else
                    strCat &= rw("proj_category_id").ToString() & ","
                End If
                index += 1
            Next
            Dim sqlAct As String = "select * from Project_Activities_Templates where PActv_Parent=0 and category_ID In " & strCat _
            & " order by category_ID"
            Dim ActDT As DataTable = General_Helping.GetDataTable(sqlAct)

            If ActDT.Rows.Count > 0 Then
                activRecursion(0, 0, ProjID, ActDT)
            End If
        End If
    End Sub
    Private Sub activRecursion(ByVal oldTblID As Integer, ByVal newTblID As Integer, ByVal ProjID As Integer, ByVal ActDT As DataTable)

        If ActDT.Rows.Count > 0 Then
            For Each ActRW As DataRow In ActDT.Rows
                oldTblID = CDataConverter.ConvertToInt(ActRW("PActv_ID"))
                Dim sqlAct As String = "select * from Project_Activities_Templates where PActv_Parent = " & oldTblID
                Dim tempActDT As DataTable = General_Helping.GetDataTable(sqlAct)
                ActDT = General_Helping.GetDataTable(sqlAct)
                Dim TempSql As String = "insert into Project_Activities (Proj_Proj_Id,PActv_Desc,PActv_Parent,PActv_wieght,Notes) values (" _
                & ProjID & ",'" & ActRW("PActv_Desc").ToString() & "'," & newTblID & "," & CDataConverter.ConvertToDecimal(ActRW("PActv_wieght")) & ",'" & ActRW("Notes").ToString() & "')"
                General_Helping.ExcuteQuery(TempSql)
                Dim _dt As DataTable = General_Helping.GetDataTable("SELECT MAX(PActv_ID) AS LargestPActv_ID FROM Project_Activities")
                activRecursion(oldTblID, CDataConverter.ConvertToInt(_dt.Rows(0)("LargestPActv_ID").ToString()), ProjID, ActDT)

            Next
        End If
    End Sub

    Private Sub btnRefuse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefuse.Click
        General_Helping.ExcuteQuery("update project set proj_is_commit = 12 , proj_is_refused = 1 , proj_is_repeated = 0 where proj_ID = " & Request.QueryString("proj_id"))
        Session("IsRefused") = 1
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "msg", "alert('لقد تم رفض المشروع')", True)

        Response.Redirect("~/MainForm/default.aspx")
    End Sub

    Private Sub btnRetry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        General_Helping.ExcuteQuery("update project set proj_is_commit = 11 , proj_is_refused = 0 , proj_is_repeated = 1 where proj_ID = " & Request.QueryString("proj_id"))
        Session("IsRepeated") = 1
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "msg", "alert('لقد تم إعادة المشروع')", True)
        'System.Windows.Forms.MessageBox.Show("لقد تم إعادة المشروع")
        Response.Redirect("~/MainForm/default.aspx")
    End Sub

    Private Sub ImgBtnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnBack.Click
        'Response.Redirect("~/WebForms2/default.aspx?return=1")
        Response.Redirect("Projects_Grid_Page.aspx")
    End Sub


    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        Response.Redirect("~/MainForm/Projects.aspx?mode=edit&proj_id=" & Request.QueryString("proj_id"))
    End Sub

    'Protected Sub pushToVeiw_clicked(ByVal sender As Object, ByVal e As EventArgs)

    '    veiwAllNotes.Visible = False
    '    veiwAllNotes_grid.Visible = True
    '    dont_show.Visible = True
    '    edit_text.Visible = False
    'End Sub
    'Protected Sub lnkhide_clicked(ByVal sender As Object, ByVal e As EventArgs)

    '    veiwAllNotes_grid.Visible = False
    '    dont_show.Visible = False
    '    veiwAllNotes.Visible = True
    '    txtEditable.Visible = False
    '    edit_text.Visible = True

    'End Sub
    Protected Sub btnAddNote_clicked(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNote.Click
        newnote.Visible = True
        txtEditable.Text = ""
        lblnewnote.Visible = False
        rowsavenote.Visible = True
    End Sub
    Protected Sub btnSaveNote_clicked(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveNote.Click
        If txtEditable.Text <> "" Then
            Dim str As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            Dim str1 As String = str.ToString("dd/MM/yyyy")
            'db.ExcuteQuery("update project set Proj_Notes='" & txtEditable.Text & "' , proj_is_commit = 0 , proj_is_refused = 1 , proj_is_repeated = 0 where proj_ID = " & Request.QueryString("proj_id"))
            General_Helping.ExcuteQuery("insert into Notes (Note_Desc,Note_date,proj_proj_id) values ('" & txtEditable.Text & "','" & str1 & "','" & Request.QueryString("proj_id") & "')")
            Dim sqlz As String = "update project set Proj_Notes='" & txtEditable.Text & "' where proj_id='" & Request.QueryString("proj_id") & "'"
            General_Helping.ExcuteQuery(sqlz)
            'FillGrid()
        End If
        newnote.Visible = False
        lblnewnote.Visible = True
        rowsavenote.Visible = False
        'Dim sql10 As String
        'sql10 = "select Notes.*  from Notes where Proj_proj_id=" & Request.QueryString("proj_id") _
        '        & " order by Note_id desc"
        'Dim _dt As DataTable
        '_dt = General_Helping.GetDataTable(sql10)
        'GridView8.DataSource = _dt
        'GridView8.DataBind()

        FillGrid()
    End Sub
    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub
    'Protected Sub imgBreifPrinter_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    'PMreports.setsession()
    '    'Dim rd As ReportDocument
    '    'rd = PMreports.project_abstract()


    '    'If rd.Rows.Count > 0 Then

    '    '    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, True, "Report")
    '    'Else

    '    '    ReportsClass.Reports.ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!")
    '    'End If
    'End Sub
    'Protected Sub Imagedocument_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    PMreports.setsession()
    '    Dim rd As ReportDocument
    '    rd = PMreports.project_document()


    '    If rd.Rows.Count > 0 Then

    '        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, True, "Report")
    '    Else

    '        ReportsClass.Reports.ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!")
    '    End If
    'End Sub
    'Protected Sub imgProjectTeam_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    PMreports.setsession()
    '    Dim rd As ReportDocument
    '    rd = PMreports.Project_Team_Rep()


    '    If rd.Rows.Count > 0 Then

    '        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, True, "Report")
    '    Else

    '        ReportsClass.Reports.ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!")
    '    End If
    'End Sub
    'Protected Sub imgProjectObj_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    PMreports.setsession()
    '    Dim rd As ReportDocument
    '    rd = PMreports.Proj_Objective()


    '    If rd.Rows.Count > 0 Then

    '        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, True, "Report")
    '    Else

    '        ReportsClass.Reports.ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!")
    '    End If
    'End Sub
    'Protected Sub imgprojcons_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    PMreports.setsession()
    '    Dim rd As ReportDocument
    '    rd = PMreports.proj_cons_rep()



    '    If rd.Rows.Count > 0 Then

    '        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, True, "Report")
    '    Else

    '        ReportsClass.Reports.ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!")
    '    End If


    'End Sub
    'Protected Sub imgProj_notes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    PMreports.setsession()
    '    Dim rd As ReportDocument
    '    rd = PMreports.proj_notes_rep()


    '    If rd.Rows.Count > 0 Then

    '        rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, True, "Report")
    '    Else

    '        ReportsClass.Reports.ShowAlertMessage("هذا التقرير لا يوجد به بيانات للعرض !!!!")
    '    End If
    'End Sub

    Private Sub FillLog(Optional ByVal ID As Integer = 0)
        Try
            Dim dtnow As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            Dim dateNow As String = dtnow.ToString("d")
            Dim recordID As String
            If ID <> 0 Then
                recordID = ID.ToString()
                Project_Log_DB.FillLog(CDataConverter.ConvertToInt(recordID), Project_Log_DB.Action.read, Project_Log_DB.operation.Departments_Documents)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Tree_Files_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tree_Files.SelectedNodeChanged
        If (Not Tree_Files.SelectedNode Is Nothing And CDataConverter.ConvertToInt(Tree_Files.SelectedNode.Value) > 0) Then
            FillLog(CDataConverter.ConvertToInt(Tree_Files.SelectedNode.Value))
            Response.Redirect("ALL_Document_Details.aspx?type=deprtfile&id=" & Tree_Files.SelectedNode.Value)
            'Page.RegisterStartupScript("error", "<script language=javascript>window.open('ALL_Document_Details.aspx?type=deprtfile&id=" & Tree_Files.SelectedNode.Value & "');</script>")




        End If

    End Sub
End Class
