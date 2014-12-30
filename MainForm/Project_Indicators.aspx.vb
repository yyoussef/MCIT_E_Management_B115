Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class WebForms_Project_Indicators
    Inherits System.Web.UI.Page
    'Session_CS Session_CS


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#Region "print"
    Private Sub print()


        Dim sql As String = ""
        sql = " select PAI_Desc ,PAI_Wieght, PActv_Desc,IndT_Desc,Proj_Notes,Proj_title " _
             & " from Project_Activities_Indicators " _
             & " join Project_Activities ON  pactv_pactv_id= PActv_id " _
             & " join Indicators_Type on indt_indt_id =IndT_id " _
             & " join Project on proj_id = proj_proj_id " _
             & " where PActv_parent = 0"

        Dim dt As DataTable = General_Helping.GetDataTable(sql)

        Dim rpt As ReportDocument = New ReportDocument
        Dim ReportPath As String = Server.MapPath("..\reports\Indicator_Type.rpt")
        rpt.Load(ReportPath)
        rpt.SetDataSource(dt)
        rpt.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "report")


    End Sub


#End Region


    Protected Sub ImgBtnPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnPrint.Click

        print()

    End Sub
End Class