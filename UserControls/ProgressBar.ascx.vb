Partial Public Class ProgressBar
    Inherits System.Web.UI.UserControl
    Dim Percentvalue As Integer
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.

        InitializeComponent()
    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SetProgress(Percentvalue, 100)
    End Sub

    Public Sub SetProgress(ByVal current As Integer, ByVal max As Integer)
        Dim percent As String = Double.Parse(Percentvalue * 100 / max).ToString("0")

        If Percentvalue > 0 And Percentvalue <= 100 Then
            If percent.Equals("100") Then
                'lblPrcent.Text = "تم" 51b911
                lblPrcent.ForeColor = Drawing.Color.Green
                lblPrcent.Text = percent + "%"
                lblProgress.Text = lblProgress.Text & _
                    "<TABLE cellspacing=0 cellpadding=0 border=1 width=50><TR><TD bgcolor=#51b911 width=100%>&nbsp;</TD></TR></TABLE>"
            Else
                lblPrcent.Text = percent + "%"
                lblProgress.Text = lblProgress.Text & _
                    "<TABLE cellspacing=0 cellpadding=0 border=1 width=50><TR><TD bgcolor=#FFF7CE>&nbsp;</TD><TD bgcolor=#000066 width=" + _
                    percent.ToString() + _
                    "%>&nbsp;</TD></TR></TABLE>"
            End If

            If Integer.Parse(percent) < 1 Then
                'only start showing at 1%
                lblProgress.Visible = False
            Else
                lblProgress.Visible = True
            End If
        Else
            lblProgress.Visible = False
            lblProgress.Text = "النسبه لابد ان تكون بين 0 و 100"
        End If
    End Sub

    Public Property MainValue()
        Get
            Return Percentvalue
        End Get
        Set(ByVal value)
            Percentvalue = CDataConverter.ConvertToInt(value)
        End Set
    End Property





End Class
