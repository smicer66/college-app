Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class webcontrols_checkout_enrolments
    Inherits CheckoutBaseControl

Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

		'ExtraSupport
		WorkingData.EnrolmentRequestRow.StudentDetailUserDefined8 = drpExtraSupport.SelectedValue
		WorkingData.EnrolmentRequestRow.StudentDetailUserDefined9 = txtEAA.Text
	
	'MainReasonForCourse
        If drpMainCourseReason.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select the main reason for doing this course"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else
            WorkingData.EnrolmentRequestRow.EnrolmentUserDefined9 = drpMainCourseReason.SelectedValue
        End If

   End Sub

       
Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

		Me.Page.Validate()
                'Response.Redirect(GetResourceValue("onlineenrolmentnotavailable_e_aspx"))

End Sub
        

    Protected Overrides Sub OnLoad(e As EventArgs)
'Added by Tina to redirect to courses page till enrolments goes live
        'Response.Redirect("http://www.cityofbristol.ac.uk/courses")
	
	If Page.IsPostBack = False Then

			drpExtraSupport.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined8
			txtEAA.Text = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined9
			drpMainCourseReason.SelectedValue = WorkingData.EnrolmentRequestRow.EnrolmentUserDefined9

	End If


        MyBase.OnLoad(e)
    End Sub
  
End Class
