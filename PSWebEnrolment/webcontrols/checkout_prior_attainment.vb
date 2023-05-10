Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports CompassCC.CCCSystem.CCCCommon
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient

Partial Class checkout_prior_attainment
    Inherits CheckoutBaseControl



    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        div_english_maths.Visible = False
        'Breadcrumbs
        If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            breadcrumbenrols.Visible = True
            breadcrumbapps.Visible = False
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = True
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            breadcrumbenrols.Visible = True
            breadcrumbapps.Visible = False
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = False
        Else
            breadcrumbenrols.Visible = False
            breadcrumbapps.Visible = False
        End If

        'Custom code to colour the form based on the contents of the shopping basket
        'Use this when sharing pages between types (Application/Enrolment)

        'Clear class attributes first
        Me.panel1.Attributes("class") = ""



        If WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Me.panel1.Attributes("class") = "panel panel-danger"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Me.panel1.Attributes("class") = "panel panel-success"
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enquiry") Then
            Me.panel1.Attributes("class") = "panel panel-info"
        Else
            Me.panel1.Attributes("class") = "panel panel-danger"
        End If

        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
            If item.OfferingID > 0 Then

                Dim SQLDBDataReader As SqlClient.SqlDataReader
                Dim SQLDataTable As New DataTable
                Dim cmd As New SqlCommand
                Dim SQLCmd As New SqlClient.SqlConnection
                SQLCmd.ConnectionString = GetConn()
                SQLCmd.Open()
                cmd.CommandTimeout = "120"
                cmd.CommandText = "PSwebenrolmentReports.dbo.spGetOfferingDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = SQLCmd
                cmd.Parameters.AddWithValue("offeringid", item.OfferingID)
                SQLDBDataReader = cmd.ExecuteReader()
                If SQLDBDataReader.HasRows Then
                    While (SQLDBDataReader.Read)

                        If Not IsDBNull(SQLDBDataReader("EnrolmentTypeID")) Then
                            'for adult english and maths
                            If SQLDBDataReader("EnrolmentTypeID") = "2" Then
                                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined45 = "AdultEM"
                                div_english_maths.Visible = True
                                item.Cost = 0
                            End If
                        End If


                    End While
                End If
                SQLCmd.Close()
                SQLDBDataReader.Close()
            End If
        Next
        If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined45 = "AdultEM" Then
            qualsPara.Text = "English and Maths Entitlement is accessible for those Learners studying a GCSE, Functional Skills (FS) or other stated eligible English and maths qualification(s). To be eligible you must confirm that you have not already achieved a Grade 4 / C or above or overseas equivalent in Maths or English. You must not have achieved the level (or above) of that in which we enrol you.<br><br>Please enter your English and Maths qualifications below:<br>"
            ddlEng.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6
            ddlMath.SelectedValue = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined7
        Else
            qualsPara.Text = "Please list any qualifications you have achieved."
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        If WorkingData.EnrolmentRequestRow.StudentDetailUserDefined45 = "AdultEM" Then
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 = ddlEng.SelectedValue
            WorkingData.EnrolmentRequestRow.StudentDetailUserDefined7 = ddlMath.SelectedValue
        End If

        If WorkingData.ShoppingCart.ContainsItemsOfType("Application") AndAlso WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Redirect(GetResourceValue("checkout_school_employer_aspx"))
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Application") Then
            Response.Redirect(GetResourceValue("checkout_parentguardian_aspx"))
        ElseIf WorkingData.ShoppingCart.ContainsItemsOfType("Enrolment") Then
            Response.Redirect(GetResourceValue("checkout_school_employer_aspx"))
        End If

    End Sub
End Class
