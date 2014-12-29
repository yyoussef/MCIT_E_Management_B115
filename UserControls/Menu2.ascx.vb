Partial Public Class UserControls_Menu2
    Inherits System.Web.UI.UserControl
    Dim Session_CS As New Session_CS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String = _
         "<a href=""http://www.dhtml-menu-builder.com""  style=""display:none;visibility:hidden;"">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a>" + vbCrLf + _
         "<script type=""text/javascript"">" + vbCrLf + _
         "<!--" + vbCrLf + _
         "stm_bm([""menu1b73"",900,"""",""blank.gif"",0,"""","""",1,0,250,0,1000,1,0,0,"""",""100%"",0,1,1,2,""default"",""hand"","""",1,25],this);" + vbCrLf + _
         "stm_bp(""p0"",[0,4,0,0,0,7,5,7,100,"""",-2,"""",-2,50,0,0,""#999999"",""transparent"",""bg_01.gif"",3,1,1,""#000000""]);" + vbCrLf + _
         "stm_ai(""p0i0"",[0,""حركة سداد الكمبيالات"","""","""",-1,-1,0,"""",""_self"","""","""","""","""",5,5,0,"""","""",0,0,0,1,1,""#FFFFF7"",1,""#993333"",1,"""",""bg_02.gif"",3,1,0,0,""#FFFFF7"",""#000000"",""#FFFFFF"",""#FFFFFF"",""bold 13pt Arial"",""bold 13pt Arial"",0,0,"""","""","""","""",0,0,0]);" + vbCrLf + _
         "stm_aix(""p0i1"",""p0i0"",[0,""البيع الآجل""]);" + vbCrLf + _
         "stm_aix(""p0i2"",""p0i0"",[0,""البيع النقدي""]);" + vbCrLf + _
         "stm_aix(""p0i3"",""p0i0"",[0,""حركة سداد الشراء""]);" + vbCrLf + _
         "stm_aix(""p0i4"",""p0i0"",[0,""الشراء الآجل""]);" + vbCrLf + _
         "stm_aix(""p0i5"",""p0i0"",[0,""الشراء النقدي""]);" + vbCrLf + _
         "stm_aix(""p0i6"",""p0i0"",[0,""البيانات المخزنية""]);" + vbCrLf + _
         "stm_aix(""p0i7"",""p0i0"",[0,""الأكواد"","""","""",-1,-1,0,"""",""_self"","""","""","""","""",5,5,0,""arrow_r.gif"",""arrow_r.gif"",7,7]);" + vbCrLf + _
         "stm_bpx(""p1"",""p0"",[1,4,0,0,0,7,5,0]);" + vbCrLf + _
         "stm_aix(""p1i0"",""p0i0"",[0,""التصنيفات  "","""","""",-1,-1,0,""../WebForms2/Category.aspx"",""_self"","""","""","""","""",5,5,0,"""","""",0,0,0,0]);" + vbCrLf + _
         "stm_aix(""p1i1"",""p1i0"",[0,""المقاســـات"","""","""",-1,-1,0,""""]);" + vbCrLf + _
         "stm_aix(""p1i2"",""p1i1"",[0,""الأصنــــاف""]);" + vbCrLf + _
         "stm_aix(""p1i3"",""p1i1"",[0,""المورديـــن""]);" + vbCrLf + _
         "stm_aix(""p1i4"",""p1i1"",[0,""العمــــــــلاء""]);" + vbCrLf + _
         "stm_ep();" + vbCrLf + _
         "stm_ep();" + vbCrLf + _
         "stm_em();" + vbCrLf + _
         "//-->" + vbCrLf + _
         "</script>"



        If Not IsPostBack Then
            If Session_CS.UROL_UROL_ID = 3 Then
                SingleDiv.Visible = True
                MainDiv.Visible = False
            ElseIf Session_CS.UROL_UROL_ID = 4 Then
                SingleDiv.Visible = False
                MainDiv.Visible = True
            End If
        End If
    End Sub

End Class