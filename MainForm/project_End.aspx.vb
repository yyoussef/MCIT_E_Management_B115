Imports System.Data.SqlClient
Imports System.Data
Imports VB_Classes.Dates

Partial Class WebForms_project_End
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS
    Public con As New SqlConnection
    Dim Obj_General_Helping As New General_Helping

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sql3 As String = ""
            sql3 = "select * from Active_Satatus where ActStat_ID > 3"
            Dim _dt3 As DataTable = General_Helping.GetDataTable(sql3)
            Obj_General_Helping.SmartBindDDL(ddlprojSit, _dt3, "ActStat_ID", "ActStat_Desc", "اختر حالة الإنهاء")
            Dim str As DateTime = CDataConverter.ConvertDateTimeNowRtnDt()
            txtEndDate.Text = str.ToString("dd/MM/yyyy")
            Dim sql1 = "select Proj_End_Date,Proj_End_Note,Proj_is_commit from project where proj_id=" & Session_CS.Project_id
            Dim dt1 As DataTable = Obj_General_Helping.GetDataTable(sql1)

            If dt1.Rows.Count > 0 Then
                If Not dt1.Rows(0)("Proj_End_Date") Is DBNull.Value Then
                    txtEndDate.Text = dt1.Rows(0)("Proj_End_Date")
                End If
                If Not dt1.Rows(0)("Proj_End_Note") Is DBNull.Value Then
                    txtEndNote.Text = dt1.Rows(0)("Proj_End_Note")
                End If
                If dt1.Rows(0)("Proj_is_commit").ToString() = "4" Then
                    ddlprojSit.SelectedValue = 4
                End If
                If dt1.Rows(0)("Proj_is_commit").ToString() = "5" Then
                    ddlprojSit.SelectedValue = 5
                End If

                fillgrid()
            End If



        End If
    End Sub



    Protected Sub saveEndProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveEndProject.Click
        If ddlprojSit.SelectedIndex = 0 Then

            lblErrorMsg.Text = "يجب إدخال البيانات أولاً"
            txtEndNote.Text = ""

            Return
        Else
            'SaveFileContents(FileUpload1.PostedFile)
            Dim validated_End_date As String = ""
            If txtEndDate.Text <> "" Then
                If CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtEndDate.Text)) <> "" Then

                    'If date_validate(txtEndDate.Text) <> "" Then
                    validated_End_date = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtEndDate.Text))
                    txtEndDate.Text = CDataConverter.ConvertDateTimeToFormatdmy(CDataConverter.ConvertToDate(txtEndDate.Text))
                    lblErrorMsg.Visible = False
                    General_Helping.ExcuteQuery("update project set Proj_End_Date = '" & validated_End_date & "' where proj_id = " & Session_CS.Project_id)
                Else
                    lblErrorMsg.Text = "أدخل التاريخ (يوم/شهر/سنة) "
                    lblErrorMsg.Visible = True
                    Return
                End If

            End If
            If txtEndNote.Text <> "" Then
                General_Helping.ExcuteQuery("update project set Proj_End_Note = '" & txtEndNote.Text & "' where proj_id = " & Session_CS.Project_id)
            End If
            If ddlprojSit.SelectedValue = 4 Then
                General_Helping.ExcuteQuery("update project set Proj_is_commit = " & 4 & " where proj_id = " & Session_CS.Project_id)
                'ReportsClass.Reports.ShowAlertMessage("تم إنهاء المشروع بنجاح")
                'System.Windows.Forms.MessageBox.Show("تم إنهاء المشروع بنجاح")
                'Response.Redirect("~/WebForms2/default.aspx")
            ElseIf ddlprojSit.SelectedValue = 5 Then
                General_Helping.ExcuteQuery("update project set Proj_is_commit = " & 5 & " where proj_id = " & Session_CS.Project_id)
                'System.Windows.Forms.MessageBox.Show("تم إلغاءالمشروع ")
                'ReportsClass.Reports.ShowAlertMessage("تم إلغاءالمشروع ")
                'Response.Redirect("~/WebForms2/default.aspx")
            End If

        End If
    End Sub

    Public Sub SaveFileContents(ByVal file As HttpPostedFile)
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

            Dim cmd As New SqlCommand()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE Project set Proj_End_Document=@Proj_End_Document,Proj_End_Document_Name=@Proj_End_Document_Name,Proj_End_Document_Type=@Proj_End_Document_Type where Proj_id=" & Session_CS.Project_id
            cmd.Parameters.Add("@Proj_End_Document", SqlDbType.VarBinary)
            cmd.Parameters.Add("@Proj_End_Document_Name", SqlDbType.NVarChar, 100)
            cmd.Parameters.Add("@Proj_End_Document_Type", SqlDbType.NVarChar, 100)
            cmd.Parameters("@Proj_End_Document").Value = Input
            cmd.Parameters("@Proj_End_Document_Name").Value = txtFileName.Text
            cmd.Parameters("@Proj_End_Document_Type").Value = type
            cmd.ExecuteNonQuery()

            lblErrorMsg.Text = "تم التحميل بنجاح"



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

    Protected Sub saveDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveDoc.Click
        'Project_End_Document table_name'

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
            Dim cmd As New SqlCommand("Add_Edit_ProjEndDoc", con)
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure

            If Proj_doc_id.Value = "0" Then
                'cmd.CommandText = "UPDATE Project set Proj_End_Document=@Proj_End_Document,Proj_End_Document_Name=@Proj_End_Document_Name,Proj_End_Document_Type=@Proj_End_Document_Type where Proj_id=" & Session_CS.Project_id
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                cmd.Parameters.Add("@Proj_id", SqlDbType.Int)
                cmd.Parameters.Add("@End_Doc_ID", SqlDbType.Int)
                cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 255)
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)

                cmd.Parameters("@Proj_id").Value = Session_CS.Project_id
                cmd.Parameters("@End_Doc_ID").Value = "0"
                cmd.Parameters("@mode").Value = "new"
                cmd.Parameters("@File_data").Value = Input
                cmd.Parameters("@File_name").Value = txtFileName.Text
                cmd.Parameters("@File_ext").Value = type
                cmd.ExecuteNonQuery()

                lblErrorMsg.Text = "تم حفظ الوثيقة بنجاح"
                DocumentGrid.DataBind()
            Else
                cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
                cmd.Parameters.Add("@Proj_id", SqlDbType.Int)
                cmd.Parameters.Add("@End_Doc_ID", SqlDbType.Int)
                cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 255)
                cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
                cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)

                cmd.Parameters("@Proj_id").Value = Session_CS.Project_id
                cmd.Parameters("@End_Doc_ID").Value = Proj_doc_id.Value
                cmd.Parameters("@mode").Value = "edit"
                cmd.Parameters("@File_data").Value = Input
                cmd.Parameters("@File_name").Value = txtFileName.Text
                cmd.Parameters("@File_ext").Value = type
                cmd.ExecuteNonQuery()
                lblErrorMsg.Text = "تم التعديل بنجاح"
                DocumentGrid.DataBind()
            End If
            fillgrid()
        Else
            Dim cmd As New SqlCommand("update Project_End_Document set File_name=  '" & txtFileName.Text & "' where End_Doc_ID = " & Proj_doc_id.Value, con)
            OpenConnection()
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            lblErrorMsg.Text = "تم التعديل بنجاح"
            'cmd.Parameters.Add("@File_data", SqlDbType.VarBinary)
            'cmd.Parameters.Add("@Proj_id", SqlDbType.Int)
            'cmd.Parameters.Add("@End_Doc_ID", SqlDbType.Int)
            'cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 255)
            'cmd.Parameters.Add("@File_name", SqlDbType.NVarChar, 250)
            'cmd.Parameters.Add("@File_ext", SqlDbType.NVarChar, 250)

            'cmd.Parameters("@Proj_id").Value = Session_CS.Project_id
            'cmd.Parameters("@End_Doc_ID").Value = Proj_doc_id.Value
            'cmd.Parameters("@mode").Value = "edit"
            'cmd.Parameters("@File_data").Value = Input
            'cmd.Parameters("@File_name").Value = txtFileName.Text
            'cmd.Parameters("@File_ext").Value = Type
            'cmd.ExecuteNonQuery()
            'lblErrorMsg.Text = "تم التعديل بنجاح"
            fillgrid()

        End If

    End Sub

    Protected Sub DocumentGrid_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DocumentGrid.RowCommand

        If e.CommandName = "EditItem" Then
            OpenConnection()
            'Dim cmd1 As New SqlCommand(" select * from ")
            Dim cmd As New SqlCommand("select * from Project_End_Document where End_Doc_ID = " & e.CommandArgument, con)
            Dim sqladptr As SqlDataAdapter = New SqlDataAdapter
            sqladptr.SelectCommand = cmd
            Dim DT As DataTable = New DataTable()
            sqladptr.Fill(DT)
            Proj_doc_id.Value = e.CommandArgument

            txtFileName.Text = DT.Rows(0)("File_Name").ToString()

            fillgrid()

            'DocumentGrid.DataBind()
            'DocumentGrid.Visible = True

        End If
        If e.CommandName = "RemoveItem" Then
            OpenConnection()
            'Dim cmd1 As New SqlCommand(" select * from ")
            Dim cmd As New SqlCommand("delete from Project_End_Document where End_Doc_ID = " & e.CommandArgument, con)
            cmd.ExecuteNonQuery()

            fillgrid()
        End If
    End Sub
    Public Sub fillgrid()

        OpenConnection()
        'Dim cmd1 As New SqlCommand(" select * from ")
        Dim cmd As New SqlCommand("Project_End_Document_SelectByProj_id", con)
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Proj_id", SqlDbType.Int)
        cmd.Parameters("@Proj_id").Value = Session_CS.Project_id.ToString()
        Dim sqladptr As SqlDataAdapter = New SqlDataAdapter
        sqladptr.SelectCommand = cmd
        Dim DT As DataTable = New DataTable()
        sqladptr.Fill(DT)
        DocumentGrid.DataSource = DT
        DocumentGrid.DataBind()
        con.Close()

    End Sub
    

End Class
