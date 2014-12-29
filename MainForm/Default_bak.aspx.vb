Imports System.Data

Partial Class WebForms_Default
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session_CS.Project_id = Nothing

        If Not IsPostBack Then
            '''''''''''''''Mosa3ed Wazer''''''''''''''''''''''''
            LinkEvents.Visible = True
            LinkMeeting.Visible = True
            LinkMeetingWithout.Visible = True
            Image6.Visible = True
            Image5.Visible = True
            Image7.Visible = True
            '            statisticsTD.Style.Add("display", "none")

            'nEvents MeetingNo  MeetingWNo
            Dim dtime As DateTime = DateTime.Today.AddDays(2)
            Dim tomorrowDT As String = dtime.ToString("d")

            Dim todaytime As DateTime = DateTime.Today
            Dim todayDT As String = todaytime.ToString("d")

            Dim monthtime As DateTime = DateTime.Today.AddMonths(1)
            Dim monthDT As String = monthtime.ToString("d")

            Dim sqlQry As String = ""
            Dim _dtS As New DataTable


            If Session_CS.UROL_UROL_ID.ToString() = "4" Then
                sqlQry = "SELECT id FROM Event INNER JOIN Project ON Event.ProjID = Project.Proj_id INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " _
                   & " WHERE convert(datetime, Event.Event_date,103) between convert(datetime, '" & todayDT & "',103) and convert(datetime, '" & tomorrowDT & "',103)" _
                   & " and Project_Team.pmp_pmp_id=" & Session_CS.pmp_id
                _dtS = General_Helping.GetDataTable(sqlQry)



                If _dtS.Rows.Count <> 0 Then
                    LinkButton10.Text = Convert.ToString(_dtS.Rows.Count)
                    nEvents.Visible = True
                End If


                sqlQry = "SELECT id FROM Project INNER JOIN Meetings ON Project.Proj_id = Meetings.ProjID INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " _
                       & " WHERE convert(datetime, Meetings.Meeting_date,103) between convert(datetime, '" & todayDT & "',103) and convert(datetime, '" & tomorrowDT & "',103)" _
                        & " and Project_Team.pmp_pmp_id=" & Session_CS.pmp_id
                _dtS = General_Helping.GetDataTable(sqlQry)
                If _dtS.Rows.Count <> 0 Then
                    LinkButton4.Text = Convert.ToString(_dtS.Rows.Count)
                    MeetingNo.Visible = True
                End If

                sqlQry = "SELECT id FROM Project INNER JOIN Protocol ON Project.Proj_id = Protocol.ProjID INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " _
                       & " WHERE convert(datetime, Protocol.Protocol_end_date,103) between convert(datetime, '" & todayDT & "',103) and convert(datetime, '" & monthDT & "',103)" _
                        & " and Project_Team.pmp_pmp_id=" & Session_CS.pmp_id
                _dtS = General_Helping.GetDataTable(sqlQry)
                If _dtS.Rows.Count <> 0 Then
                    LinkButton9.Text = Convert.ToString(_dtS.Rows.Count)
                    TrProtocol.Visible = True
                End If

                sqlQry = "SELECT id FROM Project INNER JOIN Meetings ON Project.Proj_id = Meetings.ProjID INNER JOIN Project_Team ON Project.Proj_id = Project_Team.proj_proj_id  " _
                       & " WHERE Meetings.File_name='' and convert(datetime, Meetings.Meeting_date,103) between convert(datetime, '" & todayDT & "',103) and convert(datetime, '" & tomorrowDT & "',103)" _
                        & " and Project_Team.pmp_pmp_id=" & Session_CS.pmp_id
                _dtS = General_Helping.GetDataTable(sqlQry)
                If _dtS.Rows.Count <> 0 Then
                    LinkButton7.Text = Convert.ToString(_dtS.Rows.Count)
                    MeetingWNo.Visible = True
                End If
            ElseIf Session_CS.UROL_UROL_ID.ToString() = "2" Or Session_CS.UROL_UROL_ID.ToString() = "3" Then
                sqlQry = "SELECT id FROM Event INNER JOIN Project ON Event.ProjID = Project.Proj_id " _
                   & " WHERE convert(datetime, Event.Event_date,103) between convert(datetime, '" & todayDT & "',103) and convert(datetime, '" & tomorrowDT & "',103)" _
                   & " and (Event.Event_attendence='" & Session_CS.pmp_id & "' or Event.Event_attendence LIKE '" & Session_CS.pmp_id & "#%' or Event.Event_attendence LIKE '%#" & Session_CS.pmp_id & "' or Event.Event_attendence LIKE '%#" & Session_CS.pmp_id & "#%') "
                _dtS = General_Helping.GetDataTable(sqlQry)
                If _dtS.Rows.Count <> 0 Then
                    LinkButton10.Text = Convert.ToString(_dtS.Rows.Count)
                    nEvents.Visible = True
                End If
            End If




            '
            Dim sqlz As String = ""
            Dim _dt As New DataTable
            backMain.Visible = False
            If Session_CS.UROL_UROL_ID = 7 Then
                Response.Redirect("Store_Resources.aspx")
            End If
            If Session_CS.UROL_UROL_ID = 2 Then
                If Request.QueryString("curProj") = 1 Then
                    sqlz = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                           & " from project " _
                           & " Left join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 2 and project_team.rol_rol_id =4 order by Dept_name,PTem_Name"
                    _dt = General_Helping.GetDataTable(sqlz)

                    If _dt.Rows.Count <> 0 Then
                        gvMain.DataSource = _dt
                        gvMain.DataBind()
                        gvMain.Visible = True
                        main.Visible = True
                        count.Visible = False
                        Current.Visible = False
                        repeadted.Visible = False
                        refused.Visible = False
                        done.Visible = False
                        canceled.Visible = False
                        lblMain.Text = "المشروعات الجارية"
                        nEvents.Visible = False
                        TrProtocol.Visible = False
                        MeetingNo.Visible = False
                        Tr_Protocol_Active.Visible = False
                        Tr_Protocol_Done.Visible = False
                        Tr_Protocol_Stop.Visible = False

                    End If
                Else
                    main.Visible = False
                    Dim sql As String = ""
                    sql = " select count(distinct(proj_id))Proj_count " _
                           & " from project " _
                           & " where Proj_is_commit = 0 and Proj_is_refused = 0 and Proj_is_repeated = 0 "
                    If General_Helping.GetDataTable(sql).Rows.Count <> 0 Then
                        LBtnProj_count.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        LinkButton3.Visible = False
                    End If
                    sql = " select count(distinct(proj_id))Proj_count " _
                               & " from project " _
                               & " where proj_is_commit = 2 "
                    If General_Helping.GetDataTable(sql).Rows.Count <> 0 Then
                        LBtnCurrentProj.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        LinkButton1.Visible = False
                    End If

                    sql = " select count(distinct(proj_id))Proj_count " _
                               & " from project " _
                               & " where proj_is_commit = 4 "

                    If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                        lbtnProj_done.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        done.Visible = False
                    End If

                    sql = " select count(distinct(proj_id))Proj_count " _
                               & " from project " _
                               & " where proj_is_commit = 5 "

                    If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                        lbtnProj_cancel.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        canceled.Visible = False
                    End If


                    count.Visible = True
                    link3.Text = "مشروع مقترح"
                    'Label2.Text = "مشروع مقترح"
                    Current.Visible = True
                    refused.Visible = False
                    repeadted.Visible = False

                End If

                '''''''''''''''Moder Edara'''''''''''''''''''''
            ElseIf Session_CS.UROL_UROL_ID = 3 Then
                If Request.QueryString("curProj") = 1 Then
                    sqlz = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                           & " from project " _
                           & " join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where proj_is_commit = 2 and project_team.rol_rol_id = 4 and project.pmp_pmp_id = " & Session_CS.pmp_id _
                           & " order by PTem_Name"
                    _dt = General_Helping.GetDataTable(sqlz)

                    If _dt.Rows.Count <> 0 Then
                        gvMain.DataSource = _dt
                        gvMain.DataBind()
                        gvMain.Visible = True
                        main.Visible = True
                        count.Visible = False
                        Current.Visible = False
                        repeadted.Visible = False
                        refused.Visible = False
                        done.Visible = False
                        canceled.Visible = False
                        lblMain.Text = "المشروعات الجارية"
                        nEvents.Visible = False
                        TrProtocol.Visible = False
                        MeetingNo.Visible = False
                        Tr_Protocol_Active.Visible = False
                        Tr_Protocol_Done.Visible = False
                        Tr_Protocol_Stop.Visible = False


                    End If
                Else
                    main.Visible = False
                    Dim sql As String = ""
                    sql = " select count(distinct(proj_id))Proj_count " _
                           & " from project " _
                           & " where Proj_is_commit = 1 and project.pmp_pmp_id = " & Session_CS.pmp_id
                    If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                        LBtnProj_count.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        count.Visible = False
                    End If

                    sql = " select count(distinct(proj_id))Proj_count " _
                           & " from project " _
                           & " where Proj_is_refused = 1 and project.pmp_pmp_id = " & Session_CS.pmp_id
                    lbtnProj_refused.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    sql = " select count(distinct(proj_id))Proj_count " _
                           & " from project " _
                           & " where Proj_is_repeated = 1 and project.pmp_pmp_id = " & Session_CS.pmp_id
                    lbtnProj_repeadted.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    sql = " select count(distinct(proj_id))Proj_count " _
                               & " from project " _
                               & " where proj_is_commit = 2 and project.pmp_pmp_id = " & Session_CS.pmp_id
                    LBtnCurrentProj.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")

                    sql = " select count(distinct(proj_id))Proj_count " _
                              & " from project " _
                              & " where proj_is_commit = 4 and project.pmp_pmp_id = " & Session_CS.pmp_id


                    If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                        lbtnProj_done.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        done.Visible = False
                    End If

                    sql = " select count(distinct(proj_id))Proj_count " _
                              & " from project " _
                              & " where proj_is_commit = 5 and project.pmp_pmp_id = " & Session_CS.pmp_id

                    If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                        lbtnProj_cancel.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                    Else
                        canceled.Visible = False
                    End If

                    'count.Visible = True
                    Current.Visible = True
                    repeadted.Visible = True
                    refused.Visible = True
                End If

                '''''''''''''''Moder Mashro3'''''''''''''''''''''
            ElseIf Session_CS.UROL_UROL_ID = 4 Then

                If Request.QueryString("curProj") = 1 Then
                    If Session_CS.UROL_UROL_ID = 4 Then
                        If Session_CS.pmp_id > 0 Then
                            sqlz = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                                   & " from project " _
                                   & " join project_team on project_team.proj_proj_id = proj_id " _
                                   & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                                   & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                                   & " where proj_is_commit = 2 and project_team.rol_rol_id =4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id _
                                   & " order by pmp_name"
                            _dt = General_Helping.GetDataTable(sqlz)

                            If _dt.Rows.Count <> 0 Then
                                gvMain.DataSource = _dt
                                gvMain.DataBind()
                                gvMain.Visible = True
                                main.Visible = True
                                count.Visible = False
                                Current.Visible = False
                                repeadted.Visible = False
                                refused.Visible = False
                                done.Visible = False
                                canceled.Visible = False
                                gvMain.Columns(4).Visible = False
                                lblMain.Text = "المشروعات الجارية"
                                backMain.Visible = True
                                nEvents.Visible = False
                                TrProtocol.Visible = False
                                MeetingNo.Visible = False
                                Tr_Protocol_Active.Visible = False
                                Tr_Protocol_Done.Visible = False
                                Tr_Protocol_Stop.Visible = False

                            End If
                        End If
                    End If
                Else

                    LBtnProj_count.Visible = True
                    LBtnCurrentProj.Visible = True
                    LinkButton1.Visible = True
                    LinkButton2.Visible = True

                    gvMain.Visible = True
                    main.Visible = False
                    repeadted.Visible = False
                    refused.Visible = False
                    'done.Visible = False
                    'canceled.Visible = False
                    Dim sql As String = ""
                    If Session_CS.pmp_id > 0 Then
                        sql = " select count(distinct(proj_proj_id))Proj_count " _
                               & " from project " _
                               & " join project_team on project_team.proj_proj_id = proj_id where proj_is_commit = 1 and rol_rol_id=4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id
                        If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                            LBtnProj_count.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                        Else
                            count.Visible = False
                        End If


                        sql = " select count(distinct(proj_proj_id))Proj_count " _
                               & " from project " _
                               & " join project_team on project_team.proj_proj_id = proj_id where proj_is_commit = 2 and rol_rol_id=4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id


                        If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                            LBtnCurrentProj.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                        Else
                            Current.Visible = False
                        End If

                        sql = " select count(distinct(proj_proj_id))Proj_count " _
                              & " from project " _
                              & " join project_team on project_team.proj_proj_id = proj_id where proj_is_commit = 4 and rol_rol_id=4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id


                        If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                            lbtnProj_done.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                        Else
                            done.Visible = False
                        End If

                        sql = " select count(distinct(proj_proj_id))Proj_count " _
                              & " from project " _
                              & " join project_team on project_team.proj_proj_id = proj_id where proj_is_commit = 5 and rol_rol_id=4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id


                        If General_Helping.GetDataTable(sql).Rows(0)("Proj_count") <> 0 Then
                            lbtnProj_cancel.Text = General_Helping.GetDataTable(sql).Rows(0)("Proj_count")
                        Else
                            canceled.Visible = False
                        End If


                    End If

                End If

            ElseIf Session_CS.UROL_UROL_ID = 6 Then
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
            End If
        End If

        If Session_CS.UROL_UROL_ID = 8 Or Session_CS.UROL_UROL_ID = 2 Then
            If Session_CS.UROL_UROL_ID = 8 Then
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
            End If
            Dim sqlQry1 As String = "select * from Protocol_Def where Status = 1"
            Dim _dtS1 As DataTable = General_Helping.GetDataTable(sqlQry1)
            If _dtS1.Rows.Count <> 0 Then

                lnk_prot_1.Text = " " & Convert.ToString(_dtS1.Rows.Count) & " "
                Tr_Protocol_Active.Visible = True
            End If
            Dim sqlQry2 As String = "select * from Protocol_Def where Status = 2"
            Dim _dtS2 As DataTable = General_Helping.GetDataTable(sqlQry2)
            If _dtS2.Rows.Count <> 0 Then

                LinkButton15.Text = " " & Convert.ToString(_dtS2.Rows.Count) & " "
                Tr_Protocol_Done.Visible = True
            End If
            Dim sqlQry3 As String = "select * from Protocol_Def where Status = 3"
            Dim _dtS3 As DataTable = General_Helping.GetDataTable(sqlQry3)
            If _dtS3.Rows.Count <> 0 Then

                LinkButton18.Text = " " & Convert.ToString(_dtS3.Rows.Count) & " "
                Tr_Protocol_Stop.Visible = True
            End If
        End If



    End Sub

    Protected Sub LBtnProj_count_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LBtnProj_count.Click
        RetrieveCountProj()
    End Sub

    Private Sub lbtnProj_refused_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnProj_refused.Click
        RetrieveRefusedProj()
    End Sub

    Private Sub lbtnProj_repeadted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnProj_repeadted.Click
        RetrieveRepeadtedProj()
    End Sub

    Private Sub LBtnCurrentProj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnCurrentProj.Click
        RetrieveCurrentProj()
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRows(gvMain)
        If Session_CS.UROL_UROL_ID = 3 Or Session_CS.UROL_UROL_ID = 4 Then
            gvMain.Columns(0).Visible = False
            gvMain.Columns(1).Visible = False
        End If
    End Sub


    'Protected Sub ImgBtnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnBack.Click
    '    Response.Redirect("~/WebForms2/default.aspx?return=1")
    'End Sub



    Protected Sub ImgBtnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnBack.Click
        Response.Redirect("~/WebForms2/default.aspx?return=1")
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        RetrieveCurrentProj()
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton2.Click
        RetrieveCurrentProj()
    End Sub

    Public Sub RetrieveCountProj()
        Dim sql As String = ""
        Dim _dt As New DataTable

        If Session_CS.UROL_UROL_ID = 2 Then
            'sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,convert(integer,Proj_InitValue) as Proj_InitValue_integer " _
            sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                           & " from project " _
                           & " join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 0 and Proj_is_refused = 0 and Proj_is_repeated = 0 and project_team.rol_rol_id = 4  order by Dept_name,proj_id"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.Visible = True
                main.Visible = True
                lblMain.Text = "المشروعات المقترحة"
                lblMain.Visible = True
                gvMain.DataSource = _dt
                gvMain.DataBind()
                backMain.Visible = True
                LBtnProj_count.Visible = False
                link3.Visible = False
                LinkButton3.Visible = False
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                lbtnProj_refused.Visible = False
                lbtnProj_repeadted.Visible = False
                LBtnCurrentProj.Visible = False
                LinkButton2.Visible = False
                LinkButton1.Visible = False
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

            End If

        ElseIf Session_CS.UROL_UROL_ID = 3 Then
            sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_id,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                           & " from project " _
                           & " join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where proj_is_commit = 1 and project_team.rol_rol_id = 4 and Dept_id=" & Session_CS.dept_id
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                main.Visible = True
                gvMain.Visible = True
                lblMain.Visible = True
                count.Visible = False
                refused.Visible = False
                repeadted.Visible = False
                done.Visible = False
                canceled.Visible = False
                Current.Visible = False
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = " المشروعات الجديدة"
                backMain.Visible = True
                gvMain.DataSource = General_Helping.GetDataTable(sql)
                gvMain.DataBind()
            End If

        ElseIf Session_CS.UROL_UROL_ID = 4 Then
            If Session_CS.pmp_id > 0 Then
                sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                       & " from project " _
                       & " join project_team on project_team.proj_proj_id = proj_id " _
                       & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                       & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                       & " where proj_is_commit = 1 and project_team.rol_rol_id =4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id _
                       & " order by pmp_name"
                _dt = General_Helping.GetDataTable(sql)

                If _dt.Rows.Count <> 0 Then
                    main.Visible = True
                    gvMain.DataSource = General_Helping.GetDataTable(sql)
                    gvMain.DataBind()
                    gvMain.Columns(4).Visible = False
                    lblMain.Text = " المشروعات الجديدة"
                    count.Visible = False
                    Current.Visible = False
                    repeadted.Visible = False
                    refused.Visible = False
                    done.Visible = False
                    canceled.Visible = False
                    LBtnCurrentProj.Visible = False
                    LinkButton1.Visible = False
                    LinkButton2.Visible = False
                    backMain.Visible = True
                    nEvents.Visible = False
                    TrProtocol.Visible = False
                    MeetingNo.Visible = False
                    Tr_Protocol_Active.Visible = False
                    Tr_Protocol_Done.Visible = False
                    Tr_Protocol_Stop.Visible = False

                End If
            End If


        End If
    End Sub
    Public Sub RetrieveCurrentProj()
        Dim sql As String = ""
        Dim _dt As New DataTable
        MeetingWNo.Visible = False
        MeetingNo.Visible = False
        nEvents.Visible = False
        Tr_Protocol_Active.Visible = False
        Tr_Protocol_Done.Visible = False
        Tr_Protocol_Stop.Visible = False

        If Session_CS.UROL_UROL_ID = 2 Then
            sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                           & " from project " _
                           & " Left join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 2 and project_team.rol_rol_id =4 order by Dept_name,PTem_Name"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.DataSource = _dt
                gvMain.DataBind()
                gvMain.Visible = True
                main.Visible = True
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                backMain.Visible = True
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = "المشروعات الجارية"
            End If

        ElseIf Session_CS.UROL_UROL_ID = 4 Then
            If Session_CS.pmp_id > 0 Then
                sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                       & " from project " _
                       & " join project_team on project_team.proj_proj_id = proj_id " _
                       & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                       & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                       & " where proj_is_commit = 2 and project_team.rol_rol_id =4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id _
                       & " order by pmp_name"
                _dt = General_Helping.GetDataTable(sql)

                If _dt.Rows.Count <> 0 Then
                    gvMain.DataSource = _dt
                    gvMain.DataBind()
                    gvMain.Visible = True
                    main.Visible = True
                    count.Visible = False
                    Current.Visible = False
                    repeadted.Visible = False
                    refused.Visible = False
                    done.Visible = False
                    canceled.Visible = False
                    nEvents.Visible = False
                    TrProtocol.Visible = False
                    MeetingNo.Visible = False
                    Tr_Protocol_Active.Visible = False
                    Tr_Protocol_Done.Visible = False
                    Tr_Protocol_Stop.Visible = False

                    gvMain.Columns(4).Visible = False
                    backMain.Visible = True
                    lblMain.Text = " المشروعات الجارية"
                    backMain.Visible = True

                End If
            End If

        ElseIf Session_CS.UROL_UROL_ID = 3 Then
            sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue Proj_InitValue_integer " _
                           & " from project " _
                           & " join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where proj_is_commit = 2 and project_team.rol_rol_id = 4 and project.pmp_pmp_id = " & Session_CS.pmp_id _
                           & " order by PTem_Name"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.DataSource = _dt
                gvMain.DataBind()
                gvMain.Visible = True
                main.Visible = True
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                backMain.Visible = True
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = " المشروعات الجارية"

            End If
        End If
    End Sub
    Public Sub RetrieveRefusedProj()
        Dim Sql As String = " select proj_id,pmp_name,PTem_Name,Proj_Title,dept_id,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer,Proj_Notes " _
                      & " from project " _
                      & " join project_team on project_team.proj_proj_id = proj_id " _
                      & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                      & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where proj_is_refused = 1 and Dept_id=" & Session_CS.dept_id _
                      & " and project_team.rol_rol_id = 4 order by PTem_Name"
        Dim _dt As DataTable = General_Helping.GetDataTable(Sql)

        If _dt.Rows.Count <> 0 Then
            GridView1.DataSource = _dt
            GridView1.DataBind()
            main.Visible = True
            GridView1.Visible = True
            gvMain.Visible = False
            backMain.Visible = True
            Current.Visible = False
            count.Visible = False
            refused.Visible = False
            repeadted.Visible = False
            done.Visible = False
            canceled.Visible = False
            lblMain.Visible = True
            Tr2.Visible = True
            nEvents.Visible = False
            TrProtocol.Visible = False
            MeetingNo.Visible = False
            Tr_Protocol_Active.Visible = False
            Tr_Protocol_Done.Visible = False
            Tr_Protocol_Stop.Visible = False

            lblMain.Text = " المشروعات المرفوضة"
        End If
    End Sub
    Public Sub RetrieveRepeadtedProj()
        Dim Sql As String = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_id,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer,Proj_Notes " _
                        & " from project " _
                        & " join project_team on project_team.proj_proj_id = proj_id " _
                        & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                        & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where proj_is_repeated = 1 and Dept_id=" & Session_CS.dept_id _
                        & " and project_team.rol_rol_id = 4 order by PTem_Name"
        Dim _dt As DataTable = General_Helping.GetDataTable(Sql)

        If _dt.Rows.Count <> 0 Then
            GridView1.DataSource = _dt
            GridView1.DataBind()
            main.Visible = True
            GridView1.Visible = True
            gvMain.Visible = False
            count.Visible = False
            Current.Visible = False
            repeadted.Visible = False
            refused.Visible = False
            done.Visible = False
            canceled.Visible = False
            backMain.Visible = True
            lblMain.Visible = True
            Tr2.Visible = True
            nEvents.Visible = False
            TrProtocol.Visible = False
            MeetingNo.Visible = False
            Tr_Protocol_Active.Visible = False
            Tr_Protocol_Done.Visible = False
            Tr_Protocol_Stop.Visible = False

            lblMain.Text = " المشروعات المطلوب تعديلها"
        End If
    End Sub
    Public Sub RetrievedoneProj()
        Dim sql As String = ""
        Dim _dt As New DataTable
        MeetingWNo.Visible = False
        MeetingNo.Visible = False
        nEvents.Visible = False
        Tr_Protocol_Active.Visible = False
        Tr_Protocol_Done.Visible = False
        Tr_Protocol_Stop.Visible = False

        If Session_CS.UROL_UROL_ID = 4 Then
            If Session_CS.pmp_id > 0 Then
                sql = " select * ,Proj_InitValue Proj_InitValue_integer  " _
                       & " from project " _
                       & " join project_team on project_team.proj_proj_id = proj_id " _
                       & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                       & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                       & " where proj_is_commit = 4 and project_team.rol_rol_id =4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id _
                       & " order by pmp_name"
                _dt = General_Helping.GetDataTable(sql)

                If _dt.Rows.Count <> 0 Then
                    gvMain.DataSource = _dt
                    gvMain.DataBind()
                    main.Visible = True
                    gvMain.Visible = True
                    count.Visible = False
                    Current.Visible = False
                    repeadted.Visible = False
                    refused.Visible = False
                    done.Visible = False
                    canceled.Visible = False
                    backMain.Visible = True
                    lblMain.Visible = True
                    Tr2.Visible = True
                    nEvents.Visible = False
                    TrProtocol.Visible = False
                    MeetingNo.Visible = False
                    Tr_Protocol_Active.Visible = False
                    Tr_Protocol_Done.Visible = False
                    Tr_Protocol_Stop.Visible = False

                    lblMain.Text = " المشروعات المنجزة"
                    backMain.Visible = True

                End If
            End If
        ElseIf Session_CS.UROL_UROL_ID = 3 Then
            sql = " select * ,Proj_InitValue Proj_InitValue_integer" _
                           & " from project " _
                           & " join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where proj_is_commit = 4 and project_team.rol_rol_id = 4 and project.pmp_pmp_id = " & Session_CS.pmp_id _
                           & " order by PTem_Name"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.DataSource = _dt
                gvMain.DataBind()
                main.Visible = True
                gvMain.Visible = True
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                backMain.Visible = True
                lblMain.Visible = True
                Tr2.Visible = True
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = " المشروعات المنجزة"
                backMain.Visible = True

            End If
        ElseIf Session_CS.UROL_UROL_ID = 2 Then
            sql = " select * ,Proj_InitValue Proj_InitValue_integer" _
                           & " from project " _
                           & " Left join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 4 and project_team.rol_rol_id =4 order by Dept_name,PTem_Name"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.DataSource = _dt
                gvMain.DataBind()
                main.Visible = True
                gvMain.Visible = True
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                backMain.Visible = True
                lblMain.Visible = True
                Tr2.Visible = True
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = " المشروعات المنجزة"
                backMain.Visible = True
            End If
        End If

    End Sub
    Public Sub RetrievecancelProj()
        Dim sql As String = ""
        Dim _dt As New DataTable
        MeetingWNo.Visible = False
        MeetingNo.Visible = False
        nEvents.Visible = False
        Tr_Protocol_Active.Visible = False
        Tr_Protocol_Done.Visible = False
        Tr_Protocol_Stop.Visible = False

        If Session_CS.UROL_UROL_ID = 4 Then
            If Session_CS.pmp_id > 0 Then
                sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                       & " from project " _
                       & " join project_team on project_team.proj_proj_id = proj_id " _
                       & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                       & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                       & " where proj_is_commit = 5 and project_team.rol_rol_id =4 and project_team.pmp_pmp_id = " & Session_CS.pmp_id _
                       & " order by pmp_name"
                _dt = General_Helping.GetDataTable(sql)

                If _dt.Rows.Count <> 0 Then
                    gvMain.DataSource = _dt
                    gvMain.DataBind()
                    main.Visible = True
                    GridView1.Visible = False
                    gvMain.Visible = True
                    count.Visible = False
                    Current.Visible = False
                    repeadted.Visible = False
                    refused.Visible = False
                    done.Visible = False
                    canceled.Visible = False
                    backMain.Visible = True
                    lblMain.Visible = True
                    Tr2.Visible = True
                    nEvents.Visible = False
                    TrProtocol.Visible = False
                    MeetingNo.Visible = False
                    Tr_Protocol_Active.Visible = False
                    Tr_Protocol_Done.Visible = False
                    Tr_Protocol_Stop.Visible = False

                    lblMain.Text = " المشروعات المتوقفة"
                    backMain.Visible = True

                End If
            End If
        ElseIf Session_CS.UROL_UROL_ID = 3 Then
            sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue Proj_InitValue_integer " _
                           & " from project " _
                           & " join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where proj_is_commit = 5 and project_team.rol_rol_id = 4 and project.pmp_pmp_id = " & Session_CS.pmp_id _
                           & " order by PTem_Name"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.DataSource = _dt
                gvMain.DataBind()
                main.Visible = True
                GridView1.Visible = False
                gvMain.Visible = True
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                backMain.Visible = True
                lblMain.Visible = True
                Tr2.Visible = True
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = " المشروعات المتوقفة"
                backMain.Visible = True

            End If
        ElseIf Session_CS.UROL_UROL_ID = 2 Then
            sql = " select proj_id,pmp_name,PTem_Name,Proj_Title,Dept_name,proj_is_commit,Proj_InitValue as Proj_InitValue_integer " _
                           & " from project " _
                           & " Left join project_team on project_team.proj_proj_id = proj_id " _
                           & " join departments on departments.dept_id = PROJECT.dept_dept_id " _
                           & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID " _
                           & " where Proj_is_commit = 5 and project_team.rol_rol_id =4 order by Dept_name,PTem_Name"
            _dt = General_Helping.GetDataTable(sql)

            If _dt.Rows.Count <> 0 Then
                gvMain.DataSource = _dt
                gvMain.DataBind()
                main.Visible = True
                GridView1.Visible = False
                gvMain.Visible = True
                count.Visible = False
                Current.Visible = False
                repeadted.Visible = False
                refused.Visible = False
                done.Visible = False
                canceled.Visible = False
                backMain.Visible = True
                lblMain.Visible = True
                Tr2.Visible = True
                nEvents.Visible = False
                TrProtocol.Visible = False
                MeetingNo.Visible = False
                Tr_Protocol_Active.Visible = False
                Tr_Protocol_Done.Visible = False
                Tr_Protocol_Stop.Visible = False

                lblMain.Text = " المشروعات المتوقفة"
                backMain.Visible = True
            End If
        End If
    End Sub
    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton3.Click
        RetrieveCountProj()
    End Sub

    Protected Sub link3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles link3.Click
        RetrieveCountProj()
    End Sub

    'Protected Sub LinkR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkR.Click
    '    RetrieveRepeadtedProj()
    'End Sub

    Protected Sub linkRefused_Click(ByVal sender As Object, ByVal e As EventArgs) Handles linkRefused.Click
        RetrieveRefusedProj()
    End Sub

    Protected Sub LinkRef_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkRef.Click
        RetrieveRefusedProj()
    End Sub
    Protected Sub LinkRep_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkRep.Click
        RetrieveRepeadtedProj()
    End Sub
    Protected Sub LinkR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkR.Click
        RetrieveRepeadtedProj()
    End Sub


    Protected Sub Lbtdone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lbtdone.Click
        RetrievedoneProj()
    End Sub
    Protected Sub lbtnProj_done_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnProj_done.Click
        RetrievedoneProj()
    End Sub
    Protected Sub Linkdone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Linkdone.Click
        RetrievedoneProj()
    End Sub


    Protected Sub Llbtcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Llbtcancel.Click
        RetrievecancelProj()
    End Sub
    Protected Sub lbtnProj_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnProj_cancel.Click
        RetrievecancelProj()
    End Sub
    Protected Sub Linkcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Linkcancel.Click
        RetrievecancelProj()
    End Sub
End Class
