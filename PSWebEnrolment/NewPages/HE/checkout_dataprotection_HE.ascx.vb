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

        'Dim rowAttachment = WorkingData.EnrolmentRequestAttachment
        'WorkingData.EnrolmentRequestAttachments.TypeOfEvidence
        ''_lastAttachmentID -= 1
        'With rowAttachment

        '    ' Response.Write(WorkingData.EnrolmentRequestAttachments.) ' = ddlTypeOfEvidence.SelectedValue

        'End With
        If Session("euro") = "2" Then divEuro.Visible = True

    End Sub

    Public Overrides Sub ValidateControl()

        If Not chkConfirm.Checked Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please confirm that you have read the declaration above."
            v.IsValid = False
            Me.Page.Validators.Add(v)
        End If


    End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        ValidateControl()

        If Me.Page.IsValid Then

            '  If WorkingData.ShoppingCart.Items.Count = 0 Then
            '  Server.Transfer(GetResourceValue("logout"))
            '  Else
            For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
                item.Cost = 0
            Next
            Server.Transfer(GetResourceValue("checkout_makepayment_aspx"))
            '  End If



        End If

    End Sub

End Class
