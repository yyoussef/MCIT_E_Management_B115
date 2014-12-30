Imports System.Data
Imports VB_Classes
Imports VB_Classes.Dates

Partial Class WebForms_Project_Activities
    Inherits System.Web.UI.Page

    'Session_CS Session_CS
   

    Dim Obj_General_Helping As New General_Helping

    Dim Nroot As Boolean = True
    Dim tn As Integer
    Dim sql_Connection As String = Database.ConnectionString

#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)

        Smart_Search_org.sql_Connection = sql_Connection
        Smart_Search_org.Text_Field = "Org_Desc "
        Smart_Search_org.Value_Field = "ORG_id "
        Smart_Search_org.Query = "select ORG_id,Org_Desc from Organization"
        Smart_Search_org.DataBind()


        MyBase.OnInitComplete(e)

        Smart_Search_chorg.sql_Connection = sql_Connection
        Smart_Search_chorg.Text_Field = "Org_Desc "
        Smart_Search_chorg.Value_Field = "ORG_id "
        Smart_Search_chorg.Query = "select ORG_id,Org_Desc from Organization"
        Smart_Search_chorg.DataBind()

        Smart_Project_ID.sql_Connection = sql_Connection
        Smart_Project_ID.Text_Field = "Proj_Title "
        Smart_Project_ID.Value_Field = "Proj_id "
        Smart_Project_ID.Query = "SELECT Proj_id, Proj_Title FROM Project"
        Smart_Project_ID.DataBind()
        AddHandler Me.Smart_Project_ID.Value_Handler, AddressOf Smart_Search_Selected



        MyBase.OnInitComplete(e)
    End Sub

#End Region

    Private Sub Smart_Search_Selected(ByVal Value As String)
        If CDataConverter.ConvertToInt(Value) > 0 Then
            PopulateRootLevel(CDataConverter.ConvertToInt(Value))
            FillGrid()
        End If
      
    End Sub

#Region "Load"
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session_CS.Project_id = "460"

        If Not IsPostBack Then
            'Smart_Project_ID.SelectedValue = "200"
            'Dim dt As New DataTable
            'dt = VB_Classes.Activities.Activities_levels_DT(0, 1, 0)
            FillDDL()

            BtnSave.CommandArgument = "new"
            BtnChildSave.CommandArgument = "new"
            lblPageStatus.Text = ""
            'ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)

        End If
    End Sub
#End Region

