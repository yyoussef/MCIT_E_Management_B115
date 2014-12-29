Imports System.Globalization
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class WebForms_Project_needs
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS



#Region "Variables"
    Dim Project_Needs_ENTITY As New BLL.Project_Needs
    Dim need_sub_type As New BLL.Needs_Sup_Type
    Dim Obj_General_Helping As New General_Helping

    Dim sql_Connection As String = Database.ConnectionString
#End Region

#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)



        Smart_Search_mn.sql_Connection = sql_Connection
        Smart_Search_mn.Text_Field = "NMT_Desc "
        Smart_Search_mn.Value_Field = "NMT_Id "
        Dim Query As String
        Query = "select NMT_Desc,NMT_Id from Needs_main_type"
        Smart_Search_mn.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_mn.DataBind()
        AddHandler Me.Smart_Search_mn.Value_Handler, AddressOf Smart_Search_mn_Selected

        MyBase.OnInitComplete(e)



    End Sub

#End Region

#Region "event handel"

    Private Sub Smart_Search_mn_Selected(ByVal Value As String)
        'DDLJobCat.SelectedValue = Value
        'job_index_changed()
        ' Me.DataBind()
        Smart_Search_sp.Text_Field = "NST_Desc "
        Smart_Search_sp.Value_Field = "NST_Id  "
        Smart_Search_sp.sql_Connection = sql_Connection
        Dim Query As String
        Query = "select NST_Id ,NST_Desc  from Needs_Sup_Type where nmt_nmt_id =" & Value
        Smart_Search_sp.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_sp.DataBind()

        If Smart_Search_sp.Items_Count = 0 Then
            Smart_Search_sp.Clear_Controls()
        End If
    End Sub
    'Private Sub main_index_changed()
    '    If ddlMainCat.SelectedIndex <> 0 Then
    '        Dim dt As DataTable = General_Helping.GetDataTable("select NST_Desc,NST_Id from Needs_Sup_Type where nmt_nmt_id=" & ddlMainCat.SelectedValue)
    '        Obj_General_Helping.SmartBindDDL(ddlSubCat, dt, "NST_ID", "NST_Desc", "....اختر نوع الاحتياج الفرعى....")

    '    Else

    '        ddlSubCat.Items.Clear()
    '        ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")
    '    End If
    'End Sub
#End Region

#Region "Load"
    Dim rowindeces As New List(Of Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_request_DT.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertDateTimeNowRtnDt())
            GenerateTree()
            'ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)
            FillGrid()
            FillDDls()
            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region


