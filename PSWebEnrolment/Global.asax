<%@ Application Language="VB" %>
<%@ Import Namespace="CompassCC.CCCSystem.CCCCommon" %>
<%@ Import Namespace="CompassCC.ProSolution.PSWebEnrolmentKit" %>

<script runat="server">

    Dim m_blnInitialised As Boolean

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup

        Initialise()

        m_blnInitialised = True

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Try
            'Get the last error that occured and save it in a session
            Dim exceptionContainer As Exception = Server.GetLastError

            'Write the error to the session if it is available
            If Not System.Web.HttpContext.Current.Session Is Nothing Then
                Session("LastError") = exceptionContainer

                'Need to do this to not destroy the session
                Server.ClearError()

                Response.Redirect("~/GenericError.aspx")
            End If

        Catch ex As Exception
            Diagnostics.Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started

        If Not m_blnInitialised Then
            'In case of errors during startup (E.g. Database server not running)
            Initialise()
            m_blnInitialised = True
        End If

        Session.LCID = 2057 'Set Locale to UK (Ignoring regional settings of computer)

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

    Private Sub Initialise()

        CCCDataCache.DisableAllCaching = True

        CCCDataCache.DisableAllCaching = True
        CCCConfigLibrary.ReadConfigFromConfigFile(IO.Path.Combine(HttpRuntime.AppDomainAppPath, "web.config"))
        CCCConfigLibrary.ReadConfigFromConfigFile(IO.Path.Combine(HttpRuntime.AppDomainAppPath, "web.dbconfig"))
        CCCConfigLibrary.ReadConfigFromMyAppDBConfigFile()
        CCCDatabaseConnectInfoList.LoadDatabaseInfoFromConfig()

        'Set timeout values from config
        CCCConfigLibrary.SetAllFrameworkValuesFromConfig()

        CCCObjectFactory.InitialiseForAssembly(GetType(CompassCC.ProSolution.PSWebEnrolmentKit.EnrolmentRequestDataTable).Assembly, AssemblyType.Business)


        Dim bla As CCCDatabaseConnectInfo() = CCCDatabaseConnectInfoList.GetDatabaseConnectInfos()


        For Each e As CCCDatabaseConnectInfo In bla
            Dim test As String = e.ServerName

        Next


        'Configure/check connections
        Dim rules As CCCBrokenRulesList = CCCDatabaseConnectionLibrary.CheckDBConnectionInfos(CCCDatabaseConnectInfoList.GetDatabaseConnectInfos(), False)
        If Not rules.IsAllValid Then
            Throw New CCCTechnicalException("One or more database connections is not valid: " & rules.GetBrokenRulesText())
        End If

        If CCCDatabaseConnectInfo.DefaultDatabaseDBInfo IsNot Nothing Then
            'Load metadata from default database
            CCCMetaData.InitialiseForDatabase(CCCDatabaseConnectInfo.DefaultDatabaseDBInfo)

        End If

        PaymentSubmitter.ShouldMakeNewApplicationForEachOffering = True
        CCCWebField.ShouldCreateRequiredFieldIcon = False
        'CCCWebField.UseHTMLRequiredFieldValidation = true
        PaymentSubmitter.ShouldValidateAge = False
        PaymentSubmitter.MinimumAge = 16
        CheckoutBaseControl.ShouldCheckBasketNotEmpty = False
        PaymentSubmitter.AllowEmptyBasket = True


        WorkingData.Provider = New SessionWorkingDataProvider 'ProfileWorkingDataProvider '

        PaymentSubmitter.ShouldSendEmailConfirmation = True


        SystemSettings.SaveForLater = False ''CCCPS-80182: New setting to control Save for Later feature.

        ''Set particular configuration to 0 to bypass the check (for example, set MinUpperCaseRequired = 0 to let user set password without any upper case character(s). 
        PasswordValidation.EnableNewPolicy = False
        PasswordValidation.MinLength = 7
        PasswordValidation.MinUpperCaseRequired = 1
        PasswordValidation.MinLowerCaseRequired = 1
        PasswordValidation.MinNumericRequired = 1
        PasswordValidation.MinNonAlphaNumRequired = 1

        SystemSettings.PreloadStudentInfo = False ''CCCPS-81074: New setting to control Pre-loading of student info via PS student record.

        'CCCPS-81189 - Image resizer settings. To reduce the size of image.
        SystemSettings.UseImageResizeFeature = False
        'Note that achieving an exact file size can be challenging due to the nature of image compression algorithms And variations in image content. 
        'The resulting file size may still have slight variations. So for such images size can be little bigger than mentioned below.
        SystemSettings.MaxReducedImageSize = 500000  'In Bytes only. i.e. given is 500KB

    End Sub

    ''' <summary>
    ''' CCCPS-78455 add samesite to cookies (same was already done in PS Web - CCCPS-78449)
    ''' </summary>
    Protected Sub Application_PreSendRequestHeaders()
        Dim IsSameSiteEnabled As String = ConfigurationManager.AppSettings("SameSiteToCookie")
        If Context IsNot Nothing AndAlso IsSameSiteEnabled = "1" Then
            Dim cookieValueSuffix = "; Secure; SameSite=none"
            Dim cookies = Context.Response.Cookies

            For i = 0 To cookies.Count - 1
                Dim cookie = cookies(i)
                cookie.Value += cookieValueSuffix
            Next
        End If
    End Sub

</script>