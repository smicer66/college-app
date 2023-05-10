Imports Microsoft.VisualBasic

Public Module Library
    Dim m_WebSiteMode As WebSiteMode

    Public Property CurrentWebSiteMode() As WebSiteMode
        Get
            Return m_WebSiteMode
        End Get
        Set(ByVal value As WebSiteMode)
            m_WebSiteMode = value
        End Set
    End Property

    Public Function GetResourceValue(ByVal resourceKey As String) As String
        'Get the value text from the resources file
        Return CStr(Web.HttpContext.GetGlobalResourceObject("Resource", resourceKey))
    End Function
    Public Function GetConn() As String
        'Get the value text from the resources file
        Return CStr("Data Source=(local); initial Catalog=pswebenrolmentreports;User Id=Ripple;Password=P5web3")
    End Function
End Module





