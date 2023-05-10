Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class checkout_quals_on_entry
    Inherits CheckoutBaseControl

    Dim ctl1 As Object


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        '  Response.Write(WorkingData.EnrolmentRequestRow.HasEducationHealthCarePlan)
        'Breadcrumbs
        If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            breadcrumbenrols.Visible = True
            breadcrumbapps.Visible = False
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = True
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            breadcrumbenrols.Visible = True
            breadcrumbapps.Visible = False
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = False
        Else
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = False
        End If

        'Custom code to colour the form based on the contents of the shopping basket
        'Use this when sharing pages between types (Application/Enrolment)

        'Clear class attributes first
        Me.panel1.Attributes("class") = ""



        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Me.panel1.Attributes("class") = "panel panel-danger"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Me.panel1.Attributes("class") = "panel panel-success"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
            Me.panel1.Attributes("class") = "panel panel-info"
        Else
            Me.panel1.Attributes("class") = "panel panel-danger"
        End If

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
                        'show personal statement for Access to HE
                        If CStr(SQLDBDataReader("name")).IndexOf("CELTA") > -1 Then
                            divStatement.Visible = True
                            olCelta.Visible = True
                        End If
                        'show personal statement for Access to HE
                        If CStr(SQLDBDataReader("name")).IndexOf("ACCESS TO HE") > -1 Then
                            divStatement.Visible = True
                            olAccessHE.Visible = True
                        End If
                        'show personal statement supported internship as well as referee details
                        If CStr(SQLDBDataReader("code")).IndexOf("ATSUPINTER") > -1 _
                               Or CStr(SQLDBDataReader("code")).IndexOf("LBF1778B00-1") > -1 _
                               Or CStr(SQLDBDataReader("code")).IndexOf("LGF1081A00-1") > -1 _
                               Or CStr(SQLDBDataReader("code")).IndexOf("LPF1081A00-1") > -1 _
                                Or CStr(SQLDBDataReader("code")).IndexOf("ATSUPINTER") > -1 _
                               Or CStr(SQLDBDataReader("code")).IndexOf("LTF1081A00-1") > -1 Then
                            divStatement.Visible = True
                            divReferee.Visible = True
                            olSuppInter.Visible = True
                        End If


                    End While
                End If
                SQLCmd.Close()
                SQLDBDataReader.Close()
            End If
        Next
        If Not Page.IsPostBack Then
            If divStatement.Visible = True Then personalstatement.Text = WorkingData.EnrolmentRequestRow.StudentDeclaration
        End If

    End Sub

    Protected Overrides Sub CreateChildControls()
        MyBase.CreateChildControls()

        'If IsPostBack Then

        'Recreate the header row
        Dim rowH As New TableRow

        'Dim c1, c2, c3, c4, c5, c6 As New TableCell
        Dim c1, c2, c3, c4, c6 As New TableCell
        c1.Text = "Subject"
        c1.Attributes.Add("class", "text=center")
        c2.Text = "Subject (if not in list)"
        c6.Text = "Type of Qualification e.g.GCSE,NVQ 2,A Level etc"
        c3.Text = "Results(if known)"
        c4.Text = "Predicted results(if known)"
        'c5.Text = "Date Awarded (Expected to complete) dd/mm/yyyy"
        rowH.Cells.AddRange({c1, c2, c6, c3, c4})
        'rowH.Cells.AddRange({c1, c2, c6, c3, c4, c5})

        tblQuals.Rows.Add(rowH)

        If IsPostBack Then
            Dim c As Control = GetPostBackControl(Me.Page)
            If c.GetType Is GetType(Button) Then
                If DirectCast(c, Button).Text = "Add Row" Then intCurrentQuals += 1
            End If
            If c.GetType Is GetType(Button) Then
                If (intCurrentQuals > 0) Then
                    If DirectCast(c, Button).Text = "Remove Row" Then intCurrentQuals -= 1
                End If
            End If
        End If

        For i = 0 To intCurrentQuals
            Dim row As New TableRow
            Dim cell1, cell2, cell3, cell4, cell5, cell6 As New TableCell
            Dim ctl1, ctl2, ctl3, ctl4, ctl5, ctl6 As New StudentQualsOnEntryField


            ctl1.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.QualID
            ctl1.StudentQualsOnEntryRowNumber = i
            ctl1.LabelWidth = 0
            ctl1.IsRequired = True
            cell1.Controls.Add(ctl1)

            ctl2.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.Subject
            ctl2.StudentQualsOnEntryRowNumber = i
            ctl2.LabelWidth = 0
            cell2.Controls.Add(ctl2)

            ctl6.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.Level
            ctl6.StudentQualsOnEntryRowNumber = i
            ctl6.LabelWidth = 0
            ctl6.IsRequired = False
            cell6.Controls.Add(ctl6)

            ctl3.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.Grade
            ctl3.StudentQualsOnEntryRowNumber = i
            ctl3.LabelWidth = 0
            cell3.Controls.Add(ctl3)

            ctl4.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.PredictedGrade
            ctl4.StudentQualsOnEntryRowNumber = i
            ctl4.LabelWidth = 0
            cell4.Controls.Add(ctl4)

            'ctl5.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.DateAwarded
            'ctl5.StudentQualsOnEntryRowNumber = i
            'If WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            '    ctl5.IsRequired = True
            'End If
            'ctl5.LabelWidth = 0
            'cell5.Controls.Add(ctl5)

            'row.Cells.AddRange({cell1, cell2, cell6, cell3, cell4, cell5})
            row.Cells.AddRange({cell1, cell2, cell6, cell3, cell4})
            tblQuals.Rows.Add(row)

        Next

    End Sub
    Public Overrides Sub ValidateControl()

        If divStatement.Visible = True Then
            If WorkingData.EnrolmentRequestRow.StudentDeclaration = "" Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please enter your personal statement."
                v.IsValid = False
                Me.Page.Validators.Add(v)
            End If
        End If


        'MyBase.ValidateControl()
        'Dim str As String
        'Dim str1 As String
        'Dim count As Integer = 0
        'For i = 1 To tblQuals.Rows.Count - 1
        '    str = String.Empty
        '    If tblQuals.Rows(i).Cells(0).Controls(0).GetType Is GetType(StudentQualsOnEntryField) Then
        '        str = DirectCast(tblQuals.Rows(i).Cells(0).Controls(0), StudentQualsOnEntryField).Value
        '        str1 = DirectCast(tblQuals.Rows(i).Cells(1).Controls(0), StudentQualsOnEntryField).Value
        '        If str IsNot Nothing Then
        '            If str.Length = 0 Then
        '                count = count + 1
        '            End If

        '            If str1 IsNot Nothing Then
        '                If str1.Length > 0 And str.Length = 0 Then
        '                    count = count - 1
        '                End If
        '            End If
        '        End If
        '    End If
        'Next
        'If WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
        '    If count > 0 Then
        '        Dim v As New CustomValidator()
        '        v.ErrorMessage = "Please select a Qualification"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        'End If
    End Sub


    Public Property intCurrentQuals() As Integer
        Get
            Return CInt(HttpContext.Current.Session("intQualRows"))
        End Get
        Set(ByVal value As Integer)
            HttpContext.Current.Session("intQualRows") = value
        End Set
    End Property

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        If divStatement.Visible = True Then WorkingData.EnrolmentRequestRow.StudentDeclaration = personalstatement.Text

        Me.Page.Validate()


        If Me.Page.IsValid Then
            If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_aspx"))            
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_aspx"))
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_apponly_aspx"))
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_enquiry"))
            End If
        End If
    End Sub


    Protected Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click

        If divStatement.Visible = True Then WorkingData.EnrolmentRequestRow.StudentDeclaration = personalstatement.Text

        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Redirect(GetResourceValue("checkout_attachments_aspx"))

        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Dim age As Integer
            age = Today.Year - Convert.ToDateTime(WorkingData.ApplicationRequestRow.DateOfBirth).Year
            If (age > 19) Then
                Response.Redirect(GetResourceValue("checkout_applications2_aspx"))
            Else
                Response.Redirect(GetResourceValue("checkout_parentguardian_aspx"))
            End If
        End If
    End Sub
End Class
