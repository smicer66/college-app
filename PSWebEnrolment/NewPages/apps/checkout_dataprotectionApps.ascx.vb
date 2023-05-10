Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class checkout_dataprotection
    Inherits CheckoutBaseControl


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Dim p As New PaymentSubmitter

        If p.ShouldTransferToPaymentSite AndAlso System.Configuration.ConfigurationManager.AppSettings("UsePayPal") = "1" Then
            btnContinue.ImageResource = "PayPalButton"
        End If


        'Dim rowAttachment = WorkingData.EnrolmentRequestAttachment
        'WorkingData.EnrolmentRequestAttachments.TypeOfEvidence
        ''_lastAttachmentID -= 1
        'With rowAttachment

        '    ' Response.Write(WorkingData.EnrolmentRequestAttachments.) ' = ddlTypeOfEvidence.SelectedValue

        'End With
        ' If Session("euro") = "2" Then divEuro.Visible = True

    End Sub

    Public Overrides Sub ValidateControl()


        If Not chkConfirm.Checked Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please confirm the information given in this form is correct and complete."
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If

        'If Not checkID.Checked Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please confirm that you have uploded your identity document."
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        'End If

        'If Not checkPhoto.Checked Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please confirm that you have uploaded your photo."
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        'End If

        'If Not checkUK.Checked And Session("euro") = "2" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please confirm that you have uploaded your UK/EE residency evidence"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        'End If

        'If Not checkAch.Checked Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please confirm that you have uploaded a copy of all certificates achieved."
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        'End If

        'If Not StudentSignature.Signature IsNot Nothing Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please sign the application."
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)

        '    Me.ValidationSummary1.ShowSummary = True
        'End If
    End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        ValidateControl()

        If Me.Page.IsValid Then

            'used to store age but now clear them down
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined1 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined2 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined4 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined7 = ""
            'WorkingData.EnrolmentRequestRow.StudentDetailUserDefined8 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined9 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined10 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined11 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined12 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined13 = ""
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined14 = ""

            'If 1 = 2 Then
            '    'put them on the undecided offering by default if fails to find proper offeringid for applicants/vistors
            '    Dim IntOffering1ID As Integer = 130360
            '    If Not WorkingData.CurrentLoggedOnUserRow Is Nothing Then
            '        If Not WorkingData.CurrentLoggedOnUserRow.Email Is Nothing Then
            '            Dim SQLDBDataReader As SqlClient.SqlDataReader
            '            Dim SQLDataTable As New DataTable
            '            Dim cmd As New SqlCommand
            '            Dim SQLCmd As New SqlClient.SqlConnection

            '            SQLCmd.ConnectionString = GetConn()
            '            SQLCmd.Open()
            '            cmd.CommandText = "PSWebenrolmentReports.dbo.spGetStudentDetailsByEmail"
            '            cmd.CommandType = CommandType.StoredProcedure
            '            cmd.Connection = SQLCmd
            '            cmd.Parameters.AddWithValue("email", WorkingData.CurrentLoggedOnUserRow.Email)
            '            SQLDBDataReader = cmd.ExecuteReader()

            '            If SQLDBDataReader.HasRows Then
            '                While (SQLDBDataReader.Read)
            '                    'Session("refno") = CStr(SQLDBDataReader("refno"))
            '                    ' If Not IsDBNull(SQLDBDataReader("refno")) Then WorkingData.EnrolmentRequestRow.RefNo = CStr(SQLDBDataReader("refno"))
            '                    If Not IsDBNull(SQLDBDataReader("oid")) Then IntOffering1ID = SQLDBDataReader("oid")
            '                End While
            '            End If
            '        End If

            '        If IntOffering1ID > -1 Then
            '            Dim tblOffering1 As New OfferingDataTable
            '            Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tblOffering1)
            '            v.Columns.AddPKColumns()
            '            v.Columns.EnsureColumnsAreSelected(True, False, tblOffering1.WebSiteAvailabilityIDColumn, tblOffering1.CourseInformationIDColumn, tblOffering1.TotalFeeAmountColumn, tblOffering1.OfferingTypeIDColumn)
            '            v.Filters.SetColumnFilter(tblOffering1.OfferingIDColumn, IntOffering1ID)
            '            tblOffering1.TableAdapter.Load(tblOffering1, v)
            '            WorkingData.ShoppingCart.Items.Clear()

            '            If tblOffering1.Count > 0 AndAlso tblOffering1(0).WebSiteAvailabilityID.HasValue Then
            '                Dim item As New ShoppingCartItem()
            '                With tblOffering1(0)
            '                    'Dim CourseOfferingFees As New CourseOfferingFees(CType(.OfferingID, Integer))
            '                    If .TotalFeeAmount.HasValue Then
            '                        item.Cost = CDec(.TotalFeeAmount.Value.ToString())
            '                    End If
            '                    item.Description = .GetRowDescription
            '                    item.ItemType = "Enrolment"
            '                    item.OfferingID = .OfferingID.Value
            '                    item.CourseInfoID = .CourseInformationID.GetValueOrDefault
            '                End With
            '                With WorkingData.ShoppingCart
            '                    If Not .Items.Contains(item) Then
            '                        .Items.Add(item)

            '                    End If
            '                End With
            '            End If
            '        End If
            '        '  WorkingData.EnrolmentRequestRow.StudentSignature = StudentSignature.Signature

            '    End If
            'End If

            If Me.Page.IsValid Then
                ' WorkingData.EnrolmentRequestRow.RequestStatus = "app_app"
                Server.Transfer(GetResourceValue("checkout_makepayment_aspx"))

            Else
                ' StudentSignature.SignatureHiddenValue = "" 'hides the hidden value of the signature so you have to sign again

            End If
        End If

    End Sub

End Class
