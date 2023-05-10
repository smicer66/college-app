Partial Class GenericError
    Inherits System.Web.UI.Page

    Private Property ExceptionContainer() As Exception
        Get
            ExceptionContainer = DirectCast(Session("LastError"), Exception)
        End Get
        Set(ByVal value As Exception)
            Session("LastError") = value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not IsPostBack Then

            'display application version
            'lblVersion.Text = VersionManager.ApplicationVersion.Major & "." & VersionManager.ApplicationVersion.Minor & _
            '    "." & VersionManager.ApplicationVersion.Build

            Try

                'Get the error type
                If Not ExceptionContainer.InnerException Is Nothing Then

                    If ExceptionContainer.InnerException.GetType Is GetType(HttpUnhandledException) Then
                        ExceptionContainer = ExceptionContainer.GetBaseException
                    Else
                        ExceptionContainer = ExceptionContainer.InnerException
                    End If
                End If


                'Show the error on screen
                lblErrorType.Text = Replace(ExceptionContainer.GetType.ToString, ControlChars.NewLine, "<br/>")
                'Only try to get the referring page if there is one
                If Not Request.UrlReferrer Is Nothing Then
                    lblErrorPage.Text = Request.UrlReferrer.PathAndQuery.ToString
                End If
                lblErrorMessage.Text = Replace(ExceptionContainer.Message, ControlChars.NewLine, "<br/>")
                lblErrorLocation.Text = Replace(ExceptionContainer.StackTrace, ControlChars.NewLine, "<br/>")


                If ExceptionContainer.Message.Contains("Unable to get DataSource") Then
                    lblErrorType.Text = "Database connection error"
                    lblErrorMessage.Text = "Unable to connect to database with the specified connection details. The server was not found or is not accessible. "
                End If

                'catch any errors that might be caused by the error page itself
            Catch ex As Exception

                lblErrorType.Text = Replace(ex.GetType.ToString, ControlChars.NewLine, "<br/>")
                lblErrorPage.Text = Request.UrlReferrer.PathAndQuery.ToString
                lblErrorMessage.Text = Replace(ex.Message, ControlChars.NewLine, "<br/>")
                lblErrorLocation.Text = "Error on Error Page <br/>" & _
                                        Replace(ex.StackTrace, ControlChars.NewLine, "<br/>")


            End Try


        End If

    End Sub

End Class