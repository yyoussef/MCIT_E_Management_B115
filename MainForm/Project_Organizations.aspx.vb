Imports System.Data
Imports MCIT.Web.Data
Imports System.Data.SqlClient


Partial Class WebForms_Project_Organizations
    Inherits System.Web.UI.Page
    Dim Session_CS As New Session_CS


#Region "Variables"
    Dim Project_Org_ENTITY As New BLL.Project_Organization
    Dim Obj_General_Helping As New General_Helping
    Dim org_entity As New BLL.Organization
    Dim sql_Connection As String = DBL.Universal.GetConnectionString()

#End Region


#Region "On Init"

    Protected Overrides Sub OnInitComplete(ByVal e As System.EventArgs)

        Smart_Search_org.sql_Connection = sql_Connection
        Smart_Search_org.Text_Field = "Org_Desc "
        Smart_Search_org.Value_Field = "ORG_id "
        Dim Query As String = "select ORG_id,Org_Desc from Organization"
        Smart_Search_org.datatble = General_Helping.GetDataTable(Query)
        Smart_Search_org.DataBind()
        AddHandler Me.Smart_Search_org.Value_Handler, AddressOf Smart_Search_org_Selected
        MyBase.OnInitComplete(e)

    End Sub

#End Region



#Region "event handel"
    Private Sub Smart_Search_org_Selected(ByVal Value As String)
        Dim sql As String = ""
        Dim _dt As New DataTable
        If Smart_Search_org.SelectedValue <> "" Then
            Value = Smart_Search_org.SelectedValue
            sql = "select Project_Organization.* , Org_Desc from Project_Organization " _
                        & " join Project on Proj_proj_id = Proj_id" _
                        & " join Organization on org_org_id = org_id" _
                        & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where  Proj_proj_id=" & Session_CS.Project_id _
            & " and org_id=" & Smart_Search_org.SelectedValue
            '& " and Project_Organization.type=1"



            _dt = General_Helping.GetDataTable(sql)
            gvMain.DataSource = _dt
            gvMain.DataBind()

        Else
            Value = "0"
            sql = "select Project_Organization.* , Org_Desc from Project_Organization " _
                & " join Project on Proj_proj_id = Proj_id" _
                & " join Organization on org_org_id = org_id" _
                & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where  Proj_proj_id=" & Session_CS.Project_id



            _dt = General_Helping.GetDataTable(sql)
            gvMain.DataSource = _dt
            gvMain.DataBind()
        End If

    End Sub

#End Region



#Region "Load"

    Protected Sub stat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblchk.Visible = False
            chkmain.Visible = False
            ' ImgBtnResearch.Attributes.Add("OnClick", Me.Obj_Browser_Side.ClientSideFunction)
            'FillDDls()
            If Request.QueryString("type") = "1" Then
                lblMastertitle.Visible = True
                Page.Title = "الجهات المستفيدة"
            End If

            If Request.QueryString("type") = "2" Then
                lblexec.Visible = True
                Page.Title = "الجهات المنفذة"
                lblchk.Visible = True
                chkmain.Visible = True
            End If
            FillGrid()

            BtnSave.CommandArgument = "new"
        End If
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        'DDLOrgs.SelectedValue = ".....اختر جهه......"
        txtcontactPerson.Text = ""
        txtphone.Text = ""
        txtEmail.Text = ""
        txtmobile.Text = ""
        txtrole.Text = ""
        txtNotes.Text = ""
        chkmain.Checked = 0
    End Sub
#End Region


