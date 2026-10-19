'Option Explicit On
'Option Strict On

Imports System.Activities.Expressions
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Globalization
Imports System.Web.DynamicData
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports DocuSign.eSign.Model
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class personaldetails
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False

        'Response.Write(WorkingData.ApplicationRequestRow.DateOfBirth)
        If Not IsPostBack Then

            'Response.Write(Convert.ToDateTime(WorkingData.EnrolmentRequestRow.DateOfBirth).ToString("dd MMM yyyy"))
            If WorkingData.ApplicationRequestRow IsNot Nothing AndAlso WorkingData.ApplicationRequestRow.DateOfBirth IsNot Nothing AndAlso Convert.ToDateTime(WorkingData.ApplicationRequestRow.DateOfBirth).ToString("dd MMM yyyy").Equals("01 Jan 0001").Equals(False) Then
                datepicker.Value = Convert.ToDateTime(WorkingData.ApplicationRequestRow.DateOfBirth).ToString("dd MMM yyyy")
            End If

        End If


        Dim ddl As DropDownList = FindDropDownList(SchoolID)
        If ddl IsNot Nothing Then
            AddHandler ddl.SelectedIndexChanged, AddressOf SchoolID_SelectedIndexChanged
            ddl.AutoPostBack = True
        End If


        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined4 IsNot Nothing Then
            StudentDetailUserDefined4.Value = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined4
            otherSchoolGroupDiv.Visible = True
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



    Private Function FindDropDownList(parent As Control) As DropDownList

        For Each ctrl As Control In parent.Controls

            If TypeOf ctrl Is DropDownList Then
                Return DirectCast(ctrl, DropDownList)
            End If

            Dim result As DropDownList = FindDropDownList(ctrl)

            If result IsNot Nothing Then
                Return result
            End If

        Next

        Return Nothing

    End Function

    Public Overrides Sub ValidateControl()
        'MyBase.ValidateControl()
        'Response.Write(WorkingData.ApplicationRequest(0).FirstForename)
        'Response.Write(WorkingData.ApplicationRequest(0).Surname)
        '   Response.Write(ddlAlevel_one.SelectedIndex)
        'Response.Write(Me.Page.IsValid)

        If Me.Page.IsValid Then
            'Response.Write(WorkingData.ApplicationRequest(0).FirstForename)
        End If



        '--Here Comment
        'If Len(datepicker.Value) > 0 Then
        '    If IsDate(datepicker.Value) AndAlso YearsBetweenDates(CDate(datepicker.Value), Today.Date) < 14 Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please check your date of birth has been entered correctly. It looks like you have entered an incorrect date."
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If

        'End If
        ''Whatspaa
        'If fldWhatsApp.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please tell us if you use WhatsApp"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 = fldWhatsApp.SelectedValue
        'End If
        'If divALevels.Visible = True Then
        '    '    Response.Write(ddlAlevel_one.SelectedIndex)
        '    If ddlAlevel_one.SelectedIndex = "0" Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please provide an A Level subject choice 1"
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If
        '    If ddlAlevel_two.SelectedIndex = "0" Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please provide an A Level subject choice 2"
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If
        '    If ddlAlevel_three.SelectedIndex = "0" Then
        '        Dim v As New CustomValidator
        '        v.IsValid = False
        '        v.ErrorMessage = "Please provide an A Level subject choice 3"
        '        Me.Page.Validators.Add(v)
        '        ValidationSummary1.ShowSummary = True
        '    End If
        'End If

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


        Dim input As String = datepicker.Value
        Dim parsedDate As DateTime

        If DateTime.TryParseExact(
                input,
                "dd MMM yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                parsedDate
            ) Then
            WorkingData.ApplicationRequestRow.DateOfBirth = parsedDate

        End If


        Dim cboSex As DropDownList = DirectCast(fldSex.InternalFieldControl, DropDownList)
        Dim cboEthnic As DropDownList = DirectCast(EthnicGroupID.InternalFieldControl, DropDownList)
        Dim cboPronoun As DropDownList = DirectCast(PreferredPronouns.InternalFieldControl, DropDownList)
        Dim cboPrimaryLang As DropDownList = DirectCast(StudentFirstLanguageID.InternalFieldControl, DropDownList)
        Dim cboPreviousSchool As DropDownList = DirectCast(SchoolID.InternalFieldControl, DropDownList)

        Page.Session("TSex") = cboSex.SelectedItem.Text
        Page.Session("TEthnicity") = cboEthnic.SelectedItem.Text
        Page.Session("TPronoun") = cboPronoun.SelectedItem.Text
        Page.Session("TPrimaryLang") = cboPrimaryLang.SelectedItem.Text
        Page.Session("TPreviousSchool") = cboPreviousSchool.SelectedItem.Text


        'Me.Page.Validate()

        ''If Me.Page.IsValid Then


        'WorkingData.ApplicationRequestRow.ApplicationUserDefined3 = ddlAlevel_one.SelectedValue
        'WorkingData.ApplicationRequestRow.ApplicationUserDefined4 = ddlAlevel_two.SelectedValue
        'WorkingData.ApplicationRequestRow.ApplicationUserDefined5 = ddlAlevel_three.SelectedValue



        '-----End
        '    If FileUpload1.HasFile Then
        '        Dim fs As System.IO.Stream = FileUpload1.PostedFile.InputStream()
        '        Dim MyData(CInt(fs.Length)) As Byte
        '        fs.Read(MyData, 0, CInt(fs.Length))
        '        fs.Close()

        '        WorkingData.EnrolmentRequestRow.Photo = MyData
        '    End If



        'End If
    End Sub



    Public Sub KnownAsLastName_CheckedChanged(Sender As Object, e As EventArgs) Handles KnownAsLastName.CheckedChanged

        If KnownAsLastName.Checked Then
            knownLastGroup.Visible = True
        Else
            knownLastGroup.Visible = False
        End If
    End Sub



    Public Sub KnownAsFirstName_CheckedChanged(Sender As Object, e As EventArgs) Handles KnownAsFirstName.CheckedChanged

        If KnownAsFirstName.Checked Then
            knownFirstGroup.Visible = True
        Else
            knownFirstGroup.Visible = False
        End If
    End Sub


    Public Sub SchoolID_SelectedIndexChanged(Sender As Object, e As EventArgs)
        If SchoolID.Value = "23605" Then
            otherSchoolGroupDiv.Visible = True
        Else
            otherSchoolGroupDiv.Visible = False
        End If
    End Sub

End Class
