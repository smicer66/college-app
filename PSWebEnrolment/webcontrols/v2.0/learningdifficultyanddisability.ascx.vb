'Option Explicit On
'Option Strict On

Imports System.Activities.Expressions
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class learningdifficultyanddisability
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False
        'Response.Write(Page.Session("TLearningDifficultySelected").ToString)

        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            btnBack1.Visible = False
            btnBack.Visible = True


        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Dim IsAccessOrConstructionCourse As Boolean = False


            For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
                'Response.Write(item.Description)
                If (item.Description.IndexOf("Access to HE") > -1) Then
                    IsAccessOrConstructionCourse = True
                End If

            Next

            If (IsAccessOrConstructionCourse.Equals(True)) Then
                btnBack1.Visible = True
                btnBack.Visible = False
            Else
                btnBack1.Visible = False
                btnBack.Visible = True
            End If
        End If


        Dim enumerator As IEnumerator = DisabilityCategory1ID.Controls.GetEnumerator()

        Dim divFormGroup As New HtmlGenericControl("div")
        divFormGroup.Attributes("class") = "form-group"
        While enumerator.MoveNext()
            Dim ctrl As Control = DirectCast(enumerator.Current, Control)

            If TypeOf ctrl Is DropDownList Then
                Dim ddl As DropDownList = DirectCast(ctrl, DropDownList)


                For Each item As ListItem In ddl.Items
                    'Response.Write(item.Value & " = " & item.Text)
                    'otherLDDDiv
                    If (item.Text.Length > 0) Then

                        Dim checkbox As New HtmlInputCheckBox()
                        checkbox.ID = "fldOtherCheckbox_" + item.Value
                        'checkbox.Text = item.Text
                        checkbox.Value = item.Value
                        checkbox.Name = "otherDisability"

                        'Dim lbl As New HtmlGenericControl("label")
                        'lbl.ID = "label_" + item.Value
                        'lbl.Attributes("class") = "condition-option"

                        ''checkbox.Text = item.Text
                        'lbl.InnerText = item.Text


                        'divFormGroup.Controls.Add(checkbox)
                        'divFormGroup.Controls.Add(lbl)

                        'otherLDDDiv.Controls.Add(divFormGroup)
                        Dim lbl As New HtmlGenericControl("label")
                        lbl.ID = "label_" + item.Value
                        lbl.Attributes("class") = "condition-option"
                        lbl.Attributes("class") = "condition-option"

                        'checkbox.Text = item.Text
                        'lbl.InnerText = item.Text


                        If Not IsPostBack Then
                            If WorkingData.ApplicationRequestRow IsNot Nothing AndAlso WorkingData.ApplicationRequestRow.StudentDetailUserDefined47 IsNot Nothing Then
                                For Each j As String In WorkingData.ApplicationRequestRow.StudentDetailUserDefined47.ToString.Split(",")
                                    If j.Equals(item.Value.ToString) Then
                                        checkbox.Checked = True
                                    End If
                                Next
                            End If
                        End If


                        Dim sp As New HtmlGenericControl("span")
                        sp.InnerText = item.Text

                        lbl.Controls.Add(checkbox)
                        lbl.Controls.Add(sp)
                        'divFormGroup.Controls.Add(lbl)

                        otherLDDDiv.Controls.Add(lbl)
                    End If

                Next
            End If
        End While


        If Not IsPostBack Then
            LearningDiffOrDisID.SelectedValue = WorkingData.ApplicationRequestRow.LearningDifficultyID
            drpPrevSupport.SelectedValue = WorkingData.ApplicationRequestRow.StudentDetailUserDefined8
            If Page.Session("TDrpEHCP") IsNot Nothing AndAlso Page.Session("TDrpEHCP").Equals("Yes") Then
                drpEHCP.SelectedValue = 1
            ElseIf Page.Session("TDrpEHCP") IsNot Nothing AndAlso Page.Session("TDrpEHCP").Equals("No") Then
                drpEHCP.SelectedValue = 0
            End If

            drpShareSchl.SelectedValue = WorkingData.ApplicationRequestRow.StudentDetailUserDefined42
            evacuationAssistance.SelectedValue = WorkingData.ApplicationRequestRow.StudentDetailUserDefined46

            If WorkingData.ApplicationRequestRow IsNot Nothing AndAlso WorkingData.ApplicationRequestRow.LearningDifficultyID IsNot Nothing AndAlso WorkingData.ApplicationRequestRow.LearningDifficultyID.Equals("1") Then


                disfields.Visible = True


            End If


        End If

    End Sub


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        '  Response.Write(ddlAlevel_one.SelectedIndex)
        If LearningDiffOrDisID IsNot Nothing AndAlso LearningDiffOrDisID.SelectedItem IsNot Nothing Then

        Else
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you have a learning difficulty, disability or health condition."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If drpPrevSupport IsNot Nothing AndAlso drpPrevSupport.SelectedItem.Value.Equals("").Equals(False) Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you receive additional support from your previous school."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If drpEHCP IsNot Nothing AndAlso drpEHCP.SelectedItem IsNot Nothing Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you have an Education Health Care Plan."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If drpShareSchl IsNot Nothing AndAlso drpShareSchl.SelectedItem IsNot Nothing Then


        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if we can request data regarding your support needs from your school."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If

        If evacuationAssistance IsNot Nothing AndAlso evacuationAssistance.SelectedItem.Value.Equals("").Equals(False) Then

        Else

            Dim v As New CustomValidator()
            v.ErrorMessage = "Please specify if you would require assistance to evacuate the building in the event of an emergency."
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
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


        Me.Page.Validate()

        If Me.Page.IsValid Then
            Page.Session("TLearningDiffOrDisID") = LearningDiffOrDisID.SelectedItem.Text
            WorkingData.ApplicationRequestRow.LearningDifficultyID = LearningDiffOrDisID.SelectedItem.Value

            Page.Session("TDrpPrevSupport") = drpPrevSupport.SelectedItem.Text
            WorkingData.ApplicationRequestRow.StudentDetailUserDefined8 = drpPrevSupport.SelectedItem.Value

            Page.Session("TDrpEHCP") = drpEHCP.SelectedItem.Text
            WorkingData.ApplicationRequestRow.HasEducationHealthCarePlan = drpEHCP.SelectedItem.Value

            Page.Session("TDrpShareSchl") = drpShareSchl.SelectedItem.Text
            WorkingData.ApplicationRequestRow.StudentDetailUserDefined42 = drpShareSchl.SelectedItem.Value

            Page.Session("TEvacuationAssistance") = evacuationAssistance.SelectedItem.Text
            WorkingData.ApplicationRequestRow.StudentDetailUserDefined46 = evacuationAssistance.SelectedItem.Value

            'Page.Session("TLearningDiffOrDisID") = LearningDiffOrDisID.SelectedItem.Text
            'WorkingData.EnrolmentRequest(0).StudentDetailUserDefined21 = LearningDiffOrDisID.SelectedItem.Value

            Dim selectedTexts As New List(Of String)
            Dim selectedValues As New List(Of String)

            For Each ctrl As Control In otherLDDDiv.Controls

                If TypeOf ctrl Is HtmlGenericControl Then

                    For Each child As Control In ctrl.Controls

                        If TypeOf child Is HtmlInputCheckBox Then

                            Dim checkbox As HtmlInputCheckBox = DirectCast(child, HtmlInputCheckBox)

                            If checkbox.Checked Then

                                Dim divFormGroup As New HtmlGenericControl("div")
                                divFormGroup.Attributes("class") = "form-group"
                                Dim enumerator As IEnumerator = DisabilityCategory1ID.Controls.GetEnumerator()
                                While enumerator.MoveNext()
                                    Dim ctrl1 As Control = DirectCast(enumerator.Current, Control)

                                    If TypeOf ctrl1 Is DropDownList Then
                                        Dim ddl As DropDownList = DirectCast(ctrl1, DropDownList)


                                        For Each item As ListItem In ddl.Items
                                            If item.Value.Equals(checkbox.Value) Then

                                                selectedValues.Add(checkbox.Value)
                                                selectedTexts.Add(item.Text)

                                            End If
                                        Next
                                    End If
                                End While



                            End If

                        End If

                    Next

                End If

            Next

            If selectedValues.Count > 0 Then
                WorkingData.ApplicationRequestRow.StudentDetailUserDefined47 = String.Join(",", selectedValues)
                Page.Session("TLearningDifficultySelected") = String.Join(", ", selectedTexts)
            End If

            If DisabilityCategory1ID IsNot Nothing AndAlso DisabilityCategory1ID.Value IsNot Nothing Then
                Dim ddlMainDisability As DropDownList = DirectCast(DisabilityCategory1ID.InternalFieldControl, DropDownList)
                Page.Session("TMainDisabilitySelected") = ddlMainDisability.SelectedItem.Text

            End If



            If Me.Page.IsValid Then
                Response.Redirect(GetResourceValue("additionaldetails_aspx"))
            End If

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
        End If


    End Sub




    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click


        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Write(1)

        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Response.Write(2)
        End If
    End Sub




    Public Sub LearningDiffOrDisID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LearningDiffOrDisID.SelectedIndexChanged

        If LearningDiffOrDisID.SelectedValue.Equals("1") Then
            disfields.Visible = True
        Else
            disfields.Visible = False
        End If
    End Sub
End Class
