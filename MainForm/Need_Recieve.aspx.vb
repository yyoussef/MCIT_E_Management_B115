Imports MCIT.Web.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data
Imports System.Collections.Generic

Partial Class mainform_Need_Recieve
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS
    Public con As New SqlConnection
    Dim fmt As DateTimeFormatInfo = (New CultureInfo("en-US")).DateTimeFormat
    Dim provider As CultureInfo = CultureInfo.InvariantCulture
    Dim Obj_General_Helping As New General_Helping




#Region "Variables"
    Dim sql_Connection As String = Database.ConnectionString
    Dim Project_Needs_ENTITY As New BLL.Project_Needs
    Dim need_sub_type As New BLL.Needs_Sup_Type
    Dim Need_Recieve As New BLL.Need_Recieve
    Dim fileLen As Integer
    Dim Input(fileLen) As Byte
    Dim type As String
    'Private Obj_Browser_Side As New cBrowser(Me, "select NMT_id,NMT_desc from Needs_Main_Type", "الإحتياجات الرئيسية", 4)
    'Private Obj_Sql_Con As New SqlConnection(Database.ConnectionString)
#End Region

#Region "On Init"
    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)

        MyBase.OnInitComplete(e)

        Smart_Search_Proj.sql_Connection = sql_Connection
        Smart_Search_Proj.Text_Field = "Proj_Title "
        Smart_Search_Proj.Value_Field = "proj_proj_id "


        Dim Sql As String = " SELECT DISTINCT Project_Needs.proj_proj_id, Project.Proj_Title FROM         Project_Needs INNER JOIN Project ON Project_Needs.proj_proj_id = Project.Proj_id INNER JOIN " _
                            & " Need_Availble ON Project_Needs.PNed_ID = Need_Availble.PNed_PNed_Id GROUP BY Project_Needs.proj_proj_id, Project.Proj_Title HAVING      (SUM(ISNULL(Need_Availble.Availble_Amount, 0)) > 0) "
        '" SELECT DISTINCT Project_Needs.proj_proj_id, Project.Proj_Title  FROM         Need_Recieve INNER JOIN                       Project_Needs ON Need_Recieve.pned_pned_id = Project_Needs.PNed_ID INNER JOIN                       Project ON Project_Needs.proj_proj_id = Project.Proj_id " _
        '                           & "GROUP BY Project_Needs.proj_proj_id, Project.Proj_Title HAVING      (SUM(ISNULL(Need_Recieve.recieved_amount, 0)) > 0)"

        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Sql)
        Smart_Search_Proj.DataBind()

        If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then

            Smart_Search_Proj.SelectedValue = Session_CS.Project_id
            Smart_Search_Proj.Enabled = False
            FillGrid()

        End If

        AddHandler Me.Smart_Search_Proj.Value_Handler, AddressOf Smart_Search_Selected



        MyBase.OnInitComplete(e)
    End Sub

#End Region



#Region "event handel"

    Private Sub Smart_Search_Selected(ByVal Value As String)
        If CDataConverter.ConvertToInt(Value) > 0 Then
            FillGrid()
        End If
    End Sub

    Private Sub MOnMember_Data(ByVal VSender As Object, ByVal VArgs As BrowseDataEventArgs)
        ddlMainCat.SelectedValue = VArgs.Item(0).ToString()
        main_index_changed()
    End Sub
    Private Sub main_index_changed()
        If ddlMainCat.SelectedIndex <> 0 Then
            Dim dt As DataTable = General_Helping.GetDataTable("select NST_Desc,NST_Id from Needs_Sup_Type where nmt_nmt_id=" & ddlMainCat.SelectedValue)
            Obj_General_Helping.SmartBindDDL(ddlSubCat, dt, "NST_ID", "NST_Desc", "....اختر نوع الاحتياج الفرعى....")

        Else

            ddlSubCat.Items.Clear()
            ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")
        End If
    End Sub
#End Region

#Region "Load"
    Dim rowindeces As New List(Of Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)
            FillDDls()
            'BtnSave.CommandArgument = "new"

            If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then
                FillGrid()
              
            End If

        End If
    End Sub
#End Region


#Region "Clear"
    Private Sub Clear()
        'lblApprovedAmount.Text = ""
        'lblAvailbleAmount.Text = ""
        txtRecievedDate.Text = ""
        TxtOrg.Text = ""
        TxtPerson.Text = ""
        txtRecievedAmount.Text = ""
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""

        'lblremain.Text = ""
        'lbltotaldelivers.Text = ""
        'ddlSubCat.SelectedValue = "....اختر نوع الاحتياج الفرعى...."
        'ddlItem.SelectedValue = "......اختر البند........"
        'ddlMainCat.SelectedValue = "....اختر نوع الاحتياج الرئيسى......"

    End Sub
#End Region



