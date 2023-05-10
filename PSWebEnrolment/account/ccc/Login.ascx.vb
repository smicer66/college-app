Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class account_ccc_Login
    Inherits webenrolmentcontrolvalidate

    Private m_errortext As String

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        m_errortext = ""
        ValidateControl()

        If Me.Page.IsValid Then
            Dim tblWebUser As WebUserDataTable = WorkingData.WebUser
            Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblWebUser)
            v.Columns.AddDBColumns(False, False)
            v.Filters.SetColumnFilter(tblWebUser.EmailColumn, Request.Form("pre[email]"))
            tblWebUser.TableAdapter.Load(tblWebUser, v)

            If tblWebUser.Rows.Count = 1 Then
                'User already exists - log in
                Dim row As WebUserRow = tblWebUser(0)
                If row.IsLockedOut Then
                    tblWebUser.Clear()
                    m_errortext = "User locked out"
                    Exit Sub

                End If
                If row.VerificationStatusID = 0 Then
                    tblWebUser.Clear()
                    m_errortext = "Account verification pending, please check your emails for the verification link we sent."
                    lnkReSend.Visible = True
                    Exit Sub
                End If
                If CCCAuthenticationLibrary.DoesSpecifiedPasswordMatchEncryptedPassword(Request.Form("password"), row.Password) Then
                    ' WorkingData.CurrentLoggedOnUserRow = row
                    Response.Redirect(GetResourceValue("UserAccount"))
                Else
                    'password incorrect
                    tblWebUser.Clear()
                    m_errortext = "Incorrect password"
                End If

            Else
                m_errortext = "We cannot find this email address in our system, please try to register instead"




            End If
        End If

    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        errtext.InnerText = m_errortext
    End Sub

    Protected Overrides Sub OnPreRender(e As EventArgs)
        MyBase.OnPreRender(e)
        errtext.InnerText = m_errortext
    End Sub
End Class
