

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit


Partial Class webcontrols_checkout_enrolments2
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)

        'If Not Session("agecourse") Is Nothing Then lblAgeCourse.Text = CType("Your age on " & Session("startdate") & ": " & Session("agecourse") & " (" & Session("ageGroup"), String) & ")"

        ' postcode.Value = WorkingD ata.EnrolmentRequestRow.PostcodeOut & WorkingData.EnrolmentRequestRow.PostcodeIn
        If Not IsPostBack Then
            If Session("dis") <> "" Then selectLearnDiff.SelectedValue = Session("dis")
        End If
        MyBase.OnLoad(e)
    End Sub


    Public Overrides Sub ValidateControl()

        Session("dis") = selectLearnDiff.SelectedValue
        If Session("dis") <> "" Then WorkingData.EnrolmentRequestRow.LearningDiffOrDisID = Session("dis")
        If WorkingData.EnrolmentRequestRow.Parent2PhoneNumber = "" And WorkingData.EnrolmentRequestRow.Parent2MobileTel = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please enter at least one Emergency Telephone number."
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        'Response.Write(selectEuro.SelectedValue)
        If WorkingData.EnrolmentRequestRow.LearningDiffOrDisID = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please answer the question 'Do you have any Special Education Needs or learning / disabilities'"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If WorkingData.EnrolmentRequestRow.LearningDiffOrDisID = "1" And CType("" & WorkingData.EnrolmentRequestRow.DisabilityCategory1ID, String) = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please provide a primary learning / disabilities' "
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If


        MyBase.ValidateControl()
    End Sub
End Class


