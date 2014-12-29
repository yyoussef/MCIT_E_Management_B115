Imports System.Globalization
Imports MCIT.Web.Data
Imports System.Data.SqlClient
Imports System.Data

Partial Class MainForm_Need_Available
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS
    Public con As New SqlConnection
    Dim fmt As DateTimeFormatInfo = (New CultureInfo("en-US")).DateTimeFormat
    Dim provider As CultureInfo = CultureInfo.InvariantCulture
    Dim Obj_General_Helping As New General_Helping



#Region "Variables"
    Dim Needs_Available_ENTITY As New BLL.Need_Availble
    Dim sql_Connection As String = Database.ConnectionString
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

#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)

        MyBase.OnInitComplete(e)

        Smart_Search_Proj.sql_Connection = sql_Connection
        Smart_Search_Proj.Text_Field = "Proj_Title "
        Smart_Search_Proj.Value_Field = "Proj_id "
        Dim Sql As String = " SELECT     sum(Availble_Amount) as Availble_Amount , sum(approved_amount) as approved_amount, Proj_id, Proj_Title FROM         Needs_Approved_Available  where  Availble_Amount < approved_amount  group by Proj_id, Proj_Title "
        Smart_Search_Proj.datatble = General_Helping.GetDataTable(Sql)
        Smart_Search_Proj.DataBind()


        If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then

            Smart_Search_Proj.SelectedValue = Session_CS.Project_id
            Smart_Search_Proj.Enabled = False

        End If

        AddHandler Me.Smart_Search_Proj.Value_Handler, AddressOf Smart_Search_Selected





        MyBase.OnInitComplete(e)
    End Sub

#End Region

    Private Sub Smart_Search_Selected(ByVal Value As String)
        If CDataConverter.ConvertToInt(Value) > 0 Then
            'FillDDls()
            Session_CS.Project_id = Value
            FillGrid()
            GridView1.Visible = False

            'Else
            '   gvMain.Visible = False
            '  tbl_doc.Visible = False
        End If
    End Sub

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
    'Dim rowindeces As New List(Of Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()

        If Not IsPostBack Then
            ' ImgBtnResearch1.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)

            TR2.Visible = False
            BtnSave.CommandArgument = "new"
            Me.Page.Form.Enctype = "multipart/form-data"
            If (String.IsNullOrEmpty(Session_CS.Project_id.ToString()) = False And Session_CS.Project_id <> 0) Then
                FillGrid()
                GridView1.Visible = False
            End If

        End If
    End Sub
#End Region


#Region "Clear"
    Private Sub Clear()
        'txtsanf.Text = ""
        'txtAvailalbeAmnt.Text = ""
        'txtAvailbleDate.Text = ""
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        'ddlSubCat.SelectedValue = "....اختر نوع الاحتياج الفرعى...."
        'ddlItem.SelectedValue = "......اختر البند........"
        'ddlMainCat.SelectedValue = "....اختر نوع الاحتياج الرئيسى......"

    End Sub
#End Region



