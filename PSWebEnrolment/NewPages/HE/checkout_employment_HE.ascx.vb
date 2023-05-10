Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class webcontrols_checkout_employment
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not (IsPostBack) Then

            If WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID <> "" Then selectEmployed.SelectedValue = WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID
            If WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentIntensityID <> "" Then selectEmploymentIntensity.SelectedValue = WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentIntensityID
            If WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfEmploymentID <> "" Then selectEmploymentLength.SelectedValue = WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfEmploymentID
            If WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfUnemploymentID <> "" Then selectLengthUnemployed.SelectedValue = WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfUnemploymentID
            If WorkingData.EnrolmentRequestEmploymentHistoryRow.BenefitStatusIndicatorID <> "" Then selectBenefits.SelectedValue = WorkingData.EnrolmentRequestEmploymentHistoryRow.BenefitStatusIndicatorID
            ddlFee.SelectedValue = WorkingData.EnrolmentRequestRow.EnrolmentUserDefined11
            If WorkingData.EnrolmentRequestEmploymentHistoryRow.IsSelfEmployed Then
                    rdoSelfEmp.SelectedValue = 1
                Else
                    rdoSelfEmp.SelectedValue = 0
                End If

            End If



    End Sub

    Public Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        If Me.Page.IsValid Then

            'Response.Write("---" + selectEmployed.SelectedValue)
            'WorkingData.EnrolmentRequestEmploymentHistory.NewRow()
            WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID = selectEmployed.SelectedValue
            WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentIntensityID = selectEmploymentIntensity.SelectedValue
            WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfEmploymentID = selectEmploymentLength.SelectedValue
            WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfUnemploymentID = selectLengthUnemployed.SelectedValue
            WorkingData.EnrolmentRequestEmploymentHistoryRow.BenefitStatusIndicatorID = selectBenefits.SelectedValue

            If rdoSelfEmp.SelectedValue.ToString.Length > 0 Then
                    WorkingData.EnrolmentRequestEmploymentHistoryRow.IsSelfEmployed = rdoSelfEmp.SelectedValue
                End If
            WorkingData.EnrolmentRequestRow.EnrolmentUserDefined11 = ddlFee.SelectedValue
            Response.Redirect(GetResourceValue("checkout_attachments_he_aspx"))
            '  Response.Redirect(GetResourceValue("checkout_attachments"))


        End If

    End Sub


    Public Overrides Sub ValidateControl()
        If ddlFee.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please tell us Who is paying for the annual course fee"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        'If ddlFee.SelectedValue = "3" Then
        '    If WorkingData.EnrolmentRequestEmploymentHistoryRow.EmployerName = "" Then
        '        Dim v As New CustomValidator
        '        v.ErrorMessage = "Please tell us your Employer Name"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        '    If WorkingData.EnrolmentRequestEmploymentHistoryRow.ContactTel = "" Then
        '        Dim v As New CustomValidator
        '        v.ErrorMessage = "Please provide us with your Employers Telelphone"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        '    If WorkingData.EnrolmentRequestEmploymentHistoryRow.Email = "" Then
        '        Dim v As New CustomValidator
        '        v.ErrorMessage = "Please provide us with your Employers email"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        'End If
        If selectEmployed.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "* Please tell us your employment status"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If selectEmployed.SelectedValue = "11" Or selectEmployed.SelectedValue = "12" Then
            If selectLengthUnemployed.SelectedValue = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* Length of of time umemployed must be provided"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If (selectBenefits.SelectedValue = "") Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* Please either select the benefits you are receiving"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
        End If
        If selectEmployed.SelectedValue = "10" Then
            If selectEmploymentIntensity.SelectedValue = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* Hours per week must be provided"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If selectEmploymentLength.SelectedValue = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* Length of time in employment must be provided"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If Not IsDate(WorkingData.EnrolmentRequestEmploymentHistoryRow.DateFrom) Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* Employment from date must be proivded"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            ''Employed check for EII and LOE and SelfEmp
            If Not (rdoSelfEmp.SelectedValue = "1" Or rdoSelfEmp.SelectedValue = "0") Then

                Dim a As New CustomValidator
                a.IsValid = False
                a.ErrorMessage = "If you are Employed, are you self employed?"
                Me.Page.Validators.Add(a)
                ValidationSummary1.CssClass = "error"

            End If
            If (WorkingData.EnrolmentRequestRow.SocioEconomicClassID = "") Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* Which best describes your occupation?"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If (WorkingData.EnrolmentRequestRow.SOCOccupationID = "") Then
                Dim v As New CustomValidator
                v.ErrorMessage = "* What industry do you work in?"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
        End If
        'If WorkingData.EnrolmentRequestRow.HEQualsOnEntryID = "" Then
        '    Dim v As New CustomValidator
        '    v.ErrorMessage = "* Select the highest qualification that you have achieved from the list"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        'End If
        MyBase.ValidateControl()
    End Sub

End Class
