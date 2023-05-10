Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

'This page is used to load the web pages that have been converted to ascx user controls.
'The user controls are located in the webcontrols folder of the website
'The user control path to the user control that is to be loaded in added to the page request.
Partial Class webcontrols_webenrolment
    Inherits System.Web.UI.Page

    Dim WithEvents cntl As webenrolmentcontrolvalidate

    Protected Sub webcontrols_webenrolment_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        Dim strWebControlurl As String = ResolveUrl(Me.Request("page"))
        cntl = TryCast(Page.LoadControl(strWebControlurl), webenrolmentcontrolvalidate)
        ''cntl.BreadcrumbHolder.PushBreadcrumb(New CCCBreadcrumb("", GetFriendlyNameForControl(strWebControlurl), ResolveUrl(Me.Request("page")), ""))
        PlaceHolder1.Controls.Add(cntl)
    End Sub

    Public Overrides Sub Validate()
        MyBase.Validate()
        If cntl IsNot Nothing Then cntl.ValidateControl()
    End Sub

    ''Private Function GetFriendlyNameForControl(s As String) As String
    ''    Dim name As String = ""
    ''    Dim i As Integer = s.LastIndexOf("/")
    ''    name = s.Substring(i + 1, s.IndexOf(".ascx", i + 1) - i - 1)
    ''    name = name.Replace("_", " ")
    ''    name = name.Replace("checkout", "")
    ''    name = StrConv(name, VbStrConv.ProperCase)
    ''    Return name
    ''End Function
End Class
