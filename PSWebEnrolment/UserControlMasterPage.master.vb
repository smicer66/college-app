Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class UserControlMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        LoadLinks()


        'navbar
        If WorkingData.ShoppingCart.Items.Count > 0 Then
            If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                navenrols.Visible = True
                navapps.Visible = False
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                navenrols.Visible = False
                navapps.Visible = True
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                navenrols.Visible = True
                navapps.Visible = False
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
                navenrols.Visible = False
                navapps.Visible = False
            End If
        Else
            navenrols.Visible = True
            navapps.Visible = False
            'If (Me.Page.Request("OfferingID") Is Nothing) Then
            '    Response.Redirect("http://www.cityofbristol.ac.uk/courses")
            'End If
        End If

        If WorkingData.Provider.GetType Is GetType(SessionWorkingDataProvider) Then
            If Not WorkingData.CurrentLoggedOnUserRow Is Nothing Then
                regLinks.Visible = False
                regLoggedIn.Visible = True
                username.InnerText = "Logged in as: " & WorkingData.CurrentLoggedOnUserRow.Email
            Else
                username.Visible = False
                regLinks.Visible = True
                regLoggedIn.Visible = False
            End If
        Else
            If System.Web.HttpContext.Current.User.Identity.IsAuthenticated Then
                username.InnerText = "Logged in as: " & HttpContext.Current.User.Identity.Name
                regLinks.Visible = False
                regLoggedIn.Visible = True
                lnkLogout.Visible = True
            Else
                username.Visible = False
                regLinks.Visible = True
                regLoggedIn.Visible = False
            End If
        End If


    End Sub
    Protected Overrides Sub OnPreRender(e As EventArgs)
        MyBase.OnPreRender(e)
        If WorkingData.Provider.GetType Is GetType(SessionWorkingDataProvider) Then
            lnkRegister.NavigateUrl = "webenrolment.aspx?page=~/account/ccc/Register.ascx"
            lnkLogin.NavigateUrl = "webenrolment.aspx?page=~/account/ccc/Login.ascx"
            lnkLogout.NavigateUrl = "webenrolment.aspx?page=~/account/ccc/Logout.ascx"
            lnkAccount.Visible = True
        Else
            lnkRegister.NavigateUrl = "account/aspnetdb/Register.aspx"
            lnkLogin.NavigateUrl = "account/aspnetdb/Login.aspx"
            lnkLogout.NavigateUrl = "account/aspnetdb/Logout.aspx"
            lnkAccount.Visible = False
        End If
    End Sub


    Private Sub LoadLinks()

        Dim htmlHeader As HtmlHead = CType(Page.Master.FindControl("header"), HtmlHead)

        Dim css As New HtmlGenericControl()
        css.TagName = "link"
        css.Attributes.Add("rel", "stylesheet")
        css.Attributes.Add("type", "text/css")
        css.Attributes("href") = ResolveUrl("~/_css/bootstrap-glyphicons.css")
        htmlHeader.Controls.Add(css)

        Dim css2 As New HtmlGenericControl()
        css2.TagName = "link"
        css2.Attributes.Add("rel", "stylesheet")
        css2.Attributes.Add("type", "text/css")
        css2.Attributes("href") = ResolveUrl("~/_css/bootstrap.min.css")
        htmlHeader.Controls.Add(css2)

        Dim css3 As New HtmlGenericControl()
        css3.TagName = "link"
        css3.Attributes.Add("rel", "stylesheet")
        css3.Attributes.Add("type", "text/css")
        css3.Attributes("href") = ResolveUrl("~/_css/custom.css")
        htmlHeader.Controls.Add(css3)

        Dim js1 As New HtmlGenericControl("script")
        js1.Attributes("type") = "text/javascript"
        js1.Attributes("src") = ResolveUrl("~/js/jquery.js")
        htmlHeader.Controls.Add(js1)

        Dim js2 As New HtmlGenericControl("script")
        js2.Attributes("type") = "text/javascript"
        js2.Attributes("src") = ResolveUrl("~/js/respond.min.js")
        htmlHeader.Controls.Add(js2)

        Dim js3 As New HtmlGenericControl("script")
        js3.Attributes("type") = "text/javascript"
        js3.Attributes("src") = ResolveUrl("~/js/html5shiv.js")
        htmlHeader.Controls.Add(js3)

        Dim js4 As New HtmlGenericControl("script")
        js4.Attributes("type") = "text/javascript"
        js4.Attributes("src") = ResolveUrl("~/js/custom.js")
        htmlHeader.Controls.Add(js4)

        Dim js5 As New HtmlGenericControl("script")
        js5.Attributes("type") = "text/javascript"
        js5.Attributes("src") = ResolveUrl("~/js/bootstrap.min.js")
        htmlHeader.Controls.Add(js5)

        Dim js6 As New HtmlGenericControl("script")
        js6.Attributes("type") = "text/javascript"
        js6.Attributes("src") = ResolveUrl("~/js/header-search.js")
        htmlHeader.Controls.Add(js6)

        Dim js7 As New HtmlGenericControl("script")
        js7.Attributes("type") = "text/javascript"
        js7.Attributes("src") = ResolveUrl("~/js/mobile-menu.js")
        htmlHeader.Controls.Add(js7)

    End Sub
End Class