#Region "Fill Data"
    Private Sub FillGrid()

        If CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) > 0 Then
            If RblActType.SelectedValue = 0 Then
                Dim sql As String = ""
                Dim _dt As New DataTable
               
                sql = "select Project_Activities.* from Project_Activities" _
                    & " where PActv_parent = 0  and proj_proj_id=" & Smart_Project_ID.SelectedValue _
                    & " order by Parent_Actv_Num"
                _dt = Obj_General_Helping.GetDataTable(sql)

                gvMain.DataSource = _dt
                gvMain.DataBind()
                Dim i As Integer = 0
                For Each row1 As DataRow In _dt.Rows
                    CType(gvMain.Rows(i).FindControl("MainPB"), ProgressBar).SetProgress(row1("PActv_wieght"), 100)
                    i += 1
                Next
                gvSub.Visible = False
                gvMain.Visible = True
            Else

                Dim dt_Level As DataTable = Activities_levels_for_Grid(Smart_Project_ID.SelectedValue)
                ' Dim dt As DataTable = Activities_levels_DT(Smart_Project_ID.SelectedValue)
                'Dim sql2 As String = ""
                'sql2 = "select Project_Activities.* from Project_Activities" _
                '   & " join Project on Proj_proj_id = Proj_id" _
                '   & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID" _
                '   & " where PActv_parent <> 0  and   proj_proj_id=" & Smart_Project_ID.SelectedValue _
                '   & " order by Parent_Actv_Num"
                'dt_Level = Obj_General_Helping.GetDataTable(sql2)

                gvSub.DataSource = dt_Level
                gvSub.DataBind()

                Dim rw_indx As Decimal = 0
                For Each rw As DataRow In dt_Level.Rows
                    CType(gvSub.Rows(CInt(rw_indx)).FindControl("SubPB"), ProgressBar).SetProgress(CInt(rw("PActv_wieght")), 100)
                    'gvSub.Rows(CInt(rw_indx)).Cells(0).BackColor = Drawing.Color.FromArgb(255, 255, 153)

                    rw_indx += 1
                Next



                gvMain.Visible = False
                gvSub.Visible = True
            End If
        End If
    End Sub

    Public Function Activities_levels_for_Grid(ByVal proj_ip As Integer) As DataTable
        Dim sql As String = ""
        Dim _dt As New DataTable
        Dim main_dt As New DataTable
        sql = "select Project_Activities.* from Project_Activities" _
            & " where PActv_parent = 0 and  proj_proj_id=" & proj_ip _
            & " order by PActv_Parent,Child_Actv_Num"
        main_dt = Obj_General_Helping.GetDataTable(sql)
        sql = "select Project_Activities.* from Project_Activities" _
            & " where PActv_parent = 0 and  proj_proj_id=" & proj_ip & "and Parent_Actv_Num = " & 1 _
            & " order by PActv_Parent,Child_Actv_Num"
        _dt = Obj_General_Helping.GetDataTable(sql)


        ''''''''2nd_lvl
        Dim total_rows As Integer = 0
        Dim sql1 As String = ""
        Dim _dt1 As New DataTable
        Dim i1 As Integer = 0
        Dim i2 As Integer = 0
        Dim temp_dt As New DataTable
        Dim temp_sql As String = ""
        For row_indx As Integer = 0 To main_dt.Rows.Count - 1
            If row_indx <> 0 Then
                temp_sql = "select Project_Activities.* from Project_Activities" _
               & " where PActv_parent = 0 and  proj_proj_id=" & proj_ip & " and Parent_Actv_Num = " & row_indx + 1 _
               & " order by PActv_Parent,Child_Actv_Num"
                temp_dt = Obj_General_Helping.GetDataTable(temp_sql)
                _dt.ImportRow(temp_dt.Rows(0))
                total_rows += 1
            End If
            sql1 = "select Project_Activities.* from Project_Activities" _
            & " where PActv_parent = " & CInt(_dt.Rows(total_rows)("PActv_ID")) & "  and proj_proj_id=" & proj_ip _
            & " order by PActv_Parent,Child_Actv_Num"
            _dt1 = Obj_General_Helping.GetDataTable(sql1)
            If _dt1.Rows.Count > 0 Then
                i1 = 0
                For Each row1_1 As DataRow In _dt1.Rows
                    '
                    'Dim dr As DataRow
                    'dr = _dt.NewRow()
                    'dr = row1_1
                    '_dt.Rows.InsertAt(dr, row_indx)
                    _dt.ImportRow(_dt1.Rows(i1))
                    _dt.AcceptChanges()
                    '''''''''3rd_lvl
                    Dim sql2 As String = ""
                    Dim _dt2 As New DataTable
                    'For Each row2 As DataRow In _dt1.Rows
                    sql2 = "select Project_Activities.* from Project_Activities" _
                    & " where PActv_parent = " & CInt(_dt1.Rows(i1)("PActv_ID")) & " and proj_proj_id=" & proj_ip _
                    & " order by PActv_Parent,Child_Actv_Num"
                    _dt2 = Obj_General_Helping.GetDataTable(sql2)
                    If _dt2.Rows.Count > 0 Then
                        i2 = 0
                        For Each row1_2 As DataRow In _dt2.Rows
                            '_dt.AcceptChanges()
                            '_dt.Rows.InsertAt(row1_2, row_indx)
                            ' row_indx += 1
                            _dt.ImportRow(_dt2.Rows(i2))
                            _dt.AcceptChanges()
                            i2 += 1
                            total_rows += 1
                        Next
                        '    CType(CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).Rows(i2).FindControl("gvlvl2"), GridView).DataSource = _dt2
                        '    CType(CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).Rows(i2).FindControl("gvlvl2"), GridView).DataBind()
                        '    CType(CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).Rows(i2).FindControl("gvlvl2"), GridView).Visible = True
                        '    ' CType(CType(CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).Rows(i2).FindControl("gvlvl2"), GridView).FindControl("SubPB2"), ProgressBar).SetProgress(row2("PActv_wieght"), 100)
                    End If

                    'Next
                    '_dt.Rows.Add(row1_1)

                    'row_indx += 1




                    i1 += 1
                    total_rows += 1
                Next

            End If
            'If _dt1.Rows.Count > 0 Then
            '    CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).DataSource = _dt1
            '    CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).DataBind()
            '    CType(gvSub.Rows(i1).FindControl("gvlvl1"), GridView).Visible = True
            '    ' CType(gvSub.Rows(i1).FindControl("gvlvl1").FindControl("SubPB1"), ProgressBar).SetProgress(row1("PActv_wieght"), 100)
            'End If


        Next


        '''''''

        Return _dt
        'gridveiw.DataSource = _dt
        'gridveiw.DataBind()

        'Dim rw_indx As Decimal = 0
        'For Each rw As DataRow In _dt.Rows
        '    CType(gridveiw.Rows(CInt(rw_indx)).FindControl("SubPB"), ProgressBar).SetProgress(CInt(rw("PActv_wieght")), 100)
        '    gridveiw.Rows(CInt(rw_indx)).Cells(0).BackColor = Drawing.Color.FromArgb(255, 255, 153)

        '    rw_indx += 1
        'Next

    End Function

    Private Sub FillDDL()
        Dim sql As String = ""
        sql = "select IndT_id,IndT_Desc from Indicators_Type"
        Dim _dt As DataTable = Obj_General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(ddlInd, _dt, "IndT_id", "IndT_Desc", "النوع")

        Dim sql2 As String = ""
        sql2 = "select IndT_id,IndT_Desc from Indicators_Type"
        Dim _dt2 As DataTable = Obj_General_Helping.GetDataTable(sql2)
        Obj_General_Helping.SmartBindDDL(ddlChildInd, _dt, "IndT_id", "IndT_Desc", "النوع")

        'Dim sql1 As String = ""
        'sql1 = "select PActv_ID,Parent_PActv_Desc,PActv_Desc from Project_Activities where  proj_proj_id = " & Smart_Project_ID.SelectedValue & " order by Parent_Actv_Num" 'pactv_parent = 0 and
        'Dim _dt1 As DataTable = Obj_General_Helping.GetDataTable(sql1)
        'Obj_General_Helping.SmartBindDDL(DdlMainActv, _dt1, "PActv_ID", "PActv_Desc", "اختر النشاط الرئيسى")

        Dim sql3 As String = ""
        sql3 = "select * from Active_Satatus"
        Dim _dt3 As DataTable = Obj_General_Helping.GetDataTable(sql3)
        Obj_General_Helping.SmartBindDDL(ddlActvSit, _dt3, "ActStat_ID", "ActStat_Desc", "اختر موقف التنفيذ")

        Dim sql4 As String = ""
        sql4 = "select * from Active_Satatus"
        Dim _dt4 As DataTable = Obj_General_Helping.GetDataTable(sql4)
        Obj_General_Helping.SmartBindDDL(ddlActivSitChild, _dt4, "ActStat_ID", "ActStat_Desc", "اختر موقف التنفيذ")

    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        txtDesc.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        txtPeriod.Text = ""
        txtWight.Text = ""
        txtInd.Text = ""
        txtIndVal.Text = ""
        txtUnit.Text = ""
        txtChildDesc.Text = ""
        txtStartChildDate.Text = ""
        txtEndChildDate.Text = ""
        txtChildPeriod.Text = ""
        txtChildWight.Text = ""
        txtchildUnit.Text = ""
        txtChildInd.Text = ""
        ' txtExOrg.Text = ""
        txtExPer.Text = ""
        ' txtChildExOrg.Text = ""
        txtChildExPer.Text = ""
        txtActvNote.Text = ""
        txtChilActvNote.Text = ""
        txtActStartDate.Text = ""
        txtActEndDate.Text = ""
        txtActStartChildDate.Text = ""
        txtActEndChildDate.Text = ""
        For index As Integer = 0 To 28
            chk_gov_list.Items(index).Selected = False
        Next
        Smart_Search_org.Clear_Controls()
        Smart_Search_chorg.Clear_Controls()
        'DdlMainActv.SelectedValue = "اختر النشاط الرئيسى"
        'ddlInd.SelectedValue = "النوع"
        'ddlChildInd.SelectedValue = "النوع"
        'ddlActivSitChild.SelectedValue = "اختر موقف التنفيذ"
        'ddlActvSit.SelectedValue = "اختر موقف التنفيذ"
        'lblPageStatus.Visible = False
        'lblPageStatus.Text = ""
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If RblActType.SelectedValue = 0 Then
            If txtDesc.Text = "" Then ' Or txtStartDate.Text = "" Or txtPeriod.Text = "" Or txtWight.Text = "" Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
                Return False
            Else
                lblPageStatus.Visible = False
                Return True
            End If
        Else
            If txtChildDesc.Text = "" Or parent_activ.Text = "" Then ' Or txtStartChildDate.Text = "" Or txtChildPeriod.Text = "" Or txtChildWight.Text = "" Or txtEndChildDate.Text = "" Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
                Return False
            Else
                lblPageStatus.Visible = False
                Return True
            End If
        End If
    End Function
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then


                Obj_General_Helping.ExcuteQuery("insert into Project_Activities (Proj_Proj_Id) values (" & Smart_Project_ID.SelectedValue & ")")
                Dim dt As New DataTable
                Dim _dt As New DataTable
                Dim sql As String = ""
                sql = "SELECT MAX(PActv_ID) AS LargestPActv_ID FROM Project_Activities"
                _dt = Obj_General_Helping.GetDataTable(sql)
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Desc = '' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Parent_Pactv_Desc = '" & CType(txtDesc.Text, String) & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                dt = Obj_General_Helping.GetDataTable("select count(Parent_PActv_Desc) as CC from Project_Activities where Proj_Proj_Id=" & Smart_Project_ID.SelectedValue & " and PActv_Parent =" & 0)
                Dim x As Integer = dt.Rows(0)("CC")
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Parent_Actv_Num = " & x + 1 & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Parent = " & 0 & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Obj_General_Helping.ExcuteQuery("update Project_Activities set lvl = " & 1 & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))

                If txtWight.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & Decimal.Parse(txtWight.Text) & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & 0 & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If

                If txtStartDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtStartDate.Text) <> "" Then
                        validated_date = date_validate(txtStartDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Start_Date ='" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtEndDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtEndDate.Text) <> "" Then
                        validated_date = date_validate(txtEndDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_End_Date = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = " & DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", Nothing)).Days & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtActStartDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActStartDate.Text) <> "" Then
                        validated_date = date_validate(txtActStartDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_Start_Date = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtActEndDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActEndDate.Text) <> "" Then
                        validated_date = date_validate(txtActEndDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_End_Date = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If Smart_Search_org.SelectedValue <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Excutive_responsible_Org_Org_id = '" & Smart_Search_org.SelectedValue & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Implementing_Location = '" & Smart_Search_org.SelectedText & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If

                If txtExPer.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Implementing_person = '" & txtExPer.Text & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If


                For index As Integer = 0 To 28
                    If chk_gov_list.Items(index).Selected = True Then
                        Obj_General_Helping.ExcuteQuery("insert into Project_Activities_gov (activity_id,gov_id) values (" & _dt.Rows(0)("LargestPActv_ID") & "," & chk_gov_list.Items(index).Value & ")")
                    End If
                Next

                Obj_General_Helping.ExcuteQuery("insert into Project_Activities_Indicators (pactv_pactv_id) values (" & _dt.Rows(0)("LargestPActv_ID") & ")")
                Obj_General_Helping.ExcuteQuery("insert into Activity_sitiuation (project_activity_FK) values (" & _dt.Rows(0)("LargestPActv_ID") & ")")

                If txtInd.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Desc = '" & txtInd.Text & "' where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtIndVal.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Wieght = '" & Decimal.Parse(txtIndVal.Text) & "' where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtUnit.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Unit = '" & txtUnit.Text & "' where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If ddlInd.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set indt_indt_id = " & ddlInd.SelectedIndex & " where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If ddlActvSit.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set ActStat_ActStat_id = " & ddlActvSit.SelectedIndex & " where PActv_ID=" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtActvNote.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Activity_sitiuation set actv_sit_desc = '" & txtActvNote.Text & "' where project_activity_FK=" & _dt.Rows(0)("LargestPActv_ID"))
                End If

                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                Dim dt As New DataTable
                Dim sql As String = ""
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Parent_Pactv_Desc = '" & CType(txtDesc.Text, String) & "' where PActv_ID = " & PActv_ID.Value)
                If txtPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = '" & Decimal.Parse(txtPeriod.Text) & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtWight.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & Decimal.Parse(txtWight.Text) & "' where PActv_ID = " & PActv_ID.Value)
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & 0 & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtStartDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtStartDate.Text) <> "" Then
                        validated_date = date_validate(txtStartDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Start_Date = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtEndDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtEndDate.Text) <> "" Then
                        validated_date = date_validate(txtEndDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_End_Date  = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = " & DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", Nothing)).Days & " where PActv_ID = " & PActv_ID.Value)
                End If
                If txtActStartDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActStartDate.Text) <> "" Then
                        validated_date = date_validate(txtActStartDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_Start_Date = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtActEndDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActEndDate.Text) <> "" Then
                        validated_date = date_validate(txtActEndDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_End_Date = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_End_Date = '' where PActv_ID = " & PActv_ID.Value)
                End If
                If Smart_Search_org.SelectedValue <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Excutive_responsible_Org_Org_id = '" & Smart_Search_org.SelectedValue & "' where PActv_ID = " & PActv_ID.Value)
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Implementing_Location = '" & Smart_Search_org.SelectedText & "' where PActv_ID = " & PActv_ID.Value)
                End If

                Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Implementing_person = '" & txtExPer.Text & "' where PActv_ID = " & PActv_ID.Value)

                Obj_General_Helping.ExcuteQuery("delete from Project_Activities_gov where activity_id=" & PActv_ID.Value)
                For index As Integer = 0 To 28
                    If chk_gov_list.Items(index).Selected = True Then
                        Obj_General_Helping.ExcuteQuery("insert into Project_Activities_gov (activity_id,gov_id) values (" & PActv_ID.Value & "," & chk_gov_list.Items(index).Value & ")")
                    End If
                Next
                If txtInd.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Desc = '" & txtInd.Text & "' where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If txtIndVal.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Wieght = '" & Decimal.Parse(txtIndVal.Text) & "' where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If txtUnit.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Unit = '" & txtUnit.Text & "' where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If ddlInd.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set indt_indt_id = " & ddlInd.SelectedIndex & " where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If ddlActvSit.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set ActStat_ActStat_id = " & ddlActvSit.SelectedIndex & " where PActv_ID=" & PActv_ID.Value)
                End If
                If txtActvNote.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Activity_sitiuation set actv_sit_desc = '" & txtActvNote.Text & "' where project_activity_FK=" & PActv_ID.Value)
                End If
                BtnSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
            End If
            FillGrid()
            PopulateRootLevel(Smart_Project_ID.SelectedValue)
            BtnSave.Text = "حفــــــظ"
            Clear()

        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub

    Private Sub SaveChildDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then

                Obj_General_Helping.ExcuteQuery("insert into Project_Activities (Proj_Proj_Id) values (" & Smart_Project_ID.SelectedValue & ")")
                Dim dt As New DataTable
                Dim _dt As New DataTable
                Dim dt1 As New DataTable
                Dim sql1 As String = ""
                Dim sql As String = ""
                sql = "SELECT MAX(PActv_ID) AS LargestPActv_ID FROM Project_Activities"
                _dt = Obj_General_Helping.GetDataTable(sql)
                sql1 = "select Parent_Pactv_Desc from Project_Activities where PActv_ID =" & Session("tn_id")
                dt1 = Obj_General_Helping.GetDataTable(sql1)
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Parent_Pactv_Desc = '" & dt1.Rows(0)("Parent_Pactv_Desc") & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                txtDesc.Text = CType(txtChildDesc.Text, String)
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Desc = '" & CType(txtChildDesc.Text, String) & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                dt = Obj_General_Helping.GetDataTable("select count(PActv_Desc) as CC from Project_Activities where Proj_Proj_Id=" & Smart_Project_ID.SelectedValue & " and PActv_Parent =" & Session("tn_id"))
                Dim x As Integer = dt.Rows(0)("CC")
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Child_Actv_Num = " & x + 1 & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Parent = " & Session("tn_id") & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Dim test As String = "select PActv_Parent from Project_Activities where PActv_ID=" & Session("tn_id")
                Dim test_dt As DataTable = Obj_General_Helping.GetDataTable(test)
                If test_dt.Rows(0)("PActv_Parent") = 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set lvl = " & 2 & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set lvl = " & 3 & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtChildPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = '" & Decimal.Parse(txtChildPeriod.Text) & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtChildWight.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & Decimal.Parse(txtChildWight.Text) & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & 0 & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtStartChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtStartChildDate.Text) <> "" Then
                        validated_date = date_validate(txtStartChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Start_Date = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtEndChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtEndChildDate.Text) <> "" Then
                        validated_date = date_validate(txtEndChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_End_Date  = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtChildPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = " & DateTime.ParseExact(txtEndChildDate.Text, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(txtStartChildDate.Text, "dd/MM/yyyy", Nothing)).Days & " where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtActStartChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActStartChildDate.Text) <> "" Then
                        validated_date = date_validate(txtActStartChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_Start_Date = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtActEndChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActEndChildDate.Text) <> "" Then
                        validated_date = date_validate(txtActEndChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_End_Date = '" & validated_date & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If Smart_Search_chorg.SelectedValue <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Excutive_responsible_Org_Org_id = '" & Smart_Search_chorg.SelectedValue & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtChildExPer.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Implementing_person = '" & txtChildExPer.Text & "' where PActv_ID = " & _dt.Rows(0)("LargestPActv_ID"))
                End If

                For index As Integer = 0 To 28
                    If chk_gov_List1.Items(index).Selected = True Then
                        Obj_General_Helping.ExcuteQuery("insert into Project_Activities_gov (activity_id,gov_id) values (" & _dt.Rows(0)("LargestPActv_ID") & "," & chk_gov_List1.Items(index).Value & ")")
                    End If
                Next

                Obj_General_Helping.ExcuteQuery("insert into Project_Activities_Indicators (pactv_pactv_id) values (" & _dt.Rows(0)("LargestPActv_ID") & ")")
                Obj_General_Helping.ExcuteQuery("insert into Activity_sitiuation (project_activity_FK) values (" & _dt.Rows(0)("LargestPActv_ID") & ")")
                If txtChildInd.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Desc = '" & txtChildInd.Text & "' where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtchildUnit.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Unit = '" & txtchildUnit.Text & "' where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If ddlChildInd.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set indt_indt_id = " & ddlChildInd.SelectedIndex & " where pactv_pactv_id =" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If ddlActivSitChild.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set ActStat_ActStat_id = " & ddlActivSitChild.SelectedIndex & " where PActv_ID=" & _dt.Rows(0)("LargestPActv_ID"))
                End If
                If txtChilActvNote.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Activity_sitiuation set actv_sit_desc = '" & txtChilActvNote.Text & "' where project_activity_FK=" & _dt.Rows(0)("LargestPActv_ID"))
                End If

                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"

            Else

                Dim dt1 As New DataTable
                Dim sql1 As String = ""


                'sql1 = "select Parent_Pactv_Desc from Project_Activities where PActv_ID =" & Session("tn_id")
                'dt1 = Obj_General_Helping.GetDataTable(sql1)
                'Obj_General_Helping.ExcuteQuery("update Project_Activities set Parent_Pactv_Desc = '" & dt1.Rows(0)("Parent_Pactv_Desc") & "' where PActv_ID = " & PActv_ID.Value)
                Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Desc = '" & CType(txtChildDesc.Text, String) & "' where PActv_ID = " & PActv_ID.Value)

                'Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Parent = " & Session("tn_id") & " where PActv_ID = " & PActv_ID.Value)
                If txtChildPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = '" & Decimal.Parse(txtChildPeriod.Text) & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtChildWight.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & Decimal.Parse(txtChildWight.Text) & "' where PActv_ID = " & PActv_ID.Value)
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Wieght = '" & 0 & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtStartChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtStartChildDate.Text) <> "" Then
                        validated_date = date_validate(txtStartChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Start_Date = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtEndChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtEndChildDate.Text) <> "" Then
                        validated_date = date_validate(txtEndChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_End_Date  = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtChildPeriod.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Pactv_Period = '" & DateTime.ParseExact(txtEndChildDate.Text, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(txtStartChildDate.Text, "dd/MM/yyyy", Nothing)).Days & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtActStartChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActStartChildDate.Text) <> "" Then
                        validated_date = date_validate(txtActStartChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_Start_Date = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                End If
                If txtActEndChildDate.Text <> "" Then
                    Dim validated_date As String = ""
                    If date_validate(txtActEndChildDate.Text) <> "" Then
                        validated_date = date_validate(txtActEndChildDate.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_End_Date = '" & validated_date & "' where PActv_ID = " & PActv_ID.Value)
                Else
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Actual_End_Date = '' where PActv_ID = " & PActv_ID.Value)
                End If
                If Smart_Search_chorg.SelectedValue <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set Excutive_responsible_Org_Org_id = '" & Smart_Search_chorg.SelectedValue & "' where PActv_ID = " & PActv_ID.Value)
                End If

                Obj_General_Helping.ExcuteQuery("update Project_Activities set PActv_Implementing_person = '" & txtChildExPer.Text & "' where PActv_ID = " & PActv_ID.Value)

                Obj_General_Helping.ExcuteQuery("delete from Project_Activities_gov where activity_id=" & PActv_ID.Value)
                For index As Integer = 0 To 28
                    If chk_gov_List1.Items(index).Selected = True Then
                        Obj_General_Helping.ExcuteQuery("insert into Project_Activities_gov (activity_id,gov_id) values (" & PActv_ID.Value & "," & chk_gov_List1.Items(index).Value & ")")
                    End If
                Next

                If txtChildInd.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Desc = '" & txtChildInd.Text & "' where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If txtchildUnit.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set PAI_Unit = '" & txtchildUnit.Text & "' where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If ddlChildInd.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities_Indicators set indt_indt_id = " & ddlChildInd.SelectedIndex & " where pactv_pactv_id =" & PActv_ID.Value)
                End If
                If ddlActivSitChild.SelectedIndex <> 0 Then
                    Obj_General_Helping.ExcuteQuery("update Project_Activities set ActStat_ActStat_id = " & ddlActivSitChild.SelectedIndex & " where PActv_ID=" & PActv_ID.Value)
                End If
                If txtChilActvNote.Text <> "" Then
                    Obj_General_Helping.ExcuteQuery("update Activity_sitiuation set actv_sit_desc = '" & txtChilActvNote.Text & "' where project_activity_FK=" & PActv_ID.Value)
                End If

                BtnChildSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
            End If
            FillGrid()
            BtnChildSave.Text = "حفــــــظ"
            Clear()
            For index As Integer = 0 To 28
                chk_gov_List1.Items(index).Selected = False
            Next
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If CDataConverter.ConvertToInt(Smart_Project_ID.SelectedValue) > 0 Then
            If Valid() Then
                If BtnSave.CommandArgument = "new" Then
                    SaveDataForClasses()
                Else
                    SaveDataForClasses(PActv_ID.Value)
                End If
                ' FillGrid()
            End If
        Else
            lblPageStatus.Visible = True
            lblPageStatus.Text = "يجب اختيار المشروع أولا"
        End If
    End Sub

    Private Sub BtnChildSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChildSave.Click
        If Valid() Then
            If BtnChildSave.CommandArgument = "new" Then
                SaveChildDataForClasses()
            Else
                SaveChildDataForClasses(PActv_ID.Value)
            End If
            'FillGrid()
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        BtnSave.CommandArgument = "edit"
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False

        Clear()
        Dim _dt As New DataTable
        Dim sql1 As String = "select * from project_Activities where PActv_ID=" & CType(sender, ImageButton).CommandArgument
        _dt = Obj_General_Helping.GetDataTable(sql1)

        If Not _dt.Rows(0)("Parent_PActv_Desc") Is DBNull.Value Then
            txtDesc.Text = _dt.Rows(0)("Parent_PActv_Desc")
        End If

        If Not _dt.Rows(0)("PActv_Wieght") Is DBNull.Value Then
            txtWight.Text = CType(_dt.Rows(0)("PActv_Wieght"), Integer)
        End If

        If Not _dt.Rows(0)("PActv_Period") Is DBNull.Value Then
            txtPeriod.Text = CType(_dt.Rows(0)("PActv_Period"), Integer)
        End If

        If Not _dt.Rows(0)("PActv_Start_Date") Is DBNull.Value Then
            txtStartDate.Text = _dt.Rows(0)("PActv_Start_Date")
        End If

        If Not _dt.Rows(0)("PActv_End_Date") Is DBNull.Value Then
            txtEndDate.Text = _dt.Rows(0)("PActv_End_Date")
        End If
        If Not _dt.Rows(0)("PActv_Actual_Start_Date") Is DBNull.Value Then
            txtActStartDate.Text = _dt.Rows(0)("PActv_Actual_Start_Date")
        End If
        If Not _dt.Rows(0)("PActv_Actual_End_Date") Is DBNull.Value Then
            txtActEndDate.Text = _dt.Rows(0)("PActv_Actual_End_Date")
        End If
        If Not _dt.Rows(0)("ActStat_ActStat_id") Is DBNull.Value Then
            ddlActvSit.SelectedIndex = _dt.Rows(0)("ActStat_ActStat_id")
        End If
        If Not _dt.Rows(0)("PActv_Implementing_person") Is DBNull.Value Then
            txtExPer.Text = _dt.Rows(0)("PActv_Implementing_person")
        End If
        If Not _dt.Rows(0)("Excutive_responsible_Org_Org_id") Is DBNull.Value Then
            Smart_Search_org.SelectedValue = _dt.Rows(0)("Excutive_responsible_Org_Org_id")
        End If

        Dim sql3 As String = "select gov_id from Project_Activities_gov where activity_id=" & _dt.Rows(0)("PActv_ID")
        Dim dt3 As DataTable = Obj_General_Helping.GetDataTable(sql3)
        If dt3.Rows.Count <> 0 Then
            For index As Integer = 0 To dt3.Rows.Count - 1
                chk_gov_list.Items(dt3.Rows(index)("gov_id") - 1).Selected = True
            Next
        End If

        Dim sql As String = ""
        sql = "select * from Project_Activities_Indicators where pactv_pactv_id = " & _dt.Rows(0)("PActv_ID")
        Dim _dt1 As New DataTable
        _dt1 = Obj_General_Helping.GetDataTable(sql)
        If _dt1.Rows.Count <> 0 Then


            If Not _dt1.Rows(0)("PAI_Desc") Is DBNull.Value Then
                txtInd.Text = _dt1.Rows(0)("PAI_Desc")
            End If

            If Not _dt1.Rows(0)("PAI_Unit") Is DBNull.Value Then
                txtUnit.Text = _dt1.Rows(0)("PAI_Unit")
            End If
            If Not _dt1.Rows(0)("PAI_Wieght") Is DBNull.Value Then
                txtIndVal.Text = _dt1.Rows(0)("PAI_Wieght")
            End If
            If Not _dt1.Rows(0)("indt_indt_id") Is DBNull.Value Then
                ddlInd.SelectedValue = _dt1.Rows(0)("indt_indt_id")
            End If

        End If
        Dim sql2 As String = "select * from Activity_sitiuation where project_activity_FK = " & _dt.Rows(0)("PActv_ID")
        Dim dt2 As New DataTable
        dt2 = Obj_General_Helping.GetDataTable(sql2)
        If Not dt2.Rows(0)("actv_sit_desc") Is DBNull.Value Then
            txtActvNote.Text = dt2.Rows(0)("actv_sit_desc")
        End If

        PActv_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("PActv_ID"), HtmlControls.HtmlInputHidden).Value = PActv_ID.Value Then
                id = i
            Else
                gvMain.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next
        gvMain.Rows(id).BackColor = Drawing.Color.Lavender
        BtnSave.Text = "تعديــــل"
        lblPageStatus.Text = ""


    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            lblPageStatus.Visible = False
            lblPageStatus.Text = ""
            Dim Sql As String = "select Project_Activities.* from Project_Activities" _
                    & " join Project on Proj_proj_id = Proj_id" _
                    & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID" _
                    & " where PActv_parent = " & CType(sender, ImageButton).CommandArgument & "  and proj_proj_id=" & Smart_Project_ID.SelectedValue _
                    & " order by Parent_Actv_Num"
            Dim _dt As DataTable = Obj_General_Helping.GetDataTable(Sql)
            If _dt.Rows.Count > 0 Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "عفوا لا يمكن الحذف"
            Else
                'Dim Project_Activities_ENTITY As New BLL.Project_Activities(CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery("DELETE FROM Activity_sitiuation WHERE project_activity_FK =" & CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery("DELETE FROM Project_Activities_Indicators WHERE pactv_pactv_id =" & CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery("delete from Project_Activities_gov where activity_id=" & CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery(" DELETE FROM Project_Activities WHERE PActv_ID=" & CType(sender, ImageButton).CommandArgument)

                'Project_Activities_ENTITY.Delete()
                'lblPageStatus.Visible = True
                'lblPageStatus.Text = "لقد تم الحذف بنجاح"
            End If

            FillGrid()
            gvMain.Visible = True

        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        'DBL.Helper.MergeRows(gvMain)

        Dim i As Integer = 0
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("MainPB"), ProgressBar).MainValue = 100 Then
                'row.BackColor = Drawing.Color.Chartreuse
                'ElseIf CType(gvMain.Rows(i).FindControl("MainPB"), ProgressBar).MainValue > 50 Then
                '    row.BackColor = Drawing.Color.Red
            End If
            i += 1
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

        If GridView.Rows.Count > 1 Then


            For rowIndex As Integer = GridView.Rows.Count - 2 To rowIndex Step -1
                Dim row As GridViewRow = GridView.Rows(rowIndex)
                Dim previousRow As GridViewRow = GridView.Rows(rowIndex + 1)
                For cellIndex As Integer = 1 To 3 'row.Cells.Count - 1

                    If previousRow.Cells(cellIndex).Text = "&nbsp;" Then
                        ' previousRow.BackColor = Drawing.Color.FromArgb(255, 255, 153)
                        previousRow.BackColor = Drawing.Color.FromArgb(204, 235, 255)
                        'previousRow.Cells(12).Visible = False
                        'previousRow.Cells(11).Visible = False
                        previousRow.FindControl("ImgBtnEditChild").Visible = False
                        previousRow.FindControl("ImgBtnDeleteChild").Visible = False
                        previousRow.Cells(1).Visible = False
                    End If
                    If rowIndex = 0 Then
                        'row.BackColor = Drawing.Color.FromArgb(255, 255, 153)
                        row.BackColor = Drawing.Color.FromArgb(204, 235, 255)
                        'row.Cells(12).Visible = False
                        'row.Cells(11).Visible = False
                        row.FindControl("ImgBtnEditChild").Visible = False
                        row.FindControl("ImgBtnDeleteChild").Visible = False
                        row.Cells(1).Visible = False
                    End If
                    If row.Cells(cellIndex).Text = previousRow.Cells(cellIndex).Text And cellIndex = 2 Then
                        row.Cells(cellIndex).RowSpan = CInt(IIf(previousRow.Cells(cellIndex).RowSpan < 2, 2, previousRow.Cells(cellIndex).RowSpan + 1))
                        previousRow.Cells(cellIndex).Visible = False
                        row.Cells(cellIndex).Font.Bold = True
                        row.Cells(cellIndex).Font.Size = 12
                        If previousRow.Cells(cellIndex - 1).Text <> "3" Then
                            previousRow.Cells(cellIndex + 1).Font.Size = 10
                            previousRow.Cells(cellIndex + 1).Font.Bold = True
                            ' previousRow.Cells(0).Visible = False

                        End If



                        'ElseIf cellIndex = 2 And row.Cells(cellIndex).Text = "&nbsp;" Then
                        '    row.BackColor = Drawing.Color.FromArgb(255, 255, 153)
                        '    ' row.Cells(0).Visible = False

                        '    If previousRow.Cells(cellIndex).Text = "&nbsp;" Then
                        '        previousRow.BackColor = Drawing.Color.FromArgb(255, 255, 153)
                        '        '   previousRow.Cells(0).Visible = False

                        '    End If


                    ElseIf cellIndex = 0 And previousRow.Cells(cellIndex).Text = "3" Then
                        previousRow.Cells(cellIndex + 2).Font.Size = 8
                        previousRow.Cells(cellIndex + 2).BackColor = Drawing.Color.White
                        'If previousRow.Cells(cellIndex + 2).Text.StartsWith("-") = False Then
                        '    previousRow.Cells(cellIndex + 2).Text = "-" + previousRow.Cells(cellIndex + 2).Text
                        '    previousRow.Cells(cellIndex + 2).Text = previousRow.Cells(cellIndex + 2).Text.Replace(">", "-  ")
                        'End If

                        '                ' previousRow.Cells(cellIndex).Visible = False
                    End If

                Next
                previousRow.Cells(1).Visible = False

            Next
            GridView.HeaderRow.Cells(1).Visible = False
            'ElseIf GridView.Rows.Count = 1 Then
            ''GridView.HeaderRow.Cells(0).Visible = False
            'Dim row As GridViewRow = GridView.Rows(0)
            '' row.BackColor = Drawing.Color.FromArgb(255, 255, 153)
            ''row.Cells(0).Visible = False
            ''row.Cells(10).Visible = False
            ''row.Cells(11).Visible = False
        ElseIf GridView.Rows.Count = 1 Then
            GridView.HeaderRow.Cells(1).Visible = False
            GridView.Rows(0).Cells(1).Visible = False
            GridView.Rows(0).FindControl("ImgBtnEditChild").Visible = False
            GridView.Rows(0).FindControl("ImgBtnDeleteChild").Visible = False
            GridView.Rows(0).Cells(2).Font.Bold = True
            GridView.Rows(0).Cells(2).Font.Size = 12
            GridView.Rows(0).BackColor = Drawing.Color.FromArgb(204, 235, 255)
        End If

    End Sub

    Private Sub RblActType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblActType.SelectedIndexChanged
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""
        Clear()
        If RblActType.SelectedValue = 0 Then
            tblSecAct.Visible = False
            gvSub.Visible = False
            tblMainActv.Visible = True
            gvMain.Visible = True
        Else
            tblSecAct.Visible = True
            gvSub.Visible = True
            tblMainActv.Visible = False
            gvMain.Visible = False

            FillDDL()

        End If
        FillGrid()
    End Sub

    Protected Sub ImgBtnEditChild_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnChildSave.CommandArgument = "edit"
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Clear()
        Dim _dt As New DataTable
        Dim sql1 As String = "select *  from project_Activities where PActv_ID=" & CType(sender, ImageButton).CommandArgument
        _dt = Obj_General_Helping.GetDataTable(sql1)


        If Not _dt.Rows(0)("Parent_PActv_Desc") Is DBNull.Value Then
            'txtActvSit.Text = _dt.Rows(0)("PActv_Parent")
            parent_activ.Text = _dt.Rows(0)("Parent_PActv_Desc")
        End If

        If Not _dt.Rows(0)("PActv_Desc") Is DBNull.Value Then
            txtChildDesc.Text = _dt.Rows(0)("PActv_Desc")
        End If

        If Not _dt.Rows(0)("PActv_Wieght") Is DBNull.Value Then
            txtChildWight.Text = CType(_dt.Rows(0)("PActv_Wieght"), Integer)
        End If

        If Not _dt.Rows(0)("PActv_Period") Is DBNull.Value Then
            txtChildPeriod.Text = CType(_dt.Rows(0)("PActv_Period"), Integer)
        End If

        If Not _dt.Rows(0)("PActv_Start_Date") Is DBNull.Value Then
            txtStartChildDate.Text = _dt.Rows(0)("PActv_Start_Date")
        End If

        If Not _dt.Rows(0)("PActv_End_Date") Is DBNull.Value Then
            txtEndChildDate.Text = _dt.Rows(0)("PActv_End_Date")
        End If
        If Not _dt.Rows(0)("PActv_Actual_Start_Date") Is DBNull.Value Then
            txtActStartChildDate.Text = _dt.Rows(0)("PActv_Actual_Start_Date")
        End If
        If Not _dt.Rows(0)("PActv_Actual_End_Date") Is DBNull.Value Then
            txtActEndChildDate.Text = _dt.Rows(0)("PActv_Actual_End_Date")
        End If
        If Not _dt.Rows(0)("ActStat_ActStat_id") Is DBNull.Value Then
            ddlActivSitChild.SelectedIndex = _dt.Rows(0)("ActStat_ActStat_id")
        End If
        If Not _dt.Rows(0)("PActv_Implementing_person") Is DBNull.Value Then
            txtChildExPer.Text = _dt.Rows(0)("PActv_Implementing_person")
        End If
        If Not _dt.Rows(0)("Excutive_responsible_Org_Org_id") Is DBNull.Value Then
            Smart_Search_chorg.SelectedValue = _dt.Rows(0)("Excutive_responsible_Org_Org_id")
        End If

        Dim sql3 As String = "select gov_id from Project_Activities_gov where activity_id=" & _dt.Rows(0)("PActv_ID")
        Dim dt3 As DataTable = Obj_General_Helping.GetDataTable(sql3)
        If dt3.Rows.Count <> 0 Then
            For index As Integer = 0 To dt3.Rows.Count - 1
                chk_gov_List1.Items(dt3.Rows(index)("gov_id") - 1).Selected = True
            Next
        End If

        Dim sql As String = ""
        sql = "select * from Project_Activities_Indicators where pactv_pactv_id = " & _dt.Rows(0)("PActv_ID")
        Dim _dt1 As New DataTable
        _dt1 = Obj_General_Helping.GetDataTable(sql)
        If _dt1.Rows.Count <> 0 Then
            If Not _dt1.Rows(0)("PAI_Desc") Is DBNull.Value Then
                txtChildInd.Text = _dt1.Rows(0)("PAI_Desc")
            End If

            If Not _dt1.Rows(0)("PAI_Unit") Is DBNull.Value Then
                txtchildUnit.Text = _dt1.Rows(0)("PAI_Unit")
            End If

            If Not _dt1.Rows(0)("indt_indt_id") Is DBNull.Value Then
                ddlChildInd.SelectedValue = _dt1.Rows(0)("indt_indt_id")
            End If
        End If
        Dim sql2 As String = "select * from Activity_sitiuation where project_activity_FK = " & _dt.Rows(0)("PActv_ID")
        Dim dt2 As New DataTable
        dt2 = Obj_General_Helping.GetDataTable(sql2)
        If Not dt2.Rows(0)("actv_sit_desc") Is DBNull.Value Then
            txtChilActvNote.Text = dt2.Rows(0)("actv_sit_desc")
        End If

        PActv_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvSub.Rows
            If CType(gvSub.Rows(i).FindControl("PActv_ID"), HtmlControls.HtmlInputHidden).Value = PActv_ID.Value Then
                id = i
            Else
                gvSub.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next
        gvSub.Rows(id).BackColor = Drawing.Color.Lavender
        BtnChildSave.Text = "تعديــــل"
        lblPageStatus.Text = ""

    End Sub

    Protected Sub ImgBtnDeleteChild_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            '''''''''''''
            lblPageStatus.Visible = False
            lblPageStatus.Text = ""
            Dim Sql As String = "select Project_Activities.* from Project_Activities" _
                    & " join Project on Proj_proj_id = Proj_id" _
                    & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID" _
                    & " where PActv_parent = " & CType(sender, ImageButton).CommandArgument & "  and proj_proj_id=" & Smart_Project_ID.SelectedValue _
                    & " order by Parent_Actv_Num"
            Dim _dt As DataTable = Obj_General_Helping.GetDataTable(Sql)
            If _dt.Rows.Count > 0 Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "عفوا لا يمكن الحذف"
            Else
                'Dim Project_Activities_ENTITY As New BLL.Project_Activities(CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery("DELETE FROM Activity_sitiuation WHERE project_activity_FK =" & CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery("DELETE FROM Project_Activities_Indicators WHERE pactv_pactv_id =" & CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery("delete from Project_Activities_gov where activity_id=" & CType(sender, ImageButton).CommandArgument)
                Obj_General_Helping.ExcuteQuery(" DELETE FROM Project_Activities WHERE PActv_ID=" & CType(sender, ImageButton).CommandArgument)


                'Project_Activities_ENTITY.Delete()
                'lblPageStatus.Visible = True
                'lblPageStatus.Text = "لقد تم الحذف بنجاح"
            End If

            FillGrid()
            gvSub.Visible = True
            ''''''''''''
          
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = CType(sender.parent.parent.FindControl("PActv_ID"), HtmlControls.HtmlInputHidden).Value
        Response.Redirect("../WebForms/Project_Activities_All.aspx?pactv_id=" & id)
    End Sub


#End Region




    Protected Sub txtWight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtWight.TextChanged
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""
        If txtWight.Text.Length > 0 Then
            If txtWight.Text = 0 Then
                ddlActvSit.SelectedIndex = 1
            ElseIf txtWight.Text > 0 And txtWight.Text < 100 Then
                ddlActvSit.SelectedIndex = 2
            ElseIf txtWight.Text = 100 Then
                ddlActvSit.SelectedIndex = 3
            End If
            If txtWight.Text > 100 Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "ادخل النسبة بين 0 و 100"
                Return
            End If
        End If
    End Sub

    Protected Sub txtChildWight_textChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtChildWight.TextChanged
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""
        If txtChildWight.Text.Length > 0 Then
            If txtChildWight.Text = 0 Then
                ddlActivSitChild.SelectedIndex = 1
            ElseIf txtChildWight.Text > 0 And txtChildWight.Text < 100 Then
                ddlActivSitChild.SelectedIndex = 2
            ElseIf txtChildWight.Text = 100 Then
                ddlActivSitChild.SelectedIndex = 3
            End If
            If txtChildWight.Text > 100 Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "ادخل النسبة بين 0 و 100"
                Return
            End If
        End If
    End Sub



    Protected Sub ddlActvSit_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlActvSit.SelectedIndexChanged
        If ddlActvSit.SelectedIndex = 1 Then
            txtWight.Text = 0
        End If
        If ddlActvSit.SelectedIndex = 3 Then
            txtWight.Text = 100
        End If
        If ddlActvSit.SelectedIndex = 0 Then
            txtWight.Text = ""
        End If
        If ddlActvSit.SelectedIndex = 2 Then
            txtWight.Text = ""
        End If

    End Sub

    Protected Sub ddlActivSitChild_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlActivSitChild.SelectedIndexChanged
        If ddlActivSitChild.SelectedIndex = 1 Then
            txtChildWight.Text = 0
        End If
        If ddlActivSitChild.SelectedIndex = 3 Then
            txtChildWight.Text = 100
        End If
        If ddlActivSitChild.SelectedIndex = 0 Then
            txtChildWight.Text = ""
        End If
        If ddlActivSitChild.SelectedIndex = 2 Then
            txtChildWight.Text = ""
        End If
    End Sub



    Protected Sub txtStartDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStartDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        'Dim test_string As String = date_validate(txtStartDate.Text)
        If date_validate(txtStartDate.Text) <> "" Then
            txtStartDate.Text = date_validate(txtStartDate.Text)
            validated_date = date_validate(txtStartDate.Text)
            lblPageStatus.Visible = False
            If txtEndDate.Text <> "" Then
                If date_validate(txtEndDate.Text) <> "" Then
                    If Date_compare(date_validate(txtEndDate.Text), validated_date) = False Then
                        lblPageStatus.Text = "تاريخ البداية  يجب أن يكون قبل تاريخ النهاية "
                        lblPageStatus.Visible = True
                        txtEndDate.Text = ""
                        Return
                    End If

                    txtPeriod.Text = CType(DateTime.ParseExact(date_validate(txtEndDate.Text), "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing)).Days, String)

                End If

            ElseIf txtEndDate.Text = "" And txtPeriod.Text <> "" Then
                txtEndDate.Text = DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing).AddDays(1 * (Decimal.Parse(txtPeriod.Text))).ToString("dd/MM/yyyy")
            End If
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtStartDate.Text = ""
            Return
        End If
    End Sub

    Protected Sub txtEndDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtEndDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtEndDate.Text) <> "" Then
            txtEndDate.Text = date_validate(txtEndDate.Text)
            validated_date = date_validate(txtEndDate.Text)

            lblPageStatus.Text = ""
            lblPageStatus.Visible = False
            If txtStartDate.Text <> "" Then
                If date_validate(txtStartDate.Text) <> "" Then
                    If Date_compare(date_validate(txtStartDate.Text), validated_date) = True Then
                        lblPageStatus.Text = "تاريخ البداية  يجب أن يكون قبل تاريخ النهاية "
                        lblPageStatus.Visible = True
                        txtEndDate.Text = ""
                        Return
                    End If

                    txtPeriod.Text = CType(DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(date_validate(txtStartDate.Text), "dd/MM/yyyy", Nothing)).Days, String)

                End If

            ElseIf txtStartDate.Text = "" And txtPeriod.Text <> "" Then
                txtStartDate.Text = DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing).AddDays(-1 * (Decimal.Parse(txtPeriod.Text))).ToString("dd/MM/yyyy")
            End If
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtEndDate.Text = ""
            Return
        End If
    End Sub

    Protected Sub txtPeriod_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPeriod.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If txtStartDate.Text <> "" And txtPeriod.Text <> "" Then
            If date_validate(txtStartDate.Text) <> "" Then
                Dim str As String = date_validate(txtStartDate.Text)
                txtEndDate.Text = DateTime.ParseExact(str, "dd/MM/yyyy", Nothing).AddDays(Decimal.Parse(txtPeriod.Text)).ToString("dd/MM/yyyy")
            End If
        End If
        If txtStartDate.Text = "" And txtEndDate.Text <> "" And txtPeriod.Text <> "" Then
            If date_validate(txtEndDate.Text) <> "" Then
                Dim str As String = date_validate(txtEndDate.Text)
                txtStartDate.Text = DateTime.ParseExact(str, "dd/MM/yyyy", Nothing).AddDays(-1 * (Decimal.Parse(txtPeriod.Text))).ToString("dd/MM/yyyy")
            End If
        End If
       
        'If txtPeriod.Text = "" And txtStartDate.Text <> "" And txtEndDate.Text <> "" Then
        '    txtPeriod.Text = CType(DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", Nothing)).Days, String)
        'End If

    End Sub

    Protected Sub txtStartChildDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStartChildDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtStartChildDate.Text) <> "" Then
            txtStartChildDate.Text = date_validate(txtStartChildDate.Text)
            validated_date = date_validate(txtStartChildDate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtStartChildDate.Text = ""
            Return
        End If
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If parent_activ.Text <> "" Then
            If txtEndChildDate.Text <> "" Then
                If date_validate(txtEndChildDate.Text) <> "" Then
                    If Date_compare(date_validate(txtEndChildDate.Text), validated_date) = False Then
                        lblPageStatus.Text = "تاريخ البداية يجب أن يكون قبل تاريخ النهاية "
                        lblPageStatus.Visible = True
                        txtStartChildDate.Text = ""
                        Return
                    End If

                    txtChildPeriod.Text = CType(DateTime.ParseExact(date_validate(txtEndChildDate.Text), "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing)).Days, String)

                End If

            ElseIf txtEndChildDate.Text = "" And txtChildPeriod.Text <> "" Then
                txtEndChildDate.Text = DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing).AddDays(1 * (Decimal.Parse(txtChildPeriod.Text))).ToString("dd/MM/yyyy")
            End If
        Else
            lblPageStatus.Text = "اختر نشاط رئيسى أولا"
            lblPageStatus.Visible = True
            txtStartChildDate.Text = ""
            Return
        End If
    End Sub

    Protected Sub txtEndChildDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtEndChildDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtEndChildDate.Text) <> "" Then
            txtEndChildDate.Text = date_validate(txtEndChildDate.Text)
            validated_date = date_validate(txtEndChildDate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtEndChildDate.Text = ""
            Return
        End If
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If parent_activ.Text <> "" Then
            If txtStartChildDate.Text <> "" Then
                If date_validate(txtStartChildDate.Text) <> "" Then
                    If Date_compare(date_validate(txtStartChildDate.Text), validated_date) = True Then
                        lblPageStatus.Text = "تاريخ البداية  يجب أن يكون قبل تاريخ النهاية "
                        lblPageStatus.Visible = True
                        txtEndChildDate.Text = ""
                        Return
                    End If

                    txtChildPeriod.Text = CType(DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(date_validate(txtStartChildDate.Text), "dd/MM/yyyy", Nothing)).Days, String)

                End If

            ElseIf txtStartChildDate.Text = "" And txtChildPeriod.Text <> "" Then
                txtStartChildDate.Text = DateTime.ParseExact(validated_date, "dd/MM/yyyy", Nothing).AddDays(-1 * (Decimal.Parse(txtChildPeriod.Text))).ToString("dd/MM/yyyy")
            End If

        Else
            lblPageStatus.Text = "اختر نشاط رئيسى أولا"
            lblPageStatus.Visible = True
            txtEndChildDate.Text = ""
            Return
        End If
    End Sub

    Protected Sub txtChildPeriod_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtChildPeriod.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
       
        If txtStartChildDate.Text <> "" And txtChildPeriod.Text <> "" Then
            If date_validate(txtStartChildDate.Text) <> "" Then
                Dim str As String = date_validate(txtStartChildDate.Text)
                txtEndChildDate.Text = DateTime.ParseExact(str, "dd/MM/yyyy", Nothing).AddDays(Decimal.Parse(txtChildPeriod.Text)).ToString("dd/MM/yyyy")
            End If
        End If
        If txtStartChildDate.Text = "" And txtEndChildDate.Text <> "" And txtChildPeriod.Text <> "" Then
            If date_validate(txtEndChildDate.Text) <> "" Then
                Dim str As String = date_validate(txtEndChildDate.Text)
                txtStartChildDate.Text = DateTime.ParseExact(str, "dd/MM/yyyy", Nothing).AddDays(-1 * (Decimal.Parse(txtChildPeriod.Text))).ToString("dd/MM/yyyy")
            End If
        End If
        'If txtChildPeriod.Text = "" And txtStartChildDate.Text <> "" And txtEndChildDate.Text <> "" Then
        '    txtChildPeriod.Text = CType(DateTime.ParseExact(txtEndChildDate.Text, "dd/MM/yyyy", Nothing).Subtract(DateTime.ParseExact(txtStartChildDate.Text, "dd/MM/yyyy", Nothing)).Days, String)
        'End If
    End Sub



    Protected Sub txtChildDesc_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtChildDesc.TextChanged
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""
    End Sub

    Protected Sub txtActStartDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtActStartDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtActStartDate.Text) <> "" Then
            txtActStartDate.Text = date_validate(txtActStartDate.Text)
            validated_date = date_validate(txtActStartDate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtActStartDate.Text = ""
            Return
        End If
        If txtActEndDate.Text <> "" Then
            If date_validate(txtActEndDate.Text) <> "" Then
                If Date_compare(date_validate(txtActEndDate.Text), validated_date) = False Then
                    lblPageStatus.Text = "تاريخ البداية الفعلى يجب أن يكون قبل تاريخ النهاية الفعلى"
                    lblPageStatus.Visible = True
                    txtActStartDate.Text = ""
                End If
            End If
        End If

    End Sub

    Protected Sub txtActEndDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtActEndDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtActEndDate.Text) <> "" Then
            txtActEndDate.Text = date_validate(txtActEndDate.Text)
            validated_date = date_validate(txtActEndDate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtActEndDate.Text = ""
            Return
        End If
        If txtActStartDate.Text <> "" Then
            If date_validate(txtActStartDate.Text) <> "" Then
                If Date_compare(date_validate(txtActStartDate.Text), validated_date) = True Then
                    lblPageStatus.Text = "تاريخ البداية الفعلى يجب أن يكون قبل تاريخ النهاية الفعلى"
                    lblPageStatus.Visible = True
                    txtActEndDate.Text = ""
                End If
            End If
        End If

    End Sub

    Protected Sub txtActStartChildDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtActStartChildDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtActStartChildDate.Text) <> "" Then
            txtActStartChildDate.Text = date_validate(txtActStartChildDate.Text)
            validated_date = date_validate(txtActStartChildDate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtActStartChildDate.Text = ""
            Return
        End If

        If txtActEndChildDate.Text <> "" Then
            If date_validate(txtActEndChildDate.Text) <> "" Then
                If Date_compare(date_validate(txtActEndChildDate.Text), validated_date) = False Then
                    lblPageStatus.Text = "تاريخ البداية الفعلى يجب أن يكون قبل تاريخ النهاية الفعلى"
                    lblPageStatus.Visible = True
                    txtActStartChildDate.Text = ""
                End If
            End If
        End If





    End Sub

    Protected Sub txtActEndChildDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtActEndChildDate.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        Dim validated_date As String = ""
        If date_validate(txtActEndChildDate.Text) <> "" Then
            txtActEndChildDate.Text = date_validate(txtActEndChildDate.Text)
            validated_date = date_validate(txtActEndChildDate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            txtActEndChildDate.Text = ""
            Return
        End If

        If txtActStartChildDate.Text <> "" Then
            If date_validate(txtActStartChildDate.Text) <> "" Then
                If Date_compare(date_validate(txtActStartChildDate.Text), validated_date) = True Then
                    lblPageStatus.Text = "تاريخ البداية الفعلى يجب أن يكون قبل تاريخ النهاية الفعلى"
                    lblPageStatus.Visible = True
                    txtActEndChildDate.Text = ""
                End If
            End If
        End If
    End Sub

#Region "TreeView Actions"
    Private Sub PopulateRootLevel(ByVal Proj_id As Integer)

        Dim dt As New DataTable()
        Dim sql As String = ""
        sql = "select PActv_ID,Parent_PActv_Desc,Parent_Actv_Num,(select count(*) FROM Project_Activities " _
              & "WHERE PActv_Parent=PA.PActv_ID) childnodecount FROM Project_Activities PA where PActv_Parent = 0 and proj_proj_id = " & Proj_id _
              & " order by Parent_Actv_Num"
        dt = Obj_General_Helping.GetDataTable(sql)
        Nroot = True
        TreeView1.Nodes.Clear()
        PopulateNodes(dt, TreeView1.Nodes)

    End Sub

    Private Sub PopulateSubLevel(ByVal parentid As Integer, ByVal parentNode As TreeNode)

        'If Obj_General_Helping.OpenConnection() Then
        Dim dt As New DataTable()
        Dim sql As String = ""
        sql = "select PActv_ID,pactv_desc,PActv_Parent,Child_Actv_Num,(select count(*) FROM Project_Activities " _
            & "WHERE PActv_Parent=PA.PActv_ID) childnodecount FROM Project_Activities PA where PActv_Parent = " & parentid _
            & " order by PActv_Parent,Child_Actv_Num"
        dt = Obj_General_Helping.GetDataTable(sql)
        Nroot = False
        PopulateNodes(dt, parentNode.ChildNodes)
        'End If
    End Sub

    Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)

        If Nroot = True Then
            If dt.Rows.Count <> 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim tn As New TreeNode()
                    tn.Text = dr("Parent_PActv_Desc").ToString()
                    tn.Value = dr("PActv_ID").ToString()
                    nodes.Add(tn)

                    'If node has child nodes, then enable on-demand populating
                    tn.PopulateOnDemand = (CInt(dr("childnodecount")) > 0)
                Next
            Else
                TreeView1.Nodes.Clear()
            End If

        Else
            If dt.Rows.Count <> 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim tn As New TreeNode()
                    tn.Text = dr("pactv_desc").ToString()
                    tn.Value = dr("PActv_ID").ToString()
                    nodes.Add(tn)

                    'If node has child nodes, then enable on-demand populating
                    tn.PopulateOnDemand = (CInt(dr("childnodecount")) > 0)
                Next
            Else
                TreeView1.Nodes.Clear()
            End If
        End If
    End Sub

    Protected Sub TreeView1_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles TreeView1.TreeNodePopulate
        PopulateSubLevel(CInt(e.Node.Value), e.Node)
    End Sub


#End Region


    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.SelectedNodeChanged

        If TreeView1.SelectedNode.Selected = True Then
            'For Each temp_tn As TreeNode In TreeView1.Nodes
            '    If TreeView1.Nodes.IndexOf(temp_tn) = tn Then
            '        temp_tn.Checked = True
            '    Else
            '        temp_tn.Checked = False
            '    End If
            'Next
            tn = TreeView1.SelectedNode.Value
            parent_activ.Text = TreeView1.SelectedNode.Text
            Session("tn_id") = tn
        End If

    End Sub
End Class