Imports System.Data.SqlClient
Imports System.Data

Partial Class WebForms_Project_Document
    Inherits System.Web.UI.Page
    'Session_CS Session_CS
    Public con As New SqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillGrid()
        End If
    End Sub

    Private Sub FillGrid()
        Dim sql As String = ""
        If CDataConverter.ConvertToInt(Session_CS.Project_id) > 0 Then
            sql = " select PDOC_id,PDOC_FileName  " _
                   & " from project " _
                   & " join Projects_Documents on dbo.Projects_Documents.Proj_Proj_id = dbo.Project.Proj_id " _
                   & " where proj_proj_id = " & Session_CS.Project_id _
                   & " order by pdoc_id desc "
            gvMain.DataSource = General_Helping.GetDataTable(sql)
            gvMain.DataBind()
        End If
    End Sub

#Region "dimmed fn"
    Private Sub dimmed()
        If UploadButton.Text = "تعديل" Then
            txtFileName.Enabled = False
            FileUpload1.Enabled = False
        End If

    End Sub

#End Region
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

    ' Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UploadButton.Click
    Public Sub UploadDocuments()
        If PDOC_ID.Value <> "0" And (FileUpload1.HasFile) Then
            DisplayFileContents(FileUpload1.PostedFile)
            txtFileName.Text = ""
        ElseIf PDOC_ID.Value <> "0" And (FileUpload1.HasFile = False) And txtFileName.Text <> "" Then
            Dim Sql As String = "update Projects_Documents set  PDOC_FileName = " & txtFileName.Text
            General_Helping.ExcuteQuery(Sql)
        ElseIf PDOC_ID.Value = "0" And (FileUpload1.HasFile) Then
            DisplayFileContents(FileUpload1.PostedFile)
            'ElseIf PDOC_ID.Value <> "0" 
            'lblErrorMsg.Visible = True
            'lblErrorMsg.Text = "عفوا يجب اختيار ملف"
        End If
    End Sub

    Public Sub DisplayFileContents(ByVal file As HttpPostedFile)
        Dim myStream As System.IO.Stream
        Dim fileLen As Integer
        Dim displayString As New StringBuilder()
        fileLen = FileUpload1.PostedFile.ContentLength
        Dim Input(fileLen) As Byte
        myStream = FileUpload1.FileContent

        If (FileUpload1.HasFile = True) Then
            Dim DocName As String = FileUpload1.FileName
            Dim dotindex As Integer = DocName.LastIndexOf(".")
            Dim type As String = DocName.Substring(dotindex, DocName.Length - dotindex)

            myStream.Read(Input, 0, fileLen)

            OpenConnection()
            If PDOC_ID.Value = "0" Then
                Dim cmd As New SqlCommand()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "insert into Projects_Documents (PDOC_Image,PDOC_FileName,PDOC_Type,Proj_Proj_id) VALUES (@PDOC_Image,@PDOC_FileName,@PDOC_Type,@Proj_Proj_id)"
                cmd.Parameters.Add("@PDOC_Image", SqlDbType.VarBinary)
                cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@PDOC_Type", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)

                cmd.Parameters("@PDOC_Image").Value = Input
                cmd.Parameters("@PDOC_FileName").Value = txtFileName.Text

                cmd.Parameters("@PDOC_Type").Value = type
                cmd.Parameters("@Proj_Proj_id").Value = Session_CS.Project_id


                cmd.ExecuteNonQuery()
                FillGrid()
                lblErrorMsg.Text = "تم التحميل بنجاح"

            End If

        End If

    End Sub

    Public Sub UpdateUploadDocument()
        Dim myStream As System.IO.Stream
        Dim fileLen As Integer
        Dim displayString As New StringBuilder()

        fileLen = FileUpload1.PostedFile.ContentLength
        Dim Input(fileLen) As Byte
        myStream = FileUpload1.FileContent
        Dim DocName As String = FileUpload1.FileName
        If (FileUpload1.HasFile = True) Then
            Dim dotindex As Integer = DocName.LastIndexOf(".")
            Dim type As String = DocName.Substring(dotindex, DocName.Length - dotindex)

            myStream.Read(Input, 0, fileLen)
            Session("myStream") = Input
            OpenConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            If PDOC_ID2.Value <> "0" And (FileUpload1.HasFile) Then

                cmd.CommandText = " update Projects_Documents set PDOC_Image=@PDOC_Image,PDOC_FileName=@PDOC_FileName,PDOC_Type=@PDOC_Type where PDOC_ID =@PDOC_ID"
                cmd.Parameters.Add("@PDOC_Image", SqlDbType.VarBinary)
                cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@PDOC_Type", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@PDOC_ID", SqlDbType.BigInt)

                cmd.Parameters("@PDOC_Image").Value = Input
                cmd.Parameters("@PDOC_FileName").Value = txtFileName.Text
                cmd.Parameters("@PDOC_Type").Value = type
                cmd.Parameters("@PDOC_ID").Value = PDOC_ID2.Value

                cmd.ExecuteScalar()

                lblErrorMsg.Text = "تم التعديل بنجاح"
            End If

        ElseIf txtFileName.Text <> "" And Not (FileUpload1.HasFile) Then
            OpenConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Projects_Documents set PDOC_FileName=@PDOC_FileName where PDOC_ID = @PDOC_ID"

            cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
            cmd.Parameters.Add("@PDOC_ID", SqlDbType.BigInt)


            cmd.Parameters("@PDOC_FileName").Value = txtFileName.Text
            cmd.Parameters("@PDOC_ID").Value = PDOC_ID2.Value

            cmd.ExecuteScalar()

            lblErrorMsg.Text = "تم التعديل بنجاح"

        End If

        UploadButton.Text = "حفــــــظ"
        FillGrid()

    End Sub
    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim sql As String = ""
        Dim sql2 As String = ""
        PDOC_ID.Value = CType(sender, ImageButton).CommandArgument
        sql = "select * from Projects_Documents where Proj_proj_id = " & Session_CS.Project_id
        Dim ddt As DataTable
        Dim _dt As DataTable = General_Helping.GetDataTable(sql)
        If _dt.Rows.Count > 0 Then
            sql2 = "select * from Projects_Documents where PDOC_id= " & CType(sender, ImageButton).CommandArgument
            ddt = General_Helping.GetDataTable(sql2)
            If Not _dt.Rows(0)("PDOC_FileName") Is DBNull.Value Then
                txtFileName.Text = ddt.Rows(0)("PDOC_FileName")
                PDOC_ID2.Value = ddt.Rows(0)("PDOC_id")
            Else
                PDOC_ID2.Value = 0
            End If
            Dim i As Integer = 0
            Dim id As Integer
            For Each row As GridViewRow In gvMain.Rows
                If CType(gvMain.Rows(i).FindControl("PDOC_ID2"), HtmlControls.HtmlInputHidden).Value = PDOC_ID2.Value Then
                    id = i
                Else
                    gvMain.Rows(i).BackColor = Drawing.Color.White
                End If
                i += 1
            Next
            gvMain.Rows(id).BackColor = Drawing.Color.Lavender

            'BtnSave.Text = "حفــــــظ"
            'UploadButton.Text = "حفــــــظ"
            UploadButton.Text = "تعديــــل"
            lblErrorMsg.Text = ""
        End If
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim str As String
        Dim cmd As SqlCommand
        Dim con As SqlConnection
        Dim constr As String

        constr = ConfigurationManager.AppSettings("ConnectionString")
        'con = New SqlConnection(constr)
        'con.Open()


        PDOC_ID3.Value = CType(sender.parent.parent.FindControl("PDOC_id3"), HtmlControls.HtmlInputHidden).Value
        str = " delete from projects_documents where pdoc_id= " & PDOC_ID3.Value
        Dim d As Integer = General_Helping.ExcuteQuery(" delete from projects_documents where pdoc_id= " & PDOC_ID3.Value)
        'cmd = New SqlCommand(str, con)
        'cmd.ExecuteNonQuery()
        gvMain.DataBind()
        lblErrorMsg.Text = " تم الحذف بنجاح"
        FillGrid()


    End Sub

    Protected Sub UploadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UploadButton.Click
        If PDOC_ID.Value = "0" Then

            If FileUpload1.HasFile = False And txtFileName.Text = "" Then

                lblErrorMsg.Text = "يجب إدخال البيانات أولاً"
            Else
                UploadDocuments()
                txtFileName.Text = ""
            End If

        Else
            UpdateUploadDocument()

            txtFileName.Text = ""
            UploadButton.Text = "حفظ"

        End If
        'ElseIf FileUpload1.HasFile And txtFileName.Text <> "" Then

        '    Dim myStream As System.IO.Stream
        '    Dim fileLen As Integer
        '    Dim displayString As New StringBuilder()

        '    fileLen = FileUpload1.PostedFile.ContentLength

        '    Dim Input(fileLen) As Byte

        '    myStream = FileUpload1.FileContent


        '    myStream.Read(Input, 0, fileLen - 1)

        '    Session("myStream") = Input

        '    OpenConnection()
        '    Dim cmd As New SqlCommand()
        '    cmd.Connection = con
        '    cmd.CommandType = CommandType.Text
        '    cmd.CommandText = "update Projects_Documents set PDOC_Image=@PDOC_Image,PDOC_FileName=@PDOC_FileName,PDOC_Type=@PDOC_Type,Proj_Proj_id=@Proj_Proj_id where PDOC_ID = @PDOC_ID"
        '    cmd.Parameters.Add("@PDOC_Image", SqlDbType.Image)
        '    cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
        '    cmd.Parameters.Add("@PDOC_Type", SqlDbType.NVarChar, 250)
        '    cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)
        '    cmd.Parameters.Add("@PDOC_ID", SqlDbType.BigInt)

        '    cmd.Parameters("@PDOC_Image").Value = Input
        '    cmd.Parameters("@PDOC_FileName").Value = txtFileName.Text

        '    cmd.Parameters("@PDOC_Type").Value = FileUpload1.PostedFile.ContentType
        '    'cmd.Parameters("@Proj_Proj_id").Value = Session_CS.Project_id
        '    cmd.Parameters("@PDOC_ID").Value = PDOC_ID.Value


        '    cmd.ExecuteScalar()

        '    lblErrorMsg.Text = "تم التعديل بنجاح"
        '    PDOC_ID.Value = "0"

        'ElseIf txtFileName.Text <> "" And Not (FileUpload1.HasFile) Then
        '    Dim myStream As System.IO.Stream
        '    Dim fileLen As Integer
        '    Dim displayString As New StringBuilder()

        '    fileLen = FileUpload1.PostedFile.ContentLength

        '    Dim Input(fileLen) As Byte

        '    myStream = FileUpload1.FileContent


        '    myStream.Read(Input, 0, fileLen - 1)

        '    Session("myStream") = Input
        '    Dim cmd As New SqlCommand()
        '    cmd.Connection = con
        '    cmd.CommandType = CommandType.Text
        '    cmd.CommandText = "update Projects_Documents set PDOC_Image=@PDOC_Image,PDOC_FileName=@PDOC_FileName,PDOC_Type=@PDOC_Type,Proj_Proj_id=@Proj_Proj_id where PDOC_ID = @PDOC_ID"
        '    cmd.Parameters.Add("@PDOC_Image", SqlDbType.Image)
        '    cmd.Parameters.Add("@PDOC_FileName", SqlDbType.NVarChar, 250)
        '    cmd.Parameters.Add("@PDOC_Type", SqlDbType.NVarChar, 250)
        '    cmd.Parameters.Add("@Proj_Proj_id", SqlDbType.BigInt)
        '    cmd.Parameters.Add("@PDOC_ID", SqlDbType.BigInt)

        '    cmd.Parameters("@PDOC_Image").Value = Input
        '    cmd.Parameters("@PDOC_FileName").Value = txtFileName.Text
        '    'Dim str As String = FileUpload1.FileName
        '    'Dim str2() As String = str.Split(".")
        '    cmd.Parameters("@PDOC_Type").Value = FileUpload1.PostedFile.ContentType
        '    cmd.Parameters("@Proj_Proj_id").Value = Session_CS.Project_id
        '    cmd.Parameters("@PDOC_ID").Value = PDOC_ID.Value
        '    Response.Write(cmd)
        '    cmd.ExecuteScalar()

        '    lblErrorMsg.Text = "تم التعديل بنجاح"
        '    PDOC_ID.Value = "0"
        'End If

        'UploadButton.Text = "حفــــــظ"
        'FillGrid()

    End Sub


End Class