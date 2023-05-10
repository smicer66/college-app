Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit

Partial Class account_ccc_Logout
    Inherits webenrolmentcontrolvalidate



    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        WorkingData.WebUser.Clear()

        '   Response.Redirect(GetResourceValue("search_aspx"))
        Response.Redirect("webenrolment.aspx?page=~/account/ccc/Login.ascx")
    End Sub
End Class
