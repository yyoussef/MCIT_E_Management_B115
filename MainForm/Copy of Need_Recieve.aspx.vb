Imports MCIT.Web.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data
Imports System.Collections.Generic

Partial Class MainForm_Need_Recieve
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS
    Public con As New SqlConnection
    Dim fmt As DateTimeFormatInfo = (New CultureInfo("en-US")).DateTimeFormat
    Dim provider As CultureInfo = CultureInfo.InvariantCulture
    Dim Obj_General_Helping As New General_Helping




#Region "Variables"
    Dim Project_Needs_ENTITY As New BLL.Project_Needs
    Dim need_sub_type As New BLL.Needs_Sup_Type
    Dim Need_Recieve As New BLL.Need_Recieve
    Dim fileLen As Integer
    Dim Input(fileLen) As Byte
    Dim type As String
    'Private Obj_Browser_Side As New cBrowser(Me, "select NMT_id,NMT_desc from Needs_Main_Type", "الإحتياجات الرئيسية", 4)
    'Private Obj_Sql_Con As New SqlConnection(Database.ConnectionString)
#End Region

    '#Region "On Init"
    '    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)

    '        Obj_Browser_Side = New cBrowser(Me, "select NMT_id,NMT_desc from Needs_Main_Type", "الإحتياجات الرئيسية", 6)
    '        Dim strConString As String = Database.ConnectionString
    '        'Obj_Sql_Con = System.Data.SqlClient.SqlConnection(strConString)
    '        Obj_Sql_Con.Open()



    '        'Me.Obj_Browser_Side = New cBrowser
    '        Me.Obj_Browser_Side.MAddField("NMT_Desc", "اسم الإحتياج الرئيسى", 200, BrowserFieldType.NIString)
    '        'Me.Obj_Browser_Side.MAddField("ORG_id", "رقم ", 50, BrowserFieldType.NIString)

    '        Me.Obj_Browser_Side.ID = "Obj_Browser_Side"

    '        'Dim MOnMember_Data As BrowseDataEventHandler
    '        AddHandler Me.Obj_Browser_Side.BrowseData, AddressOf MOnMember_Data




    '        MyBase.OnInitComplete(e)
    '    End Sub

    '#End Region

#Region "event handel"
    'Private Sub MOnMember_Data(ByVal VSender As Object, ByVal VArgs As BrowseDataEventArgs)
    '    ddlMainCat.SelectedValue = VArgs.Item(0).ToString()
    '    main_index_changed()
    'End Sub
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
            'ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)
            'FillDDls()
            FillGrid()
            TR2.Visible = False
            'fillgridneedreivedocs()
            BtnSave.CommandArgument = "new"
            Me.Page.Form.Enctype = "multipart/form-data"
            'Dim dynDiv As New System.Web.UI.HtmlControls.HtmlGenericControl("DIV")
            'dynDiv.ID = "dynDivCode"
            'dynDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Gray")
            'dynDiv.Style.Add(HtmlTextWriterStyle.Height, "500px")
            'dynDiv.Style.Add(HtmlTextWriterStyle.Width, "1600px")
            'dynDiv.InnerHtml = "I was created using Code Behind"
            'Me.Controls.Add(dynDiv)

        End If
    End Sub
#End Region


#Region "Clear"
    Private Sub Clear()
        'lblApprovedAmount.Text = ""
        'lblAvailbleAmount.Text = ""
        'txtRecievedDate.Text = ""
        'TxtOrg.Text = ""
        'TxtPerson.Text = ""
        'txtRecievedAmount.Text = ""
        lblPageStatus.Visible = False
        lblPageStatus.Text = ""

        'lblremain.Text = ""
        'lbltotaldelivers.Text = ""
        'ddlSubCat.SelectedValue = "....اختر نوع الاحتياج الفرعى...."
        'ddlItem.SelectedValue = "......اختر البند........"
        'ddlMainCat.SelectedValue = "....اختر نوع الاحتياج الرئيسى......"

    End Sub
#End Region

    'Protected Sub lnkCustDetails_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Fetch the customer id
    '    'Need_Av_Ids.Value = CType(sender, Button).CommandArgument

    '    ' Connection
    '    Dim sql_exchange As String = "select * from need_Recieve where pned_pned_id= " & 22
    '    Dim dt_ As New DataTable
    '    dt_ = General_Helping.GetDataTable(sql_exchange)
    '    ' Bind the reader to the GridView
    '    ' You can also use a lighter control
    '    ' like the Repeater to display data
    '    gvActivities.DataSource = dt_
    '    gvActivities.DataBind()

    '    ' Show the modalpopupextender
    '    ModalPopupExtender1.Show()

    'End Sub
