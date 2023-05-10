Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class webcontrols_checkout_school_employer
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        'Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType, "Load", "<script type=""text/javascript""> $(function () {var c = $(""#employerpanel""); c.showLoading(); }); </script>")
        'Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType, "UnLoad", "<script type=""text/javascript""> $(function () {var c = $(""#employerpanel""); c.hideLoading(); }); </script>")
        MyBase.OnLoad(e)

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

        ' MyBase.LoadDatePickerCSS()

        'Custom code to colour the form based on the contents of the shopping basket
        'Use this when sharing pages between types (Application/Enrolment)

        'Clear class attributes first
        Me.schoolpanel.Attributes("class") = ""
        Me.employerpanel.Attributes("class") = ""
        'Me.empnote.Attributes("class") = ""

        If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Me.schoolpanel.Attributes("class") = "panel panel-danger"
            Me.employerpanel.Attributes("class") = "panel panel-danger"
            'Me.empnote.Attributes("class") = "alert alert-danger"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Me.schoolpanel.Attributes("class") = "panel panel-danger"
            Me.employerpanel.Attributes("class") = "panel panel-danger"
            'Me.empnote.Attributes("class") = "alert alert-danger"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Me.schoolpanel.Attributes("class") = "panel panel-success"
            Me.employerpanel.Attributes("class") = "panel panel-success"
            'Me.empnote.Attributes("class") = "alert alert-success"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
            Me.schoolpanel.Attributes("class") = "panel panel-info"
            Me.employerpanel.Attributes("class") = "panel panel-info"
            'Me.empnote.Attributes("class") = "alert alert-info"
        Else
            Me.schoolpanel.Attributes("class") = "panel panel-danger"
            Me.employerpanel.Attributes("class") = "panel panel-danger"
            'Me.empnote.Attributes("class") = "alert alert-danger"
        End If
        'Checking for Age to skip the page
        Dim age As Integer
        age = Today.Year - Convert.ToDateTime(WorkingData.ApplicationRequestRow.DateOfBirth).Year
        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            If (age > 19) Then
                'Hide a panel
                pnlSchool.Visible = False
            Else
                pnlSchool.Visible = True
            End If
        End If
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Redirect(GetResourceValue("checkout_enrolments2_aspx"))
        End If
    End Sub

    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()
        'English
        If drpEmpStatus.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option for Employment Status"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else
            If drpEmpStatus.SelectedValue = "10" Then
                WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID = "10"

                'Dim v1 As New CustomValidator()
                'v1.ErrorMessage = "Please select an option for Employment Intensity"
                'v1.IsValid = False
                'Me.Page.Validators.Add(v1)
                'Me.ValidationSummary1.ShowSummary = True

            ElseIf drpEmpStatus.SelectedValue = "11" Then
                WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID = "11"
            ElseIf drpEmpStatus.SelectedValue = "12" Then
                WorkingData.EnrolmentRequestEmploymentHistoryRow.EmploymentStatusID = "12"
            End If
        End If
    End Sub
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()

        If Me.Page.IsValid Then
            'WorkingData.EnrolmentRequestEmploymentHistory(0).EmployerName = fldEmployerName.Value
            'Dim pcode As String = Replace(employerpostcode.Value, " ", "")
            'If Len(pcode) > 0 Then
            '    WorkingData.EnrolmentRequest(0).EmployerPostcodeOut = pcode.Substring(0, pcode.Length - 3)
            '    WorkingData.EnrolmentRequest(0).EmployerPostcodeIn = Right(pcode, 3)
            'End If


            If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
                Response.Redirect(GetResourceValue("checkout_priorattainment_aspx"))
            ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
                Response.Redirect(GetResourceValue("checkout_dataprotection_apponly_aspx"))
            End If

        End If

    End Sub


    Protected Sub drpEmpStatus_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpEmpStatus.SelectedIndexChanged
        If drpEmpStatus.SelectedValue = "9" Then
            'SelfEmployed
            WorkingData.EnrolmentRequestEmploymentHistoryRow.IsSelfEmployed = True
            pnlUnEmploymentDetails.Visible = False
            pnlEmployerDetails.Visible = False
            'Show only intensity and date from
            pnlEmployed.Visible = True
            fldEmploymentIntensity.CustomCaption = "Employment Intensity *"
            fldEmploymentIntensity.IsRequired = True
            fldLengthofEmployment.CustomCaption = "Length of Employment *"
            fldLengthofEmployment.IsRequired = True
            fldDateFrom.CustomCaption = "Date From *"
            fldDateFrom.IsRequired = True
            fldUnEmploymentDateFrom.CustomCaption = "Date From"
            fldUnEmploymentDateFrom.IsRequired = False
        ElseIf drpEmpStatus.SelectedValue = "10" Then
            pnlUnEmploymentDetails.Visible = False
            pnlEmployed.Visible = True
            pnlEmployerDetails.Visible = True
            fldEmploymentIntensity.IsRequired = True
            fldEmploymentIntensity.CustomCaption = "Employment Intensity *"
            fldLengthofEmployment.CustomCaption = "Length of Employment *"
            fldLengthofEmployment.IsRequired = True
            fldDateFrom.CustomCaption = "Date From *"
            fldDateFrom.IsRequired = True
            fldUnEmploymentDateFrom.CustomCaption = "Date From"
            fldUnEmploymentDateFrom.IsRequired = False
        ElseIf drpEmpStatus.SelectedValue = "11" Then
            pnlUnEmploymentDetails.Visible = True
            pnlEmployed.Visible = False
            pnlEmployerDetails.Visible = False
            fldDateFrom.CustomCaption = "Date From"
            fldDateFrom.IsRequired = False
            fldLengthofUnEmployment.IsRequired = True
            fldLengthofUnEmployment.CustomCaption = "Length of Unemployment  *"
            fldLengthofUnEmployment.Focus()
            fldEmploymentIntensity.IsRequired = False
            fldEmploymentIntensity.CustomCaption = "Employment Intensity"
            fldLengthofEmployment.CustomCaption = "Length of Employment"
            fldLengthofEmployment.IsRequired = False
            pnlEmployed.Visible = False
            fldUnEmploymentDateFrom.CustomCaption = "Date From *"
            fldUnEmploymentDateFrom.IsRequired = True
        ElseIf drpEmpStatus.SelectedValue = "12" Then
            pnlUnEmploymentDetails.Visible = True
            pnlEmployed.Visible = False
            pnlEmployerDetails.Visible = False
            fldDateFrom.CustomCaption = "Date From"
            fldDateFrom.IsRequired = False
            fldLengthofUnEmployment.IsRequired = True
            fldLengthofUnEmployment.CustomCaption = "Length of Unemployment  *"
            fldLengthofUnEmployment.Focus()
            fldEmploymentIntensity.IsRequired = False
            fldEmploymentIntensity.CustomCaption = "Employment Intensity"
            pnlEmployed.Visible = False
            fldLengthofEmployment.CustomCaption = "Length of Employment"
            fldLengthofEmployment.IsRequired = False
            fldUnEmploymentDateFrom.CustomCaption = "Date From *"
            fldUnEmploymentDateFrom.IsRequired = True
        Else
            pnlUnEmploymentDetails.Visible = False
            fldLengthofUnEmployment.IsRequired = False
            fldEmploymentIntensity.IsRequired = False
            fldLengthofEmployment.CustomCaption = "Length of Employment"
            fldLengthofEmployment.IsRequired = False
            fldLengthofUnEmployment.CustomCaption = "Length of Unemployment "
            fldEmploymentIntensity.CustomCaption = "Employment Intensity"
            pnlEmployed.Visible = False
            pnlEmployerDetails.Visible = False
        End If


    End Sub
End Class
