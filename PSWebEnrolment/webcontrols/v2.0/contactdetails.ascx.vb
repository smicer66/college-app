'Option Explicit On
'Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Expressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip
Imports System.Xml
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class contactdetails
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
#Region "CCCPS-82076: Properties needed to optimize usage of AFD Postcode lookup"
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



    Private Property LookupLimitPrevious As Integer
        Get
            If Session("LookupLimitPrevious") Is Nothing Then
                Session("LookupLimitPrevious") = -1 ''Set a number here to limit a user to perform lookup. Any number less than 0 means no limit will be applied.
            End If
            Return Session("LookupLimitPrevious")
        End Get
        Set(value As Integer)
            Session("LookupLimitPrevious") = value
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


    Private Property FetchedAddressesPrevious As System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument)
        Get
            If Session("FetchedAddressesPrevious") Is Nothing Then
                Session("FetchedAddressesPrevious") = New System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument)
            End If
            Return Session("FetchedAddressesPrevious")
        End Get
        Set(value As System.Collections.Generic.Dictionary(Of String, System.Xml.XmlDocument))
            Session("FetchedAddressesPrevious") = value
        End Set
    End Property
#End Region

    Private Enum SearchType
        FastFind
        Search
        Retrieve
    End Enum

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Response.Write(Session("LookupLimit"))
        'Response.Write(Session("LookupLimitPrevious"))

        'btnFetchAddress.Enabled = True
        'Reset to look at main address again (If user is navigating backwards


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


        If Not IsPostBack Then
            Address4.Items.Clear()
            StudentDetailUserDefined16.Items.Clear()

            Address4.Items.Add(New ListItem("-- Select County --", ""))
            StudentDetailUserDefined16.Items.Add(New ListItem("-- Select County --", ""))

            While SQLDBDataReader.Read()
                Address4.Items.Add(New ListItem(
                    SQLDBDataReader("CountyName").ToString(),
                    SQLDBDataReader("CountyName").ToString()
                ))
                StudentDetailUserDefined16.Items.Add(New ListItem(
                    SQLDBDataReader("CountyName").ToString(),
                    SQLDBDataReader("CountyName").ToString()
                ))
            End While

            SQLCmd.Close()
            SQLDBDataReader.Close()

            ConfirmEmail.Value = WorkingData.EnrolmentRequestRow.Email



        End If




        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False
        Dim ddl As DropDownList = FindDropDownList(CountryID)
        If ddl IsNot Nothing Then
            AddHandler ddl.SelectedIndexChanged, AddressOf CountryID_SelectedIndexChanged
            ddl.AutoPostBack = True
        End If

        If PreviousAddressCheckbox.Checked Then
            PreviousAddressSection.Visible = PreviousAddressCheckbox.Checked
        End If


        If WorkingData.EnrolmentRequestRow.CountryID IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.CountryID.Equals("XF") Then
            UKAddressSection.Visible = True
        End If

        If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17 IsNot Nothing Then
            PreviousAddressSection.Visible = True
        End If

        If WorkingData.EnrolmentRequestRow.PostcodeIn IsNot Nothing Then
            txtLookup.Value = WorkingData.EnrolmentRequestRow.PostcodeOut & " " & WorkingData.EnrolmentRequestRow.PostcodeIn
        End If

        If WorkingData.EnrolmentRequestRow.Address4 IsNot Nothing Then
            Address4.SelectedValue = WorkingData.EnrolmentRequestRow.Address4
        End If

        'Response.Write(WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17)
        If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17 IsNot Nothing Then
            PreviousAddressCheckbox.Checked = True
            postCodePrevious.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17
            txtLookupPrevious.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17
            PreviousAddress1.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined13
            PreviousAddress2.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined14
            PreviousAddress3.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined15
            StudentDetailUserDefined16.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined16
        End If


        If IsPostBack Then
            If Request.Form("__EVENTTARGET") IsNot Nothing Then
                ''CCCPS-82076: We have to handle click event like this because of StudentEnrolmentField which we have used to display address details.
                ''Some internal logic of StudentEnrolmentField gets executed before the Buton Click event which causes an issue in loading proper data.
                If Request.Form("__EVENTTARGET").EndsWith("btnFind") Then
                    btnFetchAddress.Enabled = False
                    findAddress()
                    If lstresult.SelectedIndex >= 0 Then
                        btnFetchAddress.Enabled = True
                    End If
                ElseIf Request.Form("__EVENTTARGET").EndsWith("btnFindPrevAddress") Then
                    btnFetchAddressPrevious.Enabled = False
                    findPreviousAddress()
                    If lstresultPrevious.SelectedIndex >= 0 Then
                        btnFetchAddressPrevious.Enabled = True
                    End If
                ElseIf Request.Form("__EVENTTARGET").EndsWith("btnFetchAddress") Then
                    UpdateAddress()
                ElseIf Request.Form("__EVENTTARGET").EndsWith("btnFetchAddressPrevious") Then
                    UpdateAddressForPrevious()
                ElseIf Request.Form("__EVENTTARGET").EndsWith("btnCSA") Then
                    SearchedCodes.Clear()
                    FetchedAddresses.Clear()
                End If
            End If
        Else
            btnFetchAddress.Enabled = False
            postcode.Value = WorkingData.EnrolmentRequestRow.PostcodeOut & WorkingData.EnrolmentRequestRow.PostcodeIn
        End If

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
    ''' <summary>
    ''' CCCPS-82076: Separated from updateAddress() method as this part was needed to load address from session as well.
    ''' </summary>
    ''' <param name="xmlDoc"></param>
    ''' 


    Private Sub UpdateAddressForPrevious()

        ' Declare XML Objects and variables
        Dim xmlDoc As System.Xml.XmlDocument
        Dim lstStr As String
        Dim xmlLocation As String

        ' Replace lstresultPrevious with the name of your list box for the results
        With lstresultPrevious

            If lstresultPrevious.Items.Count = 0 Then
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
        If MaintainDataLocally AndAlso FetchedAddressesPrevious.ContainsKey(addressKey) Then
            bindAddressPrevious(FetchedAddressesPrevious(addressKey))
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
            If MaintainDataLocally Then FetchedAddressesPrevious.Add(addressKey, xmlDoc)
        Catch
            Dim v As New CustomValidator
            v.ErrorMessage = "Error loading address results, please enter address manually"
            v.IsValid = False
            Me.Page.Validators.Add(v)

            Exit Sub

        End Try

        bindAddressPrevious(xmlDoc)

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
                Address1.Value = String.Format("{0}, {1}", strProperty, dataNode.InnerText)
            Else
                Address1.Value = dataNode.InnerText
            End If
        End If

        dataNode = itemNodes(0).SelectSingleNode("Locality")
        If Not (dataNode Is Nothing) Then Address2.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Town")
        If Not (dataNode Is Nothing) Then Address3.Value = dataNode.InnerText

        'dataNode = itemNodes(0).SelectSingleNode("PostalCounty")
        'If Not (dataNode Is Nothing) Then Address4.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Postcode")
        If Not (dataNode Is Nothing) Then
            'txtpostcodeout.Value = Trim(dataNode.InnerText.Substring(0, InStr(1, dataNode.InnerText, " ")))
            'txtpostcodein.Value = Trim(Mid(dataNode.InnerText, InStr(1, dataNode.InnerText, " ") + 1))
            If Not (dataNode Is Nothing) Then postcode.Value = dataNode.InnerText
        End If
    End Sub


    Private Sub bindAddressPrevious(xmlDoc As System.Xml.XmlDocument)
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
                PreviousAddress1.Value = String.Format("{0}, {1}", strProperty, dataNode.InnerText)
            Else
                PreviousAddress1.Value = dataNode.InnerText
            End If
        End If

        dataNode = itemNodes(0).SelectSingleNode("Locality")
        If Not (dataNode Is Nothing) Then PreviousAddress2.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Town")
        If Not (dataNode Is Nothing) Then PreviousAddress3.Value = dataNode.InnerText

        'dataNode = itemNodes(0).SelectSingleNode("PostalCounty")
        'If Not (dataNode Is Nothing) Then Address4.Value = dataNode.InnerText

        dataNode = itemNodes(0).SelectSingleNode("Postcode")
        If Not (dataNode Is Nothing) Then
            'txtpostcodeout.Value = Trim(dataNode.InnerText.Substring(0, InStr(1, dataNode.InnerText, " ")))
            'txtpostcodein.Value = Trim(Mid(dataNode.InnerText, InStr(1, dataNode.InnerText, " ") + 1))
            If Not (dataNode Is Nothing) Then postCodePrevious.Value = dataNode.InnerText
        End If
    End Sub



    Private Sub findPreviousAddress()
        ' Clear out any existing items in the list
        'Response.Write("Btn clicked")

        lstresultPrevious.Items.Clear()
        If String.IsNullOrWhiteSpace(txtLookupPrevious.Value) Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter a previous UK address postcode."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Return
        End If
        ''CCCPS-82076: Validating postcode format before performing lookup (Only if ValidateBeforeSearch is set to True). 
        If ValidateBeforeSearch Then
            Dim regexPostCode As New Regex("^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$")
            Dim match As Match = regexPostCode.Match(txtLookupPrevious.Value)
            If Not match.Success Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Please enter a valid previous UK address Postcode"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Return
            End If
        End If
        ''CCCPS-82076: No need to call an API to fetch address list if we have it locally. 
        If MaintainDataLocally AndAlso SearchedCodes.ContainsKey(txtLookupPrevious.Value) Then
            GetSearchResultsForPreviousAddress(SearchedCodes(txtLookupPrevious.Value))
            Return
        End If
        ''CCCPS-82076: Stop user from performing lookup limit is exhausted.
        If LookupLimitPrevious = 0 Then
            Dim v As New CustomValidator
            v.ErrorMessage = "The previous UK address has been looked up too many times. Please enter manually."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Return
        End If
        ' Declare XML Objects and variables
        Dim xmlDoc As System.Xml.XmlDocument
        Dim xmlLocation As String

        ' Create the XML Document Object Instance
        xmlDoc = New System.Xml.XmlDocument()

        ' Replace lstResult with the name of your list box for the results
        With lstresultPrevious
            ' Build up the XML query string
            xmlLocation = BuildServerDetails(SearchType.FastFind)

            ' Set the Country Name or ISO code for International operations
            xmlLocation = xmlLocation & "&Country=UK"

            ' Set the lookup string
            xmlLocation = xmlLocation & "&Lookup=" & txtLookupPrevious.Value ' Change txtLookup to your lookup entry textbox

            ' Load the XML from the webserver with the query string
            Try
                xmlDoc.Load(xmlLocation)
                ''CCCPS-82076: Maintain retrieved address list in session to reload locally if user searches for same postcode again. 
                If MaintainDataLocally Then SearchedCodes.Add(txtLookupPrevious.Value, xmlDoc)
                LookupLimitPrevious -= 1
                previousAddressDiv.Visible = True
            Catch
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading previous UK address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Exit Sub
            End Try
            GetSearchResultsForPreviousAddress(xmlDoc)
        End With
    End Sub

    Private Sub findAddress()
        ' Clear out any existing items in the list
        'Response.Write(LookupLimit)

        lstresult.Items.Clear()
        If String.IsNullOrWhiteSpace(txtLookup.Value) Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter a search term for the previous UK address post code."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Return
        End If
        ''CCCPS-82076: Validating postcode format before performing lookup (Only if ValidateBeforeSearch is set to True). 
        If ValidateBeforeSearch Then
            Dim regexPostCode As New Regex("^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$")
            Dim match As Match = regexPostCode.Match(txtLookup.Value)
            If Not match.Success Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Please enter a valid Postcode"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Return
            End If
        End If
        ''CCCPS-82076: No need to call an API to fetch address list if we have it locally. 
        If MaintainDataLocally AndAlso SearchedCodes.ContainsKey(txtLookup.Value) Then
            GetSearchResults(SearchedCodes(txtLookup.Value))
            Return
        End If
        ''CCCPS-82076: Stop user from performing lookup limit is exhausted.
        If LookupLimit = 0 Then
            Dim v As New CustomValidator
            v.ErrorMessage = "The address has been looked up too many times. Please enter manually."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
            Response.Write(LookupLimit)
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
            xmlLocation = xmlLocation & "&Lookup=" & txtLookup.Value ' Change txtLookup to your lookup entry textbox

            ' Load the XML from the webserver with the query string
            Try
                xmlDoc.Load(xmlLocation)
                ''CCCPS-82076: Maintain retrieved address list in session to reload locally if user searches for same postcode again. 
                If MaintainDataLocally Then SearchedCodes.Add(txtLookup.Value, xmlDoc)
                LookupLimit -= 1
                currentResults.Visible = True
            Catch
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
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


    Private Sub GetSearchResultsForPreviousAddress(xmlDoc As System.Xml.XmlDocument)
        Dim root As System.Xml.XmlNode
        Dim pcFromNode As System.Xml.XmlNode
        Dim dataNode As System.Xml.XmlNode
        Dim itemNodes As System.Xml.XmlNodeList
        Dim listNode As System.Xml.XmlNode
        Dim keyNode As System.Xml.XmlNode
        With lstresultPrevious
            ' Check if PCE returned an error and if the document is valid
            root = xmlDoc.DocumentElement
            dataNode = root.SelectSingleNode("Result")
            itemNodes = root.SelectNodes("Item")
            If dataNode Is Nothing Or itemNodes Is Nothing Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Error loading previous UK address results, please enter address manually"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Exit Sub
            End If
            If Val(dataNode.InnerText) < 1 Then
                dataNode = root.SelectSingleNode("ErrorText")
                If dataNode Is Nothing Then
                    Dim v As New CustomValidator
                    v.ErrorMessage = "Error loading previous UK address results, please enter address manually"
                    v.IsValid = False
                    Me.Page.Validators.Add(v)
                Else
                    Dim v As New CustomValidator
                    v.ErrorMessage = dataNode.InnerText & vbCrLf & "Please enter previous UK address manually"
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



    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        If ConfirmEmail.Value.Equals(fldContactEmail.Value) Then

        Else
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please confirm your email address by retyping it again."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If CountryID.Value.Equals("XF") Then
            If Address4.SelectedItem.Value.Equals("") Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please specify the county of your address."
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If

        '  Response.Write(ddlAlevel_one.SelectedIndex)


        '--Here Comment
        'If Len(datepicker.Value) > 0 Then
        '    If IsDate(datepicker.Value) AndAlso YearsBetweenDates(CDate(datepicker.Value), Today.Date) < 14 Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please check your date of birth has been entered correctly. It looks like you have entered an incorrect date."
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If

        'End If
        ''Whatspaa
        'If fldWhatsApp.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please tell us if you use WhatsApp"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 = fldWhatsApp.SelectedValue
        'End If
        'If divALevels.Visible = True Then
        '    '    Response.Write(ddlAlevel_one.SelectedIndex)
        '    If ddlAlevel_one.SelectedIndex = "0" Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please provide an A Level subject choice 1"
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If
        '    If ddlAlevel_two.SelectedIndex = "0" Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please provide an A Level subject choice 2"
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If
        '    If ddlAlevel_three.SelectedIndex = "0" Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please provide an A Level subject choice 3"
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If
        'End If

    End Sub


    Private Function FindDropDownList(parent As Control) As DropDownList

        For Each ctrl As Control In parent.Controls

            If TypeOf ctrl Is DropDownList Then
                Return DirectCast(ctrl, DropDownList)
            End If

            Dim result As DropDownList = FindDropDownList(ctrl)

            If result IsNot Nothing Then
                Return result
            End If

        Next

        Return Nothing

    End Function


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



    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click



        'Me.Page.Validate()
        If Me.Page.IsValid Then

            Dim cboCountry As DropDownList = DirectCast(CountryID.InternalFieldControl, DropDownList)
            Page.Session("TCountry") = cboCountry.SelectedItem.Text

            WorkingData.EnrolmentRequest(0).Address1 = Address1.Value
            WorkingData.EnrolmentRequest(0).Address2 = Address2.Value
            WorkingData.EnrolmentRequest(0).Address3 = Address3.Value
            WorkingData.EnrolmentRequest(0).Address4 = Address4.SelectedItem.Value

            Dim pcode As String = Replace(txtLookup.Value, " ", "")
            If Len(pcode) > 0 Then

                'avoid dodgy postcodes breaking system
                Try
                    WorkingData.EnrolmentRequest(0).PostcodeOut = pcode.Substring(0, pcode.Length - 3)
                Catch ex As ArgumentOutOfRangeException
                    WorkingData.EnrolmentRequest(0).PostcodeOut = ""
                End Try

                Try
                    WorkingData.EnrolmentRequest(0).PostcodeIn = Right(pcode, 3)
                Catch ex As ArgumentOutOfRangeException
                    WorkingData.EnrolmentRequest(0).PostcodeIn = ""
                End Try


            End If

            Dim pcodePrevious As String = Replace(txtLookupPrevious.Value, " ", "")
            If Len(pcodePrevious) > 0 Then
                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined17 = ""
                'avoid dodgy postcodes breaking system
                Try
                    WorkingData.EnrolmentRequest(0).StudentDetailUserDefined17 += pcodePrevious.Substring(0, pcodePrevious.Length - 3) + " "
                Catch ex As ArgumentOutOfRangeException
                    WorkingData.EnrolmentRequest(0).StudentDetailUserDefined17 += ""
                End Try

                Try
                    WorkingData.EnrolmentRequest(0).StudentDetailUserDefined17 += Right(pcodePrevious, 3)
                Catch ex As ArgumentOutOfRangeException
                    WorkingData.EnrolmentRequest(0).StudentDetailUserDefined17 += ""
                End Try

                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined13 = PreviousAddress1.Value
                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined14 = PreviousAddress2.Value
                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined15 = PreviousAddress3.Value
                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined16 = StudentDetailUserDefined16.SelectedItem.Value

            End If

            'Response.Write(WorkingData.EnrolmentRequest(0).StudentDetailUserDefined17)

            Dim blnApplicationsOnly As Boolean = WorkingData.ShoppingCart IsNot Nothing AndAlso Not WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment")

            If blnApplicationsOnly Then
                Response.Redirect(GetResourceValue("parentcarercontactdetails_aspx"))
            Else
                Response.Redirect(GetResourceValue("parentcarercontactdetails_aspx"))
            End If

        End If

    End Sub

    Public Sub OverseasCheck_CheckedChanged(Sender As Object, e As EventArgs) Handles OverseasCheck.CheckedChanged
        OverseasGroupDiv.Visible = OverseasCheck.Checked
    End Sub

    Public Sub PreviousAddressCheckbox_CheckedChanged(Sender As Object, e As EventArgs) Handles PreviousAddressCheckbox.CheckedChanged
        PreviousAddressSection.Visible = PreviousAddressCheckbox.Checked
    End Sub

    Public Sub CountryID_SelectedIndexChanged(Sender As Object, e As EventArgs)
        If CountryID.Value = "XF" Then
            UKAddressSection.Visible = True
        Else
            UKAddressSection.Visible = False
        End If
    End Sub
End Class
