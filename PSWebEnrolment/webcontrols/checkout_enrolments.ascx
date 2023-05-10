<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_enrolments.ascx.vb" Inherits="webcontrols_checkout_enrolments" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                  <li class="active">Personal Details</li>
                </ol>
   
<div class="panel panel-danger">
    <div class="panel-heading">About you</div>
     
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Title" ID="fldTitle" runat="server" IsRequired="true" LabelWidth="200" AutoFocus="true" CustomCaption="Title *"  ExcludedIDValues="Br,Dr,Mast,Prof,Revd,Sr" />
    </div>
    <div><h4>Legal Name(as Passport/Birth Certificate)</h4></div>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname" ID="fldSurname" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="Surname/Family name *"/>
    </div>
    <%--<div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname"  ID="fldPreviousSurname" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Previous surname"/>
    </div>--%>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="FirstForename" ID="fldFirstName" runat="server" IsRequired="true" LabelWidth="200" CustomCaption ="First name *" />
    </div>
   <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="OtherForenames" ID="fldMiddleName" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Middle name" />
    </div>
    <div class="form-group">        
        <cc1:StudentEnrolmentField id="datepicker" runat="server" IsRequired="true" StudentEnrolmentFieldType="DateOfBirth"  LabelWidth="250" ClientIDMode="Static" CustomFieldType="Date" CustomCaption="Date of birth (dd/mm/yyyy) *" Placeholder="dd/mm/yyyy" />        
    </div>
     <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Sex" ID="fldSex" runat="server" IsRequired ="true"  LabelWidth="200" CustomCaption ="Legally recognised Sex *"  />
    </div>
   <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="NI" ID="fldNI" runat="server" LabelWidth="200" CustomCaption="National Insurance Number" />
    </div>
   <%-- <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="StudyElsewhere" ID="fldPrevious" runat="server" LabelWidth="500" CustomCaption="Have you previously enrolled on a course at this college?" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="previousstudentrefno" ID="fldStudentNo" runat="server" LabelWidth="500" CustomCaption="If so,please enter Student ID if known" />
    </div>--%>
<%--     <div class=" form-group">
    <cc1:studentenrolmentfield id="fldSchool" runat="server" customcaption="Last school / college attended"
          labelwidth="300" StudentEnrolmentFieldType="SchoolID"  ></cc1:studentenrolmentfield>          
    </div>  --%>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="EthnicGroupID" ID="fldEthnicGroupID" runat="server" IsRequired="true" LabelWidth="300" ExcludedIDValues="99"
            CustomCaption="Ethnicity *" />
    </div>
   
    <br />
     <div class="panel-heading">Support for your course - Someone from the ALS team will get in touch if you require assistance.</div>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="LearningDiffOrDisID"   ID="fldLearningDisabilityID" runat="server" IsRequired="true" LabelWidth="800"
            CustomCaption="Do you consider yourself to have a disability and/or learning difficulty and/or health problem? *" />
    </div>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory1ID"  ID="fldDisabilityID" runat="server" IsRequired="false" LabelWidth="800"
            CustomCaption="What do you consider to be your main learning difficulty/disability/health problem (if any) " />
    </div>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="DisabilityCategory2ID" ID="fldLearningDifficultyID" runat="server" IsRequired="false" LabelWidth="800"
            CustomCaption="What do you consider to be your secondary learning difficulty/disability/health problem (if any ) " />

<%-- Are you classified as a care leaver? --%>
    </div> 
    <div class="form-group">
    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="CareLeaver" ID="fldCareLeaver" runat="server" IsRequired="false"  LabelWidth="600"
            CustomCaption="Are you classified as a care leaver?"  Width="35" />

<%-- Do you have an Education Health and Care Plan (EHCP)? --%>
    </div> 
	<div class="form-group">
    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HasEducationHealthCarePlan" ID="fldEHCP" runat="server" IsRequired="false"  LabelWidth="600"
            CustomCaption="Do you have an Education Health and Care plan (EHCP)?"  Width="35" />

    </div>
    <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HouseholdSituation1ID" ID="fldHouseHoldSituation" runat="server" IsRequired="True" LabelWidth="300"
            CustomCaption="Household Situation *" />
    </div>




 <div class="form-group">
    <asp:Label ID="lblExtraSupport" Text="Have you had extra support in secondary school" runat ="server"></asp:Label><br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpExtraSupport" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true"  >
    <asp:ListItem Text ="" Value =""></asp:ListItem>
    <asp:ListItem Text ="Yes" Value ="Yes"></asp:ListItem>
    <asp:ListItem Text ="No" Value ="No"></asp:ListItem>
    </asp:DropDownList>
    </div>

<div class="form-group">
	    <asp:Label ID="lblEAA" Text="Please list any exam access arrangements that you have had in the past e.g. extra time, reader" runat ="server"></asp:Label><br />

		<asp:TextBox  ID="txtEAA" runat="server" MaxLength="200" CssClass="form-control"/>

</div>

	



  <%--   <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="" ID="fldPast3years" runat="server" LabelWidth="600"
          CustomCaption="If you do not normally live in the UK where have you been living during the past 3 years ?" IsRequired="false"  />--%>
    </div> 
    <%-- <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SentMarketingInfo" ID="fldMarketingInfo" runat="server" IsRequired="false"  LabelWidth="1100"
            CustomCaption="We would like to keep your contact details so we can inform you of any news, courses or events that you may be interested in. If you are happy for us to contact you in the future, please tick this box."  Width="35" /> --%>
            <br /><br /> 

  <div class="form-group">
    <asp:Label ID="lblMainCourseReason" Text="Please select the main reason for you doing this course *" runat ="server"></asp:Label><br />
    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpMainCourseReason" AppendDataBoundItems="true" CssClass="form-control" EnableViewState="true"  >
    <asp:ListItem Text ="" Value =""></asp:ListItem>
        <asp:ListItem Text ="Employed - assist me to get a better paid job" Value ="029c"></asp:ListItem>
        <asp:ListItem Text ="Employed - help me change careers" Value ="029b"></asp:ListItem>
        <asp:ListItem Text ="Employed - increase knowledge for work" Value ="029a"></asp:ListItem>
        <asp:ListItem Text ="Employed - required for work" Value ="029d"></asp:ListItem>
        <asp:ListItem Text ="Help me live in the local community" Value ="025e"></asp:ListItem>
        <asp:ListItem Text ="Help me to get involved in voluntary work" Value ="025d"></asp:ListItem>
        <asp:ListItem Text ="Level 2 and below enrolments" Value ="029e"></asp:ListItem>
        <asp:ListItem Text ="Level 3+ Enrolments" Value ="030a"></asp:ListItem>
        <asp:ListItem Text ="To move to higher education" Value ="031b"></asp:ListItem>
        <asp:ListItem Text ="Unemployed - first of many steps to employment" Value ="025b"></asp:ListItem>
        <asp:ListItem Text ="Unemployed - getting back into education" Value ="025a"></asp:ListItem>
        <asp:ListItem Text ="Unemployed - to allow me to potentially enrol onto a higher level course" Value ="025c"></asp:ListItem>
        <asp:ListItem Text ="Unemployed - will help me get into paid employment" Value ="028a"></asp:ListItem>
         
    </asp:DropDownList>
    </div>


              <div class="form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HeardAboutCollegeID" ID="fldHeardAboutCollegeID" runat="server" IsRequired="false" LabelWidth="300"
            CustomCaption="How did you hear about the college?" />
    </div>  


        <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_aspx"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue" LinkResource="address_0_aspx" 
	CausesValidation="true"  EnableEnterKey="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />
