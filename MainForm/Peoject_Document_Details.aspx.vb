Imports System.Data

Partial Class WebForms_Peoject_Document_Details
    Inherits System.Web.UI.Page
    'Session_CS Session_CS


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim _dt As DataTable
            Dim sql As String = ""

            sql = "select File_data,File_ext,File_name from Departments_Documents where File_ID = " & Request.QueryString("File_ID")
            _dt = General_Helping.GetDataTable(sql)
            Dim bytes() As Byte = CType(_dt.Rows(0)("File_data"), Byte())
            Response.ContentType = "application/x-unknown"
            Dim File_Name As String
            File_Name = _dt.Rows(0)("File_name") & _dt.Rows(0)("File_ext")
            Response.AddHeader("Content-Disposition", "attachment; filename=" & Server.UrlPathEncode(File_Name))
            Response.BinaryWrite(bytes)
            'Response.AddHeader("Location", Page.Request.Url.ToString())
            'Response.Clear()
            'Response.BufferOutput = True
            'Response.ClearContent()
            ' Response.End()


            Response.Flush()
            Response.Close()
            'Response.Redirect(Page.Request.Url.ToString())
        End If
    End Sub

End Class
'begin
'Response.Buffer = True
'Response.Charset = ""
'Response.Cache.SetCacheability(HttpCacheability.NoCache)
'Response.ContentType = _dt.Rows(0)("PDOC_Type").ToString()
'Response.BinaryWrite(bytes)
'Response.Flush()
'Response.End()
'end
' try 2

'Response.Charset = "ASCII"
'Response.HeaderEncoding = UnicodeEncoding.ASCII
'Response.ContentEncoding = UnicodeEncoding.ASCII




'''' end try 2 '''

'try 1 version 
'Const myBufferSize As Integer = 1042

'Dim myInputStream As Stream
'myInputStream = New MemoryStream(bytes)
'Dim myOutputStream As Stream

'myOutputStream = System.IO.File.OpenWrite("d://My Files//file.doc")

'Dim buffer(myBufferSize) As Byte

'Dim numbytes As Integer


'While (myInputStream.Read(buffer, 0, myBufferSize) > 0)
'    myOutputStream.Write(buffer, 0, myInputStream.Read(buffer, 0, myBufferSize))

'End While



'myInputStream.Close()
'myOutputStream.Close()

''''end try''''


''''OLD try''''

'sql = "select PDOC_Image,PDOC_Type from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'_dt = General_Helping.GetDataTable(sql)
'Response.Buffer = True
'Response.ContentType = _dt.Rows(0)("PDOC_Type")
'Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))            
''Response.Flush()
'Response.End()

'If _dt.Rows(0)("PDOC_Type").ToLower() = "doc" Or _dt.Rows(0)("PDOC_Type").ToLower() = "docx" Then
'    Response.ContentType = "application/msword"
'    Response.ContentEncoding = Encoding.Default
'    sql = "select PDOC_Image from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'    _dt = General_Helping.GetDataTable(sql)
'    Response.Write(_dt.Rows.Count)
'    Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))
'    Response.Flush()
'    Response.End()
'ElseIf _dt.Rows(0)("PDOC_Type").ToLower() = "xls" Or _dt.Rows(0)("PDOC_Type").ToLower() = "xlsx" Then
'    Response.ContentType = "application/vnd.xls"
'    sql = "select PDOC_Image from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'    _dt = General_Helping.GetDataTable(sql)
'    Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))
'    Response.Flush()
'    Response.End()
'ElseIf _dt.Rows(0)("PDOC_Type").ToLower() = "ppt" Or _dt.Rows(0)("PDOC_Type").ToLower() = "pptx" Then
'    Response.ContentType = "application/vnd.ms-powerpoint"
'    sql = "select PDOC_Image from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'    _dt = General_Helping.GetDataTable(sql)
'    Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))
'    Response.Flush()
'    Response.End()
'ElseIf _dt.Rows(0)("PDOC_Type").ToLower() = "pdf" Then
'    Response.ContentType = "application/pdf"
'    sql = "select PDOC_Image from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'    _dt = General_Helping.GetDataTable(sql)
'    Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))
'    Response.Flush()
'    Response.End()
'ElseIf _dt.Rows(0)("PDOC_Type").ToLower() = "jpeg" Or _dt.Rows(0)("PDOC_Type").ToLower() = "jpg" Or _dt.Rows(0)("PDOC_Type").ToLower() = "jpe" Then
'    Response.ContentType = "image/jpeg"
'    sql = "select PDOC_Image from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'    _dt = General_Helping.GetDataTable(sql)
'    Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))
'    Response.Flush()
'    Response.End()
'ElseIf _dt.Rows(0)("PDOC_Type").ToLower() = "gif" Then
'    Response.ContentType = "image/gif"
'    sql = "select PDOC_Image from Projects_Documents where PDOC_id = " & Request.QueryString("PDOC_id")
'    _dt = General_Helping.GetDataTable(sql)
'    Response.BinaryWrite(_dt.Rows(0)("PDOC_Image"))
'    Response.Flush()
'    Response.End()

'End If
