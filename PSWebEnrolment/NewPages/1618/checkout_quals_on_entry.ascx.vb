Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class checkout_quals_on_entry
    Inherits CheckoutBaseControl


    Protected Overrides Sub OnLoad(e As EventArgs)
        Response.Write(WorkingData.EnrolmentRequestRow.StudentDetailUserDefined1)
        MyBase.OnLoad(e)

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
        Dim ctlPredictedGrades As DropDownList = TryCast(StudentQualsOnEntryField19.InternalFieldControl, DropDownList)

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

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade = 0
        For k As Integer = 0 To ctlPredictedGrades.Items.Count - 1 Step 1
            Dim item = ctlPredictedGrades.Items(k)
            Dim itemGradeName = item.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlPredictedGrades.Items.Remove(item)
                    ctlPredictedGrades.Items.Insert(indexPredictedGrade, item)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade += 1
            End Select
        Next

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

        Dim itemPredictedGradeBlank = ctlPredictedGrades.Items.FindByValue("")
        ctlPredictedGrades.Items.Remove(itemPredictedGradeBlank)
        ctlPredictedGrades.Items.Insert(0, itemPredictedGradeBlank)


        ''Render control for 2nd object

        Dim ctlqual1 As DropDownList = TryCast(Qual.InternalFieldControl, DropDownList)
        Dim ctlgrades1 As DropDownList = TryCast(Grade.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades1 As DropDownList = TryCast(PredGrade.InternalFieldControl, DropDownList)

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

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade1 = 0
        For k As Integer = 0 To ctlpredictedgrades1.Items.Count - 1 Step 1
            Dim item1 = ctlpredictedgrades1.Items(k)
            Dim itemGradeName1 = item1.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName1
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades1.Items.Remove(item1)
                    ctlpredictedgrades1.Items.Insert(indexPredictedGrade1, item1)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade1 += 1
            End Select
        Next

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

        Dim itemPredictedGradeBlank1 = ctlpredictedgrades1.Items.FindByValue("")
        ctlpredictedgrades1.Items.Remove(itemPredictedGradeBlank1)
        ctlpredictedgrades1.Items.Insert(0, itemPredictedGradeBlank1)


        '''''Render control for 3rd object

        Dim ctlqual2 As DropDownList = TryCast(StudentQualsOnEntryField1.InternalFieldControl, DropDownList)
        Dim ctlgrades2 As DropDownList = TryCast(StudentQualsOnEntryField2.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades2 As DropDownList = TryCast(StudentQualsOnEntryField3.InternalFieldControl, DropDownList)

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

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade2 = 0
        For k As Integer = 0 To ctlpredictedgrades2.Items.Count - 1 Step 1
            Dim item2 = ctlpredictedgrades2.Items(k)
            Dim itemGradeName2 = item2.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName2
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades2.Items.Remove(item2)
                    ctlpredictedgrades2.Items.Insert(indexPredictedGrade2, item2)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade2 += 1
            End Select
        Next

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

        Dim itemPredictedGradeBlank2 = ctlpredictedgrades2.Items.FindByValue("")
        ctlpredictedgrades2.Items.Remove(itemPredictedGradeBlank2)
        ctlpredictedgrades2.Items.Insert(0, itemPredictedGradeBlank2)

        ''Render control for 4th object

        Dim ctlqual3 As DropDownList = TryCast(StudentQualsOnEntryField5.InternalFieldControl, DropDownList)
        Dim ctlgrades3 As DropDownList = TryCast(StudentQualsOnEntryField6.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades3 As DropDownList = TryCast(StudentQualsOnEntryField7.InternalFieldControl, DropDownList)

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

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade3 = 0
        For k As Integer = 0 To ctlpredictedgrades3.Items.Count - 1 Step 1
            Dim item3 = ctlpredictedgrades3.Items(k)
            Dim itemGradeName3 = item3.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName3
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades3.Items.Remove(item3)
                    ctlpredictedgrades3.Items.Insert(indexPredictedGrade3, item3)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade3 += 1
            End Select
        Next

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

        Dim itemPredictedGradeBlank3 = ctlpredictedgrades3.Items.FindByValue("")
        ctlpredictedgrades3.Items.Remove(itemPredictedGradeBlank3)
        ctlpredictedgrades3.Items.Insert(0, itemPredictedGradeBlank3)


        ''Render control for 5th object

        Dim ctlqual4 As DropDownList = TryCast(StudentQualsOnEntryField9.InternalFieldControl, DropDownList)
        Dim ctlgrades4 As DropDownList = TryCast(StudentQualsOnEntryField10.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades4 As DropDownList = TryCast(StudentQualsOnEntryField11.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade4 = 0
        For k As Integer = 0 To ctlgrades4.Items.Count - 1 Step 1
            Dim item4 = ctlgrades4.Items(k)
            Dim itemGradeName4 = item4.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName4
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades4.Items.Remove(item4)
                    ctlgrades4.Items.Insert(indexGrade4, item4)
                    ' Increment index to maintain alpha sort
                    indexGrade4 += 1
            End Select
        Next

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade4 = 0
        For k As Integer = 0 To ctlpredictedgrades4.Items.Count - 1 Step 1
            Dim item4 = ctlpredictedgrades4.Items(k)
            Dim itemGradeName4 = item4.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName4
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades4.Items.Remove(item4)
                    ctlpredictedgrades4.Items.Insert(indexPredictedGrade4, item4)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade4 += 1
            End Select
        Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual4 = 0
        For j As Integer = 0 To ctlqual4.Items.Count - 1 Step 1
            Dim item4 = ctlqual4.Items(j)
            Dim itemQualName4 = item4.Text

            ' Is this a GCSE?
            If itemQualName4.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName4) Then
                ' Remove the item and reinsert at top
                ctlqual4.Items.Remove(item4)
                ctlqual4.Items.Insert(indexQual4, item4)
                ' Increment index to maintain alpha sort
                indexQual4 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank4 = ctlqual4.Items.FindByValue("")
        ctlqual4.Items.Remove(itemQualBlank4)
        ctlqual4.Items.Insert(0, itemQualBlank4)

        Dim itemGradeBlank4 = ctlgrades4.Items.FindByValue("")
        ctlgrades4.Items.Remove(itemGradeBlank4)
        ctlgrades4.Items.Insert(0, itemGradeBlank4)

        Dim itemPredictedGradeBlank4 = ctlpredictedgrades4.Items.FindByValue("")
        ctlpredictedgrades4.Items.Remove(itemPredictedGradeBlank4)
        ctlpredictedgrades4.Items.Insert(0, itemPredictedGradeBlank4)

        ''Render control for 6th object

        Dim ctlqual5 As DropDownList = TryCast(StudentQualsOnEntryField13.InternalFieldControl, DropDownList)
        Dim ctlgrades5 As DropDownList = TryCast(StudentQualsOnEntryField14.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades5 As DropDownList = TryCast(StudentQualsOnEntryField15.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade5 = 0
        For k As Integer = 0 To ctlgrades5.Items.Count - 1 Step 1
            Dim item5 = ctlgrades5.Items(k)
            Dim itemGradeName5 = item5.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName5
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades5.Items.Remove(item5)
                    ctlgrades5.Items.Insert(indexGrade5, item5)
                    ' Increment index to maintain alpha sort
                    indexGrade5 += 1
            End Select
        Next

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade5 = 0
        For k As Integer = 0 To ctlpredictedgrades5.Items.Count - 1 Step 1
            Dim item5 = ctlpredictedgrades5.Items(k)
            Dim itemGradeName5 = item5.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName5
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades5.Items.Remove(item5)
                    ctlpredictedgrades5.Items.Insert(indexPredictedGrade5, item5)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade5 += 1
            End Select
        Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual5 = 0
        For j As Integer = 0 To ctlqual5.Items.Count - 1 Step 1
            Dim item5 = ctlqual5.Items(j)
            Dim itemQualName5 = item5.Text

            ' Is this a GCSE?
            If itemQualName5.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName5) Then
                ' Remove the item and reinsert at top
                ctlqual5.Items.Remove(item5)
                ctlqual5.Items.Insert(indexQual5, item5)
                ' Increment index to maintain alpha sort
                indexQual5 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank5 = ctlqual5.Items.FindByValue("")
        ctlqual5.Items.Remove(itemQualBlank5)
        ctlqual5.Items.Insert(0, itemQualBlank5)

        Dim itemGradeBlank5 = ctlgrades5.Items.FindByValue("")
        ctlgrades5.Items.Remove(itemGradeBlank5)
        ctlgrades5.Items.Insert(0, itemGradeBlank5)

        Dim itemPredictedGradeBlank5 = ctlpredictedgrades5.Items.FindByValue("")
        ctlpredictedgrades5.Items.Remove(itemPredictedGradeBlank5)
        ctlpredictedgrades5.Items.Insert(0, itemPredictedGradeBlank5)

        ''Render control for 7th object

        Dim ctlqual6 As DropDownList = TryCast(StudentQualsOnEntryField21.InternalFieldControl, DropDownList)
        Dim ctlgrades6 As DropDownList = TryCast(StudentQualsOnEntryField22.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades6 As DropDownList = TryCast(StudentQualsOnEntryField23.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade6 = 0
        For k As Integer = 0 To ctlgrades6.Items.Count - 1 Step 1
            Dim item6 = ctlgrades6.Items(k)
            Dim itemGradeName6 = item6.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName6
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades6.Items.Remove(item6)
                    ctlgrades6.Items.Insert(indexGrade6, item6)
                    ' Increment index to maintain alpha sort
                    indexGrade6 += 1
            End Select
        Next

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade6 = 0
        For k As Integer = 0 To ctlpredictedgrades6.Items.Count - 1 Step 1
            Dim item6 = ctlpredictedgrades6.Items(k)
            Dim itemGradeName6 = item6.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName6
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades6.Items.Remove(item6)
                    ctlpredictedgrades6.Items.Insert(indexPredictedGrade6, item6)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade6 += 1
            End Select
        Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual6 = 0
        For j As Integer = 0 To ctlqual6.Items.Count - 1 Step 1
            Dim item6 = ctlqual6.Items(j)
            Dim itemQualName6 = item6.Text

            ' Is this a GCSE?
            If itemQualName6.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName6) Then
                ' Remove the item and reinsert at top
                ctlqual6.Items.Remove(item6)
                ctlqual6.Items.Insert(indexQual6, item6)
                ' Increment index to maintain alpha sort
                indexQual6 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank6 = ctlqual6.Items.FindByValue("")
        ctlqual6.Items.Remove(itemQualBlank6)
        ctlqual6.Items.Insert(0, itemQualBlank6)

        Dim itemGradeBlank6 = ctlgrades6.Items.FindByValue("")
        ctlgrades6.Items.Remove(itemGradeBlank6)
        ctlgrades6.Items.Insert(0, itemGradeBlank6)

        Dim itemPredictedGradeBlank6 = ctlpredictedgrades6.Items.FindByValue("")
        ctlpredictedgrades6.Items.Remove(itemPredictedGradeBlank6)
        ctlpredictedgrades6.Items.Insert(0, itemPredictedGradeBlank6)

        ''Render control for 8th object

        Dim ctlqual7 As DropDownList = TryCast(StudentQualsOnEntryField25.InternalFieldControl, DropDownList)
        Dim ctlgrades7 As DropDownList = TryCast(StudentQualsOnEntryField26.InternalFieldControl, DropDownList)
        Dim ctlpredictedgrades7 As DropDownList = TryCast(StudentQualsOnEntryField27.InternalFieldControl, DropDownList)

        ' Move all GCSE Grades to the top
        Dim indexGrade7 = 0
        For k As Integer = 0 To ctlgrades7.Items.Count - 1 Step 1
            Dim item7 = ctlgrades7.Items(k)
            Dim itemGradeName7 = item7.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName7
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlgrades7.Items.Remove(item7)
                    ctlgrades7.Items.Insert(indexGrade7, item7)
                    ' Increment index to maintain alpha sort
                    indexGrade7 += 1
            End Select
        Next

        ' Move all GCSE Predicted Grades to the top
        Dim indexPredictedGrade7 = 0
        For k As Integer = 0 To ctlpredictedgrades7.Items.Count - 1 Step 1
            Dim item7 = ctlpredictedgrades7.Items(k)
            Dim itemGradeName7 = item7.Text

            ' Is this a GCSE Grade A*-G or 1-9?
            Select Case itemGradeName7
                Case "A*", "A", "B", "C", "D", "E", "F", "G", "U",
                     "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    ' Remove the item and reinsert at top
                    ctlpredictedgrades7.Items.Remove(item7)
                    ctlpredictedgrades7.Items.Insert(indexPredictedGrade7, item7)
                    ' Increment index to maintain alpha sort
                    indexPredictedGrade7 += 1
            End Select
        Next

        ' Move all GCSE Qualifications to the top
        Dim indexQual7 = 0
        For j As Integer = 0 To ctlqual7.Items.Count - 1 Step 1
            Dim item7 = ctlqual7.Items(j)
            Dim itemQualName7 = item7.Text

            ' Is this a GCSE?
            If itemQualName7.StartsWith("GCSE") Or String.IsNullOrWhiteSpace(itemQualName7) Then
                ' Remove the item and reinsert at top
                ctlqual7.Items.Remove(item7)
                ctlqual7.Items.Insert(indexQual7, item7)
                ' Increment index to maintain alpha sort
                indexQual7 += 1
            End If
        Next

        ' Reinsert blank entries at top
        Dim itemQualBlank7 = ctlqual7.Items.FindByValue("")
        ctlqual7.Items.Remove(itemQualBlank7)
        ctlqual7.Items.Insert(0, itemQualBlank7)

        Dim itemGradeBlank7 = ctlgrades7.Items.FindByValue("")
        ctlgrades7.Items.Remove(itemGradeBlank7)
        ctlgrades7.Items.Insert(0, itemGradeBlank7)

        Dim itemPredictedGradeBlank7 = ctlpredictedgrades7.Items.FindByValue("")
        ctlpredictedgrades7.Items.Remove(itemPredictedGradeBlank7)
        ctlpredictedgrades7.Items.Insert(0, itemPredictedGradeBlank7)

        MyBase.RenderControl(writer)


    End Sub


    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        If Page.IsValid Then
            Response.Redirect(GetResourceValue("checkout_attachments_1618_aspx"))


        End If
    End Sub

    Public Overrides Sub ValidateControl()

        MyBase.ValidateControl()

        ''Date > Today Checkers
        If DateAwarded.Value.ToString.Length > 0 Then
            If DateAwarded.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If

        If StudentQualsOnEntryField4.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField4.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If

        If StudentQualsOnEntryField8.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField8.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If

        If StudentQualsOnEntryField12.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField12.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If

        If StudentQualsOnEntryField16.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField16.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If
        If StudentQualsOnEntryField20.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField20.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If
        If StudentQualsOnEntryField24.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField24.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If
        If StudentQualsOnEntryField28.Value.ToString.Length > 0 Then
            If StudentQualsOnEntryField28.Value > Today Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please dont enter a value greater than today"
                Me.Page.Validators.Add(v)
            End If
        End If
        'Validation for QoE Mandatory Entry for Drade Or PredGrade

        If StudentQualsOnEntryField17.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField18.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField19.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 1, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If

        If Qual.Value.ToString.Length > 0 AndAlso (Not Grade.Value.ToString.Length > 0 AndAlso Not PredGrade.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 2, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If

        If StudentQualsOnEntryField1.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField2.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField3.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 3, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If

        If StudentQualsOnEntryField5.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField6.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField7.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 4, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If


        If StudentQualsOnEntryField9.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField10.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField11.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 5, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If

        If StudentQualsOnEntryField13.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField14.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField15.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 6, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If

        If StudentQualsOnEntryField21.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField22.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField23.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 7, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If
        If StudentQualsOnEntryField25.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField26.Value.ToString.Length > 0 AndAlso Not StudentQualsOnEntryField27.Value.ToString.Length > 0) Then
            Dim v As New CustomValidator
            v.IsValid = False
            v.ErrorMessage = "If you have entered Qualification 8, you must enter the Grade (or predicted grade)"
            Me.Page.Validators.Add(v)
        End If


        '''Manadatory Date Award
        'If Qual.Value.ToString.Length > 0 AndAlso (Not DateAwarded.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 1 , you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If

        'If StudentQualsOnEntryField1.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField4.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 2, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If

        'If StudentQualsOnEntryField5.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField9.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 3, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If

        'If StudentQualsOnEntryField9.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField12.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 4, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If

        'If StudentQualsOnEntryField13.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField16.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 5, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If

        'If StudentQualsOnEntryField17.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField20.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 6, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If
        'If StudentQualsOnEntryField21.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField24.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 7, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If
        'If StudentQualsOnEntryField25.Value.ToString.Length > 0 AndAlso (Not StudentQualsOnEntryField28.Value.ToString.Length > 0) Then
        '    Dim v As New CustomValidator
        '    v.IsValid = False
        '    v.ErrorMessage = "If you have entered Qualification 8, you must enter the Date Awarded"
        '    Me.Page.Validators.Add(v)
        'End If
    End Sub

End Class
