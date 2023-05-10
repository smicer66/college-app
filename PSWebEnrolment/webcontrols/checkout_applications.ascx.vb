'Option Explicit On
'Option Strict On

Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class checkout_applications
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False

        If Not IsPostBack Then
            If WorkingData.ApplicationRequestRow.ApplicationUserDefined3 <> "" Then ddlAlevel_one.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined3
            If WorkingData.ApplicationRequestRow.ApplicationUserDefined4 <> "" Then ddlAlevel_two.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined4
            If WorkingData.ApplicationRequestRow.ApplicationUserDefined5 <> "" Then ddlAlevel_three.SelectedValue = WorkingData.ApplicationRequestRow.ApplicationUserDefined5
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 <> "" Then fldWhatsApp.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6
            WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByEmail = True
            'show personal statement for Access to HE
            For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
                If item.OfferingID > 0 Then

                    Dim SQLDBDataReader As SqlClient.SqlDataReader
                    Dim SQLDataTable As New DataTable
                    Dim cmd As New SqlCommand
                    Dim SQLCmd As New SqlClient.SqlConnection
                    SQLCmd.ConnectionString = GetConn()
                    SQLCmd.Open()
                    cmd.CommandTimeout = "120"
                    cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = SQLCmd
                    cmd.Parameters.AddWithValue("offeringid", item.OfferingID)
                    SQLDBDataReader = cmd.ExecuteReader()
                    If SQLDBDataReader.HasRows Then
                        While (SQLDBDataReader.Read)

                            'show personal statement supported internship as well as referee details
                            If CStr(SQLDBDataReader("code")).IndexOf("ALSCIENCE") > -1 _
                                   Or CStr(SQLDBDataReader("code")).IndexOf("ALBUS&LAW") > -1 _
                                   Or CStr(SQLDBDataReader("code")).IndexOf("ALHUM") > -1 _
                                   Or CStr(SQLDBDataReader("code")).IndexOf("ALCREATIVE") > -1 _
                                   Or CStr(SQLDBDataReader("code")).IndexOf("ALSOCIALSCI") > -1 Then
                                divALevels.Visible = True
                            End If


                        End While
                    End If
                    SQLCmd.Close()
                    SQLDBDataReader.Close()
                End If
            Next
            If divALevels.Visible = True Then
                ''get the a level subjects

                Dim SQLDBDataReader As SqlClient.SqlDataReader
                Dim SQLDataTable As New DataTable
                Dim cmd As New SqlCommand
                Dim SQLCmd As New SqlClient.SqlConnection
                SQLCmd.ConnectionString = GetConn()
                SQLCmd.Open()
                cmd.CommandTimeout = "120"
                cmd.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = SQLCmd


                SQLDBDataReader = cmd.ExecuteReader()
                '  If SQLDBDataReader.HasRows Then
                ddlAlevel_one.DataSource = SQLDBDataReader
                ddlAlevel_one.DataTextField = "name"

                ddlAlevel_one.DataValueField = "code"
                ddlAlevel_one.DataBind()
                SQLCmd.Close()
                SQLDBDataReader.Close()


                Dim SQLDBDataReader2 As SqlClient.SqlDataReader
                Dim SQLDataTable2 As New DataTable
                Dim cmd2 As New SqlCommand
                Dim SQLCmd2 As New SqlClient.SqlConnection
                SQLCmd2.ConnectionString = GetConn()
                SQLCmd2.Open()
                cmd2.CommandTimeout = "120"
                cmd2.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
                cmd2.CommandType = CommandType.StoredProcedure
                cmd2.Connection = SQLCmd2


                SQLDBDataReader2 = cmd2.ExecuteReader()
                '  If SQLDBDataReader.HasRows Then
                ddlAlevel_two.DataSource = SQLDBDataReader2
                ddlAlevel_two.DataTextField = "name"

                ddlAlevel_two.DataValueField = "code"
                ddlAlevel_two.DataBind()
                SQLCmd2.Close()
                SQLDBDataReader2.Close()


                Dim SQLDBDataReader3 As SqlClient.SqlDataReader
                Dim SQLDataTable3 As New DataTable
                Dim cmd3 As New SqlCommand
                Dim SQLCmd3 As New SqlClient.SqlConnection
                SQLCmd3.ConnectionString = GetConn()
                SQLCmd3.Open()
                cmd3.CommandTimeout = "120"
                cmd3.CommandText = "PSwebenrolmentReports.dbo.spGetALevels"
                cmd3.CommandType = CommandType.StoredProcedure
                cmd3.Connection = SQLCmd3


                SQLDBDataReader3 = cmd3.ExecuteReader()
                '  If SQLDBDataReader.HasRows Then
                ddlAlevel_three.DataSource = SQLDBDataReader3
                ddlAlevel_three.DataTextField = "name"

                ddlAlevel_three.DataValueField = "code"
                ddlAlevel_three.DataBind()
                SQLCmd3.Close()
                SQLDBDataReader3.Close()
                ''  End If
                ''SQLCmd.Close()
                'SQLDBDataReader.Close()

                'SQLDBDataReader = cmd.ExecuteReader()
                'ddlAlevel_two.DataSource = SQLDBDataReader
                'ddlAlevel_two.DataTextField = "name"

                'ddlAlevel_two.DataValueField = "code"
                'ddlAlevel_two.DataBind()

                'SQLDBDataReader = cmd.ExecuteReader()
                'ddlAlevel_three.DataSource = SQLDBDataReader
                'ddlAlevel_three.DataTextField = "name"

                'ddlAlevel_three.DataValueField = "code"
                'ddlAlevel_three.DataBind()


                '  End If

            End If
        End If
    End Sub


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        '  Response.Write(ddlAlevel_one.SelectedIndex)
        If Len(datepicker.value) > 0 Then
            If IsDate(datepicker.value) AndAlso YearsBetweenDates(CDate(datepicker.value), Today.Date) < 14 Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please check your date of birth has been entered correctly. It looks like you have entered an incorrect date."
                Me.Page.Validators.Add(v)
                ValidationSummary1.ShowSummary = True
            End If

        End If
        'Whatspaa
        If fldWhatsApp.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please tell us if you use WhatsApp"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 = fldWhatsApp.SelectedValue
        End If
        If divALevels.Visible = True Then
            '    Response.Write(ddlAlevel_one.SelectedIndex)
            If ddlAlevel_one.SelectedIndex = "0" Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please provide an A Level subject choice 1"
                Me.Page.Validators.Add(v)
                ValidationSummary1.ShowSummary = True
            End If
            If ddlAlevel_two.SelectedIndex = "0" Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please provide an A Level subject choice 2"
                Me.Page.Validators.Add(v)
                ValidationSummary1.ShowSummary = True
            End If
            If ddlAlevel_three.SelectedIndex = "0" Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please provide an A Level subject choice 3"
                Me.Page.Validators.Add(v)
                ValidationSummary1.ShowSummary = True
            End If
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

        'If Me.Page.IsValid Then


        WorkingData.ApplicationRequestRow.ApplicationUserDefined3 = ddlAlevel_one.SelectedValue
        WorkingData.ApplicationRequestRow.ApplicationUserDefined4 = ddlAlevel_two.SelectedValue
        WorkingData.ApplicationRequestRow.ApplicationUserDefined5 = ddlAlevel_three.SelectedValue

        '    If FileUpload1.HasFile Then
        '        Dim fs As System.IO.Stream = FileUpload1.PostedFile.InputStream()
        '        Dim MyData(CInt(fs.Length)) As Byte
        '        fs.Read(MyData, 0, CInt(fs.Length))
        '        fs.Close()

        '        WorkingData.EnrolmentRequestRow.Photo = MyData
        '    End If



        'End If
    End Sub
End Class
