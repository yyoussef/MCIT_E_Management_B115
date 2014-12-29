Imports System.Data

Partial Class WebForms_Employee_Entry_Screen
    Inherits System.Web.UI.Page


#Region "Variables"
    Dim Employee_ENTITY As New BLL.EMPLOYEE

    Dim Obj_General_Helping As New General_Helping

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
            FillDDLs()
            BtnSave.CommandArgument = "new"
        End If
    End Sub

#Region "Clear"
    Private Sub Clear()
        txt_emp_name.Text = ""
        ddl_job_desc.SelectedValue = ".....اختر فئةالوظيفه....."
        ddl_dept.SelectedValue = "....اختر الاداره....."

    End Sub
#End Region

#Region "Validation"
    Private Function Valid() As Boolean
        If txt_emp_name.Text = "" Or ddl_dept.SelectedValue = "....اختر الاداره....." Or ddl_job_desc.SelectedValue = ".....اختر فئةالوظيفه....." Then
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا يجب ادخال البيانات اولا"
            Return False
        Else
            lblPageStatus.Visible = False
            Return True
        End If
    End Function
#End Region

#Region "fills"
    Private Sub FillGrid()
        Dim sql As String = ""
        Dim _dt As New DataTable

        sql = "select Employee.*  ,dept_name,jtit_desc from Employee" _
        & " join departments on dept_dept_id = dept_id" _
        & " join job on job_job_id = job_id" _
        & " join job_title on jtit_jtit_id = jtit_id"

        _dt = General_Helping.GetDataTable(sql)
        gvMain.DataSource = _dt
        gvMain.DataBind()
    End Sub
    Private Sub FillDDLs()
        Dim dt As DataTable
        dt = General_Helping.GetDataTable("select dept_id,dept_name from departments")
        Obj_General_Helping.SmartBindDDL(ddl_dept, dt, "dept_id", "dept_name", "....اختر الاداره.....")

        dt = General_Helping.GetDataTable("select JTIT_id,JTIT_Desc  from JOB_TITLE")
        Obj_General_Helping.SmartBindDDL(ddl_job_desc, dt, "JTIT_id", "JTIT_Desc", ".....اختر فئةالوظيفه.....")


    End Sub
#End Region

#Region "Save Data"
    Private Sub SaveDataForClasses(Optional ByVal ID As Integer = 0)
        Try

            If ID = 0 Then

                Dim Employee_ENTITY As New BLL.EMPLOYEE
                Employee_ENTITY.Pmp_Name = txt_emp_name.Text
                Employee_ENTITY.Dept_Dept_Id = ddl_dept.SelectedValue
                Employee_ENTITY.Job_Job_Id = ddl_job_desc.SelectedValue
                Employee_ENTITY.Save()
                FillGrid()
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم الحفظ بنجاح"
            Else

                Dim Employee_ENTITY As New BLL.EMPLOYEE(ID)
                Employee_ENTITY.Pmp_Name = txt_emp_name.Text
                Employee_ENTITY.Dept_Dept_Id = ddl_dept.SelectedValue
                Employee_ENTITY.Job_Job_Id = ddl_job_desc.SelectedValue
                Employee_ENTITY.Save()
                FillGrid()
                BtnSave.CommandArgument = "new"
                lblPageStatus.Visible = True
                lblPageStatus.Text = "تم التعديل بنجاح"
            End If
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
                SaveDataForClasses(pmp_ID.Value)
            End If
        End If
    End Sub

    Protected Sub ImgBtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BtnSave.CommandArgument = "edit"
        Dim _dt As New DataTable
        _dt = Employee_ENTITY.Get(CType(sender, ImageButton).CommandArgument)
        txt_emp_name.Text = _dt.Rows(0)("pmp_name")
        ddl_dept.SelectedValue = _dt.Rows(0)("dept_dept_id")
        ddl_job_desc.SelectedValue = _dt.Rows(0)("job_job_id")
        pmp_ID.Value = CType(sender, ImageButton).CommandArgument
        lblPageStatus.Visible = False
    End Sub

    Protected Sub ImgBtnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim Employee_ENTITY As New BLL.EMPLOYEE(CType(sender, ImageButton).CommandArgument)
            Employee_ENTITY.Delete()
            FillGrid()
            lblPageStatus.Visible = True
            lblPageStatus.Text = "لقد تم الحذف بنجاح"
        Catch ex As Exception
            lblPageStatus.Visible = True
            lblPageStatus.Text = "عفوا لا يمكن الحذف"
        End Try
    End Sub


#End Region

End Class