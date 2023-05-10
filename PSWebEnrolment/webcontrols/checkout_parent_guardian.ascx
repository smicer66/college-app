<%@ Control Language="VB" AutoEventWireup="false" CodeFile="checkout_parent_guardian.ascx.vb" Inherits="webcontrols_checkout_parent_guardian" %>

<%@ Register Assembly="PSWebEnrolmentKit" Namespace="CompassCC.ProSolution.PSWebEnrolmentKit"
    TagPrefix="cc1" %>


<br /><br />
                <ol class="breadcrumb" id="breadcrumbapps" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_applications2.ascx">Further Details</a></li>
                  <li class="active">Parent / Guardian</li>
                </ol>
                   <ol class="breadcrumb" id="breadcrumbenrols" runat="server">
                  <li><a href="default.aspx">Home</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout.ascx">Checkout</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments.ascx">Personal Details</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/address_0.ascx">Address</a></li>
                    <li><a href="webenrolment.aspx?page=~/webcontrols/checkout_enrolments2.ascx">Further Details</a></li>
                  <li class="active">Parent / Guardian</li>
                </ol>

<div class="panel panel-success" id="parent1panel" runat="server">
    <div class="panel-heading">Contact Details - Parent/Guardian </div>
    <br />
    <div><b>By completing this, you are giving permission for communication to be copied to your parent/guardian </b></div>
    <br />
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentTitle" ID="StudentEnrolmentField8" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Parent/Guardian Title" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentFirstName" ID="StudentEnrolmentField2" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Parent/Guardian First Name"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentSurname" ID="StudentEnrolmentField6" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Parent/Guardian Surname"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentPhoneNumber" ID="StudentEnrolmentField10" runat="server" LabelWidth="300"  CustomCaption ="Parent/Guardian Phone Number"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentMobileTel" ID="StudentEmailField1" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="Parent/Guardian Mobile" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="ParentEmailAddress" ID="StudentEnrolmentField11" runat="server"  LabelWidth="200" CustomCaption ="Parent/Guardian Email Address"/>
    </div>    
     <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="IsLivingWithParent" ID="StudentEnrolmentField16" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="I live with this person" />
    </div>
</div>

<%--<div class="panel panel-success" id="parent2panel" runat="server">
    <div class="panel-heading">Contact Details - Parent/Guardian 2</div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2FirstName" ID="StudentEnrolmentField9" runat="server" IsRequired="false" LabelWidth="200" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2Surname" ID="StudentEnrolmentField12" runat="server" IsRequired="false" LabelWidth="200" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2Title" ID="StudentEnrolmentField13" runat="server" IsRequired="false" LabelWidth="200" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2PhoneNumber" ID="StudentEnrolmentField14" runat="server" LabelWidth="200" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2EmailAddress" ID="StudentEnrolmentField15" runat="server"  LabelWidth="200"/>
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="Parent2MobileTel" ID="StudentEmailField2" runat="server" IsRequired="false" LabelWidth="200" />
    </div>
    <div class=" form-group">
        <cc1:StudentEnrolmentField StudentEnrolmentFieldType="IsLivingWithParent2" ID="StudentEnrolmentField17" runat="server" IsRequired="false" LabelWidth="200" CustomCaption ="I live with this person" />
    </div>
</div>--%>


        <cc1:CCCButton id="btnBack" runat="server" Text="Back" ImageResource="btnBack"/>
        <cc1:CCCButton ID="btnContinue" runat="server" Text="Continue" ImageResource="btnContinue"  CausesValidation="true" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" ForeColor="" />