#Region "Fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        'sql = "select need_Recieve.*,NMT_Desc,NST_Desc,PNed_Name,PNed_Date,PNed_Number,approved_amount,(PNed_Number-(SELECT SUM(recieved_amount) AS total_recieved_amount FROM need_Recieve where pned_pned_id=" & ddlItem.SelectedValue & ")) as remain from need_recieve" _
        ''    & " join Project_Needs on need_recieve.pned_pned_id = Project_Needs.PNed_ID" _
        '    & " join Needs_Sup_Type on Project_Needs.nst_nst_id = Needs_Sup_Type.NST_ID" _
        '    & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID where 1=1"

        'If ddlItem.SelectedValue <> "0" Then
        '    sql &= " AND pned_pned_id=" & ddlItem.SelectedValue
        'End If

        'sql &= " order by recieved_amount_date"

        sql = "select Project_Needs.* ,(SELECT sum(Availble_Amount) from Need_Availble where Need_Availble.PNed_PNed_Id =Project_Needs.PNed_ID) as Availble_Amount_edited,(SELECT sum(recieved_amount) from Need_Recieve where Need_Recieve.PNed_PNed_Id =Project_Needs.PNed_ID) as recieved_amount,NMT_Desc,NST_Desc,convert(nvarchar,PNed_Date,103) as needDate,convert(varchar(20),convert(money, PNed_InitValue), 1) as moneyv,convert(varchar(20),convert(money, (Project_Needs.PNed_Number)*(Project_Needs.PNed_InitValue)), 1) as multiply_money_integer from Project_Needs" _
          & " join Needs_Sup_Type on Project_Needs.nst_nst_id = Needs_Sup_Type.NST_ID" _
          & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID" _
          & " where Project_Needs.proj_proj_id= " & Session_CS.Project_id & " and (SELECT sum(Availble_Amount) from Need_Availble where Need_Availble.PNed_PNed_Id =Project_Needs.PNed_ID) >0 ORDER BY Needs_Main_Type.NMT_ID,Needs_Sup_Type.NST_ID"
        Dim dt As New DataTable
        dt = General_Helping.GetDataTable(sql)

        gvMain.Visible = True
        gvMain.DataSource = dt
        gvMain.DataBind()
        Dim sql_exchange As String = ""

        Dim dt_ As New DataTable
        Dim cnt As Integer = 0
        For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1
            Dim txtneedID As TextBox = gvMain.Rows(rwIndex).FindControl("txtneedID")
            Dim newRecieve As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewrecievedAmount")
            Dim txtActualCheck As TextBox = gvMain.Rows(rwIndex).FindControl("txtexchange")
            Dim newRecieveDate As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieveDate")
            'Dim FUp1 As FileUpload = gvMain.Rows(rwIndex).FindControl("FileUpload1")
            Dim imgbtncalender As ImageButton = gvMain.Rows(rwIndex).FindControl("ImageButton3")


            sql_exchange = " select *,Project_Activities.PActv_Desc " _
                    & " from activities_Needs_relationship" _
                    & " join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID " _
                    & " where activities_Needs_relationship.need_id = '" & txtneedID.Text & "'" _
                    & " order by Project_Activities.PActv_ID"
            dt_ = General_Helping.GetDataTable(sql_exchange)
            If dt_.Rows.Count > 0 Then

            Else
                gvMain.Rows(rwIndex).FindControl("btnshow").Visible = False
            End If


            If gvMain.Rows(rwIndex).Cells(8).Text = gvMain.Rows(rwIndex).Cells(9).Text Then
                newRecieve.Enabled = False
                txtActualCheck.Enabled = False
                newRecieveDate.Enabled = False
                'FUp1.Visible = False
                imgbtncalender.Visible = False
                gvMain.Rows(rwIndex).FindControl("btnshow").Visible = False
            Else
                cnt += 1

            End If
        Next
        If cnt > 0 Then
            BtnSave.Visible = True
        Else
            BtnSave.Visible = False
        End If
        'FileUpload1.Controls.Clear()
        txtFileName.Text = ""
        TxtDes.Text = ""

        If dt.Rows.Count = 0 Then
            tbl_doc.Visible = False
            BtnSave.Visible = False
        End If



        '    Dim sql1 As String = ""
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
        'Dim str2 As String = ""
        'sql2 = "SELECT SUM(recieved_amount) AS total_recieved_amount FROM need_Recieve where pned_pned_id=" & ddlItem.SelectedValue
        'Dim dt1 As New DataTable
        'dt1 = General_Helping.GetDataTable(sql2)
        'Dim sql3 As String = "select Project_Needs.* from Project_Needs where PNed_ID=" & ddlItem.SelectedValue
        'Dim dt3 As New DataTable
        'dt3 = General_Helping.GetDataTable(sql3)
        'Dim str As String = dt3.Rows(0)("PNed_Number")
        'Dim str1() As String = str.Split(".")
        'lblamnt.Text = str1(0)

        ''done by moataz 

        'If Not dt3.Rows(0)("PNed_InitValue") Is DBNull.Value Then
        '    str2 = dt3.Rows(0)("PNed_InitValue")
        'End If

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

        'Dim sql_exchange As String = "select * from need_Recieve where pned_pned_id= " & ddlItem.SelectedValue
        'Dim dt_ As New DataTable
        'dt_ = General_Helping.GetDataTable(sql_exchange)
        'If (dt_.Rows.Count > 0) Then
        '    Dim str_exchange As String = dt_.Rows(0)("exchange_amount").ToString()
        '    txtExchange.Text = str_exchange
        'End If

    End Sub

    Private Sub FillGridveiw2()
        Dim sql_exchange1 As String = "select *,Project_Activities.PActv_Desc " _
           & " from activities_Needs_relationship" _
           & " join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID " _
           & " where activities_Needs_relationship.need_id = '" & need_id.Value & "'" _
           & " order by Project_Activities.PActv_ID"

        Dim dt_1 As New DataTable
        dt_1 = General_Helping.GetDataTable(sql_exchange1)

        GridView2.Visible = True
        GridView2.DataSource = dt_1
        GridView2.DataBind()


    End Sub


    Private Sub FillGridveiw1()
        Dim dt As New DataTable
        Dim sql As String = "select Need_Recieve_Document.*, Need_Recieve.* from Need_Recieve left join Need_Recieve_Document on Need_Recieve.Recieve_Doc_id=Need_Recieve_Document.id where PNed_PNed_Id=" & need_id.Value & " order by convert(datetime, recieved_amount_date, 103) desc"
        dt = General_Helping.GetDataTable(sql)
        GridView1.Visible = True
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Private Sub fillgridneedreivedocs()
        OpenConnection()
        'Dim cmd1 As New SqlCommand(" select * from ")
        Dim cmd As New SqlCommand("SELECT DISTINCT Need_Recieve_Document.id,Need_Recieve_Document.[File_name] FROM dbo.Need_Recieve_Document  JOIN dbo.Need_Recieve ON  dbo.Need_Recieve_Document.id =dbo.Need_Recieve.Recieve_Doc_id JOIN dbo.Project_Needs ON  dbo.Need_Recieve.pned_pned_id =dbo.Project_Needs.PNed_ID  where Project_Needs.proj_proj_id = " & Session_CS.Project_id, con)
        cmd.Connection = con
        Dim sqladptr As SqlDataAdapter = New SqlDataAdapter
        sqladptr.SelectCommand = cmd
        Dim DT As DataTable = New DataTable()
        sqladptr.Fill(DT)
        'GridNeed.DataSource = DT
        'GridNeed.DataBind()
        con.Close()
    End Sub

    'Public Sub chklistchoose_changed()

    '        If chktype.Value = "1" Then
    '            newone.Visible = True
    '            oldone.Visible = False
    '            chklistchoose.Items(0).Selected = True
    '            chklistchoose.Items(1).Selected = False
    '            chktype.Value = "0"
    '        ElseIf chktype.Value = "0" Then
    '            newone.Visible = False
    '            oldone.Visible = True
    '            chklistchoose.Items(0).Selected = False
    '            chklistchoose.Items(1).Selected = True
    '            chktype.Value = "1"
    '        End If



    'End Sub
#End Region

