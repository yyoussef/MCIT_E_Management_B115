Imports System.Data

Partial Public Class UserControls_Site_Menu2
    Inherits System.Web.UI.UserControl
    Dim Session_CS As New Session_CS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Div_Usual_User.Visible = True

        If Session("is_vacation_mng") = 1 Then
            Li31.Visible = True
        End If

        If Session("Eval_mng") = "1" Then
            LI_Eval_Emp.Visible = True
            LI_Eval_Emp_mng.Visible = True
            LI_Eval_Emp_mnstr.Visible = True
        End If

        If Session_CS.UROL_UROL_ID = 2 Then
            If CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0 Then
                LI_Search_Mnstr.Visible = True
            Else
                LI_Search_Mnstr.Visible = False
            End If

            AssMinister.Visible = True
            Div_Usual_User.Visible = False


        ElseIf Session_CS.UROL_UROL_ID = 3 Then
            If CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) = 0 Then
                LI_Search_Mngr.Visible = True
            Else
                LI_Search_Mngr.Visible = False
            End If

            MangerDepDiv.Visible = True
            Div_Usual_User.Visible = False

        ElseIf Session_CS.UROL_UROL_ID = 10 Then

            Div_Usual_User.Visible = False
            Taha_Div.Visible = True

        ElseIf Session_CS.UROL_UROL_ID = 4 Then
            If CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0 Then
                ProjManager.Visible = True
                Div_Usual_User.Visible = False
            End If


        End If

        If CDataConverter.ConvertToInt(Session_CS.Project_id.ToString()) > 0 Then
            Dim sql1 As String = ""
            sql1 = " SELECT Proj_id ,pmp_pmp_id " _
                   & " FROM     Project     " _
                   & " where Proj_id = '" & Session_CS.Project_id & "' and pmp_pmp_id = '" & Session_CS.pmp_id & "'"
            Dim DT As New DataTable
            DT = General_Helping.GetDataTable(sql1)
            If DT.Rows.Count > 0 Then
                MangerDepDiv.Visible = False
                ProjManager.Visible = True
                Div_Usual_User.Visible = False

            Else
                Dim sql2 As String = ""
                sql2 = " SELECT     Project_Team.proj_proj_id FROM         Project_Team WHERE     Edit_Project = 'true' and proj_proj_id = '" & Session_CS.Project_id & "'  " _
                       & " and pmp_pmp_id = '" & Session_CS.pmp_id & "'"
                Dim DT2 As New DataTable
                DT2 = General_Helping.GetDataTable(sql2)
                If DT2.Rows.Count > 0 Then
                    MangerDepDiv.Visible = False
                    ProjManager.Visible = True
                    Div_Usual_User.Visible = False
                End If


            End If


        End If


    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        'Response.Redirect("../WebForms2/Project_info.aspx?mode=edit&Proj_id=" & Session_CS.Project_id)
        Response.Redirect("../WebForms2/ProjectGeneralData.aspx?mode=edit&Proj_id=" & Session_CS.Project_id)
    End Sub
End Class