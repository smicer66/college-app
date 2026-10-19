'Option Explicit On
'Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Globalization
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.Business.UCASHep1XMLDocLink
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.ProSolution.PSWebEnrolmentKit.epaycapita
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class yourqualifications
    Inherits CheckoutBaseControl

    Dim ctl1 As Object

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False


        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then


        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Dim IsAccessOrConstructionCourse As Boolean = False


            For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
                'Response.Write(item.Description)
                If (item.Description.IndexOf("Access to HE") > -1) Then
                    IsAccessOrConstructionCourse = True
                End If

            Next

            If (IsAccessOrConstructionCourse.Equals(True)) Then

            Else
                Response.Redirect(GetResourceValue("learningdifficultyanddisability_aspx"))
            End If
        End If


        If Not IsPostBack Then

            tblQuals.Rows.Clear()

            'CreateChildControls()

        End If

    End Sub


    Protected Overrides Sub CreateChildControls()
        MyBase.CreateChildControls()

        'If IsPostBack Then

        'Recreate the header row
        Dim rowH As New TableRow

        'Dim c1, c2, c3, c4, c5, c6 As New TableCell
        Dim c1, c2, c3, c4, c6 As New TableCell
        c1.Text = "Subject"
        c1.Attributes.Add("class", "text=center")
        c6.Text = "Qualification"
        c2.Text = "Date Obtained"
        c3.Text = "Result"
        'c5.Text = "Date Awarded (Expected to complete) dd/mm/yyyy"
        rowH.Cells.AddRange({c1, c6, c2, c3})
        'rowH.Cells.AddRange({c1, c2, c6, c3, c4, c5})

        tblQuals.Rows.Add(rowH)

        If IsPostBack Then
            Dim c As Control = GetPostBackControl(Me.Page)
            If c.GetType Is GetType(Button) Then
                If DirectCast(c, Button).Text = "Add Row" Then intCurrentQuals += 1
            End If
            If c.GetType Is GetType(Button) Then
                If (intCurrentQuals > 0) Then
                    If DirectCast(c, Button).Text = "Remove Row" Then intCurrentQuals -= 1
                End If
            End If
        End If

        For i = 0 To intCurrentQuals
            Dim row As New TableRow
            Dim cell1, cell2, cell3, cell4, cell5, cell6 As New TableCell
            'Dim ctl1, ctl2, ctl3, ctl4, ctl5, ctl6 As New StudentQualsOnEntryField
            Dim ctl2 As New DropDownList
            Dim ctl1, ctl3, ctl4, ctl5, ctl6 As New StudentQualsOnEntryField




            '----Start Here
            ctl1.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.QualID
            ctl1.StudentQualsOnEntryRowNumber = i
            ctl1.LabelWidth = 0
            ctl1.IsRequired = True
            cell1.Controls.Add(ctl1)

            Dim SQLDBDataReader As SqlClient.SqlDataReader
            Dim SQLDataTable As New DataTable
            Dim cmd As New SqlCommand
            Dim SQLCmd As New SqlClient.SqlConnection
            SQLCmd.ConnectionString = GetConn()
            SQLCmd.Open()
            cmd.CommandText = "PSWebenrolmentReports.dbo.spGetPossibleGrades"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = SQLCmd
            'cmd.Parameters.AddWithValue("countryID", CountryID.Value)
            SQLDBDataReader = cmd.ExecuteReader()

            ctl2 = New DropDownList()
            ctl2.CssClass = "form-control"
            cell2.Controls.Add(ctl2)
            ctl2.Items.Clear()

            ctl2.Items.Add(New ListItem("", ""))

            While SQLDBDataReader.Read()
                ctl2.Items.Add(New ListItem(
                SQLDBDataReader("Description").ToString(),
                SQLDBDataReader("Code").ToString()
            ))
            End While

            SQLCmd.Close()
            SQLDBDataReader.Close()


            'ctl2.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.QualID
            'ctl2.StudentQualsOnEntryRowNumber = i
            'ctl2.LabelWidth = 0
            'cell2.Controls.Add(ctl2)

            ctl6.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.DateAwarded
            ctl6.StudentQualsOnEntryRowNumber = i
            ctl6.LabelWidth = 0
            ctl6.IsRequired = False
            'ctl6.Placeholder = "e.g.GCSE,NVQ 2,A Level etc"
            cell6.Controls.Add(ctl6)

            ctl3.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.Grade
            ctl3.StudentQualsOnEntryRowNumber = i
            ctl3.LabelWidth = 0
            cell3.Controls.Add(ctl3)

            '---End Here

            'ctl4.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.PredictedGrade
            'ctl4.StudentQualsOnEntryRowNumber = i
            'ctl4.LabelWidth = 0
            'cell4.Controls.Add(ctl4)

            'ctl5.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.DateAwarded
            'ctl5.StudentQualsOnEntryRowNumber = i
            'If WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            '    ctl5.IsRequired = True
            'End If
            'ctl5.LabelWidth = 0
            'cell5.Controls.Add(ctl5)

            'row.Cells.AddRange({cell1, cell2, cell6, cell3, cell4, cell5})
            row.Cells.AddRange({cell1, cell2, cell6, cell3})
            tblQuals.Rows.Add(row)

        Next

    End Sub
    Public Overrides Sub ValidateControl()

        'Response.Write(tblQuals.Rows.Count)
        For i = 1 To tblQuals.Rows.Count - 1
            If tblQuals.Rows(i).Cells(0).Controls(0).GetType Is GetType(StudentQualsOnEntryField) Then
                Dim subject As String = DirectCast(tblQuals.Rows(i).Cells(0).Controls(0), StudentQualsOnEntryField).Value
                Dim qual As String = DirectCast(tblQuals.Rows(i).Cells(1).Controls(0), DropDownList).SelectedItem.Value
                Dim dateObtained = DirectCast(tblQuals.Rows(i).Cells(2).Controls(0), StudentQualsOnEntryField).Value
                Dim result = DirectCast(tblQuals.Rows(i).Cells(3).Controls(0), StudentQualsOnEntryField).Value

                'Response.Write(subject)
            End If
        Next

        'MyBase.ValidateControl()
        'Dim str As String
        'Dim str1 As String
        'Dim count As Integer = 0
        'For i = 1 To tblQuals.Rows.Count - 1
        '    str = String.Empty
        '    If tblQuals.Rows(i).Cells(0).Controls(0).GetType Is GetType(StudentQualsOnEntryField) Then
        '        str = DirectCast(tblQuals.Rows(i).Cells(0).Controls(0), StudentQualsOnEntryField).Value
        '        str1 = DirectCast(tblQuals.Rows(i).Cells(1).Controls(0), StudentQualsOnEntryField).Value
        '        If str IsNot Nothing Then
        '            If str.Length = 0 Then
        '                count = count + 1
        '            End If

        '            If str1 IsNot Nothing Then
        '                If str1.Length > 0 And str.Length = 0 Then
        '                    count = count - 1
        '                End If
        '            End If
        '        End If
        '    End If
        'Next
        'If WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
        '    If count > 0 Then
        '        Dim v As New CustomValidator()
        '        v.ErrorMessage = "Please select a Qualification"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        'End If
    End Sub


    Public Property intCurrentQuals() As Integer
        Get
            Return CInt(HttpContext.Current.Session("intQualRows"))
        End Get
        Set(ByVal value As Integer)
            HttpContext.Current.Session("intQualRows") = value
        End Set
    End Property

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click


        Me.Page.Validate()
        For i = 1 To tblQuals.Rows.Count - 1
            If tblQuals.Rows(i).Cells(0).Controls(0).GetType Is GetType(StudentQualsOnEntryField) Then
                Dim subject As String = DirectCast(tblQuals.Rows(i).Cells(0).Controls(0), StudentQualsOnEntryField).Value
                Dim qual As String = DirectCast(tblQuals.Rows(i).Cells(1).Controls(0), DropDownList).SelectedItem.Value
                Dim dateObtained = DirectCast(tblQuals.Rows(i).Cells(2).Controls(0), StudentQualsOnEntryField).Value
                Dim result = DirectCast(tblQuals.Rows(i).Cells(3).Controls(0), StudentQualsOnEntryField).Value

                'Response.Write(subject)
                'Response.Write(qual)
                'Response.Write(dateObtained)
                'Response.Write(result)

                WorkingData.ApplicationRequestQualsOnEntryRow.QualID = qual
                WorkingData.ApplicationRequestQualsOnEntryRow.Subject = subject

                Dim enumerator As IEnumerator = WorkingData.ApplicationRequestQualsOnEntry.Rows.GetEnumerator

                While enumerator.MoveNext()
                    'Response.Write(enumerator.Current.GetType)
                End While


                Dim parsedDate As DateTime
                If DateTime.TryParseExact(
                    dateObtained,
                    "dd/mm/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    parsedDate
                ) Then
                    WorkingData.ApplicationRequestQualsOnEntryRow.DateAwarded = parsedDate

                End If

                WorkingData.ApplicationRequestQualsOnEntryRow.Grade = result





            End If
        Next



        If Me.Page.IsValid Then
            Response.Write(WorkingData.ShoppingCart.ContainsItemsOfType("Application"))
            If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_aspx"))
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_aspx"))
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                Response.Redirect(GetResourceValue("personalstatement_aspx"))
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_enquiry"))
            End If
        End If
    End Sub


    Protected Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click



        'If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
        '    Response.Redirect(GetResourceValue("checkout_attachments_aspx"))

        'ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
        '    Dim age As Integer
        '    age = Today.Year - Convert.ToDateTime(WorkingData.ApplicationRequestRow.DateOfBirth).Year
        '    If (age > 19) Then
        '        Response.Redirect(GetResourceValue("checkout_applications2_aspx"))
        '    Else
        '        Response.Redirect(GetResourceValue("checkout_parentguardian_aspx"))
        '    End If
        'End If
        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Redirect(GetResourceValue("checkout_attachments_aspx"))

        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Dim age As Integer
            age = Today.Year - Convert.ToDateTime(WorkingData.ApplicationRequestRow.DateOfBirth).Year
            Response.Redirect(GetResourceValue("residencystatus_aspx"))
        End If
    End Sub
End Class