#Region "Clear"
    Private Sub Clear()
        txtItem.Text = ""
        txtAmount.Text = ""
        txtdate.Text = ""
        txtInitialValue.Text = ""
        txtItemDesc.Text = ""
        chkBoxAll.Checked = False
        For Each gvrw As GridViewRow In gvActivities.Rows

            Dim actv_chek As CheckBox = gvrw.FindControl("chkboxRow")

            actv_chek.Checked = False

        Next
    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txtAmount.Text = "" Or String.IsNullOrEmpty(Smart_Search_mn.SelectedValue) Or txtItem.Text = "" Or String.IsNullOrEmpty(Smart_Search_sp.SelectedValue) Then
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
    Private Sub GenerateTree()

        Dim dt As DataTable
        dt = activityLeveling.ActivLevls.leveling(CDataConverter.ConvertToInt(Session_CS.Project_id), 0, 0, 0, 0)

        gvActivities.DataSource = dt
        gvActivities.DataBind()

    End Sub
    Private Sub FillGrid()



        Dim sql As String = ""
        sql = "select * ,convert(varchar(20), convert(money, PNed_InitValue), 1) as moneyv" _
        & " ,convert(varchar(20), convert(money, (Project_Needs.PNed_Number)*(Project_Needs.PNed_InitValue)), 1) as multiply_money_integer " _
        & " from Project_Needs  join project on Project_Needs.proj_proj_id = Proj_id " _
        & " join Needs_Sup_Type on Project_Needs.nst_nst_id = nst_ID " _
        & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = NMT_ID where proj_proj_id=" & Session_CS.Project_id _
        & " order by NMT_Desc,NST_Desc,PNed_ID"
        Dim dt1 As New DataTable
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()
        dt1 = General_Helping.GetDataTable(sql)
        Dim sql1 As String = ""
        sql1 = "SELECT PNed_InitValue,PNed_Number FROM Project_Needs where proj_proj_id=" & Session_CS.Project_id
        Dim dt As New DataTable
        dt = General_Helping.GetDataTable(sql1)
        If dt.Rows.Count > 0 Then
            Dim i As Integer = 0
            Dim total_needs As Double
            For Each row As DataRow In dt.Rows
                If Not dt.Rows(i)("PNed_InitValue") Is DBNull.Value And Not dt.Rows(i)("PNed_Number") Is DBNull.Value Then
                    total_needs += Double.Parse(dt.Rows(i)("PNed_InitValue")) * Double.Parse(dt.Rows(i)("PNed_Number"))
                End If
                i += 1
            Next
            If dt1.Rows.Count > 0 Then


                If total_needs > Double.Parse(dt1.Rows(0)("Proj_InitValue")) Then
                    lblPageStatus.Text = "اجمالى الاحتياجات يتخطى ميزانيه المشروع"
                    lblPageStatus.Visible = True
                    lblTotalNeedsCalc.Text = total_needs.ToString
                    totalNeeds.Visible = True
                    Return
                End If
            End If

            lblTotalNeedsCalc.Text = total_needs.ToString("#,###.00")
            totalNeeds.Visible = True
        End If
    End Sub
    Private Sub FillDDls()
        Dim dtime As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
        Dim currentYear As String = dtime.ToString("yyyy")
        Dim currentYearInt As Integer
        currentYearInt = Convert.ToInt16(currentYear)
        Dim dt5 As New DataTable
        Dim cMonth As Integer = CDataConverter.ConvertDateTimeNowRtnDt().Month
        If cMonth < 7 Then
            currentYearInt = currentYearInt - 1
        End If
        currentYear = currentYearInt.ToString()

        Dim sql As String = "SELECT     Project_Funding_Sources.Sources_ID, Project_Funding_Sources.Source_Name " _
                            & "FROM         Project_Funding_Sources INNER JOIN " _
                            & "Project_Period_Sources ON Project_Funding_Sources.Sources_ID = Project_Period_Sources.Sources_ID INNER JOIN " _
                            & "Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID " _
                            & "WHERE     (Project_Period_Balance.Proj_id = " & Session_CS.Project_id & ") AND (Project_Period_Balance.Quarter_Year = '" & currentYear & "') " _
                            & "GROUP BY Project_Funding_Sources.Sources_ID, Project_Funding_Sources.Source_Name"
        dt5 = General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(ddl_Source, dt5, "Sources_ID", "Source_Name", "....اختر مصدر التمويل......")
    End Sub
    Public Sub GetDataSetProvider(ByVal ID As String)
        Dim qryStr As String = ""
        Dim qrtrData As DataTable
        Dim dtime As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
        Dim currentYear As String = dtime.ToString("yyyy")
        Dim currentYearInt As Integer
        currentYearInt = Convert.ToInt16(currentYear)
        Dim dt5 As New DataTable
        Dim cMonth As Integer = CDataConverter.ConvertDateTimeNowRtnDt().Month
        If cMonth < 7 Then
            currentYearInt = currentYearInt - 1
        End If
        currentYear = currentYearInt.ToString()
        Dim sql As String
        sql = "SELECT     Project_Period_Sources.Provider_ID " _
                           & "FROM         Project_Funding_Sources INNER JOIN " _
                           & "Project_Period_Sources ON Project_Funding_Sources.Sources_ID = Project_Period_Sources.Sources_ID INNER JOIN " _
                           & "Project_Period_Balance ON Project_Period_Sources.Period_ID = Project_Period_Balance.Period_ID " _
                           & "WHERE     (Project_Period_Balance.Proj_id = " & Session_CS.Project_id & ") AND (Project_Period_Balance.Quarter_Year = '" & currentYear & "') " _
                           & " AND (Project_Funding_Sources.Sources_ID = " & ID.ToString() & ")" _
                           & "GROUP BY Provider_ID"


        Select Case ID   ' Evaluate Number.
            Case 1
                qryStr = "SELECT  0.00 as Value, 1 as Provider_ID,'بنك الإستثمار القومى' as Provider_Name"
            Case 2
                qryStr = "SELECT 0.00 as Value, [Loan_ID] as Provider_ID,[Loan_Name] as Provider_Name FROM [Loans] where Loan_ID in (" & sql & ")"
            Case 3
                qryStr = "select 0.00 as Value, Org_ID as Provider_ID, Org_Desc as Provider_Name from Project_Organization " _
                & " join Project on Proj_proj_id = Proj_id" _
                & " join Organization on org_org_id = org_id" _
                & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where  Proj_proj_id=" & Session_CS.Project_id & " AND Org_ID in (" & sql & ")"
            Case 4
                qryStr = "select 0.00 as Value, Protocol_ID as Provider_ID,Name as Provider_Name FROM Protocol_Def where Type=2 AND Protocol_ID in (" & sql & ")"
        End Select

        qrtrData = General_Helping.GetDataTable(qryStr)
        ddl_Provider.DataSource = qrtrData
        ddl_Provider.DataBind()
        'Obj_General_Helping.SmartBindDDL(ddl_Provider, qrtrData, "Provider_ID", "Provider_Name", "....اختر....")
    End Sub
    Private Sub FillLog(Optional ByVal ID As Integer = 0)
        Try



            Dim dtnow As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            Dim dateNow As String = dtnow.ToString("d")
            Dim recordID As String
            If ID = 0 Then
                Dim sql As String = ""
                Dim _dt As New DataTable

                sql = " select max(PNed_ID) as recordID from Project_Needs "
                _dt = General_Helping.GetDataTable(sql)


                If _dt.Rows.Count > 0 Then
                    recordID = _dt.Rows(0)("recordID").ToString()

                    Project_Log_DB.FillLog(recordID, Project_Log_DB.Action.add, Project_Log_DB.operation.Project_Needs_Request)
                End If

            Else
                recordID = ID.ToString()
                Project_Log_DB.FillLog(recordID, Project_Log_DB.Action.edit, Project_Log_DB.operation.Project_Needs_Request)

            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try
            If ID = 0 Then
                FillGrid()

                If txtAmount.Text <> Nothing Then
                    If txtAmount.Text = 0 Then
                        lblPageStatus.Text = "الكمية المطلوبة لايمكن أن تساوى 0"
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If

                Dim validated_date As String = ""
                If txtdate.Text <> "" Then


                    If txtdate.Text <> "" Then
                        validated_date = txtdate.Text
                        'If VB_Classes.Dates.date_validate(txtdate.Text) <> "" Then
                        '    validated_date = VB_Classes.Dates.date_validate(txtdate.Text)

                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If


                Dim validated_date_request As String = ""
                If txt_request_DT.Text <> "" Then


                    If txt_request_DT.Text <> "" Then
                        validated_date_request = txt_request_DT.Text

                        'If VB_Classes.Dates.date_validate(txt_request_DT.Text) <> "" Then
                        '    validated_date_request = VB_Classes.Dates.date_validate(txt_request_DT.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If

                Dim sql1 As String = ""
                Dim dt As New DataTable
                Dim _dt As New DataTable
                General_Helping.ExcuteQuery("insert into Project_Needs (Proj_Proj_Id) values(" & Session_CS.Project_id & ")")
                sql1 = "SELECT MAX(PNed_ID) AS LargestPNed_ID FROM Project_Needs"
                dt = General_Helping.GetDataTable(sql1)
                General_Helping.ExcuteQuery("update Project_Needs set Nst_Nst_Id = " & Smart_Search_sp.SelectedValue & " where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Number = " & CDataConverter.ConvertToInt(txtAmount.Text) & " where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Name = '" & txtItem.Text & "' where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                General_Helping.ExcuteQuery("update Project_Needs set PNed_desc = '" & txtItemDesc.Text & "' where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Date = '" & validated_date & "' , Request_DT = '" & validated_date_request & "'  where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Initvalue = " & CDataConverter.ConvertToDecimal(txtInitialValue.Text) & " where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))


                If CDataConverter.ConvertToInt(ddl_Source.SelectedValue) > 0 Then
                    General_Helping.ExcuteQuery("update Project_Needs set Sources_ID = " & CDataConverter.ConvertToInt(ddl_Source.SelectedValue) & " where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                End If
                If CDataConverter.ConvertToInt(ddl_Provider.SelectedValue) > 0 Then
                    General_Helping.ExcuteQuery("update Project_Needs set Provider_ID = " & CDataConverter.ConvertToInt(ddl_Provider.SelectedValue) & " where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                End If
                _dt = General_Helping.GetDataTable("select count(PNed_ID) as CC from Project_Needs where Proj_Proj_Id=" & Session_CS.Project_id)
                Dim x As Integer = _dt.Rows(0)("CC")
                General_Helping.ExcuteQuery("update Project_Needs set need_Serial = " & x & " where PNed_ID = " & dt.Rows(0)("LargestPNed_ID"))
                General_Helping.ExcuteQuery("delete from activities_Needs_relationship where need_id=" & dt.Rows(0)("LargestPNed_ID"))
                If gvActivities.Rows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To gvActivities.Rows.Count - 1
                        Dim Chkbox As CheckBox
                        Dim actv_id_box As TextBox
                        Chkbox = gvActivities.Rows(i).FindControl("chkboxRow")
                        actv_id_box = gvActivities.Rows(i).FindControl("txtPActv_ID")
                        If Chkbox.Checked = True Then
                            General_Helping.ExcuteQuery("insert into activities_Needs_relationship (need_id,actv_id,proj_id) values(" & dt.Rows(0)("LargestPNed_ID") & "," & CDataConverter.ConvertToInt(actv_id_box.Text) & "," & Session_CS.Project_id & ")")
                        End If
                    Next
                End If


                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
                GenerateTree()
                FillGrid()
                FillLog(0)


            Else
                FillGrid()
                If txtAmount.Text <> Nothing Then
                    If txtAmount.Text = 0 Then
                        lblPageStatus.Text = "الكمية المطلوبة لايمكن أن تساوى 0"
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If
                Dim validated_date As String = ""
                If txtdate.Text <> "" Then


                    If txtdate.Text <> "" Then
                        validated_date = txtdate.Text

                        'If VB_Classes.Dates.date_validate(txtdate.Text) <> "" Then
                        '    validated_date = VB_Classes.Dates.date_validate(txtdate.Text)

                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If

                Dim validated_date_request As String = ""
                If txt_request_DT.Text <> "" Then


                    If txt_request_DT.Text <> "" Then
                        'If VB_Classes.Dates.date_validate(txt_request_DT.Text) <> "" Then
                        validated_date_request = txt_request_DT.Text
                        'validated_date_request = VB_Classes.Dates.date_validate(txt_request_DT.Text)
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If

                General_Helping.ExcuteQuery("update Project_Needs set Nst_Nst_Id = " & Smart_Search_sp.SelectedValue & " where PNed_ID = " & ID)
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Number = " & CDataConverter.ConvertToInt(txtAmount.Text) & " where PNed_ID = " & ID)
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Name = '" & txtItem.Text & "' where PNed_ID = " & ID)

                General_Helping.ExcuteQuery("update Project_Needs set PNed_desc = '" & txtItemDesc.Text & "' where PNed_ID = " & ID)
                General_Helping.ExcuteQuery("update Project_Needs set Pned_Date = '" & validated_date & "' , Request_DT = '" & validated_date_request & "'  where PNed_ID = " & ID)
                If CDataConverter.ConvertToInt(ddl_Source.SelectedValue) > 0 Then
                    General_Helping.ExcuteQuery("update Project_Needs set Sources_ID = " & CDataConverter.ConvertToInt(ddl_Source.SelectedValue) & " where PNed_ID = " & ID)
                End If
                If CDataConverter.ConvertToInt(ddl_Provider.SelectedValue) > 0 Then
                    General_Helping.ExcuteQuery("update Project_Needs set Provider_ID = " & CDataConverter.ConvertToInt(ddl_Provider.SelectedValue) & " where PNed_ID = " & ID)
                End If

                General_Helping.ExcuteQuery("update Project_Needs set Pned_Initvalue = " & CDataConverter.ConvertToDecimal(txtInitialValue.Text) & " where PNed_ID = " & ID)
                General_Helping.ExcuteQuery("delete from activities_Needs_relationship where need_id=" & ID)
                If gvActivities.Rows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To gvActivities.Rows.Count - 1
                        Dim Chkbox As CheckBox
                        Dim actv_id_box As TextBox
                        Chkbox = gvActivities.Rows(i).FindControl("chkboxRow")
                        actv_id_box = gvActivities.Rows(i).FindControl("txtPActv_ID")
                        If Chkbox.Checked = True Then
                            General_Helping.ExcuteQuery("insert into activities_Needs_relationship (need_id,actv_id,proj_id) values(" & ID & "," & CDataConverter.ConvertToInt(actv_id_box.Text) & "," & Session_CS.Project_id & ")")
                        End If
                    Next
                End If

                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
                GenerateTree()
                FillGrid()
                FillDDls()
                BtnSave.Text = "حفــــــظ"
                BtnSave.CommandArgument = "new"
                FillLog(ID)


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
                SaveDataForClasses(PNed_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Clear()
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable
        Dim Sql As String = "select Project_Needs.*,NMT_Desc,nmt_nmt_id,NST_Desc from Project_Needs join Needs_Sup_Type on Project_Needs.nst_nst_id = nst_ID join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = NMT_ID join project on Project_Needs.proj_proj_id = proj_id where PNed_ID=" & CType(sender, ImageButton).CommandArgument
        _dt = General_Helping.GetDataTable(Sql)
        Smart_Search_mn.SelectedValue = _dt.Rows(0)("nmt_nmt_id")
        Smart_Search_mn_Selected(Smart_Search_mn.SelectedValue)
        Smart_Search_sp.SelectedValue = _dt.Rows(0)("nst_nst_id")
        'Dim dt As DataTable = General_Helping.GetDataTable("select NST_ID,NST_Desc from Needs_Sup_Type where nmt_nmt_id = " & Smart_Search_mn.SelectedValue)



        txtItem.Text = _dt.Rows(0)("PNed_Name")
        If Not _dt.Rows(0)("PNed_desc") Is DBNull.Value Then
            txtItemDesc.Text = _dt.Rows(0)("PNed_desc")
        End If
        If Not _dt.Rows(0)("PNed_Number") Is DBNull.Value Then
            txtAmount.Text = _dt.Rows(0)("PNed_Number")
        End If
        If Not _dt.Rows(0)("PNed_InitValue") Is DBNull.Value Then
            txtInitialValue.Text = _dt.Rows(0)("PNed_InitValue")
        End If
        If Not _dt.Rows(0)("PNed_Date") Is DBNull.Value Then
            txtdate.Text = _dt.Rows(0)("PNed_Date")
        End If

        If Not _dt.Rows(0)("Request_DT") Is DBNull.Value Then
            txt_request_DT.Text = _dt.Rows(0)("Request_DT")
        End If

        PNed_ID.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("PNed_ID"), HtmlControls.HtmlInputHidden).Value = PNed_ID.Value Then
                id = i
            Else
                gvMain.Rows(i).BackColor = Drawing.Color.White
            End If
            i += 1
        Next
        Dim _dt1 As New DataTable
        Dim Sql1 As String = "select * from activities_Needs_relationship where need_id=" & CType(sender, ImageButton).CommandArgument
        _dt1 = General_Helping.GetDataTable(Sql1)

        For Each rw As DataRow In _dt1.Rows
            For Each gvrw As GridViewRow In gvActivities.Rows
                Dim actv_text As TextBox = gvrw.FindControl("txtPActv_ID")
                Dim actv_chek As CheckBox = gvrw.FindControl("chkboxRow")
                If actv_text.Text = rw("actv_id").ToString() Then
                    actv_chek.Checked = True
                End If
            Next
        Next
        Try
            If Not _dt.Rows(0)("Sources_ID") Is DBNull.Value Then
                If _dt.Rows(0)("Sources_ID") > 0 Then
                    ddl_Source.SelectedValue = _dt.Rows(0)("Sources_ID")
                    'GetDataSetProvider(CDataConverter.ConvertToInt(ddl_Source.SelectedValue))
                End If
                If Not _dt.Rows(0)("Provider_ID") Is DBNull.Value Then
                    ddl_Provider.SelectedValue = _dt.Rows(0)("Provider_ID")
                End If
            End If
        Catch ex As Exception

        End Try
        gvMain.Rows(id).BackColor = Drawing.Color.Lavender
        BtnSave.Text = "تعديــــل"
        lblPageStatus.Text = ""
        'lblPageStatus.Visible = False
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            General_Helping.ExcuteQuery("DELETE FROM Need_Recieve WHERE pned_pned_id=" & CType(sender, ImageButton).CommandArgument)
            General_Helping.ExcuteQuery("delete from Need_Availble where PNed_PNed_Id=" & CType(sender, ImageButton).CommandArgument)
            Dim Project_Needs_ENTITY As New BLL.Project_Needs(CType(sender, ImageButton).CommandArgument)
            Project_Needs_ENTITY.Delete()
            Dim Sql As String = "update Project_Needs set need_Serial=need_Serial - " & 1 & " where PNed_ID >" & CType(sender, ImageButton).CommandArgument & " and proj_proj_id = " & Session_CS.Project_id
            General_Helping.ExcuteQuery(Sql)
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Protected Sub chekAllChange(ByVal sender As Object, ByVal e As EventArgs)

        For Each gvrw As GridViewRow In gvActivities.Rows

            Dim actv_chek As CheckBox = gvrw.FindControl("chkboxRow")
            If chkBoxAll.Checked = True Then
                actv_chek.Checked = True
            Else
                actv_chek.Checked = False
            End If


        Next
    End Sub
    'Private Sub ddlMainCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMainCat.SelectedIndexChanged
    '    If ddlMainCat.SelectedIndex <> 0 Then
    '        Dim dt As DataTable = General_Helping.GetDataTable("select NST_Desc,NST_Id from Needs_Sup_Type where nmt_nmt_id=" & ddlMainCat.SelectedValue)
    '        Obj_General_Helping.SmartBindDDL(ddlSubCat, dt, "NST_ID", "NST_Desc", "....اختر نوع الاحتياج الفرعى....")

    '    Else

    '        ddlSubCat.Items.Clear()
    '        ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")
    '    End If
    'End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        'DBL.Helper.MergeRows(gvMain)
        MergeRows_2cell(gvMain)
    End Sub
    Public Sub MergeRows_2cell(ByVal GridView As GridView)

        If GridView.Rows.Count > 1 Then
            For rowIndex As Integer = GridView.Rows.Count - 2 To rowIndex Step -1
                Dim row As GridViewRow = GridView.Rows(rowIndex)
                Dim previousRow As GridViewRow = GridView.Rows(rowIndex + 1)
                For cellIndex As Integer = 1 To 2
                    If row.Cells(cellIndex).Text = previousRow.Cells(cellIndex).Text Then
                        row.Cells(cellIndex).RowSpan = CInt(IIf(previousRow.Cells(cellIndex).RowSpan < 2, 2, previousRow.Cells(cellIndex).RowSpan + 1))
                        previousRow.Cells(cellIndex).Visible = False
                    End If
                Next
            Next
        End If

    End Sub




#End Region




    Protected Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAmount.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If txtAmount.Text <> Nothing Then
            If txtAmount.Text = 0 Then
                lblPageStatus.Text = "الكمية المطلوبة لايمكن أن تساوى 0"
                lblPageStatus.Visible = True
                Return
            End If
            If txtInitialValue.Text <> "" Then
                Dim sql As String = ""
                sql = "select Project.Proj_InitValue,NMT_Desc,NST_Desc" _
                & " from Project" _
                & " full outer join Project_Needs on Project.proj_id = Project_Needs.proj_proj_id" _
                & " full outer join Needs_Sup_Type on Project_Needs.nst_nst_id = nst_ID" _
                & " full outer join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = NMT_ID" _
                & " where proj_id =" & Session_CS.Project_id _
                & " order by NMT_Desc,NST_Desc,PNed_ID"
                Dim dt1 As New DataTable
                dt1 = General_Helping.GetDataTable(sql)
                Dim sql1 As String = ""
                sql1 = "SELECT PNed_InitValue,PNed_Number FROM Project_Needs where proj_proj_id=" & Session_CS.Project_id
                Dim dt As New DataTable
                dt = General_Helping.GetDataTable(sql1)
                Dim total_needs As Double
                If dt.Rows.Count > 0 Then
                    Dim i As Integer = 0

                    For Each row As DataRow In dt.Rows
                        If Not dt.Rows(i)("PNed_InitValue") Is DBNull.Value And Not dt.Rows(i)("PNed_Number") Is DBNull.Value Then
                            total_needs += Double.Parse(dt.Rows(i)("PNed_InitValue")) * Double.Parse(dt.Rows(i)("PNed_Number"))
                        End If
                        i += 1
                    Next
                    If BtnSave.Text = "حفــــــظ" And txtInitialValue.Text <> "" And txtAmount.Text <> "" Then
                        total_needs += Double.Parse(txtInitialValue.Text) * Double.Parse(txtAmount.Text)
                    End If
                    If total_needs > Double.Parse(dt1.Rows(0)("Proj_InitValue")) Then
                        lblPageStatus.Text = "اجمالى الاحتياجات يتخطى ميزانيه المشروع"
                        lblPageStatus.Visible = True
                        Return
                    End If
                    lblTotalNeedsCalc.Text = total_needs.ToString("#,###.00")
                    totalNeeds.Visible = True
                ElseIf txtInitialValue.Text <> "" And txtAmount.Text <> "" Then
                    total_needs = Double.Parse(txtInitialValue.Text) * Double.Parse(txtAmount.Text)
                    If total_needs > Double.Parse(dt1.Rows(0)("Proj_InitValue")) Then
                        lblPageStatus.Text = "اجمالى الاحتياجات يتخطى ميزانيه المشروع"
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub txtdate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtdate.TextChanged


        Dim validated_date As String = ""
        If txtdate.Text <> "" Then
            txtdate.Text = txtdate.Text
            validated_date = txtdate.Text

            'If VB_Classes.Dates.date_validate(txtdate.Text) <> "" Then
            '    txtdate.Text = VB_Classes.Dates.date_validate(txtdate.Text)
            '    validated_date = VB_Classes.Dates.date_validate(txtdate.Text)
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            Return
        End If


    End Sub

    Protected Sub txtInitialValue_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtInitialValue.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If txtInitialValue.Text <> "" Then
            If txtInitialValue.Text = 0 Then
                lblPageStatus.Text = "القيمة التقديرية لايمكن أن تساوى 0"
                lblPageStatus.Visible = True
                Return
            End If
            If txtAmount.Text <> "" Then
                Dim sql As String = ""
                sql = "select Project.Proj_InitValue,NMT_Desc,NST_Desc" _
                & " from Project" _
                & " full outer join Project_Needs on Project.proj_id = Project_Needs.proj_proj_id" _
                & " full outer join Needs_Sup_Type on Project_Needs.nst_nst_id = nst_ID" _
                & " full outer join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = NMT_ID" _
                & " where proj_id = " & Session_CS.Project_id _
                & " order by NMT_Desc,NST_Desc,PNed_ID"
                Dim dt1 As New DataTable
                dt1 = General_Helping.GetDataTable(sql)
                Dim sql1 As String = ""
                sql1 = "SELECT PNed_InitValue,PNed_Number FROM Project_Needs where proj_proj_id=" & Session_CS.Project_id
                Dim dt As New DataTable
                dt = General_Helping.GetDataTable(sql1)
                Dim total_needs As Double
                If dt.Rows.Count > 0 Then
                    Dim i As Integer = 0

                    For Each row As DataRow In dt.Rows
                        If Not dt.Rows(i)("PNed_InitValue") Is DBNull.Value And Not dt.Rows(i)("PNed_Number") Is DBNull.Value Then
                            total_needs += Double.Parse(dt.Rows(i)("PNed_InitValue")) * Double.Parse(dt.Rows(i)("PNed_Number"))
                        End If
                        i += 1
                    Next
                    If BtnSave.Text = "حفــــــظ" And txtInitialValue.Text <> "" And txtAmount.Text <> "" Then
                        total_needs += Double.Parse(txtInitialValue.Text) * Double.Parse(txtAmount.Text)
                    End If
                    If total_needs > Double.Parse(dt1.Rows(0)("Proj_InitValue")) Then
                        lblPageStatus.Text = "اجمالى الاحتياجات يتخطى ميزانيه المشروع"
                        lblPageStatus.Visible = True
                        Return

                    End If
                    lblTotalNeedsCalc.Text = total_needs.ToString
                    totalNeeds.Visible = True
                ElseIf txtInitialValue.Text <> "" And txtAmount.Text <> "" Then
                    total_needs = Double.Parse(txtInitialValue.Text) * Double.Parse(txtAmount.Text)
                    If total_needs > Double.Parse(dt1.Rows(0)("Proj_InitValue")) Then
                        lblPageStatus.Text = "اجمالى الاحتياجات يتخطى ميزانيه المشروع"
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub ddl_Source_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_Source.SelectedIndexChanged
        GetDataSetProvider(CDataConverter.ConvertToInt(ddl_Source.SelectedValue))
    End Sub

    Protected Sub gvSub_PreRender1(ByVal sender As Object, ByVal e As System.EventArgs)

        MergeRows(gvActivities)


    End Sub
    Protected Sub MergeRows(ByVal GridView As GridView)


        If GridView.Rows.Count > 1 Then

            Dim rowIndex As Integer
            For rowIndex = GridView.Rows.Count - 2 To 0 Step -1

                Dim row As GridViewRow = GridView.Rows(rowIndex)
                Dim previousRow As GridViewRow = GridView.Rows(rowIndex + 1)
                Dim txtlvl As TextBox
                Dim txtprelvl As TextBox
                txtlvl = row.FindControl("txtLevel")
                txtprelvl = previousRow.FindControl("txtLevel")
                Dim lvl_row As Integer = CDataConverter.ConvertToInt(txtlvl.Text)
                Dim lvl_previousRow As Integer = CDataConverter.ConvertToInt(txtprelvl.Text)

                If lvl_row = 1 Then

                    row.Font.Bold = True
                    row.Font.Size = 14
                    row.BackColor = System.Drawing.Color.FromArgb(235, 236, 239)
                    row.ForeColor = System.Drawing.Color.Black

                End If
                If lvl_previousRow = 1 Then

                    previousRow.Font.Bold = True
                    previousRow.Font.Size = 14
                    previousRow.BackColor = System.Drawing.Color.FromArgb(235, 236, 239)
                    previousRow.ForeColor = System.Drawing.Color.Black
                End If
                If lvl_previousRow = 2 Then
                    previousRow.BackColor = System.Drawing.Color.FromArgb(138, 173, 198)
                End If
                If (lvl_previousRow = 3) Then
                    previousRow.BackColor = System.Drawing.Color.FromArgb(175, 207, 229)
                End If
                If (lvl_previousRow = 4) Then
                    previousRow.BackColor = System.Drawing.Color.FromArgb(194, 221, 238)
                End If
                If (lvl_previousRow = 5) Then
                    previousRow.BackColor = System.Drawing.Color.FromArgb(212, 226, 243)
                End If
                If (lvl_previousRow = 6) Then
                    previousRow.BackColor = System.Drawing.Color.FromArgb(240, 226, 243)
                End If
                If (lvl_previousRow = 7) Then
                    previousRow.BackColor = System.Drawing.Color.White
                End If
                If (lvl_previousRow = 8) Then
                    previousRow.BackColor = System.Drawing.Color.White
                End If
                If (lvl_previousRow = 9) Then
                    previousRow.BackColor = System.Drawing.Color.White
                End If



                'If (previousRow.Cells(1).Text = "&nbsp;") Then

                '    If (previousRow.Cells(1).RowSpan < 2) Then
                '        row.Cells(1).RowSpan = 2
                '    Else
                '        row.Cells(1).RowSpan = CDataConverter.ConvertToInt(previousRow.Cells(1).RowSpan + 1)

                '        previousRow.Cells(1).Visible = False
                '    End If
                'End If


            Next

        ElseIf GridView.Rows.Count = 1 Then


            GridView.Rows(0).Cells(1).Font.Bold = True
            GridView.Rows(0).Cells(1).Font.Size = 14
            GridView.Rows(0).Cells(1).BackColor = System.Drawing.Color.FromArgb(235, 236, 239)
        End If

    End Sub

End Class