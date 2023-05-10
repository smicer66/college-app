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


    End Sub


</script>