Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class checkout_payment
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        If System.Configuration.ConfigurationManager.AppSettings("UseWorldPay") = "1" Then
            Dim strPaymentID As String = Request("cartId")
            Dim strStatus As String = Request("transStatus")
            If Len(strStatus) > 0 And Len(strPaymentID) > 0 Then
                If strStatus.ToString.ToUpper = "Y" Then
                    'Update payment status
                    Dim tbl As New EnrolmentRequestDataTable
                    Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tbl)
                    v.Columns.AddAllColumns(False, False)
                    v.Filters.SetColumnFilter(tbl.WebPaymentIDColumn, strPaymentID)
                    tbl.TableAdapter.Load(tbl, v)

                    For Each row As EnrolmentRequestRow In tbl.Select()
                        row.PaymentStatus = "Paid"
                        row.PaymentMethodID = 6
                    Next
                    tbl.TableAdapter.Save(tbl)

                End If

                Me.Controls.Add(New LiteralControl("<h2>Process Complete - Payment Successful</h2>"))
                Me.Controls.Add(New LiteralControl("<p>Please come into college to complete the process</p>"))

            Else
                Dim strMsg As String = "transStatus and cartId must be supplied"

                Me.Controls.Add(New LiteralControl("<h2>Process Complete</h2>"))
                Me.Controls.Add(New LiteralControl("<p>Your request has been received but there was a problem processing the result your payment. The payment may have been successful. The error message received was:" & strMsg & " Please contact the college to continue the process.</p>"))
            End If
        ElseIf System.Configuration.ConfigurationManager.AppSettings("UseRealEx") = "1" Then
            Dim strPaymentID As String = Request("WebPaymentID")
            Dim strStatus As String = Request("RESULT")
            If Len(strStatus) > 0 And Len(strPaymentID) > 0 Then
                If strStatus.ToString = "00" Then
                    'Update payment status
                    Dim tbl As New EnrolmentRequestDataTable
                    Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tbl)
                    v.Columns.AddAllColumns(False, False)
                    v.Filters.SetColumnFilter(tbl.WebPaymentIDColumn, strPaymentID)
                    tbl.TableAdapter.Load(tbl, v)

                    For Each row As EnrolmentRequestRow In tbl.Select()
                        row.PaymentStatus = "Paid"
                    Next
                    tbl.TableAdapter.Save(tbl)

                End If

                Me.Controls.Add(New LiteralControl("<h2>Process Complete - Payment Successful</h2>"))
                Me.Controls.Add(New LiteralControl("<p>Please come into college to complete the process</p>"))

            Else
                Dim strMsg As String = "ORDER_ID and/or RESULT not returned from RealEx"
                Me.Controls.Add(New LiteralControl("<h2>Process Complete</h2>"))
                Me.Controls.Add(New LiteralControl("<p>Your request has been received but there was a problem processing the result your payment. The payment may have been successful. The error message received was:" & strMsg & " Please contact the college to continue the process.</p>"))

            End If
        ElseIf System.Configuration.ConfigurationManager.AppSettings("UsePayPal") = "1" Then
            'If sent here by PayPal then payment successful...

            Dim strInvoice As String = Request("invoice")
            If Len(strInvoice) > 0 Then
                'Update payment status
                Dim tbl As New EnrolmentRequestDataTable
                Dim v As CCCDataViewDataSet = CCCDataViewDataSet.CreateDataView(tbl)
                v.Columns.AddAllColumns(False, False)
                v.Filters.SetColumnFilter(tbl.WebPaymentIDColumn, strInvoice)
                tbl.TableAdapter.Load(tbl, v)

                For Each row As EnrolmentRequestRow In tbl.Select()
                    row.PaymentStatus = "Paid"
                Next
                tbl.TableAdapter.Save(tbl)
            End If

            End If


    End Sub
End Class