#Region "Save Data"
    Public Sub newSubSave()

        Dim txtamount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtRecieve_amount")

        Dim txtexchange_amount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtexchange_amount")

        Dim txtrecieved_amount_date As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieved_amount_date")

        Dim txtrecieve_organization As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieve_organization")

        Dim txtrecieve_organization_person As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieve_organization_person")
        Dim rwchkbox As CheckBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("CheckBox1")
        'Dim FUp1 As FileUpload = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("FileUpload1")

        Dim err As Label = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("lblError")
        Dim err2 As Label = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("lblError2")
        err.Visible = False
        err2.Visible = False
        Dim needId As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtneedid")
        Dim txtrecieveid As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieveid")
        Need_Av_Ids.Value = needId.Text
        Dim oldAmount As Integer = CDataConverter.ConvertToInt(General_Helping.GetDataTable("select recieved_amount from Need_Recieve where need_recieve_id=" & CDataConverter.ConvertToInt(txtrecieveid.Text)).Rows(0)("recieved_amount").ToString())
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If txtamount.Text <> "" Then
            If Integer.Parse(txtamount.Text) = 0 Then
                lblPageStatus.Text = "الكمية المنصرفة لايمكن أن تساوى 0"
                lblPageStatus.Visible = True
                err.Visible = True
                Return
            End If

            Dim totAvailble As String = gvMain.Rows(Integer.Parse(myRowIndex2.Value)).Cells(8).Text
            Dim oldTotalRecieve As String = gvMain.Rows(Integer.Parse(myRowIndex2.Value)).Cells(9).Text
            Dim total_recieve As Integer
            If oldTotalRecieve <> "&nbsp;" And totAvailble <> "" Then
                total_recieve = Integer.Parse(oldTotalRecieve) + Integer.Parse(txtamount.Text) - oldAmount
                If total_recieve > Integer.Parse(totAvailble) Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "إجمالى الكمية المنصرفة تتخطى الكمية المتاحة"
                    'FillGridveiw1()

                    err.Visible = True
                    Return
                End If
            ElseIf totAvailble <> "" Then
                total_recieve = Integer.Parse(txtamount.Text)
                If total_recieve > Integer.Parse(totAvailble) Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "إجمالى الكمية المنصرفة تتخطى الكمية المتاحة"
                    ' FillGridveiw1()

                    err.Visible = True
                    Return
                End If
            End If
            'Dim datet As DateTime = System.DateTime.Now
            'Dim today As String = datet.ToString("dd/MM/yyyy")
            Dim validated_date As String = ""

            validated_date = txtrecieved_amount_date.Text
            If validated_date = "" Then
                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                lblPageStatus.Visible = True
                txtrecieved_amount_date.Text = ""
                err2.Visible = True
                Return
            End If

            'saveNewDoc()



            Dim cmd As New SqlCommand()
            OpenConnection()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Need_Recieve set recieved_amount=@recieved_amount,exchange_amount=@exchange_amount,recieved_amount_date=@recieved_amount_date,recieve_organization=@recieve_organization,recieve_organization_person=@recieve_organization_person,Recieve_Doc_id=@Recieve_Doc_id where need_recieve_id=" & CDataConverter.ConvertToInt(txtrecieveid.Text) & ""

            cmd.Parameters.Add("@recieved_amount", SqlDbType.BigInt)

            cmd.Parameters.Add("@exchange_amount", SqlDbType.Decimal)
            cmd.Parameters.Add("@recieved_amount_date", SqlDbType.NVarChar, 50)
            cmd.Parameters.Add("@recieve_organization", SqlDbType.VarChar, 500)
            cmd.Parameters.Add("@recieve_organization_person", SqlDbType.VarChar, 500)
            'cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
            'cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
            'cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)

            cmd.Parameters.Add("@Recieve_Doc_id", SqlDbType.Int)


            cmd.Parameters("@recieved_amount").Value = CDataConverter.ConvertToInt(txtamount.Text)


            cmd.Parameters("@exchange_amount").Value = CDataConverter.ConvertToDecimal(txtexchange_amount.Text)


            cmd.Parameters("@recieved_amount_date").Value = validated_date
            cmd.Parameters("@recieve_organization").Value = txtrecieve_organization.Text
            cmd.Parameters("@recieve_organization_person").Value = txtrecieve_organization_person.Text


            Dim theDocId As Integer = CDataConverter.ConvertToInt(General_Helping.GetDataTable("select Recieve_Doc_id from Need_Recieve where need_recieve_id=" & CDataConverter.ConvertToInt(txtrecieveid.Text)).Rows(0)("Recieve_Doc_id"))
            If rwchkbox.Checked = True Then
                cmd.Parameters("@Recieve_Doc_id").Value = CDataConverter.ConvertToInt(doc_id.Value)
            Else
                cmd.Parameters("@Recieve_Doc_id").Value = theDocId
            End If


            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try


            General_Helping.ExcuteQuery("update Project_Needs set TotalDelievered =" & total_recieve & " where PNed_ID=" & Integer.Parse(Need_Av_Ids.Value))

            lblPageStatus.Visible = True
            lblPageStatus.Text = "تم التعديل بنجاح"
            FillGrid()
            FillGridveiw1()

            'fillgridneedreivedocs()

            err.Visible = False
            err2.Visible = False



        End If


    End Sub
    Private Sub saveNewDoc()

        '''''''save doc
        Dim cmd1 As New SqlCommand()
        If (FileUpload1.HasFile = True) Then
            Dim DocName As String = ""
            Dim type As String = ""
            Dim fileLen As Integer
            Dim displayString As New StringBuilder()

            Dim myStream As System.IO.Stream

            OpenConnection()
            cmd1.Connection = con
            cmd1.CommandType = CommandType.Text
            cmd1.CommandText = "insert into Need_Recieve_Document (File_name,File_data,Doc_Desc,File_ext) VALUES(@File_name,@File_data,@Doc_Desc,@File_ext)"

            cmd1.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
            cmd1.Parameters.Add("@File_data", SqlDbType.VarBinary)
            cmd1.Parameters.Add("@Doc_Desc", SqlDbType.NVarChar, 250)
            cmd1.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)

            fileLen = FileUpload1.PostedFile.ContentLength
            Dim Input(fileLen) As Byte
            myStream = FileUpload1.FileContent
            myStream.Read(Input, 0, fileLen)
            DocName = FileUpload1.FileName
            Dim dotindex As Integer = DocName.LastIndexOf(".")
            type = DocName.Substring(dotindex, DocName.Length - dotindex)
            If (txtFileName.Text <> "") Then
                cmd1.Parameters("@File_name").Value = txtFileName.Text
            Else
                cmd1.Parameters("@File_name").Value = DocName
            End If

            cmd1.Parameters("@File_data").Value = Input
            cmd1.Parameters("@Doc_Desc").Value = TxtDes.Text
            cmd1.Parameters("@File_ext").Value = type

            Try
                Dim mydocststus As Integer = cmd1.ExecuteNonQuery()
                If mydocststus > 0 Then

                    Dim sql11 As String = "SELECT MAX(id) AS max_recieve_doc FROM Need_Recieve_Document"
                    Dim dt11 As New DataTable
                    dt11 = General_Helping.GetDataTable(sql11)
                    doc_id.Value = dt11.Rows(0)("max_recieve_doc").ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Else
            doc_id.Value = "0"
        End If


        '''''
    End Sub

    Public Sub newSave()
        If checkValidFornewSave() = False Then
            Return
        End If
        'saveNewDoc()
        For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1


            Dim need_id As TextBox = gvMain.Rows(rwIndex).FindControl("txtPnedid")
            Need_Av_Ids.Value = need_id.Text
            Dim textActivities As TextBox = gvMain.Rows(rwIndex).FindControl("txtActivIDs")
            Dim textAmounts As TextBox = gvMain.Rows(rwIndex).FindControl("txtAmounts")
            Dim textMoneys As TextBox = gvMain.Rows(rwIndex).FindControl("txtMoneys")
            Dim strActiv() As String = textActivities.Text.Split(",")
            Dim strAmounts() As String = textAmounts.Text.Split(",")
            Dim strMoneys() As String = textMoneys.Text.Split(",")
            Dim newrecieve As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewrecievedAmount")
            Dim txtRecieve_person As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieve_person")
            Dim txtRecieve_organization As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieve_organization")
            Dim txtexchange As TextBox = gvMain.Rows(rwIndex).FindControl("txtexchange")
            Dim newRecieveDate As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieveDate")
            Dim rwchkbox As CheckBox = gvMain.Rows(rwIndex).FindControl("CheckBox1")
            Dim validated_date As String = newRecieveDate.Text

            Dim totAvailble As String = gvMain.Rows(rwIndex).Cells(8).Text
            Dim oldTotalRecieve As String = gvMain.Rows(rwIndex).Cells(9).Text
            Dim total_recieve As Integer

            If newrecieve.Text <> "" Then


                If oldTotalRecieve <> "&nbsp;" And totAvailble <> "" Then
                    total_recieve = Integer.Parse(oldTotalRecieve) + Integer.Parse(newrecieve.Text)

                ElseIf totAvailble <> "" Then
                    total_recieve = Integer.Parse(newrecieve.Text)

                End If
                Dim cmd As New SqlCommand()
                OpenConnection()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "insert into Need_Recieve (recieved_amount,pned_pned_id ,exchange_amount,recieved_amount_date,recieve_organization,recieve_organization_person,Recieve_Doc_id) values(@recieved_amount,@pned_pned_id,@exchange_amount,@recieved_amount_date,@recieve_organization,@recieve_organization_person,@Recieve_Doc_id)"

                cmd.Parameters.Add("@recieved_amount", SqlDbType.BigInt)
                cmd.Parameters.Add("@pned_pned_id", SqlDbType.Int)
                cmd.Parameters.Add("@exchange_amount", SqlDbType.Decimal)
                cmd.Parameters.Add("@recieved_amount_date", SqlDbType.NVarChar, 50)
                cmd.Parameters.Add("@recieve_organization", SqlDbType.VarChar, 500)
                cmd.Parameters.Add("@recieve_organization_person", SqlDbType.VarChar, 500)
                'cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                'cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
                'cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@Recieve_Doc_id", SqlDbType.Int)



                cmd.Parameters("@recieved_amount").Value = CDataConverter.ConvertToInt(newrecieve.Text)
                cmd.Parameters("@pned_pned_id").Value = CDataConverter.ConvertToInt(Need_Av_Ids.Value)

                cmd.Parameters("@exchange_amount").Value = CDataConverter.ConvertToDecimal(txtexchange.Text)


                cmd.Parameters("@recieved_amount_date").Value = validated_date
                cmd.Parameters("@recieve_organization").Value = txtRecieve_organization.Text
                cmd.Parameters("@recieve_organization_person").Value = txtRecieve_person.Text

                If rwchkbox.Checked = True Then
                    cmd.Parameters("@Recieve_Doc_id").Value = CDataConverter.ConvertToInt(doc_id.Value)
                Else
                    cmd.Parameters("@Recieve_Doc_id").Value = 0
                End If

                'div1.Style.Add("display", "block")





                Try
                    cmd.ExecuteNonQuery()


                    Dim count As Integer = strActiv.Length
                    If count > 0 Then


                        For cnt = 0 To strActiv.Length - 2
                            Dim sql_exchange1 As String = "select *,Project_Activities.PActv_Desc " _
                           & " from activities_Needs_relationship" _
                           & " join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID " _
                           & " where activities_Needs_relationship.need_id = '" & Need_Av_Ids.Value & "'" _
                           & " and activities_Needs_relationship.actv_id='" & strActiv(cnt) & "'" _
                           & " order by Project_Activities.PActv_ID"

                            Dim dt_1 As New DataTable
                            dt_1 = General_Helping.GetDataTable(sql_exchange1)

                            General_Helping.ExcuteQuery("update activities_Needs_relationship set total=" & CDataConverter.ConvertToInt(strMoneys(cnt)) + CDataConverter.ConvertToInt(dt_1.Rows(0)("total").ToString()) & ",amount =" & CDataConverter.ConvertToInt(strAmounts(cnt)) + CDataConverter.ConvertToInt(dt_1.Rows(0)("amount").ToString()) & " where actv_id=" & CDataConverter.ConvertToInt(strActiv(cnt)) & "and need_id=" & Integer.Parse(Need_Av_Ids.Value))

                        Next
                    End If

                Catch ex As Exception
                    Throw ex
                End Try


                'General_Helping.ExcuteQuery("insert into Need_Recieve (recieved_amount,pned_pned_id ,exchange_amount,recieved_amount_date,recieve_organization,recieve_organization_person,File_data,File_ext,File_name) values(" & Integer.Parse(newrecieve.Text) & "," & Need_Av_Ids.Value & "," & Decimal.Parse(txtexchange.Text) & ", '" & validated_date & "','" & txtRecieve_organization.Text & "','" & txtRecieve_person.Text & "',"  ,Input  ")")
                General_Helping.ExcuteQuery("update Project_Needs set TotalDelievered =" & total_recieve & " where PNed_ID=" & Integer.Parse(Need_Av_Ids.Value))

                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
                'FileUpload1.Controls.Clear()
                Dim sql11 As String = ""
                sql11 = "SELECT MAX(need_recieve_id) AS Largest_need_recieve_id FROM Need_Recieve"
                Dim dt11 As New DataTable
                dt11 = General_Helping.GetDataTable(sql11)

                Project_Log_DB.FillLog(CDataConverter.ConvertToInt(dt11.Rows(0)("Largest_need_recieve_id")), Project_Log_DB.Action.add, Project_Log_DB.operation.Project_Needs_Recieve)



            Else

                Continue For
            End If




        Next

        FillGrid()
        'fillgridneedreivedocs()
        GridView1.Visible = False
        GridView2.Visible = False
        myRowIndex2.Value = ""
        TR2.Visible = False
    End Sub
    Public Sub saveAddAnotherDoc(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, Button).CommandName = "save" Then
            saveNewDoc()

            Dim dt As DataTable = General_Helping.GetDataTable("select id,File_name from Need_Recieve_Document where id=" & Integer.Parse(doc_id.Value))
            If dt.Rows.Count > 0 Then
                editCurrentDoc.Visible = True
                newone.Visible = False
                hrefDoc.HRef = "ALL_Document_Details.aspx?type=projectrecieveNew&id=" & dt.Rows(0)("id").ToString
                hrefDoc.InnerText = "- " + dt.Rows(0)("File_name").ToString
                lbledit.Text = "تم إضافة وثيقة"
                Dim cnt As Integer = 0
                For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1
                    If gvMain.Rows(rwIndex).Cells(8).Text <> gvMain.Rows(rwIndex).Cells(9).Text Then
                        cnt += 1
                    End If
                Next


            Else
                lblAddExistDoc.Text = "لم تتم إضافة وثيقة"
                lblAddExistDoc.ForeColor = Drawing.Color.Red
            End If

        ElseIf CType(sender, Button).CommandName = "change" Then
            editCurrentDoc.Visible = False
            newone.Visible = True
            doc_id.Value = "0"
            txtFileName.Text = ""
            TxtDes.Text = ""

            lblAddExistDoc.Text = "اضف وثيقة جديدة"

        End If

    End Sub

#End Region

#Region "validation"
    Private Function checkValidFornewSave() As Boolean
        For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1
            Dim err As Label = gvMain.Rows(rwIndex).FindControl("lblError")
            Dim err2 As Label = gvMain.Rows(rwIndex).FindControl("lblError2")
            err.Visible = False
            err2.Visible = False
            Dim need_id As TextBox = gvMain.Rows(rwIndex).FindControl("txtPnedid")
            Need_Av_Ids.Value = need_id.Text
            Dim textActivities As TextBox = gvMain.Rows(rwIndex).FindControl("txtActivIDs")
            Dim textAmounts As TextBox = gvMain.Rows(rwIndex).FindControl("txtAmounts")
            Dim textMoneys As TextBox = gvMain.Rows(rwIndex).FindControl("txtMoneys")
            Dim strActiv() As String = textActivities.Text.Split(",")
            Dim strAmounts() As String = textAmounts.Text.Split(",")
            Dim strMoneys() As String = textMoneys.Text.Split(",")
            Dim newrecieve As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewrecievedAmount")
            Dim txtRecieve_person As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieve_person")
            Dim txtRecieve_organization As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieve_organization")
            Dim txtexchange As TextBox = gvMain.Rows(rwIndex).FindControl("txtexchange")
            Dim newRecieveDate As TextBox = gvMain.Rows(rwIndex).FindControl("txtRecieveDate")
            Dim rwchkbox As CheckBox = gvMain.Rows(rwIndex).FindControl("CheckBox1")
            'Dim NeedDate As String = gvMain.Rows(rwIndex).Cells(4).Text

            lblPageStatus.Text = ""
            lblPageStatus.Visible = False
            If newrecieve.Text <> "" Then
                If Integer.Parse(newrecieve.Text) = 0 Then
                    lblPageStatus.Text = "الكمية المنصرفة لايمكن أن تساوى 0"
                    lblPageStatus.Visible = True
                    err.Visible = True
                    Return False
                End If

                Dim totAvailble As String = gvMain.Rows(rwIndex).Cells(8).Text
                Dim oldTotalRecieve As String = gvMain.Rows(rwIndex).Cells(9).Text
                Dim total_recieve As Integer
                If oldTotalRecieve <> "&nbsp;" And totAvailble <> "" Then
                    total_recieve = Integer.Parse(oldTotalRecieve) + Integer.Parse(newrecieve.Text)
                    If total_recieve > Integer.Parse(totAvailble) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "إجمالى الكمية المنصرفة تتخطى الكمية المتاحة"
                        'FillGridveiw1()

                        err.Visible = True
                        Return False
                    End If
                ElseIf totAvailble <> "" Then
                    total_recieve = Integer.Parse(newrecieve.Text)
                    If total_recieve > Integer.Parse(totAvailble) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "إجمالى الكمية المنصرفة تتخطى الكمية المتاحة"
                        'FillGridveiw1()

                        err.Visible = True
                        Return False
                    End If
                End If
                'Dim datet As DateTime = System.DateTime.Now
                'Dim today As String = datet.ToString("dd/MM/yyyy")
                Dim validated_date As String = ""

                validated_date = newRecieveDate.Text

                If validated_date = "" Then
                    lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                    lblPageStatus.Visible = True
                    newRecieveDate.Text = ""
                    err2.Visible = True
                    Return False
                End If
                ''''''

                'If NeedDate <> "&nbsp;" And validated_date <> "" Then
                '    If Dates.Dates_operations.Date_compare(NeedDate, validated_date) Then
                '        lblPageStatus.Visible = False
                '    Else
                '        lblPageStatus.Visible = True
                '        lblPageStatus.Text = "تاريخ الصرف يجب أن يأتى قبل تاريخ طلب توفير الاحتياج "
                '        Return False
                '    End If
                'End If
                '    Dim sql As String = "select min(Availble_Amount_Date) as min_Availble_Amount_Date from Need_Availble where PNed_PNed_Id=" & ddlItem.SelectedValue
                '    Dim dt As DataTable = General_Helping.GetDataTable(sql)
                '    If dt.Rows.Count > 0 And dt.Rows(0)("min_Availble_Amount_Date").ToString <> "" And validated_date <> "" Then
                '        If VB_Classes.Dates.Date_compare(validated_date, dt.Rows(0)("min_Availble_Amount_Date")) Then
                '            lblPageStatus.Visible = False
                '        Else
                '            lblPageStatus.Visible = True
                '            lblPageStatus.Text = "تاريخ الصرف يجب أن يأتى بعد تاريخ الاتاحة "
                '            Return
                '        End If
                '    End If



                '''''

                err.Visible = False
                err2.Visible = False
            Else


                Continue For
            End If





        Next
        lblPageStatus.Visible = False
        Return True
    End Function
