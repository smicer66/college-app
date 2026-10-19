'Option Explicit On
'Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Web.UI.WebControls.Expressions
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class residencystatus
    Inherits CheckoutBaseControl

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
            cmd.CommandText = "PSWebenrolmentReports.dbo.spGetCountryList"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = SQLCmd
            'cmd.Parameters.AddWithValue("countryID", CountryID.Value)
            SQLDBDataReader = cmd.ExecuteReader()

            PlaceOfBirth.Items.Clear()

            PlaceOfBirth.Items.Add(New ListItem("", ""))

            While SQLDBDataReader.Read()
                PlaceOfBirth.Items.Add(New ListItem(
                SQLDBDataReader("Description").ToString(),
                SQLDBDataReader("CountryID").ToString()
            ))
            End While

            SQLCmd.Close()
            SQLDBDataReader.Close()


            'Response.Write(WorkingData.EnrolmentRequestRow.StudentDetailUserDefined23)

            currentlyUk.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined20
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined20 IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined20.Equals("1") Then
                livingInUKShow.Visible = True
            End If
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined22 IsNot Nothing Then
                ukPassport.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined22
                If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined22.Equals("0") Then
                    alwaysLivedInUKDiv.Visible = True
                End If
            End If
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined23 IsNot Nothing Then
                PlaceOfBirth.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined23
            End If
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 IsNot Nothing Then
                If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6.Equals("Y") Then
                    alwaysLivedInUk.SelectedValue = 1
                    visaImmigrationDetails.Visible = False
                    ukEntryDateDiv.Visible = False
                    LivedInTheUKLast3YrsDiv.Visible = False
                ElseIf WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6.Equals("N") Then
                    alwaysLivedInUk.SelectedValue = 0
                    EuroResidentID.SelectedValue = WorkingData.EnrolmentRequest(0).EuroResidentID

                    visaImmigrationDetails.Visible = True
                    ukEntryDateDiv.Visible = True
                    LivedInTheUKLast3YrsDiv.Visible = True
                End If
            End If
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.DateOfEntryUK IsNot Nothing Then
                DateOfEntryUK.Value = Convert.ToDateTime(WorkingData.EnrolmentRequestRow.DateOfEntryUK).ToString("dd MMM yyyy")
            End If
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined21 IsNot Nothing Then
                DoYouHaveAVisa.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined21
                If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined21.Equals("1") Then
                    visaDetailsDiv.Visible = True
                    VisaTypeID.Value = WorkingData.EnrolmentRequestRow.VisaTypeID
                    VisaDocumentNumber.Value = WorkingData.EnrolmentRequestRow.VisaDocumentNumber
                    VisaStartDate.Value = WorkingData.EnrolmentRequestRow.VisaStartDate
                    If(WorkingData.EnrolmentRequestRow.VisaExpiryDate isNot Nothing) Then
                        VisaExpiryDate.Value = WorkingData.EnrolmentRequestRow.VisaExpiryDate
                    End If

                    If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3 IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3.Trim.Length > 0 Then
                        DoYouHaveAVisaShareCode.SelectedValue = 1
                        StudentDetailUserDefined3.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3
                        shareCodeDiv.Visible = True
                    End If
                Else
                    visaDetailsDiv.Visible = False
                End If
            End If


        End If


    End Sub


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()


        If currentlyUk.SelectedItem IsNot Nothing AndAlso currentlyUk.SelectedItem.Value.Equals("1") Then
            If ukPassport.SelectedItem IsNot Nothing Then
                If PlaceOfBirth.SelectedItem IsNot Nothing AndAlso PlaceOfBirth.SelectedItem.Value.Equals("").Equals(False) Then

                Else
                    'Throw error for place of birth
                    Dim v As New CustomValidator
                    v.IsValid = False
                    v.ErrorMessage = "Please specify your country of birth."
                    Me.Page.Validators.Add(v)
                    ValidationSummary1.ShowSummary = True
                End If

                If ukPassport.SelectedItem.Value.Equals("0") Then
                    If alwaysLivedInUk.SelectedItem IsNot Nothing AndAlso alwaysLivedInUk.SelectedItem.Value.Equals("0") Then
                        If DateOfEntryUK.Value IsNot Nothing AndAlso DateOfEntryUK.Value.ToString.Trim.Length > 0 Then
                            If EuroResidentID.SelectedItem IsNot Nothing AndAlso EuroResidentID.SelectedItem.Value.ToString.Trim.Length > 0 Then
                                If DoYouHaveAVisa.SelectedItem IsNot Nothing AndAlso DoYouHaveAVisa.SelectedItem.Value.Equals("1") Then
                                    If DoYouHaveAVisaShareCode.SelectedItem IsNot Nothing AndAlso DoYouHaveAVisaShareCode.SelectedItem.Value.Equals("1") Then

                                    ElseIf DoYouHaveAVisaShareCode.SelectedItem IsNot Nothing AndAlso DoYouHaveAVisaShareCode.SelectedItem.Value.Equals("0") Then

                                    Else
                                        'Throw error for non selection of share code
                                        Dim v As New CustomValidator
                                        v.IsValid = False
                                        v.ErrorMessage = "Please specify if you have an eVisa shareCode."
                                        Me.Page.Validators.Add(v)
                                        ValidationSummary1.ShowSummary = True
                                    End If
                                ElseIf DoYouHaveAVisa.SelectedItem IsNot Nothing AndAlso DoYouHaveAVisa.SelectedItem.Value.Equals("0") Then

                                ElseIf DoYouHaveAVisa.SelectedItem IsNot Nothing AndAlso DoYouHaveAVisa.SelectedItem.Value.Equals("2") Then

                                Else
                                    'Throw error for non selection of do you have a visa
                                    Dim v As New CustomValidator
                                    v.IsValid = False
                                    v.ErrorMessage = "Please specify if you have a visa."
                                    Me.Page.Validators.Add(v)
                                    ValidationSummary1.ShowSummary = True
                                End If
                            Else
                                'Throw error for non selection of 3 years in the UK
                                Dim v As New CustomValidator
                                v.IsValid = False
                                v.ErrorMessage = "Please specify if you have lived in the UK for the last 3 years."
                                Me.Page.Validators.Add(v)
                                ValidationSummary1.ShowSummary = True
                            End If
                        Else
                            'Throw error for date of entry
                            'Dim v As New CustomValidator
                            'v.IsValid = False
                            'v.ErrorMessage = "Please specify your date of entry into the UK."
                            'Me.Page.Validators.Add(v)
                            'ValidationSummary1.ShowSummary = True
                        End If
                    ElseIf alwaysLivedInUk.SelectedItem IsNot Nothing AndAlso alwaysLivedInUk.SelectedItem.Value.Equals("1") Then

                    Else
                        'Throw error for always lived in the UK
                        Dim v As New CustomValidator
                        v.IsValid = False
                        v.ErrorMessage = "Please specify if you have always lived in the UK."
                        Me.Page.Validators.Add(v)
                        ValidationSummary1.ShowSummary = True
                    End If
                Else

                End If
            Else
                'Throw error uk pasport
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please specify if you have a UK passport."
                Me.Page.Validators.Add(v)
                ValidationSummary1.ShowSummary = True
            End If
        Else
            If currentlyUk.SelectedItem Is Nothing Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please specify if you are currently in the UK."
                Me.Page.Validators.Add(v)
                ValidationSummary1.ShowSummary = True
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



    Public Sub currentlyUk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles currentlyUk.SelectedIndexChanged


        If currentlyUk.SelectedValue.Equals("1") Then
            'Response.Write(1)
            livingInUKShow.Visible = True
            NotCurrentlyInUKMessage.Visible = False
        Else
            'Response.Write(0)
            livingInUKShow.Visible = False
            NotCurrentlyInUKMessage.Visible = True
        End If
    End Sub


    Public Sub alwaysLivedInUk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles alwaysLivedInUk.SelectedIndexChanged


        If alwaysLivedInUk.SelectedValue.Equals("0") Then
            'Response.Write(1)
            ukEntryDateDiv.Visible = True
            visaImmigrationDetails.Visible = True
            ukEntryDateDiv.Visible = True
            LivedInTheUKLast3YrsDiv.Visible = True
        Else
            'Response.Write(0)
            ukEntryDateDiv.Visible = False
            visaImmigrationDetails.Visible = False
            ukEntryDateDiv.Visible = False
            LivedInTheUKLast3YrsDiv.Visible = False
        End If
    End Sub


    Public Sub DoYouHaveAVisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DoYouHaveAVisa.SelectedIndexChanged


        If DoYouHaveAVisa.SelectedValue.Equals("1") Then
            'Response.Write(1)
            visaDetailsDiv.Visible = True
        Else
            'Response.Write(0)
            visaDetailsDiv.Visible = False
        End If
    End Sub


    Public Sub DoYouHaveAVisaShareCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DoYouHaveAVisaShareCode.SelectedIndexChanged



        If DoYouHaveAVisaShareCode.SelectedValue.Equals("1") Then
            'Response.Write(1)
            shareCodeDiv.Visible = True
        Else
            'Response.Write(0)
            shareCodeDiv.Visible = False
        End If
    End Sub


    Public Sub ukPassport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ukPassport.SelectedIndexChanged

        If ukPassport.SelectedValue.Equals("1") Then
            'Response.Write(1)
            alwaysLivedInUKDiv.Visible = False
            ukEntryDateDiv.Visible = False
            visaImmigrationDetails.Visible = False
            ukEntryDateDiv.Visible = False
            LivedInTheUKLast3YrsDiv.Visible = False
        Else
            'Response.Write(0)
            alwaysLivedInUKDiv.Visible = True
            alwaysLivedInUk.SelectedValue = Nothing

        End If
    End Sub



    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()


        If Me.Page.IsValid Then
            WorkingData.EnrolmentRequest(0).StudentDetailUserDefined20 = currentlyUk.SelectedItem.Value
            Page.Session("TCurrentlyInUk") = currentlyUk.SelectedItem.Text

            If currentlyUk.SelectedItem.Value.Equals("1") Then
                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined22 = ukPassport.SelectedItem.Value
                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined23 = PlaceOfBirth.SelectedItem.Value 'CountryOfBirth
                Page.Session("TPlaceOfBirth") = PlaceOfBirth.SelectedItem.Text

                Page.Session("TUKPassport") = ukPassport.SelectedItem.Text
                If ukPassport.SelectedItem.Value.Equals("0") Then

                    If alwaysLivedInUk.SelectedItem IsNot Nothing AndAlso alwaysLivedInUk.SelectedItem.Value.Equals("1") Then
                        Page.Session("TAlwaysLivedInUk") = alwaysLivedInUk.SelectedItem.Text
                        WorkingData.EnrolmentRequest(0).StudentDetailUserDefined6 = "Y"
                    ElseIf alwaysLivedInUk.SelectedItem IsNot Nothing AndAlso alwaysLivedInUk.SelectedItem.Value.Equals("0") Then
                        If alwaysLivedInUk.SelectedItem.Value.Equals("0") Then
                            Page.Session("TAlwaysLivedInUk") = alwaysLivedInUk.SelectedItem.Text
                        End If
                        WorkingData.EnrolmentRequest(0).StudentDetailUserDefined6 = "N"

                        Dim parsedDate As DateTime
                        Dim visaExpireDateParsed As DateTime
                        Dim visaStartDateParsed As DateTime

                        If DateTime.TryParseExact(
                                DateOfEntryUK.Value,
                                "dd MMM yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                parsedDate
                            ) Then
                            Page.Session("TDateOfEntryUK") = DateOfEntryUK.Value
                            WorkingData.EnrolmentRequest(0).DateOfEntryUK = DateOfEntryUK.Value

                        End If


                        Page.Session("TEuroResidentID") = EuroResidentID.SelectedItem.Text
                        WorkingData.EnrolmentRequest(0).EuroResidentID = EuroResidentID.SelectedItem.Value

                        If DoYouHaveAVisa.SelectedItem.Value IsNot Nothing Then
                            Page.Session("TDoYouHaveAVisa") = DoYouHaveAVisa.SelectedItem.Text
                            WorkingData.EnrolmentRequest(0).StudentDetailUserDefined21 = DoYouHaveAVisa.SelectedItem.Value

                            If DoYouHaveAVisa.SelectedItem.Value.Equals("1") Then
                                Dim cboVisaTypeID As DropDownList = DirectCast(VisaTypeID.InternalFieldControl, DropDownList)
                                Page.Session("TVisaTypeID") = cboVisaTypeID.SelectedItem.Text

                                Page.Session("TVisaDocumentNumber") = VisaDocumentNumber.Value
                                Page.Session("TVisaStartDate") = VisaStartDate.Value
                                Page.Session("TVisaExpiryDate") = VisaExpiryDate.Value
                                WorkingData.EnrolmentRequest(0).StudentDetailUserDefined21 = DoYouHaveAVisa.SelectedItem.Value


                                If DateTime.TryParseExact(
                                        VisaExpiryDate.Value,
                                        "dd MMM yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        visaExpireDateParsed
                                    ) Then
                                    WorkingData.EnrolmentRequestRow.VisaExpiryDate = visaExpireDateParsed

                                End If

                                If DateTime.TryParseExact(
                                        VisaStartDate.Value,
                                        "dd MMM yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        visaStartDateParsed
                                    ) Then
                                    WorkingData.EnrolmentRequestRow.VisaStartDate = visaStartDateParsed

                                End If

                                Page.Session("TDoYouHaveAVisaShareCode") = DoYouHaveAVisaShareCode.SelectedItem.Text
                                If DoYouHaveAVisaShareCode.SelectedItem.Value.Equals("1") Then
                                    Page.Session("TShareCode") = StudentDetailUserDefined3.Value
                                    WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3 = StudentDetailUserDefined3.Value
                                End If
                            End If
                        End If
                    End If

                End If
            End If




            'Response.Write(1)

















            Dim IsAccessOrConstructionCourse As Boolean = False


            For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
                'Response.Write(item.Description)
                If (item.Description.IndexOf("Access to HE") > -1) Then
                    IsAccessOrConstructionCourse = True
                End If

            Next

            If IsAccessOrConstructionCourse.Equals(True) Then
                Response.Redirect(GetResourceValue("yourqualifications_aspx"))
            Else
                Response.Redirect(GetResourceValue("learningdifficultyanddisability_aspx"))
            End If
        End If
    End Sub
End Class