#Region "Fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        sql = "select Project_Needs.* ,(SELECT sum(Availble_Amount) from Need_Availble where Need_Availble.PNed_PNed_Id =Project_Needs.PNed_ID) as Availble_Amount_edited,NMT_Desc,NST_Desc,convert(nvarchar,PNed_Date,103) as needDate,convert(varchar(20),convert(money, PNed_InitValue), 1) as moneyv,convert(varchar(20),convert(money, (Project_Needs.PNed_Number)*(Project_Needs.PNed_InitValue)), 1) as multiply_money_integer from Project_Needs" _
            & " join Needs_Sup_Type on Project_Needs.nst_nst_id = Needs_Sup_Type.NST_ID" _
            & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID" _
            & " where Project_Needs.proj_proj_id= " & Session_CS.Project_id & " and Project_Needs.approved_amount>0 ORDER BY Needs_Main_Type.NMT_ID,Needs_Sup_Type.NST_ID"
        Dim dt1 As New DataTable
        dt1 = General_Helping.GetDataTable(sql)

        'If dt1.Rows.Count <> 0 Then
        '    If Not dt1.Rows(0)("PNed_Number") Is DBNull.Value Then
        '        Dim str As String = dt1.Rows(0)("PNed_Number")
        '        Dim str1() As String = str.Split(".")
        '        lblamnt.Text = str1(0)
        '    End If
        '    If Not dt1.Rows(0)("needDate") Is DBNull.Value Then
        '        lblNeedDate.Text = dt1.Rows(0)("needDate")
        '    End If
        '    If Not dt1.Rows(0)("approved_amount") Is DBNull.Value Then
        '        lblApprovedAmnt.Text = dt1.Rows(0)("approved_amount")
        '    Else
        '        lblApprovedAmnt.Text = 0
        '    End If

        'End If
        'Dim sql1 As String = ""
        'sql1 = "SELECT SUM(Availble_Amount) AS total_availble_amount FROM Need_Availble where PNed_PNed_Id=" & ddlItem.SelectedValue
        'Dim dt As New DataTable
        'dt = General_Helping.GetDataTable(sql1)
        'If Not dt.Rows(0)("total_availble_amount") Is DBNull.Value Then
        '    Label9.Visible = True
        '    lblAvailbleAmount.Visible = True
        '    lblAvailbleAmount.Text = dt.Rows(0)("total_availble_amount")
        '    If Not dt1.Rows(0)("approved_amount") Is DBNull.Value Then
        '        lblAvailbleRemain.Text = (CDataConverter.ConvertToInt(dt1.Rows(0)("approved_amount")) - CDataConverter.ConvertToInt(dt.Rows(0)("total_availble_amount"))).ToString

        '    End If
        'Else
        '    lblAvailbleAmount.Text = 0
        '    lblAvailbleRemain.Text = (CDataConverter.ConvertToInt(dt1.Rows(0)("approved_amount"))).ToString

        'End If


        'gvMain.Visible = True
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()
        If gvMain.Rows.Count > 0 Then
            BtnSave.Visible = True
            tbl_doc.Visible = True
        Else
            tbl_doc.Visible = False
            BtnSave.Visible = False
        End If
        For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1
            Dim newAvailble As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewAvailbleAmount")
            Dim brandName As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewAvailbleName")
            Dim newAvailbeDate As TextBox = gvMain.Rows(rwIndex).FindControl("txtAvailbleDate")
            If gvMain.Rows(rwIndex).Cells(7).Text = gvMain.Rows(rwIndex).Cells(8).Text Then
                newAvailble.Enabled = False
                brandName.Enabled = False
                newAvailbeDate.Enabled = False

            End If
        Next
    End Sub
    Private Sub FillGridveiw1()
        Dim dt As New DataTable

     

        Dim sql As String = "select Need_Availble_Document.*,Need_Availble.* from Need_Availble left join Need_Availble_Document on Need_Availble.Availble_Doc_id=Need_Availble_Document.id where PNed_PNed_Id=" & Need_Av_Id.Value & " order by convert(datetime, Availble_Amount_Date, 103) desc"
        dt = General_Helping.GetDataTable(sql)
        GridView1.Visible = True
        GridView1.DataSource = dt
        GridView1.DataBind()
        TR2.Visible = True

    End Sub
    'Private Sub FillDDls()
    '    Dim dt5 As New DataTable
    '    Dim sql As String = "select distinct Needs_Main_Type.NMT_id,NMT_desc" _
    '            & " from Needs_Main_Type" _
    '            & " join dbo.Needs_Sup_Type ON dbo.Needs_Sup_Type.nmt_nmt_id = dbo.Needs_Main_Type.NMT_id" _
    '            & " join dbo.Project_Needs ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID" _
    '            & " where dbo.Project_Needs.proj_proj_id=" & Smart_Search_Proj.SelectedValue
    '    dt5 = General_Helping.GetDataTable(sql)
    '    Obj_General_Helping.SmartBindDDL(ddlMainCat, dt5, "NMT_id", "NMT_Desc", "....اختر نوع الاحتياج الرئيسى......")

    '    ddlSubCat.Items.Clear()
    '    ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")

    '    ddlItem.Items.Clear()
    '    ddlItem.Items.Insert(0, "......اختر البند........")
    'End Sub
#End Region

