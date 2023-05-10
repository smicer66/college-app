

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit


Partial Class webcontrols_checkout_enrolments2
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        Response.Write(WorkingData.EnrolmentRequestRow.StudentDetailUserDefined25)
        'If Not Session("agecourse") Is Nothing Then lblAgeCourse.Text = CType("Your age on " & Session("startdate") & ": " & Session("agecourse") & " (" & Session("ageGroup"), String) & ")"

        If Not IsPostBack Then
            If Session("euro") <> "" Then selectEuro.SelectedValue = Session("euro")
            If Session("dis") <> "" Then selectLearnDiff.SelectedValue = Session("dis")
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined24 <> "" Then ddlDSA.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined24
        End If

        ' postcode.Value = WorkingD ata.EnrolmentRequestRow.PostcodeOut & WorkingData.EnrolmentRequestRow.PostcodeIn

        MyBase.OnLoad(e)
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        Session("euro") = selectEuro.SelectedValue
        Session("dis") = selectLearnDiff.SelectedValue
        If Session("euro") = "1" Then WorkingData.EnrolmentRequestRow.EuroResidentID = True
        If Session("euro") = "2" Then WorkingData.EnrolmentRequestRow.EuroResidentID = False
        If Session("dis") <> "" Then WorkingData.EnrolmentRequestRow.LearningDiffOrDisID = Session("dis")
        WorkingData.EnrolmentRequestRow.StudentDetailUserDefined24 = ddlDSA.SelectedValue
        ' If WorkingData.ShoppingCart.Items.Count = 0 Then
        'Server.Transfer(GetResourceValue("logout"))
        'Else
        Response.Redirect(GetResourceValue("checkout_employment_HE_aspx"))
        ' End If


    End Sub
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        ' Me.Page.Validate()

        Session("euro") = selectEuro.SelectedValue
        Session("dis") = selectLearnDiff.SelectedValue
        If Session("euro") = "1" Then WorkingData.EnrolmentRequestRow.EuroResidentID = True
        If Session("euro") = "2" Then WorkingData.EnrolmentRequestRow.EuroResidentID = False
        If Session("dis") <> "" Then WorkingData.EnrolmentRequestRow.LearningDiffOrDisID = Session("dis")

        WorkingData.EnrolmentRequestRow.StudentDetailUserDefined24 = ddlDSA.SelectedValue
        ' If WorkingData.ShoppingCart.Items.Count = 0 Then
        ' Server.Transfer(GetResourceValue("logout"))
        'Else
        Response.Redirect(GetResourceValue("checkout_parentguardian_HE_aspx"))
        ' End If

        'End If

    End Sub

    Public Overrides Sub ValidateControl()
        'Response.Write(selectEuro.SelectedValue)
        If selectLearnDiff.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please answer the question 'Do you consider yourself to have a learning difficulty or disability'"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If selectLearnDiff.SelectedValue = "1" And CType("" & WorkingData.EnrolmentRequestRow.DisabilityCategory1ID, String) = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please provide a primary learning / disabilities' "
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        If selectEuro.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "* Have you lived in the UK for the last 3 years?"
            'rdoEuro.CssClass = "error"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If ddlDSA.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "* Are you receiving Disability Student Allowance?"
            'rdoEuro.CssClass = "error"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        '' Or CType("" & WorkingData.EnrolmentRequestRow.EuroResidentID, String) = "2")
        'If (selectEuro.SelectedValue = "2" And fldDateEntry.Value = "") Then
        '    Dim v As New CustomValidator
        '    v.ErrorMessage = "Please state when did you move to the UK/EU? "
        '    v.IsValid = False
        '    'fldDateEntry.Style.Add("border", "1px solid red")
        '    Me.Page.Validators.Add(v)
        'End If
        'If fldDateEntry.Value <> "" Then

        '    If IsDate(fldDateEntry.Value) Then
        '        If CDate(fldDateEntry.Value) > Date.Now() Then
        '            Dim v As New CustomValidator
        '            v.ErrorMessage = "When did you move to the UK/EE cannot be in the future. "
        '            v.IsValid = False
        '            'fldDateEntry.Style.Add("border", "1px solid red")
        '            Me.Page.Validators.Add(v)
        '        End If
        '    End If
        'End If

        MyBase.ValidateControl()
    End Sub
End Class


