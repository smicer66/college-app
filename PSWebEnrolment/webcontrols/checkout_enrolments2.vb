

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class webcontrols_checkout_enrolments2
    Inherits CheckoutBaseControl
    Protected Overrides Sub OnLoad(e As EventArgs)
        Response.Write(WorkingData.EnrolmentRequestRow.StudentDetailUserDefined25)
        'If Not Session("agecourse") Is Nothing Then lblAgeCourse.Text = CType("Your age on " & Session("startdate") & ": " & Session("agecourse") & " (" & Session("ageGroup"), String) & ")"

        If Not IsPostBack Then
            If Session("euro") <> "" Then selectEuro.SelectedValue = Session("euro")
        End If
        If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3 <> "" Then selectEnterforEducation.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3
        ' postcode.Value = WorkingD ata.EnrolmentRequestRow.PostcodeOut & WorkingData.EnrolmentRequestRow.PostcodeIn

        MyBase.OnLoad(e)
    End Sub
    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        If selectEuro.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please answer the question '* Have you lived in the UK legally for at least the last three years ?'"
            'rdoEuro.CssClass = "error"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        If selectEnterforEducation.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please answer the question '*  Did you enter the UK from another country mainly to receive education?'"
            'rdoEuro.CssClass = "error"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        If (selectEuro.SelectedValue = "2" And fldDateEntry.Value = "") Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please answer the question '* What date did you arrive in the UK ?' "
            v.IsValid = False
            'fldDateEntry.Style.Add("border", "1px solid red")
            Me.Page.Validators.Add(v)
        End If
        If (selectEuro.SelectedValue = "2" And WorkingData.EnrolmentRequestRow.VisaTypeID Is Nothing) Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please answer the question '* Do you have pre-settled or settled status' "
            v.IsValid = False
            'fldDateEntry.Style.Add("border", "1px solid red")
            Me.Page.Validators.Add(v)
        End If
        If fldDateEntry.Value <> "" Then

            If IsDate(fldDateEntry.Value) Then
                If CDate(fldDateEntry.Value) > Date.Now() Then
                    Dim v As New CustomValidator
                    v.ErrorMessage = "* When did you move to the UK cannot be in the future. "
                    v.IsValid = False
                    'fldDateEntry.Style.Add("border", "1px solid red")
                    Me.Page.Validators.Add(v)
                End If
            End If
        End If

        'Criminal Conviction
        If drpCriminal.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option for Criminal Convictions"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else
            'WorkingData.EnrolmentRequestRow.StudentDetailUserDefined4 = drpCriminal.SelectedValue
            WorkingData.EnrolmentRequestRow.CriminalConvictionID = Convert.toInt32(drpCriminal.SelectedValue)
        End If


    End Sub
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        Session("euro") = selectEuro.SelectedValue
        If Session("euro") = "1" Then WorkingData.EnrolmentRequestRow.EuroResidentID = True
        If Session("euro") = "2" Then WorkingData.EnrolmentRequestRow.EuroResidentID = False
        WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3 = selectEnterforEducation.SelectedValue
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click


        Session("euro") = selectEuro.SelectedValue
        If Session("euro") = "1" Then WorkingData.EnrolmentRequestRow.EuroResidentID = True
        If Session("euro") = "2" Then WorkingData.EnrolmentRequestRow.EuroResidentID = False

    End Sub

End Class
