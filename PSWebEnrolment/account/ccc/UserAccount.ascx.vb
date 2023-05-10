Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class account_ccc_UserAccount
    Inherits webenrolmentcontrolvalidate

    Private m_errortext As String

    Protected Overrides Sub OnPreRender(e As EventArgs)
        MyBase.OnPreRender(e)
        errtext.InnerText = m_errortext
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)

        errtext.InnerText = m_errortext

        If WorkingData.CurrentLoggedOnUserRow Is Nothing Then
            Response.Redirect("webenrolment.aspx?page=~/account/ccc/login.ascx")
        Else
            'nned to get the offeringid of the applicant logged in
            Dim SQLDBDataReader As SqlClient.SqlDataReader
            Dim SQLDataTable As New DataTable
            Dim cmd As New SqlCommand
            Dim SQLCmd As New SqlClient.SqlConnection
            SQLCmd.ConnectionString = GetConn()
            SQLCmd.Open()
            cmd.CommandText = "PSWebenrolmentReports.dbo.spGetStudentDetailsByEmail"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = SQLCmd
            cmd.Parameters.AddWithValue("email", WorkingData.CurrentLoggedOnUserRow.Email)
            SQLDBDataReader = cmd.ExecuteReader()

            If SQLDBDataReader.HasRows Then
                While (SQLDBDataReader.Read)
                    If Not IsDBNull(SQLDBDataReader("refno")) Then Session("refno") = CStr(SQLDBDataReader("refno"))
                    If Not IsDBNull(SQLDBDataReader("refno")) Then WorkingData.EnrolmentRequestRow.RefNo = CStr(SQLDBDataReader("refno"))
                    If Not IsDBNull(SQLDBDataReader("oid")) Then WorkingData.EnrolmentRequestRow.OfferingID = CInt(SQLDBDataReader("oid"))
                    If Not IsDBNull(SQLDBDataReader("email_submitted")) Then Session("submitted") = CStr(SQLDBDataReader("email_submitted"))  ''are the already in the enrolment request?
                End While
            End If
            SQLCmd.Close()
            SQLDBDataReader.Close()
            'find offering type
            Dim offeringtype As String
            offeringtype = ""
            Dim cmd2 As New SqlCommand
            If Not WorkingData.EnrolmentRequestRow.OfferingID Is Nothing Then
                SQLCmd.ConnectionString = GetConn()
                SQLCmd.Open()
                cmd2.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
                cmd2.CommandType = CommandType.StoredProcedure
                cmd2.Connection = SQLCmd
                cmd2.Parameters.AddWithValue("offeringid", WorkingData.EnrolmentRequestRow.OfferingID)
                SQLDBDataReader = cmd2.ExecuteReader()
                If SQLDBDataReader.HasRows Then
                    While (SQLDBDataReader.Read)

                        If Not IsDBNull(SQLDBDataReader("offeringtype")) Then offeringtype = CStr(SQLDBDataReader("offeringtype"))  ''are the already in the enrolment request?
                    End While
                End If
                SQLCmd.Close()
                SQLDBDataReader.Close()
            End If

            'if authenitcated by pass the user accont web form - pointless for now
            If Not Session("refno") Is Nothing And Not WorkingData.EnrolmentRequestRow.OfferingID Is Nothing Then 'And Session("submitted") = "N" Then
                If offeringtype = "HE Course" Then
                    Response.Redirect("webenrolment.aspx?page=~%2fnewpages%2fhe%2fcourseenrol_he.ascx&OFFERINGID=" + CStr(WorkingData.EnrolmentRequestRow.OfferingID))
                Else
                    'by navigating to this URL, it will had offering id to the shopping baslet - this is required for request to work.
                    Response.Redirect("webenrolment_1618.aspx?page=~%2fnewpages%2f1618%2fcourseenrol.ascx&OFFERINGID=" + CStr(WorkingData.EnrolmentRequestRow.OfferingID))
                    'Response.Redirect("webenrolment.aspx?page=~%2fNewPages%2fcheckout_new.ascx&OFFERINGID=" + CStr(WorkingData.EnrolmentRequestRow.OfferingID))
                End If

            ElseIf Session("submitted") = "Y" Then
                'already in the request - allow once only?
                Response.Redirect("webenrolment.aspx?page=~%2fwebcontrols%2fthankyou.ascx")
            Else
                ''the should just login without begin in the data set for admissions?
                'what shall we do if in the user table but not in the student detils?
                Response.Redirect("GenericNoOnline.aspx")
                'https://apply.educationpartnershipne.ac.uk/PSWeb16/GenericNoOnline.aspx
            End If

        End If



        MyBase.OnLoad(e)
    End Sub



    Public Sub btnSubmit_OnClick(sender As Object, e As EventArgs)
        m_errortext = ""
        ValidateControl()

        If Me.Page.IsValid Then

        End If

    End Sub

    Protected Sub lstDetails_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lstDetails.ItemDataBound
        Dim item As ListViewItem = e.Item
        ' Verify if the item is a data item.
        If item.ItemType = ListViewItemType.DataItem Then


        End If



    End Sub
End Class
