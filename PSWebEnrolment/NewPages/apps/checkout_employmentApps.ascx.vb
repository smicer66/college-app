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
            ' If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined43 = "True" Then chkOtherStateBen.checked = True
            ' If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined43 = "False" Then chkOtherStateBen.Checked = False
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined28 = "True" Then chkNoStateBen.Checked = True
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined28 = "False" Then chkNoStateBen.Checked = False
            personalstatement.Text = WorkingData.EnrolmentRequestRow.StudentDeclaration

            If WorkingData.EnrolmentRequestEmploymentHistoryRow.IsSelfEmployed Then
                rdoSelfEmp.SelectedValue = 1
            Else
                rdoSelfEmp.SelectedValue = 0
            End If

        End If


    End Sub
    Public Function FieldContains(Searchfor As String, SearchField As String, AllowNulls As Boolean) As Boolean

        If AllowNulls And Len(SearchField) = 0 Then Return True

        For Each strSearchFor As String In Searchfor.Split(";")
            If UCase(SearchField) = UCase(strSearchFor) Then
                Return True
            End If
        Next

        Return False

    End Function

    Public Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        WorkingData.EnrolmentRequestRow.StudentDeclaration = personalstatement.Text
        Me.Page.Validate()

        If Me.Page.IsValid Then



            'Response.Write("---" + selectEmployed.SelectedValue)
            'WorkingData.EnrolmentRequestEmploymentHistory.NewRow()
            WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID = selectEmployed.SelectedValue
            WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentIntensityID = selectEmploymentIntensity.SelectedValue
            WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfEmploymentID = selectEmploymentLength.SelectedValue

            WorkingData.EnrolmentRequestEmploymentHistoryRow.LengthOfUnemploymentID = selectLengthUnemployed.SelectedValue
            If WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID = "10" Then
                WorkingData.EnrolmentRequestEmploymentHistoryRow.BenefitStatusIndicatorID = "" 'selectBenefits.SelectedValue
            Else
                WorkingData.EnrolmentRequestEmploymentHistoryRow.BenefitStatusIndicatorID = selectBenefits.SelectedValue
            End If

            '  WorkingData.EnrolmentRequestRow.StudentDetailUserDefined43 = chkOtherStateBen.Checked
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined28 = chkNoStateBen.Checked
            If rdoSelfEmp.SelectedValue.ToString.Length > 0 Then
                WorkingData.EnrolmentRequestEmploymentHistoryRow.IsSelfEmployed = rdoSelfEmp.SelectedValue
            End If
            'If ddlFee.SelectedValue = "3" Then
            'Response.Redirect(GetResourceValue("checkout_attachments_FC_aspx"))
            'Else
            Response.Redirect(GetResourceValue("checkout_dataprotection_Apps_aspx"))

            '   End If
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        WorkingData.EnrolmentRequestRow.StudentDeclaration = personalstatement.Text
        Response.Redirect(GetResourceValue("checkout_quals_on_entry_Apps_aspx"))

    End Sub


    Public Overrides Sub ValidateControl()
        If WorkingData.EnrolmentRequestRow.StudentDeclaration = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please enter your work experience."
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        If selectEmployed.SelectedValue = "" Then
            Dim v As New CustomValidator
            v.ErrorMessage = "Please tell us your employment status"
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If
        If selectEmployed.SelectedValue = "11" Or selectEmployed.SelectedValue = "12" Then
            If selectLengthUnemployed.SelectedValue = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Length of of time unemployed must be provided"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If (selectBenefits.SelectedValue = "" And chkNoStateBen.Checked = False) Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Please either select the benefits you are receiving or tick no benefits"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
        End If
        If selectEmployed.SelectedValue = "10" Then
            If selectEmploymentIntensity.SelectedValue = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Hours per week must be provided"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If selectEmploymentLength.SelectedValue = "" Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Length of time in employment must be provided"
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
            If Not IsDate(WorkingData.EnrolmentRequestEmploymentHistoryRow.DateFrom) Then
                Dim v As New CustomValidator
                v.ErrorMessage = "Employment From date must be provided"
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

        End If

        MyBase.ValidateControl()
    End Sub

End Class
