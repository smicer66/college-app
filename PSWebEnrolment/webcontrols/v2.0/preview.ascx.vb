'Option Explicit On
'Option Strict On

Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Web.DynamicData
Imports CompassCC.CCCSystem.CCCCommon
Imports CompassCC.ProSolution.PSWebEnrolmentKit
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json.Linq
Imports PdfSharp.Pdf.Content.Objects
Imports CommandType = System.Data.CommandType

Partial Class preview
    Inherits CheckoutBaseControl

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)




        PreviewTitle.InnerText = WorkingData.EnrolmentRequestRow.Title
        PreviewLegalFirstName.InnerText = WorkingData.EnrolmentRequestRow.FirstForename
        PreviewLegalLastName.InnerText = WorkingData.EnrolmentRequestRow.Surname
        PreviewKnownAsFirstName.InnerText = WorkingData.EnrolmentRequestRow.KnownAs
        PreviewKnownAsLastName.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5
        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.DateOfBirth IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.Sex.Equals("M") Then
            PreviewDateOfBirth.InnerText = WorkingData.EnrolmentRequestRow.DateOfBirth
        End If

        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.Sex IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.Sex.Equals("M") Then
            PreviewBiologicalSex.InnerText = "Male"
        ElseIf WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.Sex IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.Sex.Equals("F") Then
            PreviewBiologicalSex.InnerText = "Female"
        End If

        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.KnownAs IsNot Nothing Then
            PreviewKnownAsFirstName.InnerText = WorkingData.EnrolmentRequestRow.KnownAs
        Else
            PreviewKnownAsFirstName.InnerText = "-"
        End If

        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5 IsNot Nothing Then
            PreviewKnownAsLastName.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined5
        Else
            PreviewKnownAsLastName.InnerText = "-"
        End If

        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.PreferredPronounID IsNot Nothing Then
            PreviewPreferredPronoun.InnerText = Page.Session("TPronoun")
        End If
        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.EthnicGroupID IsNot Nothing Then
            PreviewEthnicity.InnerText = Page.Session("TEthnicity")
        End If
        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentFirstLanguageID IsNot Nothing Then
            PreviewPrimaryLanguage.InnerText = Page.Session("TPrimaryLang")
        End If
        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.SchoolID IsNot Nothing Then
            PreviewPreviousSchool.InnerText = Page.Session("TPreviousSchool")
        End If
        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined4 IsNot Nothing Then
            OtherSchoolNameProvided.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined4
        End If



        'Contact Details
        PreviewPostCode.InnerText = WorkingData.EnrolmentRequestRow.PostcodeOut + " " + WorkingData.EnrolmentRequestRow.PostcodeIn
        PreviewUKMobile.InnerText = WorkingData.EnrolmentRequestRow.Tel
        PreviewHomeLineTel.InnerText = WorkingData.EnrolmentRequestRow.Tel2
        PreviewYourEmailAddress.InnerText = WorkingData.EnrolmentRequestRow.Email
        PreviewCountryYouLiveIn.InnerText = Page.Session("TCountry")
        PreviewAddressLine1.InnerText = WorkingData.EnrolmentRequestRow.Address1
        PreviewAddressLine2.InnerText = WorkingData.EnrolmentRequestRow.Address2
        PreviewAddressLine3.InnerText = WorkingData.EnrolmentRequestRow.Address3
        PreviewAddressLine4.InnerText = WorkingData.EnrolmentRequestRow.Address4

        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined17 IsNot Nothing Then
            PreviewPreviousPostcode.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined13
            PreviewPreviousHouseNumber.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined13
            PreviewPreviousAddressLine2.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined14
            PreviewPreviousAddressLine3.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined15
            PreviewPreviousAddressLine4.InnerText = WorkingData.EnrolmentRequestRow.StudentDetailUserDefined16
        Else
            PreviousAddressSection.Visible = False
            PreviewPreviousPostcode.InnerText = "-"
            PreviewPreviousHouseNumber.InnerText = "-"
            PreviewPreviousAddressLine2.InnerText = "-"
            PreviewPreviousAddressLine3.InnerText = "-"
            PreviewPreviousAddressLine4.InnerText = "-"
        End If


        'Parent/Carer Details
        PreviewParentFirstName.InnerText = WorkingData.EnrolmentRequestRow.ParentFirstName
        PreviewParentLastName.InnerText = WorkingData.EnrolmentRequestRow.ParentSurname
        PreviewParentLivesWithMe.InnerText = Page.Session("TIsLivingWithParent")
        PreviewParentRelationship.InnerText = Page.Session("TParentRelationship")
        PreviewParentMobileTel.InnerText = WorkingData.EnrolmentRequestRow.ParentMobileTel
        PreviewParentPhone.InnerText = WorkingData.EnrolmentRequestRow.ParentPhoneNumber

        'Response.Write(WorkingData.EnrolmentRequestRow.ParentPostCodeIn)

        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.ParentPostCodeOut IsNot Nothing Then
            'Response.Write(WorkingData.EnrolmentRequestRow.ParentAddress1)
            PreviewParentPostCode.InnerText = WorkingData.EnrolmentRequestRow.ParentPostCodeOut & WorkingData.EnrolmentRequestRow.ParentPostCodeIn
            PreviewParentAddress1.InnerText = WorkingData.EnrolmentRequestRow.ParentAddress1
            PreviewParentAddress2.InnerText = WorkingData.EnrolmentRequestRow.ParentAddress2
            PreviewParentAddress3.InnerText = WorkingData.EnrolmentRequestRow.ParentAddress3
            PreviewParentAddress4.InnerText = WorkingData.EnrolmentRequestRow.ParentAddress4
        Else
            PreviousAddressSection.Visible = False
            PreviewParentPostCode.InnerText = "-"
            PreviewParentAddress1.InnerText = "-"
            PreviewParentAddress2.InnerText = "-"
            PreviewParentAddress3.InnerText = "-"
            PreviewParentAddress4.InnerText = "-"
        End If

        'Immigration Details
        If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined20 IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined20.Equals("1") Then
            PreviewCurrentlyLivingInUK.InnerText = "Yes"
            PreviewCountryOfBirth.InnerText = Page.Session("TPlaceOfBirth")
            livingInUKShow.Visible = True
            If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined22 IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined22.Equals("1") Then
                PreviewDoYouHaveAUkPassport.InnerText = "Yes"
            Else
                PreviewDoYouHaveAUkPassport.InnerText = "No"
                If WorkingData.EnrolmentRequestRow IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6 IsNot Nothing AndAlso WorkingData.EnrolmentRequestRow.StudentDetailUserDefined6.Equals("N") Then   'AlwaysLivedInUk
                    visaImmigrationDetails.Visible = True
                    ukEntryDateDiv.Visible = True
                    PreviewHaveYouAlwaysLivedInUK.InnerText = "No"
                    If WorkingData.EnrolmentRequest IsNot Nothing AndAlso WorkingData.EnrolmentRequest(0) IsNot Nothing AndAlso WorkingData.EnrolmentRequest(0).DateOfEntryUK IsNot Nothing Then
                        PreviewDateOfEntryUK.InnerText = WorkingData.EnrolmentRequest(0).DateOfEntryUK
                    End If
                    PreviewDoYouHaveAVisa.InnerText = Page.Session("TDoYouHaveAVisa")
                    If Page.Session("TDoYouHaveAVisa") IsNot Nothing AndAlso Page.Session("TDoYouHaveAVisa").Equals("Yes") Then
                        visaDetailsDiv.Visible = True
                        PreviewVisaType.InnerText = Page.Session("TVisaTypeID")
                        PreviewVisaNumber.InnerText = Page.Session("TVisaDocumentNumber")
                        PreviewVisaStartDate.InnerText = Page.Session("TVisaStartDate")
                        PreviewVisaEndDate.InnerText = Page.Session("TVisaExpiryDate")
                        PreviewHaveAShareCode.InnerText = Page.Session("TDoYouHaveAVisaShareCode")

                        If Page.Session("TDoYouHaveAVisaShareCode") IsNot Nothing AndAlso Page.Session("TDoYouHaveAVisaShareCode").Equals("Yes") Then
                            PreviewShareCode.InnerText = Page.Session("TShareCode")
                        End If
                    Else
                        visaDetailsDiv.Visible = False
                    End If
                Else
                    visaImmigrationDetails.Visible = False
                    PreviewHaveYouAlwaysLivedInUK.InnerText = "Yes"
                    ukEntryDateDiv.Visible = False
                End If
            End If
        Else
            PreviewCurrentlyLivingInUK.InnerText = "No"
            livingInUKShow.Visible = False

        End If






        Dim IsAccessOrConstructionCourse As Boolean = False


        For Each item As ShoppingCartItem In WorkingData.ShoppingCart.Items
            'Response.Write(item.Description)
            If (item.Description.IndexOf("Access to HE") > -1) Then
                IsAccessOrConstructionCourse = True
            End If

        Next

        If IsAccessOrConstructionCourse.Equals(True) Then
            PreviewQualificationsDiv.Visible = True
            PersonalStatementDiv.Visible = True
        Else
            PreviewQualificationsDiv.Visible = False
            PersonalStatementDiv.Visible = False
        End If



        'Learning Difficulties
        PreviewHaveLDD.InnerText = Page.Session("TLearningDiffOrDisID")
        PreviewReceiveAdditionalSupport.InnerText = Page.Session("TDrpPrevSupport")
        PreviewHaveECP.InnerText = Page.Session("TDrpEHCP")
        PreviewRequestSupportNeedsFromSchool.InnerText = Page.Session("TDrpShareSchl")
        PreviewEmergencyEvacuateBuilding.InnerText = Page.Session("TEvacuationAssistance")
        PreviewOtherLDDDiv.InnerText = Page.Session("TLearningDifficultySelected")

        If Page.Session("TMainDisabilitySelected") IsNot Nothing Then
            disfields.Visible = True
            PreviewDisabilityCategory.InnerText = Page.Session("TMainDisabilitySelected")
        End If

        'Additional Details
        PreviewChildInCare.InnerText = Page.Session("TChildInCare")
        PreviewCaringResponsibilities.InnerText = Page.Session("TCaringResponsibilities")
        PreviewCareLeaver.InnerText = Page.Session("TCareLeaver")
        PreviewSocialCareInvolvement.InnerText = Page.Session("TSocialCareInvolvement")

        'Criminal Conviction
        PreviewPreviousCriminalConviction.InnerText = Page.Session("TPreviousConviction")


    End Sub


    Public Overrides Sub ValidateControl()
        MyBase.ValidateControl()



    End Sub

    Public Function YearsBetweenDates(ByVal StartDate As DateTime,
           ByVal EndDate As DateTime) As Integer
        ' Returns the number of years between the passed dates
        If Month(EndDate) < Month(StartDate) Or
           (Month(EndDate) = Month(StartDate) And
           (EndDate.Day) < (StartDate.Day)) Then
            Return Year(EndDate) - Year(StartDate) - 1
        Else
            Return Year(EndDate) - Year(StartDate)
        End If
    End Function



    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click



        Me.Page.Validate()

        If Me.Page.IsValid Then
            Response.Redirect(GetResourceValue("previousconvictions_aspx"))
        End If


    End Sub
End Class
