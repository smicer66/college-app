Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon

Partial Class accept
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not Page.IsPostBack Then
            If appID() > 0 Then
                fldRefno.Visible = False
                fldEmail.Visible = False
            Else
                fldRefno.Visible = True
                fldEmail.Visible = True
            End If
            courseLabel.Text = CourseLabelParam()
        End If
    End Sub
    Public Overrides Sub ValidateControl()
        ' Response.Write(ddlAccept.SelectedValue)
        'MainReasonForCourse
        If ddlAccept.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please tell us your decision"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        End If
        If ddlAccept.SelectedValue = "2" Then
            If ddlWhy.SelectedValue = "" Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please tell us why your are decling the offer"
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If

    End Sub

    Public ReadOnly Property appID() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("appID")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("appID"))
            End If
        End Get
    End Property

    Public ReadOnly Property CourseLabelParam() As String
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("c")) Then
                Return ""
            Else
                Return CStr(Me.Page.Request("c"))
            End If
        End Get
    End Property


    'Private Sub btnStage1_Click(sender As Object, e As EventArgs) Handles btnStage1.Click
    '    Response.Redirect(GetResourceValue("checkout_evidence_aspx"))
    'End Sub
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()
        If Me.Page.IsValid Then


            Dim tblEnquiryRequest As EnquiryRequestDataTable = WorkingData.EnquiryRequest

            tblEnquiryRequest.Clear()

            Dim row As EnquiryRequestRow = tblEnquiryRequest.NewRow

            row.AcademicYearID = "21/22"
            If appID() > 0 Then
                row.EnquiryUserDefined1 = appID
            Else
                If Len(fldRefno.Value) > 0 Then

                    row.RefNo = CInt(fldRefno.Value)

                End If
                row.EMailAddress = fldEmail.Value
            End If
            row.RequestStatus = "accept"
            row.EnquiryUserDefined2 = ddlAccept.SelectedValue
            row.EnquiryUserDefined3 = ddlWhy.SelectedValue

            tblEnquiryRequest.Rows.Add(row)

            tblEnquiryRequest.TableAdapter.Save(tblEnquiryRequest)

            WorkingData.ShoppingCart.Items.Clear()

            CCCPageLibrary.NavigateToPage(GetResourceValue("thankyou_accceptance_aspx"))

        End If



    End Sub



End Class
