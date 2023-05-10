Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class checkout_applications
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Reset to look at main address again (If user is navigating backwards
        PSWebEnrolmentProperties.IsCurrentlyTakingAltAddress = False

        If Not IsPostBack Then
            
            WorkingData.EnrolmentRequestRow.RestrictedUseAllowContactByEmail = True


        End If
    End Sub


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

If Len(datepicker.value) > 0 Then
            If IsDate(datepicker.value) AndAlso YearsBetweenDates(CDate(datepicker.value), Today.Date) < 14 Then
                Dim v As New CustomValidator
                v.IsValid = False
                v.ErrorMessage = "Please check your date of birth has been entered correctly. It looks like you have entered an incorrect date."
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
