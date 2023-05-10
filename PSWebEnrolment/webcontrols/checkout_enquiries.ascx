<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_enquiries.ascx.vb" Inherits="webcontrols_checkout_enquiries" %>
<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>

<br /><br />
                <ol class="breadcrumb">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                  <li class="active">Personal Details</li>
                </ol>

  
<div class="panel panel-info">
    <div class="panel-heading">About you</div>
      <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Title" ID="StudentEnrolmentField7" runat="server"  AutoFocus="true" IsRequired="true" LabelWidth="200"  CustomCaption ="Title *" ExcludedIDValues="Br,Dr,Mast,Prof,Revd,Sr" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="FirstForename" ID="StudentEnrolmentField1" runat="server" IsRequired="true" LabelWidth="200" CustomCaption="First name *" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Surname" ID="fldSurname" runat="server" IsRequired="true" LabelWidth="200"  CustomCaption="Last name *"/>
    </div>
    
  
    <div class=" form-group">
        <cc1:StudentEnrolmentField id="StudentEnrolmentField22" runat="server" IsRequired="true" StudentEnrolmentFieldType="DateOfBirth" LabelWidth="200" ClientIDMode="Static" CustomCaption="Date of birth(dd/mm/yyyy) *" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Sex" ID="StudentEnrolmentField4" runat="server" LabelWidth="200" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Tel" ID="StudentEnrolmentField5" IsRequired="true" runat="server"  LabelWidth="200" CustomCaption="Phone number *"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEmailField StudentEnrolmentFieldType="Email" ID="StudentEnrolmentField3" runat="server" IsRequired="false" LabelWidth="200"  Placeholder="e.g. name@domain.com"  CustomCaption="Email address"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="HeardAboutCollegeID" ID="fldHeardAboutCollegeID" runat="server" IsRequired="false" LabelWidth="300"
            CustomCaption="How did you hear about the college?" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Enquiry" ID="StudentEnrolmentFieldEnquiry" runat="server" IsRequired="true" 
            LabelWidth="200" CustomFieldType="Other" HTML5InputType="text" Placeholder="Please provide details of your enquiry" />
    </div>
     
    <%--<asp:CheckBox ID="chkMailingList" runat="server"  Text="Would you like to join our mailing list ?" Font-Bold="True"   />--%>
    <cc1:StudentEnrolmentField StudentEnrolmentFieldType="SentMarketingInfo" ID="fldMarketingInfo" runat="server" IsRequired="false" LabelWidth="425"
            CustomCaption="We would like to keep your contact details so we can inform you of any news, courses or events that you may be interested in. If you are happy for us to contact you in the future, please tick this box." Width="35" />
            <br />
    <p>Please see the full <a href="http://www.cityofbristol.ac.uk/privacy-statement/">Privacy Statement</a> for more information.</p>
</div>

        <%--<cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack" LinkResource="checkout_aspx"/>--%>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Submit" ImageResource="btnSubmit" LinkResource="" CausesValidation="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />