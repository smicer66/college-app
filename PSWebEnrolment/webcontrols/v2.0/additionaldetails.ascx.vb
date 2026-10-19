'Option Explicit On
'Option Strict On

Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class additionaldetails
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False
        'Response.Write(Page.Session("TCaringResponsibilities"))

        If Not IsPostBack Then
            If WorkingData.ApplicationRequestRow.LookedAfter IsNot Nothing Then
                fldChildInCare.SelectedValue = WorkingData.ApplicationRequestRow.LookedAfter
            End If
            If Page.Session("TCaringResponsibilities") IsNot Nothing Then
                If Page.Session("TCaringResponsibilities").Equals("Yes") Then
                    fldCaringResponsibilities.SelectedValue = True
                ElseIf Page.Session("TCaringResponsibilities").Equals("No") Then
                    fldCaringResponsibilities.SelectedValue = False
                End If
            End If
            If WorkingData.ApplicationRequestRow.CareLeaver IsNot Nothing Then
                fldCareLeaver.SelectedValue = WorkingData.ApplicationRequestRow.CareLeaver
            End If

            If WorkingData.ApplicationRequestRow.StudentDetailUserDefined2 IsNot Nothing AndAlso WorkingData.ApplicationRequestRow.StudentDetailUserDefined2.Equals("Y") Then
                fldSocialCareInvolvement.SelectedValue = "True"
            ElseIf WorkingData.ApplicationRequestRow.StudentDetailUserDefined2 IsNot Nothing AndAlso WorkingData.ApplicationRequestRow.StudentDetailUserDefined2.Equals("N") Then
                fldSocialCareInvolvement.SelectedValue = "False"
            End If


        End If

        'If Not IsPostBack Then
        '    If WorkingData.ApplicationRequestRow.ApplicationUserDefined3 <> "" Then ddlAlevel_one.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined3
        '    If WorkingData.ApplicationRequestRow.ApplicationUserDefined4 <> "" Then ddlAlevel_two.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined4
        '    If WorkingData.ApplicationRequestRow.ApplicationUserDefined5 <> "" Then ddlAlevel_three.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined5
        '    If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 <> "" Then fldWhatsApp.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6
        '    WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByEmail = True
        '    'show personal statement for Access to HE
        '    For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
        '        If item.OfferingID > 0 Then

        '            Dim SQLDBDataReader As SqlClient.SqlDataReader
        '            Dim SQLDataTable As New DataTable
        '            Dim cmd As New SqlCommand
        '            Dim SQLCmd As New SqlClient.SqlConnection
        '            SQLCmd.ConnectionString = GetConn()
        '            SQLCmd.Open()
        '            cmd.CommandTimeout = "120"
        '            cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
        '            cmd.CommandType = CommandType.StoredProcedure
        '            cmd.Connection = SQLCmd
        '            cmd.Parameters.AddWithValue("offeringid", item.OfferingID)
        '            SQLDBDataReader = cmd.ExecuteReader()
        '            If SQLDBDataReader.HasRows Then
        '                While (SQLDBDataReader.Read)

        '                    'show personal statement supported internship as well as referee details
        '                    If CStr(SQLDBDataReader("code")).IndexOf("ALSCIENCE") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALBUS&LAW") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALHUM") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALCREATIVE") > -1 _
        '                           Or CStr(SQLDBDataReader("code")).IndexOf("ALSOCIALSCI") > -1 Then
        '                        divALevels.Visible = True
        '                    End If


        '                End While
        '            End If
        '            SQLCmd.Close()
        '            SQLDBDataReader.Close()
        '        End If
        '    Next
        '    If divALevels.Visible = True Then
        '        ''get the a level subjects

        '        Dim SQLDBDataReader As SqlClient.SqlDataReader
        '        Dim SQLDataTable As New DataTable
        '        Dim cmd As New SqlCommand
        '        Dim SQLCmd As New SqlClient.SqlConnection
        '        SQLCmd.ConnectionString = GetConn()
        '        SQLCmd.Open()
        '        cmd.CommandTimeout = "120"
        '        cmd.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Connection = SQLCmd


        '        SQLDBDataReader = cmd.ExecuteReader()
        '        '  If SQLDBDataReader.HasRows Then
        '        ddlAlevel_one.DataSource = SQLDBDataReader
        '        ddlAlevel_one.DataTextField = "name"

        '        ddlAlevel_one.DataValueField = "code"
        '        ddlAlevel_one.DataBind()
        '        SQLCmd.Close()
        '        SQLDBDataReader.Close()


        '        Dim SQLDBDataReader2 As SqlClient.SqlDataReader
        '        Dim SQLDataTable2 As New DataTable
        '        Dim cmd2 As New SqlCommand
        '        Dim SQLCmd2 As New SqlClient.SqlConnection
        '        SQLCmd2.ConnectionString = GetConn()
        '        SQLCmd2.Open()
        '        cmd2.CommandTimeout = "120"
        '        cmd2.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
        '        cmd2.CommandType = CommandType.StoredProcedure
        '        cmd2.Connection = SQLCmd2


        '        SQLDBDataReader2 = cmd2.ExecuteReader()
        '        '  If SQLDBDataReader.HasRows Then
        '        ddlAlevel_two.DataSource = SQLDBDataReader2
        '        ddlAlevel_two.DataTextField = "name"

        '        ddlAlevel_two.DataValueField = "code"
        '        ddlAlevel_two.DataBind()
        '        SQLCmd2.Close()
        '        SQLDBDataReader2.Close()


        '        Dim SQLDBDataReader3 As SqlClient.SqlDataReader
        '        Dim SQLDataTable3 As New DataTable
        '        Dim cmd3 As New SqlCommand
        '        Dim SQLCmd3 As New SqlClient.SqlConnection
        '        SQLCmd3.ConnectionString = GetConn()
        '        SQLCmd3.Open()
        '        cmd3.CommandTimeout = "120"
        '        cmd3.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
        '        cmd3.CommandType = CommandType.StoredProcedure
        '        cmd3.Connection = SQLCmd3


        '        SQLDBDataReader3 = cmd3.ExecuteReader()
        '        '  If SQLDBDataReader.HasRows Then
        '        ddlAlevel_three.DataSource = SQLDBDataReader3
        '        ddlAlevel_three.DataTextField = "name"

        '        ddlAlevel_three.DataValueField = "code"
        '        ddlAlevel_three.DataBind()
        '        SQLCmd3.Close()
        '        SQLDBDataReader3.Close()
        '        ''  End If
        '        ''SQLCmd.Close()
        '        'SQLDBDataReader.Close()

        '        'SQLDBDataReader = cmd.ExecuteReader()
        '        'ddlAlevel_two.DataSource = SQLDBDataReader
        '        'ddlAlevel_two.DataTextField = "name"

        '        'ddlAlevel_two.DataValueField = "code"
        '        'ddlAlevel_two.DataBind()

        '        'SQLDBDataReader = cmd.ExecuteReader()
        '        'ddlAlevel_three.DataSource = SQLDBDataReader
        '        'ddlAlevel_three.DataTextField = "name"

        '        'ddlAlevel_three.DataValueField = "code"
        '        'ddlAlevel_three.DataBind()


        '        '  End If

        '    End If
        'End If
    End Sub


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        If fldChildInCare IsNot Nothing AndAlso fldChildInCare.SelectedItem.Value.Equals("").Equals(False) Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you are a child in care."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If fldCaringResponsibilities IsNot Nothing AndAlso fldCaringResponsibilities.SelectedItem.Value.Equals("").Equals(False) Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you have caring responsibilities for a member of your family."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If fldCareLeaver IsNot Nothing AndAlso fldCareLeaver.SelectedItem.Value.Equals("").Equals(False) Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you are a care leaver."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If fldSocialCareInvolvement IsNot Nothing AndAlso fldSocialCareInvolvement.SelectedItem.Value.Equals("").Equals(False) Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you have been involved with social care."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

    End Sub

    Public Function YearsBetweenDates(ByVal StartDate As DateTime,
           ByVal EndDate As DateTime) As Integer
        ' Returns the number of years between the passed dates
        If Month(EndDate) < Month(StartDate) Or
           (Month(EndDate) = Month(StartDate) And
           (EndDate.Day) < (StartDate.Day)) Then
            Return Year(EndDate) - Year(StartDate) - 1
        Else
            Return Year(EndDate) - Year(StartDate)
        End If
    End Function



    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click



        Me.Page.Validate()

        Page.Session("TChildInCare") = fldChildInCare.SelectedItem.Text
        If fldChildInCare.SelectedItem.Value = "True" Then
            WorkingData.ApplicationRequestRow.LookedAfter = True
        Else
            WorkingData.ApplicationRequestRow.LookedAfter = True
        End If

        Page.Session("TCaringResponsibilities") = fldCaringResponsibilities.SelectedItem.Text
        If fldCaringResponsibilities.SelectedItem.Value = "True" Then
            WorkingData.ApplicationRequestRow.YoungCarer = True
        Else
            WorkingData.ApplicationRequestRow.YoungCarer = True
        End If
        'WorkingData.EnrolmentRequest(0).YoungCarer = fldCaringResponsibilities.SelectedItem.Value

        Page.Session("TCareLeaver") = fldCareLeaver.SelectedItem.Text
        If fldCareLeaver.SelectedItem.Value = "True" Then
            WorkingData.ApplicationRequestRow.CareLeaver = True
        Else
            WorkingData.ApplicationRequestRow.CareLeaver = True
        End If
        'WorkingData.EnrolmentRequest(0).CareLeaver = fldCareLeaver.SelectedItem.Value

        Page.Session("TSocialCareInvolvement") = fldSocialCareInvolvement.SelectedItem.Text
        If fldSocialCareInvolvement.SelectedItem.Value = "True" Then
            WorkingData.ApplicationRequestRow.StudentDetailUserDefined2 = "Y"
        Else
            WorkingData.ApplicationRequestRow.StudentDetailUserDefined2 = "N"
        End If


        If Me.Page.IsValid Then
            Response.Redirect(GetResourceValue("previousconvictions_aspx"))
        End If


    End Sub
End Class
