Imports System.Data

Partial Class WebForms_Project_Activities_All
    Inherits System.Web.UI.Page
    'Session_CS Session_CS

    Dim Nroot As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillGrid(Request.QueryString("PActv_ID"))

        End If
    End Sub

    Private Sub FillGrid(Optional ByVal PActv_id As Integer = 0)
        If PActv_id <> 0 Then
            Dim sql As String = ""
            Dim _dt As New DataTable
            ' sql = " select PA.PActv_Desc PActv_ChildDesc,PA.PActv_Start_Date,PA.PActv_Period,PA.PActv_Wieght, " _
            '& " (select PActv_Desc from Project_Activities PACTV where PACTV.PActv_ID = PA.pactv_parent) PActv_Desc " _
            '& " from Project_Activities PA " _
            '    & " join Project on Proj_proj_id = Proj_id " _
            '    & " join employee on Project.pmp_pmp_id = EMPLOYEE.PMP_ID where proj_is_commit = 2 and pactv_parent <> 0 and pa.PActv_Parent = " & PActv_id
            sql = "select * from Project_Activities where pactv_parent = " & PActv_id _
                & " order by PActv_Parent,Child_Actv_Num"
            _dt = General_Helping.GetDataTable(sql)
            gvMain.DataSource = _dt
            gvMain.DataBind()
        End If
    End Sub

    Private Sub gvMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMain.PreRender
        DBL.Helper.MergeRows(gvMain)
    End Sub

    Private Sub RblActType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblActType.SelectedIndexChanged
        If RblActType.SelectedValue = 0 Then
            tblGridView.Visible = True
            tblTreeView.Visible = False
            TreeView1.Nodes.Clear()
        Else
            tblGridView.Visible = False
            tblTreeView.Visible = True
            PopulateRootLevel(Session_CS.Project_id)
        End If
    End Sub

#Region "TreeView Actions"
    Private Sub PopulateRootLevel(ByVal Proj_id As Integer)
        Dim dt As New DataTable()
        Dim sql As String = ""
        sql = "select PActv_ID,Parent_PActv_Desc,Parent_Actv_Num,(select count(*) FROM Project_Activities " _
              & "WHERE PActv_Parent=PA.PActv_ID) childnodecount FROM Project_Activities PA where PActv_Parent = 0 and proj_proj_id = " & Proj_id _
              & " order by Parent_Actv_Num"
        dt = General_Helping.GetDataTable(sql)
        Nroot = True
        PopulateNodes(dt, TreeView1.Nodes)

    End Sub

    Private Sub PopulateSubLevel(ByVal parentid As Integer, ByVal parentNode As TreeNode)

        ' If General_Helping.OpenConnection() Then
        Dim dt As New DataTable()
        Dim sql As String = ""
        sql = "select PActv_ID,pactv_desc,PActv_Parent,Child_Actv_Num,(select count(*) FROM Project_Activities " _
            & "WHERE PActv_Parent=PA.PActv_ID) childnodecount FROM Project_Activities PA where PActv_Parent = " & parentid _
            & " order by PActv_Parent,Child_Actv_Num"
        dt = General_Helping.GetDataTable(sql)
        Nroot = False
        PopulateNodes(dt, parentNode.ChildNodes)
        'End If
    End Sub

    Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)

        If Nroot = True Then
            If dt.Rows.Count <> 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim tn As New TreeNode()
                    tn.Text = dr("Parent_PActv_Desc").ToString()
                    tn.Value = dr("PActv_ID").ToString()
                    nodes.Add(tn)

                    'If node has child nodes, then enable on-demand populating
                    tn.PopulateOnDemand = (CInt(dr("childnodecount")) > 0)
                Next
            Else
                TreeView1.Nodes.Clear()
            End If

        Else
            If dt.Rows.Count <> 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim tn As New TreeNode()
                    tn.Text = dr("pactv_desc").ToString()
                    tn.Value = dr("PActv_ID").ToString()
                    nodes.Add(tn)

                    'If node has child nodes, then enable on-demand populating
                    tn.PopulateOnDemand = (CInt(dr("childnodecount")) > 0)
                Next
            Else
                TreeView1.Nodes.Clear()
            End If
        End If
    End Sub

    Protected Sub TreeView1_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles TreeView1.TreeNodePopulate
        PopulateSubLevel(CInt(e.Node.Value), e.Node)
    End Sub


#End Region

End Class
