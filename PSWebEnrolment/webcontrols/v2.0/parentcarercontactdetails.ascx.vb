'Option Explicit On
'Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
'Imports DocuSign.eSign.Model
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class parentcarercontactdetails
    Inherits CheckoutBaseControl



    Private ReadOnly Property AFD_SERVER As String
        Get
            Return SystemSettings.AFDEvolution_Server
        End Get
    End Property

    Private ReadOnly Property AFD_SERIAL_NUMBER As String
        Get
            Return SystemSettings.AFDEvolution_SerialNumber
        End Get
    End Property

    Private ReadOnly Property AFD_PASSWORD As String
        Get
            Return SystemSettings.AFDEvolution_Password
        End Get
    End Property

    Private ReadOnly Property AFD_USER_ID As String
        Get
            Return SystemSettings.AFDEvolution_UserID
        End Get
    End Property

    ''' <summary>
    ''' Set 'False' if you want to stop maintaining postcode and addresses locally during single session. Keeping this on will help us to reduce number of API calls made to find and retrieve addresses.
    ''' </summary>
    ''' <returns></returns>
    Private ReadOnly Property MaintainDataLocally As Boolean
        Get
            Return True
        End Get
    End Property
    ''' <summary>
    ''' Set 'True' if you want user to use lookup with a postcode in a valid format only.
    ''' </summary>
    ''' <returns></returns>
    Private ReadOnly Property ValidateBeforeSearch As Boolean
        Get
            Return False
        End Get
    End Property
    ''' <summary>
    ''' This property is needed to limit user from performing too many lookup operations.
    ''' </summary>
    ''' <returns></returns>
    Private Property LookupLimit As Integer
        Get
            If Session("LookupLimit") Is Nothing Then
                Session("LookupLimit") = -1 ''Set a number here to limit a user to perform lookup. Any number less than 0 means no limit will be applied.
            End If
            Return Session("LookupLimit")
        End Get
        Set(value As Integer)
            Session("LookupLimit") = value
        End Set
    End Property


    ''' <summary>
    ''' A property to hold addresses of already searched postcodes. With this, we will be able to fetch address list locally without calling an API, when same postcode is searched repetitively.
    ''' </summary>
    ''' <returns></returns>
    Private Property SearchedCodes As System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument)
        Get
            If Session("SearchedCodes") Is Nothing Then
                Session("SearchedCodes") = New System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument)
            End If
            Return Session("SearchedCodes")
        End Get
        Set(value As System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument))
            Session("SearchedCodes") = value
        End Set
    End Property
    ''' <summary>
    ''' A property to hold selected addresses (by user). With this, we will be able to retrieve address details locally without calling an API, when same address is selected repetitively.
    ''' </summary>
    ''' <returns></returns>
    Private Property FetchedAddresses As System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument)
        Get
            If Session("FetchedAddresses") Is Nothing Then
                Session("FetchedAddresses") = New System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument)
            End If
            Return Session("FetchedAddresses")
        End Get
        Set(value As System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument))
            Session("FetchedAddresses") = value
        End Set
    End Property

    Private Enum SearchType
        FastFind
        Search
        Retrieve
    End Enum


    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False


        If Not IsPostBack Then
            Dim SQLDBDataReader As SqlClient.SqlDataReader
            Dim SQLDataTable As New DataTable
            Dim cmd As New SqlCommand
            Dim SQLCmd As New SqlClient.SqlConnection
            SQLCmd.ConnectionString = GetConn()
            SQLCmd.Open()
            cmd.CommandText = "PSWebenrolmentReports.dbo.spGetCountyList"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = SQLCmd
            'cmd.Parameters.AddWithValue("countryID", CountryID.Value)
            SQLDBDataReader = cmd.ExecuteReader()

            Address4.Items.Clear()

            Address4.Items.Add(New ListItem("-- Select County --", ""))

            While SQLDBDataReader.Read()
                Address4.Items.Add(New ListItem(
                    SQLDBDataReader("CountyName").ToString(),
                    SQLDBDataReader("CountyName").ToString()
                ))
            End While

            SQLCmd.Close()
            SQLDBDataReader.Close()


            ParentEmailAddressConfirm.Value = WorkingData.EnrolmentRequestRow.ParentEmailAddress
            IsLivingWithParent.SelectedValue = WorkingData.EnrolmentRequestRow.IsLivingWithParent
            'Response.Write(WorkingData.EnrolmentRequestRow.IsLivingWithParent)
            If WorkingData.EnrolmentRequestRow.IsLivingWithParent.Equals(False) Then
                pcLiveInUKDiv.Visible = True
                If WorkingData.EnrolmentRequestRow.ParentPostCodeOut IsNot Nothing Then
                    pcLiveInUK.SelectedValue = 1
                    pcAddressSection.Visible = True
                    txtLookupPC.Value = WorkingData.EnrolmentRequestRow.ParentPostCodeOut & " " & WorkingData.EnrolmentRequestRow.ParentPostCodeIn
                    Address4.SelectedValue = WorkingData.EnrolmentRequestRow.ParentAddress4
                ElseIf WorkingData.EnrolmentRequestRow.ParentPostCodeOut Is Nothing Then
                    pcLiveInUK.SelectedValue = 0
                End If
            End If

            Else
            btnFetchAddress.Enabled = False
            PCPostcode.Value = WorkingData.EnrolmentRequestRow.Contact1PostCodeOut & WorkingData.EnrolmentRequestRow.Contact1PostCodeIn

            'Response.Write(WorkingData.EnrolmentRequestRow.ParentAddress1 & "###" & WorkingData.EnrolmentRequestRow.Contact1PostCodeIn)

        End If


        If IsPostBack Then
            If Request.Form("__EVENTTARGET") IsNot Nothing Then
                ''CCCPS-82076: We have to handle click event like this because of StudentEnrolmentField which we have used to display address details.
                ''Some internal logic of StudentEnrolmentField gets executed before the Buton Click event which causes an issue in loading proper data.
                If Request.Form("__EVENTTARGET").EndsWith("btnFindPC") Then
                    btnFetchAddress.Enabled = False
                    findAddress()
                    If lstresult.SelectedIndex >= 0 Then
                        btnFetchAddress.Enabled = True
                    End If
                ElseIf Request.Form("__EVENTTARGET").EndsWith("btnFetchAddress") Then
                    UpdateAddress()
                ElseIf Request.Form("__EVENTTARGET").EndsWith("btnCSA") Then
                    SearchedCodes.Clear()
                    FetchedAddresses.Clear()
                End If
            End If
        Else
            btnFetchAddress.Enabled = False
            PCPostcode.Value = WorkingData.EnrolmentRequestRow.PostcodeOut & WorkingData.EnrolmentRequestRow.PostcodeIn
        End If

        'AddHandler IsLivingWithParent.SelectedIndexChanged, AddressOf IsLivingWithParent_SelectedIndexChanged

        'If Not IsPostBack Then
        '    If WorkingData.ApplicationRequestRow.ApplicationUserDefined3 <> "" Then ddlAlevel_one.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined3
        '    If WorkingData.ApplicationRequestRow.ApplicationUserDefined4 <> "" Then ddlAlevel_two.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined4
        '    If WorkingData.ApplicationRequestRow.ApplicationUserDefined5 <> "" Then ddlAlevel_three.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined5
        '    If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 <> "" Then fldWhatsApp.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6
        '    WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByEmail = True
        '    'show personal statement for Access to HE
        '    For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
        '        If item.OfferingID > 0 Then

        '            Dim SQLDBDataReader As SqlClient.SqlDataReader
        '            Dim SQLDataTable As New DataTable
        '            Dim cmd As New SqlCommand
        '            Dim SQLCmd As New SqlClient.SqlConnection
        '            SQLCmd.ConnectionString = GetConn()
        '            SQLCmd.Open()
        '            cmd.CommandTimeout = "120"
        '            cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
        '            cmd.CommandType = CommandType.StoredProcedure
        '            cmd.Connection = SQLCmd
        '            cmd.Parameters.AddWithValue("offeringid", item.OfferingID)
        '            SQLDBDataReader = cmd.ExecuteReader()
        '            If SQLDBDataReader.HasRows Then
        '                While (SQLDBDataReader.Read)

        '                    'show personal statement supported internship as well as referee details
        '                    If CStr(SQLDBDataReader("code")).IndexOf("ALSCIENCE") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALBUS&LAW") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALHUM") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALCREATIVE") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALSOCIALSCI") > -1 Then
        '                        divALevels.Visible = True
        '                    End If


        '                End While
        '            End If
        '            SQLCmd.Close()
        '            SQLDBDataReader.Close()
        '        End If
        '    Next
        '    If divALevels.Visible = True Then
        '        ''get the a level subjects

        '        Dim SQLDBDataReader As SqlClient.SqlDataReader
        '        Dim SQLDataTable As New DataTable
        '        Dim cmd As New SqlCommand
        '        Dim SQLCmd As New SqlClient.SqlConnection
        '        SQLCmd.ConnectionString = GetConn()
        '        SQLCmd.Open()
        '        cmd.CommandTimeout = "120"
        '        cmd.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Connection = SQLCmd


        '        SQLDBDataReader = cmd.ExecuteReader()
        '        '  If SQLDBDataReader.HasRows Then
        '        ddlAlevel_one.DataSource = SQLDBDataReader
        '        ddlAlevel_one.DataTextField = "name"

        '        ddlAlevel_one.DataValueField = "code"
        '        ddlAlevel_one.DataBind()
        '        SQLCmd.Close()
        '        SQLDBDataReader.Close()


        '        Dim SQLDBDataReader2 As SqlClient.SqlDataReader
        '        Dim SQLDataTable2 As New DataTable
        '        Dim cmd2 As New SqlCommand
        '        Dim SQLCmd2 As New SqlClient.SqlConnection
        '        SQLCmd2.ConnectionString = GetConn()
        '        SQLCmd2.Open()
        '        cmd2.CommandTimeout = "120"
        '        cmd2.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
        '        cmd2.CommandType = CommandType.StoredProcedure
        '        cmd2.Connection = SQLCmd2


        '        SQLDBDataReader2 = cmd2.ExecuteReader()
        '        '  If SQLDBDataReader.HasRows Then
        '        ddlAlevel_two.DataSource = SQLDBDataReader2
        '        ddlAlevel_two.DataTextField = "name"

        '        ddlAlevel_two.DataValueField = "code"
        '        ddlAlevel_two.DataBind()
        '        SQLCmd2.Close()
        '        SQLDBDataReader2.Close()


        '        Dim SQLDBDataReader3 As SqlClient.SqlDataReader
        '        Dim SQLDataTable3 As New DataTable
        '        Dim cmd3 As New SqlCommand
        '        Dim SQLCmd3 As New SqlClient.SqlConnection
        '        SQLCmd3.ConnectionString = GetConn()
        '        SQLCmd3.Open()
        '        cmd3.CommandTimeout = "120"
        '        cmd3.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
        '        cmd3.CommandType = CommandType.StoredProcedure
        '        cmd3.Connection = SQLCmd3


        '        SQLDBDataReader3 = cmd3.ExecuteReader()
        '        '  If SQLDBDataReader.HasRows Then
        '        ddlAlevel_three.DataSource = SQLDBDataReader3
        '        ddlAlevel_three.DataTextField = "name"

        '        ddlAlevel_three.DataValueField = "code"
        '        ddlAlevel_three.DataBind()
        '        SQLCmd3.Close()
        '        SQLDBDataReader3.Close()
        '        ''  End If
        '        ''SQLCmd.Close()
        '        'SQLDBDataReader.Close()

        '        'SQLDBDataReader = cmd.ExecuteReader()
        '        'ddlAlevel_two.DataSource = SQLDBDataReader
        '        'ddlAlevel_two.DataTextField = "name"

        '        'ddlAlevel_two.DataValueField = "code"
        '        'ddlAlevel_two.DataBind()

        '        'SQLDBDataReader = cmd.ExecuteReader()
        '        'ddlAlevel_three.DataSource = SQLDBDataReader
        '        'ddlAlevel_three.DataTextField = "name"

        '        'ddlAlevel_three.DataValueField = "code"
        '        'ddlAlevel_three.DataBind()


        '        '  End If

        '    End If
        'End If
    End Sub



    Private Sub UpdateAddress()

        ' Declare XML Objects and variables
        Dim xmlDoc As System.Xml.XmlDocument
        Dim lstStr As String
        Dim xmlLocation As String

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

            ' Set XML parameter to retrieve the selected record
            lstStr = .Items.Item(.SelectedIndex).ToString
            ' Finished with the list box
        End With
        Dim addressKey As String = lstStr.Substring(lstStr.Length - 40, 40).Trim
        'Response.Write(addressKey)
        ''CCCPS-82076: No need to call an API to fetch address if we have it locally. 
        If MaintainDataLocally AndAlso FetchedAddresses.ContainsKey(addressKey) Then
            bindAddress(FetchedAddresses(addressKey))
            Return
        End If
        ' Create the XML Document Object Instance
        xmlDoc = New System.Xml.XmlDocument()

        ' Build up the XML query string
        xmlLocation = BuildServerDetails(SearchType.Retrieve)
        xmlLocation = xmlLocation & "&Key=" & addressKey

        ' Load the XML from the webserver with the query string
        Try
            xmlDoc.Load(xmlLocation)
            ''CCCPS-82076: Maintain retrieved address in session to reload locally if user selects it again. 
            If MaintainDataLocally Then FetchedAddresses.Add(addressKey, xmlDoc)
        Catch
            Dim v As New CustomValidator
            v.ErrorMessage = "Error loading address results, please enter address manually"
            v.IsValid = False
            Me.Page.Validators.Add(v)

            Exit Sub

        End Try

        bindAddress(xmlDoc)

    End Sub


    Private Sub bindAddress(xmlDoc As System.Xml.XmlDocument)
        Dim root As System.Xml.XmlNode
        Dim dataNode As System.Xml.XmlNode
        Dim itemNodes As System.Xml.XmlNodeList
        ' Check if PCE returned an error and if the document is valid
        root = xmlDoc.DocumentElement
        dataNode = root.SelectSingleNode("Result")
        'Response.Write(dataNode.InnerText)
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
                ParentAddress1.Value = String.Format("{0}, {1}", strProperty, dataNode.InnerText)
            Else
                ParentAddress1.Value = dataNode.InnerText
            End If
        End If

        dataNode = itemNodes(0).SelectSingleNode("Locality")
        If Not (dataNode Is Nothing) Then ParentAddress2.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Town")
        If Not (dataNode Is Nothing) Then ParentAddress2.Value = dataNode.InnerText

        'dataNode = itemNodes(0).SelectSingleNode("PostalCounty")
        'If Not (dataNode Is Nothing) Then Address4.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Postcode")
        If Not (dataNode Is Nothing) Then
            'txtpostcodeout.Value = Trim(dataNode.InnerText.Substring(0, InStr(1, dataNode.InnerText, " ")))
            'txtpostcodein.Value = Trim(Mid(dataNode.InnerText, InStr(1, dataNode.InnerText, " ") + 1))
            If Not (dataNode Is Nothing) Then PCPostcode.Value = dataNode.InnerText
        End If
    End Sub



    Private Sub findAddress()
        ' Clear out any existing items in the list
        'Response.Write("Btn clicked")

        lstresult.Items.Clear()
        If String.IsNullOrWhiteSpace(txtLookupPC.Value) Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter a search term for the previous UK address post code."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
            Return
        End If
        ''CCCPS-82076: Validating postcode format before performing lookup (Only if ValidateBeforeSearch is set to True). 
        If ValidateBeforeSearch Then
            Dim regexPostCode As New Regex("^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$")
            Dim match As Match = regexPostCode.Match(txtLookupPC.Value)
            If Not match.Success Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Please enter a valid Postcode"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
                Return
            End If
        End If
        ''CCCPS-82076: No need to call an API to fetch address list if we have it locally. 
        If MaintainDataLocally AndAlso SearchedCodes.ContainsKey(txtLookupPC.Value) Then
            GetSearchResults(SearchedCodes(txtLookupPC.Value))
            Return
        End If
        ''CCCPS-82076: Stop user from performing lookup limit is exhausted.
        If LookupLimit = 0 Then
            Dim v As New CustomValidator
            v.ErrorMessage = "The address has been looked up too many times. Please enter manually."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
            Return
        End If
        ' Declare XML Objects and variables
        Dim xmlDoc As System.Xml.XmlDocument
        Dim xmlLocation As String

        ' Create the XML Document Object Instance
        xmlDoc = New System.Xml.XmlDocument()

        ' Replace lstResult with the name of your list box for the results
        With lstresult
            ' Build up the XML query string
            xmlLocation = BuildServerDetails(SearchType.FastFind)

            ' Set the Country Name or ISO code for International operations
            xmlLocation = xmlLocation & "&Country=UK"

            ' Set the lookup string
            xmlLocation = xmlLocation & "&Lookup=" & txtLookupPC.Value ' Change txtLookup to your lookup entry textbox

            ' Load the XML from the webserver with the query string
            Try
                xmlDoc.Load(xmlLocation)
                ''CCCPS-82076: Maintain retrieved address list in session to reload locally if user searches for same postcode again. 
                If MaintainDataLocally Then SearchedCodes.Add(txtLookupPC.Value, xmlDoc)
                LookupLimit -= 1
                currentResults.Visible = True
            Catch
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
                Exit Sub
            End Try
            GetSearchResults(xmlDoc)
        End With
    End Sub



    Private Function BuildServerDetails(ByVal Type As SearchType) As String
        Dim xmlLocation As String
        ' Build up the XML query string
        xmlLocation = AFD_SERVER & "/afddata.pce?"
        xmlLocation = xmlLocation & "Serial=" & AFD_SERIAL_NUMBER & "&"
        xmlLocation = xmlLocation & "Password=" & AFD_PASSWORD & "&"
        xmlLocation = xmlLocation & "UserID=" & AFD_USER_ID & "&"

        Select Case Type
            Case SearchType.FastFind
                xmlLocation = xmlLocation & "Data=Address&Task=FastFind&Fields=List"
            Case SearchType.Search
                xmlLocation = xmlLocation & "Data=Address&Task=Search&Fields=List"
            Case SearchType.Retrieve
                xmlLocation = xmlLocation & "Data=Address&Task=Retrieve&Fields=Standard"
            Case Else

        End Select

        ' Set the maximum number of records to return
        xmlLocation = xmlLocation & "&MaxQuantity=100"

        Return xmlLocation
    End Function


    Private Sub GetSearchResults(xmlDoc As System.Xml.XmlDocument)
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
                    v.ErrorMessage = "Postcode has changed from " & pcFromNode.InnerText & " to " & dataNode.InnerText
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
                    .Items.Add(listNode.InnerText & Space(512) & keyNode.InnerText)
                    '.Items.Add(listNode.InnerText)
                End If
            Next

            If .Items.Count() <> 0 Then .SelectedIndex = 0 ' Select First item in the list

        End With
    End Sub


    Public Sub IsLivingWithParent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles IsLivingWithParent.SelectedIndexChanged


        If IsLivingWithParent.SelectedValue.Equals("False") Then


            'Response.Write(1)

            pcLiveInUKDiv.Visible = True
        Else
            'Response.Write(0)
            pcLiveInUKDiv.Visible = False
        End If
    End Sub


    Public Sub rdoLearnDiff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pcLiveInUK.SelectedIndexChanged


        If pcLiveInUK.SelectedValue.Equals("1") Then
            'Response.Write(1)

            pcAddressSection.Visible = True
        Else
            'Response.Write(0)
            pcAddressSection.Visible = False
        End If
    End Sub

    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        'MyBase.ValidateControl()

        If ParentEmailAddress.Value.Equals(ParentEmailAddressConfirm.Value) Then

        Else
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please confirm your email address by retyping it again."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If IsLivingWithParent.SelectedItem IsNot Nothing AndAlso IsLivingWithParent.SelectedItem.Value.Equals("") Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please confirm if this parent/carer lives at your address."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If


        If IsLivingWithParent IsNot Nothing AndAlso
            IsLivingWithParent.SelectedItem IsNot Nothing AndAlso
            IsLivingWithParent.SelectedItem.Value.Equals("False") Then

            If pcLiveInUK IsNot Nothing AndAlso
            pcLiveInUK.SelectedItem IsNot Nothing AndAlso
            pcLiveInUK.SelectedItem.Value.Equals("1") Then

                If Address4 IsNot Nothing AndAlso
                Address4.SelectedItem IsNot Nothing AndAlso
                Address4.SelectedItem.Value.Equals("") Then
                    Dim v As New CustomValidator()
                    v.ErrorMessage = "Please specify the county of your address."
                    v.IsValid = False
                    Me.Page.Validators.Add(v)
                    Me.ValidationSummary1.ShowSummary = True

                End If
            Else

                If pcLiveInUK.SelectedItem Is Nothing Then

                    Dim v As New CustomValidator()
                    v.ErrorMessage = "Please specify if the parent/carer lives in the UK."
                    v.IsValid = False
                    Me.Page.Validators.Add(v)
                    Me.ValidationSummary1.ShowSummary = True
                End If
            End If
        End If

        Return


    End Sub

    Public Function YearsBetweenDates(ByVal StartDate As DateTime,
           ByVal EndDate As DateTime) As Integer
        ' Returns the number of years between the passed dates
        If Month(EndDate) < Month(StartDate) Or
           (Month(EndDate) = Month(StartDate) And
           (EndDate.Day) < (StartDate.Day)) Then
            Return Year(EndDate) - Year(StartDate) - 1
        Else
            Return Year(EndDate) - Year(StartDate)
        End If
    End Function


    'Private Sub IsLivingWithParent_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles IsLivingWithParent.SelectedIndexChanged


    '    Response.Write(IsLivingWithParent.SelectedValue)
    '    If IsLivingWithParent.SelectedValue = "Y" Then
    '        'Response.Write("IsLivingWithParent_SelectedIndexChanged")
    '        parentCarerContactDetails.Visible = False
    '    Else
    '        parentCarerContactDetails.Visible = True
    '    End If
    'End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click


        Me.Page.Validate()
        'Response.Write(IsLivingWithParent.SelectedItem.Value)

        If Me.Page.IsValid Then

            WorkingData.EnrolmentRequest(0).IsLivingWithParent = IsLivingWithParent.SelectedItem.Value
            Page.Session("TIsLivingWithParent") = IsLivingWithParent.SelectedItem.Text

            Dim cboParentRelationship As DropDownList = DirectCast(Contact1RelationshipID.InternalFieldControl, DropDownList)
            Page.Session("TParentRelationship") = cboParentRelationship.SelectedItem.Text

            If IsLivingWithParent.SelectedItem.Value.Equals("True") Then

                'Response.Write(WorkingData.EnrolmentRequestRow.PostCodeIn)
                WorkingData.EnrolmentRequest(0).ParentAddress1 = WorkingData.EnrolmentRequest(0).Address1
                WorkingData.EnrolmentRequest(0).ParentAddress2 = WorkingData.EnrolmentRequest(0).Address2
                WorkingData.EnrolmentRequest(0).ParentAddress3 = WorkingData.EnrolmentRequest(0).Address3
                WorkingData.EnrolmentRequest(0).ParentAddress4 = WorkingData.EnrolmentRequest(0).Address4

                WorkingData.EnrolmentRequest(0).ParentPostCodeOut = WorkingData.EnrolmentRequest(0).PostCodeOut
                WorkingData.EnrolmentRequest(0).ParentPostCodeIn = WorkingData.EnrolmentRequest(0).PostCodeIn
            Else
                WorkingData.EnrolmentRequest(0).ParentAddress1 = ParentAddress1.Value
                WorkingData.EnrolmentRequest(0).ParentAddress2 = ParentAddress2.Value
                WorkingData.EnrolmentRequest(0).ParentAddress3 = ParentAddress3.Value
                WorkingData.EnrolmentRequest(0).ParentAddress4 = Address4.SelectedItem.Value

                Dim pcode As String = Replace(txtLookupPC.Value, " ", "")
                If Len(pcode) > 0 Then


                    'avoid dodgy postcodes breaking system
                    Try
                        WorkingData.EnrolmentRequest(0).ParentPostCodeOut = pcode.Substring(0, pcode.Length - 3)
                    Catch ex As ArgumentOutOfRangeException
                        WorkingData.EnrolmentRequest(0).ParentPostCodeOut = ""
                    End Try

                    Try
                        WorkingData.EnrolmentRequest(0).ParentPostCodeIn = Right(pcode, 3)
                    Catch ex As ArgumentOutOfRangeException
                        WorkingData.EnrolmentRequest(0).ParentPostCodeIn = ""
                    End Try


                End If


            End If




            'Response.Write(WorkingData.EnrolmentRequest(0).ParentAddress1)





            Response.Redirect(GetResourceValue("residencystatus_aspx"))
        Else

        End If

    End Sub
End Class
