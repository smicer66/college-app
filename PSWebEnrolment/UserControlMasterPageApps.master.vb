Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class UserControlMasterPage
    Inherits System.Web.UI.MasterPage
    Implements IHttpModule
    Public Overrides Sub Dispose()



    End Sub

    Public Shadows Sub Init(context As HttpApplication)
        AddHandler context.BeginRequest, New EventHandler(AddressOf context_BeginRequest)
    End Sub


    Private Sub context_BeginRequest(sender As Object, e As EventArgs)

        Dim currentContext As HttpContext = TryCast(sender, HttpApplication).Context
        If (currentContext.Request.Url.ToString().Contains("OfferingID") _
                    Or currentContext.Request.Url.ToString().Contains("Offering1ID") _
                    Or currentContext.Request.Url.ToString().Contains("Offering2ID") _
                    Or currentContext.Request.Url.ToString().Contains("Offering3ID") _
                    Or currentContext.Request.Url.ToString().Contains("Offering4ID") _
                    Or currentContext.Request.Url.ToString().Contains("Offering5ID")) Then
            currentContext.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.ReadOnly)
        Else
            currentContext.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Default)
        End If

    End Sub

    Private Sub IHttpModule_Init(context As HttpApplication) Implements IHttpModule.Init
        Throw New NotImplementedException()
    End Sub

    Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose
        Throw New NotImplementedException()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' PutAllOfferingsInBasket()
        If Not IsPostBack Then
            PutAllOfferingsInBasket()
            'PopulateOfferingFeeTable()

            Dim i As Byte = 1
            For Each c As ShoppingCartItem In WorkingData.ShoppingCart.Items
                c.ChoiceNumber = i
                i = CByte(i + 1)
            Next
        End If

        LoadLinks()


        If WorkingData.Provider.GetType Is GetType(SessionWorkingDataProvider) Then
            If Not WorkingData.CurrentLoggedOnUserRow Is Nothing Then
                ' regLinks.Visible = False
                regLoggedIn.Visible = True
                username.InnerText = "Logged in as: " & WorkingData.CurrentLoggedOnUserRow.Email
            Else
                username.Visible = False
                'regLinks.Visible = True
                regLoggedIn.Visible = False
            End If
        Else
            If System.Web.HttpContext.Current.User.Identity.IsAuthenticated Then
                username.InnerText = "Logged in as: " & HttpContext.Current.User.Identity.Name
                ' regLinks.Visible = False
                regLoggedIn.Visible = True
                lnkLogout.Visible = True
            Else
                username.Visible = False
                ' regLinks.Visible = True
                regLoggedIn.Visible = False
            End If
        End If


    End Sub


    Public ReadOnly Property Id() As Integer
        Get
            '   Response.Write(Me.Page.Request("id"))
            If Not WorkingData.ApplicationRequestRow.WebApplicationID Is Nothing Then
                If WorkingData.ApplicationRequestRow.WebApplicationID > -1 Then
                    Return CInt(WorkingData.ApplicationRequestRow.WebApplicationID)
                Else
                    Return -1
                End If
            ElseIf CInt(Me.Page.Request("id")) > -1 Then
                Return CInt(Me.Page.Request("id"))
            ElseIf Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("id")) Then
                Return -1
            Else Return -1

            End If
        End Get

    End Property


    Protected Sub PutAllOfferingsInBasket()

        ' Response.Write(Id())
        Dim IntOffering1ID As Integer = 183791 ''generic app course code
        If IntOffering1ID <> -1 Then
            ''put the id into table, the id should be either enquiry id or booking id
            WorkingData.ApplicationRequestRow.PEBookingID = Id
            Dim tblOffering1 As New OfferingDataTable
            Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblOffering1)
            v.Columns.AddPKColumns()
            v.Columns.EnsureColumnsAreSelected(True, False, tblOffering1.WebSiteAvailabilityIDColumn, tblOffering1.CourseInformationIDColumn, tblOffering1.TotalFeeAmountColumn, tblOffering1.OfferingTypeIDColumn)
            v.Filters.SetColumnFilter(tblOffering1.OfferingIDColumn, IntOffering1ID)
            tblOffering1.TableAdapter.Load(tblOffering1, v)
            If tblOffering1.Count > 0 AndAlso tblOffering1(0).WebSiteAvailabilityID.HasValue Then
                Dim item As New ShoppingCartItem()
                With tblOffering1(0)
                    'Dim CourseOfferingFees As New CourseOfferingFees(CType(.OfferingID, Integer))
                    If .TotalFeeAmount.HasValue Then
                        item.Cost = 0
                    End If

                    item.Description = .GetRowDescription
                    item.ItemType = "Application"
                    item.OfferingID = .OfferingID.Value
                    item.CourseInfoID = .CourseInformationID.GetValueOrDefault
                End With
                With WorkingData.ShoppingCart
                    If Not .Items.Contains(item) Then
                        .Items.Add(item)
                    End If
                End With
            End If
        End If

    End Sub

    Protected Overrides Sub OnPreRender(e As EventArgs)
        MyBase.OnPreRender(e)
        If WorkingData.Provider.GetType Is GetType(SessionWorkingDataProvider) Then
            ' lnkRegister.NavigateUrl = "webenrolment.aspx?page=~/account/ccc/Register.ascx"
            ' lnkLogin.NavigateUrl = "webenrolment.aspx?page=~/account/ccc/Login.ascx"
            lnkLogout.NavigateUrl = "webenrolment.aspx?page=~/account/ccc/Logout.ascx"
            'lnkAccount.Visible = True
        Else
            'lnkRegister.NavigateUrl = "account/aspnetdb/Register.aspx"
            'lnkLogin.NavigateUrl = "account/aspnetdb/Login.aspx"
            lnkLogout.NavigateUrl = "account/aspnetdb/Logout.aspx"

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

        Dim css8 As New HtmlGenericSelfClosing()
        css8.TagName = "link"
        css8.Attributes.Add("rel", "stylesheet")
        css8.Attributes.Add("type", "text/css")
        css8.Attributes("href") = ResolveUrl("~/_css/jquery-ui.min.css")
        htmlHeader.Controls.Add(css8)

        Dim css3 As New HtmlGenericControl()
        css3.TagName = "link"
        css3.Attributes.Add("rel", "stylesheet")
        css3.Attributes.Add("type", "text/css")
        css3.Attributes("href") = ResolveUrl("~/_css/custom.css")
        htmlHeader.Controls.Add(css3)

        Dim js01 As New HtmlGenericControl("script")
        js01.Attributes("type") = "text/javascript"
        js01.Attributes("src") = ResolveUrl("https://unpkg.com/@popperjs/core@2.4.4/dist/umd/popper.min.js")
        htmlHeader.Controls.Add(js01)

        Dim js00 As New HtmlGenericControl("script")
        js00.Attributes("type") = "text/javascript"
        js00.Attributes("src") = ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js")
        htmlHeader.Controls.Add(js00)

        Dim js0 As New HtmlGenericControl("script")
        js0.Attributes("type") = "text/javascript"
        js0.Attributes("src") = ResolveUrl("~/js/jquery-1.9.1.min.js")
        htmlHeader.Controls.Add(js0)

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

        Dim js9 As New HtmlGenericControl("script")
        js9.Attributes("type") = "text/javascript"
        js9.Attributes("src") = ResolveUrl("~/js/jquery-ui.min.js")
        htmlHeader.Controls.Add(js9)

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

