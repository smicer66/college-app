Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Net.Mail


Partial Class account_ccc_PasswordReset
    Inherits webenrolmentcontrolvalidate

    Protected Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click

        CCCCheck.CheckNotNothing(Request.Form("pre[email]"), "Email")
        Dim row As WebUserRow = WebUserDataTable.FindUserRow(Request.Form("pre[email]"))

        If Not row Is Nothing Then
            If row.VerificationStatusID = 0 Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Access has not been verified. We have re-sent you a verification code, please check your email."
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True

                ResendVerificationCode()

                Exit Sub
            End If

            row.VerificationCode = Guid.NewGuid
            row.VerificationStatusID = 2
            row.Table.TableAdapter.Save(row.Table)

            Dim WebMail As New SmtpClient("")
            Dim mailMessage As New MailMessage()

            'mailMessage.Subject = "Email Verification requested"

            Dim StringMessage As String

            StringMessage = "Hi<br />"
            StringMessage += "You have requested to reset your password in order to safely access your online enrolment.<br/>"
            StringMessage += String.Format("Please click on link or copy this link into an internet browser to create a password and begin enrolment. <br />Please pick a strong memorable password: {0}", ResolveUrl(Me.Context.Request.Url.Scheme + "://" + Me.Context.Request.Url.Authority + "/PSWebEnrolment/webenrolment.aspx?page=~/account/ccc/DoPasswordReset.ascx&Email=" & Request.Form("pre[email]") & "&vc=" & row.VerificationCode.ToString))
            StringMessage += "<br />Yours sincerely,<br />"
            StringMessage += "Admissions<br />"
            StringMessage += "Admissions.Team@cityofbristol.ac.uk<br />"
            StringMessage += "01173125000<br />"


            mailMessage.[To].Add(Request.Form("pre[email]"))

            mailMessage.IsBodyHtml = True

            mailMessage.Subject = "Email verification requested to College online enrolment"
            mailMessage.Body = StringMessage

            WebMail.Send(mailMessage)

            altSuccess.Visible = True
            btnResetPassword.Enabled = False
        Else
            Dim v As New CustomValidator()
            v.ErrorMessage = "User not found. Check if your email is the one registered with the College. Online enrolment is only available to users who have been invited to enrol online."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If
    End Sub


    Private Sub ResendVerificationCode()
        CCCCheck.CheckNotNothing(Request.Form("pre[email]"), "Email")
        Dim row As WebUserRow = WebUserDataTable.FindUserRow(Request.Form("pre[email]"))

        If Not row Is Nothing Then
            If row.VerificationStatusID = 1 Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Account already verified, please log in to continue."
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True

                Exit Sub
            End If

            row.VerificationCode = Guid.NewGuid
            row.VerificationStatusID = 0
            row.Table.TableAdapter.Save(row.Table)

            Dim WebMail As New SmtpClient("")
            Dim mailMessage As New MailMessage()

            'mailMessage.Subject = "Email Verification requested"

            Dim StringMessage As String
            StringMessage = "Hi<br />"
            StringMessage += "You have requested a reset password in order to login safely to the online enrolment system.<br/>"
            StringMessage += String.Format("Please click this link to verify your email address and to pick a strong memorable password: {0}", ResolveUrl(Me.Context.Request.Url.Scheme + "://" + Me.Context.Request.Url.Authority + "/psweb16/webenrolment.aspx?page=~/account/ccc/DoPasswordReset.ascx&Email=" & Request.Form("pre[email]") & "&vc=" & row.VerificationCode.ToString))
            StringMessage += "<br />Yours sincerely,<br />"
            StringMessage += "<br />"
            StringMessage += "Admissions.Team@cityofbristol.ac.uk"

            mailMessage.[To].Add(Request.Form("pre[email]"))
            mailMessage.From = New MailAddress("Admissions.Team@cityofbristol.ac.uk")
            mailMessage.IsBodyHtml = True

            mailMessage.Subject = "Email verification requested to College online enrolment"
            mailMessage.Body = StringMessage

            WebMail.Send(mailMessage)
        Else
            Dim v As New CustomValidator()
            v.ErrorMessage = "User not found. Check if your email is the one registered with the College. Online enrolment is only available to users who have been invited to enrol online."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If
    End Sub

End Class
