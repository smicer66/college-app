Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class checkout_makepayment
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        'Show error message if no javascript 
        Panel1.Visible = Not Me.Request.Browser.EcmaScriptVersion.Major >= 1

    End Sub


End Class
