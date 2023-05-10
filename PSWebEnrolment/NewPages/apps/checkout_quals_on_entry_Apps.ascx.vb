Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class checkout_quals_on_entry
    Inherits CheckoutBaseControl

    Dim ctl1 As Object


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)


    End Sub


    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        If Me.Page.IsValid Then

            Response.Redirect(GetResourceValue("checkout_employment_Apps_aspx"))

        End If
    End Sub


    Protected Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click

        Response.Redirect(GetResourceValue("checkout_enrolments2_Apps_aspx"))


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
            '   ctl1.IsRequired = True
            cell1.Controls.Add(ctl1)

            ctl2.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.Subject
            ctl2.StudentQualsOnEntryRowNumber = i
            ctl2.LabelWidth = 0
            cell2.Controls.Add(ctl2)

            ctl6.StudentQualsOnEntryFieldType = StudentQualsOnEntryFieldType.Level
            ctl6.StudentQualsOnEntryRowNumber = i
            ctl6.LabelWidth = 0
            '  ctl6.IsRequired = True
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


    Public Property intCurrentQuals() As Integer
        Get
            Return CInt(HttpContext.Current.Session("intQualRows"))
        End Get
        Set(ByVal value As Integer)
            HttpContext.Current.Session("intQualRows") = value
        End Set
    End Property

End Class