#Region "Validation"
    Private Function Valid() As Boolean
        If String.IsNullOrEmpty(Smart_Search_org.SelectedValue) Then
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
    Private Sub FillGrid()
        Dim sql As String = ""
        Dim _dt As New DataTable
        If Smart_Search_org.SelectedValue <> "" Then
            sql = "select Project_Organization.* , Org_Desc from Project_Organization " _
                        & " join Project on Proj_proj_id = Proj_id" _
                        & " join Organization on org_org_id = org_id" _
                        & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where  Proj_proj_id=" & Session_CS.Project_id _
            & " and org_id=" & Smart_Search_org.SelectedValue



            _dt = General_Helping.GetDataTable(sql)
            gvMain.DataSource = _dt
            gvMain.DataBind()

        Else
            sql = "select Project_Organization.* , Org_Desc from Project_Organization " _
                & " join Project on Proj_proj_id = Proj_id" _
                & " join Organization on org_org_id = org_id" _
                & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where  Proj_proj_id=" & Session_CS.Project_id
            If Request.QueryString("type") = "1" Then
                sql &= "and Project_Organization.type=1"

            End If
            If Request.QueryString("type") = "2" Then
                sql &= "and Project_Organization.type=2"

            End If

            _dt = General_Helping.GetDataTable(sql)
            gvMain.DataSource = _dt
            gvMain.DataBind()
        End If
    End Sub

    'Private Sub FillDDls()
    '    Dim dt As New DataTable
    '    dt = General_Helping.GetDataTable("select ORG_id,Org_Desc from Organization")
    '    Obj_General_Helping.SmartBindDDL(DDLOrgs, dt, "ORG_id", "Org_Desc", ".....اختر جهه......")
    'End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try

            If ID = 0 Then

                If gvMain.Rows.Count > 0 Then
                    Dim temp_sql As String = "select Org_Desc from Organization where ORG_id=" & Smart_Search_org.SelectedValue
                    Dim temp_dt As DataTable = General_Helping.GetDataTable(temp_sql)
                    Dim orgName As String = temp_dt.Rows(0)("Org_Desc")
                    'Dim i As Integer = 0
                    'For Each row As GridViewRow In gvMain.Rows
                    '    If gvMain.Rows(i).Cells(0).Text = orgName Then
                    '        lblPageStatus.Visible = True
                    '        lblPageStatus.Text = "تم ادخال بيانات لهذه الجهة من قبل"
                    '        Return
                    '    End If
                    '    i += 1
                    'Next
                End If

                General_Helping.ExcuteQuery("insert into Project_Organization (Proj_Proj_Id) values (" & Session_CS.Project_id & ")")
                Dim Sql As String = "SELECT MAX(POrg_ID) AS LargestPOrg_ID FROM Project_Organization"
                Dim _dt As DataTable = General_Helping.GetDataTable(Sql)

                General_Helping.ExcuteQuery("update Project_Organization set Org_Org_Id =" & Smart_Search_org.SelectedValue & "where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                If txtcontactPerson.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Contact_Person ='" & txtcontactPerson.Text & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                End If
                If txtphone.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Phone ='" & txtphone.Text & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                End If
                If txtEmail.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Email ='" & txtEmail.Text & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                End If
                If txtmobile.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Mobile ='" & txtmobile.Text & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                End If

                If txtNotes.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Notes ='" & txtNotes.Text & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                End If

                If txtrole.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set role ='" & txtrole.Text & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                End If

                If Request.QueryString("type") = "1" Then
                    General_Helping.ExcuteQuery("update Project_Organization set type ='" & 1 & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))


                End If
                If Request.QueryString("type") = "2" Then
                    General_Helping.ExcuteQuery("update Project_Organization set type ='" & 2 & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))

                End If
                If chkmain.Checked = True Then
                    General_Helping.ExcuteQuery("update Project_Organization set exec_org_main ='" & 1 & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))
                Else
                    General_Helping.ExcuteQuery("update Project_Organization set exec_org_main ='" & 0 & "'where POrg_ID = " & _dt.Rows(0)("LargestPOrg_ID"))

                End If


                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                General_Helping.ExcuteQuery("update Project_Organization set Org_Org_Id  =" & Smart_Search_org.SelectedValue & " where POrg_ID = " & POrg_id.Value)
                If txtcontactPerson.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Contact_Person ='" & txtcontactPerson.Text & "' where POrg_ID = " & POrg_id.Value)
                End If
                If txtphone.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Phone ='" & txtphone.Text & "'where POrg_ID = " & POrg_id.Value)
                End If
                If txtEmail.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Email ='" & txtEmail.Text & "'where POrg_ID = " & POrg_id.Value)
                End If
                If txtmobile.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Mobile ='" & txtmobile.Text & "'where POrg_ID = " & POrg_id.Value)
                End If
                If txtNotes.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set Notes ='" & txtNotes.Text & "'where POrg_ID = " & POrg_id.Value)
                End If

                If txtrole.Text <> "" Then
                    General_Helping.ExcuteQuery("update Project_Organization set role ='" & txtrole.Text & "'where POrg_ID = " & POrg_id.Value)
                End If
                If chkmain.Checked = True Then
                    General_Helping.ExcuteQuery("update Project_Organization set exec_org_main ='" & 1 & "'where POrg_ID = " & POrg_id.Value)
                Else
                    General_Helping.ExcuteQuery("update Project_Organization set exec_org_main ='" & 0 & "'where POrg_ID = " & POrg_id.Value)

                End If


                FillGrid()
                BtnSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
            End If
            BtnSave.Text = "حفــــــظ"
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
                SaveDataForClasses(POrg_id.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable

        _dt = Project_Org_ENTITY.Get(CType(sender, ImageButton).CommandArgument)
        Smart_Search_org.SelectedValue = _dt.Rows(0)("org_org_id")
        txtcontactPerson.Text = IIf(_dt.Rows(0)("Contact_Person") Is DBNull.Value, "", _dt.Rows(0)("Contact_Person"))
        txtphone.Text = IIf(_dt.Rows(0)("Phone") Is DBNull.Value, "", _dt.Rows(0)("Phone"))
        txtEmail.Text = IIf(_dt.Rows(0)("Email") Is DBNull.Value, "", _dt.Rows(0)("Email"))
        txtmobile.Text = IIf(_dt.Rows(0)("mobile") Is DBNull.Value, "", _dt.Rows(0)("mobile"))
        txtNotes.Text = IIf(_dt.Rows(0)("Notes") Is DBNull.Value, "", _dt.Rows(0)("Notes"))
        txtrole.Text = IIf(_dt.Rows(0)("role") Is DBNull.Value, "", _dt.Rows(0)("role"))
        'chkmain.Checked = IIf(_dt.Rows(0)("exec_org_main") Is DBNull.Value, False, Convert.ToBoolean(_dt.Rows(0)("exec_org_main")))
        If _dt.Rows(0)("exec_org_main") Is DBNull.Value Then
            chkmain.Checked = False
        Else
            chkmain.Checked = True
        End If
        POrg_id.Value = CType(sender, ImageButton).CommandArgument
        Dim i As Integer = 0
        Dim id As Integer
        For Each row As GridViewRow In gvMain.Rows
            If CType(gvMain.Rows(i).FindControl("POrg_id"), HtmlControls.HtmlInputHidden).Value = POrg_id.Value Then
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

            Dim Project_Organization_ENTITY As New BLL.Project_Organization(CType(sender, ImageButton).CommandArgument)
            Project_Organization_ENTITY.Delete()
            FillGrid()
            'lblPageStatus.Visible = True
            'lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRows(gvMain)
    End Sub
#End Region
    'Private Sub ddlOrgs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLOrgs.SelectedIndexChanged

    '    lblPageStatus.Text = ""

    'End Sub
End Class