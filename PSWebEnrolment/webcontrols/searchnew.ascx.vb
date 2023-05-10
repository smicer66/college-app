Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports System.Reflection

Partial Class webcontrols_searchnew
    Inherits webenrolmentcontrolvalidate

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        If Not IsPostBack Then

            PopulateDropDownLists()

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadGridData()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        'Clear search values first...
        Me.txtKeywords.Text = ""
        cboCollegeLevel.SelectedValue = Nothing
        cboSite.SelectedValue = Nothing
        'Then load grid
        LoadGridData()
    End Sub

    Dim m_CoursesInBasket As System.Collections.Generic.List(Of Integer)

    'These properties will hode/show the example extra search fields
    Private ShowSite As Boolean = False
    Private ShowCollegeLevel As Boolean = False

    Private Sub PopulateDropDownLists()
        'Populate drop down lists etc.
        '... or alteratvively hide the saerch fields that aren't being used

        If ShowSite Then
            cboSite.Items.Add(New WebControls.ListItem("All", ""))
            Dim strExcludedSiteIDs = ""
            'NOTE: PopulateListWithDescriptionColumns is a v simple way of using CCCListControlLibrary
            CCCListControlLibrary.PopulateListWithDescriptionColumns(New SiteDataTable, cboSite, True, strExcludedSiteIDs)
        Else
            SearchAreaForSite.Visible = False
        End If

        If ShowCollegeLevel Then
            'NOTE: PopulateList with more flexible options on creating the lookup using the CCCListControlLibrary
            Dim t = New CollegeLevelDataTable
            Dim v = CCCDataViewDataSet.CreateDataViewDefault(t)
            v.Filters.SetColumnFilter(t.SIDColumn, 0, FilterOperator.OperatorNotEquals)  'Don't include "0, -----" (top level college level) by default
            'v.Filters.SetColumnFilter(t.DescriptionColumn, "a*", FilterOperator.OperatorNotLike)  'This example makes it only show CollegeLvels that don't start aith "a" (Or "A")
            'v.Filters.SetColumnFilter(t.IsAvailableForOfferingsColumn, True)  'This example filters on the CollegeLevel being available for assigning to offerings
            Dim l = New CCCLookup(t, v)
            CCCListControlLibrary.PopulateList(l, cboCollegeLevel, True)
        Else
            SearchAreaForCollegeLevel.Visible = False
        End If

    End Sub

