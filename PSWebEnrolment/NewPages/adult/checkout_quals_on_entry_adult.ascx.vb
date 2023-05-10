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
                        'for adult english and maths
                        If CStr(SQLDBDataReader("offeringtype")).IndexOf("English/Maths") > -1 Then
                            If CStr(SQLDBDataReader("fundingid")).IndexOf("35") > -1 _
                               Or CStr(SQLDBDataReader("funding2id")).IndexOf("35") > -1 Then
                                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5 = "AdultEM"

                            End If
                        End If


                    End While
                End If
                SQLCmd.Close()
                SQLDBDataReader.Close()
            End If
        Next
        If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5 = "AdultEM" Then
            qualsPara.Text = "English and Maths Entitlement is accessible for those Learners studying a GCSE, Functional Skills (FS) or other stated eligible English and maths qualification(s). To be eligible you must confirm that you have not already achieved a Grade 4 / C or above or overseas equivalent in Maths or English. You must not have achieved the level (or above) of that in which we enrol you.<br><br>Please enter your English and Maths qualifications below:<br>"
            ddlEng.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6
            ddlMath.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined7
        Else
            qualsPara.Text = "Please list any qualifications you have achieved."
        End If
    End Sub



    Public Property intCurrentQuals() As Integer
        Get
            Return CInt(HttpContext.Current.Session("intQualRows"))
        End Get
        Set(ByVal value As Integer)
            HttpContext.Current.Session("intQualRows") = value
        End Set
    End Property

    'Example of render control on GCSE grades at the top 


    Public Overrides Sub RenderControl(writer As HtmlTextWriter)

        ''Render control for 1st Subject


        Dim ctlQuals As DropDownList = TryCast(StudentQualsOnEntryField17.InternalFieldControl, DropDownList)
        Dim ctlGrades As DropDownList = TryCast(StudentQualsOnEntryField18.InternalFieldControl, DropDownList)
        '   Dim ctlPredictedGrades As DropDownList = TryCast(StudentQualsOnEntryField19.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade = 0
        For k As Integer = 0 To ctlGrades.Items.Count - 1 Step 1
            Dim item = ctlGrades.Items(k)
            Dim itemGradeName = item.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlGrades.Items.Remove(item)
                    ctlGrades.Items.Insert(indexGrade, item)
                    ' Increment index to maintain alpha sort
                    indexGrade += 1
            End Select
        Next

        '' Move all GCSE Predicted Grades to the top
        'Dim indexPredictedGrade = 0
        'For k As Integer = 0 To ctlPredictedGrades.Items.Count - 1 Step 1
        '    Dim item = ctlPredictedGrades.Items(k)
        '    Dim itemGradeName = item.Text

        '    ' Is this a GCSE Grade A*-G or 1-9?
        '    Select Case itemGradeName
        '        Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
        '             "1", "2", "3", "4", "5", "6", "7", "8", "9"
        '            ' Remove the item and reinsert at top
        '            ctlPredictedGrades.Items.Remove(item)
        '            ctlPredictedGrades.Items.Insert(indexPredictedGrade, item)
        '            ' Increment index to maintain alpha sort
        '            indexPredictedGrade += 1
        '    End Select
        'Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual = 0
        For j As Integer = 0 To ctlQuals.Items.Count - 1 Step 1
            Dim item = ctlQuals.Items(j)
            Dim itemQualName = item.Text

            ' Is this a GCSE?
            If itemQualName.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName) Then
                ' Remove the item and reinsert at top
                ctlQuals.Items.Remove(item)
                ctlQuals.Items.Insert(indexQual, item)
                ' Increment index to maintain alpha sort
                indexQual += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank = ctlQuals.Items.FindByValue("")
        ctlQuals.Items.Remove(itemQualBlank)
        ctlQuals.Items.Insert(0, itemQualBlank)

        Dim itemGradeBlank = ctlGrades.Items.FindByValue("")
        ctlGrades.Items.Remove(itemGradeBlank)
        ctlGrades.Items.Insert(0, itemGradeBlank)

        'Dim itemPredictedGradeBlank = ctlPredictedGrades.Items.FindByValue("")
        'ctlPredictedGrades.Items.Remove(itemPredictedGradeBlank)
        'ctlPredictedGrades.Items.Insert(0, itemPredictedGradeBlank)


        ''Render control for 2nd object

        Dim ctlqual1 As DropDownList = TryCast(Qual.InternalFieldControl, DropDownList)
        Dim ctlgrades1 As DropDownList = TryCast(Grade.InternalFieldControl, DropDownList)
        '       Dim ctlpredictedgrades1 As DropDownList = TryCast(PredGrade.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade1 = 0
        For k As Integer = 0 To ctlgrades1.Items.Count - 1 Step 1
            Dim item1 = ctlgrades1.Items(k)
            Dim itemGradeName1 = item1.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName1
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades1.Items.Remove(item1)
                    ctlgrades1.Items.Insert(indexGrade1, item1)
                    ' Increment index to maintain alpha sort
                    indexGrade1 += 1
            End Select
        Next

        '' Move all GCSE Predicted Grades to the top
        'Dim indexPredictedGrade1 = 0
        'For k As Integer = 0 To ctlpredictedgrades1.Items.Count - 1 Step 1
        '    Dim item1 = ctlpredictedgrades1.Items(k)
        '    Dim itemGradeName1 = item1.Text

        '    ' Is this a GCSE Grade A*-G or 1-9?
        '    Select Case itemGradeName1
        '        Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
        '             "1", "2", "3", "4", "5", "6", "7", "8", "9"
        '            ' Remove the item and reinsert at top
        '            ctlpredictedgrades1.Items.Remove(item1)
        '            ctlpredictedgrades1.Items.Insert(indexPredictedGrade1, item1)
        '            ' Increment index to maintain alpha sort
        '            indexPredictedGrade1 += 1
        '    End Select
        'Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual1 = 0
        For j As Integer = 0 To ctlqual1.Items.Count - 1 Step 1
            Dim item1 = ctlqual1.Items(j)
            Dim itemQualName1 = item1.Text

            ' Is this a GCSE?
            If itemQualName1.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName1) Then
                ' Remove the item and reinsert at top
                ctlqual1.Items.Remove(item1)
                ctlqual1.Items.Insert(indexQual1, item1)
                ' Increment index to maintain alpha sort
                indexQual1 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank1 = ctlqual1.Items.FindByValue("")
        ctlqual1.Items.Remove(itemQualBlank1)
        ctlqual1.Items.Insert(0, itemQualBlank1)

        Dim itemGradeBlank1 = ctlgrades1.Items.FindByValue("")
        ctlgrades1.Items.Remove(itemGradeBlank1)
        ctlgrades1.Items.Insert(0, itemGradeBlank1)

        'Dim itemPredictedGradeBlank1 = ctlpredictedgrades1.Items.FindByValue("")
        'ctlpredictedgrades1.Items.Remove(itemPredictedGradeBlank1)
        'ctlpredictedgrades1.Items.Insert(0, itemPredictedGradeBlank1)


        '''''Render control for 3rd object

        Dim ctlqual2 As DropDownList = TryCast(StudentQualsOnEntryField1.InternalFieldControl, DropDownList)
        Dim ctlgrades2 As DropDownList = TryCast(StudentQualsOnEntryField2.InternalFieldControl, DropDownList)
        ' Dim ctlpredictedgrades2 As DropDownList = TryCast(StudentQualsOnEntryField3.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade2 = 0
        For k As Integer = 0 To ctlgrades2.Items.Count - 1 Step 1
            Dim item2 = ctlgrades2.Items(k)
            Dim itemGradeName2 = item2.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName2
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades2.Items.Remove(item2)
                    ctlgrades2.Items.Insert(indexGrade2, item2)
                    ' Increment index to maintain alpha sort
                    indexGrade2 += 1
            End Select
        Next

        '' Move all GCSE Predicted Grades to the top
        'Dim indexPredictedGrade2 = 0
        'For k As Integer = 0 To ctlpredictedgrades2.Items.Count - 1 Step 1
        '    Dim item2 = ctlpredictedgrades2.Items(k)
        '    Dim itemGradeName2 = item2.Text

        '    ' Is this a GCSE Grade A*-G or 1-9?
        '    Select Case itemGradeName2
        '        Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
        '             "1", "2", "3", "4", "5", "6", "7", "8", "9"
        '            ' Remove the item and reinsert at top
        '            ctlpredictedgrades2.Items.Remove(item2)
        '            ctlpredictedgrades2.Items.Insert(indexPredictedGrade2, item2)
        '            ' Increment index to maintain alpha sort
        '            indexPredictedGrade2 += 1
        '    End Select
        'Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual2 = 0
        For j As Integer = 0 To ctlqual2.Items.Count - 1 Step 1
            Dim item2 = ctlqual2.Items(j)
            Dim itemQualName2 = item2.Text

            ' Is this a GCSE?
            If itemQualName2.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName2) Then
                ' Remove the item and reinsert at top
                ctlqual2.Items.Remove(item2)
                ctlqual2.Items.Insert(indexQual2, item2)
                ' Increment index to maintain alpha sort
                indexQual2 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank2 = ctlqual2.Items.FindByValue("")
        ctlqual2.Items.Remove(itemQualBlank2)
        ctlqual2.Items.Insert(0, itemQualBlank2)

        Dim itemGradeBlank2 = ctlgrades2.Items.FindByValue("")
        ctlgrades2.Items.Remove(itemGradeBlank2)
        ctlgrades2.Items.Insert(0, itemGradeBlank2)

        'Dim itemPredictedGradeBlank2 = ctlpredictedgrades2.Items.FindByValue("")
        'ctlpredictedgrades2.Items.Remove(itemPredictedGradeBlank2)
        'ctlpredictedgrades2.Items.Insert(0, itemPredictedGradeBlank2)

        ''Render control for 4th object

        Dim ctlqual3 As DropDownList = TryCast(StudentQualsOnEntryField5.InternalFieldControl, DropDownList)
        Dim ctlgrades3 As DropDownList = TryCast(StudentQualsOnEntryField6.InternalFieldControl, DropDownList)
        '     Dim ctlpredictedgrades3 As DropDownList = TryCast(StudentQualsOnEntryField7.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade3 = 0
        For k As Integer = 0 To ctlgrades3.Items.Count - 1 Step 1
            Dim item3 = ctlgrades3.Items(k)
            Dim itemGradeName3 = item3.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName3
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades3.Items.Remove(item3)
                    ctlgrades3.Items.Insert(indexGrade3, item3)
                    ' Increment index to maintain alpha sort
                    indexGrade3 += 1
            End Select
        Next

        '' Move all GCSE Predicted Grades to the top
        'Dim indexPredictedGrade3 = 0
        'For k As Integer = 0 To ctlpredictedgrades3.Items.Count - 1 Step 1
        '    Dim item3 = ctlpredictedgrades3.Items(k)
        '    Dim itemGradeName3 = item3.Text

        '    ' Is this a GCSE Grade A*-G or 1-9?
        '    Select Case itemGradeName3
        '        Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
        '             "1", "2", "3", "4", "5", "6", "7", "8", "9"
        '            ' Remove the item and reinsert at top
        '            ctlpredictedgrades3.Items.Remove(item3)
        '            ctlpredictedgrades3.Items.Insert(indexPredictedGrade3, item3)
        '            ' Increment index to maintain alpha sort
        '            indexPredictedGrade3 += 1
        '    End Select
        'Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual3 = 0
        For j As Integer = 0 To ctlqual3.Items.Count - 1 Step 1
            Dim item3 = ctlqual3.Items(j)
            Dim itemQualName3 = item3.Text

            ' Is this a GCSE?
            If itemQualName3.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName3) Then
                ' Remove the item and reinsert at top
                ctlqual3.Items.Remove(item3)
                ctlqual3.Items.Insert(indexQual3, item3)
                ' Increment index to maintain alpha sort
                indexQual3 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank3 = ctlqual3.Items.FindByValue("")
        ctlqual3.Items.Remove(itemQualBlank3)
        ctlqual3.Items.Insert(0, itemQualBlank3)

        Dim itemGradeBlank3 = ctlgrades3.Items.FindByValue("")
        ctlgrades3.Items.Remove(itemGradeBlank3)
        ctlgrades3.Items.Insert(0, itemGradeBlank3)

        'Dim itemPredictedGradeBlank3 = ctlpredictedgrades3.Items.FindByValue("")
        'ctlpredictedgrades3.Items.Remove(itemPredictedGradeBlank3)
        'ctlpredictedgrades3.Items.Insert(0, itemPredictedGradeBlank3)

        '' Move all GCSE Predicted Grades to the top
        'Dim indexPredictedGrade7 = 0
        'For k As Integer = 0 To ctlpredictedgrades7.Items.Count - 1 Step 1
        '    Dim item7 = ctlpredictedgrades7.Items(k)
        '    Dim itemGradeName7 = item7.Text

        '    ' Is this a GCSE Grade A*-G or 1-9?
        '    Select Case itemGradeName7
        '        Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
        '             "1", "2", "3", "4", "5", "6", "7", "8", "9"
        '            ' Remove the item and reinsert at top
        '            ctlpredictedgrades7.Items.Remove(item7)
        '            ctlpredictedgrades7.Items.Insert(indexPredictedGrade7, item7)
        '            ' Increment index to maintain alpha sort
        '            indexPredictedGrade7 += 1
        '    End Select
        'Next

        'Dim itemPredictedGradeBlank7 = ctlpredictedgrades7.Items.FindByValue("")
        'ctlpredictedgrades7.Items.Remove(itemPredictedGradeBlank7)
        'ctlpredictedgrades7.Items.Insert(0, itemPredictedGradeBlank7)

        MyBase.RenderControl(writer)


    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        If Me.Page.IsValid Then
            If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5 = "AdultEM" Then
                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 = ddlEng.SelectedValue
                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined7 = ddlMath.SelectedValue
            End If

            Response.Redirect(GetResourceValue("checkout_employment_adult_aspx"))

        End If
    End Sub


    Protected Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click

        Response.Redirect(GetResourceValue("checkout_enrolments2_adult_aspx"))


    End Sub

    Public Overrides Sub ValidateControl()
        'If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5 = "AdultEM" Then
        '    'Response.Write(selectEuro.SelectedValue)
        '    If ddlEng.SelectedValue = "" Then
        '        Dim v As New CustomValidator
        '        v.ErrorMessage = "Please complete the English declaration dropdown box"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        '    If ddlMath.SelectedValue = "" Then
        '        Dim v As New CustomValidator
        '        v.ErrorMessage = "Please complete the Maths declaration dropdown box"
        '        v.IsValid = False
        '        Me.Page.Validators.Add(v)
        '    End If
        'End If


        MyBase.ValidateControl()
    End Sub
End Class
