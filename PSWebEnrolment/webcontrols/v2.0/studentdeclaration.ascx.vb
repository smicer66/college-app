'Option Explicit On
'Option Strict On

Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient
Imports jSignature.Tools
Imports Svg
Imports System.Drawing.Imaging
Imports System.IO

Partial Class studentdeclaration
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Response.Write(1)
        Dim v As New CustomValidator()
        v.ErrorMessage = "Please complete your signature."
        v.IsValid = False
        Me.Page.Validators.Add(v)
        Me.ValidationSummary1.ShowSummary = True
    End Sub

    Public ReadOnly Property Signature As Byte()
        Get
            If Len(signatureData.Value) > 0 Then
                Dim output As String = Replace(signatureData.Value, "image/jsignature;base30,", "")
                Dim base30Converter As New Base30Converter()
                Dim arrBase30Data As Integer()()() = base30Converter.GetData(output)
                Dim strSVG As String = SVGConverter.ToSVG(arrBase30Data)

                'first convert it to SVG
                Dim mySVG As SvgDocument
                Dim newStream As New MemoryStream(ASCIIEncoding.[Default].GetBytes(strSVG))

                mySVG = SvgDocument.Open(Of SvgDocument)(newStream, Nothing)

                Dim tempStream As New MemoryStream()
                mySVG.Draw().Save(tempStream, ImageFormat.Png)
                Dim arrImageSS As Byte() = tempStream.GetBuffer
                tempStream.Close()

                Return arrImageSS
            Else
                Return Nothing
            End If
        End Get

    End Property

    Public Property SignatureHiddenValue() As String
        Get
            Return signatureData.Value
        End Get
        Set(ByVal value As String)
            signatureData.Value = value
        End Set
    End Property


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        'If signatureData Is Nothing Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please complete your signature."
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'End If
    End Sub


    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Response.Write(1)
        Me.Page.Validate()

        If Me.Page.IsValid Then
            'signatureData.value
            Response.Write(WorkingData.EnrolmentRequestRow.VisaExpiryDate)
            WorkingData.ApplicationRequestRow.StudentDetailUserDefined45 = ""
            Try
                Server.Transfer(GetResourceValue("checkout_makepayment_aspx"))
            Catch ex As CompassCC.CCCSystem.CCCCommon.CCCDataValidationException
                ' Show a user-friendly message and log details

                Dim v As New CustomValidator()
                v.ErrorMessage = "Data validation failed: " & ex.Message
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True

                ' If exception stores more details in ex.Data or a property, include them in logs:
                System.Diagnostics.Trace.TraceError("Validation error saving working data: " & ex.ToString())
            Catch ex As Exception
                ' Generic fallback

                Dim v As New CustomValidator()
                v.ErrorMessage = "An unexpected error occurred. Please contact support." & ex.ToString()
                v.IsValid = False
                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
                System.Diagnostics.Trace.TraceError("Unexpected error in btnContinue_Click: " & ex.ToString())
            End Try
        End If
    End Sub
End Class
