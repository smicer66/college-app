Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class checkout_dataprotection
    Inherits CheckoutBaseControl


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)


        'Breadcrumbs
        If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            breadcrumbenrols.Visible = True
            breadcrumbapps.Visible = False
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = True
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            breadcrumbenrols.Visible = True
            breadcrumbapps.Visible = False
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = False
        Else
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = False
        End If

        Dim p As New PaymentSubmitter

        If p.ShouldTransferToPaymentSite AndAlso System.Configuration.ConfigurationManager.AppSettings("UsePayPal") = "1" Then
            btnContinue.ImageResource = "PayPalButton"
        End If
    End Sub

    Public Overrides Sub ValidateControl()
	
	If StudentSignature.Signature Is Nothing Then

		Dim v As New CustomValidator()
            v.ErrorMessage = "Please complete your signature."
            v.IsValid = False
            Me.Page.Validators.Add(v)

            Me.ValidationSummary1.ShowSummary = True

	Else
		WorkingData.EnrolmentRequestRow.StudentSignature = StudentSignature.Signature

	End If
	

	


        If Not chkConfirm.Checked Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please confirm that you have read the declaration above."
            v.IsValid = False
            Me.Page.Validators.Add(v)

            Me.ValidationSummary1.ShowSummary = True
        End If


	'AcceptMarketingConsent
	If drpAcceptMarketingConsent.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option whether we can contact you"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else


	    If drpAcceptMarketingConsent.SelectedValue = "True" Then
                WorkingData.EnrolmentRequestRow.AcceptMarketingConsent = True
            Else
                WorkingData.EnrolmentRequestRow.AcceptMarketingConsent = False
            End If

        End If

	'AcceptShareInfoConsent
	If drpAcceptShareInfoConsent.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option whether external agencies can contact you for surveys, research or learning opportunities"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else


	    If drpAcceptShareInfoConsent.SelectedValue = "True" Then
                WorkingData.EnrolmentRequestRow.AcceptShareInfoConsent = True
            Else
                WorkingData.EnrolmentRequestRow.AcceptShareInfoConsent = False
            End If




		'if external can contact at least one option needs to be checked
		If drpAcceptShareInfoConsent.SelectedValue = "True" Then

			If chkPhone.Checked = False And chkEmail.Checked = False And chkPost.Checked = False Then

				Dim v As New CustomValidator()
            			v.ErrorMessage = "Please select at least one contact option for external agencies."
            			v.IsValid = False
            			Me.Page.Validators.Add(v)

           		 	Me.ValidationSummary1.ShowSummary = True

			Else

				'update checked items on db:
				WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByTelephone = chkPhone.Checked
				WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByEmail = chkEmail.Checked
				WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByPost = chkPost.Checked

			End If




		End If



        End If

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click

        '   If divStatement.Visible = True Then WorkingData.EnrolmentRequestRow.StudentDeclaration = personalstatement.Text

        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Redirect(GetResourceValue("checkout_attachments_aspx"))

        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then

            Response.Redirect(GetResourceValue("checkout_quals_on_entry_aspx"))

        End If
    End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        ValidateControl()

        If Me.Page.IsValid Then
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined45 = ""
            Server.Transfer(GetResourceValue("checkout_makepayment_aspx"))

	Else
		StudentSignature.SignatureHiddenValue = "" 'hides the hidden value of the signature so you have to sign again

        End If

    End Sub

End Class
