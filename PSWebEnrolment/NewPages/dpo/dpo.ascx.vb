Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class accept
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)


    End Sub
    Public Overrides Sub ValidateControl()
        ' Response.Write(ddlOutomeType.SelectedValue)
        'MainReasonForCourse
        If ddlOutomeType.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please tell us your current desintation or progression"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If
        If ddlOutomeType.SelectedValue = "EDU" Then
            If ddlEdu.SelectedValue = "" Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please tell us the type of Education"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If
        If ddlOutomeType.SelectedValue = "EMP" Then
            If ddlInEmp.SelectedValue = "" Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please tell us the type of paid employment"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If
        If ddlOutomeType.SelectedValue = "EMP" Then
            If ddlSOC.SelectedValue = "" Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please select the closest occupation that best describes your job"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If
        If ddlOutomeType.SelectedValue = "NPE" Then
            If ddlNotInEmp.SelectedValue = "" Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please tell us the type of Not In Paid Employment"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If
    End Sub

    Public ReadOnly Property sdid() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("sdid")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("sdid"))
            End If
        End Get
    End Property



    'Private Sub btnStage1_Click(sender As Object, e As EventArgs) Handles btnStage1.Click
    '    Response.Redirect(GetResourceValue("checkout_evidence_aspx"))
    'End Sub
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()
        If Me.Page.IsValid And sdid() > 0 Then


            Dim tblEnquiryRequest As EnquiryRequestDataTable = WorkingData.EnquiryRequest

            tblEnquiryRequest.Clear()

            Dim row As EnquiryRequestRow = tblEnquiryRequest.NewRow

            row.AcademicYearID = "21/22"
            If sdid() > 0 Then row.EnquiryUserDefined1 = sdid()

            row.RequestStatus = "dpo"
            row.EnquiryUserDefined2 = ddlOutomeType.SelectedValue
            row.EnquiryUserDefined3 = ddlEdu.SelectedValue
            row.EnquiryUserDefined4 = ddlInEmp.SelectedValue
            row.EnquiryUserDefined5 = ddlNotInEmp.SelectedValue
            row.EnquiryUserDefined6 = ddlSOC.SelectedValue
            tblEnquiryRequest.Rows.Add(row)

            tblEnquiryRequest.TableAdapter.Save(tblEnquiryRequest)

            WorkingData.ShoppingCart.Items.Clear()

            CCCPageLibrary.NavigateToPage(GetResourceValue("thankyou_dpo_aspx"))

        End If



    End Sub



End Class