#Region " Grid "

    Sub LoadGridData()

        Dim t As New CourseInformationDataTable

        Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataViewDefault(t)
        v.Columns.Clear()
        v.Columns.AddPKColumns()
        v.Columns.EnsureColumnsAreSelected(True, False, t.DescriptionColumn, t.AcademicYearIDColumn, t.WebsiteAvailabilityIDColumn)
        v.Filters.SetColumnFilter(t.ObsoleteColumn, False)
        v.Filters.SetColumnFilter(t.WebsiteAvailabilityIDColumn, 0, FilterOperator.OperatorNotEquals)
        v.SortOrders.Clear()
        v.SortOrders.SetColumnSortOrder(SortDirection.Ascending, t.DescriptionColumn)

        'Add Search
        Dim SearchText = Me.txtKeywords.Text
        Dim ColumnsToSearch = {t.DescriptionColumn}
        v.Filters.AddSearchColumns(ColumnsToSearch, SearchText)

        'Add filters as well (search will only return results above the data rows that matches these filters)
        If Not CCCBlankLibrary.IsBlank(cboCollegeLevel.SelectedValue) Then
            v.Filters.SetColumnFilter(t.SIDColumn, cboCollegeLevel.SelectedValue)
        End If
        'NOTE: this Option same as above but using SID (CollegeLevel) in [Offering] rather than in the [CourseInformation] table
        'If Not CCCBlankLibrary.IsBlank(cboCollegeLevel.SelectedValue) Then
        '    Dim str = "EXISTS(SELECT * FROM Offering O WHERE O.CourseInformationID = CourseInformation.CourseInformationID " &
        '        "AND O.SID = " & cboCollegeLevel.SelectedValue &
        '        ")"
        '    v.Filters.AddRow(str)
        'End If

        'removed AA 13-jul-2022 for tollkit patch https://customers.oneadvanced.com/s/article/Important-Security-Vulnerability-Notification-ProSolution-Web-Enrolment-Toolkit-v21-1-to-v22-2
        'If Not CCCBlankLibrary.IsBlank(cboSite.SelectedValue) Then
        '    Dim str = "EXISTS(SELECT * FROM Offering O WHERE O.CourseInformationID = CourseInformation.CourseInformationID " &
        '        "AND O.SiteID = " & cboSite.SelectedValue &
        '        ")"
        '    v.Filters.AddRow(str)
        'End If

        Dim writer As DataAccess.CCCSQLLanguageWriter = CCCObjectFactory.CreateObject(Of DataAccess.CCCSQLLanguageWriter)() 'Create SQL language writer for SanitiseSQLValueString
        If Not CCCBlankLibrary.IsBlank(cboSite.SelectedValue) Then
            Dim str = "EXISTS(SELECT * FROM Offering O WHERE O.CourseInformationID = CourseInformation.CourseInformationID " &
        "AND O.SiteID = " & writer.SQLLanguageFormatter.SanitiseSQLValueString(cboSite.SelectedValue, False) &
        ")"
            v.Filters.AddRow(str)
        End If

        'If Not CCCBlankLibrary.IsBlank(cboModeOfAttendance.SelectedValue) Then
        '    Dim str = "EXISTS(SELECT * FROM Offering O WHERE O.CourseInformationID = CourseInformation.CourseInformationID " &
        '"AND O.ModeOfAttendanceID = '" & writer.SQLLanguageFormatter.SanitiseSQLValueString(cboModeOfAttendance.SelectedValue, False) & "')"
        '    v.Filters.AddRow(str)
        'End If

        'If Not CCCBlankLibrary.IsBlank(objMarketingFields.MarketingField1) AndAlso objMarketingFields.MarketingField1 <> "All" Then
        '    Dim str = "EXISTS(SELECT * FROM CourseInformationText CT WHERE CT.CourseInformationID = CourseInformation.CourseInformationID " &
        '"AND CT.InformationText LIKE '%" & writer.SQLLanguageFormatter.SanitiseSQLValueString(objMarketingFields.MarketingField1, False) & "%'" &
        '"AND CT.CourseInformationTypeID = " & objMarketingFields.MarketingField1CourseInformationTypeID & ")"
        '    v.Filters.AddRow(str)
        'End If

        'If Not CCCBlankLibrary.IsBlank(objMarketingFields.MarketingField2) AndAlso objMarketingFields.MarketingField2 <> "All" Then
        '    Dim str = "EXISTS(SELECT * FROM CourseInformationText CT WHERE CT.CourseInformationID = CourseInformation.CourseInformationID " &
        '"AND CT.InformationText LIKE '%" & writer.SQLLanguageFormatter.SanitiseSQLValueString(objMarketingFields.MarketingField2, False) & "%'" &
        '"AND CT.CourseInformationTypeID = " & objMarketingFields.MarketingField2CourseInformationTypeID & ")"
        '    v.Filters.AddRow(str)
        'End If
        'If Not CCCBlankLibrary.IsBlank(objMarketingFields.MarketingField3) AndAlso objMarketingFields.MarketingField3 <> "All" Then
        '    Dim str = "EXISTS(SELECT * FROM CourseInformationText CT WHERE CT.CourseInformationID = CourseInformation.CourseInformationID " &
        '"AND CT.InformationText LIKE '%" & writer.SQLLanguageFormatter.SanitiseSQLValueString(objMarketingFields.MarketingField3, False) & "%'" &
        '"AND CT.CourseInformationTypeID = " & objMarketingFields.MarketingField3CourseInformationTypeID & ")"
        '    v.Filters.AddRow(str)
        'End If

        t.TableAdapter.Load(t, v)

        SearchGrid.DataSource = t

        m_CoursesInBasket = New System.Collections.Generic.List(Of Integer)
        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
            m_CoursesInBasket.Add(item.CourseInfoID)
        Next

        SearchGrid.DataBind()

    End Sub

    Private Sub m_Grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles SearchGrid.ItemDataBound#
        Dim item As ListViewItem = e.Item
        ' Verify if the item is a data item.
        If item.ItemType = ListViewItemType.DataItem Then
            Dim rowView As System.Data.DataRowView
            rowView = CType(e.Item, System.Web.UI.WebControls.ListViewDataItem).DataItem
            Dim img As HyperLink = e.Item.FindControl("ApplyOrEnrolmentBtn")
            SetWebSiteAvailabilityIcon(img, rowView)

            If rowView.Row.Table.Columns.Contains("_SearchScore") Then
                Dim lbl As Label = e.Item.FindControl("lblScore")
                FormatScore(lbl, rowView)
            End If
        End If
    End Sub

    Dim m_blnPageChanged As Boolean = False
    Private Sub m_Grid_PagePropertiesChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchGrid.PagePropertiesChanged
        LoadGridData()
        m_blnPageChanged = True
    End Sub

    Private Sub m_DataPager_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpSearchGrid.PreRender
        If ViewState("Searched") = True AndAlso Not m_blnPageChanged Then
            dpSearchGrid.SetPageProperties(0, dpSearchGrid.MaximumRows, True)
        End If
    End Sub

    Private Sub FormatScore(ByVal lblScore As Label, ByVal rowView As System.Data.DataRowView)
        Dim dataValue As String = rowView("_SearchScore").ToString
        lblScore.Text = CInt(dataValue).ToString & "%"
    End Sub

    Private Sub SetWebSiteAvailabilityIcon(ByVal img As HyperLink, ByVal rowView As System.Data.DataRowView)
        Dim dataValue As String = rowView("WebSiteAvailabilityID").ToString
        Dim intCourseInfoID As Integer = CInt(rowView("CourseInformationID"))
        Dim imageURL As String = String.Empty
        Dim imageText As String = String.Empty
        Dim NavigateUrl As String = String.Empty

        If m_CoursesInBasket.Contains(intCourseInfoID) Then
            imageText = "Course already in basket"
            imageURL = GetResourceValue("basketsmall")
            NavigateUrl = GetResourceValue("checkout_aspx")
        ElseIf CCCBlankLibrary.IsBlank(dataValue) Then
            imageURL = GetResourceValue("icon_noofferings")
            NavigateUrl = GetResourceValue("courseunavailable_aspx")
        Else
            Dim Availability As Byte = CType(dataValue, Byte)
            Dim row As WebSiteAvailabilityRow = WebSiteAvailabilityTable.FindByWebSiteAvailabilityID(Availability)
            If row IsNot Nothing Then
                imageText = row.Description
                If Len(row.IconFileName) = 0 Then
                    imageURL = GetResourceValue("gap")
                Else
                    imageURL = GetResourceValue(Replace(row.IconFileName, ".png", ""))
                End If
                NavigateUrl = GetResourceValue("coursedisplay_aspx") & IIf(GetResourceValue("coursedisplay_aspx").Contains("?"), "&", "?").ToString & "CourseInformationID=" & intCourseInfoID.ToString
            Else
                imageURL = GetResourceValue("icon_noofferings")
                NavigateUrl = GetResourceValue("courseunavailable_aspx")
            End If

        End If

        img.Text = imageText
        img.ImageUrl = imageURL
        img.NavigateUrl = NavigateUrl
    End Sub

    Private m_tblWebSiteAvailability As WebSiteAvailabilityDataTable
    Private Property WebSiteAvailabilityTable() As WebSiteAvailabilityDataTable
        Get
            If m_tblWebSiteAvailability Is Nothing Then
                m_tblWebSiteAvailability = New WebSiteAvailabilityDataTable
                Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(m_tblWebSiteAvailability)
                v.Columns.AddAllColumns(False, False)
                m_tblWebSiteAvailability.TableAdapter.Load(m_tblWebSiteAvailability, v)
            End If
            Return m_tblWebSiteAvailability
        End Get
        Set(ByVal value As WebSiteAvailabilityDataTable)
            m_tblWebSiteAvailability = value
        End Set
    End Property

#End Region

End Class
