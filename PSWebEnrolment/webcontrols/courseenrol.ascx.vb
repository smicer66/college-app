Option Explicit On
Option Strict On

Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class courseenrol
    Inherits webenrolmentcontrolvalidate

    Public ReadOnly Property OfferingID() As Integer
        Get
            If Me.DesignMode OrElse CCCBlankLibrary.IsBlank(Me.Page.Request("OfferingID")) Then
                Return -1
            Else
                Return CInt(Me.Page.Request("OfferingID"))
            End If
        End Get
    End Property

Protected Overrides Sub OnLoad(e As EventArgs)
'Added by Tina to redirect to courses page till enrolments goes live
        'Response.Redirect("http://www.cityofbristol.ac.uk/courses")
        WorkingData.EnrolmentRequestRow.SentMarketingInfo = True
End Sub
End Class