#Region "Save Data"
    Private Sub newSave()
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1
            Dim err As Label = gvMain.Rows(rwIndex).FindControl("lblError")
            Dim err2 As Label = gvMain.Rows(rwIndex).FindControl("lblError2")
            err.Visible = False
            err2.Visible = False
            Dim need_id As TextBox = gvMain.Rows(rwIndex).FindControl("txtPnedid")
            Need_Av_Ids.Value = need_id.Text
            Dim newAvailble As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewAvailbleAmount")
            Dim approved As TextBox = gvMain.Rows(rwIndex).FindControl("txtApproved")
            Dim brandName As TextBox = gvMain.Rows(rwIndex).FindControl("txtnewAvailbleName")
            Dim newAvailbeDate As TextBox = gvMain.Rows(rwIndex).FindControl("txtAvailbleDate")
            Dim rwchkbox As CheckBox = gvMain.Rows(rwIndex).FindControl("CheckBox1")
            Dim sql As String = ""
            sql = "select need_Recieve.* from need_recieve where pned_pned_id=" & Integer.Parse(need_id.Text)
            Dim dt = General_Helping.GetDataTable(sql)

            If newAvailble.Text <> "" Then
                If Integer.Parse(newAvailble.Text) = 0 Then
                    lblPageStatus.Text = "الكمية المتاحة لايمكن أن تساوى 0"
                    lblPageStatus.Visible = True
                    err.Visible = True
                    Return
                End If
                Dim sql15 As String = "select sum(Availble_Amount) as Availble_Amount_Sum from Need_Availble where PNed_PNed_Id=" & Integer.Parse(need_id.Text)
                Dim dt15 As New DataTable
                dt15 = General_Helping.GetDataTable(sql15)
                If approved.Text = "" Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "لم يتم التصديق لهذا الاحتياج"

                    err.Visible = True
                    Return
                End If
                Dim total_available As Integer
                If Not dt15.Rows(0)("Availble_Amount_Sum") Is DBNull.Value And approved.Text <> "" Then
                    total_available = Integer.Parse(dt15.Rows(0)("Availble_Amount_Sum")) + Integer.Parse(newAvailble.Text)
                    If total_available > Integer.Parse(approved.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "إجمالى الكمية المتاحة تتخطى الكمية المصدق بها"
                        FillGridveiw1()
                        err.Visible = True
                        Return
                    End If
                ElseIf approved.Text <> "" Then
                    total_available = Integer.Parse(newAvailble.Text)
                    If total_available > Integer.Parse(approved.Text) Then
                        lblPageStatus.Visible = True
                        lblPageStatus.Text = "إجمالى الكمية المتاحة تتخطى الكمية المصدق بها"
                        FillGridveiw1()
                        err.Visible = True
                        Return
                    End If
                End If
                'Dim datet As DateTime = System.DateTime.Now
                'Dim today As String = datet.ToString("dd/MM/yyyy")
                Dim validated_date As String = ""

                validated_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(newAvailbeDate.Text))


                If validated_date = "" Then
                    lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                    lblPageStatus.Visible = True
                    newAvailbeDate.Text = ""
                    err2.Visible = True
                    Return
                End If

                Dim doc_value As Integer = 0
                If rwchkbox.Checked = True Then
                    doc_value = Integer.Parse(doc_id.Value)
                End If

                General_Helping.ExcuteQuery("insert into Need_Availble (PNed_PNed_Id,Availble_Item,Availble_Amount,Availble_Amount_Date,Availble_Doc_id) values(" & Integer.Parse(need_id.Text) & ",'" & (brandName.Text).ToString & "', " & Integer.Parse(newAvailble.Text) & ", '" & validated_date & "'," & doc_value & " )")
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"

                Dim sql11 As String = ""
                sql11 = "SELECT MAX(Need_Availble_Id) AS Largest_Need_Availble_Id FROM Need_Availble"
                Dim dt11 As New DataTable
                dt11 = General_Helping.GetDataTable(sql11)

                Project_Log_DB.FillLog(CDataConverter.ConvertToInt(dt11.Rows(0)("Largest_Need_Availble_Id")), Project_Log_DB.Action.add, Project_Log_DB.operation.Project_Needs_Avaialble)


                err.Visible = False
                err2.Visible = False
            Else

                Continue For
            End If




        Next

        FillGrid()
        FillGridveiw1()
    End Sub
    Public Sub newSubSave()



        Dim txtAvailble_Amount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtAvailble_Amount")

        Dim txtAvailble_Item As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtAvailble_Item")


        Dim txtavailble_amount_date As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtavailble_amount_date")

        Dim rwchkbox As CheckBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("CheckBox1")




        Dim err As Label = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("lblError")
        Dim err2 As Label = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("lblError2")
        err.Visible = False
        err2.Visible = False
        Dim needId As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtneedid")
        Dim txtAvailbleId As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtAvailbleId")
        Need_Av_Id.Value = needId.Text
        Dim oldAmount As Integer = CDataConverter.ConvertToInt(General_Helping.GetDataTable("select Availble_Amount from Need_Availble where Need_Availble_Id=" & CDataConverter.ConvertToInt(txtAvailbleId.Text)).Rows(0)("Availble_Amount").ToString())
        lblPageStatus.Text = ""
        lblPageStatus.Visible = False
        If txtAvailble_Amount.Text <> "" Then
            If Integer.Parse(txtAvailble_Amount.Text) = 0 Then
                lblPageStatus.Text = "الكمية المتاحة لايمكن أن تساوى 0"
                lblPageStatus.Visible = True
                err.Visible = True
                Return
            End If

            Dim totAapproved As String = gvMain.Rows(Integer.Parse(myRowIndex2.Value)).Cells(7).Text
            Dim oldTotalAvailble As String = gvMain.Rows(Integer.Parse(myRowIndex2.Value)).Cells(8).Text
            Dim total_Availble As Integer
            If oldTotalAvailble <> "&nbsp;" And totAapproved <> "" Then
                total_Availble = Integer.Parse(oldTotalAvailble) + Integer.Parse(txtAvailble_Amount.Text) - oldAmount
                If total_Availble > Integer.Parse(totAapproved) Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "إجمالى الكمية المتاحة تتخطى الكمية المصدقة"
                    FillGridveiw1()

                    err.Visible = True
                    Return
                End If
            ElseIf totAapproved <> "" Then
                total_Availble = Integer.Parse(txtAvailble_Amount.Text)
                If total_Availble > Integer.Parse(totAapproved) Then
                    lblPageStatus.Visible = True
                    lblPageStatus.Text = "إجمالى الكمية المتاحة تتخطى الكمية المصدقة"
                    FillGridveiw1()

                    err.Visible = True
                    Return
                End If
            End If
            'Dim datet As DateTime = System.DateTime.Now
            'Dim today As String = datet.ToString("dd/MM/yyyy")
            Dim validated_date As String = ""

            validated_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtavailble_amount_date.Text))

            If validated_date = "" Then
                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                lblPageStatus.Visible = True
                txtavailble_amount_date.Text = ""
                err2.Visible = True
                Return
            End If

            'saveNewDoc()


            Dim doc_value As Integer = 0
            If rwchkbox.Checked = True Then
                doc_value = Integer.Parse(doc_id.Value)
            End If

            General_Helping.ExcuteQuery("update Need_Availble set Availble_Item='" & txtAvailble_Item.Text & "',Availble_Amount=" & Integer.Parse(txtAvailble_Amount.Text) & ",Availble_Amount_Date='" & validated_date & "',Availble_Doc_id=" & doc_value & " where Need_Availble_Id=" & Integer.Parse(txtAvailbleId.Text))


            General_Helping.ExcuteQuery("update Project_Needs set TotalDelievered =" & total_Availble & " where PNed_ID=" & Integer.Parse(Need_Av_Id.Value))

            lblPageStatus.Visible = True
            lblPageStatus.Text = "تم التعديل بنجاح"
            FillGrid()
            FillGridveiw1()



            err.Visible = False
            err2.Visible = False



        End If


    End Sub

