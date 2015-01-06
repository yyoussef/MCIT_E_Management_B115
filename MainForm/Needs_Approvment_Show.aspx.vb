Imports System.Globalization
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebForms_Needs_Approvment
    Inherits System.Web.UI.Page
    'Session_CS Session_CS
    Public con As New SqlClient.SqlConnection
    Dim fmt As DateTimeFormatInfo = (New CultureInfo("en-US")).DateTimeFormat
    Dim provider As CultureInfo = CultureInfo.InvariantCulture

#Region "Variables"
    Dim Project_Needs_ENTITY As New BLL.Project_Needs


#End Region

#Region "Load"
    'Dim rowindeces As New List(Of Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillGrid()
            fillgridDoc()

        End If


    End Sub
#End Region


#Region "Clear"
    Private Sub Clear()

        lblPageStatus.Text = ""
        lblPageStatus.Visible = False

    End Sub
#End Region



#Region "Fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        sql = " select Project_Needs_Document.File_name,dbo.Project_Needs.PNed_ID, dbo.Project_Needs.PNed_Name, dbo.Project_Needs.PNed_desc, dbo.Project_Needs.PNed_Number, " _
          & " dbo.Project_Needs.approved_amount, dbo.Project_Needs.PNed_InitValue,convert(varchar(20), convert(money, PNed_InitValue), 1) as moneyv,convert(varchar(20), convert(money, (Project_Needs.PNed_Number)*(Project_Needs.PNed_InitValue)), 1) as multiply_money_integer, dbo.Project_Needs.nst_nst_id, dbo.Project_Needs.PNed_Date, " _
          & " dbo.Project_Needs.need_Serial, dbo.Project_Needs.proj_proj_id, dbo.Project_Needs.TotalDelievered, dbo.Project_Needs.Sources_ID," _
          & " dbo.Project_Needs.Need_Doc_id, dbo.Needs_Main_Type.NMT_Desc, dbo.Needs_Sup_Type.NST_Desc, dbo.Project_Needs_Document.id " _
          & " from dbo.Project_Needs INNER JOIN  dbo.Needs_Sup_Type ON dbo.Project_Needs.nst_nst_id = dbo.Needs_Sup_Type.NST_ID INNER JOIN" _
          & " dbo.Needs_Main_Type ON dbo.Needs_Sup_Type.nmt_nmt_id = dbo.Needs_Main_Type.NMT_ID LEFT OUTER JOIN" _
          & " dbo.Project_Needs_Document ON dbo.Project_Needs.Need_Doc_id = dbo.Project_Needs_Document.id" _
          & " where proj_proj_id = " & Session_CS.Project_id _
          & " order by NMT_Desc,NST_Desc,PNed_ID"
        Dim dt1 As New DataTable
        dt1 = General_Helping.GetDataTable(sql)
        gvMain.Visible = True
        gvMain.DataSource = General_Helping.GetDataTable(sql)
        gvMain.DataBind()

        'Dim i As Integer = 0

        'For Each row As GridViewRow In gvMain.Rows
        '    If CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text <> "" Then
        '        If Integer.Parse(CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text) = Integer.Parse(dt1.Rows(i)("PNed_Number")) Then
        '            CType(gvMain.Rows(i).FindControl("BtnSave"), Button).Enabled = False
        '        End If
        '    End If
        '    i += 1
        'Next



    End Sub

#End Region



