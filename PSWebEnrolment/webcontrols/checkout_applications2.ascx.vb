Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports System.Data
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType
Imports System.Data.SqlClient


Partial Class webcontrols_checkout_applications2
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If Not IsPostBack Then
            rdoLearnDiff.SelectedValue = WorkingData.EnrolmentRequestRow.LearningDiffOrDisID
            If Session("euro") <> "" Then selectEuro.SelectedValue = Session("euro")
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
                        If Not IsDBNull(SQLDBDataReader("part_of_sp")) Then
                            If SQLDBDataReader("part_of_sp") = "Yes" Then
                                school.IsRequired = True
                            End If
                        End If

                    End While
                End If
                SQLCmd.Close()
                SQLDBDataReader.Close()
            End If
        Next
        'WorkingData.EnrolmentRequestRow.EuroResidentID = True

    End Sub

    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()

        If Len(rdoLearnDiff.SelectedValue) = 0 Then
            Dim cv As New CustomValidator With {
.IsValid = False,
.ErrorMessage = "Please specify whether you have a disability or learning difficulty"
}
            Me.Page.Validators.Add(cv)
        End If

        If school.IsRequired = True Then
            If WorkingData.EnrolmentRequestRow.SchoolID Is Nothing Then
                Dim v As New CustomValidator()
                v.ErrorMessage = "Please tell us your Previous School"
                v.IsValid = False

                Me.Page.Validators.Add(v)
                Me.ValidationSummary1.ShowSummary = True
            End If
        End If


        'If school.IsRequired = True Then
        '    Dim SchoolAsInt As Integer
        '    If Integer.TryParse(WorkingData.EnrolmentRequestRow.SchoolID, SchoolAsInt) Then
        '        ' childAge successfully parsed as Integer
        '    Else
        '        Dim v As New CustomValidator()
        '        v.ErrorMessage = "Please tell us your previous school"
        '        v.IsValid = False

        '        Me.Page.Validators.Add(v)
        '        Me.ValidationSummary1.ShowSummary = True
        '    End If

        'End If

        'English
        'If drpEnglish.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please select an option for English Language"
        '    v.IsValid = False

        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    If drpEnglish.SelectedValue = "Yes" Then
        '        WorkingData.EnrolmentRequestRow.StudentFirstLanguageID = 1
        '    ElseIf drpEnglish.SelectedValue = "No" Then
        '        WorkingData.EnrolmentRequestRow.StudentFirstLanguageID = 25
        '    End If
        'End If

        'Euro
        'If drpEuroResident.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please select an option for European Resident"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    If drpEuroResident.SelectedValue = "Yes" Then
        '        WorkingData.EnrolmentRequestRow.EuroResidentID = 1
        '    ElseIf drpEuroResident.SelectedValue = "No" Then
        '        WorkingData.EnrolmentRequestRow.EuroResidentID = 0
        '    End If
        'End If

        ''Immigration
        'If drpImmigrationRestriction.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please select an option for Immigration Restriction"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    WorkingData.EnrolmentRequestRow.StudentDetailUserDefined1 = drpImmigrationRestriction.SelectedValue
        'End If
        'PreviousSupportNeeds
        If drpPrevSupport.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option for whether you have previously received suppport from your school"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else


            If drpPrevSupport.SelectedValue = "True" Then
                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined8 = "Y"
            Else
                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined8 = "N"
            End If

        End If

        'ConsentToShareSupportNeeds
        If drpShareSchl.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option for consenting to share your support needs data"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else


            If drpShareSchl.SelectedValue = "True" Then
                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined42 = "Y"
            Else
                WorkingData.EnrolmentRequestRow.StudentDetailUserDefined42 = "N"
            End If

        End If

        'EHCP
        If drpEHCP.SelectedValue = "" Then
            Dim v As New CustomValidator()
            v.ErrorMessage = "Please select an option for Education and Health Care Plan"
            v.IsValid = False
            Me.Page.Validators.Add(v)
            Me.ValidationSummary1.ShowSummary = True
        Else


            If drpEHCP.SelectedValue = "True" Then
                WorkingData.EnrolmentRequestRow.HasEducationHealthCarePlan = True
            Else
                WorkingData.EnrolmentRequestRow.HasEducationHealthCarePlan = False
            End If

        End If

        ''Asylum
        'If fldAsylum.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please select an option for Asylum Seeker"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    WorkingData.EnrolmentRequestRow.StudentDetailUserDefined2 = fldAsylum.SelectedValue
        'End If

        ''FT Education
        'If drpFulltimeEducation.SelectedValue = "" Then
        '    Dim v As New CustomValidator()
        '    v.ErrorMessage = "Please select an option for the purpose for entering UK/EU"
        '    v.IsValid = False
        '    Me.Page.Validators.Add(v)
        '    Me.ValidationSummary1.ShowSummary = True
        'Else
        '    WorkingData.EnrolmentRequestRow.StudentDetailUserDefined3 = drpFulltimeEducation.SelectedValue
        'End If
        'WorkingData.EnrolmentRequestRow.StudentDetailUserDefined7 = drpReligion.SelectedValue
    End Sub
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Me.Page.Validate()
        Session("euro") = selectEuro.SelectedValue
        If Session("euro") = "1" Then WorkingData.EnrolmentRequestRow.EuroResidentID = True
        If Session("euro") = "2" Then WorkingData.EnrolmentRequestRow.EuroResidentID = False
        'If Me.Page.IsValid Then
        '    'If fldEuroResidentID.Value = False Then
        '    '    Response.Redirect(GetResourceValue("onlineenrolmentnotavailable_e_aspx"))
        '    'End If
        '    If drpEuroResident.SelectedValue IsNot "" And drpImmigrationRestriction.SelectedValue IsNot "" And drpCriminal.SelectedValue IsNot "" And fldAsylum.SelectedValue IsNot "" Then
        '        If drpEuroResident.SelectedValue = "Yes" And drpImmigrationRestriction.SelectedValue = "N" And drpCriminal.SelectedValue = "N" And fldAsylum.SelectedValue = "N" Then
        '            Me.Page.Validate()
        '        Else
        '            Me.Page.Validate()
        '            Response.Redirect(GetResourceValue("onlineapplicationnotavailable_e_aspx"), True)
        '        End If
        '        Me.Page.Validate()
        '    End If

        'End If

    End Sub

End Class