#End Region

#Region "validation"
    Private Function Valid() As Boolean
        'If txtAvailalbeAmnt.Text = "" Or txtsanf.Text = "" Or txtAvailbleDate.Text = "" Then
        '    lblPageStatus.Visible = True
        '    lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
        '    Return False
        'Else
        '    lblPageStatus.Visible = False
        '    Return True
        'End If
        Return True
    End Function
#End Region
#Region "Event Handler"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        newSave()
        'If Valid() Then
        '    'If BtnSave.CommandArgument = "new" Then
        '    '    SaveDataForClasses()
        '    'Else
        '    '    SaveDataForClasses(Need_Av_Id.Value)
        '    'End If
        'End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try


            If CType(sender, ImageButton).CommandName = "edit" Then
                myRowIndex1.Value = CType(sender, ImageButton).CommandArgument
                lblPageStatus.Visible = False

                Dim imgbtnsave As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImgBtnSave")
                imgbtnsave.Visible = True
                Dim imgbtnedit As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImgBtnEdit")
                imgbtnedit.Visible = False
                Dim txtAvailble_Amount As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtAvailble_Amount")
                txtAvailble_Amount.ReadOnly = False
                Dim txtAvailble_Item As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtAvailble_Item")
                txtAvailble_Item.ReadOnly = False

                Dim txtavailble_amount_date As TextBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("txtavailble_amount_date")
                txtavailble_amount_date.ReadOnly = False
                Dim ImageButton3 As ImageButton = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("ImageButton3")
                ImageButton3.Visible = True


                Dim hrefDoc As HtmlAnchor = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("hrefDoc")
                hrefDoc.Visible = False
                'Dim FileUpload1 As FileUpload = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("FileUpload1")
                'FileUpload1.Visible = True
                Dim rwchkbox As CheckBox = GridView1.Rows(Integer.Parse(myRowIndex1.Value)).FindControl("CheckBox1")
                rwchkbox.Visible = True
                GridView1.HeaderRow.Cells(3).Text = "ربط بوثيقة الإتاحة"
                GridView1.HeaderRow.Cells(4).Text = "حـفظ"
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




            End If
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن العرض"
        End Try


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
            cmd1.CommandText = "insert into Need_Availble_Document (File_name,File_data,Doc_Desc,File_ext) VALUES(@File_name,@File_data,@Doc_Desc,@File_ext)"

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

                    Dim sql11 As String = "SELECT MAX(id) AS max_availble_doc FROM Need_Availble_Document"
                    Dim dt11 As New DataTable
                    dt11 = General_Helping.GetDataTable(sql11)
                    doc_id.Value = dt11.Rows(0)("max_availble_doc").ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Else
            doc_id.Value = "0"
        End If


        '''''
    End Sub
    Public Sub saveAddAnotherDoc(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, Button).CommandName = "save" Then
            saveNewDoc()

            Dim dt As DataTable = General_Helping.GetDataTable("select id,File_name from Need_Availble_Document where id=" & Integer.Parse(doc_id.Value))
            If dt.Rows.Count > 0 Then
                editCurrentDoc.Visible = True
                newone.Visible = False
                hrefDoc.HRef = "ALL_Document_Details.aspx?type=projectneedavailble&id=" & dt.Rows(0)("id").ToString
                hrefDoc.InnerText = "- " + dt.Rows(0)("File_name").ToString
                lbledit.Text = "تم إضافة وثيقة"
                Dim cnt As Integer = 0
                For rwIndex As Integer = 0 To gvMain.Rows.Count - 1 Step 1
                    If gvMain.Rows(rwIndex).Cells(8).Text <> gvMain.Rows(rwIndex).Cells(9).Text Then
                        cnt += 1
                    End If
                Next

                If cnt > 0 And doc_id.Value <> "0" Then
                    BtnSave.Visible = True
                Else
                    BtnSave.Visible = False
                End If

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
            BtnSave.Visible = False
            lblAddExistDoc.Text = "اضف وثيقة جديدة"

        End If

    End Sub
    Protected Sub ImgBtnveiw_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Need_Av_Id.Value = CType(sender, ImageButton).CommandArgument
            myRowIndex2.Value = CType(sender, ImageButton).CommandName
            FillGridveiw1()
            For i As Integer = 0 To gvMain.Rows.Count - 1 Step 1
                gvMain.Rows(i).BackColor = Drawing.Color.White
            Next
            gvMain.Rows(Integer.Parse(CType(sender, ImageButton).CommandName)).BackColor = Drawing.Color.Lavender
            lblPageStatus.Visible = False
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن العرض"
            GridView1.Visible = False
        End Try
    End Sub
    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Needs_Available_ENTITY As New BLL.Need_Availble(CType(sender, ImageButton).CommandArgument)
            Need_Av_Id.Value = CType(sender, ImageButton).CommandName
            Needs_Available_ENTITY.Delete()
            FillGrid()
            FillGridveiw1()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
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

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRowsforNeedsAvailble(gvMain)
        If myRowIndex2.Value <> "" Then
            gvMain.Rows(Integer.Parse(myRowIndex2.Value)).BackColor = Drawing.Color.Lavender
        End If
    End Sub
#End Region
    Protected Sub rowEdit(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.RowEditing


    End Sub
    'Private Sub ddlMainCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMainCat.SelectedIndexChanged
    '    If ddlMainCat.SelectedValue <> "....اختر نوع الاحتياج الرئيسى......" Then
    '        Dim dt2 As New DataTable
    '        Dim sql As String = "select distinct Needs_Sup_Type.NST_id,NST_Desc" _
    '            & " from Needs_Sup_Type" _
    '            & " join dbo.Needs_Main_Type ON dbo.Needs_Main_Type.NMT_id = dbo.Needs_Sup_Type.nmt_nmt_id" _
    '            & " join dbo.Project_Needs ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID" _
    '            & " where dbo.Project_Needs.proj_proj_id=" & Smart_Search_Proj.SelectedValue & " and nmt_nmt_id = " & ddlMainCat.SelectedValue
    '        dt2 = General_Helping.GetDataTable(sql)
    '        Obj_General_Helping.SmartBindDDL(ddlSubCat, dt2, "NST_ID", "NST_Desc", "....اختر نوع الاحتياج الفرعى....")
    '        Clear()
    '        lblamnt.Text = ""
    '        lblApprovedAmnt.Text = ""
    '        ddlItem.Items.Clear()
    '        ddlItem.Items.Insert(0, "......اختر البند........")
    '    Else
    '        Clear()
    '        lblamnt.Text = ""
    '        lblApprovedAmnt.Text = ""
    '        ddlItem.Items.Clear()
    '        ddlItem.Items.Insert(0, "......اختر البند........")
    '        ddlSubCat.Items.Clear()
    '        ddlSubCat.Items.Insert(0, "....اختر نوع الاحتياج الفرعى....")
    '    End If
    'End Sub
    'Protected Sub ddlSubCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSubCat.SelectedIndexChanged
    '    If ddlSubCat.SelectedValue <> "....اختر نوع الاحتياج الفرعى...." Then
    '        Dim dt3 As New DataTable
    '        dt3 = General_Helping.GetDataTable("select pned_id,pned_name from project_needs where nst_nst_id = " & ddlSubCat.SelectedValue & "and proj_proj_id = " & Smart_Search_Proj.SelectedValue)
    '        Obj_General_Helping.SmartBindDDL(ddlItem, dt3, "pned_id", "pned_name", "......اختر البند........")
    '        Clear()
    '        lblamnt.Text = ""
    '        lblApprovedAmnt.Text = ""
    '    Else
    '        Clear()
    '        lblamnt.Text = ""
    '        lblApprovedAmnt.Text = ""
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
    '        lblamnt.Text = ""
    '        lblApprovedAmnt.Text = ""
    '    End If

    'End Sub


    'Protected Sub txtAvailalbeAmnt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAvailalbeAmnt.TextChanged
    '    lblPageStatus.Text = ""
    '    lblPageStatus.Visible = False
    '    If txtAvailalbeAmnt.Text <> "" And ddlItem.SelectedIndex > 0 Then
    '        If txtAvailalbeAmnt.Text = 0 Then
    '            lblPageStatus.Text = "الكمية المتاحة لايمكن أن تساوى 0"
    '            lblPageStatus.Visible = True
    '            Return
    '        End If
    '        Dim sql15 As String = "select sum(Availble_Amount) as Availble_Amount_Sum from Need_Availble where PNed_PNed_Id=" & ddlItem.SelectedValue
    '        Dim dt15 As New DataTable
    '        dt15 = General_Helping.GetDataTable(sql15)
    '        Dim total_available As Integer
    '        If lblApprovedAmnt.Text = "" Then
    '            lblPageStatus.Visible = True
    '            lblPageStatus.Text = "لم يتم التصديق لهذا الاحتياج"
    '            Return
    '        End If
    '        If Not dt15.Rows(0)("Availble_Amount_Sum") Is DBNull.Value And lblApprovedAmnt.Text <> "" Then
    '            total_available = Integer.Parse(dt15.Rows(0)("Availble_Amount_Sum")) + Integer.Parse(txtAvailalbeAmnt.Text)
    '            If total_available > Integer.Parse(lblApprovedAmnt.Text) Then
    '                lblPageStatus.Visible = True
    '                lblPageStatus.Text = "إجمالى الكمية المتاحة تتخطى الكمية المصدق بها"
    '                Return
    '            End If
    '        ElseIf lblApprovedAmnt.Text <> "" Then
    '            total_available = Integer.Parse(txtAvailalbeAmnt.Text)
    '            If total_available > Integer.Parse(lblApprovedAmnt.Text) Then
    '                lblPageStatus.Visible = True
    '                lblPageStatus.Text = "إجمالى الكمية المتاحة تتخطى الكمية المصدق بها"
    '                Return
    '            End If
    '        End If
    '    End If
    'End Sub

    'Protected Sub txtAvailbleDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAvailbleDate.TextChanged



    '    lblPageStatus.Text = ""
    '    lblPageStatus.Visible = False
    '    If txtAvailbleDate.Text <> "" Then
    '        If txtAvailbleDate.Text.Length > 10 Or txtAvailbleDate.Text.Length < 8 Then
    '            lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
    '            lblPageStatus.Visible = True
    '            txtAvailbleDate.Text = ""
    '            Return
    '        End If
    '        Dim str2 As String = txtAvailbleDate.Text
    '        Dim str3 As String = ""
    '        Dim ch1 As Char = "\"
    '        Dim ch2 As Char = "/"
    '        str3 = str2.Replace(ch1, ch2)
    '        txtAvailbleDate.Text = str3
    '        If txtAvailbleDate.Text.Length >= 8 Then
    '            Dim str As String = txtAvailbleDate.Text
    '            Dim str1() As String = str.Split("/")
    '            If str1.Length <> 3 Then
    '                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
    '                lblPageStatus.Visible = True
    '                txtAvailbleDate.Text = ""
    '                Return
    '            End If
    '            If str1(0) > 31 Or str1(0) < 1 Then
    '                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
    '                lblPageStatus.Visible = True
    '                txtAvailbleDate.Text = ""
    '                Return
    '            End If
    '            If str1(0) < 10 And str1(0).Count = 1 Then
    '                str1(0) = "0" & str1(0)
    '                txtAvailbleDate.Text = str1(0) & "/" & str1(1) & "/" & str1(2)
    '            End If
    '            If str1(1) > 12 Or str1(1) < 1 Then
    '                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
    '                lblPageStatus.Visible = True
    '                txtAvailbleDate.Text = ""
    '                Return
    '            End If
    '            If str1(1) < 10 And str1(1).Count = 1 Then
    '                str1(1) = "0" & str1(1)
    '                txtAvailbleDate.Text = str1(0) & "/" & str1(1) & "/" & str1(2)
    '            End If
    '            If str1(2) > 9999 Or str1(2) < 0 Then
    '                lblPageStatus.Text = "أدخل التاريخ (يوم/شهر/سنة) "
    '                lblPageStatus.Visible = True
    '                txtAvailbleDate.Text = ""
    '                Return
    '            End If

    '        End If

    '    End If




    '    'If ddlItem.SelectedIndex > 0 And txtAvailbleDate.Text <> "" Then
    '    '    Dim sql As String = "select convert(nvarchar,PNed_Date,103) as need_date from Project_Needs where PNed_ID=" & ddlItem.SelectedValue
    '    '    Dim dt As DataTable = General_Helping.GetDataTable(sql)
    '    '    If Not dt.Rows(0)("need_date") Is DBNull.Value Then
    '    '        If DateTime.ParseExact(txtAvailbleDate.Text, "dd/MM/yyyy", Nothing) > DateTime.ParseExact(dt.Rows(0)("need_date"), "dd/MM/yyyy", Nothing) Then
    '    '            lblPageStatus.Visible = True
    '    '            lblPageStatus.Text = "تاريخ الاتاحة يجب أن يأتى قبل تاريخ طلب الاحتياج"
    '    '            Return
    '    '        End If
    '    '    End If
    '    'End If


    'End Sub
End Class