#Region "Fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        sql = " SELECT     Need_Recieve.need_recieve_id, Need_Recieve.recieved_amount, Need_Recieve.recieved_amount_date, Need_Recieve.remain_amount,                       Need_Recieve.recieve_organization, Need_Recieve.recieve_organization_person, Need_Recieve.pned_pned_id, Need_Recieve.File_data, Need_Recieve.File_name,                       Need_Recieve.File_ext, Need_Recieve.doc_desc, Needs_Main_Type.NMT_Desc, Needs_Sup_Type.NST_Desc, Project_Needs.PNed_Name,                       Project_Needs.PNed_Date, Project_Needs.PNed_Number, Project_Needs.approved_amount, Project_Needs.proj_proj_id  " _
            & "  FROM         Needs_Sup_Type INNER JOIN                       Project_Needs ON Needs_Sup_Type.NST_ID = Project_Needs.nst_nst_id INNER JOIN                       Needs_Main_Type ON Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID LEFT OUTER JOIN                       Need_Recieve ON Project_Needs.PNed_ID = Need_Recieve.pned_pned_id " _
            & " where Project_Needs.proj_proj_id =" & Smart_Search_Proj.SelectedValue

        'If ddlItem.SelectedValue <> "0" Then
        '    sql &= " AND pned_pned_id=" & ddlItem.SelectedValue
        'End If

        'sql &= " order by recieved_amount_date"
        gvMain.Visible = True
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()

        'Dim sql1 As String = ""
        'sql1 = "SELECT SUM(Availble_Amount) AS total_availble_amount FROM Need_Availble"
        'If ddlItem.SelectedValue <> "0" Then
        '    sql1 &= " where PNed_PNed_Id = " & ddlItem.SelectedValue
        'End If
        'Dim dt As New DataTable
        'Dim sql11 As String = "select PNed_Date from Project_Needs"

        'If ddlItem.SelectedValue <> "0" Then
        '    sql11 &= " where PNed_ID =" & ddlItem.SelectedValue

        'End If
        'Dim dt11 As DataTable = General_Helping.GetDataTable(sql11)
        'dt = General_Helping.GetDataTable(sql1)
        'If Not dt.Rows(0)("total_availble_amount") Is DBNull.Value Then
        '    lblAvailbleAmount.Text = dt.Rows(0)("total_availble_amount")
        'End If
        'If Not dt11.Rows(0)("PNed_Date") Is DBNull.Value Then
        '    lblNeedDate.Text = dt11.Rows(0)("PNed_Date")
        'End If
        'Dim sql2 As String = ""
        'sql2 = "SELECT SUM(recieved_amount) AS total_recieved_amount FROM need_Recieve where pned_pned_id=" & ddlItem.SelectedValue
        'Dim dt1 As New DataTable
        'dt1 = General_Helping.GetDataTable(sql2)
        'Dim sql3 As String = "select Project_Needs.* from Project_Needs where PNed_ID=" & ddlItem.SelectedValue
        'Dim dt3 As New DataTable
        'dt3 = General_Helping.GetDataTable(sql3)
        'Dim str As String = dt3.Rows(0)("PNed_Number")
        'Dim str1() As String = str.Split(".")
        'lblamnt.Text = str1(0)
        'Dim str2 As String = dt3.Rows(0)("PNed_InitValue")
        'Dim str3() As String = str2.Split(".")
        'lblunitprice.Text = str3(0)
        'If Not dt3.Rows(0)("approved_amount") Is DBNull.Value Then
        '    lblApprovedAmount.Text = dt3.Rows(0)("approved_amount")
        '    If Not dt1.Rows(0)("total_recieved_amount") Is DBNull.Value Then
        '        lbltotaldelivers.Text = dt1.Rows(0)("total_recieved_amount")
        '        lblremain.Text = lblAvailbleAmount.Text - lbltotaldelivers.Text
        '    Else
        '        lbltotaldelivers.Text = 0
        '        lblremain.Text = lblAvailbleAmount.Text
        '    End If
        'End If
        'If Not dt.Rows(0)("total_availble_amount") Is DBNull.Value Then
        '    If Not dt3.Rows(0)("approved_amount") Is DBNull.Value Then
        '        lblAvailbleRemain.Text = (CDataConverter.ConvertToInt(dt3.Rows(0)("approved_amount")) - CDataConverter.ConvertToInt(dt.Rows(0)("total_availble_amount"))).ToString
        '    End If
        'Else
        '    lblAvailbleAmount.Text = 0
        '    lblAvailbleRemain.Text = (CDataConverter.ConvertToInt(dt3.Rows(0)("approved_amount"))).ToString

        'End If

        'Dim dtgrid As DataTable
        'dtgrid = General_Helping.GetDataTable("select *,Project_Activities.PActv_Desc from activities_Needs_relationship join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID where activities_Needs_relationship.need_id=" & ddlItem.SelectedValue & " order by Project_Activities.PActv_ID")
        'If dtgrid.Rows.Count > 0 Then
        '    trActivities.Visible = True
        '    gvActivities.DataSource = dtgrid
        '    gvActivities.DataBind()
        'End If


    End Sub
    Private Sub FillDDls()
        Dim dt5 As New DataTable
        Dim sql As String = "select distinct Needs_Main_Type.NMT_id,NMT_desc" _
               & " from Needs_Main_Type" _
               & " join dbo.Needs_Sup_Type ON dbo.Needs_Sup_Type.nmt_nmt_id = dbo.Needs_Main_Type.NMT_id" _
               & " join dbo.Project_Needs ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID" _
               & " join Need_Availble ON dbo.Need_Availble.PNed_PNed_Id = dbo.Project_Needs.PNed_ID "
        If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then

            sql &= " where Need_Availble.Availble_Amount <> 0 and dbo.Project_Needs.proj_proj_id=" & Session_CS.Project_id
        End If

        'If (Smart_Search_Proj.SelectedValue <> "0" Or Smart_Search_Proj.SelectedValue <> "") Then


        '    sql &= " where Need_Availble.Availble_Amount <> 0 and dbo.Project_Needs.proj_proj_id=" & Smart_Search_Proj.SelectedValue
        'End If


        dt5 = General_Helping.GetDataTable(sql)
        Obj_General_Helping.SmartBindDDL(ddlMainCat, dt5, "NMT_ID", "NMT_Desc", "....اختر نوع الاحتياج الرئيسى......")

        ddlSubCat.Items.Clear()
        ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")

        ddlItem.Items.Clear()
        ddlItem.Items.Insert(0, "......اختر البند........")
    End Sub