#Region "save"
    Protected Sub saveAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveAll.Click

        SaveFileContent()
        Dim i As Integer = 0
        Dim sql As String = ""
        sql = "select Project_Needs.* ,NMT_Desc,NST_Desc from Project_Needs" _
            & " join Needs_Sup_Type on Project_Needs.nst_nst_id = Needs_Sup_Type.NST_ID" _
            & " join Needs_Main_Type on Needs_Sup_Type.nmt_nmt_id = Needs_Main_Type.NMT_ID" _
            & " where proj_proj_id = " & Session_CS.Project_id _
            & " order by NMT_Desc,NST_Desc,PNed_ID"
        Dim dt1 As New DataTable
        dt1 = General_Helping.GetDataTable(sql)
        For Each row As GridViewRow In gvMain.Rows

            If CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text <> "" Then
                If CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text = 0 Then
                    CType(gvMain.Rows(i).FindControl("astrisk"), Label).Visible = True
                    lblPageStatus.Text = "الكمية المصدق بها لايمكن أن تساوى 0"
                    lblPageStatus.Visible = True
                    Return
                ElseIf Integer.Parse(CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text) > Integer.Parse(dt1.Rows(i)("PNed_Number")) Then

                    CType(gvMain.Rows(i).FindControl("astrisk"), Label).Visible = True
                    lblPageStatus.Text = "الكمية المصدق بها تتخطى الكميه المطلوبة"
                    lblPageStatus.Visible = True
                    Return
                    'Else

                    'End If

                ElseIf CType(gvMain.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then

                    'div1.Style.Add("display", "block")
                    General_Helping.ExcuteQuery("update Project_Needs set approved_amount = " & CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text & ", Need_Doc_id = " & lblID.Text & " where PNed_ID = " & dt1.Rows(i)("PNed_ID"))


                    'Else
                    '    lblPageStatus.Visible = True
                    '    lblPageStatus.Text = "يجب ادخال ملف الوثيقة أولاَ"


                Else

                    'div1.Style.Add("display", "none")
                    Dim cmd As Integer = General_Helping.ExcuteQuery("update Project_Needs set approved_amount = " & CType(gvMain.Rows(i).FindControl("txtApprove"), TextBox).Text & " where PNed_ID = " & dt1.Rows(i)("PNed_ID"))


                End If
            Else

                Dim dt2 As DataTable = General_Helping.GetDataTable("select count(Need_Availble_Id) as records from Need_Availble where PNed_PNed_Id=" & dt1.Rows(i)("PNed_ID"))
                If dt2.Rows(0)("records") > 0 Then
                    CType(gvMain.Rows(i).FindControl("astrisk"), Label).Visible = True
                    lblPageStatus.Text = "عفوا لا يمكن الحذف تمت الإتاحة لهذا الاحتياج"
                    lblPageStatus.Visible = True
                    Return
                Else

                    General_Helping.ExcuteQuery("update Project_Needs set approved_amount = Null where PNed_ID =" & dt1.Rows(i)("PNed_ID"))


                End If
            End If

            i += 1
        Next
        FillGrid()
        fillgridDoc()
        lblPageStatus.Visible = True
        lblPageStatus.Text = "تم الحفظ بنجاح"

    End Sub
#End Region

#Region "event handler"
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
    Public Sub SaveFileContent()
        Dim myStream As System.IO.Stream
        Dim fileLen As Integer
        Dim displayString As New StringBuilder()
        fileLen = FileUpload1.PostedFile.ContentLength
        Dim Input(fileLen) As Byte
        myStream = FileUpload1.FileContent
        myStream.Read(Input, 0, fileLen)
        OpenConnection()

        If (FileUpload1.HasFile = True) Then
            Dim DocName As String = FileUpload1.FileName
            Dim dotindex As Integer = DocName.LastIndexOf(".")
            Dim type As String = DocName.Substring(dotindex, DocName.Length - dotindex)
            Dim i As Integer = 0
            Dim cmd As New SqlCommand("Add_Edit_ProjNeedDoc", con)
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            If doc_id.Value = "0" Then

                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                cmd.Parameters.Add("@id", SqlDbType.Int)
                cmd.Parameters.Add("@Doc_Desc", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 255)
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)
                cmd.Parameters("@id").Value = "0"
                cmd.Parameters("@mode").Value = "new"
                cmd.Parameters("@File_data").Value = Input
                cmd.Parameters("@File_name").Value = txtFileName.Text
                cmd.Parameters("@Doc_Desc").Value = TxtDes.Text
                cmd.Parameters("@File_ext").Value = type

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                con.Close()


                If (rowsAffected > 0) Then
                    Dim cmd2 As New SqlCommand("ProjNeedDoc_select", con)
                    cmd2.Connection = con
                    cmd2.CommandType = CommandType.StoredProcedure
                    Dim sqladptr As SqlDataAdapter = New SqlDataAdapter
                    sqladptr.SelectCommand = cmd2
                    Dim DT As DataTable = New DataTable()
                    sqladptr.Fill(DT)
                    lblID.Text = DT.Rows(0)("id").ToString()
                    fillgridDoc()
                    con.Close()
                End If
            Else
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                cmd.Parameters.Add("@id", SqlDbType.Int)
                cmd.Parameters.Add("@Doc_Desc", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 255)
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)
                cmd.Parameters("@id").Value = doc_id.Value
                cmd.Parameters("@Doc_Desc").Value = TxtDes.Text
                cmd.Parameters("@mode").Value = "edit"
                cmd.Parameters("@File_data").Value = Input
                cmd.Parameters("@File_name").Value = txtFileName.Text
                cmd.Parameters("@File_ext").Value = type
                cmd.ExecuteNonQuery()

                Dim rowsAffected2 As Integer = cmd.ExecuteNonQuery()
                If (rowsAffected2 > 0) Then
                    lblPageStatus.Text = "تم التعديل بنجاح"
                    fillgridDoc()
                End If
                con.Close()
            End If
        ElseIf (txtFileName.Text <> Nothing & TxtDes.Text <> Nothing) Then
            Dim cmd As New SqlCommand("update Project_Needs_Document set File_name =  '" & txtFileName.Text & "', Doc_Desc = '" & TxtDes.Text & "' where id = " & doc_id.Value, con)
            OpenConnection()
            cmd.Connection = con
            Dim rowsAffected3 As Integer = cmd.ExecuteNonQuery()
            con.Close()
            If (rowsAffected3 > 0) Then
                lblPageStatus.Text = "تم التعديل بنجاح"
            End If
        End If
    End Sub


    Public Function OpenConnection() As Boolean
        Try
            If con.State <> ConnectionState.Open Then
                '''''''''''''specify the ConnectionStrng property'''''''''''''
                Dim conString As String '= "Data Source=migo-pc;Initial Catalog=ForTestOnly;Persist Security Info=True;User ID=WebProjects;Password=sqlasp"
                conString = Database.ConnectionString

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

    Protected Sub GridNeed_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridNeed.RowCommand
        If e.CommandName = "EditItem" Then
            UpdateDoc.Visible = True
            saveAll.Visible = False
            doc_id.Value = e.CommandArgument
            OpenConnection()
            Dim cmd As New SqlCommand("Project_Needs_Document_select", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@id").Value = e.CommandArgument
            Dim sqladptr As SqlDataAdapter = New SqlDataAdapter
            sqladptr.SelectCommand = cmd
            Dim DT As DataTable = New DataTable()
            sqladptr.Fill(DT)
            txtFileName.Text = DT.Rows(0)("File_name").ToString()
            TxtDes.Text = DT.Rows(0)("Doc_Desc").ToString()
            fillgridDoc()

        End If

        If e.CommandName = "RemoveItem" Then
            OpenConnection()

            Dim cmd As New SqlCommand("delete from Project_Needs_Document where id = " & e.CommandArgument, con)
            cmd.Connection = con
            cmd.ExecuteNonQuery()

            Dim cmd1 As New SqlCommand("update Project_Needs set Need_Doc_id=" & 0 & " where PNed_ID = " & e.CommandArgument, con)
            cmd1.Connection = con
            cmd1.ExecuteNonQuery()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
            fillgridDoc()
            FillGrid()
        End If
    End Sub

    Public Sub fillgridDoc()
        OpenConnection()
        'Dim cmd1 As New SqlCommand(" select * from ")
        Dim cmd As New SqlCommand("SELECT DISTINCT Project_Needs_Document.id,Project_Needs_Document.[File_name] FROM dbo.Project_Needs_Document  JOIN dbo.Project_Needs ON  dbo.Project_Needs_Document.id =dbo.Project_Needs.Need_Doc_id  where Project_Needs.proj_proj_id = " & Session_CS.Project_id, con)
        cmd.Connection = con
        Dim sqladptr As SqlDataAdapter = New SqlDataAdapter
        sqladptr.SelectCommand = cmd
        Dim DT As DataTable = New DataTable()
        sqladptr.Fill(DT)
        GridNeed.DataSource = DT
        GridNeed.DataBind()
        con.Close()
    End Sub

    Protected Sub UpdateDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateDoc.Click


        SaveFileContent()
        Dim cmd1 As New SqlCommand("update Project_Needs set Need_Doc_id=" & doc_id.Value, con)
        GridNeed.DataBind()
    End Sub
End Class