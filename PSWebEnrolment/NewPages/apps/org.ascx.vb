Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class orgs
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        If IsPostBack Then
            UpdateAddress()
        Else
            postcode.Value = WorkingData.EnrolmentRequestRow.PostcodeOut + WorkingData.EnrolmentRequestRow.PostcodeIn

            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined19 <> "" Then ddlCategory1.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined19
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined18 <> "" Then ddlCategory2.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined18
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17 <> "" Then ddlInsure.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17
            PutAllOfferingsInBasket()
            If oID > -1 Then WorkingData.EnrolmentRequestRow.EmployerID = oID
            If cID > -1 Then WorkingData.EnrolmentRequestRow.Contact1RelationshipID = cID
            If pID > -1 Then WorkingData.EnrolmentRequestRow.Contact2RelationshipID = pID


        End If
    End Sub


    Private ReadOnly Property AFD_SERVER As String
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("AFDPEServer")
        End Get
    End Property

    Private ReadOnly Property AFD_SERIAL_NUMBER As String
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("AFDPESerialNumber")
        End Get
    End Property

    Private ReadOnly Property AFD_PASSWORD As String
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("AFDPEPassword")
        End Get
    End Property

    Private ReadOnly Property AFD_USER_ID As String
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("AFDPEUserID")
        End Get
    End Property

    Private Enum SearchType
        FastFind
        Search
        Retrieve
    End Enum


    Private Sub UpdateAddress()

        ' Declare XML Objects and variables
        Dim xmlDoc As System.Xml.XmlDocument
        Dim root As System.Xml.XmlNode
        Dim dataNode As System.Xml.XmlNode
        Dim itemNodes As System.Xml.XmlNodeList
        Dim lstStr As String
        Dim xmlLocation As String

        ' Create the XML Document Object Instance
        xmlDoc = New System.Xml.XmlDocument()

        ' Build up the XML query string
        xmlLocation = BuildServerDetails(SearchType.Retrieve)

        ' Replace lstResult with the name of your list box for the results
        With lstresult

            If lstresult.Items.Count = 0 Then
                Exit Sub
            Else
                ' Check a valid item is selected
                If .SelectedIndex < 0 Then
                    Dim v As New CustomValidator
                    v.ErrorMessage = "Please select an item from the list."

                    v.IsValid = False
                    Me.Page.Validators.Add(v)

                    Exit Sub
                End If
            End If
            'Response.Write(.SelectedIndex)
            ' Set XML parameter to retrieve the selected record
            lstStr = .Items.Item(.SelectedIndex).ToString

            xmlLocation = xmlLocation + "&Key=" + lstStr.Substring(lstStr.Length - 40, 40).Trim

            ' Finished with the list box
        End With

        ' Load the XML from the webserver with the query string
        Try

            xmlDoc.Load(xmlLocation)

        Catch
            Dim v As New CustomValidator
            v.ErrorMessage = "Error loading address results, please enter address manually"
            v.IsValid = False
            Me.Page.Validators.Add(v)

            Exit Sub

        End Try

        ' Check if PCE returned an error and if the document is valid
        root = xmlDoc.DocumentElement
        dataNode = root.SelectSingleNode("Result")
        itemNodes = root.SelectNodes("Item")
        If dataNode Is Nothing Or itemNodes Is Nothing Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Error loading address results, please enter address manually"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Exit Sub
        End If
        If Val(dataNode.InnerText) < 1 Then
            dataNode = root.SelectSingleNode("ErrorText")
            If dataNode Is Nothing Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            Else
                Dim v As New CustomValidator
                v.ErrorMessage = dataNode.InnerText & vbCrLf & "Please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)

            End If
            Exit Sub
        End If


        Dim strProperty As String = String.Empty

        dataNode = itemNodes(0).SelectSingleNode("Property")
        If Not (dataNode Is Nothing) Then strProperty = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Street")
        If Not (dataNode Is Nothing) Then
            If Not CCCBlankLibrary.IsBlank(strProperty) Then
                txtAddress1.Value = String.Format("{0}, {1}", strProperty, dataNode.InnerText)
            Else
                txtAddress1.Value = dataNode.InnerText
            End If
        End If

        dataNode = itemNodes(0).SelectSingleNode("Locality")
        If Not (dataNode Is Nothing) Then txtAddress2.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Town")
        If Not (dataNode Is Nothing) Then txtAddress3.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("PostalCounty")
        If Not (dataNode Is Nothing) Then txtAddress4.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Postcode")
        If Not (dataNode Is Nothing) Then
            'txtpostcodeout.Value = Trim(dataNode.InnerText.Substring(0, InStr(1, dataNode.InnerText, " ")))
            'txtpostcodein.Value = Trim(Mid(dataNode.InnerText, InStr(1, dataNode.InnerText, " ") + 1))
            If Not (dataNode Is Nothing) Then
                postcode.Value = dataNode.InnerText
                divAddresslines.Visible = True
            End If
        End If

    End Sub
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        If txtLookup.Text = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter a search term."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Exit Sub
        End If
        ' Declare XML Objects and variables
        Dim xmlDoc As System.Xml.XmlDocument
        Dim xmlLocation As String

        ' Create the XML Document Object Instance
        xmlDoc = New System.Xml.XmlDocument()

        ' Replace lstResult with the name of your list box for the results
        If lstresult.Items.Count > 0 Then divlstResult.Visible = True
        With lstresult

            ' Clear out any existing items in the list
            .Items.Clear()

            ' Build up the XML query string
            xmlLocation = BuildServerDetails(SearchType.FastFind)

            ' Set the Country Name or ISO code for International operations
            xmlLocation = xmlLocation + "&Country=UK"

            ' Set the lookup string
            xmlLocation = xmlLocation + "&Lookup=" + txtLookup.Text ' Change txtLookup to your lookup entry textbox

            ' Load the XML from the webserver with the query string
            Try
                xmlDoc.Load(xmlLocation)
            Catch
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Exit Sub
            End Try

            GetSearchResults(xmlDoc, btnFind)

        End With


    End Sub

    Private Sub GetSearchResults(xmlDoc As System.Xml.XmlDocument, btnButton As Button)
        Dim root As System.Xml.XmlNode
        Dim pcFromNode As System.Xml.XmlNode
        Dim dataNode As System.Xml.XmlNode
        Dim itemNodes As System.Xml.XmlNodeList
        Dim listNode As System.Xml.XmlNode
        Dim keyNode As System.Xml.XmlNode
        With lstresult
            ' Check if PCE returned an error and if the document is valid
            root = xmlDoc.DocumentElement
            dataNode = root.SelectSingleNode("Result")
            itemNodes = root.SelectNodes("Item")
            If dataNode Is Nothing Or itemNodes Is Nothing Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Exit Sub
            End If
            If Val(dataNode.InnerText) < 1 Then
                dataNode = root.SelectSingleNode("ErrorText")
                If dataNode Is Nothing Then
                    Dim v As New CustomValidator
                    v.ErrorMessage = "Error loading address results, please enter address manually"
                    v.IsValid = False
                    Me.Page.Validators.Add(v)
                Else
                    Dim v As New CustomValidator
                    v.ErrorMessage = dataNode.InnerText & vbCrLf & "Please enter address manually"
                    v.IsValid = False
                    Me.Page.Validators.Add(v)
                End If
                Exit Sub
            End If

            ' Display any changed postcode if applicable
            pcFromNode = itemNodes(0).SelectSingleNode("PostcodeFrom")
            dataNode = itemNodes(0).SelectSingleNode("Postcode")
            If Not (pcFromNode Is Nothing) And Not (dataNode Is Nothing) Then
                If pcFromNode.InnerText <> "" Then
                    Dim v As New CustomValidator
                    v.ErrorMessage = "Postcode has changed from " + pcFromNode.InnerText + " to " + dataNode.InnerText
                    v.IsValid = True
                    Me.Page.Validators.Add(v)
                End If
            End If

            ' Now add matching records to the list box
            For Each dataNode In itemNodes
                ' Get the data nodes
                listNode = dataNode.SelectSingleNode("List")
                keyNode = dataNode.SelectSingleNode("Key")
                If Not (listNode Is Nothing) And Not (keyNode Is Nothing) Then
                    ' Add the item to the list box with hidden key
                    .Items.Add(listNode.InnerText + Space(512) + keyNode.InnerText)
                End If
            Next

            ' If .Items.Count() <> 0 Then .SelectedIndex = 0 ' Select First item in the list

        End With
    End Sub


    Private Function BuildServerDetails(ByVal Type As SearchType) As String
        Dim xmlLocation As String
        ' Build up the XML query string
        xmlLocation = AFD_SERVER + "/afddata.pce?"
        xmlLocation = xmlLocation + "Serial=" + AFD_SERIAL_NUMBER + "&"
        xmlLocation = xmlLocation + "Password=" + AFD_PASSWORD + "&"
        xmlLocation = xmlLocation + "UserID=" + AFD_USER_ID + "&"

        Select Case Type
            Case SearchType.FastFind
                xmlLocation = xmlLocation + "Data=Address&Task=FastFind&Fields=List"
            Case SearchType.Search
                xmlLocation = xmlLocation + "Data=Address&Task=Search&Fields=List"
            Case SearchType.Retrieve
                xmlLocation = xmlLocation + "Data=Address&Task=Retrieve&Fields=Standard"
            Case Else

        End Select

        ' Set the maximum number of records to return
        xmlLocation = xmlLocation + "&MaxQuantity=100"

        Return xmlLocation
    End Function

    Public Overrides Sub ValidateControl()

        If Len(txtAddress1.Value) = 0 Then
            Dim v As New CustomValidator
            v.ErrorMessage = "You must enter the 1st line of the address"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        If Len(postcode.Value) = 0 Then
            Dim v As New CustomValidator
            v.ErrorMessage = "You must enter the postcode"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        Dim regexPostCode As New Regex("^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$")
        Dim match As Match = regexPostCode.Match(postcode.Value)
        If Not match.Success Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter a valid Postcode"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        If WorkingData.EnrolmentRequestRow.MobileTel = "" And WorkingData.EnrolmentRequestRow.Tel = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter atleast one phone number (Home Telephone / Mobile number)."
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If ddlCategory1.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = " Please tell us you primary business sector"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If ddlInsure.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "  Please can you confirm you have in place suitable and sufficient insurance in respect to learners"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If ddlCompHouse.SelectedValue = "1" Then
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined45 = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = " You have stated you are registered with company house, please provide your Company Registration Number"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
        End If
        If chkConfirm.Checked = False Then

            Dim v As New CustomValidator
            v.ErrorMessage = " Please confirm you have read the above Privacy Notice and the information given in this form is correct and complete."
            v.IsValid = False
                Me.Page.Validators.Add(v)

        End If
    End Sub

    Public ReadOnly Property oID() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("o")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("o"))
            End If
        End Get
    End Property


    Public ReadOnly Property cID() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("c")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("c"))
            End If
        End Get
    End Property


    Public ReadOnly Property pID() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("p")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("p"))
            End If
        End Get
    End Property



    'Private Sub btnStage1_Click(sender As Object, e As EventArgs) Handles btnStage1.Click
    '    Response.Redirect(GetResourceValue("checkout_evidence_aspx"))
    'End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        If ddlCategory1.SelectedValue <> "" Then WorkingData.EnrolmentRequestRow.StudentDetailUserDefined19 = ddlCategory1.SelectedValue
        If ddlCategory2.SelectedValue <> "" Then WorkingData.EnrolmentRequestRow.StudentDetailUserDefined18 = ddlCategory2.SelectedValue
        If ddlInsure.SelectedValue <> "" Then WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17 = ddlInsure.SelectedValue
        WorkingData.EnrolmentRequestRow.GDPRAllowContactByEmail = True
        If Me.Page.IsValid Then

            Dim pcode As String = Replace(postcode.Value, " ", "")
            If Len(pcode) > 0 Then

                'avoid dodgy postcodes breaking system
                Try
                    WorkingData.EnrolmentRequestRow.PostcodeOut = pcode.Substring(0, pcode.Length - 3)
                Catch ex As ArgumentOutOfRangeException
                    WorkingData.EnrolmentRequestRow.PostcodeOut = ""
                End Try

                Try
                    WorkingData.EnrolmentRequestRow.PostcodeIn = Right(pcode, 3)
                Catch ex As ArgumentOutOfRangeException
                    WorkingData.EnrolmentRequestRow.PostcodeIn = ""
                End Try
            End If
            ''defaults
            WorkingData.EnrolmentRequestRow.RequestStatus = "organisation"
            WorkingData.EnrolmentRequestRow.OfferingID = 186247
            WorkingData.EnrolmentRequestRow.DateOfBirth = "01-Jan-2021"
            CCCPageLibrary.NavigateToPage(GetResourceValue("checkout_makepayment_aspx"))

        End If



    End Sub


    Protected Sub PutAllOfferingsInBasket()


        Dim IntOffering1ID As Integer = 186247
        If IntOffering1ID <> -1 Then
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
End Class
