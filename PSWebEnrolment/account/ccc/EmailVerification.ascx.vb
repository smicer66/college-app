Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Net.Mail

Partial Class account_ccc_EmailVerification
    Inherits webenrolmentcontrolvalidate


    Property Email As String
    Property Verification As String


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Email = Request("Email")
        Verification = Request("vc")

        Dim result As VerficationResult = WebUserDataTable.CheckVerificationCodeIsValid(Email, Verification)

        Select Case result
            Case VerficationResult.Verified
                Dim tblWebUser As WebUserDataTable = WorkingData.WebUser
                Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblWebUser)
                v.Columns.AddDBColumns(False, False)
                v.Filters.SetColumnFilter(tblWebUser.EmailColumn, Email)
                tblWebUser.TableAdapter.Load(tblWebUser, v)

                'WorkingData.CurrentLoggedOnUserRow = row
                Response.Redirect(GetResourceValue("AccountCreated"))
            Case VerficationResult.Failed
                Dim v As New CustomValidator()
                v.ErrorMessage = "Verification Code does not match. Please check and try again."
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True

            Case VerficationResult.AlreadyVerified
                Response.Redirect(GetResourceValue("UserAccount"))
            Case VerficationResult.Expired
                Dim v As New CustomValidator()
                v.ErrorMessage = "Verification Code has expired."
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
                ResendVerification.Visible = True
            Case VerficationResult.UserNotFound
                Dim v As New CustomValidator()
                v.ErrorMessage = "User not found. Please try to register again."
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
        End Select



    End Sub

    Protected Sub ResendVerification_Click(sender As Object, e As EventArgs) Handles ResendVerification.Click
        Dim StringMessage As String

        CCCCheck.CheckNotNothing(Email, "Email")
        Dim tblWebUser As WebUserDataTable = WorkingData.WebUser
        Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblWebUser)
        v.Columns.AddDBColumns(False, False)
        v.Filters.SetColumnFilter(tblWebUser.EmailColumn, Email)
        tblWebUser.TableAdapter.Load(tblWebUser, v)

        Dim row As WebUserRow = tblWebUser(0)
        row.VerificationCode = Guid.NewGuid
        row.VerificationStatusID = 0
        tblWebUser.TableAdapter.Save(row.Table)

        Dim WebMail As New SmtpClient("")
        Dim mailMessage As New MailMessage()
        mailMessage.[To].Add(Email)
        mailMessage.Subject = "Email Verification Requested"

        StringMessage = "Hi<br />"
        StringMessage += "You have requested to reset your password in order to safely access your online enrolment.<br/>"
        StringMessage += String.Format("Please click on link or copy this link into an internet browser to create a password and begin enrolment. <br />Please pick a strong memorable password: {0}", ResolveUrl(Me.Context.Request.Url.Scheme + "://" + Me.Context.Request.Url.Authority + "/PSWebEnrolment/webenrolment.aspx?page=~/account/ccc/DoPasswordReset.ascx&Email=" & Request.Form("pre[email]") & "&vc=" & row.VerificationCode.ToString))
        StringMessage += "<br />Yours sincerely,<br />"
        StringMessage += "Admissions<br />"
        StringMessage += "Admissions.Team@cityofbristol.ac.uk<br />"
        StringMessage += "01173125000<br />"

        mailMessage.Body = String.Format(StringMessage, ResolveUrl(Me.Context.Request.Url.Scheme + "://" + Me.Context.Request.Url.Authority + Replace(Me.Context.Request.ApplicationPath, "/", "") + "/webenrolment.aspx?page=~/account/ccc/EmailVerification.ascx&Email=" & Email & "&vc=" & row.VerificationCode.ToString))

        WebMail.Send(mailMessage)
        altSuccess.Visible = True
        ResendVerification.Enabled = False
    End Sub
End Class