#End Region

#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        newSave()
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try


            If CType(sender, ImageButton).CommandName = "edit" Then
                myRowIndex1.Value = CType(sender, ImageButton).CommandArgument
                Dim imgbtnsave As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImgBtnSave")
                imgbtnsave.Visible = True
                Dim imgbtnedit As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImgBtnEdit")
                imgbtnedit.Visible = False
                Dim txtamount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtRecieve_amount")
                txtamount.ReadOnly = False
                Dim txtexchange_amount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtexchange_amount")
                txtexchange_amount.ReadOnly = False
                Dim txtrecieved_amount_date As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieved_amount_date")
                txtrecieved_amount_date.ReadOnly = False
                Dim ImageButton3 As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImageButton3")
                ImageButton3.Visible = True
                Dim txtrecieve_organization As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieve_organization")
                txtrecieve_organization.ReadOnly = False
                Dim txtrecieve_organization_person As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieve_organization_person")
                txtrecieve_organization_person.ReadOnly = False
                Dim hrefDoc As HtmlAnchor = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("hrefDoc")
                hrefDoc.Visible = False
                'Dim FileUpload1 As FileUpload = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("FileUpload1")
                'FileUpload1.Visible = True
                Dim rwchkbox As CheckBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("CheckBox1")
                rwchkbox.Visible = True
                GridView1.HeaderRow.Cells(5).Text = "ربط بوثيقة الصرف"
                GridView1.HeaderRow.Cells(6).Text = "حـفظ"
                Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
                If current IsNot Nothing Then
                    current.RegisterPostBackControl(imgbtnedit)
                    current.RegisterPostBackControl(imgbtnsave)

                End If

                GridView1.Rows(Integer.Parse(myRowIndex1.Value)).BackColor = Drawing.Color.Lavender
                'ElseIf CType(sender, ImageButton).CommandName = "choose" Then
                '    myRowIndex3.Value = CType(sender, ImageButton).CommandArgument
                '    Dim txtdocid As TextBox = GridNeed.Rows(Integer.Parse(myRowIndex3.Value)).FindControl("txtdocid")
                '    doc_id.Value = txtdocid.Text
                '    For chrwIndex As Integer = 0 To GridNeed.Rows.Count - 1 Step 1
                '        Dim curimg As ImageButton = GridNeed.Rows(chrwIndex).FindControl("ImgBtnChoose")
                '        If CType(GridNeed.Rows(chrwIndex).FindControl("ImgBtnChoose"), ImageButton).CommandArgument = myRowIndex3.Value Then

                '            curimg.ImageUrl = "../Images/checked.jpg"
                '        Else

                '            curimg.ImageUrl = "../Images/unchecked.png"
                '        End If
                '    Next

            ElseIf CType(sender, ImageButton).CommandName = "save" Then
                myRowIndex1.Value = CType(sender, ImageButton).CommandArgument

                newSubSave()

                'Dim imgbtnsave As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImgBtnSave")
                'imgbtnsave.Visible = False
                'Dim imgbtnedit As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImgBtnEdit")
                'imgbtnedit.Visible = True
                'Dim txtamount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtRecieve_amount")
                'txtamount.ReadOnly = True
                'Dim txtexchange_amount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtexchange_amount")
                'txtexchange_amount.ReadOnly = True
                'Dim txtrecieved_amount_date As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieved_amount_date")
                'txtrecieved_amount_date.ReadOnly = True
                'Dim ImageButton3 As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImageButton3")
                'ImageButton3.Visible = False
                'Dim txtrecieve_organization As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieve_organization")
                'txtrecieve_organization.ReadOnly = True
                'Dim txtrecieve_organization_person As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtrecieve_organization_person")
                'txtrecieve_organization_person.ReadOnly = True
                'Dim hrefDoc As HtmlAnchor = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("hrefDoc")
                'hrefDoc.Visible = True
                'Dim FileUpload1 As FileUpload = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("FileUpload1")
                'FileUpload1.Visible = False
            ElseIf CType(sender, ImageButton).CommandName = "editActiv" Then
                myRowIndex4.Value = CType(sender, ImageButton).CommandArgument
                Dim txtneedid As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txtneedid")
                Dim txtActivid As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txtActivId")
                Dim txt_amount As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txtamount")
                txt_amount.ReadOnly = False
                'Dim txttotal As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txttotal")
                'txttotal.ReadOnly = False
                Dim imgbtnsave As ImageButton = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("ImgBtnSave")
                imgbtnsave.Visible = True
                Dim imgbtnedit As ImageButton = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("ImgBtnEdit")
                imgbtnedit.Visible = False
                GridView2.Rows(Integer.Parse(myRowIndex4.Value)).BackColor = Drawing.Color.Lavender
                Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
                If current IsNot Nothing Then
                    current.RegisterPostBackControl(imgbtnedit)
                    current.RegisterPostBackControl(imgbtnsave)

                End If

                GridView2.HeaderRow.Cells(3).Text = "حـفظ"
            ElseIf CType(sender, ImageButton).CommandName = "saveActiv" Then
                myRowIndex4.Value = CType(sender, ImageButton).CommandArgument
                Dim txtneedid As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txtneedid")
                Dim txtActivid As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txtActivId")
                Dim txtamount As TextBox = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("txtamount")


                Dim Sql As String = "select PNed_ID ,(SELECT sum(recieved_amount) from Need_Recieve where Need_Recieve.PNed_PNed_Id =Project_Needs.PNed_ID) as recieved_amount from Project_Needs" _
                    & " where Project_Needs.PNed_ID= " & CDataConverter.ConvertToInt(txtneedid.Text)
                Dim dt As DataTable = General_Helping.GetDataTable(Sql)
                Dim oldTotalRecieve As String = dt.Rows(0)("recieved_amount").ToString

                Dim amount_sum As Integer = 0
                For drRwindex As Integer = 0 To GridView2.Rows.Count - 1 Step 1
                    Dim txtEachRwAmount As TextBox = GridView2.Rows(drRwindex).FindControl("txtamount")
                    amount_sum += CDataConverter.ConvertToInt(txtEachRwAmount.Text)

                    If oldTotalRecieve <> "&nbsp;" Then

                        If amount_sum > CDataConverter.ConvertToInt(oldTotalRecieve) Then
                            lblPageStatus.Visible = True

                            lblPageStatus.Text = "إجمالى الكمية الموزعة تتخطى الكمية المنصرفة لهذا الإحتياج"
                            FillGridveiw2()
                            Dim err As Label = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("lblError")
                            err.Visible = True
                            Return
                        End If

                    End If
                Next

                Try


                    General_Helping.ExcuteQuery("update activities_Needs_relationship set total=" & CDataConverter.ConvertToInt(txtamount.Text) * CDataConverter.ConvertToInt(General_Helping.GetDataTable("select PNed_InitValue from Project_Needs where PNed_ID=" & CDataConverter.ConvertToInt(txtneedid.Text)).Rows(0)("PNed_InitValue")) & ",amount =" & CDataConverter.ConvertToInt(txtamount.Text) & " where actv_id=" & CDataConverter.ConvertToInt(txtActivid.Text) & "and need_id=" & CDataConverter.ConvertToInt(txtneedid.Text))
                    FillGridveiw2()

                    lblPageStatus.Text = "تم الحفظ"
                    lblPageStatus.Visible = True
                    Dim err As Label = GridView2.Rows(Integer.Parse(myRowIndex4.Value)).FindControl("lblError")
                    err.Visible = False
                Catch ex As Exception
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "عفوا لا يمكن الحفظ"
                End Try


            End If
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن العرض"
        End Try
        'Clear()
        'Dim sql2 As String = ""
        'sql2 = "SELECT SUM(recieved_amount) AS total_recieved_amount FROM need_Recieve where pned_pned_id=" & ddlItem.SelectedValue
        'Dim sql_exchange As String = "select * from need_Recieve where pned_pned_id= " & ddlItem.SelectedValue
        'Dim dt_ As New DataTable
        'dt_ = General_Helping.GetDataTable(sql_exchange)
        'Dim str_exchange As String = dt_.Rows(0)("exchange_amount").ToString()
        'txtExchange.Text = str_exchange
        'Dim dt1 As New DataTable
        'dt1 = General_Helping.GetDataTable(sql2)
        'Dim sql3 As String = "select Project_Needs.* from Project_Needs where PNed_ID=" & ddlItem.SelectedValue
        'Dim dt3 As New DataTable
        'dt3 = General_Helping.GetDataTable(sql3)
        'Dim str As String = dt3.Rows(0)("PNed_Number")
        'Dim str1() As String = str.Split(".")
        'lblamnt.Text = str1(0)
        'If Not dt3.Rows(0)("approved_amount") Is DBNull.Value Then
        '    lblApprovedAmount.Text = dt3.Rows(0)("approved_amount")
        '    If Not dt1.Rows(0)("total_recieved_amount") Is DBNull.Value Then
        '        lbltotaldelivers.Text = dt1.Rows(0)("total_recieved_amount")
        '        lblremain.Text = lblApprovedAmount.Text - lbltotaldelivers.Text
        '    Else
        '        lbltotaldelivers.Text = 0
        '        lblremain.Text = lblApprovedAmount.Text
        '    End If
        'End If
        'BtnSave.CommandArgument = "edit"
        'Dim dt As New DataTable
        'Dim sql As String = "select need_Recieve.* from need_recieve where need_recieve_id=" & CType(sender, ImageButton).CommandArgument
        'dt = General_Helping.GetDataTable(sql)
        'If Not dt.Rows(0)("recieved_amount") Is DBNull.Value Then
        '    txtRecievedAmount.Text = dt.Rows(0)("recieved_amount")
        '    lblremain.Text = Decimal.Parse(lblremain.Text) + Decimal.Parse(txtRecievedAmount.Text)
        '    lbltotaldelivers.Text = Decimal.Parse(lbltotaldelivers.Text) - Decimal.Parse(txtRecievedAmount.Text)
        'End If
        'If Not dt.Rows(0)("recieve_organization") Is DBNull.Value Then
        '    TxtOrg.Text = dt.Rows(0)("recieve_organization")
        'End If
        'If Not dt.Rows(0)("recieve_organization_person") Is DBNull.Value Then
        '    TxtPerson.Text = dt.Rows(0)("recieve_organization_person")
        'End If
        'If Not dt.Rows(0)("recieved_amount_date") Is DBNull.Value Then

        '    txtRecievedDate.Text = dt.Rows(0)("recieved_amount_date")
        'End If

        'If Not dt.Rows(0)("File_name") Is DBNull.Value Then

        '    TxtDocName.Text = dt.Rows(0)("File_name")
        'End If
        'need_recieve_id.Value = CType(sender, ImageButton).CommandArgument
        'lblPageStatus.Visible = False
        'Dim i As Integer = 0
        'Dim id As Integer
        'For Each row As GridViewRow In gvMain.Rows
        '    If CType(gvMain.Rows(i).FindControl("need_recieve_id"), HtmlControls.HtmlInputHidden).Value = need_recieve_id.Value Then
        '        id = i
        '    Else
        '        gvMain.Rows(i).BackColor = Drawing.Color.White
        '    End If
        '    i += 1
        'Next
        'gvMain.Rows(id).BackColor = Drawing.Color.Lavender



        'BtnSave.Text = "تعديــــل"
        'lblPageStatus.Text = ""
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Try
            General_Helping.ExcuteQuery("DELETE FROM Need_Recieve WHERE need_recieve_id=" & CType(sender, ImageButton).CommandArgument)

            FillGrid()
            FillGridveiw1()
            FillGridveiw2()

            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try


    End Sub

    Protected Sub ImgBtnveiw_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try

            need_id.Value = CType(sender, ImageButton).CommandArgument
            myRowIndex2.Value = CType(sender, ImageButton).CommandName
            FillGridveiw1()

            FillGridveiw2()
            TR2.Visible = True
            For i As Integer = 0 To gvMain.Rows.Count - 1 Step 1
                gvMain.Rows(i).BackColor = Drawing.Color.White
            Next
            gvMain.Rows(Integer.Parse(myRowIndex2.Value)).BackColor = Drawing.Color.Lavender
            lblPageStatus.Visible = False
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن العرض"
            GridView1.Visible = False
            GridView2.Visible = False
        End Try
    End Sub


    Protected Sub showPopupGrid(ByVal s As Object, ByVal e As EventArgs)
        lblPageStatus.Visible = False
        need_id.Value = CType(s, Button).CommandArgument
        myRowIndex.Value = CType(s, Button).CommandName
        Dim textnewRecieve As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtnewrecievedAmount")
        If CDataConverter.ConvertToInt(textnewRecieve.Text) < 1 Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لايمكن توزيع صرف على الأنشطة المرتبطة بدون إضافة كمية للصرف أولا"
            Return
        End If
        Dim sql_exchange As String = "select *,Project_Activities.PActv_Desc " _
         & " from activities_Needs_relationship" _
         & " join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID " _
         & " where activities_Needs_relationship.need_id = '" & need_id.Value & "'" _
         & " order by Project_Activities.PActv_ID"

        Dim dt_ As New DataTable
        dt_ = General_Helping.GetDataTable(sql_exchange)

        gvActivities.DataSource = dt_
        gvActivities.DataBind()
        overlay.Style.Add(HtmlTextWriterStyle.Display, "block")
        popup.Style.Add(HtmlTextWriterStyle.Display, "block")



        Dim textActivities As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtActivIDs")
        Dim textAmounts As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtAmounts")
        Dim textMoneys As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtMoneys")

        Dim count As Integer


        Dim strActiv() As String = textActivities.Text.Split(",")
        Dim strAmounts() As String = textAmounts.Text.Split(",")
        Dim strMoneys() As String = textMoneys.Text.Split(",")
        count = strActiv.Length
        If count > 0 Then
            Dim grdtextActivities As TextBox

            For cnt = 0 To strActiv.Length - 2
                For drRwindex As Integer = 0 To dt_.Rows.Count - 1 Step 1
                    grdtextActivities = gvActivities.Rows(drRwindex).FindControl("txtPActv_ID")
                    If grdtextActivities.Text = strActiv(cnt) Then
                        Dim grdtextAmounts As TextBox = gvActivities.Rows(drRwindex).FindControl("txtamount")
                        Dim grdtextMoneys As TextBox = gvActivities.Rows(drRwindex).FindControl("txttotal")
                        grdtextAmounts.Text = strAmounts(cnt)
                        grdtextMoneys.Text = strMoneys(cnt)

                    End If
                Next
            Next
        End If









    End Sub
    Protected Sub savePopupGrid(ByVal s As Object, ByVal e As EventArgs)
        Dim amount_sum As Integer = 0
        'Dim totalsrf As Integer = CDataConverter.ConvertToInt(gvMain.Rows(myRowIndex.Value).Cells(9))
        Dim textnewRecieve As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtnewrecievedAmount")
        Dim textActivities As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtActivIDs")
        Dim textAmounts As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtAmounts")
        Dim textMoneys As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtMoneys")
        Dim txtneedid As TextBox = gvMain.Rows(Integer.Parse(myRowIndex.Value)).FindControl("txtneedid")
        Dim totAvailble As String = gvMain.Rows(myRowIndex.Value).Cells(8).Text
        Dim oldTotalRecieve As String = gvMain.Rows(myRowIndex.Value).Cells(9).Text
        Dim Sql As String = "SELECT sum(amount) as activ_recieved_amount from activities_Needs_relationship where " _
            & " activities_Needs_relationship.need_id= " & CDataConverter.ConvertToInt(txtneedid.Text)
        Dim dtt As DataTable = General_Helping.GetDataTable(Sql)
        Dim oldTotalRecieve1 As String = dtt.Rows(0)("activ_recieved_amount").ToString
        Dim oldTotalRecieve2 As Integer = CDataConverter.ConvertToInt(oldTotalRecieve) + Integer.Parse(textnewRecieve.Text)
        If CDataConverter.ConvertToInt(oldTotalRecieve1) >= oldTotalRecieve2 Then
            lblpopupStatus.Visible = True
            lblpopupStatus.ForeColor = Drawing.Color.Red
            lblpopupStatus.Text = "الكمية الموزعه على الانشطة تتساوى او تتخطى الكمية المنصرفة لهذا الإحتياج"
            FillGridveiw2()

            Return
        End If
        For drRwindex As Integer = 0 To gvActivities.Rows.Count - 1 Step 1
            Dim grdtextAmounts As TextBox = gvActivities.Rows(drRwindex).FindControl("txtamount")
            Dim grdtextMoneys As TextBox = gvActivities.Rows(drRwindex).FindControl("txttotal")
            Dim grdtextActivities As TextBox = gvActivities.Rows(drRwindex).FindControl("txtPActv_ID")
            If (grdtextAmounts.Text <> "" Or grdtextAmounts.Text <> "0") And (grdtextMoneys.Text <> "" Or grdtextMoneys.Text <> "0") Then
                textActivities.Text += grdtextActivities.Text & ","
                textAmounts.Text += grdtextAmounts.Text & ","
                grdtextMoneys.Text = (CDataConverter.ConvertToInt(grdtextAmounts.Text) * CDataConverter.ConvertToInt(General_Helping.GetDataTable("select PNed_InitValue from Project_Needs where PNed_ID=" & need_id.Value).Rows(0)("PNed_InitValue"))).ToString()
                textMoneys.Text += grdtextMoneys.Text & ","

            End If
            amount_sum += CDataConverter.ConvertToInt(grdtextAmounts.Text)
            If amount_sum > Integer.Parse(textnewRecieve.Text) Then
                lblpopupStatus.Visible = True
                lblpopupStatus.ForeColor = Drawing.Color.Red
                lblpopupStatus.Text = "الكمية الموزعه على الانشطة اكبر من الكمية المراد صرفها لهذا الإحتياج"

                grdtextAmounts.Text = ""
                grdtextMoneys.Text = ""
                Return
            End If


            Dim total_recieve As Integer

            If oldTotalRecieve <> "&nbsp;" And totAvailble <> "" Then
                total_recieve = Integer.Parse(oldTotalRecieve) + amount_sum
                If total_recieve > Integer.Parse(totAvailble) Then
                    lblpopupStatus.Visible = True
                    lblpopupStatus.ForeColor = Drawing.Color.Red
                    lblpopupStatus.Text = "إجمالى الكمية المنصرفة تتخطى الكمية المتاحة"
                    'FillGridveiw1()

                    Return
                End If



            ElseIf totAvailble <> "" Then
                total_recieve = amount_sum
                If total_recieve > Integer.Parse(totAvailble) Then
                    lblpopupStatus.Visible = True
                    lblpopupStatus.ForeColor = Drawing.Color.Red
                    lblpopupStatus.Text = "إجمالى الكمية المنصرفة تتخطى الكمية المتاحة"
                    'FillGridveiw1()

                    Return
                End If
            End If
        Next




        lblpopupStatus.Text = "تم توزيع الصرف على الأنشطة"
        lblpopupStatus.Visible = True
        lblpopupStatus.ForeColor = Drawing.Color.Green






    End Sub
    Protected Sub cancelPopupGrid(ByVal s As Object, ByVal e As EventArgs)

        'Dim sql_exchange As String = "select *,Project_Activities.PActv_Desc " _
        ' & " from activities_Needs_relationship" _
        ' & " join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID " _
        ' & " where(activities_Needs_relationship.need_id = 16)" _
        ' & " order by Project_Activities.PActv_ID"

        'Dim dt_ As New DataTable
        'dt_ = General_Helping.GetDataTable(sql_exchange)

        'gvActivities.DataSource = dt_
        'gvActivities.DataBind()

        For drRwindex As Integer = 0 To gvActivities.Rows.Count - 1 Step 1


            Dim grdtextAmounts As TextBox = gvActivities.Rows(drRwindex).FindControl("txtamount")
            Dim grdtextMoneys As TextBox = gvActivities.Rows(drRwindex).FindControl("txttotal")
            grdtextAmounts.Text = ""
            grdtextMoneys.Text = ""

        Next

        Dim textActivities As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtActivIDs")
        Dim textAmounts As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtAmounts")
        Dim textMoneys As TextBox = gvMain.Rows(myRowIndex.Value).FindControl("txtMoneys")
        textActivities.Text = ""
        textAmounts.Text = ""
        textMoneys.Text = ""

        lblpopupStatus.Text = "تم الإلغاء"
        lblpopupStatus.Visible = True
        lblpopupStatus.ForeColor = Drawing.Color.Red
        'overlay.Style.Add(HtmlTextWriterStyle.Display, "none")
        'popup.Style.Add(HtmlTextWriterStyle.Display, "none")


    End Sub
    Protected Sub closePopupGrid(ByVal s As Object, ByVal e As EventArgs)

        'Dim sql_exchange As String = "select *,Project_Activities.PActv_Desc " _
        ' & " from activities_Needs_relationship" _
        ' & " join Project_Activities on activities_Needs_relationship.actv_id= Project_Activities.PActv_ID " _
        ' & " where(activities_Needs_relationship.need_id = 16)" _
        ' & " order by Project_Activities.PActv_ID"

        'Dim dt_ As New DataTable
        'dt_ = General_Helping.GetDataTable(sql_exchange)

        'gvActivities.DataSource = dt_
        'gvActivities.DataBind()
        lblpopupStatus.Visible = False
        overlay.Style.Add(HtmlTextWriterStyle.Display, "none")
        popup.Style.Add(HtmlTextWriterStyle.Display, "none")


    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRowsforNeedsAvailble(gvMain)
        For drRwindex As Integer = 0 To gvMain.Rows.Count - 1 Step 1


            gvMain.Rows(drRwindex).BackColor = Drawing.Color.White


            Dim textActivities As TextBox = gvMain.Rows(drRwindex).FindControl("txtActivIDs")
            If textActivities.Text <> "" And gvMain.Rows(drRwindex).FindControl("btnshow").Visible = True Then
                Dim btnshowActivities As Button = gvMain.Rows(drRwindex).FindControl("btnshow")
                btnshowActivities.Text = "تم الربط"
                btnshowActivities.BackColor = Drawing.Color.YellowGreen
            Else
                Dim btnshowActivities As Button = gvMain.Rows(drRwindex).FindControl("btnshow")
                btnshowActivities.Text = "ربط"
                btnshowActivities.BackColor = Drawing.Color.FromArgb(194, 221, 240)
            End If

        Next
        If myRowIndex2.Value <> "" Then
            gvMain.Rows(Integer.Parse(myRowIndex2.Value)).BackColor = Drawing.Color.Lavender
        End If

    End Sub

    Protected Sub rowEdit(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.RowEditing


    End Sub

    'Protected Sub GridNeed_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridNeed.RowCommand
    '    If e.CommandName = "EditItem" Then

    '        doc_id.Value = e.CommandArgument
    '        Dim Sql As String = "SELECT * from Need_Recieve_Document where id=" & CDataConverter.ConvertToInt(doc_id.Value)

    '        Dim DT As DataTable = General_Helping.GetDataTable(Sql)

    '        txtFileName.Text = DT.Rows(0)("File_name").ToString()
    '        TxtDes.Text = DT.Rows(0)("Doc_Desc").ToString()
    '        fillgridDoc()

    '    End If

    '    If e.CommandName = "RemoveItem" Then
    '        OpenConnection()

    '        Dim cmd As New SqlCommand("delete from Need_Recieve_Document where id = " & e.CommandArgument, con)
    '        cmd.Connection = con
    '        cmd.ExecuteNonQuery()

    '        Dim cmd1 As New SqlCommand("update Need_Recieve set Recieve_Doc_id=" & 0 & " where Recieve_Doc_id = " & CDataConverter.ConvertToInt(e.CommandArgument), con)
    '        cmd1.Connection = con
    '        cmd1.ExecuteNonQuery()
    '        lblPageStatus.Visible = True
    '        lblPageStatus.Text = "لقد تم الحذف بنجاح"
    '        fillgridDoc()
    '        FillGrid()
    '    End If
    'End Sub
#End Region

    'Private Sub ddlMainCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMainCat.SelectedIndexChanged
    '    If ddlMainCat.SelectedValue <> "....اختر نوع الاحتياج الرئيسى......" Then
    '        Dim dt2 As New DataTable
    '        Dim sql As String = "select distinct Needs_Sup_Type.NST_id,NST_Desc" _
    '              & " from Needs_Sup_Type" _
    '              & " join dbo.Needs_Main_Type ON dbo.Needs_Main_Type.NMT_id = dbo.Needs_Sup_Type.nmt_nmt_id" _
    '              & " join dbo.Project_Needs ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID" _
    '              & " join Need_Availble ON dbo.Need_Availble.PNed_PNed_Id = dbo.Project_Needs.PNed_ID" _
    '              & " where Need_Availble.Availble_Amount <> 0 and dbo.Project_Needs.proj_proj_id=" & Session_CS.Project_id & " and nmt_nmt_id = " & ddlMainCat.SelectedValue

    '        dt2 = General_Helping.GetDataTable(sql)
    '        Obj_General_Helping.SmartBindDDL(ddlSubCat, dt2, "NST_ID", "NST_Desc", "....اختر نوع الاحتياج الفرعى....")
    '        Clear()
    '        lblApprovedAmount.Text = ""
    '        lblAvailbleAmount.Text = ""
    '        lblremain.Text = ""
    '        lbltotaldelivers.Text = ""
    '        lblamnt.Text = ""
    '        lblunitprice.Text = ""
    '        ddlItem.Items.Clear()
    '        ddlItem.Items.Insert(0, "......اختر البند........")
    '    Else
    '        Clear()
    '        lblApprovedAmount.Text = ""
    '        lblAvailbleAmount.Text = ""
    '        lblremain.Text = ""
    '        lbltotaldelivers.Text = ""
    '        lblamnt.Text = ""
    '        lblunitprice.Text = ""
    '        ddlItem.Items.Clear()
    '        ddlItem.Items.Insert(0, "......اختر البند........")
    '        ddlSubCat.Items.Clear()
    '        ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")
    '    End If
    'End Sub
    'Protected Sub ddlSubCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSubCat.SelectedIndexChanged
    '    If ddlSubCat.SelectedValue <> "....اختر نوع الاحتياج الفرعى...." Then
    '        Dim dt3 As New DataTable
    '        dt3 = General_Helping.GetDataTable("select pned_id,pned_name from project_needs where nst_nst_id = " & ddlSubCat.SelectedValue & "and proj_proj_id = " & Session_CS.Project_id)
    '        Obj_General_Helping.SmartBindDDL(ddlItem, dt3, "pned_id", "pned_name", "......اختر البند........")
    '        Clear()
    '        lblApprovedAmount.Text = ""
    '        lblAvailbleAmount.Text = ""
    '        lblremain.Text = ""
    '        lbltotaldelivers.Text = ""
    '        lblamnt.Text = ""
    '        lblunitprice.Text = ""
    '    Else
    '        Clear()
    '        lblApprovedAmount.Text = ""
    '        lblAvailbleAmount.Text = ""
    '        lblremain.Text = ""
    '        lbltotaldelivers.Text = ""
    '        lblamnt.Text = ""
    '        lblunitprice.Text = ""
    '        ddlItem.Items.Clear()
    '        ddlItem.Items.Insert(0, "......اختر البند........")
    '    End If
    'End Sub

    'Protected Sub ddlItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlItem.SelectedIndexChanged
    '    If ddlItem.SelectedValue <> "......اختر البند........" Then
    '        FillGrid()
    '        Clear()
    '    Else
    '        Clear()
    '        lblApprovedAmount.Text = ""
    '        lblAvailbleAmount.Text = ""
    '        lblremain.Text = ""
    '        lbltotaldelivers.Text = ""
    '        lblamnt.Text = ""
    '        lblunitprice.Text = ""
    '    End If

    'End Sub



    'Protected Sub txtRecievedAmount_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecievedAmount.TextChanged
    '    lblPageStatus.Text = ""
    '    lblPageStatus.Visible = False
    '    If txtRecievedAmount.Text <> "" And ddlItem.SelectedIndex > 0 Then
    '        If txtRecievedAmount.Text = 0 Then
    '            lblPageStatus.Text = "الكمية المنصرفة لايمكن أن تساوى 0"
    '            lblPageStatus.Visible = True
    '            Return
    '        End If
    '        If lblAvailbleAmount.Text = "" Then
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "لم تتم الاتاحة لهذا الاحتياج"
    '            Return
    '        ElseIf lblApprovedAmount.Text = "" Then
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "لم يتم التصديق لهذا الاحتياج"
    '            Return
    '        End If
    '        Dim sql As String = ""
    '        sql = "select sum(recieved_amount) as sum_recieved from need_recieve where pned_pned_id=" & ddlItem.SelectedValue
    '        Dim dt = General_Helping.GetDataTable(sql)
    '        Dim total_recieved As Integer
    '        If Not dt.Rows(0)("sum_recieved") Is DBNull.Value Then
    '            total_recieved = Integer.Parse(dt.Rows(0)("sum_recieved")) + Integer.Parse(txtRecievedAmount.Text)
    '        Else
    '            total_recieved = Integer.Parse(txtRecievedAmount.Text)
    '        End If

    '        If Decimal.Parse(total_recieved) > Decimal.Parse(lblApprovedAmount.Text) Then
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المصدق بها "
    '            Return
    '        ElseIf Integer.Parse(txtRecievedAmount.Text) > Decimal.Parse(lblremain.Text) Then
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "الكميه المنصرفة اكبر من الكمية المتبقية "
    '            Return
    '        ElseIf Decimal.Parse(total_recieved) > Decimal.Parse(lblAvailbleAmount.Text) Then
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "الكميه المنصرفة اكبر من الكميه المتاحه "
    '            Return
    '        End If

    '    End If


    'End Sub

    'Protected Sub txtRecievedDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecievedDate.TextChanged
    '    Dim validated_date As String = ""
    '    If VB_Classes.Dates.date_validate(txtRecievedDate.Text) <> "" Then
    '        txtRecievedDate.Text = VB_Classes.Dates.date_validate(txtRecievedDate.Text)
    '        validated_date = VB_Classes.Dates.date_validate(txtRecievedDate.Text)
    '        lblPageStatus.Visible = False
    '    Else
    '        lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
    '        lblPageStatus.Visible = True
    '        Return
    '    End If

    '    If lblNeedDate.Text <> "" And validated_date <> "" Then
    '        If VB_Classes.Dates.Date_compare(validated_date, lblNeedDate.Text) Then
    '            lblPageStatus.Visible = False
    '        Else
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "تاريخ الصرف يجب أن يأتى بعد تاريخ طلب الاحتياج "
    '            Return
    '        End If
    '    End If
    '    Dim sql As String = "select min(Availble_Amount_Date) as min_Availble_Amount_Date from Need_Availble where PNed_PNed_Id=" & ddlItem.SelectedValue
    '    Dim dt As DataTable = General_Helping.GetDataTable(sql)
    '    If dt.Rows.Count > 0 And dt.Rows(0)("min_Availble_Amount_Date").ToString <> "" And validated_date <> "" Then
    '        If VB_Classes.Dates.Date_compare(validated_date, dt.Rows(0)("min_Availble_Amount_Date")) Then
    '            lblPageStatus.Visible = False
    '        Else
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "تاريخ الصرف يجب أن يأتى بعد تاريخ الاتاحة "
    '            Return
    '        End If
    '    End If

    'End Sub




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

        'MergeRows(gvActivities)


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