#End Region

    Private Sub fill_values()
        Dim sql1 As String = ""
        'sql1 = "SELECT SUM(Availble_Amount) AS total_availble_amount FROM Need_Availble"
        sql1 = "SELECT SUM(Availble_Amount) AS total_availble_amount FROM Need_Availble inner join dbo.Project_Needs on dbo.Project_Needs.PNed_ID=Need_Availble.PNed_PNed_id "

        If ddlItem.SelectedValue <> "0" Then
            sql1 &= " where PNed_PNed_Id = " & ddlItem.SelectedValue
        End If
        If Smart_Search_Proj.SelectedValue <> "0" Then
            sql1 &= " and Project_Needs.proj_proj_id = " & Smart_Search_Proj.SelectedValue
        End If
        Dim dt As New DataTable
        Dim sql11 As String = "select PNed_Date FROM Project_Needs   inner join Need_Availble on dbo.Project_Needs.PNed_ID=Need_Availble.PNed_PNed_id "

        If ddlItem.SelectedValue <> "0" Then
            sql11 &= " where PNed_ID =" & ddlItem.SelectedValue

        End If
        Dim dt11 As DataTable = General_Helping.GetDataTable(sql11)
        dt = General_Helping.GetDataTable(sql1)
        If Not dt.Rows(0)("total_availble_amount") Is DBNull.Value Then
            lblAvailbleAmount.Text = dt.Rows(0)("total_availble_amount")
        End If
        If Not dt11.Rows(0)("PNed_Date") Is DBNull.Value Then
            lblNeedDate.Text = dt11.Rows(0)("PNed_Date")
        End If
        Dim sql2 As String = ""
        sql2 = "SELECT SUM(recieved_amount) AS total_recieved_amount FROM need_Recieve where pned_pned_id=" & ddlItem.SelectedValue
        Dim dt1 As New DataTable
        dt1 = General_Helping.GetDataTable(sql2)
        Dim sql3 As String = "select Project_Needs.* from Project_Needs where PNed_ID=" & ddlItem.SelectedValue
        Dim dt3 As New DataTable
        dt3 = General_Helping.GetDataTable(sql3)
        Dim str As String = dt3.Rows(0)("PNed_Number")
        Dim str1() As String = str.Split(".")
        lblamnt.Text = str1(0)
        Dim str2 As String = dt3.Rows(0)("PNed_InitValue")
        Dim str3() As String = str2.Split(".")
        lblunitprice.Text = str3(0)
        If Not dt3.Rows(0)("approved_amount") Is DBNull.Value Then
            lblApprovedAmount.Text = dt3.Rows(0)("approved_amount")
            If Not dt1.Rows(0)("total_recieved_amount") Is DBNull.Value Then
                lbltotaldelivers.Text = dt1.Rows(0)("total_recieved_amount")
                lblremain.Text = lblAvailbleAmount.Text - lbltotaldelivers.Text
            Else
                lbltotaldelivers.Text = 0
                lblremain.Text = lblAvailbleAmount.Text
            End If
        End If
        If Not dt.Rows(0)("total_availble_amount") Is DBNull.Value Then
            If Not dt3.Rows(0)("approved_amount") Is DBNull.Value Then
                lblAvailbleRemain.Text = (CDataConverter.ConvertToInt(dt3.Rows(0)("approved_amount")) - CDataConverter.ConvertToInt(dt.Rows(0)("total_availble_amount"))).ToString
            End If
        Else
            lblAvailbleAmount.Text = 0
            lblAvailbleRemain.Text = (CDataConverter.ConvertToInt(dt3.Rows(0)("approved_amount"))).ToString

        End If

        Dim dtgrid As DataTable
        dtgrid = General_Helping.GetDataTable("select *,Project_Activities.PActv_Desc from activities_Needs_relationship join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID where activities_Needs_relationship.need_id=" & ddlItem.SelectedValue & " order by Project_Activities.PActv_ID")
        If dtgrid.Rows.Count > 0 Then
            trActivities.Visible = True
            gvActivities.DataSource = dtgrid
            gvActivities.DataBind()
        End If
    End Sub

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try

            If ID = 0 Then
                Dim sql As String = ""
                Dim dt As New DataTable
                sql = "select sum(recieved_amount) as sum_recieved from need_recieve where pned_pned_id=" & ddlItem.SelectedValue
                Dim dt1 = General_Helping.GetDataTable(sql)
                Dim total_recieved As Integer
                If lblremain.Text = "0" Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "تم صرف الاحتياج بالكامل"
                    Return
                End If

                lblPageStatus.Text = ""
                lblPageStatus.Visible = False
                If txtRecievedAmount.Text <> "" And ddlItem.SelectedIndex > 0 Then
                    If txtRecievedAmount.Text = 0 Then
                        lblPageStatus.Text = "الكمية المنصرفة لايمكن أن تساوى 0"
                        lblPageStatus.Visible = True
                        Return
                    End If
                    If lblAvailbleAmount.Text = "" Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "لم تتم الاتاحة لهذا الاحتياج"
                        Return
                    ElseIf lblApprovedAmount.Text = "" Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "لم يتم التصديق لهذا الاحتياج"
                        Return
                    End If
                    If Not dt1.Rows(0)("sum_recieved") Is DBNull.Value Then
                        total_recieved = Integer.Parse(dt1.Rows(0)("sum_recieved")) + Integer.Parse(txtRecievedAmount.Text)
                    Else
                        total_recieved = Integer.Parse(txtRecievedAmount.Text)
                    End If

                    If Decimal.Parse(total_recieved) > Decimal.Parse(lblApprovedAmount.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المصدق بها "
                        Return
                    ElseIf Integer.Parse(txtRecievedAmount.Text) > Decimal.Parse(lblremain.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "الكميه المنصرفة اكبر من الكمية المتبقية "
                        Return
                    ElseIf Decimal.Parse(total_recieved) > Decimal.Parse(lblAvailbleAmount.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المتاحه "
                        Return
                    End If

                End If
                Dim validated_date As String = ""
                If txtRecievedDate.Text <> "" Then
                    If txtRecievedDate.Text <> "" Then
                        validated_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtRecievedDate.Text))
                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If

                End If

                Dim amount_sum As Integer = 0
                For i = 0 To gvActivities.Rows.Count - 1
                    Dim txtAmount As TextBox
                    txtAmount = gvActivities.Rows(i).FindControl("txtamount")
                    amount_sum += CDataConverter.ConvertToInt(txtAmount.Text)
                Next
                If amount_sum > Integer.Parse(lblamnt.Text) Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "الكمية الموزعه على الانشطة اكبر من الكمية المطلوبة"
                    Return
                End If

                General_Helping.ExcuteQuery("insert into Need_Recieve (recieved_amount,pned_pned_id) values(" & Decimal.Parse(txtRecievedAmount.Text) & "," & ddlItem.SelectedValue & ")")


                General_Helping.ExcuteQuery("update Project_Needs set TotalDelievered =" & total_recieved & " where PNed_ID=" & ddlItem.SelectedValue)

                Dim sql11 As String = ""
                sql11 = "SELECT MAX(need_recieve_id) AS Largest_need_recieve_id FROM Need_Recieve"
                Dim dt11 As New DataTable
                dt11 = General_Helping.GetDataTable(sql11)
                need_recieve_id.Value = dt11.Rows(0)("Largest_need_recieve_id")
                If txtRecievedDate.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set recieved_amount_date = '" & validated_date & "' where need_recieve_id =" & dt11.Rows(0)("Largest_need_recieve_id"))
                End If
                If TxtOrg.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set recieve_organization = '" & TxtOrg.Text & "' where need_recieve_id =" & dt11.Rows(0)("Largest_need_recieve_id"))
                End If
                If TxtPerson.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set recieve_organization_person = '" & TxtPerson.Text & "' where need_recieve_id =" & dt11.Rows(0)("Largest_need_recieve_id"))
                End If
                If FileUpload1.HasFile = True And TxtDocName.Text <> "" Then
                    SaveFileContents()
                End If
                If trActivities.Visible = True Then
                    Dim i As Integer
                    For i = 0 To gvActivities.Rows.Count - 1
                        Dim actv_id_box As TextBox
                        Dim txtAmount As TextBox
                        Dim txt_total As TextBox
                        actv_id_box = gvActivities.Rows(i).FindControl("txtPActv_ID")
                        txtAmount = gvActivities.Rows(i).FindControl("txtamount")
                        txt_total = gvActivities.Rows(i).FindControl("txttotal")
                        txt_total.Text = (CDataConverter.ConvertToInt(txtAmount.Text) * CDataConverter.ConvertToInt(General_Helping.GetDataTable("select PNed_InitValue from Project_Needs where PNed_ID=" & ddlItem.SelectedValue).Rows(0)("PNed_InitValue").ToString())).ToString()
                        General_Helping.ExcuteQuery("update activities_Needs_relationship set total=" & CDataConverter.ConvertToInt(txt_total.Text) & ",amount =" & CDataConverter.ConvertToInt(txtAmount.Text) & " where actv_id=" & CDataConverter.ConvertToInt(actv_id_box.Text) & "and need_id=" & ddlItem.SelectedValue)
                    Next
                End If
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
                txtRecievedAmount.Text = ""
                FillGrid()


            Else
                Dim sql As String = ""
                Dim dt As New DataTable
                sql = "select sum(recieved_amount) as sum_recieved from need_recieve where pned_pned_id=" & ddlItem.SelectedValue
                Dim sqll As String = "select recieved_amount from need_recieve where need_recieve_id=" & ID
                Dim dtt As DataTable = General_Helping.GetDataTable(sqll)
                Dim dt1 = General_Helping.GetDataTable(sql)
                Dim total_recieved As Integer
                If lblremain.Text = 0 Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "تم صرف الاحتياج بالكامل"
                    Return
                End If

                lblPageStatus.Text = ""
                lblPageStatus.Visible = False
                If txtRecievedAmount.Text <> "" And ddlItem.SelectedIndex > 0 Then
                    If txtRecievedAmount.Text = 0 Then
                        lblPageStatus.Text = "الكمية المنصرفة لايمكن أن تساوى 0"
                        lblPageStatus.Visible = True
                        Return
                    End If
                    If lblAvailbleAmount.Text = "" Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "لم تتم الاتاحة لهذا الاحتياج"
                        Return
                    ElseIf lblApprovedAmount.Text = "" Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "لم يتم التصديق لهذا الاحتياج"
                        Return
                    End If
                    If Not dt1.Rows(0)("sum_recieved") Is DBNull.Value Then
                        total_recieved = Integer.Parse(dt1.Rows(0)("sum_recieved")) + Integer.Parse(txtRecievedAmount.Text) - Integer.Parse(dtt.Rows(0)("recieved_amount"))
                    Else
                        total_recieved = Integer.Parse(txtRecievedAmount.Text)
                    End If

                    If Decimal.Parse(total_recieved) > Decimal.Parse(lblApprovedAmount.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المصدق بها "
                        Return
                    ElseIf Integer.Parse(txtRecievedAmount.Text) > Decimal.Parse(lblremain.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "الكميه المنصرفة اكبر من الكمية المتبقية "
                        Return
                    ElseIf Decimal.Parse(total_recieved) > Decimal.Parse(lblAvailbleAmount.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المتاحه "
                        Return
                    End If
                End If
                Dim validated_date As String = ""
                If txtRecievedDate.Text <> "" Then


                    If txtRecievedDate.Text <> "" Then
                        validated_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtRecievedDate.Text))

                        lblPageStatus.Visible = False
                    Else
                        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                        lblPageStatus.Visible = True
                        Return
                    End If
                End If

                Dim amount_sum As Integer = 0
                For i = 0 To gvActivities.Rows.Count - 1
                    Dim txtAmount As TextBox
                    txtAmount = gvActivities.Rows(i).FindControl("txtamount")
                    amount_sum += CDataConverter.ConvertToInt(txtAmount.Text)
                Next
                If amount_sum > Integer.Parse(lblamnt.Text) Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "الكمية الموزعه على الانشطة اكبر من الكمية المطلوبة"
                    Return
                End If

                General_Helping.ExcuteQuery("update Need_Recieve set recieved_amount =" & Decimal.Parse(txtRecievedAmount.Text) & " where need_recieve_id =" & ID)
                General_Helping.ExcuteQuery("update Project_Needs set TotalDelievered =" & total_recieved & " where PNed_ID=" & ddlItem.SelectedValue)
                need_recieve_id.Value = ID
                If txtRecievedDate.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set recieved_amount_date =  '" & validated_date & "' where need_recieve_id =" & ID)
                End If
                If TxtOrg.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set recieve_organization = '" & TxtOrg.Text & "' where need_recieve_id =" & ID)
                End If
                If TxtPerson.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set recieve_organization_person = '" & TxtPerson.Text & "' where need_recieve_id =" & ID)
                End If
                If FileUpload1.HasFile = True Then
                    SaveFileContents()
                ElseIf TxtDocName.Text <> "" Then
                    General_Helping.ExcuteQuery("update Need_Recieve set File_name = '" & TxtDocName.Text & "' where need_recieve_id =" & ID)

                End If

                If trActivities.Visible = True Then
                    Dim i As Integer
                    For i = 0 To gvActivities.Rows.Count - 1
                        Dim actv_id_box As TextBox
                        Dim txtAmount As TextBox
                        Dim txt_total As TextBox
                        actv_id_box = gvActivities.Rows(i).FindControl("txtPActv_ID")
                        txtAmount = gvActivities.Rows(i).FindControl("txtamount")
                        txt_total = gvActivities.Rows(i).FindControl("txttotal")
                        txt_total.Text = (CDataConverter.ConvertToInt(txtAmount.Text) * CDataConverter.ConvertToInt(General_Helping.GetDataTable("select PNed_InitValue from Project_Needs where PNed_ID=" & ddlItem.SelectedValue).Rows(0)("PNed_InitValue"))).ToString()
                        General_Helping.ExcuteQuery("update activities_Needs_relationship set total=" & CDataConverter.ConvertToInt(txt_total.Text) & ",amount =" & CDataConverter.ConvertToInt(txtAmount.Text) & " where actv_id=" & CDataConverter.ConvertToInt(actv_id_box.Text) & "and need_id=" & ddlItem.SelectedValue)
                    Next
                End If

                BtnSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
                FillGrid()
                txtRecievedAmount.Text = ""
            End If
            BtnSave.Text = "حفــــــظ"
            Clear()
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "validation"
    Private Function valid() As Boolean

        If ddlItem.SelectedIndex = 0 Or txtRecievedAmount.Text = "" Or txtRecievedDate.Text = "" Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
            Return False
        Else
            lblPageStatus.Visible = False
            Return True
        End If

    End Function
#End Region

#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If valid() Then
            If BtnSave.CommandArgument = "new" Then
                SaveDataForClasses()

            Else
                SaveDataForClasses(CDataConverter.ConvertToInt(need_recieve_id.Value))
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Clear()
        Dim sql2 As String = ""
        sql2 = "SELECT SUM(recieved_amount) AS total_recieved_amount FROM need_Recieve where pned_pned_id=" & ddlItem.SelectedValue
        Dim dt1 As New DataTable
        dt1 = General_Helping.GetDataTable(sql2)
        Dim sql3 As String = "select Project_Needs.* from Project_Needs where PNed_ID=" & ddlItem.SelectedValue
        Dim dt3 As New DataTable
        dt3 = General_Helping.GetDataTable(sql3)
        Dim str As String = dt3.Rows(0)("PNed_Number")
        Dim str1() As String = str.Split(".")
        lblamnt.Text = str1(0)
        If Not dt3.Rows(0)("approved_amount") Is DBNull.Value Then
            lblApprovedAmount.Text = dt3.Rows(0)("approved_amount")
            If Not dt1.Rows(0)("total_recieved_amount") Is DBNull.Value Then
                lbltotaldelivers.Text = dt1.Rows(0)("total_recieved_amount")
                lblremain.Text = lblApprovedAmount.Text - lbltotaldelivers.Text
            Else
                lbltotaldelivers.Text = 0
                lblremain.Text = lblApprovedAmount.Text
            End If
        End If
        BtnSave.CommandArgument = "edit"
        Dim dt As New DataTable
        Dim sql As String = "select need_Recieve.* from need_recieve where need_recieve_id=" & CType(sender, ImageButton).CommandArgument
        dt = General_Helping.GetDataTable(sql)
        If Not dt.Rows(0)("recieved_amount") Is DBNull.Value Then
            txtRecievedAmount.Text = dt.Rows(0)("recieved_amount")
            lblremain.Text = Decimal.Parse(lblremain.Text) + Decimal.Parse(txtRecievedAmount.Text)
            lbltotaldelivers.Text = Decimal.Parse(lbltotaldelivers.Text) - Decimal.Parse(txtRecievedAmount.Text)
        End If
        If Not dt.Rows(0)("recieve_organization") Is DBNull.Value Then
            TxtOrg.Text = dt.Rows(0)("recieve_organization")
        End If
        If Not dt.Rows(0)("recieve_organization_person") Is DBNull.Value Then
            TxtPerson.Text = dt.Rows(0)("recieve_organization_person")
        End If
        If Not dt.Rows(0)("recieved_amount_date") Is DBNull.Value Then

            txtRecievedDate.Text = dt.Rows(0)("recieved_amount_date")
        End If

        If Not dt.Rows(0)("File_name") Is DBNull.Value Then

            TxtDocName.Text = dt.Rows(0)("File_name")
        End If
        need_recieve_id.Value = CType(sender, ImageButton).CommandArgument
        lblPageStatus.Visible = False
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("need_recieve_id"), HtmlControls.HtmlInputHidden).Value = need_recieve_id.Value Then
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
            General_Helping.ExcuteQuery("DELETE FROM Need_Recieve WHERE need_recieve_id=" & CType(sender, ImageButton).CommandArgument)
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try


    End Sub



    'Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
    '    DBL.Helper.MergeRows(gvMain)
    'End Sub
#End Region

    Private Sub ddlMainCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMainCat.SelectedIndexChanged
        If ddlMainCat.SelectedValue <> "....اختر نوع الاحتياج الرئيسى......" Then
            Dim dt2 As New DataTable
            Dim sql As String = "select distinct Needs_Sup_Type.NST_id,NST_Desc" _
                  & " from Needs_Sup_Type" _
                  & " join dbo.Needs_Main_Type ON dbo.Needs_Main_Type.NMT_id = dbo.Needs_Sup_Type.nmt_nmt_id" _
                  & " join dbo.Project_Needs ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID" _
                  & " join Need_Availble ON dbo.Need_Availble.PNed_PNed_Id = dbo.Project_Needs.PNed_ID" _
                  & " where Need_Availble.Availble_Amount <> 0 "
            If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then

                sql &= " and dbo.Project_Needs.proj_proj_id=" & Session_CS.Project_id & " and nmt_nmt_id = " & ddlMainCat.SelectedValue
            End If
            dt2 = General_Helping.GetDataTable(sql)
            Obj_General_Helping.SmartBindDDL(ddlSubCat, dt2, "NST_ID", "NST_Desc", "....اختر نوع الاحتياج الفرعى....")
            Clear()
            lblApprovedAmount.Text = ""
            lblAvailbleAmount.Text = ""
            lblremain.Text = ""
            lbltotaldelivers.Text = ""
            lblamnt.Text = ""
            lblunitprice.Text = ""
            ddlItem.Items.Clear()
            ddlItem.Items.Insert(0, "......اختر البند........")
        Else
            Clear()
            lblApprovedAmount.Text = ""
            lblAvailbleAmount.Text = ""
            lblremain.Text = ""
            lbltotaldelivers.Text = ""
            lblamnt.Text = ""
            lblunitprice.Text = ""
            ddlItem.Items.Clear()
            ddlItem.Items.Insert(0, "......اختر البند........")
            ddlSubCat.Items.Clear()
            ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")
        End If
    End Sub
    Protected Sub ddlSubCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSubCat.SelectedIndexChanged
        If ddlSubCat.SelectedValue <> "....اختر نوع الاحتياج الفرعى...." Then
            Dim dt3 As New DataTable
            Dim sqll As String
            sqll = "select pned_id,pned_name from project_needs where nst_nst_id = " & ddlSubCat.SelectedValue
            If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then

                sqll &= " and dbo.Project_Needs.proj_proj_id=" & Session_CS.Project_id & ""
            End If
            dt3 = General_Helping.GetDataTable(sqll)
            Obj_General_Helping.SmartBindDDL(ddlItem, dt3, "pned_id", "pned_name", "......اختر البند........")
            Clear()
            lblApprovedAmount.Text = ""
            lblAvailbleAmount.Text = ""
            lblremain.Text = ""
            lbltotaldelivers.Text = ""
            lblamnt.Text = ""
            lblunitprice.Text = ""
        Else
            Clear()
            lblApprovedAmount.Text = ""
            lblAvailbleAmount.Text = ""
            lblremain.Text = ""
            lbltotaldelivers.Text = ""
            lblamnt.Text = ""
            lblunitprice.Text = ""
            ddlItem.Items.Clear()
            ddlItem.Items.Insert(0, "......اختر البند........")
        End If
    End Sub

    Protected Sub ddlItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlItem.SelectedIndexChanged
        If ddlItem.SelectedValue <> "......اختر البند........" Then
            FillGrid()
            fill_values()
            Clear()
        Else
            Clear()
            lblApprovedAmount.Text = ""
            lblAvailbleAmount.Text = ""
            lblremain.Text = ""
            lbltotaldelivers.Text = ""
            lblamnt.Text = ""
            lblunitprice.Text = ""
        End If

    End Sub



    Protected Sub txtRecievedAmount_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecievedAmount.TextChanged
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If txtRecievedAmount.Text <> "" And ddlItem.SelectedIndex > 0 Then
            If txtRecievedAmount.Text = 0 Then
                lblPageStatus.Text = "الكمية المنصرفة لايمكن أن تساوى 0"
                lblPageStatus.Visible = True
                Return
            End If
            If lblAvailbleAmount.Text = "" Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "لم تتم الاتاحة لهذا الاحتياج"
                Return
            ElseIf lblApprovedAmount.Text = "" Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "لم يتم التصديق لهذا الاحتياج"
                Return
            End If
            Dim sql As String = ""
            sql = "select sum(recieved_amount) as sum_recieved from need_recieve where pned_pned_id=" & ddlItem.SelectedValue
            Dim dt = General_Helping.GetDataTable(sql)
            Dim total_recieved As Integer
            If Not dt.Rows(0)("sum_recieved") Is DBNull.Value Then
                total_recieved = Integer.Parse(dt.Rows(0)("sum_recieved")) + Integer.Parse(txtRecievedAmount.Text)
            Else
                total_recieved = Integer.Parse(txtRecievedAmount.Text)
            End If

            If Decimal.Parse(total_recieved) > Decimal.Parse(lblApprovedAmount.Text) Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المصدق بها "
                Return
            ElseIf Integer.Parse(txtRecievedAmount.Text) > Decimal.Parse(lblremain.Text) Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "الكميه المنصرفة اكبر من الكمية المتبقية "
                Return
            ElseIf Decimal.Parse(total_recieved) > Decimal.Parse(lblAvailbleAmount.Text) Then
                lblPageStatus.Visible = True
                lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المتاحه "
                Return
            End If

        End If


    End Sub

    Protected Sub txtRecievedDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecievedDate.TextChanged
        Dim validated_date As String = ""
        If txtRecievedDate.Text <> "" Then
            ' txtRecievedDate.Text = VB_Classes.Dates.date_validate(txtRecievedDate.Text)

            validated_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtRecievedDate.Text))
            lblPageStatus.Visible = False
        Else
            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
            lblPageStatus.Visible = True
            Return
        End If

        If lblNeedDate.Text <> "" And validated_date <> "" Then
            If VB_Classes.Dates.Date_compare(validated_date, lblNeedDate.Text) Then
                lblPageStatus.Visible = False
            Else
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تاريخ الصرف يجب أن يأتى بعد تاريخ طلب الاحتياج "
                Return
            End If
        End If
        Dim sql As String = "select min(Availble_Amount_Date) as min_Availble_Amount_Date from Need_Availble where PNed_PNed_Id=" & ddlItem.SelectedValue
        Dim dt As DataTable = General_Helping.GetDataTable(sql)
        If dt.Rows.Count > 0 And dt.Rows(0)("min_Availble_Amount_Date").ToString <> "" And validated_date <> "" Then
            If VB_Classes.Dates.Date_compare(validated_date, dt.Rows(0)("min_Availble_Amount_Date")) Then
                lblPageStatus.Visible = False
            Else
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تاريخ الصرف يجب أن يأتى بعد تاريخ الاتاحة "
                Return
            End If
        End If

    End Sub


    Public Sub SaveFileContents()
        Dim fileLen As Integer
        Dim displayString As New StringBuilder()
        fileLen = FileUpload1.PostedFile.ContentLength
        Dim Input(fileLen) As Byte
        Dim myStream As System.IO.Stream
        myStream = FileUpload1.FileContent
        myStream.Read(Input, 0, fileLen)
        Dim DocName As String = FileUpload1.FileName
        Dim dotindex As Integer = DocName.LastIndexOf(".")
        Dim type As String = DocName.Substring(dotindex, DocName.Length - dotindex)
        Dim cmd As New SqlCommand("Add_Edit_NeedRecieve", con)
        OpenConnection()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@need_recieve_id", SqlDbType.BigInt)
        cmd.Parameters.Add("@recieved_amount", SqlDbType.BigInt)
        cmd.Parameters.Add("@pned_pned_id", SqlDbType.Int)
        cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
        cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
        cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)
        cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 255)

        cmd.Parameters("@need_recieve_id").Value = need_recieve_id.Value
        cmd.Parameters("@recieved_amount").Value = Decimal.Parse(txtRecievedAmount.Text)
        cmd.Parameters("@pned_pned_id").Value = ddlItem.SelectedValue
        cmd.Parameters("@mode").Value = "editWithFile"
        cmd.Parameters("@File_data").Value = Input
        cmd.Parameters("@File_name").Value = TxtDocName.Text
        cmd.Parameters("@File_ext").Value = type
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try







    End Sub

    Public Function OpenConnection() As Boolean
        Try
            If con.State <> ConnectionState.Open Then
                '''''''''''''specify the ConnectionStrng property'''''''''''''
                Dim conString As String '= "Data Source=migo-pc;Initial Catalog=ForTestOnly;Persist Security Info=True;User ID=WebProjects;Password=sqlasp"
                conString = DBL.Universal.GetConnectionString()

                '''''''''''''Initializes a new instance of the SQLConnection'''''''''''''
                con = New SqlConnection(conString)

                ''''''''''''' open the database connection with the property settings'''''''''''''
                '''''''''''''specified by the ConnectionString "conString"'''''''''''''
                con.Open()
                Return True
            End If
        Catch ex As Exception
            con.Close()
            Return False
        End Try
    End Function




    Protected Sub gvSub_PreRender1(ByVal sender As Object, ByVal e As System.EventArgs)

        MergeRows(gvActivities)


    End Sub
    Protected Sub MergeRows(ByVal GridView As GridView)


        If GridView.Rows.Count > 1 Then
            For Each rw As GridViewRow In GridView.Rows
                rw.Cells(0).Font.Bold = True
                rw.Cells(0).Font.Size = 14
                rw.Cells(0).BackColor = System.Drawing.Color.FromArgb(235, 236, 239)
            Next
        End If

    End Sub
End Class